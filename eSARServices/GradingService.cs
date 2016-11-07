using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARServiceModels;
using eSARServiceInterface;
using eSARLogic;
using eSARBDO;

namespace eSARServices
{
    public class GradingService : IGradingService
    {
        GradingLogic gradeLogic = new GradingLogic();
        RegistrationService rs = new RegistrationService();
        public List<StudentSubject> GetClassList(string SubjectAssignments)
        {
            List<StudentSubject> classList = new List<StudentSubject>();
            List<StudentSubjectBDO> classBdoList = new List<StudentSubjectBDO>();
            classBdoList = gradeLogic.GetClassList(SubjectAssignments);
            foreach (StudentSubjectBDO ssb in classBdoList)
            {
                StudentSubject ss = new StudentSubject();
                rs.TranslateStuSubjectsBDOToStuSubjects(ssb, ss);
                classList.Add(ss);
            }
            return classList;
        }

        public List<StudentSubject> GetStudentEvaluation(string StudentId)
        {
            List<StudentSubject> eval = new List<StudentSubject>();
            List<StudentSubjectBDO> evalBdoList = new List<StudentSubjectBDO>();
            evalBdoList = gradeLogic.GetStudentEvaluation(StudentId);
            foreach (StudentSubjectBDO ssb in evalBdoList)
            {
                StudentSubject ss = new StudentSubject();
                rs.TranslateStuSubjectsBDOToStuSubjects(ssb, ss);
                eval.Add(ss);
            }
            return eval;
        }

        public List<StudentSubject> GetClassGrades(string SubjectAssignments)
        {
            List<StudentSubject> greport1 = new List<StudentSubject>();
            List<StudentSubjectBDO> greportBdoList = new List<StudentSubjectBDO>();
            greportBdoList = gradeLogic.GetClassGradeReport(SubjectAssignments);
            foreach (StudentSubjectBDO ssb in greportBdoList)
            {
                StudentSubject ss = new StudentSubject();
                rs.TranslateStuSubjectsBDOToStuSubjects(ssb, ss);
                greport1.Add(ss);
            }
            return greport1;
        }


        public List<StudentSubject> GetStudentGrades(string StudentId, string sy)
        {
            List<StudentSubject> eval = new List<StudentSubject>();
            List<StudentSubjectBDO> evalBdoList = new List<StudentSubjectBDO>();
            evalBdoList = gradeLogic.GetStudentGradeReport(StudentId, sy);
            foreach (StudentSubjectBDO ssb in evalBdoList)
            {
                StudentSubject ss = new StudentSubject();
                rs.TranslateStuSubjectsBDOToStuSubjects(ssb, ss);
                eval.Add(ss);
            }
            return eval;
        }



        public Teacher GetTeacher(string lastname, string middlename, string firstname)
        {
            TeacherService ts = new TeacherService();
            return ts.GetTeacher(lastname, firstname, middlename);
        }

        public List<TeacherLoad> GetTeacherLoad(string TeacherId, string sy)
        {
            SubjectAssignmentService sas = new SubjectAssignmentService();
            List<TeacherLoad> load = new List<TeacherLoad>();
            List<SubjectAssignment> loadBdoList = new List<SubjectAssignment>();
            loadBdoList = sas.GetTeacherSchedule(TeacherId, sy);

            foreach (SubjectAssignment sab in loadBdoList)
            {
                int index = -1;
                int gsc = sab.GradeSectionCode;
                index = load.FindIndex(item => item.GradeSectionCode == gsc);
                if (index == -1)
                {
                    TeacherLoad sa = new TeacherLoad();
                    TranslateScheduleToLoad(sab, sa);
                    sa.SubjectAssignments = sab.SubjectAssignmentsID.ToString();
                    sa.TimeslotInfo = sab.TimeslotInfo;
                    load.Add(sa);
                }
                else
                {
                    string asses = String.Empty;
                    asses = load[index].SubjectAssignments;
                    string tlinfo = String.Empty;
                    tlinfo = load[index].TimeslotInfo;
                    load[index].SubjectAssignments = asses + " " + sab.SubjectAssignmentsID.ToString();
                    load[index].TimeslotInfo = tlinfo + " " + sab.TimeslotInfo;
                }
            }
            return load;
        }

