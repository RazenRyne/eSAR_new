using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARBDO;
using System.Data.Entity.SqlServer;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace eSARDAL
{
    public class GradeLevelDAO
    {
        public List<GradeLevelBDO> GetAllGradeLevels()
        {
            List<GradeLevel> gList = new List<GradeLevel>();
            List<GradeLevelBDO> gBDOList = new List<GradeLevelBDO>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                var allGradeLevels = (from gl in DCEnt.GradeLevels
                                      orderby gl.level ascending
                                      select gl);
                gList = allGradeLevels.ToList<GradeLevel>();
            }

          
            foreach (GradeLevel g in gList)
            {
                GradeLevelBDO gBDO = new GradeLevelBDO();
                ConvertGradeLevelToGradeLevelBDO(g, gBDO);
                gBDOList.Add(gBDO);
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
            return gBDOList;
        }

   
        public Boolean CreateGradeLevel(ref GradeLevelBDO gBDO, ref string message)
        {
            message = "Grade Level Added Successfully";
            bool ret = true;

            GradeLevel g = new GradeLevel();
            try { 
            ConvertGradeLevelBDOToGradeLevel(gBDO, g);
            using (var DCEnt = new DCFIEntities())
            {
                DCEnt.GradeLevels.Attach(g);
                DCEnt.Entry(g).State = System.Data.Entity.EntityState.Added;
                int num = DCEnt.SaveChanges();

                if (num != 1)
                {
                    ret = false;
                    message = "Adding of Grade Level failed";
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

        public Boolean UpdateGradeLevel(ref GradeLevelBDO gBDO, ref string message)
        {
            message = "Grade Level updated successfully.";
            Boolean ret = true;
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                var gCode = gBDO.GradeLev;
                GradeLevel gInDB = (from g in DCEnt.GradeLevels
                                    where g.GradeLevel1 == gCode
                                    select g).FirstOrDefault();
                if (gInDB == null)
                {
                    throw new Exception("No Grade Level " + gBDO.GradeLev);
                }
                DCEnt.GradeLevels.Remove(gInDB);
                gInDB.GradeLevel1 = gBDO.GradeLev;
                gInDB.Description = gBDO.Description;

                DCEnt.GradeLevels.Attach(gInDB);
                DCEnt.Entry(gInDB).State = System.Data.Entity.EntityState.Modified;
                int num = DCEnt.SaveChanges();

                if (num != 1)
                {
                    ret = false;
                    message = "No grade level is updated.";
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

        public List<FeeBDO> GetAllFeesForGradeLevel(string gradeLevel)
        {
            FeeDAO fdao = new FeeDAO();
            List<Fee> studentFees = null;
            List<FeeBDO> sfbdoList = new List<FeeBDO>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                studentFees = (from sf in DCEnt.Fees
                               where sf.GradeLevel == gradeLevel
                               select sf).ToList<Fee>();

            }
            foreach (Fee s in studentFees)
            {
                FeeBDO sBDO = new FeeBDO();
                fdao.ConvertFeeToFeeBDO(s, sBDO);
                sfbdoList.Add(sBDO);
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
            return sfbdoList;
        }

        public List<TraitBDO> GetAllTraitsForGradeLevel(int cat)
        {
            TraitDAO td = new TraitDAO();
            List<Trait> studentTraits = null;
            List<TraitBDO> tbdoList = new List<TraitBDO>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                studentTraits = (from t in DCEnt.Traits
                                 where t.Category == cat
                                 select t).ToList<Trait>();

            }
            foreach (Trait t in studentTraits)
            {
                TraitBDO tBDO = new TraitBDO();
                td.ConvertTraitToTraitBDO(t, tBDO);
                tbdoList.Add(tBDO);
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
            return tbdoList;
        }


        public void ConvertGradeLevelToGradeLevelBDO(GradeLevel g, GradeLevelBDO gbdo)
        {
            gbdo.Description = g.Description;
            gbdo.GradeLev = g.GradeLevel1;
            gbdo.Category = g.Category;
            gbdo.level = g.level;
        }

        public void ConvertGradeLevelBDOToGradeLevel(GradeLevelBDO gbdo, GradeLevel g)
        {
            g.Description = gbdo.Description;
            g.GradeLevel1 = gbdo.GradeLev;
            g.Category = gbdo.Category;
            g.level = gbdo.level;
        }


    }
}
