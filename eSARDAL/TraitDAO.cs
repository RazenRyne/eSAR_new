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
    public class TraitDAO
    {
        public List<TraitBDO> GetAllTraits() {       
            List<Trait> tList = new List<Trait>();
            List<TraitBDO> tBDOList = new List<TraitBDO>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
               var allTraits = (DCEnt.Traits);
                tList = allTraits.ToList<Trait>();
            }

      
            foreach (Trait t in tList)
            {
                TraitBDO tBDO = new TraitBDO();
                ConvertTraitToTraitBDO(t, tBDO);
                tBDOList.Add(tBDO);
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
            return tBDOList;
        }

        public List<TraitBDO> GetAllTraitsForCategory(int gradeLevel)
        {
            List<Trait> tList = new List<Trait>();
            List<TraitBDO> tBDOList = new List<TraitBDO>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                tList = (from t in DCEnt.Traits
                         where t.Category ==gradeLevel
                         select t).ToList<Trait>();
            }

         
            foreach (Trait t in tList)
            {
                TraitBDO tBDO = new TraitBDO();
                ConvertTraitToTraitBDO(t, tBDO);
                tBDOList.Add(tBDO);
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
            return tBDOList;
        }


        public Boolean CreateTrait(ref TraitBDO tBDO, ref string message)
        {
            message = "Trait Added Successfully";
            bool ret = true;

            Trait t = new Trait();
            try { 
            ConvertTraitBDOToTrait(tBDO, t);
            using (var DCEnt = new DCFIEntities())
            {
                DCEnt.Traits.Attach(t);
                DCEnt.Entry(t).State = System.Data.Entity.EntityState.Added;
                int num = DCEnt.SaveChanges();

                if (num != 1)
                {
                    ret = false;
                    message = "Adding of Trait failed";
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

        public Boolean UpdateTrait(ref TraitBDO tBDO, ref string message)
        {
            message = "Trait updated successfully.";
            Boolean ret = true;
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                var traitCode = tBDO.TraitsID;
                Trait tInDB = (from t in DCEnt.Traits
                                      where t.TraitsID == traitCode
                                      select t).FirstOrDefault();
                if (tInDB == null)
                {
                    throw new Exception("No Trait with TraitsIS " + tBDO.TraitsID);
                }
                DCEnt.Traits.Remove(tInDB);
                ConvertTraitBDOToTrait(tBDO, tInDB);
                
                DCEnt.Traits.Attach(tInDB);
                DCEnt.Entry(tInDB).State = System.Data.Entity.EntityState.Modified;
                int num = DCEnt.SaveChanges();

                if (num != 1)
                {
                    ret = false;
                    message = "No trait is updated.";
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

        public void ConvertTraitToTraitBDO(Trait t, TraitBDO tBDO)
        {
            tBDO.CurrTrait = t.CurrTrait;
            tBDO.Description = t.Description;
             tBDO.TraitsID = t.TraitsID;
            tBDO.Category =(int) t.Category;
         }

        public  void ConvertTraitBDOToTrait(TraitBDO t, Trait tBDO)
        {
            tBDO.CurrTrait = t.CurrTrait;
            tBDO.Description = t.Description;
            tBDO.TraitsID = t.TraitsID;
            tBDO.Category = t.Category;
        }
    }
}
