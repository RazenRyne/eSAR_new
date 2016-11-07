using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARLogic;
using eSARBDO;
using eSARServiceInterface;
using eSARServiceModels;

namespace eSARServices
{
    public class RegistrationService : IRegistrationService
    {
        StudentTraitLogic stl = new StudentTraitLogic();
        StudentEnrollmentLogic sel = new StudentEnrollmentLogic();
        StudentSubjectLogic ssl = new StudentSubjectLogic();
        StudentAssessmentLogic sal = new StudentAssessmentLogic();

        public Boolean EnrolStudent(StudentEnrollment studentEnr)
        {
            GradeSectionLogic gsl = new GradeSectionLogic();
            StudentService ss = new StudentService();
            StudentEnrollmentBDO studentBDO = new StudentEnrollmentBDO();

            string message = string.Empty;

            List<GradeSectionBDO> sections = new List<GradeSectionBDO>();
            string grade = studentEnr.GradeLevel;
            sections = (gsl.GetAllSectionsofGrade(grade));

            int div = studentEnr.Rank / 20;
            div++;
            int index = sections.FindIndex(item => item.Class == div);
            studentEnr.GradeSectionCode = (int?)sections[index].GradeSectionCode;
            TranslatEnrolToEnrolBDO(studentEnr, studentBDO);
            if (sel.RegisterStudent(studentBDO, ref message))
            {
                string section = String.Empty;
                studentBDO.GradeSectionCode = studentEnr.GradeSectionCode;
                index = sections.FindIndex(item => item.GradeSectionCode == studentEnr.GradeSectionCode);
                section = sections[index].Section;
                ss.UpdateStudent(studentEnr.StudentId, studentEnr.GradeLevel, studentEnr.Rank, section);
                ControlStudentCharacters(studentBDO);
                return true;

            }
            else return false;
        }

        public bool EnrolIrregStudent(StudentEnrollment studentEnr)
        {
            GradeSectionLogic gsl = new GradeSectionLogic();
            StudentService ss = new StudentService();
            StudentEnrollmentBDO studentBDO = new StudentEnrollmentBDO();
            TranslatEnrolToEnrolBDO(studentEnr, studentBDO);
            string message = string.Empty;
            if (sel.RegisterStudent(studentBDO, ref message))
            {
                string section = String.Empty;
                int gsc = (int)studentEnr.GradeSectionCode;
                section = gsl.GetSection(gsc);
                ss.UpdateStudent(studentEnr.StudentId, studentEnr.GradeLevel, studentEnr.Rank, section);
                ControlStudentCharacters(studentBDO);
                return true;
            }

            else return false;
        }

        public Boolean ControlSubjects(string StudentId, string sy, List<StudentSubject> subjects)
        {
            Boolean ret = false;
            foreach (StudentSubject sub in subjects)
            {
                string message = string.Empty;
                StudentSubjectBDO ssb = new StudentSubjectBDO();
                TranslateStuSubjectsToStuSubjectsBDO(sub, ssb);
                ret = ssl.ControlStudent(ssb, ref message);
            }
            return ret;

        }


        public int GetCategory(string g)
        {
            string gradeLevel = g;
            if (gradeLevel.Equals("N") || gradeLevel.Equals("K1") || gradeLevel.Equals("K2"))
                return 1;
            else if (gradeLevel.Equals("7") || gradeLevel.Equals("8") || gradeLevel.Equals("9") || gradeLevel.Equals("10"))
                return 3;
            else return 2;
        }

        public void ControlStudentCharacters(StudentEnrollmentBDO student)
        {
            int cat = GetCategory(student.GradeLevel);
            Boolean ret = false;
            TraitService trait = new TraitService();
            List<Trait> traitlist = new List<Trait>();
            traitlist = trait.GetAllTraitsOfCategory(cat);
            foreach (Trait t in traitlist)
            {
                StudentTrait st = new StudentTrait
                {
                    StudentSY = student.StudentSY,
                    TraitsID = t.TraitsID,
                    StudentEnrTraitCode = student.StudentSY + t.TraitsID,
                    LockFirst = false,
                    LockSecond = false,
                    LockFourth = false,
                    LockThird = false
                };
                if (student.GradeSectionCode != null)
                    st.GradeSectionCode = (int)student.GradeSectionCode;

                string message = string.Empty;
                StudentTraitBDO stb = new StudentTraitBDO();
                TranslateStuTraitsToStuTraitsBDO(st, stb);
                ret = stl.AddStudentCharacters(stb, ref message);
            }

        }

