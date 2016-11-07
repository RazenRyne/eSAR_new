using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARBDO
{
    public class TeacherBDO
    {
        List<TeacherEducationalBackgroundBDO> educBac = new List<TeacherEducationalBackgroundBDO>();
        List<TeacherChildrenBDO> teachChild = new List<TeacherChildrenBDO>();
        List<TrainingSeminarBDO> trainSem = new List<TrainingSeminarBDO>();
        List<WorkExperienceBDO> workExp = new List<WorkExperienceBDO>();
        List<TeacherEligibilityBDO> teachElig = new List<TeacherEligibilityBDO>();
        public string TeacherId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public bool Deactivated { get; set; }
        public string Gender { get; set; }
        public Nullable<DateTime> DOB { get; set; }
        public string TIN { get; set; }
        public Nullable<DateTime> DateOfAppointment { get; set; }
        public string EmploymentStatus { get; set; }
        public string POBProvince { get; set; }
        public string POBMunicipality { get; set; }
        public string CivilStatus { get; set; }
        public Nullable<int>HeightCm { get; set; }
        public Nullable<double> WeightKg { get; set; }
        public string BloodType { get; set; }
        public string SSSNum { get; set; }
        public string PagIBIGNo { get; set; }
        public string PhilHealthNo { get; set; }
        public string RAStreetName { get; set; }
        public string RARegion { get; set; }
        public string RAProvince { get; set; }
        public string RAMunicipality { get; set; }
        public string ResTelephoneNo { get; set; }
        public string PAStreetName { get; set; }
        public string PARegion { get; set; }
        public string PAProvince { get; set; }
        public string PAMunicipality { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNo { get; set; }
        public string PreviousSchool { get; set; }
        public string DialectSpoken { get; set; }
        public string SpouseLastName { get; set; }
        public string SpouseFirstName { get; set; }
        public string SpouseMiddleName { get; set; }
        public string SpouseOccupation { get; set; }
        public string SpouseBusinessAdd { get; set; }
        public string SpouseEmployerName { get; set; }
        public string SpouseTelephoneNo { get; set; }
        public string PERAA { get; set; }
        public byte[] Image { get; set; }
        public Nullable<bool> Academic { get; set; }
        public Nullable<double> Salary { get; set; }
        public string Department { get; set; }


        public List<TeacherChildrenBDO> TeacherChildrens
        {
            get { return teachChild; }
            set { teachChild = value; }
        }
        
        public List<TeacherEducationalBackgroundBDO> TeacherEducationalBackgrounds
        {
            get { return educBac; }
            set { educBac = value; }
        }
        public List<TeacherEligibilityBDO> TeacherEligibilities
        {
            get { return teachElig; }
            set { teachElig = value; }
        }
        
        public List<TrainingSeminarBDO> TrainingSeminars
        {
            get { return trainSem; }
            set { trainSem = value; }
        }

        public List<WorkExperienceBDO> WorkExperiences
        {
            get { return workExp; }
            set { workExp = value; }
        }
    
    }
}
