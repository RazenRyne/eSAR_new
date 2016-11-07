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
    public class LearningAreaDAO
    {

        SubjectDAO sDAO = new SubjectDAO();
        GradeLevelDAO gDAO = new GradeLevelDAO();

        public List<GradeLevelBDO> GetAllGradeLevels()
        {
            return gDAO.GetAllGradeLevels();
        }


        public List<LearningAreaBDO> GetLearningAreas()
        {
            List<LearningArea> laList = new List<LearningArea>();
            List<LearningAreaBDO> laBDOList = new List<LearningAreaBDO>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                var allLA = (DCEnt.LearningAreas);
                laList = allLA.ToList<LearningArea>();
                    
                foreach (LearningArea l in laList)
                {
                    LearningAreaBDO laBDO = new LearningAreaBDO();
                    ConvertLearningAreaToLearningAreaBDO(l, laBDO);
                    laBDOList.Add(laBDO);
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
            return laBDOList;
        }


        public LearningAreaBDO GetLearningArea(string learningAreaCode)
        {
            LearningAreaBDO laBDO = null;
            LearningArea l = new LearningArea();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                var lA = (from learn in DCEnt.LearningAreas
                          where learn.LearningAreaCode == learningAreaCode
                          select learn).FirstOrDefault();

                l = lA;                
           

            if (l != null)
            {
                laBDO = new LearningAreaBDO();
                ConvertLearningAreaToLearningAreaBDO(l, laBDO);
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
            return laBDO;
        }

        public Boolean CreateLearningArea(ref LearningAreaBDO laBDO, ref string message)
        {
            message = "Learning Area Added Successfully";
            bool ret = true;

            LearningArea la = new LearningArea();
            try { 
            ConvertLearningAreaBDOToLearningArea(laBDO, la);
            using (var DCEnt = new DCFIEntities())
            {
                DCEnt.LearningAreas.Add(la);
                DCEnt.Entry(la).State = System.Data.Entity.EntityState.Added;
                int num = DCEnt.SaveChanges();


                if (num == 0)
                {
                    ret = false;
                    message = "Adding of Learning Area failed";
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

        public Boolean UpdateLearningArea(ref LearningAreaBDO laBDO, ref string message)
        {
            List<Subject> toRemove;
            List<Subject> toAdd;
            List<Subject> toUpdate;
            Boolean ret = true;
            LearningArea l = new LearningArea();
            LearningArea laInDB = new LearningArea();
            LearningArea laInDB2 = new LearningArea();
            try {

               
                using (var DCEnt = new DCFIEntities())
            {
                var learningAreaCode = laBDO.LearningAreaCode;
                laInDB = (from la in DCEnt.LearningAreas
                          where la.LearningAreaCode.Equals(learningAreaCode)
                          select la).FirstOrDefault();

                    if (laInDB == null)
                    {
                        throw new Exception("No Learning Area with Code " + laBDO.LearningAreaCode);
                    }
                 
                    l.Academic = laBDO.Academic;
                    l.Description = laBDO.Description;
                    l.LearningAreaCode = laBDO.LearningAreaCode;
                    l.RatePerSubject = laBDO.RatePerSubject;
                    l.RatePerUnit = laBDO.RatePerUnit;
                    l.Units = laBDO.Units;
                    l.Subjects = ToSubjectList(laBDO.Subjects);

                    if (laInDB.Subjects.Count == 0)
                     {
                         foreach (Subject s in l.Subjects)
                        {
                            laInDB.Subjects.Add(s);
                        }
                }
                
                else 
                {
                    toRemove = new List<Subject>();
                    toAdd = new List<Subject>();
                    toUpdate = new List<Subject>();

                        foreach (Subject s in l.Subjects)
                        {
                            Subject subj = new Subject();
                            subj = laInDB.Subjects.Where(sub => sub.SubjectCode == s.SubjectCode).FirstOrDefault();

                            if (subj == null)
                            {
                                DCEnt.Subjects.Add(s);
                                DCEnt.Entry(s).State = System.Data.Entity.EntityState.Added;
                            }
                            else
                            {
                                if (!CompareSubject(subj, s))
                                {
                                    toUpdate.Add(s);
                                }
                            }
                     }

                        //Add new Subject
                        if (toAdd.Count > 0)
                        {
                            foreach (Subject c in toAdd)
                            {
                                DCEnt.Subjects.Add(c);
                                DCEnt.Entry(c).State = System.Data.Entity.EntityState.Added;
                            }
                        }

                    foreach (Subject c in laInDB.Subjects)
                    {
                            Subject subj = new Subject();
                            subj = l.Subjects.Where(sub => sub.SubjectCode == c.SubjectCode).FirstOrDefault();
                            Subject upSubj = new Subject();
                            upSubj = toUpdate.Where(sub => sub.SubjectCode == c.SubjectCode).FirstOrDefault();

                            //toRemove subject
                            if (subj == null)
                            {
                                DCEnt.Subjects.Remove(c);
                                DCEnt.Entry(c).State = System.Data.Entity.EntityState.Deleted;
                            }

                            //toUpdate subject
                            if (upSubj != null)
                            {
                                c.Description = upSubj.Description;
                                c.MPW = upSubj.MPW;

                                DCEnt.Entry(c).State = System.Data.Entity.EntityState.Modified;
                            }


                    }
              

                        DCEnt.LearningAreas.Attach(laInDB);
                        DCEnt.Entry(laInDB).State = System.Data.Entity.EntityState.Modified;
                    }
                   
                       
                        int num = DCEnt.SaveChanges();
                              

                        if (num > 0)
                        {
                            message = "No learning area is updated.";
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

        private List<Subject> CompareSubjectLists(List<Subject> from, List<Subject> to) {
            List<Subject> diff = new List<Subject>();
            
            foreach (Subject s in from) {
                if ( !to.Exists(item=>item.SubjectCode==s.SubjectCode))
                    diff.Add(s);
            }
            
            return diff;
        }
        private Boolean CompareLearningArea(LearningArea inDB, LearningArea inNew)
        {
            if (inDB.LearningAreaCode == inNew.LearningAreaCode && inDB.Description == inNew.Description && inDB.Academic==inNew.Academic && inDB.RatePerUnit==inNew.RatePerUnit && inDB.Units==inNew.Units)
                return true;
            else return false;
        }

        private Boolean CompareSubject(Subject inDB, Subject inNew)
        {
            if (inDB.LearningAreaCode == inNew.LearningAreaCode && inDB.SubjectCode == inNew.SubjectCode && inDB.Description == inNew.Description && inDB.MPW == inNew.MPW)
                return true;
            else return false;
        }

        public List<SubjectBDO> GetSubjectsforLearningArea(string learningAreaCode)
        {
            List<SubjectBDO> subjectlist = new List<SubjectBDO>();
            ICollection<Subject> subject;
            try {

                using (var DCEnt = new DCFIEntities())
            {
                subject = (from s in DCEnt.Subjects
                           where s.LearningAreaCode.Equals(learningAreaCode)
                               select s).ToList<Subject>();
            }
            subjectlist = ToSubjectBDOList(subject);
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
            return subjectlist;
        }

        public void ConvertLearningAreaToLearningAreaBDO(LearningArea la, LearningAreaBDO labdo)
        {
          
           // labdo.Subjects = GetSubjectsforLearningArea(la.LearningAreaCode);
            labdo.Academic = la.Academic;
            labdo.Description = la.Description;
            labdo.LearningAreaCode = la.LearningAreaCode;
            labdo.Units = la.Units;
            labdo.RatePerUnit = la.RatePerUnit;
            labdo.RatePerSubject = la.RatePerSubject;
            foreach (Subject s in la.Subjects)
            {
                SubjectBDO sb = new SubjectBDO();
               ConvertSubjectToSubjectBDO(s, sb);
                sb.Academic =(bool) la.Academic;
                labdo.Subjects.Add(sb);
            }
        }

        public void ConvertSubjectToSubjectBDO(Subject s, SubjectBDO sbdo)
        {
           sbdo.Description = s.Description;
            sbdo.GradeLevel = s.GradeLevel;
            sbdo.LearningAreaCode = s.LearningAreaCode;
            sbdo.SubjectCode = s.SubjectCode;
            sbdo.SubjectID = s.SubjectID;
            sbdo.MPW = s.MPW;
        
        }
        public List<SubjectBDO> ToSubjectBDOList(ICollection<Subject> slist)
        {
               List<SubjectBDO> sbdoList = new List<SubjectBDO>();
            foreach (Subject s in slist)
            {
                SubjectBDO sbdo = new SubjectBDO();
                ConvertSubjectToSubjectBDO(s, sbdo);
                sbdoList.Add(sbdo);
            }
            return sbdoList;
        }

        public ICollection<Subject> ToSubjectList(List<SubjectBDO> slist)
        {
            SubjectDAO sd = new SubjectDAO();
            ICollection<Subject> subjectList = new List<Subject>();
            foreach (SubjectBDO sbdo in slist)
            {
                Subject subject = new Subject();
                sd.ConvertSubjectBDOToSubject(sbdo, subject);
                subjectList.Add(subject);
            }
            return subjectList;
       
        }
        public void ConvertLearningAreaBDOToLearningArea(LearningAreaBDO labdo, LearningArea la)
        {
            SubjectDAO sdao = new SubjectDAO();
            la.Academic = labdo.Academic;
            la.Description = labdo.Description;
            la.LearningAreaCode = labdo.LearningAreaCode;
            la.Units = labdo.Units;
            la.RatePerUnit = labdo.RatePerUnit;
            la.RatePerSubject = labdo.RatePerSubject;
            la.Subjects = sdao.ToSubjectList(labdo.Subjects);
        }

    }
}
