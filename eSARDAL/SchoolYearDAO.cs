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
    public class SchoolYearDAO
    {

        public SchoolYearBDO GetSYBDO(string sy)
        {
            SchoolYearBDO SYbdo = null;
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                SchoolYear SY = (from u in DCEnt.SchoolYears
                             where u.SY == sy
                             select u).FirstOrDefault();
                if (SY != null)
                {
                    SYbdo = new SchoolYearBDO()
                    {
                        SY = SY.SY,
                        CurrentSY = SY.CurrentSY
                    };
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
            return SYbdo;
        }

        public string CurrentSY() {
            SchoolYear sy = null;
            using (var DCEnt = new DCFIEntities())
            {
                sy = (from u in DCEnt.SchoolYears
                      where u.CurrentSY==true
                      select u).FirstOrDefault();

            }

            return sy.SY;
        }
        public SchoolYear GetSY(string schoolYear)
        {
            SchoolYear sy = null;
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                sy = (from u in DCEnt.SchoolYears
                        where u.SY == schoolYear
                        select u).FirstOrDefault();

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
            return sy;

        }

        public List<SchoolYearBDO> GetAllSY()
        {
            List<SchoolYear> syList = new List<SchoolYear>();
            List<SchoolYearBDO> syBDOList = new List<SchoolYearBDO>();
            try {

                using (var DCEnt = new DCFIEntities())
                {
                    var allSY = (DCEnt.SchoolYears);
                    syList = allSY.ToList<SchoolYear>();
                    
                    foreach (SchoolYear u in syList)
                    {
                        SchoolYearBDO syBDO = new SchoolYearBDO();
                        ConvertSYToSYBDO(u, syBDO);
                        syBDOList.Add(syBDO);
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
            return syBDOList;
        }

        public void ConvertSYToSYBDO(SchoolYear schoolyear, SchoolYearBDO syBDO)
        {
            syBDO.SY = schoolyear.SY;
            syBDO.CurrentSY = schoolyear.CurrentSY;
        }

        public void ConvertSYBDOToSY(SchoolYearBDO syBDO, SchoolYear sy)
        {
            sy.SY = syBDO.SY;
            sy.CurrentSY = syBDO.CurrentSY;
        }

        public Boolean CreateSY(ref SchoolYearBDO syBDO, ref string message)
        {
            message = "School Year Added Successfully";
            bool ret = true;


            SchoolYear u = new SchoolYear()
            {
                SY = syBDO.SY,
                CurrentSY = syBDO.CurrentSY
            };
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                DCEnt.SchoolYears.Attach(u);
                DCEnt.Entry(u).State = System.Data.Entity.EntityState.Added;
                int num = DCEnt.SaveChanges();
                syBDO.SY = u.SY;

                if (num != 1)
                {
                    ret = false;
                    message = "Adding of School Year failed";
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

        public Boolean UpdateSY(ref SchoolYearBDO syBDO, ref string message)
        {
            message = "School Year updated successfully.";
            Boolean ret = true;
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                var SY = syBDO.SY;
                SchoolYear syInDB = (from u in DCEnt.SchoolYears
                                 where u.SY == SY
                                 select u).FirstOrDefault();
                if (syInDB == null)
                {
                    throw new Exception(syBDO.SY + " doesn't exist");
                }
                DCEnt.SchoolYears.Remove(syInDB);

                syInDB.SY = syBDO.SY;
                syInDB.CurrentSY = syBDO.CurrentSY;

                DCEnt.SchoolYears.Attach(syInDB);
                DCEnt.Entry(syInDB).State = System.Data.Entity.EntityState.Modified;
                int num = DCEnt.SaveChanges();

                if (num != 1)
                {
                    ret = false;
                    message = "No SY is updated.";
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

        public Boolean DeleteSY(string schoolyear, ref string message)
        {
            message = "SY " + schoolyear + " Deleted successfully.";
            Boolean ret = true;
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                SchoolYear SYInDB = (from u in DCEnt.SchoolYears
                                 where u.SY == schoolyear
                                 select u).FirstOrDefault();

                if (SYInDB == null)
                {
                    throw new Exception("No SY " + schoolyear + " existed");
                }

                DCEnt.SchoolYears.Remove(SYInDB);
                DCEnt.Entry(SYInDB).State = System.Data.Entity.EntityState.Deleted;
                int num = DCEnt.SaveChanges();
                if (num != 1)
                {
                    ret = false;
                    message = "Deletion of SY Failed.";
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

    }
}
