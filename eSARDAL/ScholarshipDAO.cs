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
    public class ScholarshipDAO
    {
            public List<ScholarshipDiscountBDO> GetAllScholarships()
        {
            List<ScholarshipDiscount> sList = new List<ScholarshipDiscount>();
            List<ScholarshipDiscountBDO> sBDOList = new List<ScholarshipDiscountBDO>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                var allScholarships = (DCEnt.ScholarshipDiscounts);
                sList = allScholarships.ToList();
            }

         
            foreach (ScholarshipDiscount s in sList)
            {
                ScholarshipDiscountBDO sBDO = new ScholarshipDiscountBDO();
                ConvertScholarshipDiscountToScholarshipDiscountBDO(s, sBDO);
                sBDOList.Add(sBDO);
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
            return sBDOList;
        }

        public ScholarshipDiscountBDO GetScholarship(int discountId)
        {
            ScholarshipDiscount sd = new ScholarshipDiscount();
            ScholarshipDiscountBDO sBDO = new ScholarshipDiscountBDO();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                 sd = (from s in DCEnt.ScholarshipDiscounts
                          where s.ScholarshipDiscountId==discountId
                          select s).FirstOrDefault();
               
            }
           
                ConvertScholarshipDiscountToScholarshipDiscountBDO(sd, sBDO);
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
            return sBDO;
        }
        public Boolean CreateScholarship(ref ScholarshipDiscountBDO sBDO, ref string message)
        {
            message = "Scholarship Added Successfully";
            bool ret = true;

            //    Scholarship s = new Scholarship();
            //    ConvertScholarshipBDOToScholarship(sBDO, s);
            //    using (var DCEnt = new DCFIEntities())
            //    {
            //        DCEnt.Scholarships.Add(s);
            //        DCEnt.Entry(s).State = System.Data.Entity.EntityState.Added;
            //        int num = DCEnt.SaveChanges();
            //        sBDO.ScholarshipCode = s.ScholarshipCode;

            //        if (num != 1)
            //        {
            //            ret = false;
            //            message = "Adding of Scholarship failed";
            //        }
            //    }
            return ret;
        }

        public Boolean AddScholarshipDiscounts(List<ScholarshipDiscountBDO> discounts, int scholarshipCode, ref string message)
        {

            message = "Scholarship Discounts Added Successfully";
            Boolean ret = true;
            try { 
            foreach (ScholarshipDiscountBDO d in discounts)
            {
                ScholarshipDiscount sd = new ScholarshipDiscount();
                ConvertScholarshipDiscountBDOToScholarshipDiscount(d, sd);
                using (var DCEnt = new DCFIEntities())
                {
                    DCEnt.ScholarshipDiscounts.Attach(sd);
                    int num = DCEnt.SaveChanges();
                    if (num != 1)
                        ret = false;
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

        public Boolean AddScholarshipDiscount(ScholarshipDiscountBDO discount,int scholarshipCode, ref string message)
        {
            message = "Scholarship Discount Added Successfully";
            Boolean ret = true;

            ScholarshipDiscount sd = new ScholarshipDiscount();
            try { 
            ConvertScholarshipDiscountBDOToScholarshipDiscount(discount, sd);
            using (var DCEnt = new DCFIEntities())
            {
                DCEnt.ScholarshipDiscounts.Add(sd);
                DCEnt.Entry(sd).State = System.Data.Entity.EntityState.Added;
                int num = DCEnt.SaveChanges();

                if (num != 1)
                {
                    ret = false;
                    message = "Adding of Scholarship Discount failed";
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

        public Boolean UpdateScholarship(ref ScholarshipDiscountBDO sBDO, ref string message)
        {
            message = "Scholarship updated successfully.";
            Boolean ret = true;
            //Scholarship sc = new Scholarship();

            //ConvertScholarshipBDOToScholarship(sBDO, sc);
            //Scholarship scholarshipInDB = new Scholarship();
            //using (var DCEnt = new DCFIEntities())
            //{
            //    var scholarshipCode = sBDO.ScholarshipCode;
            //    Scholarship sInDB = (from s in DCEnt.Scholarships
            //                         where s.ScholarshipCode == scholarshipCode
            //                         select s).FirstOrDefault();
            //    if (sInDB == null)
            //    {
            //        throw new Exception("No Scholarship with ScholarshipCode " + sBDO.ScholarshipCode);
            //    }

            //    // 1st Part
            //    if (scholarshipInDB.ScholarshipDiscounts.Count == 0)
            //    {
            //        foreach (ScholarshipDiscount sd in sc.ScholarshipDiscounts)
            //        {
            //            scholarshipInDB.ScholarshipDiscounts.Add(sd);
            //        }
            //    }
            //    else if (scholarshipInDB.ScholarshipDiscounts.Count < sc.ScholarshipDiscounts.Count)
            //    {
            //        //compare 2 lists check the non existing to the other
            //        IEnumerable<ScholarshipDiscount> sdToAdd = sc.ScholarshipDiscounts.Except(scholarshipInDB.ScholarshipDiscounts);
            //        if (sdToAdd != null)
            //        {
            //            foreach (ScholarshipDiscount child in sdToAdd)
            //            {
            //                scholarshipInDB.ScholarshipDiscounts.Add(child);
            //            }
            //        }

            //        IEnumerable<ScholarshipDiscount> sdToRemove = scholarshipInDB.ScholarshipDiscounts.Except(sc.ScholarshipDiscounts);
            //        if (sdToRemove != null)
            //        {
            //            foreach (ScholarshipDiscount child in sdToRemove)
            //            {
            //                scholarshipInDB.ScholarshipDiscounts.Add(child);
            //            }
            //        }
            //    }
            //    else if (scholarshipInDB.ScholarshipDiscounts.Count > sc.ScholarshipDiscounts.Count)
            //    {
            //        //compare 2 lists check the non existing to the other
            //        IEnumerable<ScholarshipDiscount> sdToAdd = sc.ScholarshipDiscounts.Except(scholarshipInDB.ScholarshipDiscounts);
            //        if (sdToAdd != null)
            //        {
            //            foreach (ScholarshipDiscount child in sdToAdd)
            //            {
            //                scholarshipInDB.ScholarshipDiscounts.Add(child);
            //            }
            //        }

            //        // TBC
            //        IEnumerable<ScholarshipDiscount> sdToRemove = scholarshipInDB.ScholarshipDiscounts.Except(sc.ScholarshipDiscounts);
            //        if (sdToRemove != null)
            //        {
            //            foreach (ScholarshipDiscount child in sdToRemove)
            //            {
            //                scholarshipInDB.ScholarshipDiscounts.Add(child);
            //            }
            //        }
            //    }
            //    else if (scholarshipInDB.ScholarshipDiscounts.Count == sc.ScholarshipDiscounts.Count)
            //    {
            //        //compare 2 lists check the non existing to the other
            //        IEnumerable<ScholarshipDiscount> sdToAdd = sc.ScholarshipDiscounts.Except(scholarshipInDB.ScholarshipDiscounts);
            //        if (sdToAdd != null)
            //        {
            //            foreach (ScholarshipDiscount child in sdToAdd)
            //            {
            //                scholarshipInDB.ScholarshipDiscounts.Add(child);
            //            }
            //        }

            //        IEnumerable<ScholarshipDiscount> sdToRemove = scholarshipInDB.ScholarshipDiscounts.Except(sc.ScholarshipDiscounts);
            //        if (sdToRemove != null)
            //        {
            //            foreach (ScholarshipDiscount child in sdToRemove)
            //            {
            //                scholarshipInDB.ScholarshipDiscounts.Add(child);
            //            }
            //        }
            //    }
            //}
            //using (var DC = new DCFIEntities())
            //{
            //    scholarshipInDB = sc;

            //    DC.Entry(scholarshipInDB).State = System.Data.Entity.EntityState.Modified;
            //    foreach (ScholarshipDiscount sd in scholarshipInDB.ScholarshipDiscounts)
            //        DC.Entry(sd).State = sd.ScholarshipDiscountId == 0 ? System.Data.Entity.EntityState.Added : System.Data.Entity.EntityState.Modified;
            //    int number = DC.SaveChanges();

            //    if (number > 0)
            //    {
            //        // ret = false;
            //        message = "No Scholarship is updated.";
            //    }
            //}

            return ret;

        }



        //    DCEnt.Scholarships.Remove(sInDB);

        //    sInDB.Condition = sBDO.Condition;
        //    sInDB.Deactivated = sBDO.Deactivated;
        //    sInDB.Description = sBDO.Description;
        //    sInDB.Privilege = sBDO.Privilege;
        //    sInDB.ScholarshipCode = sBDO.ScholarshipCode;

        //    DCEnt.Scholarships.Attach(sInDB);
        //    DCEnt.Entry(sInDB).State = System.Data.Entity.EntityState.Modified;
        //    int num = DCEnt.SaveChanges();

        //    if (num != 1)
        //    {
        //        ret = false;
        //        message = "No scholarship is updated.";
        //    }
        //}
        //return ret;


        public Boolean UpdateScholarshipDiscount(ref ScholarshipDiscountBDO sBDO, ref string message)
        {
            message = "Scholarship discount updated successfully.";
            Boolean ret = true;
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                var scholarshipCode = sBDO.ScholarshipDiscountId;
                ScholarshipDiscount sInDB = (from s in DCEnt.ScholarshipDiscounts
                                             where s.ScholarshipDiscountId== scholarshipCode
                                             select s).FirstOrDefault();
                if (sInDB == null)
                {
                    throw new Exception("No Scholarship discount with ScholarshipCode " + sBDO.ScholarshipDiscountId);
                }
                DCEnt.ScholarshipDiscounts.Remove(sInDB);

               // sInDB.FeeID= sBDO.FeeID;
                sInDB.Deactivated = sBDO.Deactivated;
                sInDB.Discount = sBDO.Discount;
                sInDB.ScholarshipDiscountId = sBDO.ScholarshipDiscountId;

                DCEnt.ScholarshipDiscounts.Attach(sInDB);
                DCEnt.Entry(sInDB).State = System.Data.Entity.EntityState.Modified;
                int num = DCEnt.SaveChanges();

                if (num != 1)
                {
                    ret = false;
                    message = "No scholarship discount is updated.";
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

        public List<ScholarshipDiscountBDO> GetAllScholarshipDiscountsFromScholarship(int scholarshipCode)
        {
            List<ScholarshipDiscount> scholarshipDiscounts = null;
            List<ScholarshipDiscountBDO> sbdoList = new List<ScholarshipDiscountBDO>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                scholarshipDiscounts = (from sd in DCEnt.ScholarshipDiscounts
                                        where sd.ScholarshipDiscountId == scholarshipCode
                                        select sd).ToList<ScholarshipDiscount>();
            }
            foreach (ScholarshipDiscount sd in scholarshipDiscounts)
            {
                ScholarshipDiscountBDO scholDisBDO = new ScholarshipDiscountBDO();
                ConvertScholarshipDiscountToScholarshipDiscountBDO(sd, scholDisBDO);
                sbdoList.Add(scholDisBDO);
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
            return sbdoList;
        }

        public List<StudentBDO> GetAllScholarsofScholarship(int scholarshipCode)
        {
            StudentDAO sd = new StudentDAO();
            List<Student> scholars = null;
            List<StudentBDO> sbdoList = new List<StudentBDO>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                scholars = (from s in DCEnt.Students
                            where s.ScholarshipDiscountId == scholarshipCode
                            select s).ToList<Student>();

            }
            foreach (Student s in scholars)
            {
                StudentBDO studentBDO = new StudentBDO();
                sd.ConvertStudentToStudentBDO(s, studentBDO);
                sbdoList.Add(studentBDO);
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
            return sbdoList;
        }

        public List<StudentBDO> GetAllScholars()
        {
            StudentDAO sd = new StudentDAO();
            List<Student> scholars = null;
            List<StudentBDO> sbdoList = new List<StudentBDO>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                scholars = (from s in DCEnt.Students
                            select s).ToList<Student>();

            }
            foreach (Student s in scholars)
            {
                StudentBDO studentBDO = new StudentBDO();
                sd.ConvertStudentToStudentBDO(s, studentBDO);
                sbdoList.Add(studentBDO);
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
            return sbdoList;
        }

        public List<ScholarshipDiscountBDO> GetAllDiscounts(int scholarshipCode)
        {
            List<ScholarshipDiscountBDO> sdList = new List<ScholarshipDiscountBDO>();
            List<ScholarshipDiscount> discounts = new List<ScholarshipDiscount>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                discounts = (from s in DCEnt.ScholarshipDiscounts
                             where s.ScholarshipDiscountId == scholarshipCode
                             select s).ToList<ScholarshipDiscount>();
            }
            foreach (ScholarshipDiscount sd in discounts)
            {
                ScholarshipDiscountBDO sdBDO = new ScholarshipDiscountBDO();
                ConvertScholarshipDiscountToScholarshipDiscountBDO(sd, sdBDO);
                sdList.Add(sdBDO);

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
            return sdList;
        }

        public Boolean DeleteScholarshipDiscount(int sdCode)
        {
            //message = "User Deleted successfully.";
            Boolean ret = true;
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                ScholarshipDiscount sdInDB = (from sd in DCEnt.ScholarshipDiscounts
                                              where  sd.ScholarshipDiscountId == sdCode
                                              select sd).FirstOrDefault();

                if (sdInDB == null)
                {
                    throw new Exception("No Scholarship Discount with ID " + sdCode);
                }

                DCEnt.ScholarshipDiscounts.Remove(sdInDB);
                DCEnt.Entry(sdInDB).State = System.Data.Entity.EntityState.Deleted;
                int num = DCEnt.SaveChanges();
                if (num != 1)
                {
                    ret = false;
                    //message = "Deletion of User Failed.";
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

    

          public void ConvertScholarshipDiscountBDOToScholarshipDiscount(ScholarshipDiscountBDO d, ScholarshipDiscount sd)
        {
            sd.Deactivated = d.Deactivated;
            sd.Discount = d.Discount;
            sd.Scholarship = d.Scholarship;
            sd.Description = d.Description;
            sd.ScholarshipDiscountId = d.ScholarshipDiscountId;
            
            
        }

        public void ConvertScholarshipDiscountToScholarshipDiscountBDO(ScholarshipDiscount d, ScholarshipDiscountBDO sd)
        {
         
            sd.Deactivated = d.Deactivated;
            sd.Discount = (float)d.Discount;
            sd.Description = d.Description;
            sd.Scholarship = d.Scholarship;
            sd.ScholarshipDiscountId = d.ScholarshipDiscountId;
          
        }
        public void ConvertFeeBDOToFee(FeeBDO fb, Fee f)
        {
            f.Deactivated = fb.Deactivated;
            f.FeeID = fb.FeeID;
            f.FeeDescription = fb.FeeDescription;
        }

        public void ConvertFeeToFeeBDO(Fee fb, FeeBDO f)
        {
            f.Deactivated = fb.Deactivated;
            f.FeeID = fb.FeeID;
            f.FeeDescription = fb.FeeDescription;
        }

        public void ConvertScholarshipBDOToScholarship(ScholarshipDiscountBDO sbdo, ScholarshipDiscount s)
        {
           // s.Condition = sbdo.Condition;
            s.Deactivated = sbdo.Deactivated;
            s.Description = sbdo.Description;
            //s.Privilege = sbdo.Privilege;
            //s.ScholarshipCode = sbdo.ScholarshipCode;
           // s.ScholarshipDiscounts = ToScholarshipDiscountList(sbdo.ScholarshipDiscounts);
        }

        public List<ScholarshipDiscount> ToScholarshipDiscountList(List<ScholarshipDiscountBDO> scholarhsipDiscounts)
        {
            List<ScholarshipDiscount> sdList = new List<ScholarshipDiscount>();
            foreach (ScholarshipDiscountBDO sdbdo in scholarhsipDiscounts)
            {
                ScholarshipDiscount s = new ScholarshipDiscount();
                s.Deactivated = sdbdo.Deactivated;
                s.Discount = sdbdo.Discount;
                //ss.Fee = sdbdo.Fee;
             //   s.FeeID = sdbdo.FeeID;
               // s.ScholarshipCode = sdbdo.ScholarshipCode;
                s.ScholarshipDiscountId = sdbdo.ScholarshipDiscountId;
                sdList.Add(s);
            }
            return sdList;
        }
    }
}
