using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARServiceModels
{
    public class Teacher
    {
        List<TeacherChildren> teachChild = new List<TeacherChildren>();
        List<TeacherEligibility> teachElig = new List<TeacherEligibility>();
        List<TeacherEducationalBackground> educBack = new List<TeacherEducationalBackground>();
        List<TrainingSeminar> trainSem = new List<TrainingSeminar>();
        List<WorkExperience> workExp = new List<WorkExperience>();

         
        public string TeacherId { get; set; }
         
        public string LastName { get; set; }
         
        public string FirstName { get; set; }
         
        public string MiddleName { get; set; }
         
        public string TeacherName { get; set; }
         
        public bool Deactivated { get; set; }
         
        public string Gender { get; set; }
         
        public DateTime DOB { get; set; }
         
        public string TIN { get; set; }
         
        public DateTime DateOfAppointment { get; set; }
         
        public string EmploymentStatus { get; set; }
         
        public string POBProvince { get; set; }
         
        public string POBMunicipality { get; set; }
         
        public string CivilStatus { get; set; }
         
        public int HeightCm { get; set; }
         
        public double WeightKg { get; set; }
         
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
         
        public bool? Academic { get; set; }

        public double? Salary { get; set; }

        public string Department { get; set; }


        public List<TeacherChildren> TeacherChildrens
        {
            get { return teachChild; }
            set { teachChild = value; }
        }
         
        public List<TeacherEducationalBackground> TeacherEducationalBackgrounds
        {
            get { return educBack; }
            set { educBack = value; }
        }
         
        public List<TeacherEligibility> TeacherEligibilities
        {
            get { return teachElig; }
            set { teachElig = value; }
        }
         
        public List<TrainingSeminar> TrainingSeminars
        {
            get { return trainSem; }
            set { trainSem = value; }
        }
         
        public List<WorkExperience> WorkExperiences
        {
            get { return workExp; }
            set { workExp = value; }
        }
    }
     
    public class WorkExperience
    {
         
        public string TeacherId { get; set; }
         
        public int WEId { get; set; }
         
        public DateTime WorkExpFrom { get; set; }
         
        public DateTime WorkExpTo { get; set; }
         
        public string Position { get; set; }
         
        public string CompanyName { get; set; }
         
        public double MonthlySalary { get; set; }
         
        public string StatusOfEmployment { get; set; }

    }
     
    public class TeacherEligibility
    {
         
        public string TeacherId { get; set; }
         
        public int EligibilityId { get; set; }
         
        public string Eligibility { get; set; }
         
        public string Rating { get; set; }
         
        public DateTime DateOfExam { get; set; }
         
        public string PlaceOfExam { get; set; }
         
        public string LicenseNumber { get; set; }
         
        public DateTime IssueDate { get; set; }
    }
     
    public class TeacherEducationalBackground
    {
         
        public string TeacherId { get; set; }
         
        public int TEBId { get; set; }
         
        public string EducLevel { get; set; }
         
        public string NameOfSchool { get; set; }
         
        public DateTime TEBYearFrom { get; set; }
         
        public DateTime TEBYearTo { get; set; }
         
        public string Course { get; set; }
         
        public string HonorsReceived { get; set; }
         
        public bool Deactivated { get; set; }
    }
     
    public class TeacherChildren
    {
         
        public string TeacherId { get; set; }
         
        public int ChildId { get; set; }
         
        public string LastName { get; set; }
         
        public string FirstName { get; set; }
         
        public string MiddleName { get; set; }
         
        public DateTime DOB { get; set; }

    }

     
    public class TrainingSeminar
    {
         
        public string TeacherId { get; set; }
         
        public int TSID { get; set; }
         
        public string Title { get; set; }
         
        public string AreaOfTraining { get; set; }
         
        public DateTime DateFrom { get; set; }
         
        public DateTime DateTo { get; set; }
         
        public double NoOfHours { get; set; }
         
        public string ConductedBy { get; set; }

    }
}
