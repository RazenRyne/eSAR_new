using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARBDO
{
    public class GradeSectionBDO
    {
        List<StudentEnrollmentBDO> studentEnrolled = new List<StudentEnrollmentBDO>();
        List<SubjectAssignmentBDO> subjectsEnrolled = new List<SubjectAssignmentBDO>();


        public TeacherBDO HomeRoomTeacher { get; set; }
        public RoomBDO HomeRoom { get; set; }
        public SchoolYearBDO SchoolYear { get; set; }
        public Nullable<int> Class { get; set; }
        public List<StudentEnrollmentBDO> EnrolledStudents
        {
            get { return studentEnrolled; }
            set { studentEnrolled = value; }
        }
        public List<SubjectAssignmentBDO> DefaultSubjects
        {
            get { return subjectsEnrolled; }
            set { subjectsEnrolled = value; }
        }

        public int GradeSectionCode { get; set; }
        public string GradeLevel { get; set; }
        public string Section { get; set; }
        public int HomeRoomNumber { get; set; }
        public string SY { get; set; }
        public string HomeRoomTeacherId { get; set; }
        public bool Deactivated { get; set; }

        public  GradeLevelBDO GradeLevel1 { get; set; }
        public List<StudentTraitBDO> StudentTraits { get; set; }
    }
}
