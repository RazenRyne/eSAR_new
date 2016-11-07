using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARBDO;
using eSARDAL;

namespace eSARLogic
{
    public class StudentLogic
    {
        StudentDAO studentDAO = new StudentDAO();
        public StudentBDO GetStudentWithRank(string StudentId, string grade, string gender) {
            List<StudentBDO> sbdolist = new List<StudentBDO>();
           sbdolist= studentDAO.GetStudentsWithRank(grade, gender);
            int index = sbdolist.FindIndex(p => p.StudentId.Equals(StudentId));
            return sbdolist[index];
        }

        public StudentBDO GetStudent(string studentID)
        {
            StudentBDO stuBDO = new StudentBDO();
            stuBDO = studentDAO.GetStudentBDO(studentID);
            //stuBDO.Siblings = studentDAO.GetSiblings(studentID);
            return stuBDO;
        }

        
        public List<StudentBDO> GetAllStudents()
        {
            List<StudentBDO> sBDO = new List<StudentBDO>();
            foreach (StudentBDO s in studentDAO.GetAllStudents()) {
                s.Siblings = studentDAO.GetSiblings(s.StudentId);
                sBDO.Add(s);
            }
            return sBDO;
        }

        public Boolean CreateStudent(ref StudentBDO studentBDO, ref string message)
        {
            Boolean ret = false;
            StudentBDO sBDO = GetStudent(studentBDO.StudentId);
            if (sBDO == null)
                ret = studentDAO.CreateStudent(ref studentBDO, ref message);
            else
                message = "Username already exists. Please select another username";

            return ret;
        }

        public Boolean CreateSibling(List<SiblingBDO> sBDO, string studentId) {
            return studentDAO.CreateSibling(sBDO, studentId);
        }

        public Boolean StudentExists(string studentID)
        {
            Boolean ret = true;
            var studentInDB = GetStudent(studentID);

            if (studentInDB == null)
                ret = false;

            return ret;
        }

        public Boolean UpdateStudent(ref StudentBDO studentBDO, ref string message)
        {
            if (StudentExists(studentBDO.StudentId))
                return studentDAO.UpdateStudent(ref studentBDO, ref message);
            else
            {
                message = "Cannot get user for this ID";
                return false;
            }
        }

        public Boolean DismissStudent(string studentID, ref string message)
        {
            if (StudentExists(studentID))
                return studentDAO.DismissStudent(studentID, ref message);
            else
            {
                message = "Cannot get student for this ID";
                return false;
            }
        }

        public Boolean GraduateStudent(string studentID, ref string message)
        {
            if (StudentExists(studentID))
                return studentDAO.DismissStudent(studentID, ref message);
            else
            {
                message = "Cannot get student for this ID";
                return false;
            }
        }

        public String GenerateStudentId() {
            string latestStudentId = studentDAO.GetLatestStudentId();
            StringBuilder studentId = new StringBuilder();
            string yearNow = DateTime.Now.Year.ToString();
            int con = 1;
            string c = String.Empty;
            if (!latestStudentId.Equals("none"))
            {
                string latestYear = latestStudentId.Substring(0, 4);
               
                string control = latestStudentId.Substring(4, 4);
                con= Int32.Parse(control);
                
                studentId.Append(yearNow);
                if (latestYear.Equals(yearNow))
                {
                    con++;
                    c = con.ToString();
                    if (c.Length == 1)
                        c = "000" + c;
                    else if (c.Length == 2)
                        c = "00" + c;
                    else if (c.Length == 3)
                        c = "0" + c;
                }
                else
                {
                    con = 1;
                    c = "000" + con.ToString();
                }

                studentId.Append(c);
            }
            else {
                studentId.Append(yearNow);
                c = "000" + con.ToString();
                studentId.Append(c);
            }

            return studentId.ToString();
        }
       
    }
}
