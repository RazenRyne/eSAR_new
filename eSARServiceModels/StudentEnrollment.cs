using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARServiceModels
{
    public class StudentEnrollment
    {

        Student stu = new Student();
         
        public string StudentSY { get; set; }
         
        public string StudentId { get; set; }
         
        public string SY { get; set; }
         
        public string GradeLevel { get; set; }
         
        public int Rank { get; set; }
         
        public Nullable<int> GradeSectionCode { get; set; }
         
        public Nullable<bool> Dismissed { get; set; }
         
        public int StudentEnrollmentsID { get; set; }
         
        public int DiscountId { get; set; }
         
        public string Stat { get; set; }
         
        public string StudentName { get; set; }
         
        public Student student
        {
            get { return stu; }
            set { stu = value; }
        }

    }
}
