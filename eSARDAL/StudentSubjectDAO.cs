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
    public class StudentSubjectDAO
    {
        public List<StudentSubjectBDO> GetAllStudentSubjects()
        {
            List<StudentSubjectBDO> subjectBDOList = new List<StudentSubjectBDO>();
            List<StudentSubject> subjectList = new List<StudentSubject>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                var allStudentSubjects = (DCEnt.StudentSubjects);
                subjectList = allStudentSubjects.ToList<StudentSubject>();

            
                foreach (StudentSubject s in subjectList)
                {
                    StudentSubjectBDO subjectBDO = new StudentSubjectBDO();
                    ConvertStuSubjectsToStuSubjectsBDO(s, subjectBDO);
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

        public List<StudentSubjectBDO> GetClassList(string SubjectAssignments, string gender)
        {
            List<StudentSubject> studlist = new List<StudentSubject>();
            List<StudentSubjectBDO> classList = new List<StudentSubjectBDO>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                DCEnt.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
                var ss = (from sub in DCEnt.StudentSubjects
                          where sub.SubjectAssignments == SubjectAssignments & sub.StudentEnrollment.Student.Gender == gender & sub.StudentEnrollment.Student.Dismissed== false 
                          orderby sub.StudentEnrollment.Student.LastName
                          select sub).ToList<StudentSubject>();
                

                studlist = ss;

                foreach (StudentSubject st in studlist)
                {
                    StudentSubjectBDO ssbdo = new StudentSubjectBDO();
                    ConvertStuSubjectsToStuSubjectsBDO(st, ssbdo);
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

        public List<StudentSubjectBDO> GetStudentSubjects(string studentsy)
        {
            List<StudentSubjectBDO> ssb = new List<StudentSubjectBDO>();
            List<StudentSubject> ss = new List<StudentSubject>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                ss = (from sub in DCEnt.StudentSubjects
                      where sub.StudentSY == studentsy
                      select sub).ToList<StudentSubject>();


                foreach (StudentSubject s in ss)
                {
                    StudentSubjectBDO subBDO = new StudentSubjectBDO();
                    ConvertStuSubjectsToStuSubjectsBDO(s, subBDO);
                    ssb.Add(subBDO);
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
            return ssb;
        }


        public Boolean CreateStudentSubject(StudentSubjectBDO subBDO,ref string message)
        {
            message = "Student Subject Successfully Saved";
            bool ret = true;

            StudentSubject sa = new StudentSubject();
            ConvertStuSubjectsBDOToStuSubjects(subBDO, sa);
            try{
                using (var DCEnt = new DCFIEntities())
                {
                    DCEnt.StudentSubjects.Attach(sa);
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

        public Boolean DeleteStudentSubject(StudentSubjectBDO ssb, ref string message) {
            String studentEnrSub = ssb.StudentEnrSubCode;
            try {
                using (var DCEnt = new DCFIEntities())
                {
                    var x = (from ss in DCEnt.StudentSubjects
                             where ss.StudentEnrSubCode == studentEnrSub
                             select ss).FirstOrDefault();
                    if (x != null)
                    {
                        DCEnt.StudentSubjects.Remove(x);
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
            return true;
        }

        public Boolean DeleteExistingSubjects(string studentsy)
        {
            List<StudentSubject> ss = new List<StudentSubject>();
            try
            {
                using (var DCEnt = new DCFIEntities())
                {
                    ss = (from sub in DCEnt.StudentSubjects
                          where sub.StudentSY == studentsy
                          select sub).ToList<StudentSubject>();


                    foreach (StudentSubject s in ss)
                    {
                        DCEnt.StudentSubjects.Remove(s);
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
            return true;
        }

        public Boolean UpdateStudentSection(String studentSy, int gradeSectionCode) {
             try
            {
                using (var DCEnt = new DCFIEntities())
                {
                    var x = (from ss in DCEnt.StudentEnrollments
                             where ss.StudentSY == studentSy
                             select ss).FirstOrDefault();


                    StudentEnrollment s = new StudentEnrollment();
                    s.DiscountId = x.DiscountId;
                    s.Dismissed = x.Dismissed;
                    s.GradeLevel = x.GradeLevel;
                    s.Stat = x.Stat;
                    s.StudentEnrollmentsID = x.StudentEnrollmentsID;
                    //s.SY = x.SY;
                    
                    DCEnt.StudentEnrollments.Remove(x);
                    x.StudentId = studentSy.Substring(0, 8);
                    x.GradeSectionCode = gradeSectionCode;
                    x.SY = studentSy.Substring(8,9);
                    x.DiscountId = s.DiscountId;
                    x.GradeLevel = s.GradeLevel;
                    x.Stat = s.Stat;

                    DCEnt.StudentEnrollments.Attach(x);

                    DCEnt.Entry(x).State = System.Data.Entity.EntityState.Modified;
                    int num = DCEnt.SaveChanges();

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
            return true;
        }


        public List<StudentSubjectBDO> GetFailedSubjects(string IdSy) {
            List<StudentSubject> fails = new List<StudentSubject>();
            List<StudentSubjectBDO> ssbl = new List<StudentSubjectBDO>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                var allStudentSubjects = (from subs in DCEnt.StudentSubjects
                                          where subs.StudentSY.Equals(IdSy) && subs.FourthPeriodicRating < 75.00
                                          select subs);
                fails = allStudentSubjects.ToList<StudentSubject>();

               
                foreach (StudentSubject ss in fails)
                {
                    StudentSubjectBDO ssb = new StudentSubjectBDO();
                    ConvertStuSubjectsToStuSubjectsBDO(ss, ssb);
                    ssbl.Add(ssb);

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
            return ssbl;
        }

        public Boolean SaveClassGrades(List<StudentSubjectBDO> grades) {
            Boolean ret = true;
            StudentSubject gradeInDB = new StudentSubject();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                
                foreach (StudentSubjectBDO grade in grades)
                {
                    gradeInDB = (from ss in DCEnt.StudentSubjects
                                 where ss.StudentEnrSubCode == grade.StudentEnrSubCode
                                 select ss).FirstOrDefault();

                    DCEnt.StudentSubjects.Remove(gradeInDB);
                 
                    ConvertStuSubjectsBDOToStuSubjects(grade, gradeInDB);


                    DCEnt.StudentSubjects.Attach(gradeInDB);
                    DCEnt.Entry(gradeInDB).State = System.Data.Entity.EntityState.Modified;
                    int num = DCEnt.SaveChanges();

                        if (grade.FourthPeriodicRating != 0 && grade.FirstPeriodicRating != 0 && grade.SecondPeriodicRating != 0 && grade.ThirdPeriodicRating != 0)
                                UpdateStudentGPA(grade.StudentSY);                         
                        
                        else if (grade.FourthPeriodicRating == 0 && grade.ThirdPeriodicRating != 0 && grade.FirstPeriodicRating != 0 && grade.SecondPeriodicRating != 0)
                            UpdateStudentThirdGPA(grade.StudentSY);
                        
                        else if (grade.FourthPeriodicRating == 0 && grade.ThirdPeriodicRating == 0 && grade.SecondPeriodicRating != 0 && grade.FirstPeriodicRating != 0)
                             UpdateStudentSecondGPA(grade.StudentSY);
                        
                        else if (grade.FourthPeriodicRating == 0 && grade.ThirdPeriodicRating == 0 && grade.SecondPeriodicRating == 0 && grade.FirstPeriodicRating != 0)
                           UpdateStudentFirstGPA(grade.StudentSY);
                        
                        if (num != 1)
                        ret = false;
                    
                }

            }
            
        }catch (DbEntityValidationException dbEx)
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



        public void UpdateStudentThirdGPA(string StudentSY)
        {
            List<StudentSubject> gradesInDB = new List<StudentSubject>();
            try
            {
                using (var DCEnt = new DCFIEntities())
                {
                    Student studentInDB = (from s in DCEnt.Students
                                           where s.StudentId == StudentSY.Substring(0, 8)
                                           select s).FirstOrDefault();

                    DCEnt.Students.Remove(studentInDB);

                    List<ScholarshipDiscount> sd = (DCEnt.ScholarshipDiscounts).ToList<ScholarshipDiscount>();

                    gradesInDB = (from g in DCEnt.StudentSubjects
                                  where g.StudentSY == StudentSY
                                  select g).ToList<StudentSubject>();

                    double average = 0.00;
                    double total = 0.00;
                 
                   
                    if (studentInDB.GradeLevel == "1" || studentInDB.GradeLevel == "2")
                    {
                        int totalUnits = 0;
                        foreach (StudentSubject grade in gradesInDB)
                        {
                            total += (double)grade.ThirdPeriodicRating;
                            totalUnits += 1;
                            
                        }

                        average = total / totalUnits;
                        studentInDB.ThirdAverage = average;
                       
                    }
                    else if (studentInDB.GradeLevel == "3" || studentInDB.GradeLevel == "4")
                    {
                        double totalUnits = 0.00;
                        foreach (StudentSubject grade in gradesInDB)
                        {
                            double finalG = 0.00;
                            if (grade.SubjectCode.Substring(0, 3) == "COM")
                            {
                                totalUnits += .25;
                                finalG = (double)grade.ThirdPeriodicRating * 0.25;
                            }
                            else
                            {
                                totalUnits += 1;
                                finalG = (double)grade.ThirdPeriodicRating;
                            }

                            
                            total += finalG;
                        }
                        
                        average = total / totalUnits;
                        studentInDB.ThirdAverage = average;
                       
                    }
                    else if (studentInDB.GradeLevel == "5" || studentInDB.GradeLevel == "6")
                    {
                        double totalUnits = 0.00;
                        foreach (StudentSubject grade in gradesInDB)
                        {
                            double finalG = 0.00;
                            if (grade.SubjectCode.Substring(0, 3) == "COM")
                            {
                                totalUnits += .25;
                                finalG = (double)grade.ThirdPeriodicRating * 0.25;
                            }
                            else
                            {
                                totalUnits += 1;
                                finalG = (double)grade.ThirdPeriodicRating;
                            }

                          total += finalG;
                        }
                      
                        average = total / totalUnits;
                        studentInDB.ThirdAverage = average;
                       
                    }
                    else if (studentInDB.GradeLevel == "7" || studentInDB.GradeLevel == "8" || studentInDB.GradeLevel == "9")
                    {
                        double totalUnits = 0.00;
                        foreach (StudentSubject grade in gradesInDB)
                        {
                            double units = 0.00;
                            double finalG = 0.00;
                            units = (double)grade.Subject.LearningArea.Units;
                            finalG = (double)grade.ThirdPeriodicRating * units;
                            totalUnits += units;
                            
                            total += finalG;
                        }
                       average = total / totalUnits;
                        studentInDB.ThirdAverage = average;
                     
                    }
                    else if (studentInDB.GradeLevel == "10")
                    {
                        double totalUnits = 0.00;
                        foreach (StudentSubject grade in gradesInDB)
                        {
                            double units = 0.00;
                            double finalG = 0.00;
                            if (grade.SubjectCode == "MAPEH")
                                units = 1.5;

                            else
                                units = (double)grade.Subject.LearningArea.Units;
                            
                            finalG = (double)grade.ThirdPeriodicRating * units;
                            totalUnits += units;

                            total += finalG;
                        }
                      
                        average = total / totalUnits;
                        studentInDB.ThirdAverage = average;
                     }

                    DCEnt.Students.Attach(studentInDB);
                    DCEnt.Entry(studentInDB).State = System.Data.Entity.EntityState.Modified;
                    int num = DCEnt.SaveChanges();
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
        }

        public void UpdateStudentSecondGPA(string StudentSY)
        {
            List<StudentSubject> gradesInDB = new List<StudentSubject>();
            try
            {
                using (var DCEnt = new DCFIEntities())
                {
                    Student studentInDB = (from s in DCEnt.Students
                                           where s.StudentId == StudentSY.Substring(0, 8)
                                           select s).FirstOrDefault();

                    DCEnt.Students.Remove(studentInDB);

                    List<ScholarshipDiscount> sd = (DCEnt.ScholarshipDiscounts).ToList<ScholarshipDiscount>();

                    gradesInDB = (from g in DCEnt.StudentSubjects
                                  where g.StudentSY == StudentSY
                                  select g).ToList<StudentSubject>();

                    double average = 0.00;
                    double total = 0.00;


                    if (studentInDB.GradeLevel == "1" || studentInDB.GradeLevel == "2")
                    {
                        int totalUnits = 0;
                        foreach (StudentSubject grade in gradesInDB)
                        {
                            total += (double)grade.SecondPeriodicRating;
                            totalUnits += 1;

                        }

                        average = total / totalUnits;
                        studentInDB.SecondAverage = average;

                    }
                    else if (studentInDB.GradeLevel == "3" || studentInDB.GradeLevel == "4")
                    {
                        double totalUnits = 0.00;
                        foreach (StudentSubject grade in gradesInDB)
                        {
                            double finalG = 0.00;
                            if (grade.SubjectCode.Substring(0, 3) == "COM")
                            {
                                totalUnits += .25;
                                finalG = (double)grade.SecondPeriodicRating * 0.25;
                            }
                            else
                            {
                                totalUnits += 1;
                                finalG = (double)grade.SecondPeriodicRating;
                            }


                            total += finalG;
                        }

                        average = total / totalUnits;
                        studentInDB.SecondAverage = average;

                    }
                    else if (studentInDB.GradeLevel == "5" || studentInDB.GradeLevel == "6")
                    {
                        double totalUnits = 0.00;
                        foreach (StudentSubject grade in gradesInDB)
                        {
                            double finalG = 0.00;
                            if (grade.SubjectCode.Substring(0, 3) == "COM")
                            {
                                totalUnits += .25;
                                finalG = (double)grade.SecondPeriodicRating * 0.25;
                            }
                            else
                            {
                                totalUnits += 1;
                                finalG = (double)grade.SecondPeriodicRating;
                            }

                            total += finalG;
                        }

                        average = total / totalUnits;
                        studentInDB.SecondAverage = average;

                    }
                    else if (studentInDB.GradeLevel == "7" || studentInDB.GradeLevel == "8" || studentInDB.GradeLevel == "9")
                    {
                        double totalUnits = 0.00;
                        foreach (StudentSubject grade in gradesInDB)
                        {
                            double units = 0.00;
                            double finalG = 0.00;
                            units = (double)grade.Subject.LearningArea.Units;
                            finalG = (double)grade.SecondPeriodicRating * units;
                            totalUnits += units;

                            total += finalG;
                        }
                        average = total / totalUnits;
                        studentInDB.SecondAverage = average;

                    }
                    else if (studentInDB.GradeLevel == "10")
                    {
                        double totalUnits = 0.00;
                        foreach (StudentSubject grade in gradesInDB)
                        {
                            double units = 0.00;
                            double finalG = 0.00;
                            if (grade.SubjectCode == "MAPEH")
                                units = 1.5;

                            else
                                units = (double)grade.Subject.LearningArea.Units;

                            finalG = (double)grade.SecondPeriodicRating * units;
                            totalUnits += units;

                            total += finalG;
                        }

                        average = total / totalUnits;
                        studentInDB.SecondAverage = average;
                    }

                    DCEnt.Students.Attach(studentInDB);
                    DCEnt.Entry(studentInDB).State = System.Data.Entity.EntityState.Modified;
                    int num = DCEnt.SaveChanges();
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
        }

        public void UpdateStudentFirstGPA(string StudentSY)
        {
            List<StudentSubject> gradesInDB = new List<StudentSubject>();
            try
            {
                using (var DCEnt = new DCFIEntities())
                {
                    Student studentInDB = (from s in DCEnt.Students
                                           where s.StudentId == StudentSY.Substring(0, 8)
                                           select s).FirstOrDefault();

                    DCEnt.Students.Remove(studentInDB);

                    List<ScholarshipDiscount> sd = (DCEnt.ScholarshipDiscounts).ToList<ScholarshipDiscount>();

                    gradesInDB = (from g in DCEnt.StudentSubjects
                                  where g.StudentSY == StudentSY
                                  select g).ToList<StudentSubject>();

                    double average = 0.00;
                    double total = 0.00;


                    if (studentInDB.GradeLevel == "1" || studentInDB.GradeLevel == "2")
                    {
                        int totalUnits = 0;
                        foreach (StudentSubject grade in gradesInDB)
                        {
                            total += (double)grade.FirstPeriodicRating;
                            totalUnits += 1;

                        }

                        average = total / totalUnits;
                        studentInDB.FirstAverage = average;

                    }
                    else if (studentInDB.GradeLevel == "3" || studentInDB.GradeLevel == "4")
                    {
                        double totalUnits = 0.00;
                        foreach (StudentSubject grade in gradesInDB)
                        {
                            double finalG = 0.00;
                            if (grade.SubjectCode.Substring(0, 3) == "COM")
                            {
                                totalUnits += .25;
                                finalG = (double)grade.FirstPeriodicRating * 0.25;
                            }
                            else
                            {
                                totalUnits += 1;
                                finalG = (double)grade.FirstPeriodicRating;
                            }


                            total += finalG;
                        }

                        average = total / totalUnits;
                        studentInDB.FirstAverage = average;

                    }
                    else if (studentInDB.GradeLevel == "5" || studentInDB.GradeLevel == "6")
                    {
                        double totalUnits = 0.00;
                        foreach (StudentSubject grade in gradesInDB)
                        {
                            double finalG = 0.00;
                            if (grade.SubjectCode.Substring(0, 3) == "COM")
                            {
                                totalUnits += .25;
                                finalG = (double)grade.FirstPeriodicRating * 0.25;
                            }
                            else
                            {
                                totalUnits += 1;
                                finalG = (double)grade.FirstPeriodicRating;
                            }

                            total += finalG;
                        }

                        average = total / totalUnits;
                        studentInDB.FirstAverage = average;

                    }
                    else if (studentInDB.GradeLevel == "7" || studentInDB.GradeLevel == "8" || studentInDB.GradeLevel == "9")
                    {
                        double totalUnits = 0.00;
                        foreach (StudentSubject grade in gradesInDB)
                        {
                            double units = 0.00;
                            double finalG = 0.00;
                            units = (double)grade.Subject.LearningArea.Units;
                            finalG = (double)grade.FirstPeriodicRating * units;
                            totalUnits += units;

                            total += finalG;
                        }
                        average = total / totalUnits;
                        studentInDB.FirstAverage = average;

                    }
                    else if (studentInDB.GradeLevel == "10")
                    {
                        double totalUnits = 0.00;
                        foreach (StudentSubject grade in gradesInDB)
                        {
                            double units = 0.00;
                            double finalG = 0.00;
                            if (grade.SubjectCode == "MAPEH")
                                units = 1.5;

                            else
                                units = (double)grade.Subject.LearningArea.Units;

                            finalG = (double)grade.FirstPeriodicRating * units;
                            totalUnits += units;

                            total += finalG;
                        }

                        average = total / totalUnits;
                        studentInDB.FirstAverage = average;
                    }

                    DCEnt.Students.Attach(studentInDB);
                    DCEnt.Entry(studentInDB).State = System.Data.Entity.EntityState.Modified;
                    int num = DCEnt.SaveChanges();
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
        }


        public void UpdateStudentGPA(string StudentSY) {
            List<StudentSubject> gradesInDB = new List<StudentSubject>();
            try
            {
                using (var DCEnt = new DCFIEntities())
                {
                    Student studentInDB = (from s in DCEnt.Students
                                           where s.StudentId == StudentSY.Substring(0, 8)
                                           select s).FirstOrDefault();

                    DCEnt.Students.Remove(studentInDB);

                    List<ScholarshipDiscount> sd = (DCEnt.ScholarshipDiscounts).ToList<ScholarshipDiscount>();

                    gradesInDB = (from g in DCEnt.StudentSubjects
                                  where g.StudentSY == StudentSY
                                  select g).ToList<StudentSubject>();

                    double average = 0.00;
                    double total = 0.00;
                   double unitsfailed = 0.00;
                    bool academic = true; 
                    if (studentInDB.GradeLevel == "1" || studentInDB.GradeLevel == "2") {
                        int totalUnits = 0;
                        foreach (StudentSubject grade in gradesInDB)
                        {
                            total += (double)grade.FourthPeriodicRating;
                            totalUnits += 1;

                            if (grade.FourthPeriodicRating < 75) 
                                unitsfailed += 1;
                            if (grade.FourthPeriodicRating < 80)
                                academic = false;
                        }

                        if (academic == true)
                        {
                            int ind = -1;
                            ind = sd.FindIndex(s => s.Scholarship == "ACADEMIC");
                            studentInDB.ScholarshipDiscountId = sd[ind].ScholarshipDiscountId;
                        }
                        else {
                            int ind = -1;
                            ind = sd.FindIndex(s => s.Scholarship == "NONE");
                            studentInDB.ScholarshipDiscountId = sd[ind].ScholarshipDiscountId;
                        }

                        average = total / totalUnits;
                        studentInDB.Average = average;
                        studentInDB.UnitsFailedLastYear =(decimal)unitsfailed;

                    }
                    else if (studentInDB.GradeLevel == "3" || studentInDB.GradeLevel == "4")
                    {
                        double totalUnits = 0.00;
                        foreach (StudentSubject grade in gradesInDB)
                        {
                            double finalG = 0.00;
                            if (grade.SubjectCode.Substring(0, 3) == "COM")
                            {
                                totalUnits += .25;
                                finalG = (double)grade.FourthPeriodicRating * 0.25;
                            }
                            else
                            {
                                totalUnits += 1;
                                finalG = (double)grade.FourthPeriodicRating;
                            }

                            if (grade.FourthPeriodicRating < 75)
                                unitsfailed += 1;
                            if (grade.FourthPeriodicRating < 80)
                                academic = false;

                            total += finalG;
                        }

                        if (academic == true)
                        {
                            int ind = -1;
                            ind = sd.FindIndex(s => s.Scholarship == "ACADEMIC");
                            studentInDB.ScholarshipDiscountId = sd[ind].ScholarshipDiscountId;
                        }
                        else
                        {
                            int ind = -1;
                            ind = sd.FindIndex(s => s.Scholarship == "NONE");
                            studentInDB.ScholarshipDiscountId = sd[ind].ScholarshipDiscountId;
                        }
                        
                        average = total / totalUnits;
                        studentInDB.Average = average;
                        studentInDB.UnitsFailedLastYear = (decimal)unitsfailed;
                    }
                    else if (studentInDB.GradeLevel == "5" || studentInDB.GradeLevel == "6")
                    {
                        double totalUnits = 0.00;
                        foreach (StudentSubject grade in gradesInDB)
                        {
                            double finalG = 0.00;
                            if (grade.SubjectCode.Substring(0, 3) == "COM")
                            {
                                totalUnits += .25;
                                finalG = (double)grade.FourthPeriodicRating * 0.25;
                            }
                            else
                            {
                                totalUnits += 1;
                                finalG = (double)grade.FourthPeriodicRating;
                            }

                            if (grade.FourthPeriodicRating < 75)
                                unitsfailed += 1;
                            if (grade.FourthPeriodicRating < 80)
                                academic = false;

                            total += finalG;
                        }
                        if (academic == true)
                        {
                            int ind = -1;
                            ind = sd.FindIndex(s => s.Scholarship == "ACADEMIC");
                            studentInDB.ScholarshipDiscountId = sd[ind].ScholarshipDiscountId;
                        }
                        else
                        {
                            int ind = -1;
                            ind = sd.FindIndex(s => s.Scholarship == "NONE");
                            studentInDB.ScholarshipDiscountId = sd[ind].ScholarshipDiscountId;
                        }
                        average = total /totalUnits;
                        studentInDB.Average = average;
                        studentInDB.UnitsFailedLastYear = (decimal)unitsfailed;
                    }
                    else if (studentInDB.GradeLevel == "7" || studentInDB.GradeLevel == "8" || studentInDB.GradeLevel == "9")
                    {
                        double totalUnits=0.00;
                        foreach (StudentSubject grade in gradesInDB)
                        {
                            double units = 0.00;
                            double finalG = 0.00;
                            units= (double)grade.Subject.LearningArea.Units;
                            finalG = (double)grade.FourthPeriodicRating *units;
                            totalUnits += units;

                            if (grade.FourthPeriodicRating < 75)
                                unitsfailed += 1;
                            if (grade.FourthPeriodicRating < 80)
                                academic = false;

                            total += finalG;
                        }

                        if (academic == true)
                        {
                            int ind = -1;
                            ind = sd.FindIndex(s => s.Scholarship == "ACADEMIC");
                            studentInDB.ScholarshipDiscountId = sd[ind].ScholarshipDiscountId;
                        }
                        else
                        {
                            int ind = -1;
                            ind = sd.FindIndex(s => s.Scholarship == "NONE");
                            studentInDB.ScholarshipDiscountId = sd[ind].ScholarshipDiscountId;
                        }

                        average = total / totalUnits;
                        studentInDB.Average = average;
                        studentInDB.UnitsFailedLastYear = (decimal)unitsfailed;
                    }
                    else if (studentInDB.GradeLevel == "10")
                    {
                        double totalUnits = 0.00;
                        foreach (StudentSubject grade in gradesInDB)
                        {
                            double units = 0.00;
                            double finalG = 0.00;
                            if (grade.SubjectCode == "MAPEH") 
                                units = 1.5;
                            
                            else                           
                                units = (double)grade.Subject.LearningArea.Units;


                            finalG = (double)grade.FourthPeriodicRating * units;
                            totalUnits += units;

                            if (grade.FourthPeriodicRating < 75)
                                unitsfailed += 1;
                            if (grade.FourthPeriodicRating < 80)
                                academic = false;

                            total += finalG;
                        }
                        if (academic == true)
                        {
                            int ind = -1;
                            ind = sd.FindIndex(s => s.Scholarship == "ACADEMIC");
                            studentInDB.ScholarshipDiscountId = sd[ind].ScholarshipDiscountId;
                        }
                        else
                        {
                            int ind = -1;
                            ind = sd.FindIndex(s => s.Scholarship == "NONE");
                            studentInDB.ScholarshipDiscountId = sd[ind].ScholarshipDiscountId;
                        }

                        average = total / totalUnits;
                        studentInDB.Average = average;
                        studentInDB.UnitsFailedLastYear = (decimal)unitsfailed;
                    }
                    DCEnt.Students.Attach(studentInDB);
                    DCEnt.Entry(studentInDB).State = System.Data.Entity.EntityState.Modified;
                    int num = DCEnt.SaveChanges();
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
        }

        public void ConvertStuSubjectsToStuSubjectsBDO(StudentSubject s, StudentSubjectBDO sbdo) {
            StudentEnrolmentDAO sed = new StudentEnrolmentDAO();
            StudentEnrollmentBDO sedb = new StudentEnrollmentBDO();
            sed.ConvertEnrolToEnrolBDO(s.StudentEnrollment, sedb);
            sbdo.StudentEnrollment = sedb;

            StudentDAO sd = new StudentDAO();
            StudentBDO sb = new StudentBDO();
            sd.ConvertStudentToStudentBDO(s.StudentEnrollment.Student, sb);
            sbdo.StudentEnrollment.Student = sb;

            SubjectDAO subd = new SubjectDAO();
            SubjectBDO sbo = new SubjectBDO();
            subd.ConvertSubjectToSubjectBDO(s.Subject, sbo);
            sbdo.Subject = sbo;

            sbdo.StudentSY = s.StudentSY;
            sbdo.SubjectCode = s.SubjectCode;
            sbdo.StudentSubjectsID = s.StudentSubjectsID;
            sbdo.StudentEnrSubCode = s.StudentEnrSubCode;
            sbdo.Remarks = s.Remarks;

            sbdo.FirstPeriodicRating = s.FirstPeriodicRating;
            sbdo.SecondPeriodicRating = s.SecondPeriodicRating;
            sbdo.ThirdPeriodicRating = s.ThirdPeriodicRating;
            sbdo.FourthPeriodicRating = s.FourthPeriodicRating;

            sbdo.StudentEnrSubCode = s.StudentEnrSubCode;

            sbdo.SubjectAssignments = s.SubjectAssignments;

            sbdo.FirstEntered = s.FirstEntered;
            sbdo.SecondEntered = s.SecondEntered;
            sbdo.FourthEntered = s.FourthEntered;
            sbdo.ThirdEntered = s.ThirdEntered;

            sbdo.LockFirst = s.LockFirst;
            sbdo.LockSecond = s.LockSecond;
            sbdo.LockThird = s.LockThird;
            sbdo.LockFourth = s.LockFourth;

            sbdo.FirstLocked = s.FirstLocked;
            sbdo.SecondLocked = s.SecondLocked;
            sbdo.ThirdLocked = s.ThirdLocked;
            sbdo.FourthLocked = s.FourthLocked;
                        
        }

        public void ConvertStuSubjectsBDOToStuSubjects(StudentSubjectBDO sbdo, StudentSubject s)
        {
            s.StudentSY = sbdo.StudentSY;
            s.SubjectCode = sbdo.SubjectCode;
            s.StudentSubjectsID = sbdo.StudentSubjectsID;
            s.StudentEnrSubCode = sbdo.StudentEnrSubCode;
            s.Remarks = sbdo.Remarks;

            s.FirstPeriodicRating = sbdo.FirstPeriodicRating;
            s.SecondPeriodicRating = sbdo.SecondPeriodicRating;
            s.ThirdPeriodicRating = sbdo.ThirdPeriodicRating;
            s.FourthPeriodicRating = sbdo.FourthPeriodicRating;

            s.SubjectAssignments = sbdo.SubjectAssignments;

             s.FirstEntered = sbdo.FirstEntered;
            s.SecondEntered = sbdo.SecondEntered;
            s.FourthEntered = sbdo.FourthEntered;
            s.ThirdEntered = sbdo.ThirdEntered;

            s.LockFirst = sbdo.LockFirst;
            s.LockSecond = sbdo.LockSecond;
            s.LockThird = sbdo.LockThird;
            s.LockFourth = sbdo.LockFourth;

            s.FirstLocked = sbdo.FirstLocked;
            s.SecondLocked = sbdo.SecondLocked;
            s.ThirdLocked = sbdo.ThirdLocked;
            s.FourthLocked = sbdo.FourthLocked;
        }

    }
}
