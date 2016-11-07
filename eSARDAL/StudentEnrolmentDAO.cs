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
    public class StudentEnrolmentDAO
    {
        public List<StudentEnrollmentBDO> GetAllEnrollments()
        {
            List<StudentEnrollmentBDO> enrolBDOList = new List<StudentEnrollmentBDO>();
            List<StudentEnrollment> enrolList = new List<StudentEnrollment>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                var allEnrols = (DCEnt.StudentEnrollments);
                enrolList = allEnrols.ToList<StudentEnrollment>();
            }

         
            foreach (StudentEnrollment a in enrolList)
            {
                StudentEnrollmentBDO enrolBDO = new StudentEnrollmentBDO();
                ConvertEnrolToEnrolBDO(a, enrolBDO);
                enrolBDOList.Add(enrolBDO);
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
            return enrolBDOList;
        }

        public List<StudentEnrollmentBDO> GetAllEnrollmentsForSy(string sy)
        {
            List<StudentEnrollment> enrolList = new List<StudentEnrollment>();
            List<StudentEnrollmentBDO> enrolBDOList = new List<StudentEnrollmentBDO>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                var allEnrols = (from enrol in DCEnt.StudentEnrollments
                                 where enrol.SY == sy
                                 select enrol);
                enrolList = allEnrols.ToList<StudentEnrollment>();
            }
            
            
            foreach (StudentEnrollment a in enrolList)
            {
                StudentEnrollmentBDO enrolBDO = new StudentEnrollmentBDO();
                ConvertEnrolToEnrolBDO(a, enrolBDO);
                enrolBDOList.Add(enrolBDO);
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
            return enrolBDOList;
        }

        public StudentEnrollmentBDO GetStudentEnrolment(string studID, string sy)
        {
            string id = String.Empty;
            id = studID + sy;
            StudentEnrollment sa = null;
            StudentEnrollmentBDO enrolBDO = new StudentEnrollmentBDO();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                sa = (from enrol in DCEnt.StudentEnrollments
                      where enrol.StudentSY == id
                      select enrol).FirstOrDefault();

            }
          
            ConvertEnrolToEnrolBDO(sa, enrolBDO);
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
            return enrolBDO;
        }

        public Boolean EnrolStudent(StudentEnrollmentBDO studentBDO, ref string message)
        {
            message = "Successful registering student";
            Boolean ret = true;
            StudentEnrollment student = new StudentEnrollment();
            ConvertEnrolBDOToEnrol(studentBDO, student);
            string sid = studentBDO.StudentId;
            try{
                using (var DCEnt = new DCFIEntities())
                {
                    DCEnt.StudentEnrollments.Attach(student);
                    DCEnt.Entry(student).State = System.Data.Entity.EntityState.Added;

                    Student inDB = (from s in DCEnt.Students
                                    where s.StudentId.Equals(sid)
                                    select s).FirstOrDefault();

                    inDB.ScholarshipDiscountId = studentBDO.DiscountId;

                    DCEnt.SaveChanges();

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

        public List<string> GetEnrolledIds(string sy) {
            List<StudentEnrollment> result = new List<StudentEnrollment>();
            List<string> ids = new List<string>();
            try { 
            using (var DCEnt = new DCFIEntities()) {
                var res = (from e in DCEnt.StudentEnrollments
                          where e.SY.Equals(sy)
                          select e);
               result = res.ToList<StudentEnrollment>();
            }
            
        
            foreach (StudentEnrollment s in result) {
                ids.Add(s.StudentId);
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
            return ids;
        }

        public List<string> GetEnrolledIdsforNewTraits(string gradelevel,string sy)
        {
            List<StudentEnrollment> result = new List<StudentEnrollment>();
            List<string> ids = new List<string>();
            try
            {
                using (var DCEnt = new DCFIEntities())
                {
                    var res = (from e in DCEnt.StudentEnrollments
                               where e.SY.Equals(sy) && e.GradeLevel.Equals(gradelevel)
                               select e);
                    result = res.ToList<StudentEnrollment>();
                }


                foreach (StudentEnrollment s in result)
                {
                    ids.Add(s.StudentId);
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
            return ids;
        }

        public void ConvertEnrolToEnrolBDO(StudentEnrollment se, StudentEnrollmentBDO seb) {
            StudentDAO sd = new StudentDAO();
            StudentBDO stu = new StudentBDO();
            stu = sd.GetStudentBDO(se.StudentId);
            seb.StudentSY = se.StudentSY;
            seb.StudentId = se.StudentId;
            seb.SY = se.SY;
            seb.GradeLevel = se.GradeLevel;
            seb.GradeSectionCode = se.GradeSectionCode;
            seb.Dismissed = se.Dismissed;
            seb.Stat = se.Stat;
            seb.DiscountId = se.DiscountId;
            seb.Student = stu;      
            seb.StudentEnrollmentsID = se.StudentEnrollmentsID;
        }

        public void ConvertEnrolBDOToEnrol(StudentEnrollmentBDO seb, StudentEnrollment se)
        {
            se.StudentSY = seb.StudentSY;
            se.StudentId = seb.StudentId;
            se.SY = seb.SY;
            se.GradeLevel = seb.GradeLevel;
            se.GradeSectionCode = seb.GradeSectionCode;
            se.Dismissed = seb.Dismissed;
            se.Stat = seb.Stat;
            se.DiscountId = seb.DiscountId;
            se.StudentEnrollmentsID = seb.StudentEnrollmentsID;
        }
    }
}
