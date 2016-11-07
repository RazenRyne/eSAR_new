using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARBDO;
using eSARDAL;

namespace eSARLogic
{
    public class SchoolYearLogic
    {

        SchoolYearDAO syDAO = new SchoolYearDAO();
        public SchoolYearBDO GetSY(string schoolyear)
        {
            return syDAO.GetSYBDO(schoolyear);
        }

        public List<SchoolYearBDO> GetAllSY()
        {
            return syDAO.GetAllSY();
        }

        public Boolean CreateSY(ref SchoolYearBDO schoolYearBDO, ref string message)
        {
            Boolean ret = false;
            SchoolYearBDO syBDO = GetSY(schoolYearBDO.SY);
            if (syBDO == null)
                ret = syDAO.CreateSY(ref schoolYearBDO, ref message);
            else
                message = "SchoolYear already exists. Please select another username";

            return ret;
        }

        public Boolean SYExists(string schoolyear)
        {
            Boolean ret = true;
            var syInDB = GetSY(schoolyear);

            if (syInDB == null)
                ret = false;

            return ret;
        }

        public Boolean UpdateSY(ref SchoolYearBDO syBDO, ref string message)
        {
            if (SYExists(syBDO.SY))
                return syDAO.UpdateSY(ref syBDO, ref message);
            else
            {
                message = "Cannot get School Year";
                return false;
            }
        }

        public Boolean DeleteSY(string schoolYear, ref string message)
        {
            if (SYExists(schoolYear))
                return syDAO.DeleteSY(schoolYear, ref message);
            else
            {
                message = "Cannot get SchoolYear";
                return false;
            }
        }


    }
}