        public List<TeacherLoad> GetAllTeachersLoad(string sy)
        {
            SubjectAssignmentService sas = new SubjectAssignmentService();
            List<TeacherLoad> load = new List<TeacherLoad>();
            List<SubjectAssignment> loadBdoList = new List<SubjectAssignment>();
            loadBdoList = sas.GetTeacherSchedule(sy);

            foreach (SubjectAssignment sab in loadBdoList)
            {
                int index = -1;
                int gsc = sab.GradeSectionCode;
                index = load.FindIndex(item => item.GradeSectionCode == gsc && item.SubjectCode == sab.SubjectCode);
                if (index == -1)
                {
                    TeacherLoad sa = new TeacherLoad();
                    TranslateScheduleToLoad(sab, sa);
                    sa.SubjectAssignments = sab.SubjectAssignmentsID.ToString();
                    sa.TimeslotInfo = sab.TimeslotInfo;
                    load.Add(sa);
                }
                else
                {
                    string asses = String.Empty;
                    asses = load[index].SubjectAssignments;
                    string tlinfo = String.Empty;
                    tlinfo = load[index].TimeslotInfo;
                    load[index].SubjectAssignments = asses + " " + sab.SubjectAssignmentsID.ToString();
                    load[index].TimeslotInfo = tlinfo + "/" + sab.TimeslotInfo;
                }
            }
            return load;
        }
        public void TranslateScheduleToLoad(SubjectAssignment sa, TeacherLoad tl)
        {

            tl.GradeSection = sa.GradeSection;
            tl.Section = sa.Section;
            tl.GradeLevel = sa.GradeLevel;
            tl.Class = sa.Class;

            tl.Room = sa.Room;
            tl.RoomCode = sa.RoomCode;

            tl.Subject = sa.Subject;
            tl.Teacher = sa.Teacher;
            tl.TeacherName = sa.TeacherName;

            tl.Timeslot = sa.Timeslot;
            tl.Timestart = sa.Timestart;
            tl.TimeEnd = sa.TimeEnd;
            tl.Days = sa.Days;

            tl.Deactivated = sa.Deactivated;
            tl.GradeSectionCode = sa.GradeSectionCode;
            tl.RoomId = sa.RoomId;
            tl.SubjectCode = sa.SubjectCode;

            tl.SY = sa.SY;
            tl.TeacherId = sa.TeacherId;
            tl.TimeSlotCode = sa.TimeSlotCode;


            tl.SubjectInfo = sa.SubjectInfo;

            tl.SubjectDescription = sa.SubjectDescription;

        }

        public void TranslateStudentSubjectBDOToStudentSubject(StudentSubjectBDO ssbdo, StudentSubject ss)
        {
            SubjectService s = new SubjectService();
            Subject sub = new Subject();
            s.TranslateSubjectBDOToSubject(ssbdo.Subject, sub);


            RegistrationService r = new RegistrationService();
            StudentEnrollment se = new StudentEnrollment();
            r.TranslatEnrolBDOToEnrol(ssbdo.StudentEnrollment, se);
            ss.StudentEnr = se;

            ss.Description = sub.Description;
            ss.FirstPeriodicRating = ssbdo.FirstPeriodicRating;
            ss.SecondPeriodicRating = ssbdo.SecondPeriodicRating;
            ss.ThirdPeriodicRating = ssbdo.ThirdPeriodicRating;
            ss.FourthPeriodicRating = ssbdo.FourthPeriodicRating;

            ss.FirstEntered = ssbdo.FirstEntered;
            ss.SecondEntered = ssbdo.SecondEntered;
            ss.ThirdEntered = ssbdo.ThirdEntered;
            ss.FourthEntered = ssbdo.FourthEntered;

            ss.LockFirst = (bool)ssbdo.LockFirst;
            ss.LockFourth = (bool)ssbdo.LockFourth;
            ss.LockSecond = (bool)ssbdo.LockSecond;
            ss.LockThird = (bool)ssbdo.LockThird;

            ss.FirstLocked = ssbdo.FirstLocked;
            ss.SecondLocked = ssbdo.SecondLocked;
            ss.ThirdLocked = ssbdo.ThirdLocked;
            ss.FourthLocked = ssbdo.FourthLocked;

            ss.Remarks = ssbdo.Remarks;

            ss.StudentEnrSubCode = ssbdo.StudentEnrSubCode;

            ss.StudentEnrSubCode = ssbdo.StudentEnrSubCode;
            ss.StudentSubjectsID = ssbdo.StudentSubjectsID;
            ss.StudentSY = ssbdo.StudentSY;
            ss.SubjectCode = ssbdo.SubjectCode;


            ss.StudentId = se.StudentId;
            ss.StudentName = se.StudentName;

        }

