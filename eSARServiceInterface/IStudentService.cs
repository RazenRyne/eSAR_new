using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARServiceModels;

namespace eSARServiceInterface
{
    public interface IStudentService
    {
         
        Boolean UpdateStudent(ref Student student, ref string message);
         
        Boolean DismissStudent(string studentID, ref string message);
         
        Boolean GraduateStudent(string studentID, ref string message);
         
        Boolean CreateStudent(ref Student student, ref string message);
         
        List<Student> GetAllStudents();
         
        Student GetStudent(string studentId, ref string message);
         
        String GenerateStudentId();
         
        int GetScholarshipDiscountId(string scho);

      
    }
}
