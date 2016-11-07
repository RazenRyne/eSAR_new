using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARServiceModels;

namespace eSARServiceInterface
{
    public interface ITeacherService
    {
         
        Boolean CreateTeacher(ref Teacher teacher, ref string message);
         
        Boolean UpdateTeacher(ref Teacher teacher, ref string message);
         
        List<Teacher> GetAllTeachers();
         
        List<Teacher> GetFilteredTeachers(string searchType, string search);
         
        Teacher GetTeacher(string teacherId, ref string message);
         
        Boolean DeactivateTeacher(string teacherId, ref string message);
        Teacher ActivateTeacher(string fname, string mname, string lname);


        String GenerateTeacherId();
    }
}
