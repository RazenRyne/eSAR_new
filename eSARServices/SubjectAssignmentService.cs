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
    public class SubjectAssignmentService : ISubjectAssignmentService
    {
        SubjectAssignmentLogic schedLogic = new SubjectAssignmentLogic();

        public bool CreateSchedules(SubjectAssignment subjectAssignment, string message)
        {
            Boolean ret = false; ;
            SubjectAssignmentBDO sabdo = new SubjectAssignmentBDO();
            TranslateScheduleToScheduleBDO(subjectAssignment, sabdo);
            ret = schedLogic.CreateSchedule(ref sabdo, ref message);
            return ret;
        }

        public bool CreateSchedule(List<SubjectAssignment> schedule)
        {
            string message = string.Empty;
            List<SubjectAssignmentBDO> sabdo = new List<SubjectAssignmentBDO>();
            sabdo = ToScheduleBDOList(schedule);
            return schedLogic.CreateSchedule(sabdo, ref message);
        }


        public bool UpdateSchedule(List<SubjectAssignment> schedule)
        {
            string message = string.Empty;
            List<SubjectAssignmentBDO> sabdo = new List<SubjectAssignmentBDO>();
            sabdo = ToScheduleBDOList(schedule);
            return schedLogic.UpdateSchedule(sabdo, ref message);
        }


        private List<SubjectAssignmentBDO> ToScheduleBDOList(List<SubjectAssignment> sched)
        {
            List<SubjectAssignmentBDO> slist = new List<SubjectAssignmentBDO>();
            foreach (SubjectAssignment s in sched)
            {
                SubjectAssignmentBDO sb = new SubjectAssignmentBDO();
                TranslateScheduleToScheduleBDO(s, sb);
                slist.Add(sb);
            }
            return slist;
        }

        public List<SubjectAssignment> GetAllSchedules()
        {
            List<SubjectAssignmentBDO> schedules = new List<SubjectAssignmentBDO>();
            schedules = schedLogic.GetAllSchedules();
            List<SubjectAssignment> s = new List<SubjectAssignment>();
            foreach (SubjectAssignmentBDO sched in schedules)
            {
                SubjectAssignment sa = new SubjectAssignment();
                TranslateScheduleBDOToSchedule(sched, sa);
                s.Add(sa);
            }
            return s;
        }

        public List<SubjectAssignment> GetAllSchedules(string sy)
        {
            List<SubjectAssignmentBDO> schedules = new List<SubjectAssignmentBDO>();
            schedules = schedLogic.GetAllSchedules(sy);
            List<SubjectAssignment> s = new List<SubjectAssignment>();
            foreach (SubjectAssignmentBDO sched in schedules)
            {
                SubjectAssignment sa = new SubjectAssignment();
                TranslateScheduleBDOToSchedule(sched, sa);
                s.Add(sa);
            }
            return s;
        }

        public List<SubjectAssignment> GetAllSchedulesbySection(int iGradeSection, string sy)
        {
            List<SubjectAssignmentBDO> schedules = new List<SubjectAssignmentBDO>();
            schedules = schedLogic.GetAllSchedulesbySection(iGradeSection);
            List<SubjectAssignment> s = new List<SubjectAssignment>();
            foreach (SubjectAssignmentBDO sched in schedules)
            {
                SubjectAssignment sa = new SubjectAssignment();
                TranslateScheduleBDOToSchedule(sched, sa);
                s.Add(sa);
            }
            return s;
        }


        public List<Room> GetAvailableRooms(string timeslotcode)
        {
            List<Room> roomList = new List<Room>();
            List<SubjectAssignment> schedList = new List<SubjectAssignment>();
            List<Room> takenRooms = new List<Room>();
            List<Room> availableRooms = new List<Room>();

            SubjectAssignmentService sas = new SubjectAssignmentService();
            schedList = GetAllSchedules();
            foreach (SubjectAssignment sa in schedList)
            {
                takenRooms.Add(sa.Room);
            }

            RoomService rs = new RoomService();
            roomList = rs.GetAllRooms();

            availableRooms = roomList.Except<Room>(takenRooms).ToList<Room>();

            return availableRooms;
        }

        public List<Teacher> GetAvailableTeachers(string timeslotcode)
        {
            List<Teacher> teacherList = new List<Teacher>();
            List<SubjectAssignment> schedList = new List<SubjectAssignment>();
            List<Teacher> takenTeachers = new List<Teacher>();
            List<Teacher> availableTeachers = new List<Teacher>();

            SubjectAssignmentService sas = new SubjectAssignmentService();
            schedList = GetAllSchedules();
            foreach (SubjectAssignment sa in schedList)
            {
                takenTeachers.Add(sa.Teacher);
            }

            TeacherService ts = new TeacherService();
            teacherList = ts.GetAllTeachers();

            availableTeachers = teacherList.Except<Teacher>(takenTeachers).ToList<Teacher>();

            return availableTeachers;
        }

        public List<SubjectAssignment> GetRoomSchedule(int roomCode)
        {
            List<SubjectAssignment> schedList = new List<SubjectAssignment>();
            schedList = GetAllSchedules();

            List<SubjectAssignment> roomSched = new List<SubjectAssignment>();
            roomSched = schedList.FindAll(p => p.RoomId == roomCode);
            return roomSched;
        }

        public List<StudentSchedule> GetStudentSchedule(int gradeSectionCode, string sy)
        {
            List<StudentSchedule> schedList = new List<StudentSchedule>();
            schedList = GetSchedules(sy);

            List<StudentSchedule> studSched = new List<StudentSchedule>();

            studSched = schedList.FindAll(item => item.GradeSectionCode == gradeSectionCode);

            return studSched;
        }

        public List<StudentSchedule> GetStudentExistingSchedule(List<StudentSubject> studSubs, string sy)
        {
            List<StudentSchedule> schedList = new List<StudentSchedule>();
            schedList = GetSchedules(sy);
            List<StudentSchedule> existing = new List<StudentSchedule>();
            StudentSchedule stud = new StudentSchedule();
            foreach (StudentSubject ss in studSubs)
            {
                int index = schedList.FindIndex(item => item.SubjectAssignments == ss.SubjectAssignments);
                stud = schedList[index];
                stud.Selected = false;
                existing.Add(stud);
            }
            return existing;
        }


        public List<StudentSchedule> GetSchedules(string sy)
        {
            List<SubjectAssignment> schedList = new List<SubjectAssignment>();
            schedList = GetAllSchedules(sy);

            List<StudentSchedule> studSched = new List<StudentSchedule>();

            foreach (SubjectAssignment sab in schedList)
            {
                int index = -1;
                index = studSched.FindIndex(item => item.SubjectCode == sab.SubjectCode && item.GradeSectionCode == sab.GradeSectionCode);
                if (index == -1)
                {
                    StudentSchedule sa = new StudentSchedule();
                    TranslateSAToLoadStudentSchedule(sab, sa);
                    sa.SubjectAssignments = sab.SubjectAssignmentsID.ToString();
                    sa.TimeslotInfo = sab.TimeslotInfo;
                    studSched.Add(sa);
                }
                else
                {
                    studSched[index].SubjectAssignments += " " + sab.SubjectAssignmentsID.ToString();
                    studSched[index].TimeslotInfo += " " + sab.TimeslotInfo;
                }
            }
            return studSched;
        }

        public void TranslateSAToLoadStudentSchedule(SubjectAssignment sab, StudentSchedule sa)
        {

            sa.GradeSection = sab.GradeSection;
            sa.Section = sab.Section;
            sa.GradeLevel = sab.GradeLevel;
            sa.Class = sab.Class;

            sa.Room = sab.Room;
            sa.RoomCode = sab.RoomCode;

            sa.Subject = sab.Subject;
            sa.Teacher = sab.Teacher;
            sa.TeacherName = sab.TeacherName;

            sa.Timeslot = sab.Timeslot;
            sa.Timestart = sab.Timestart;
            sa.TimeEnd = sab.TimeEnd;
            sa.Days = sab.Days;

            sa.Deactivated = sab.Deactivated;
            sa.GradeSectionCode = sab.GradeSectionCode;
            sa.RoomId = sab.RoomId;
            sa.SubjectCode = sab.SubjectCode;

            sa.SY = sab.SY;
            sa.TeacherId = sab.TeacherId;
            sa.TimeSlotCode = sab.TimeSlotCode;


            sa.SubjectInfo = sa.SubjectInfo;

            sa.SubjectDescription = sa.SubjectDescription;
        }


        public List<SubjectAssignment> GetTeacherSchedule(string teacherId, string sy)
        {
            List<SubjectAssignment> schedList = new List<SubjectAssignment>();
            schedList = GetAllSchedules();

            List<SubjectAssignment> teachSched = new List<SubjectAssignment>();
            teachSched = schedList.FindAll(p => p.TeacherId == teacherId);
            return teachSched;
        }

        public List<SubjectAssignment> GetTeacherSchedule(string sy)
        {
            List<SubjectAssignment> schedList = new List<SubjectAssignment>();
            schedList = GetAllSchedules();

            List<SubjectAssignment> teachSched = new List<SubjectAssignment>();
            teachSched = schedList.FindAll(p => p.SY == sy);
            return teachSched;
        }



        public void TranslateScheduleToScheduleBDO(SubjectAssignment schedule, SubjectAssignmentBDO sabdo)
        {
            sabdo.Deactivated = false;

            sabdo.GradeSectionCode = schedule.GradeSectionCode;
            sabdo.RoomId = schedule.RoomId;
            sabdo.SubjectAssignmentsID = schedule.SubjectAssignmentsID;
            sabdo.SubjectCode = schedule.SubjectCode;
            sabdo.SY = schedule.SY;
            sabdo.TeacherId = schedule.TeacherId;
            sabdo.TimeSlotCode = schedule.TimeSlotCode;

        }

        public void TranslateScheduleBDOToSchedule(SubjectAssignmentBDO sabdo, SubjectAssignment sched)
        {
            GradeSectionService gs = new GradeSectionService();
            GradeSection g = new GradeSection();
            gs.TranslateGradeSectionBDOToGradeSection(sabdo.GradeSection, g);
            sched.GradeSection = g;
            sched.Section = g.Section;
            sched.GradeLevel = g.GradeLevel;
            sched.Class = (int)g.Class;

            RoomService rs = new RoomService();
            Room r = new Room();
            rs.TranslateRoomBDOtoRoomDTO(sabdo.Room, r);
            sched.Room = r;
            sched.RoomCode = r.RoomCode;

            SubjectService ss = new SubjectService();
            Subject s = new Subject();
            ss.TranslateSubjectBDOToSubject(sabdo.Subject, s);
            sched.Subject = s;

            TeacherService ts = new TeacherService();
            Teacher t = new Teacher();
            ts.TranslateTeacherBDOToTeacherDTO(sabdo.Teacher, t);
            sched.Teacher = t;
            if (t.MiddleName == String.Empty)
                sched.TeacherName = t.LastName + ", " + t.FirstName;
            else
                sched.TeacherName = t.LastName + ", " + t.FirstName + " " + t.MiddleName.Substring(0, 1) + ".";

            TimeslotService times = new TimeslotService();
            Timeslot time = new Timeslot();
            times.TranslateTimeslotBDOToTimeslotDTo(sabdo.Timeslot, time);
            sched.Timeslot = time;
            sched.Timestart = time.TimeStart;
            sched.TimeEnd = time.TimeEnd;
            sched.Days = time.Days;

            sched.Deactivated = sabdo.Deactivated;
            sched.GradeSectionCode = sabdo.GradeSectionCode;
            sched.RoomId = sabdo.RoomId;
            sched.SubjectAssignmentsID = sabdo.SubjectAssignmentsID;
            sched.SubjectCode = sabdo.SubjectCode;

            sched.SY = sabdo.SY;
            sched.TeacherId = sabdo.TeacherId;
            sched.TimeSlotCode = sabdo.TimeSlotCode;

            sched.TimeslotInfo = time.Days + " " + time.TimeStart + "-" + time.TimeEnd;
            sched.SubjectInfo = sabdo.SubjectCode + " " + sched.Section + " " + sched.TimeslotInfo;

            sched.SubjectDescription = s.Description;

        }

        public List<Timeslot> GetTimeslots()
        {
            TimeslotService tservice = new TimeslotService();
            return tservice.GetAllTimeslots();
        }

        public List<GradeLevel> GetAllGradeLevels()
        {
            GradeLevelService gs = new GradeLevelService();
            return gs.GetAllGradeLevels();
        }

        public List<GradeSection> GetAllSections()
        {
            GradeSectionService gs = new GradeSectionService();
            return gs.GetAllGradeSections();
        }

        public List<GradeSection> GetAllSectionsOfGradeLevel(string gradeLevel)
        {
            GradeSectionService gs = new GradeSectionService();
            return gs.GetAllSectionsForGrade(gradeLevel);
        }

        public List<Room> GetAllRooms()
        {
            RoomService rs = new RoomService();
            return rs.GetAllRooms();
        }

        public List<Teacher> GetAllTeachers()
        {
            TeacherService ts = new TeacherService();
            return ts.GetAllTeachers();
        }

        public List<Subject> GetAllSubjects()
        {
            SubjectService ss = new SubjectService();
            return ss.GetAllSubjects();
        }

        public List<Subject> GetAllSubjectsOfGradeLevel(string gradeLevel)
        {
            SubjectService ss = new SubjectService();
            return ss.GetAllSubjectsOfGradeLevel(gradeLevel);
        }

        public string GetCurrentSY()
        {
            SchoolYearService ss = new SchoolYearService();
            return ss.GetCurrentSY().SY;
        }

        public Boolean DeleteSchedule(int schedID, ref string message)
        {
            return schedLogic.DeleteSchedule(schedID, ref message);
        }

        public List<SubjectAssignment> GetRightSchedule(int Rank, string gradeLevel)
        {
            List<SubjectAssignment> schList = new List<SubjectAssignment>();
            List<SubjectAssignmentBDO> gradeschedList = new List<SubjectAssignmentBDO>();
            gradeschedList = schedLogic.GetScheduleForGradeLevel(gradeLevel);

            List<SubjectAssignment> sectionSched = new List<SubjectAssignment>();

            foreach (SubjectAssignmentBDO sab in gradeschedList)
            {
                SubjectAssignment sa = new SubjectAssignment();
                TranslateScheduleBDOToSchedule(sab, sa);
                schList.Add(sa);
            }
            int div = Rank / 20;
            div++;
            sectionSched = schList.FindAll(item => item.Class == div);

            return sectionSched;
        }

        public SubjectAssignment GetScheduleInfo(int SubjecAssignmentsId)
        {
            List<SubjectAssignment> allSched = GetAllSchedules();
            int index = allSched.FindIndex(item => item.SubjectAssignmentsID == SubjecAssignmentsId);
            allSched[index].Selected = false;
            return allSched[index];
        }

        public List<SchoolYear> GetAllSY()
        {
            SchoolYearService sys = new SchoolYearService();
            return sys.GetAllSY();
        }

        public List<SubjectAssignment> GetStudentExSchedule(int gradeSectionCOde, string sy)
        {
            List<SubjectAssignment> existingSched = new List<SubjectAssignment>();
            existingSched = GetAllSchedules();

            List<SubjectAssignment> sched = new List<SubjectAssignment>();
            sched = existingSched.FindAll(item => item.GradeSectionCode == gradeSectionCOde && item.SY == sy);
            return sched;
        }
    }
}