        public Boolean UpdateStudentCharacters(Trait tbdo)
        {
            SchoolYear sy = new SchoolYear();
            sy = GetCurrentSY();

            IGradeLevelService gradeLevelService = new GradeLevelService();
            List<GradeLevel> gradeLevelList = new List<GradeLevel>(gradeLevelService.GetAllGradeLevels());
            List<GradeLevel> gradeLevelCategory = new List<GradeLevel>();
            gradeLevelCategory = gradeLevelList.FindAll(x => x.Category == tbdo.Category);

            Boolean ret = false;

            List<string> studentIDs = new List<string>();
            foreach (GradeLevel gl in gradeLevelCategory)
            {
                studentIDs.AddRange(GetEnrolledStudentsforNewTraits(gl.GradeLev, sy.SY));
            }

            foreach (string studentID in studentIDs)
            {
                StudentEnrollment se = new StudentEnrollment();
                se = GetEnrolledStudent(studentID, sy.SY);
                StudentTrait st = new StudentTrait
                {
                    StudentSY = se.StudentSY,
                    TraitsID = tbdo.TraitsID,
                    StudentEnrTraitCode = se.StudentSY + tbdo.TraitsID,
                    GradeSectionCode = (int)se.GradeSectionCode,
                    LockFirst = false,
                    LockSecond = false,
                    LockFourth = false,
                    LockThird = false
                };
                string message = string.Empty;
                StudentTraitBDO stb = new StudentTraitBDO();
                NewTraitsTranslateStuTraitsToStuTraitsBDO(st, stb);
                ret = stl.AddStudentCharacters(stb, ref message);
            }
            return ret;

        }

        public bool UpdateStudentBalance(string studentSy, string studentID, float assessmentfee)
        {
            string message = "";
            StudentService ss = new StudentService();
            Student stu = new Student();
            stu = ss.GetStudent(studentID, ref message);
            stu.RunningBalance = stu.RunningBalance + assessmentfee;            
            return ss.UpdateStudent(ref stu, ref message);
        }

        public List<StudentAssessment> AssessMe(StudentEnrollment student)
        {
            FeeService fs = new FeeService();
            List<Fee> feeList = new List<Fee>();
            Fee FeeforAll = new Fee();
            feeList = fs.GetAllFeesForGradeLevel(student.GradeLevel, student.SY);
            FeeforAll = fs.GetFeeForAll(student.SY);
            if (FeeforAll.Amount != null)
                feeList.Add(FeeforAll);
            foreach (Fee f in feeList)
            {
                StudentAssessmentBDO sabdo = new StudentAssessmentBDO()
                {
                    StudentSY = student.StudentSY,
                    FeeID = f.FeeID,
                    DiscountId = student.DiscountId
                };

                sal.AssessStudent(sabdo);
            }
            return GetStudentAssessment(student.StudentId, student.SY);
        }

        public StudentEnrollment GetEnrolledStudent(string id, string sy)
        {

            StudentEnrollment se = new StudentEnrollment();
            TranslatEnrolBDOToEnrol(sel.GetStudentEnrolled(id, sy), se);
            return se;

        }

        public SchoolYear GetCurrentSY()
        {
            SchoolYearService sy = new SchoolYearService();
            return sy.GetCurrentSY();
        }

        public List<string> GetEnrolledStudents(string sy)
        {
            return sel.GetEnrolledIds(sy);
        }

        public List<string> GetEnrolledStudentsforNewTraits(string gradelevel, string sy)
        {
            return sel.GetEnrolledIdsNewTraits(gradelevel,sy);
        }

        public List<StudentAssessment> GetStudentAssessment(string IDNum, string SY)
        {
            List<StudentAssessment> salist = new List<StudentAssessment>();
            List<StudentAssessmentBDO> sab = new List<StudentAssessmentBDO>();

            sab = sal.GetStudentAssessment(IDNum, SY);
            foreach (StudentAssessmentBDO s in sab)
            {
                StudentAssessment sa = new StudentAssessment();
                TranslatetAssessBDOToAssess(s, sa);
                salist.Add(sa);
            }

            return salist;
        }

        public Student StudentInfoWithRank(string IDnum, string gradelevel, string gender)
        {
            StudentService ss = new StudentService();
            return ss.StudentInfoWithRank(IDnum, gradelevel, gender);
        }