        public void TranslateStudentSubjectToStudentSubjectBDO(StudentSubject ss, StudentSubjectBDO ssbdo)
        {
            ssbdo.FirstEntered = ss.FirstEntered;
            ssbdo.FirstLocked = ss.FirstLocked;
            ssbdo.FirstPeriodicRating = ss.FirstPeriodicRating;
            ssbdo.FourthEntered = ss.FourthEntered;
            ssbdo.FourthLocked = ss.FourthLocked;
            ssbdo.FourthPeriodicRating = ss.FourthPeriodicRating;
            ssbdo.LockFirst = ss.LockFirst;
            ssbdo.LockFourth = ss.LockFourth;
            ssbdo.LockSecond = ss.LockSecond;
            ssbdo.LockThird = ss.LockThird;
            ssbdo.Remarks = ss.Remarks;
            ssbdo.SecondEntered = ss.SecondEntered;
            ssbdo.SecondLocked = ss.SecondLocked;
            ssbdo.SecondPeriodicRating = ss.SecondPeriodicRating;
            ssbdo.ThirdEntered = ss.ThirdEntered;
            ssbdo.ThirdLocked = ss.ThirdLocked;
            ssbdo.ThirdPeriodicRating = ss.ThirdPeriodicRating;
            ssbdo.StudentEnrSubCode = ss.StudentEnrSubCode;

            ssbdo.StudentEnrSubCode = ss.StudentEnrSubCode;
            ssbdo.StudentSubjectsID = ss.StudentSubjectsID;
            ssbdo.StudentSY = ss.StudentSY;
            ssbdo.SubjectAssignments = ss.SubjectAssignments;
            ssbdo.SubjectCode = ss.SubjectCode;


        }

        public bool SaveClassGrades(List<StudentSubject> grades)
        {
            GradingLogic gl = new GradingLogic();
            List<StudentSubjectBDO> ssbdo = new List<StudentSubjectBDO>();
            foreach (StudentSubject stusub in grades)
            {
                StudentSubjectBDO stuSubBdo = new StudentSubjectBDO();
                TranslateStudentSubjectToStudentSubjectBDO(stusub, stuSubBdo);
                ssbdo.Add(stuSubBdo);
            }
            return gl.SaveClassGrades(ssbdo);
        }

        public void LockGrades(int Grading, List<StudentSubject> grades)
        {
            throw new NotImplementedException();
        }


