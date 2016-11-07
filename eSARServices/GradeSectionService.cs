using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARBDO;
using eSARLogic;
using eSARServiceInterface;
using eSARServiceModels;

namespace eSARServices
{
    public class GradeSectionService : IGradeSectionService
    {
        GradeSectionLogic gsLogic = new GradeSectionLogic();
        public bool CreateGradeSection(ref GradeSection gs, ref string message)
        {
            GradeSectionBDO gsb = new GradeSectionBDO();
            TranslateGradeSectionToGradeSectionBDO(gs, gsb);
            return gsLogic.CreateGradeSection(ref gsb, ref message);
        }

        public Teacher GetTeacher(string lastname, string middlename, string firstname)
        {
            TeacherService ts = new TeacherService();
            return ts.GetTeacher(lastname, firstname, middlename);
        }

        public Teacher GetTeacherDetail(string teacherID, ref string message)
        {
            TeacherService ts = new TeacherService();
            return ts.GetTeacher(teacherID, ref message);
        }

        public List<GradeSection> GetAllGradeSections()
        {
            SchoolYearService sys = new SchoolYearService();

            string currentSY = String.Empty;
            currentSY = sys.GetCurrentSY().SY;
            return ToGradeSectionList(gsLogic.GetAllGradeSections(currentSY));
        }

        private List<GradeSection> ToGradeSectionList(List<GradeSectionBDO> gb)
        {
            List<GradeSection> gsl = new List<GradeSection>();
            foreach (GradeSectionBDO g in gb)
            {
                GradeSection gs = new GradeSection();
                TranslateGradeSectionBDOToGradeSection(g, gs);
                gsl.Add(gs);
            }
            return gsl;
        }

        public GradeSection GetGradeSection(int gradeSectionCode)
        {
            List<GradeSection> glist = new List<GradeSection>();
            glist = GetAllGradeSections();
            GradeSection g = new GradeSection();
            g = glist.Find(p => p.GradeSectionCode == gradeSectionCode);
            return g;
        }


        public void TranslateGradeSectionToGradeSectionBDO(GradeSection gs, GradeSectionBDO gsb)
        {

            gsb.Deactivated = gs.Deactivated;
            gsb.GradeLevel = gs.GradeLevel;
            gsb.GradeSectionCode = gs.GradeSectionCode;
            gsb.HomeRoomNumber = gs.HomeRoomNumber;
            gsb.HomeRoomTeacherId = gs.HomeRoomTeacherId;
            gsb.SY = gs.SY;
            gsb.Section = gs.Section;
            gsb.Class = gs.Class;
        }

        public void TranslateGradeSectionBDOToGradeSection(GradeSectionBDO gs, GradeSection gsb)
        {
            RoomService rService = new RoomService();
            Room room = new Room();
            TeacherService tService = new TeacherService();
            Teacher teacher = new Teacher();
            string message = string.Empty;
            room = rService.GetRoom(gs.HomeRoomNumber);
            teacher = tService.GetTeacher(gs.HomeRoomTeacherId, ref message);
            gsb.Deactivated = gs.Deactivated;
            gsb.GradeLevel = gs.GradeLevel;
            gsb.GradeSectionCode = gs.GradeSectionCode;
            gsb.HomeRoom = room;
            gsb.HomeRoomNumber = gs.HomeRoomNumber;
            gsb.HomeRoomTeacherId = gs.HomeRoomTeacherId;
            gsb.HomeRoomTeacher = teacher;
            if (teacher.MiddleName == String.Empty)
                gsb.TeacherName = teacher.LastName + ", " + teacher.FirstName;
            else
                gsb.TeacherName = teacher.LastName + ", " + teacher.FirstName + " " + teacher.MiddleName.Substring(0, 1);
            gsb.Class = gs.Class;
            gsb.SY = gs.SY;
            gsb.Section = gs.Section;
        }


        public List<GradeSection> GetAllSectionsForGrade(string gradeLevel)
        {
            return ToGradeSectionList(gsLogic.GetAllSectionsofGrade(gradeLevel));
        }

        public bool UpdateGradeSection(ref GradeSection gs, ref string message)
        {
            GradeSectionBDO gsb = new GradeSectionBDO();
            TranslateGradeSectionToGradeSectionBDO(gs, gsb);
            return gsLogic.UpdateGradeSection(ref gsb, ref message);
        }


        public List<Room> GetAllRooms()
        {
            RoomService r = new RoomService();
            return r.GetAllRooms();
        }

        public List<Teacher> GetAllTeachers()
        {
            TeacherService t = new TeacherService();
            return t.GetAllTeachers();
        }

        public List<SchoolYear> GetAllSchoolYears()
        {
            SchoolYearService s = new SchoolYearService();
            return s.GetAllSY();
        }

        public List<GradeLevel> GetAllGradeLevels()
        {
            GradeLevelService g = new GradeLevelService();
            return g.GetAllGradeLevels();
        }
    }
}
