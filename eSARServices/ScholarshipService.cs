using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARBDO;
using eSARLogic;
using eSARServiceInterface;
using eSARServiceModels;

namespace eSARServices
{
    public class ScholarshipService : IScholarshipService
    {
        ScholarshipLogic sLogic = new ScholarshipLogic();
        public bool AddScholarshipDiscount(ref ScholarshipDiscount scholarshipDiscount, int scholarshipCode, ref string message)
        {
            ScholarshipDiscountBDO sdbdo = new ScholarshipDiscountBDO();
            TranslateScholarshipDiscountToScholarshipDiscountBDO(scholarshipDiscount, sdbdo);
            return sLogic.AddScholarshipDiscount(sdbdo, scholarshipCode, ref message);
        }

        public bool CreateScholarship(ref ScholarshipDiscount scholarship, ref string message)
        {
            ScholarshipDiscountBDO sbdo = new ScholarshipDiscountBDO();
            TranslateScholarshipToScholarshipBDO(scholarship, sbdo);
            return sLogic.CreateScholarship(ref sbdo, ref message);
        }

        public bool DeleteScholarshipDiscount(int scholarshipFeeCode)
        {
            return sLogic.DeleteScholarshipDiscount(scholarshipFeeCode);
        }

        public List<Student> GetAllScholars()
        {
            List<Student> sList = new List<Student>();
            //foreach (StudentBDO sBDO in sLogic.GetAllScholars())
            //{
            //    Student scholar = new Student();
            //    Tra
            //}
            return sList;
        }

        public List<Student> GetAllScholarsOfScholarship(int scholarshipCode)
        {
            throw new NotImplementedException();
        }

        // Done
        public List<ScholarshipDiscount> GetAllScholarshipDiscount(int scholarshipCode)
        {
            List<ScholarshipDiscount> sDiscount = new List<ScholarshipDiscount>();
            foreach (ScholarshipDiscountBDO sdbdo in sLogic.GetAllDiscounts(scholarshipCode))
            {
                ScholarshipDiscount sc = new ScholarshipDiscount();
                TranslateScholarshipDiscountBDOToScholarshipDiscount(sdbdo, sc);
                sDiscount.Add(sc);
            }
            return sDiscount;
        }

        // Done
        public List<ScholarshipDiscount> GetAllScholarships()
        {
            List<ScholarshipDiscount> slist = new List<ScholarshipDiscount>();
            foreach (ScholarshipDiscountBDO sbdo in sLogic.GetAllScholarships())
            {
                ScholarshipDiscount s = new ScholarshipDiscount();
                TranslateScholarshipBDOToScholarship(sbdo, s);
                slist.Add(s);
            }
            return slist;
        }

        // Done
        public bool UpdateScholarship(ref ScholarshipDiscount scholarship, ref string message)
        {
            ScholarshipDiscountBDO sBDO = new ScholarshipDiscountBDO();
            TranslateScholarshipToScholarshipBDO(scholarship, sBDO);
            return sLogic.UpdateScholarship(ref sBDO, ref message);
        }

        // Done
        public bool UpdateScholarshipDiscount(ref ScholarshipDiscount scholarshipDiscount, ref string message)
        {
            ScholarshipDiscountBDO sdBDO = new ScholarshipDiscountBDO();
            TranslateScholarshipDiscountToScholarshipDiscountBDO(scholarshipDiscount, sdBDO);
            return sLogic.UpdateScholarshipDiscount(ref sdBDO, ref message);
        }

        public List<Fee> GetAllFees()
        {
            FeeService fs = new FeeService();
            return fs.GetAllFees();
        }

        private void TranslateScholarshipBDOToScholarship(ScholarshipDiscountBDO sc, ScholarshipDiscount sbdo)
        {
            sbdo.ScholarshipDiscountId = sc.ScholarshipDiscountId;
            sbdo.Scholarship = sc.Scholarship;
            sbdo.Discount = sc.Discount;
            sbdo.Deactivated = sc.Deactivated;
            sbdo.Description = sc.Description;

        }

        private void TranslateScholarshipToScholarshipBDO(ScholarshipDiscount sc, ScholarshipDiscountBDO sbdo)
        {
            sbdo.ScholarshipDiscountId = sc.ScholarshipDiscountId;
            sbdo.Scholarship = sc.Scholarship;
            sbdo.Discount = (float)sc.Discount;
            sbdo.Deactivated = sc.Deactivated;
            sbdo.Description = sc.Description;

        }

        private void TranslateScholarshipDiscountToScholarshipDiscountBDO(ScholarshipDiscount sc, ScholarshipDiscountBDO sbdo)
        {

            //FeeService fs = new FeeService();
            //Fee f = new Fee();
            //f = fs.GetFee(sc.FeeID);
            sbdo.Deactivated = sc.Deactivated;
            sbdo.Discount = (float)sc.Discount;
            sbdo.ScholarshipDiscountId = sc.ScholarshipDiscountId;
            //sbdo.Fee = f;
        }

        private void TranslateScholarshipDiscountBDOToScholarshipDiscount(ScholarshipDiscountBDO sc, ScholarshipDiscount sbdo)
        {

            sbdo.Deactivated = sc.Deactivated;
            sbdo.Discount = sc.Discount;

            sbdo.ScholarshipDiscountId = sc.ScholarshipDiscountId;

        }



        public List<ScholarshipDiscount> ToScholarhsipDiscountList(List<ScholarshipDiscountBDO> sdbdo)
        {
            List<ScholarshipDiscount> scholarshipDiscounts = new List<ScholarshipDiscount>();
            foreach (ScholarshipDiscountBDO SD in sdbdo)
            {
                ScholarshipDiscount s = new ScholarshipDiscount();
                TranslateScholarshipDiscountBDOToScholarshipDiscount(SD, s);
                scholarshipDiscounts.Add(s);
            }

            return scholarshipDiscounts;
        }

        public List<ScholarshipDiscountBDO> ToScholarhsipDiscountBDOList(List<ScholarshipDiscount> sdbdo)
        {
            List<ScholarshipDiscountBDO> scholarshipDiscounts = new List<ScholarshipDiscountBDO>();
            foreach (ScholarshipDiscount SD in sdbdo)
            {
                ScholarshipDiscountBDO s = new ScholarshipDiscountBDO();
                TranslateScholarshipDiscountToScholarshipDiscountBDO(SD, s);
                scholarshipDiscounts.Add(s);
            }

            return scholarshipDiscounts;
        }
    }
}
