using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARBDO;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace eSARDAL
{
    public class FeeDAO
    {
        public List<FeeBDO> GetAllFees()
        {
            List<FeeBDO> fBDOList = new List<FeeBDO>();
            List<Fee> fList = new List<Fee>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                var allFees = (DCEnt.Fees);
                fList = allFees.ToList<Fee>();
            }

           
            fBDOList = ToFeeBDOList(fList);
        }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
}
            }
            return fBDOList;
        }

        //Changed
        public FeeBDO GetFeeForAll(string currSY)
        {
            Fee fe = new Fee();
            FeeBDO fb = new FeeBDO();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
               fe = (from f in DCEnt.Fees
                             where f.GradeLevel.Equals("0") && f.SYImplemented.Equals(currSY)
                     select f).FirstOrDefault();
            }
                ConvertFeeToFeeBDO(fe, fb);
        }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
}
            }
                return fb;
        }

        public FeeBDO GetFee(int FeeId) {
            Fee fe = new Fee();
            FeeBDO fb = new FeeBDO();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                fe = (from f in DCEnt.Fees
                      where f.FeeID==FeeId
                      select f).FirstOrDefault();
            }
            ConvertFeeToFeeBDO(fe, fb);
        }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
}
            }
            return fb;
        }

        //Changed
        public List<FeeBDO> GetAllFees(string gradeLevel, string currSY)
        {
            List<Fee> fList = new List<Fee>();
            List<FeeBDO> fBDOList = new List<FeeBDO>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                var allFees = (from f in DCEnt.Fees
                               where f.GradeLevel.Equals(gradeLevel) && f.SYImplemented.Equals(currSY)
                               select f);
                fList = allFees.ToList<Fee>();
            }

           
            fBDOList = ToFeeBDOList(fList);
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return fBDOList;
        }

        public List<FeeBDO> ToFeeBDOList(List<Fee> fList)
        {
            List<FeeBDO> fbList = new List<FeeBDO>();
            foreach (Fee f in fList)
            {
                FeeBDO fb = new FeeBDO();
                ConvertFeeToFeeBDO(f, fb);
                fbList.Add(fb);
            }
            return fbList;
        }

        public Boolean CreateFee(ref FeeBDO fBDO, ref string message)
        {
            message = "Fee Added Successfully";
            bool ret = true;

            Fee f = new Fee();
            try { 
            ConvertFeeBDOToFee(fBDO, f);
            using (var DCEnt = new DCFIEntities())
            {
                DCEnt.Fees.Attach(f);
                DCEnt.Entry(f).State = System.Data.Entity.EntityState.Added;
                int num = DCEnt.SaveChanges();

                if (num != 1)
                {
                    ret = false;
                    message = "Adding of Fee failed";
                }
            }
        }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
}
            }
            return ret;
        }

        public Boolean UpdateFee(ref FeeBDO fBDO, ref string message)
        {
            message = "Fee updated successfully.";
            Boolean ret = true;
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                var fCode = fBDO.FeeID;
                Fee fInDB = (from f in DCEnt.Fees
                             where f.FeeID == fCode
                             select f).FirstOrDefault();
                if (fInDB == null)
                {
                    throw new Exception("No Fee " + fBDO.FeeID);
                }
                DCEnt.Fees.Remove(fInDB);
                ConvertFeeBDOToFee(fBDO, fInDB);


                DCEnt.Fees.Attach(fInDB);
                DCEnt.Entry(fInDB).State = System.Data.Entity.EntityState.Modified;
                int num = DCEnt.SaveChanges();

                if (num != 1)
                {
                    ret = false;
                    message = "No fee is updated.";
                }
            }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return ret;

        }

        public void ConvertFeeToFeeBDO(Fee f, FeeBDO fBDO)
        {
            GradeLevelDAO gdao = new GradeLevelDAO();
            if (f != null)
            {
                fBDO.Deactivated = f.Deactivated;
                fBDO.FeeID = f.FeeID;
                fBDO.FeeDescription = f.FeeDescription;
                fBDO.NumPay = f.NumPay;
                fBDO.DiscountFullPay = f.DiscountFullPay;
                fBDO.Amount = f.Amount;

                fBDO.GradeLevel = f.GradeLevel;
                fBDO.SYImplemented = f.SYImplemented;
            }
            else
                fBDO = new FeeBDO();
        }

        public void ConvertFeeBDOToFee(FeeBDO fbdo, Fee f)
        {
            f.Deactivated = fbdo.Deactivated;
            f.FeeID = fbdo.FeeID;
            f.FeeDescription = fbdo.FeeDescription;
            f.NumPay = fbdo.NumPay;
            f.DiscountFullPay = fbdo.DiscountFullPay;
            f.Amount = fbdo.Amount;
            //   f.DateSet = (DateTime)fbdo.DateSet;
            f.GradeLevel = fbdo.GradeLevel;
            f.SYImplemented = fbdo.SYImplemented;
        }
    }
}
