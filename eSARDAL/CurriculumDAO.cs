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
    public class CurriculumDAO
    {
        public List<CurriculumBDO> GetAllCurriculums()
        {
            List<Curriculum> currList = new List<Curriculum>();
            List<CurriculumBDO> currBDOList = new List<CurriculumBDO>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                var allCurr = (DCEnt.Curriculums);
                currList = allCurr.ToList<Curriculum>();
            

           
            foreach (Curriculum c in currList)
            {
                CurriculumBDO currBDO = new CurriculumBDO();
                ConvertCurriculumToCurriculumBDO(c, currBDO);
                currBDOList.Add(currBDO);
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
            return currBDOList;
        }


        private void ConvertCurriculumToCurriculumBDO(Curriculum c, CurriculumBDO currBDO)
        {
            currBDO.CurrentCurr = c.CurrentCurr;
            currBDO.CurriculumCode = c.CurriculumCode;
            currBDO.CurriculumSubjects = GetCurriculumSubjects(c.CurriculumCode);
            currBDO.Description = c.Description;
        }

        public List<CurriculumSubjectBDO> GetCurriculumSubjects(string curriculumCode)
        {
            List<CurriculumSubject> csList = new List<CurriculumSubject>();
            List<CurriculumSubjectBDO> csbList = new List<CurriculumSubjectBDO>();
            try
            {
                using (var DCEnt = new DCFIEntities())
                {
                    var allCurrSub = (from cSub in DCEnt.CurriculumSubjects
                                      where cSub.CurriculumCode == curriculumCode
                                      select cSub).ToList<CurriculumSubject>();
                    csList = allCurrSub;

                    csbList = ToCurriculumSubjectBDOList(csList);
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
            return csbList;
        }

        private List<CurriculumSubjectBDO> ToCurriculumSubjectBDOList(List<CurriculumSubject> csList)
        {
            List<CurriculumSubjectBDO> csbdoList = new List<CurriculumSubjectBDO>();
            foreach (CurriculumSubject cs in csList)
            {
                SubjectDAO sDAO = new SubjectDAO();
                SubjectBDO sbdo = new SubjectBDO();
                CurriculumSubjectBDO csbdo = new CurriculumSubjectBDO();
                csbdo.CurriculumCode = cs.CurriculumCode;
                csbdo.CurrSubCode = cs.CurrSubCode;
                csbdo.Deactivated = cs.Deactivated;
                csbdo.SubjectCode = cs.SubjectCode;
                sbdo = sDAO.GetSubject(cs.SubjectCode);

                csbdo.Sub = sbdo;
                csbdoList.Add(csbdo);
            }
            return csbdoList;
        }

        private void ConvertCurriculumBDOToCurriculum(CurriculumBDO c, Curriculum currBDO)
        {
            currBDO.CurrentCurr = c.CurrentCurr;
            currBDO.CurriculumCode = c.CurriculumCode;
            currBDO.CurriculumSubjects = ToCurriculumSubjectList(c.CurriculumSubjects);
            currBDO.Description = c.Description;
        }

        private ICollection<CurriculumSubject> ToCurriculumSubjectList(List<CurriculumSubjectBDO> csList)
        {
            ICollection<CurriculumSubject> csbdoList = new List<CurriculumSubject>();
            foreach (CurriculumSubjectBDO cs in csList)
            {
                CurriculumSubject csub = new CurriculumSubject();
                csub.CurriculumCode = cs.CurriculumCode;
                csub.CurrSubCode = cs.CurrSubCode;
                csub.Deactivated = cs.Deactivated;
                csub.SubjectCode = cs.SubjectCode;
                csbdoList.Add(csub);
            }
            return csbdoList;
        }

        public Boolean CreateCurriculum(ref CurriculumBDO cbdo, ref string message)
        {
            message = "Curriculum Added Successfully";
            bool ret = true;
            Curriculum cur = new Curriculum();
            try {
                ConvertCurriculumBDOToCurriculum(cbdo, cur);
            using (var DCEnt = new DCFIEntities())
            {
                DCEnt.Curriculums.Add(cur);
                DCEnt.Entry(cur).State = System.Data.Entity.EntityState.Added;
                int num = DCEnt.SaveChanges();


                    if (num == 0)
                    {
                        ret = false;
                        message = "Adding of Curriculum failed";
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

        public Boolean UpdateCurriculum(ref CurriculumBDO cbdo, ref string message)
        {

            message = "Curriculum updated successfully.";
            List<CurriculumSubject> toRemove;
            List<CurriculumSubject> toAdd;
            Boolean ret = true;
            Curriculum c = new Curriculum();
            Curriculum cInDB = new Curriculum();
            try { 
            ConvertCurriculumBDOToCurriculum(cbdo, c);
            

            using (var DCEnt = new DCFIEntities())
            {
                var cCode = c.CurriculumCode;
                cInDB = (from curri in DCEnt.Curriculums
                         where curri.CurriculumCode == cCode
                         select curri).FirstOrDefault();
                if (cInDB == null)
                {
                    throw new Exception("No Curriculum with Code" + c.CurriculumCode);
                }
                
                if (cInDB.CurriculumSubjects.Count == 0)
                    {
                        foreach (CurriculumSubject s in c.CurriculumSubjects)
                            cInDB.CurriculumSubjects.Add(s);
                    }
                else
                {
                    toRemove = new List<CurriculumSubject>();
                    toAdd = new List<CurriculumSubject>();
                    if (cInDB.CurriculumSubjects.Count < c.CurriculumSubjects.Count)
                    {
                        foreach (CurriculumSubject cs in c.CurriculumSubjects)
                        {
                            int co = cInDB.CurriculumSubjects.Where(sub => sub.CurrSubCode == cs.CurrSubCode).Count();
                            if (co == 0)
                                toAdd.Add(cs);
                        }
                        foreach (CurriculumSubject cs in cInDB.CurriculumSubjects)
                        {
                            int co = c.CurriculumSubjects.Where(sub => sub.CurrSubCode == cs.CurrSubCode).Count();
                            if (co == 0)
                                toRemove.Add(cs);
                        }
                    }
                    else if (cInDB.CurriculumSubjects.Count > c.CurriculumSubjects.Count)
                    {
                        foreach (CurriculumSubject cs in c.CurriculumSubjects)
                        {//check here if correct logic 
                            int co = cInDB.CurriculumSubjects.Where(sub => sub.CurrSubCode == cs.CurrSubCode).Count();
                            if (co == 0)
                                toAdd.Add(cs);

                        }
                       foreach (CurriculumSubject cs in cInDB.CurriculumSubjects)
                        {
                            int co = c.CurriculumSubjects.Where(sub => sub.CurrSubCode == cs.CurrSubCode).Count();
                            if (co == 0)
                                toRemove.Add(cs);
                        }

                    }
                    else if (cInDB.CurriculumSubjects.Count == c.CurriculumSubjects.Count)
                    {
                        foreach (CurriculumSubject s in c.CurriculumSubjects)
                        {
                            int co = cInDB.CurriculumSubjects.Where(sub => sub.CurrSubCode == s.CurrSubCode).Count();
                            if (co == 0)
                                toAdd.Add(s);
                        }
                        foreach (CurriculumSubject cs in cInDB.CurriculumSubjects)
                        {
                            int co = c.CurriculumSubjects.Where(sub => sub.CurrSubCode == cs.CurrSubCode).Count();
                            if (co == 0)
                                toRemove.Add(cs);
                        }
                    }
                    foreach (CurriculumSubject cs in toAdd)
                    {
                       cInDB.CurriculumSubjects.Add(cs);
                    }
                    foreach (CurriculumSubject cs in toRemove)
                    {
                        DCEnt.CurriculumSubjects.Remove(cs);
                        DCEnt.Entry(cs).State = System.Data.Entity.EntityState.Deleted;
                    }
                }
                if (CompareCurrs(cInDB, c))
                {
                    foreach (CurriculumSubject cs in cInDB.CurriculumSubjects)
                        DCEnt.Entry(cs).State = cs.CurriculumSubjectsID == 0 ? System.Data.Entity.EntityState.Added : System.Data.Entity.EntityState.Modified;
                    DCEnt.SaveChanges();
                }
                else
                {
                   
                   //DCEnt.Curriculums.Remove(cInDB);
                    cInDB.CurrentCurr = c.CurrentCurr;
                    cInDB.CurriculumCode = c.CurriculumCode;
                   // cInDB.CurriculumSubjects = c.CurriculumSubjects;
                    cInDB.Description = c.Description;
                    
                    DCEnt.Curriculums.Attach(cInDB);
                    DCEnt.Entry(cInDB).State = System.Data.Entity.EntityState.Modified;
                    DCEnt.SaveChanges();
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

        private Boolean CompareCurrs(Curriculum inDB, Curriculum inNew) {
            if (inDB.CurrentCurr == inNew.CurrentCurr && inDB.CurriculumCode == inNew.CurriculumCode && inDB.Description == inNew.Description)
                return true;
            else return false;

        }
    }
}
