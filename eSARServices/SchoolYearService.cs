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
    public class SchoolYearService : ISchoolYearService
    {
        SchoolYearLogic syLogic = new SchoolYearLogic();

        public SchoolYear GetSY(string schoolyear)
        {
            SchoolYearBDO SYbdo = new SchoolYearBDO();
            SYbdo = syLogic.GetSY(schoolyear);
            SchoolYear u = new SchoolYear();
            TranslateSYBDOToSYDTO(SYbdo, u);

            return u;
        }

        public Boolean CreateSY(ref SchoolYear schoolyear, ref string message)
        {
            message = String.Empty;
            SchoolYearBDO syBDO = new SchoolYearBDO();
            TranslateSYDTOToSYBDO(schoolyear, syBDO);
            return syLogic.CreateSY(ref syBDO, ref message);
        }

        public Boolean UpdateSY(ref SchoolYear schoolyear, ref string message)
        {
            message = String.Empty;
            SchoolYearBDO syBDO = new SchoolYearBDO();
            TranslateSYDTOToSYBDO(schoolyear, syBDO);
            return syLogic.UpdateSY(ref syBDO, ref message);
        }

        public List<SchoolYear> GetAllSY()
        {

            List<SchoolYearBDO> syBDOList = syLogic.GetAllSY();
            List<SchoolYear> allSY = new List<SchoolYear>();
            foreach (SchoolYearBDO syBDO in syBDOList)
            {
                SchoolYear sy = new SchoolYear();
                TranslateSYBDOToSYDTO(syBDO, sy);
                allSY.Add(sy);
            }
            return allSY;
        }

        public Boolean DeleteSY(string schoolyear, ref string message)
        {

            message = String.Empty;
            return syLogic.DeleteSY(schoolyear, ref message);
        }


        private void TranslateSYDTOToSYBDO(SchoolYear schoolyear, SchoolYearBDO syBDO)
        {
            syBDO.SY = schoolyear.SY;
            syBDO.CurrentSY = schoolyear.CurrentSY;
        }

        private void TranslateSYBDOToSYDTO(SchoolYearBDO syBDO, SchoolYear schoolyear)
        {
            schoolyear.SY = syBDO.SY;
            schoolyear.CurrentSY = syBDO.CurrentSY;
        }

        public SchoolYear GetCurrentSY()
        {
            List<SchoolYear> syList = GetAllSY();
            return syList.Find(s => s.CurrentSY == true);

        }
    }
}
