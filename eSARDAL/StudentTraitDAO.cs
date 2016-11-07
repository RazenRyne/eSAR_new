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
    public class StudentTraitDAO
    {
        public List<StudentTraitBDO> GetAllStudentTraits()
        {
            List<StudentTraitBDO> traitBDOList = new List<StudentTraitBDO>();
            List<StudentTrait> traitList = new List<StudentTrait>();
            try {
                using (var DCEnt = new DCFIEntities())
                {
                    var allStudentTraits = (DCEnt.StudentTraits);
                    traitList = allStudentTraits.ToList<StudentTrait>();



                    foreach (StudentTrait t in traitList)
                    {
                        StudentTraitBDO traitBDO = new StudentTraitBDO();
                        ConvertStuTraitsToStuTraitsBDO(t, traitBDO);
                        traitBDOList.Add(traitBDO);
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
            return traitBDOList;
        }

        public List<StudentTraitBDO> GetStudentTraits(int studID, string sy)
        {
            List<StudentTraitBDO> traitsList = new List<StudentTraitBDO>();
            try
            {
                string id = String.Empty;

                id = studID.ToString() + sy;
                List<StudentTrait> st = new List<StudentTrait>();
                StudentTraitBDO traitBDO = new StudentTraitBDO();


                using (var DCEnt = new DCFIEntities())
                {
                    st = (from trait in DCEnt.StudentTraits
                          where trait.StudentSY == id
                          select trait).ToList<StudentTrait>();


                    foreach (StudentTrait stl in st)
                    {
                        ConvertStuTraitsToStuTraitsBDO(stl, traitBDO);
                        traitsList.Add(traitBDO);
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
            return traitsList;
        }
        
        public Boolean CreateStudentTrait(ref StudentTraitBDO sabdo, ref string message)
        {
            message = "Student Trait Successfully Saved";
            bool ret = true;

            StudentTrait sa = new StudentTrait();
            try { 
            ConvertStuTraitsBDOToStuTraits(sabdo, sa);
                using (var DCEnt = new DCFIEntities())
                {
                    DCEnt.StudentTraits.Attach(sa);
                    DCEnt.Entry(sa).State = System.Data.Entity.EntityState.Added;
                    int num = DCEnt.SaveChanges();

                    if (num != 1)
                    {
                        ret = false;
                        message = "Saving Failed";
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


        public List<StudentTraitBDO> GetAdvisees(int GradeSectionCode, string gender) {
           List<StudentTrait> studlist = new List<StudentTrait>();
            List<StudentTraitBDO> classList = new List<StudentTraitBDO>();
            try
            {
                using (var DCEnt = new DCFIEntities())
                {

                    var ss = (from sub in DCEnt.StudentTraits
                              where sub.GradeSectionCode == GradeSectionCode & sub.StudentEnrollment.Student.Gender == gender & sub.StudentEnrollment.Student.Dismissed == false
                              orderby sub.StudentEnrollment.Student.LastName
                              select sub).ToList<StudentTrait>();


                    studlist = ss;

                    foreach (StudentTrait st in studlist)
                    {
                        StudentTraitBDO ssbdo = new StudentTraitBDO();
                        ConvertStuTraitsToStuTraitsBDO(st, ssbdo);
                        classList.Add(ssbdo);
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
            return classList;
            
        }

        public void ConvertStuTraitsToStuTraitsBDO(StudentTrait st, StudentTraitBDO stbdo) {
            stbdo.StudentSY = st.StudentSY;
            stbdo.TraitsID = st.TraitsID;
            stbdo.GradeSectionCode = st.GradeSectionCode;
            stbdo.FirstPeriodicRating = st.FirstPeriodicRating;
            stbdo.SecondPeriodicRating = st.SecondPeriodicRating;
            stbdo.ThirdPeriodicRating = st.ThirdPeriodicRating;
            stbdo.FourthPeriodicRating = st.FourthPeriodicRating;
            stbdo.StudentEnrTraitCode = st.StudentEnrTraitCode;
            stbdo.FirstEntered = st.FirstEntered;
            stbdo.FirstLocked = st.FirstLocked;
            stbdo.FourthEntered = st.FourthEntered;
            stbdo.FourthLocked = st.FourthLocked;
            stbdo.LockCFourth = st.LockCFourth;
            stbdo.LockFirst = st.LockFirst;
            stbdo.LockSecond = st.LockSecond;
            stbdo.LockThird = st.LockThird;
            stbdo.SecondEntered = st.SecondEntered;
            stbdo.SecondLocked = st.SecondLocked;
            stbdo.ThirdEntered = st.ThirdEntered;
            stbdo.ThirdLocked = st.ThirdLocked;
            TraitDAO td = new TraitDAO();
            TraitBDO tb = new TraitBDO();
            td.ConvertTraitToTraitBDO(st.Trait, tb);
            stbdo.Trait = tb;

            StudentEnrolmentDAO sed = new StudentEnrolmentDAO();
            StudentEnrollmentBDO seb = new StudentEnrollmentBDO();
            sed.ConvertEnrolToEnrolBDO(st.StudentEnrollment, seb);
            stbdo.StudentEnrollment = seb;

            GradeSectionDAO gsd = new GradeSectionDAO();
            GradeSectionBDO gs = new GradeSectionBDO();
            gsd.ConvertGradeSectionToGradeSectionBDO(st.GradeSection, gs);
            stbdo.GradeSection = gs;

       }

        public void ConvertStuTraitsBDOToStuTraits(StudentTraitBDO stbdo, StudentTrait st)
        {
            st.StudentSY = stbdo.StudentSY;
            st.TraitsID = stbdo.TraitsID;
            st.FirstPeriodicRating = stbdo.FirstPeriodicRating;
            st.SecondPeriodicRating = stbdo.SecondPeriodicRating;
            st.ThirdPeriodicRating = stbdo.ThirdPeriodicRating;
            st.FourthPeriodicRating = stbdo.FourthPeriodicRating;
            st.StudentEnrTraitCode = stbdo.StudentEnrTraitCode;
            st.FirstEntered = stbdo.FirstEntered;
            st.FirstLocked = stbdo.FirstLocked;
            st.FourthEntered = stbdo.FourthEntered;
            st.FourthLocked = stbdo.FourthLocked;
            st.LockCFourth = stbdo.LockCFourth;
            st.LockFirst = stbdo.LockFirst;
            st.LockSecond = stbdo.LockSecond;
            st.LockThird = stbdo.LockThird;
            st.SecondEntered = stbdo.SecondEntered;
            st.SecondLocked = stbdo.SecondLocked;
            st.ThirdEntered = stbdo.ThirdEntered;
            st.ThirdLocked = stbdo.ThirdLocked;
            st.GradeSectionCode = stbdo.GradeSectionCode;
        }

        public Boolean SaveTraitsGrades(List<StudentTraitBDO> grades)
        {
            Boolean ret = true;
            StudentTrait gradeInDB = new StudentTrait();
            try
            {
                using (var DCEnt = new DCFIEntities())
                {

                    foreach (StudentTraitBDO grade in grades)
                    {
                        gradeInDB = (from ss in DCEnt.StudentTraits
                                     where ss.StudentEnrTraitCode == grade.StudentEnrTraitCode
                                     select ss).FirstOrDefault();

                        DCEnt.StudentTraits.Remove(gradeInDB);

                        ConvertStuTraitsBDOToStuTraits(grade, gradeInDB);


                        DCEnt.StudentTraits.Attach(gradeInDB);
                        DCEnt.Entry(gradeInDB).State = System.Data.Entity.EntityState.Modified;
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
    }
}
