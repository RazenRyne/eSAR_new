using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARServiceModels;

namespace eSARServiceInterface
{
    public interface ISchoolYearService
    {
         
        SchoolYear GetSY(string schoolyear);
         
        SchoolYear GetCurrentSY();
         
        Boolean CreateSY(ref SchoolYear schoolyear, ref string message);
         
        Boolean UpdateSY(ref SchoolYear schoolyear, ref string message);
         
        List<SchoolYear> GetAllSY();
         
        Boolean DeleteSY(string schoolyear, ref string message);
    }
}