        public void TranslatEnrolToEnrolBDO(StudentEnrollment se, StudentEnrollmentBDO seb)
        {
            seb.StudentSY = se.StudentSY;
            seb.StudentId = se.StudentId;
            seb.SY = se.SY;
            seb.GradeLevel = se.GradeLevel;
            seb.GradeSectionCode = se.GradeSectionCode;
            seb.Dismissed = se.Dismissed;
            seb.Stat = se.Stat;
            seb.DiscountId = se.DiscountId;
            seb.Rank = se.Rank;

            // seb.StudentEnrollmentsID = se.StudentEnrollmentsID
        }

        public void TranslatEnrolBDOToEnrol(StudentEnrollmentBDO seb, StudentEnrollment se)
        {
            StudentService ss = new StudentService();
            Student stu = new Student();

            ss.TranslateStudentBDOToStudentDTO(seb.Student, stu);
            se.StudentSY = seb.StudentSY;
            se.StudentId = seb.StudentId;
            se.SY = seb.SY;
            se.GradeLevel = seb.GradeLevel;
            se.GradeSectionCode = seb.GradeSectionCode;
            se.Dismissed = seb.Dismissed;
            se.Stat = seb.Stat;
            se.DiscountId = (int)seb.DiscountId;
            se.StudentName = stu.LastName + ", " + stu.FirstName + " " + stu.MiddleName;
            se.StudentEnrollmentsID = seb.StudentEnrollmentsID;
            se.student = stu;

        }


        public void TranslateStuSubjectsToStuSubjectsBDO(StudentSubject s, StudentSubjectBDO sbdo)
        {
            sbdo.StudentSY = s.StudentSY;
            sbdo.SubjectCode = s.SubjectCode;
            sbdo.StudentSubjectsID = s.StudentSubjectsID;
            sbdo.StudentEnrSubCode = s.StudentEnrSubCode;
            sbdo.Remarks = s.Remarks;
            sbdo.FirstPeriodicRating = s.FirstPeriodicRating;
            sbdo.SecondPeriodicRating = s.SecondPeriodicRating;
            sbdo.ThirdPeriodicRating = s.ThirdPeriodicRating;
            sbdo.FourthPeriodicRating = s.FourthPeriodicRating;
            sbdo.SubjectAssignments = s.SubjectAssignments;
            sbdo.FirstEntered = s.FirstEntered;
            sbdo.FirstLocked = s.FirstLocked;
            sbdo.FourthEntered = s.FourthEntered;
            sbdo.FourthLocked = s.FourthLocked;
            sbdo.LockFirst = s.LockFirst;
            sbdo.LockFourth = s.LockFourth;
            sbdo.LockSecond = s.LockSecond;
            sbdo.LockThird = s.LockThird;
            sbdo.SecondEntered = s.SecondEntered;
            sbdo.SecondLocked = s.SecondLocked;
            sbdo.ThirdEntered = s.ThirdEntered;
            sbdo.ThirdLocked = s.ThirdLocked;


        }

        public void TranslateStuSubjectsBDOToStuSubjects(StudentSubjectBDO sbdo, StudentSubject s)
        {
            SubjectService ss = new SubjectService();
            Subject sub = new Subject();

            ss.TranslateSubjectBDOToSubject(sbdo.Subject, sub);
            s.SubjectCode = sbdo.SubjectCode;
            s.Description = sub.Description;

            RegistrationService rs = new RegistrationService();
            StudentEnrollment se = new StudentEnrollment();
            rs.TranslatEnrolBDOToEnrol(sbdo.StudentEnrollment, se);
            s.StudentEnr = se;

            s.StudentSY = sbdo.StudentSY;

            s.StudentId = se.StudentId;
            s.StudentName = se.StudentName;

            s.StudentSubjectsID = sbdo.StudentSubjectsID;
            s.StudentEnrSubCode = sbdo.StudentEnrSubCode;
            s.Remarks = sbdo.Remarks;
            s.FirstPeriodicRating = sbdo.FirstPeriodicRating;
            s.SecondPeriodicRating = sbdo.SecondPeriodicRating;
            s.ThirdPeriodicRating = sbdo.ThirdPeriodicRating;
            s.FourthPeriodicRating = sbdo.FourthPeriodicRating;
            s.Description = sub.Description;
            s.SubjectAssignments = sbdo.SubjectAssignments;
            s.FirstEntered = sbdo.FirstEntered;
            s.FirstLocked = sbdo.FirstLocked;
            s.FourthEntered = sbdo.FourthEntered;
            s.FourthLocked = sbdo.FourthLocked;
            s.LockFirst = sbdo.LockFirst;
            s.LockFourth = sbdo.LockFourth;
            s.LockSecond = sbdo.LockSecond;
            s.LockThird = sbdo.LockThird;
            s.SecondEntered = sbdo.SecondEntered;
            s.SecondLocked = sbdo.SecondLocked;
            s.ThirdEntered = sbdo.ThirdEntered;
            s.ThirdLocked = sbdo.ThirdLocked;
            s.FinalRating = (double)sbdo.FourthPeriodicRating;

            if (s.FinalRating > 90)
                s.Proficiency = "O";
            else if (s.FinalRating >= 85)
                s.Proficiency = "VS";
            else if (s.FinalRating >= 80)
                s.Proficiency = "S";
            else if (s.FinalRating >= 75)
                s.Proficiency = "FS";
            else if (s.FinalRating <= 74)
                s.Proficiency = "D";

        }

