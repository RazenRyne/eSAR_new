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
    public class StudentAssessmentDAO
    {
        public List<StudentAssessmentBDO> GetAllAssessments()
        {
            List<StudentAssessmentBDO> assessBDOList = new List<StudentAssessmentBDO>();
            List<StudentAssessment> assesList = new List<StudentAssessment>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                var allAssessments = (DCEnt.StudentAssessments);
                assesList = allAssessments.ToList<StudentAssessment>();
            }

   
            foreach (StudentAssessment a in assesList)
            {
                StudentAssessmentBDO assessBDO = new StudentAssessmentBDO();
                ConvertAssessToAssessBDO(a, assessBDO);
                assessBDOList.Add(assessBDO);
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
            return assessBDOList;
        }

        public List<StudentAssessmentBDO> GetStudentAssessment(string studID, string sy)
        {
            string id = string.Empty;
            id = studID + sy;
            List<StudentAssessment> sa = null;
            List<StudentAssessmentBDO> sbList = new List<StudentAssessmentBDO>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                sa = (from assess in DCEnt.StudentAssessments
                      where assess.StudentSY == id
                        select assess).ToList<StudentAssessment>();

            }
        
            foreach (StudentAssessment s in sa) {
                StudentAssessmentBDO assessBDO = new StudentAssessmentBDO();
                ConvertAssessToAssessBDO(s, assessBDO);
                sbList.Add(assessBDO);
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
            return sbList;
        }

        public Boolean CreateStudentAssessment(StudentAssessmentBDO student)
        {
            string message = "Student Successfully Assessed";
            bool ret = true;

            StudentAssessment sa = new StudentAssessment();
            try {
                ConvertAssessBDOToAssess(student, sa);
            using (var DCEnt = new DCFIEntities())
            {
                DCEnt.StudentAssessments.Attach(sa);
                DCEnt.Entry(sa).State = System.Data.Entity.EntityState.Added;
                int num = DCEnt.SaveChanges();

                if (num != 1)
                {
                    ret = false;
                    message = "Assessment Failed";
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


        public void ConvertAssessToAssessBDO(StudentAssessment a, StudentAssessmentBDO ab) {
            FeeDAO fd = new FeeDAO();
            FeeBDO fb = new FeeBDO();
            ScholarshipDAO sd = new ScholarshipDAO();
            ScholarshipDiscountBDO sb = new ScholarshipDiscountBDO();

            if (a.DiscountId.HasValue)
            {
                int d = (int)a.DiscountId;
                sb = sd.GetScholarship(d);
                ab.DiscountId = (int)a.DiscountId;
            }
        
            ab.StudentAssessmentId = a.StudentAssessmentId;
            ab.StudentSY = a.StudentSY;
            ab.FeeID = a.FeeID;
            ab.Fee = fd.GetFee((int)ab.FeeID);

            ab.ScholarshipDiscount = sb;
        }

        public void ConvertAssessBDOToAssess(StudentAssessmentBDO ab, StudentAssessment a)
        {
            a.StudentAssessmentId = ab.StudentAssessmentId;
            a.StudentSY = ab.StudentSY;
            a.FeeID = ab.FeeID;
        }
    }
}
