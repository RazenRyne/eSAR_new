using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARBDO;
using eSARDAL;
namespace eSARLogic
{
   public class StudentTraitLogic
    {
        StudentTraitDAO std = new StudentTraitDAO();
        public Boolean AddStudentCharacters(StudentTraitBDO stbdo, ref string message) {
           return std.CreateStudentTrait(ref stbdo, ref message);
        }
    }
}