        public void TranslateStuTraitsToStuTraitsBDO(StudentTrait st, StudentTraitBDO stbdo)
        {
            stbdo.StudentSY = st.StudentSY;
            stbdo.TraitsID = st.TraitsID;
            stbdo.FirstPeriodicRating = st.FirstPeriodicRating;
            stbdo.SecondPeriodicRating = st.SecondPeriodicRating;
            stbdo.ThirdPeriodicRating = st.ThirdPeriodicRating;
            stbdo.FourthPeriodicRating = st.FourthPeriodicRating;
            stbdo.StudentEnrTraitCode = st.StudentEnrTraitCode;
            stbdo.GradeSectionCode = st.GradeSectionCode;
        }

        public void NewTraitsTranslateStuTraitsToStuTraitsBDO(StudentTrait st, StudentTraitBDO stbdo)
        {
            stbdo.StudentSY = st.StudentSY;
            stbdo.TraitsID = st.TraitsID;
            stbdo.FirstPeriodicRating = st.FirstPeriodicRating;
            stbdo.SecondPeriodicRating = st.SecondPeriodicRating;
            stbdo.ThirdPeriodicRating = st.ThirdPeriodicRating;
            stbdo.FourthPeriodicRating = st.FourthPeriodicRating;
            stbdo.StudentEnrTraitCode = st.StudentEnrTraitCode;
            stbdo.GradeSectionCode = st.GradeSectionCode;
        }

        public void TranslatetAssessBDOToAssess(StudentAssessmentBDO ab, StudentAssessment a)
        {
            a.StudentAssessmentId = ab.StudentAssessmentId;
            a.StudentSY = ab.StudentSY;
            a.FeeID = (int)ab.FeeID;
            a.Amount = (double)ab.Fee.Amount;
            a.ScholarshipDiscountId = (int)ab.DiscountId;
            if (ab.ScholarshipDiscount.Discount.HasValue)
                a.Discount = (float)ab.ScholarshipDiscount.Discount;
        }

        public StudentEnrollment GetStudentEnrolled(string IDNum, string SY)
        {
            StudentEnrollment se = new StudentEnrollment();
            TranslatEnrolBDOToEnrol(sel.GetStudentEnrolled(IDNum, SY), se);
            return se;
        }

        public bool CreateStudentAssessment(StudentAssessment studAss)
        {
            throw new NotImplementedException();
        }

        public List<ScholarshipDiscount> GetScholarshipDiscounts()
        {
            ScholarshipService ss = new ScholarshipService();
            List<ScholarshipDiscount> slist = new List<ScholarshipDiscount>();
            slist = ss.GetAllScholarships();
            return slist;
        }

        public List<StudentSchedule> GetSubjectSchedules(string sy)
        {
            SubjectAssignmentService sas = new SubjectAssignmentService();
            return sas.GetSchedules(sy);
        }

        public List<StudentSubject> GetFailedSubjects(string IDSy)
        {
            List<StudentSubject> subs = new List<StudentSubject>();
            List<StudentSubjectBDO> subsbdo = new List<StudentSubjectBDO>();
            subsbdo = ssl.GetFailedSubjects(IDSy);
            foreach (StudentSubjectBDO ssb in subsbdo)
            {
                StudentSubject ss = new StudentSubject();
                TranslateStuSubjectsBDOToStuSubjects(ssb, ss);
                subs.Add(ss);
            }
            return subs;
        }

