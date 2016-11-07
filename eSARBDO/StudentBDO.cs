using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARBDO
{
    public class StudentBDO
    {
        List<SiblingBDO> siblings = new List<SiblingBDO>();
        public string StudentId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string POBAddress { get; set; }
        public string POBBarangay { get; set; }
        public string POBTownCity { get; set; }
        public string POBProvince { get; set; }
        public string HomeAddress { get; set; }
        public string HomeBarangay { get; set; }
        public string HomeTownCity { get; set; }
        public string HomeProvince { get; set; }
        public string SchoolLastAttended { get; set; }
        public string FathersName { get; set; }
        public string FathersOccupation { get; set; }
        public Nullable<double> FathersAverageYearlyIncome { get; set; }
        public string FathersEducation { get; set; }
        public string MothersMaidenName { get; set; }
        public string MothersOccupation { get; set; }
        public Nullable<double> MothersAverageYearlyIncome { get; set; }
        public string MothersEducation { get; set; }
        public string GuardiansName { get; set; }
        public string GuardiansOccupation { get; set; }
        public Nullable<double> GuardiansAverageYearlyIncome { get; set; }
        public Nullable<bool> MadrasahEnrolled { get; set; }
        public Nullable<System.DateTime> DateAdmitted { get; set; }
        public string GradeLevel { get; set; }
        public Nullable<double> Average { get; set; }
        public Nullable<bool> Card { get; set; }
        public Nullable<bool> GoodMoral { get; set; }
        public Nullable<bool> BirthCertificate { get; set; }
        public Nullable<int> ScholarshipDiscountId { get; set; }
        public string LastSYAttendedDCFI { get; set; }
        public bool Dismissed { get; set; }
        public bool Graduated { get; set; }
        public string Religion { get; set; }
        public byte[] Image { get; set; }
        public string Gender { get; set; }
        public decimal UnitsFailedLastYear { get; set; }
        public Nullable<int> ranking { get; set; }
        public Nullable<float> RunningBalance { get; set; }
        public String Section { get; set; }
        public string StudentLRN { get; set; }
        public Nullable<double> FirstAverage { get; set; }
        public Nullable<double> SecondAverage { get; set; }
        public Nullable<double> ThirdAverage { get; set; }
        public ScholarshipDiscountBDO Scholarship { get; set; }
        public string GradeBeforeDC { get; set; }

        public List<SiblingBDO> Siblings
        {
            get { return siblings; }
            set { siblings = value; }
        }

        // public virtual ICollection<StudentEnrollment> StudentEnrollments { get; set; }
        // public virtual ICollection<Payment> Payments { get; set; }

        




    }
}