        public void TranslateStudentTraitBDOToStudentTrait(StudentTraitBDO stb, StudentTrait st)
        {
            st.Description = stb.Trait.Description;
            st.FirstEntered = stb.FirstEntered;
            st.FirstLocked = stb.FirstLocked;
            st.FirstPeriodicRating = stb.FirstPeriodicRating;
            st.FourthEntered = stb.FourthEntered;
            st.FourthLocked = stb.FourthLocked;
            st.FourthPeriodicRating = stb.FourthPeriodicRating;
            st.GradeLevel = stb.GradeSection.GradeLevel;
            st.GradeSectionCode = (int)stb.GradeSectionCode;
            st.LockFirst = stb.LockFirst;
            st.LockFourth = stb.LockCFourth;
            st.LockSecond = stb.LockSecond;
            st.LockThird = stb.LockThird;
            st.SecondEntered = stb.SecondEntered;
            st.SecondLocked = stb.SecondLocked;
            st.SecondPeriodicRating = stb.SecondPeriodicRating;
            st.Section = stb.GradeSection.Section;

            RegistrationService r = new RegistrationService();
            StudentEnrollment se = new StudentEnrollment();
            r.TranslatEnrolBDOToEnrol(stb.StudentEnrollment, se);
            st.StudentEnr = se;

            st.StudentEnrTraitCode = stb.StudentEnrTraitCode;
            st.StudentId = se.StudentId;
            st.StudentName = se.StudentName;
            st.StudentSY = stb.StudentSY;
            st.TeacherId = stb.GradeSection.HomeRoomTeacherId;

            st.TeacherName = stb.GradeSection.HomeRoomTeacher.LastName + "," + stb.GradeSection.HomeRoomTeacher.FirstName;
            st.ThirdEntered = stb.ThirdEntered;
            st.ThirdLocked = stb.ThirdLocked;
            st.ThirdPeriodicRating = stb.ThirdPeriodicRating;
            st.TraitsID = stb.TraitsID;

        }

        public List<StudentTrait> GetStudentTrait(string StudentId, string sy)
        {
            throw new NotImplementedException();
        }

        public bool SaveTraitsGrade(List<StudentTrait> grades)
        {
            GradingLogic gl = new GradingLogic();
            List<StudentTraitBDO> ssbdo = new List<StudentTraitBDO>();
            foreach (StudentTrait stutra in grades)
            {
                StudentTraitBDO stutraBdo = new StudentTraitBDO();
                TranslateStudentTraitToStudentTraitBDO(stutra, stutraBdo);
                ssbdo.Add(stutraBdo);
            }
            gl.SaveTraitsGrades(ssbdo);
            return true;
        }

        public Teacher GetTeacherDet(string teacherId, ref string message)
        {
            TeacherService ts = new TeacherService();
            return ts.GetTeacher(teacherId, ref message);
        }

        public void TranslateStudentTraitToStudentTraitBDO(StudentTrait ss, StudentTraitBDO ssbdo)
        {
            ssbdo.FirstEntered = ss.FirstEntered;
            ssbdo.FirstLocked = ss.FirstLocked;
            ssbdo.FirstPeriodicRating = ss.FirstPeriodicRating;
            ssbdo.FourthEntered = ss.FourthEntered;
            ssbdo.FourthLocked = ss.FourthLocked;
            ssbdo.FourthPeriodicRating = ss.FourthPeriodicRating;
            ssbdo.LockFirst = ss.LockFirst;
            ssbdo.LockCFourth = ss.LockFourth;
            ssbdo.LockSecond = ss.LockSecond;
            ssbdo.LockThird = ss.LockThird;
            ssbdo.SecondEntered = ss.SecondEntered;
            ssbdo.SecondLocked = ss.SecondLocked;
            ssbdo.SecondPeriodicRating = ss.SecondPeriodicRating;
            ssbdo.ThirdEntered = ss.ThirdEntered;
            ssbdo.ThirdLocked = ss.ThirdLocked;
            ssbdo.ThirdPeriodicRating = ss.ThirdPeriodicRating;
            ssbdo.StudentEnrTraitCode = ss.StudentEnrTraitCode;

            ssbdo.TraitsID = ss.TraitsID;
            ssbdo.StudentSY = ss.StudentSY;
            ssbdo.GradeSectionCode = ss.GradeSectionCode;

        }

        public void LockTraitsGrade(int Grading, List<StudentTrait> grades)
        {
            throw new NotImplementedException();
        }

        public List<StudentTrait> GetAdvisees(int GradesectionCode)
        {
            GradingLogic gl = new GradingLogic();
            List<StudentTraitBDO> alist = new List<StudentTraitBDO>();
            List<StudentTrait> advisees = new List<StudentTrait>();
            alist = gl.GetAdviseesList(GradesectionCode);
            foreach (StudentTraitBDO stb in alist)
            {
                StudentTrait st = new StudentTrait();
                TranslateStudentTraitBDOToStudentTrait(stb, st);
                advisees.Add(st);
            }
            return advisees;
        }


    }
}