        public List<SubjectAssignment> GetStudentSchedule(int rank, string gradelevel)
        {
            SubjectAssignmentService sas = new SubjectAssignmentService();

            List<SubjectAssignment> salist = new List<SubjectAssignment>();
            salist = sas.GetRightSchedule(rank, gradelevel);
            return salist;

        }

        public List<StudentSubject> GetStudentSubjects(string studentIdSy)
        {
            List<StudentSubject> ss = new List<StudentSubject>();
            List<StudentSubjectBDO> ssbdo = new List<StudentSubjectBDO>();
            ssbdo = ssl.GetStudentSubjects(studentIdSy);
            foreach (StudentSubjectBDO s in ssbdo)
            {
                StudentSubject ssub = new StudentSubject();
                TranslateStuSubjectsBDOToStuSubjects(s, ssub);
                ss.Add(ssub);
            }
            return ss;

        }

        public List<StudentEnrollment> GetCurrentStudents(string sy)
        {
            StudentEnrollmentLogic ser = new StudentEnrollmentLogic();
            List<StudentEnrollmentBDO> selbdo = ser.GetEnrolledStudents(sy);
            List<StudentEnrollment> currentStudents = new List<StudentEnrollment>();
            foreach (StudentEnrollmentBDO seb in selbdo)
            {
                StudentEnrollment se = new StudentEnrollment();
                TranslatEnrolBDOToEnrol(seb, se);
                currentStudents.Add(se);
            }
            return currentStudents;
        }

        public Student GetStudent(string StudentId, ref string message)
        {
            StudentService ss = new StudentService();
            return ss.GetStudent(StudentId, ref message);
        }

        public List<StudentSchedule> GetStudentExistingSchedule(List<StudentSubject> StudentSubjectList, string sy)
        {
            SubjectAssignmentService sas = new SubjectAssignmentService();
            return sas.GetStudentExistingSchedule(StudentSubjectList, sy);
        }

        public bool UpdateStudent(ref Student student, ref string message)
        {
            StudentService ss = new StudentService();
            return ss.UpdateStudent(ref student, ref message);
        }

        public List<Fee> GetStudentFees(StudentEnrollment student)
        {
            FeeService fs = new FeeService();
            List<Fee> feeList = new List<Fee>();
            //Changed
            feeList = fs.GetAllFeesForGradeLevel(student.GradeLevel, student.SY);
            feeList.Add(fs.GetFeeForAll(student.SY));
            foreach (Fee f in feeList)
            {
                StudentAssessmentBDO sabdo = new StudentAssessmentBDO()
                {
                    StudentSY = student.StudentSY,
                    FeeID = f.FeeID,
                    DiscountId = student.DiscountId
                };
            }
            return feeList;
        }

        public List<StudentSchedule> GetSubjectsOfSection(int GradeSectionCode, string sy)
        {
            SubjectAssignmentService sas = new SubjectAssignmentService();

            List<StudentSchedule> scheduleForSection = new List<StudentSchedule>();

            scheduleForSection = sas.GetStudentSchedule(GradeSectionCode, sy);

            return scheduleForSection;
        }

        public List<SchoolYear> GetAllSY()
        {
            SchoolYearService sys = new SchoolYearService();
            return sys.GetAllSY();
        }

        public List<GradeLevel> GetAllGradeLevel()
        {
            GradeSectionService gss = new GradeSectionService();
            return gss.GetAllGradeLevels();
        }

        public List<GradeSection> GetAllGradeSection(string gradeLevel)
        {
            GradeSectionService gss = new GradeSectionService();
            return gss.GetAllSectionsForGrade(gradeLevel);
        }

        public bool DeleteLoadedSubjects(string StudentId, string sy, List<StudentSubject> subs)
        {
            Boolean ret = false;
            foreach (StudentSubject sub in subs)
            {
                string message = string.Empty;
                StudentSubjectBDO ssb = new StudentSubjectBDO();
                TranslateStuSubjectsToStuSubjectsBDO(sub, ssb);
                ret = ssl.DeleteStudentLoad(ssb, ref message);
            }
            return ret;
        }

        public bool DeleteExistingSubjects(string studentsy)
        {
             return ssl.DeleteExistingSubjects(studentsy);
        }

        public bool UpdateStudentSection(string studentSy, int gradeSectionCode, string section)
        {
            ssl.UpdateStudentSection(studentSy, gradeSectionCode);
            StudentService ss = new StudentService();
            ss.UpdateStudent(studentSy.Substring(0,8), section);
            return true;
        }
    }
}
