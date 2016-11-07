using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARBDO;
using eSARDAL;

namespace eSARLogic
{
    public class ScholarshipLogic
    {
        ScholarshipDAO sDAO = new ScholarshipDAO();
        public List<ScholarshipDiscountBDO> GetAllScholarships()
        {
            List<ScholarshipDiscountBDO> scholBDO = new List<ScholarshipDiscountBDO>();
            scholBDO=sDAO.GetAllScholarships();
            return scholBDO;
        }


        public List<ScholarshipDiscountBDO> GetAllScholarshipDiscounts(int scholarshipCode)
        {
            return sDAO.GetAllScholarshipDiscountsFromScholarship(scholarshipCode);
        }


        public List<StudentBDO> GetAllScholars()
        {
            return sDAO.GetAllScholars();
        }

        public List<StudentBDO> GetAllScholarsofScholarship(int scholarshipCode)
        {
            return sDAO.GetAllScholarsofScholarship(scholarshipCode);
        }

        public List<ScholarshipDiscountBDO> GetAllDiscounts(int scholarshipCode)
        {
            return sDAO.GetAllDiscounts(scholarshipCode);
        }

        public Boolean AddScholarshipDiscount(ScholarshipDiscountBDO sdBDO, int scholarshipCode, ref string message)
        {
            return sDAO.AddScholarshipDiscount(sdBDO, scholarshipCode, ref message);
        }

        public Boolean CreateScholarship(ref ScholarshipDiscountBDO sbdo, ref string message)
        {
            return sDAO.CreateScholarship(ref sbdo, ref message);
        }

        public Boolean UpdateScholarship(ref ScholarshipDiscountBDO sbdo, ref string message)
        {
            return sDAO.UpdateScholarship(ref sbdo, ref message);
        }

        public Boolean UpdateScholarshipDiscount(ref ScholarshipDiscountBDO sdBDO, ref string message)
        {
            return sDAO.UpdateScholarshipDiscount(ref sdBDO, ref message);
        }

        public Boolean DeleteScholarshipDiscount(int sdbdoCode)
        {
            return sDAO.DeleteScholarshipDiscount(sdbdoCode);
        }

    }
}
