using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARBDO;
using eSARDAL;

namespace eSARLogic
{
   public class TeacherLogic
    {
        TeacherDAO teacherDAO = new TeacherDAO();

        public List<TeacherBDO> GetAllTeachers() {
            List<TeacherBDO> teachBDO = new List<TeacherBDO>();
            foreach (TeacherBDO  t in teacherDAO.GetAllTeachers()) {
                t.TeacherChildrens = teacherDAO.GetAllChildren(t.TeacherId);
                t.TeacherEligibilities = teacherDAO.GetAllEligibility(t.TeacherId);
                t.TeacherEducationalBackgrounds = teacherDAO.GetAllEducationalBackground(t.TeacherId);
                t.TrainingSeminars = teacherDAO.GetAllTrainingSeminars(t.TeacherId);
                t.WorkExperiences = teacherDAO.GetAllWorkExperience(t.TeacherId);
                teachBDO.Add(t);
            }
            return teachBDO;
        }
        

        public List<TeacherBDO> GetFilteredTeachers(string searchType, string search)
        {
            List<TeacherBDO> teachBDO = new List<TeacherBDO>();
            foreach (TeacherBDO t in teacherDAO.GetFilteredTeachers(searchType, search))
            {
                t.TeacherChildrens = teacherDAO.GetAllChildren(t.TeacherId);
                t.TeacherEligibilities = teacherDAO.GetAllEligibility(t.TeacherId);
                t.TeacherEducationalBackgrounds = teacherDAO.GetAllEducationalBackground(t.TeacherId);
                t.TrainingSeminars = teacherDAO.GetAllTrainingSeminars(t.TeacherId);
                t.WorkExperiences = teacherDAO.GetAllWorkExperience(t.TeacherId);
                teachBDO.Add(t);
            }
            return teachBDO;
        }


        public TeacherBDO GetTeacher(string teacherId) {
            TeacherBDO t = new TeacherBDO();
            t= teacherDAO.GetTeacherBDO(teacherId);
            if (t != null)
            {
                t.TeacherChildrens = teacherDAO.GetAllChildren(t.TeacherId);
                t.TeacherEligibilities = teacherDAO.GetAllEligibility(t.TeacherId);
                t.TeacherEducationalBackgrounds = teacherDAO.GetAllEducationalBackground(t.TeacherId);
                t.TrainingSeminars = teacherDAO.GetAllTrainingSeminars(t.TeacherId);
                t.WorkExperiences = teacherDAO.GetAllWorkExperience(t.TeacherId);
            }
            return t;
        }


        public TeacherBDO GetTeacher(string lastname, string firstname)
        {
            TeacherBDO t = new TeacherBDO();
            t= teacherDAO.GetTeacherBDO(lastname,firstname);
            if (t != null)
            {
            t.TeacherChildrens = teacherDAO.GetAllChildren(t.TeacherId);
            t.TeacherEligibilities = teacherDAO.GetAllEligibility(t.TeacherId);
            t.TeacherEducationalBackgrounds = teacherDAO.GetAllEducationalBackground(t.TeacherId);
            t.TrainingSeminars = teacherDAO.GetAllTrainingSeminars(t.TeacherId);
            t.WorkExperiences = teacherDAO.GetAllWorkExperience(t.TeacherId);
            }
            return t;
        }

        public TeacherBDO GetTeacher(string lastname, string firstname, string mname)
        {
            TeacherBDO t = new TeacherBDO();
            t = teacherDAO.GetTeacherBDO(lastname, firstname, mname);
            if (t != null)
            {
                t.TeacherChildrens = teacherDAO.GetAllChildren(t.TeacherId);
                t.TeacherEligibilities = teacherDAO.GetAllEligibility(t.TeacherId);
                t.TeacherEducationalBackgrounds = teacherDAO.GetAllEducationalBackground(t.TeacherId);
                t.TrainingSeminars = teacherDAO.GetAllTrainingSeminars(t.TeacherId);
                t.WorkExperiences = teacherDAO.GetAllWorkExperience(t.TeacherId);
            }
            return t;
        }

        public Boolean CreateTeacher(ref TeacherBDO teacherBDO, ref string message)
        {
            Boolean ret = false;
            TeacherBDO tBDO = GetTeacher(teacherBDO.LastName, teacherBDO.FirstName);
            if (tBDO == null)
            {
                //   teacherBDO.TeacherId = GenerateTeacherId();
                ret = teacherDAO.CreateTeacher(ref teacherBDO, ref message);

            }
            else
                message = teacherBDO.LastName + ", " + teacherBDO.FirstName + " already exists. Please check your entry";

            return ret;
        }

        public Boolean CreateTeacherChildren(List<TeacherChildrenBDO> tcbdo, string teacherId) {
            Boolean ret = false;
            ret = teacherDAO.CreateTeacherChildren(tcbdo, teacherId);
            return ret;
        }

        public Boolean CreateTeacherEducationalBackground(List<TeacherEducationalBackgroundBDO> tcbdo, string teacherId)
        {
            Boolean ret = false;
            ret = teacherDAO.CreateTeacherEducationalBackground(tcbdo, teacherId);
            return ret;
        }

        public Boolean CreateTeacherEligibilities(List<TeacherEligibilityBDO> tcbdo, string teacherId)
        {
            Boolean ret = false;
            ret = teacherDAO.CreateTeacherEligibilities(tcbdo, teacherId);
            return ret;
        }

        public Boolean CreateTrainingSeminars(List<TrainingSeminarBDO> tcbdo, string teacherId)
        {
            Boolean ret = false;
            ret = teacherDAO.CreateTrainingSeminars(tcbdo, teacherId);
            return ret;
        }

        public Boolean CreateWorkExperiences(List<WorkExperienceBDO> tcbdo, string teacherId)
        {
            Boolean ret = false;
            ret = teacherDAO.CreateWorkExperiences(tcbdo, teacherId);
            return ret;
        }

        public Boolean UpdateTeacher(ref TeacherBDO teacherBDO, ref string message) {
            if (GetTeacher(teacherBDO.TeacherId)!=null)
                return teacherDAO.UpdateTeacher(ref teacherBDO, ref message);
            else
            {
                message = "Cannot get teacher for this ID";
                return false;
            }

        }

        public String GenerateTeacherId()
        {
            string latestTeacherId = teacherDAO.GetLatestTeacherId();
            StringBuilder teacherId = new StringBuilder();
            string yearNow = DateTime.Now.Year.ToString();
            int con = 1;
            string c = String.Empty;
            if (!latestTeacherId.Equals("none"))
            {
                string latestYear = latestTeacherId.Substring(0, 4);
               
                teacherId.Append(yearNow);
                if (latestYear.Equals(yearNow))
                {
                    string control = latestTeacherId.Substring(4, 3);
                    con = Int32.Parse(control);
                    con++;
                    c = con.ToString();
                    if (c.Length == 1)
                        c = "00" + c;
                    else if (c.Length == 2)
                        c = "0" + c;
                }
                else
                {
                    c = "00" + con.ToString();
                }
                teacherId.Append(c);
            }
            else
            {
                teacherId.Append(yearNow);
                c = "00" + con.ToString();
                teacherId.Append(c);
            }
            return teacherId.ToString();
        }


    }
}
