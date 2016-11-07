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
    public class FeeService : IFeeService
    {
        FeeLogic flogic = new FeeLogic();
        public bool CreateFee(ref Fee fee, ref string message)
        {
            FeeBDO fbdo = new FeeBDO();
            TranslateFeeToFeeBDO(fee, fbdo);
            return flogic.CreateFee(ref fbdo, ref message);
        }

        public List<Fee> GetAllFees()
        {
            List<Fee> flist = new List<Fee>();
            foreach (FeeBDO fbdo in flogic.GetAllFees())
            {
                Fee f = new Fee();
                TranslateFeeBDOToFee(fbdo, f);
                flist.Add(f);
            }
            return flist;
        }

        //Change Pending
        public Fee GetFee(int FeeID, string currSY)
        {
            List<Fee> flist = new List<Fee>();
            flist = GetAllFees();
            Fee fee = new Fee();
            fee = flist.Find(a => a.FeeID == FeeID && a.SYImplemented == currSY);

            return fee;
        }

        public Fee GetFeeForAll(string currSY)
        {
            Fee fee = new Fee();
            TranslateFeeBDOToFee(flogic.GetFeeForAll(currSY), fee);
            return fee;
        }

        public bool UpdateFee(ref Fee fee, ref string message)
        {
            FeeBDO fbdo = new FeeBDO();
            TranslateFeeToFeeBDO(fee, fbdo);
            return flogic.UpdateFee(ref fbdo, ref message);
        }

        public void TranslateFeeBDOToFee(FeeBDO fbdo, Fee f)
        {
            GradeLevelService gService = new GradeLevelService();
            if (fbdo != null)
            {
                f.Deactivated = fbdo.Deactivated;
                f.FeeID = fbdo.FeeID;
                f.FeeDescription = fbdo.FeeDescription;
                fbdo.NumPay = fbdo.NumPay ?? 0;
                f.NumPay = (int)fbdo.NumPay;
                fbdo.DiscountFullPay = fbdo.DiscountFullPay ?? 0;
                f.DiscountFullPay = (float)fbdo.DiscountFullPay;
                f.Amount = fbdo.Amount;
                //gService.
                f.GradeLev = gService.GetGradeLevel(fbdo.GradeLevel);
                f.GradeLevel = fbdo.GradeLevel;
                f.SYImplemented = fbdo.SYImplemented;
            }

        }

        public void TranslateFeeToFeeBDO(Fee f, FeeBDO fbdo)
        {
            fbdo.Deactivated = f.Deactivated;
            fbdo.FeeID = f.FeeID;
            fbdo.FeeDescription = f.FeeDescription;
            fbdo.NumPay = f.NumPay;
            fbdo.DiscountFullPay = f.DiscountFullPay;
            fbdo.Amount = f.Amount;
            fbdo.GradeLevel = f.GradeLevel;
            fbdo.SYImplemented = f.SYImplemented;

        }

        public List<FeeBDO> ToFeeBDOList(List<Fee> fList)
        {
            List<FeeBDO> feeList = new List<FeeBDO>();
            foreach (Fee f in fList)
            {
                FeeBDO fbdo = new FeeBDO();
                TranslateFeeToFeeBDO(f, fbdo);
                feeList.Add(fbdo);
            }
            return feeList;
        }

        //Changed
        public List<Fee> GetAllFeesForGradeLevel(string gradeLevel, string currSY)
        {
            List<Fee> fList = new List<Fee>();
            fList = ToFeeList(flogic.GetAllFees(gradeLevel, currSY));
            return fList;
        }

        private List<Fee> ToFeeList(List<FeeBDO> fbList)
        {
            List<Fee> fList = new List<Fee>();
            foreach (FeeBDO fb in fbList)
            {
                Fee f = new Fee();
                TranslateFeeBDOToFee(fb, f);
                fList.Add(f);
            }
            return fList;
        }

        public List<GradeLevel> GetAllGradeLevels()
        {
            GradeLevelService gl = new GradeLevelService();
            return gl.GetAllGradeLevels();
        }

        public List<SchoolYear> GetLastFiveSY()
        {
            SchoolYearService sy = new SchoolYearService();
            return sy.GetAllSY();
        }
    }
}
