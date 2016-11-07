using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARServiceModels
{
    public class GradeSection
    {
        List<SubjectAssignment> subass = new List<SubjectAssignment>();
        //List<StudentEnrollment> studenr = new List<StudentEnrollment>();
       
        public int GradeSectionCode { get; set; }
       
        public string GradeLevel { get; set; }
       
        public string Section { get; set; }
         
        public int HomeRoomNumber { get; set; }
         
        public string SY { get; set; }
         
        public string HomeRoomTeacherId { get; set; }
         
        public bool Deactivated { get; set; }
         
        public Teacher HomeRoomTeacher { get; set; }
         
        public Room HomeRoom { get; set; }
         
        public SchoolYear SchoolYr { get; set; }
         
        public String TeacherName { get; set; }
         
        public Nullable<int> Class { get; set; }

         
        public List<SubjectAssignment> SubjectAssignments { get { return this.subass; } set { this.subass = value; } }
        // 
        //public List<StudentEnrollment> StudentEnrollments { get{return this.studenr;} set{this.studenr=value;} }
    }
}
