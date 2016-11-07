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
    public class TeacherService : ITeacherService
    {
        TeacherLogic tLogic = new TeacherLogic();
        public bool CreateTeacher(ref Teacher teacher, ref string message)
        {
            Boolean ret = false; ;
            TeacherBDO tbdo = new TeacherBDO();
            TranslateTeacherDTOToTeacherBDO(teacher, tbdo);
            ret = tLogic.CreateTeacher(ref tbdo, ref message);
            return ret;
        }
        public String GenerateTeacherId()
        {
            return tLogic.GenerateTeacherId();
        }

        public bool DeactivateTeacher(string teacherId, ref string message)
        {
            // Teacher teacher = new Teacher();
            TeacherBDO tbdo = tLogic.GetTeacher(teacherId);
            tbdo.Deactivated = true;
            return tLogic.UpdateTeacher(ref tbdo, ref message);
        }

        public Teacher ActivateTeacher(string fname, string mname, string lname)
        {
            String message = " ";
            Teacher teacher = new Teacher();
            TeacherBDO tbdo = new TeacherBDO();
            tbdo = tLogic.GetTeacher(lname, fname, mname);
           
            if (tbdo == null)
            {
                return null;
            }
            else {
                tbdo.Deactivated = false;
                tLogic.UpdateTeacher(ref tbdo, ref message);
                TranslateTeacherBDOToTeacherDTO(tbdo, teacher);
                return teacher;
            }

        }


        public List<Teacher> GetAllTeachers()
        {
            return ToTeacherList(tLogic.GetAllTeachers());
        }

        public List<Teacher> GetFilteredTeachers(string searchType, string search)
        {
            return ToTeacherList(tLogic.GetFilteredTeachers(searchType, search));
        }

        public Teacher GetTeacher(string teacherId, ref string message)
        {
            Teacher teacher = new Teacher();
            TeacherBDO tbdo = tLogic.GetTeacher(teacherId);
            if (tbdo != null)
            {
                TranslateTeacherBDOToTeacherDTO(tbdo, teacher);
            }
            else message = "Teacher Does Not Exists";

            return teacher;
        }
        public Teacher GetTeacher(string lname, string fname, string mname)
        {
            string message = String.Empty;
            Teacher teacher = new Teacher();
            TeacherBDO tbdo = tLogic.GetTeacher(lname, fname, mname);
            if (tbdo != null)
            {
                TranslateTeacherBDOToTeacherDTO(tbdo, teacher);
            }
            else message = "Teacher Does Not Exists";

            return teacher;

        }


        public bool UpdateTeacher(ref Teacher teacher, ref string message)
        {
            TeacherBDO tbdo = new TeacherBDO();
            TranslateTeacherDTOToTeacherBDO(teacher, tbdo);
            return tLogic.UpdateTeacher(ref tbdo, ref message);
        }

        public List<Teacher> ToTeacherList(List<TeacherBDO> tc)
        {
            List<Teacher> tList = new List<Teacher>();
            foreach (TeacherBDO t in tc)
            {
                Teacher to = new Teacher();
                TranslateTeacherBDOToTeacherDTO(t, to);
                tList.Add(to);
            }
            return tList;
        }

        public void TranslateTeacherDTOToTeacherBDO(Teacher teacher, TeacherBDO tb)
        {
            tb.BloodType = teacher.BloodType;
            tb.CivilStatus = teacher.CivilStatus;
            tb.DateOfAppointment = teacher.DateOfAppointment;
            tb.Deactivated = teacher.Deactivated;
            tb.DialectSpoken = teacher.DialectSpoken;
            tb.DOB = teacher.DOB;
            tb.EmailAddress = teacher.EmailAddress;
            tb.EmploymentStatus = teacher.EmploymentStatus;
            tb.FirstName = teacher.FirstName;
            tb.Gender = teacher.Gender;
            tb.HeightCm = teacher.HeightCm;
            tb.LastName = teacher.LastName;
            tb.MiddleName = teacher.MiddleName;
            tb.MobileNo = teacher.MobileNo;
            tb.PagIBIGNo = teacher.PagIBIGNo;
            tb.PAMunicipality = teacher.PAMunicipality;
            tb.PAProvince = teacher.PAProvince;
            tb.PARegion = teacher.PARegion;
            tb.PAStreetName = teacher.PAStreetName;
            tb.PhilHealthNo = teacher.PhilHealthNo;
            tb.POBMunicipality = teacher.POBMunicipality;
            tb.POBProvince = teacher.POBProvince;
            tb.PreviousSchool = teacher.PreviousSchool;
            tb.RAMunicipality = teacher.RAMunicipality;
            tb.RAProvince = teacher.RAProvince;
            tb.RARegion = teacher.RARegion;
            tb.RAStreetName = teacher.RAStreetName;
            tb.ResTelephoneNo = teacher.ResTelephoneNo;
            tb.SpouseBusinessAdd = teacher.SpouseBusinessAdd;
            tb.SpouseEmployerName = teacher.SpouseEmployerName;
            tb.SpouseFirstName = teacher.SpouseFirstName;
            tb.SpouseLastName = teacher.SpouseLastName;
            tb.SpouseMiddleName = teacher.SpouseMiddleName;
            tb.SpouseOccupation = teacher.SpouseOccupation;
            tb.SpouseTelephoneNo = teacher.SpouseTelephoneNo;
            tb.SSSNum = teacher.SSSNum;
            tb.TeacherId = teacher.TeacherId;
            tb.TIN = teacher.TIN;
            tb.WeightKg = teacher.WeightKg;
            tb.Image = teacher.Image;
            tb.PERAA = teacher.PERAA;
            tb.Academic = teacher.Academic;
            tb.TeacherChildrens = ToChildrenBDO(teacher.TeacherChildrens);
            tb.TeacherEligibilities = ToEligibilityBDO(teacher.TeacherEligibilities);
            tb.TeacherEducationalBackgrounds = ToEducBacBDO(teacher.TeacherEducationalBackgrounds);
            tb.TrainingSeminars = ToTrainSemBDO(teacher.TrainingSeminars);
            tb.WorkExperiences = ToWorkExpBDO(teacher.WorkExperiences);
            tb.Academic = teacher.Academic ?? false;
            tb.Salary = teacher.Salary;
            tb.Department = teacher.Department;
        }

        public void TranslateTeacherBDOToTeacherDTO(TeacherBDO teacher, Teacher tb)
        {
            if (teacher.MiddleName.Length > 0)
                tb.TeacherName = teacher.LastName + ", " + teacher.FirstName + " " + teacher.MiddleName.Substring(0, 1) + ".";
            else
                tb.TeacherName = teacher.LastName + ", " + teacher.FirstName;
            tb.BloodType = teacher.BloodType;
            tb.CivilStatus = teacher.CivilStatus;
            tb.DateOfAppointment = (DateTime)teacher.DateOfAppointment;
            tb.Deactivated = teacher.Deactivated;
            tb.DialectSpoken = teacher.DialectSpoken;
            tb.DOB = (DateTime)teacher.DOB;
            tb.EmailAddress = teacher.EmailAddress;
            tb.EmploymentStatus = teacher.EmploymentStatus;
            tb.FirstName = teacher.FirstName;
            tb.Gender = teacher.Gender;
            tb.HeightCm = (int)teacher.HeightCm;
            tb.LastName = teacher.LastName;
            tb.MiddleName = teacher.MiddleName;
            tb.MobileNo = teacher.MobileNo;
            tb.PagIBIGNo = teacher.PagIBIGNo;
            tb.PAMunicipality = teacher.PAMunicipality;
            tb.PAProvince = teacher.PAProvince;
            tb.PARegion = teacher.PARegion;
            tb.PAStreetName = teacher.PAStreetName;
            tb.PhilHealthNo = teacher.PhilHealthNo;
            tb.POBMunicipality = teacher.POBMunicipality;
            tb.POBProvince = teacher.POBProvince;
            tb.PreviousSchool = teacher.PreviousSchool;
            tb.RAMunicipality = teacher.RAMunicipality;
            tb.RAProvince = teacher.RAProvince;
            tb.RARegion = teacher.RARegion;
            tb.RAStreetName = teacher.RAStreetName;
            tb.ResTelephoneNo = teacher.ResTelephoneNo;
            tb.SpouseBusinessAdd = teacher.SpouseBusinessAdd;
            tb.SpouseEmployerName = teacher.SpouseEmployerName;
            tb.SpouseFirstName = teacher.SpouseFirstName;
            tb.SpouseLastName = teacher.SpouseLastName;
            tb.SpouseMiddleName = teacher.SpouseMiddleName;
            tb.SpouseOccupation = teacher.SpouseOccupation;
            tb.SpouseTelephoneNo = teacher.SpouseTelephoneNo;
            tb.SSSNum = teacher.SSSNum;
            tb.TeacherId = teacher.TeacherId;
            tb.TIN = teacher.TIN;
            tb.WeightKg = (double)teacher.WeightKg;
            tb.Image = teacher.Image;
            tb.PERAA = teacher.PERAA;
            tb.Academic = teacher.Academic;
            tb.TeacherChildrens = ToChildrenDTO(teacher.TeacherChildrens);
            tb.TeacherEligibilities = ToEligibilityDTO(teacher.TeacherEligibilities);
            tb.TeacherEducationalBackgrounds = ToEducBacDTO(teacher.TeacherEducationalBackgrounds);
            tb.TrainingSeminars = ToTrainSemDTO(teacher.TrainingSeminars);
            tb.WorkExperiences = ToWorkExpDTO(teacher.WorkExperiences);
            tb.Academic = teacher.Academic;
            tb.Salary = teacher.Salary;
            tb.Department = teacher.Department;
        }

        public List<TeacherChildrenBDO> ToChildrenBDO(List<TeacherChildren> tc)
        {
            List<TeacherChildrenBDO> tcbdoList = new List<TeacherChildrenBDO>();
            foreach (TeacherChildren t in tc)
            {
                TeacherChildrenBDO tbdo = new TeacherChildrenBDO();
                TranslateTeacherChildrenToTeacherChildrenBDO(t, tbdo);
                tcbdoList.Add(tbdo);
            }
            return tcbdoList;
        }

        public List<TeacherChildren> ToChildrenDTO(List<TeacherChildrenBDO> tc)
        {
            List<TeacherChildren> tcbdoList = new List<TeacherChildren>();
            foreach (TeacherChildrenBDO t in tc)
            {
                TeacherChildren tbdo = new TeacherChildren();
                TranslateTeacherChildrenBDOToTeacherChildrenDTO(t, tbdo);
                tcbdoList.Add(tbdo);
            }
            return tcbdoList;
        }

        public void TranslateTeacherChildrenToTeacherChildrenBDO(TeacherChildren tc, TeacherChildrenBDO tcbdo)
        {
            tcbdo.ChildId = tc.ChildId;
            tcbdo.DOB = tc.DOB;
            tcbdo.FirstName = tc.FirstName;
            tcbdo.LastName = tc.LastName;
            tcbdo.MiddleName = tc.MiddleName;
            tcbdo.TeacherId = tc.TeacherId;
        }

        public void TranslateTeacherChildrenBDOToTeacherChildrenDTO(TeacherChildrenBDO tcbdo, TeacherChildren tc)
        {
            tc.ChildId = tcbdo.ChildId;
            tc.DOB = tcbdo.DOB;
            tc.FirstName = tcbdo.FirstName;
            tc.LastName = tcbdo.LastName;
            tc.MiddleName = tcbdo.MiddleName;
            tc.TeacherId = tcbdo.TeacherId;
        }


        public List<TeacherEligibility> ToEligibilityDTO(List<TeacherEligibilityBDO> te)
        {
            List<TeacherEligibility> teList = new List<TeacherEligibility>();
            foreach (TeacherEligibilityBDO t in te)
            {
                TeacherEligibility tedo = new TeacherEligibility();
                TranslateTeacherEligibilityBDOToTeacherEligibilityDTO(t, tedo);
                teList.Add(tedo);
            }
            return teList;
        }

        public List<TeacherEligibilityBDO> ToEligibilityBDO(List<TeacherEligibility> te)
        {
            List<TeacherEligibilityBDO> teList = new List<TeacherEligibilityBDO>();
            foreach (TeacherEligibility t in te)
            {
                TeacherEligibilityBDO tedo = new TeacherEligibilityBDO();
                TranslateTeacherEligibilityToTeacherEligibilityBDO(t, tedo);
                teList.Add(tedo);
            }
            return teList;
        }

        public void TranslateTeacherEligibilityToTeacherEligibilityBDO(TeacherEligibility te, TeacherEligibilityBDO tebdo)
        {
            tebdo.DateOfExam = te.DateOfExam;
            tebdo.Eligibility = te.Eligibility;
            tebdo.EligibilityId = te.EligibilityId;
            tebdo.IssueDate = te.IssueDate;
            tebdo.LicenseNumber = te.LicenseNumber;
            tebdo.PlaceOfExam = te.PlaceOfExam;
            tebdo.Rating = te.Rating;
            tebdo.TeacherId = te.TeacherId;
        }

        public void TranslateTeacherEligibilityBDOToTeacherEligibilityDTO(TeacherEligibilityBDO tebdo, TeacherEligibility te)
        {
            te.Eligibility = tebdo.Eligibility;
            te.EligibilityId = tebdo.EligibilityId;
            te.IssueDate = tebdo.IssueDate;
            te.LicenseNumber = tebdo.LicenseNumber;
            te.PlaceOfExam = tebdo.PlaceOfExam;
            te.Rating = tebdo.Rating;
            te.TeacherId = tebdo.TeacherId;
        }


        public List<TeacherEducationalBackground> ToEducBacDTO(List<TeacherEducationalBackgroundBDO> teb)
        {
            List<TeacherEducationalBackground> tebdoList = new List<TeacherEducationalBackground>();
            foreach (TeacherEducationalBackgroundBDO t in teb)
            {
                TeacherEducationalBackground tebdo = new TeacherEducationalBackground();
                TranslateTeacherEducationalBackgroundBDOToTeacheEducationalBackgroundDTO(t, tebdo);
                tebdoList.Add(tebdo);
            }
            return tebdoList;
        }

        public List<TeacherEducationalBackgroundBDO> ToEducBacBDO(List<TeacherEducationalBackground> teb)
        {
            List<TeacherEducationalBackgroundBDO> tebdoList = new List<TeacherEducationalBackgroundBDO>();
            foreach (TeacherEducationalBackground t in teb)
            {
                TeacherEducationalBackgroundBDO tebdo = new TeacherEducationalBackgroundBDO();
                TranslateTeacherEducationalBackgroundToTeacherEducationalBackgroundBDO(t, tebdo);
                tebdoList.Add(tebdo);
            }
            return tebdoList;
        }

        public void TranslateTeacherEducationalBackgroundToTeacherEducationalBackgroundBDO(TeacherEducationalBackground tc, TeacherEducationalBackgroundBDO tcbdo)
        {
            tcbdo.Course = tc.Course;
            tcbdo.Deactivated = tc.Deactivated;
            tcbdo.EducLevel = tc.EducLevel;
            tcbdo.HonorsReceived = tc.HonorsReceived;
            tcbdo.NameOfSchool = tc.NameOfSchool;
            tcbdo.TeacherId = tc.TeacherId;
            tcbdo.TEBId = tc.TEBId;
            tcbdo.TEBYearFrom = tc.TEBYearFrom;
            tcbdo.TEBYearTo = tc.TEBYearTo;

        }

        public void TranslateTeacherEducationalBackgroundBDOToTeacheEducationalBackgroundDTO(TeacherEducationalBackgroundBDO tc, TeacherEducationalBackground tcbdo)
        {
            tcbdo.Course = tc.Course;
            tcbdo.Deactivated = tc.Deactivated;
            tcbdo.EducLevel = tc.EducLevel;
            tcbdo.HonorsReceived = tc.HonorsReceived;
            tcbdo.NameOfSchool = tc.NameOfSchool;
            tcbdo.TeacherId = tc.TeacherId;
            tcbdo.TEBId = tc.TEBId;
            tcbdo.TEBYearFrom = tc.TEBYearFrom;
            tcbdo.TEBYearTo = tc.TEBYearTo;
        }

        public List<TrainingSeminarBDO> ToTrainSemBDO(List<TrainingSeminar> teb)
        {
            List<TrainingSeminarBDO> tebdoList = new List<TrainingSeminarBDO>();
            foreach (TrainingSeminar t in teb)
            {
                TrainingSeminarBDO tebdo = new TrainingSeminarBDO();
                TranslateTrainingSeminarToTrainingSeminarBDO(t, tebdo);
                tebdoList.Add(tebdo);
            }
            return tebdoList;
        }

        public List<TrainingSeminar> ToTrainSemDTO(List<TrainingSeminarBDO> teb)
        {
            List<TrainingSeminar> tebdoList = new List<TrainingSeminar>();
            foreach (TrainingSeminarBDO t in teb)
            {
                TrainingSeminar tebdo = new TrainingSeminar();
                TranslateTrainingSeminarBDOToTrainingSeminarDTO(t, tebdo);
                tebdoList.Add(tebdo);
            }
            return tebdoList;
        }

        public void TranslateTrainingSeminarToTrainingSeminarBDO(TrainingSeminar tc, TrainingSeminarBDO tcbdo)
        {
            tcbdo.AreaOfTraining = tc.AreaOfTraining;
            tcbdo.ConductedBy = tc.ConductedBy;
            tcbdo.DateFrom = tc.DateFrom;
            tcbdo.DateTo = tc.DateTo;
            tcbdo.NoOfHours = tc.NoOfHours;
            tcbdo.TeacherId = tc.TeacherId;
            tcbdo.Title = tc.Title;
            tcbdo.TSID = tc.TSID;

        }

        public void TranslateTrainingSeminarBDOToTrainingSeminarDTO(TrainingSeminarBDO tc, TrainingSeminar tcbdo)
        {
            tcbdo.AreaOfTraining = tc.AreaOfTraining;
            tcbdo.ConductedBy = tc.ConductedBy;
            tcbdo.DateFrom = tc.DateFrom;
            tcbdo.DateTo = tc.DateTo;
            tcbdo.NoOfHours = tc.NoOfHours;
            tcbdo.TeacherId = tc.TeacherId;
            tcbdo.Title = tc.Title;
            tcbdo.TSID = tc.TSID;
        }

        public List<WorkExperienceBDO> ToWorkExpBDO(List<WorkExperience> teb)
        {
            List<WorkExperienceBDO> tebdoList = new List<WorkExperienceBDO>();
            foreach (WorkExperience t in teb)
            {
                WorkExperienceBDO tebdo = new WorkExperienceBDO();
                TranslateWorkExperienceToWorkExperienceBDO(t, tebdo);
                tebdoList.Add(tebdo);
            }
            return tebdoList;
        }

        public List<WorkExperience> ToWorkExpDTO(List<WorkExperienceBDO> teb)
        {
            List<WorkExperience> tebdoList = new List<WorkExperience>();
            foreach (WorkExperienceBDO t in teb)
            {
                WorkExperience tebdo = new WorkExperience();
                TranslateWorkExperienceBDOToWorkExperienceDTO(t, tebdo);
                tebdoList.Add(tebdo);
            }
            return tebdoList;
        }


        public void TranslateWorkExperienceToWorkExperienceBDO(WorkExperience tc, WorkExperienceBDO tcbdo)
        {
            tcbdo.CompanyName = tc.CompanyName;
            tcbdo.MonthlySalary = tc.MonthlySalary;
            tcbdo.Position = tc.Position;
            tcbdo.StatusOfEmployment = tc.StatusOfEmployment;
            tcbdo.TeacherId = tc.TeacherId;
            tcbdo.WEId = tc.WEId;
            tcbdo.WorkExpFrom = tc.WorkExpFrom;
            tcbdo.WorkExpTo = tc.WorkExpTo;

        }

        public void TranslateWorkExperienceBDOToWorkExperienceDTO(WorkExperienceBDO tc, WorkExperience tcbdo)
        {
            tcbdo.CompanyName = tc.CompanyName;
            tcbdo.MonthlySalary = (double)tc.MonthlySalary;
            tcbdo.Position = tc.Position;
            tcbdo.StatusOfEmployment = tc.StatusOfEmployment;
            tcbdo.TeacherId = tc.TeacherId;
            tcbdo.WEId = tc.WEId;
            tcbdo.WorkExpFrom = (DateTime)tc.WorkExpFrom;
            tcbdo.WorkExpTo = (DateTime)tc.WorkExpTo;
        }


    }
}
