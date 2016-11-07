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
    public class GradingDAO
    {
        StudentTraitDAO std = new StudentTraitDAO();
        StudentSubjectDAO ssd = new StudentSubjectDAO();
        public List<StudentSubjectBDO> GetClassList(string SubjectAssignments)
        {
            List<StudentSubjectBDO> classlist = new List<StudentSubjectBDO>();
            classlist.AddRange(ssd.GetClassList(SubjectAssignments, "M"));
            classlist.AddRange(ssd.GetClassList(SubjectAssignments, "F"));
            return classlist;
        }

        public List<StudentTraitBDO> GetAdviseesList(int GradeSectionCode)
        {
            List<StudentTraitBDO> classlist = new List<StudentTraitBDO>();
            classlist.AddRange(std.GetAdvisees(GradeSectionCode, "M"));
            classlist.AddRange(std.GetAdvisees(GradeSectionCode, "F"));
            return classlist;
        }

        public List<StudentSubjectBDO> GetStudentEvaluation(string StudentId)
        {
            List<StudentSubjectBDO> evalBdo = new List<StudentSubjectBDO>();
            List<StudentSubject> eval = new List<StudentSubject>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                var studentEval = (from s in DCEnt.StudentSubjects
                                   where s.StudentSY.Contains(StudentId)
                                   select s);
                eval = studentEval.ToList();


                foreach (StudentSubject ss in eval)
                {
                    StudentSubjectBDO ssb = new StudentSubjectBDO();
                    ssd.ConvertStuSubjectsToStuSubjectsBDO(ss, ssb);
                    evalBdo.Add(ssb);

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
            return evalBdo;
        }

        public List<StudentSubjectBDO> GetClassGradeReport(string SubjectAssignments, string gender)
        {
            List<StudentSubjectBDO> classgradeBDO = new List<StudentSubjectBDO>();
            List<StudentSubject> classgrade = new List<StudentSubject>();
            try
            {

              using (var DCEnt = new DCFIEntities())
            {
                var classEval = (from s in DCEnt.StudentSubjects
                                 where s.SubjectAssignments == SubjectAssignments && s.StudentEnrollment.Student.Gender == gender
                                 orderby s.StudentEnrollment.Student.LastName
                                 select s);
                classgrade = classEval.ToList();


                foreach (StudentSubject ss in classgrade)
                {
                    StudentSubjectBDO ssb = new StudentSubjectBDO();
                    ssd.ConvertStuSubjectsToStuSubjectsBDO(ss, ssb);
                    classgradeBDO.Add(ssb);

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
            return classgradeBDO;
        }

        public List<StudentSubjectBDO> GetStudentGradeReport(string StudentId, string sy)
        {
            List<StudentSubjectBDO> studentGradeBDO = new List<StudentSubjectBDO>();
            List<StudentSubject> studentgrade = new List<StudentSubject>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                var sg = (from s in DCEnt.StudentSubjects
                          where s.StudentSY.Equals(StudentId + sy)
                          select s);
                studentgrade = sg.ToList();


                foreach (StudentSubject ss in studentgrade)
                {
                    StudentSubjectBDO ssb = new StudentSubjectBDO();
                    ssd.ConvertStuSubjectsToStuSubjectsBDO(ss, ssb);
                    studentGradeBDO.Add(ssb);

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
            return studentGradeBDO;
        }

    }
}
