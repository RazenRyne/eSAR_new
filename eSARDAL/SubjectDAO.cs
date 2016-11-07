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
    public class SubjectDAO
    {
        public List<SubjectBDO> GetAllSbjects()
        {
            List<SubjectBDO> subjectBDOList = new List<SubjectBDO>();
            List<Subject> subjectList = new List<Subject>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                var allSubjects = (DCEnt.Subjects);
                subjectList = allSubjects.ToList<Subject>();
               foreach (Subject s in subjectList)
                { 
                SubjectBDO subjectBDO = new SubjectBDO();
                ConvertSubjectToSubjectBDO(s, subjectBDO);
                subjectBDOList.Add(subjectBDO);
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
            return subjectBDOList;
        }

        public SubjectBDO GetSubject(string subjectCode)
        {
            SubjectBDO sbdo = new SubjectBDO();
            Subject subj = new Subject();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                var sub = (from s in DCEnt.Subjects
                           where s.SubjectCode == subjectCode
                           select s).FirstOrDefault();
                subj = sub;


                ConvertSubjectToSubjectBDO(subj, sbdo);
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
            return sbdo;
        }

        public Boolean CreateSubject(ref SubjectBDO subjectBDO, ref string message)
        {
            message = "Subject Added Successfully";
            bool ret = true;

            Subject s = new Subject();
            try { 
            ConvertSubjectBDOToSubject(subjectBDO, s);

            using (var DCEnt = new DCFIEntities())
            {
                DCEnt.Subjects.Attach(s);
                DCEnt.Entry(s).State = System.Data.Entity.EntityState.Added;
                int num = DCEnt.SaveChanges();

                if (num != 1)
                {
                    ret = false;
                    message = "Adding of Subject failed";
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

        public Boolean UpdateSubject(ref SubjectBDO subjectBDO, ref string message)
        {
            message = "Subject updated successfully.";
            Boolean ret = true;
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                var subjectCode = subjectBDO.SubjectCode;
                Subject subjectInDB = (from s in DCEnt.Subjects
                                       where s.SubjectCode == subjectCode
                                       select s).FirstOrDefault();
                if (subjectInDB == null)
                {
                    throw new Exception("No Subject with SubjectCode " + subjectBDO.SubjectCode);
                }
                DCEnt.Subjects.Remove(subjectInDB);

                subjectInDB.SubjectID = subjectBDO.SubjectID;
                subjectInDB.Description = subjectBDO.Description;
                subjectInDB.GradeLevel = subjectBDO.GradeLevel;
                subjectInDB.LearningAreaCode = subjectBDO.LearningAreaCode;
                subjectInDB.SubjectCode = subjectBDO.SubjectCode;
                    subjectInDB.MPW = subjectBDO.MPW;

                DCEnt.Subjects.Attach(subjectInDB);
                DCEnt.Entry(subjectInDB).State = System.Data.Entity.EntityState.Modified;
                int num = DCEnt.SaveChanges();

                if (num != 1)
                {
                    ret = false;
                    message = "No subject is updated.";
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

        public List<SubjectBDO> GetSubjectsforLearningArea(string learningAreaCode)
        {
            List<Subject> subjects = null;
            List<SubjectBDO> sbdoList = new List<SubjectBDO>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                subjects = (from s in DCEnt.Subjects
                            where s.LearningAreaCode == learningAreaCode
                            select s).ToList<Subject>();

          
            foreach (Subject s in subjects)
            {
                SubjectBDO subjBDO = new SubjectBDO();
                ConvertSubjectToSubjectBDO(s, subjBDO);
                sbdoList.Add(subjBDO);
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
            return sbdoList;
        }

        public List<SubjectBDO> GetSubjectsforGradeLevel(string gradeLevel)
        {
            List<Subject> subjects = null;
            List<SubjectBDO> sbdoList = new List<SubjectBDO>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                subjects = (from s in DCEnt.Subjects
                            where s.GradeLevel == gradeLevel
                            select s).ToList<Subject>();

          
            foreach (Subject s in subjects)
            {
                SubjectBDO subjBDO = new SubjectBDO();
                ConvertSubjectToSubjectBDO(s, subjBDO);
                sbdoList.Add(subjBDO);
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
            return sbdoList;
        }


        public void ConvertSubjectToSubjectBDO(Subject s, SubjectBDO sbdo)
        {
        
            sbdo.Description = s.Description;
            sbdo.GradeLevel = s.GradeLevel;
            sbdo.LearningAreaCode = s.LearningAreaCode;
            sbdo.SubjectCode = s.SubjectCode;
            sbdo.SubjectID = s.SubjectID;
            sbdo.MPW = s.MPW;
            sbdo.Academic =(bool) s.LearningArea.Academic;
       
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
            }

            if (l != null)
            {
                laBDO = new LearningAreaBDO();
                laBDO.Academic = l.Academic;
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


        public void ConvertSubjectBDOToSubject(SubjectBDO sbdo, Subject s)
        {
            //LearningAreaDAO ldao = new LearningAreaDAO();
            //LearningArea l = new LearningArea();//s.LearningArea = sbdo.LearningArea;
            s.SubjectID = sbdo.SubjectID;
            s.Description = sbdo.Description;
            s.GradeLevel = sbdo.GradeLevel;
            s.LearningAreaCode = sbdo.LearningAreaCode;
            s.SubjectCode = sbdo.SubjectCode;
            s.MPW = sbdo.MPW;

          //  ldao.ConvertLearningAreaBDOToLearningArea(sbdo.LearningArea, l);
           // s.LearningArea = l;
        }

        public List<Subject> ToSubjectList(List<SubjectBDO> slist)
        {

            List<Subject> sList = new List<Subject>();
            foreach (SubjectBDO sbdo in slist)
            {
                Subject s = new Subject();
                ConvertSubjectBDOToSubject(sbdo, s);
                sList.Add(s);
            }
            return sList;
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
    }
}
