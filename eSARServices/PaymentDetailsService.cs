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
    public class PaymentDetailsService : IPaymentDetailsService
    {
        PaymentDetailsLogic pdLogic = new PaymentDetailsLogic();
        public bool CreatePaymentDetail(ref PaymentDetail pd, ref string message)
        {
            PaymentDetailsBDO pdbdo = new PaymentDetailsBDO();
            TranslatePaymentDetailsDTOToPaymentDetailsBDO(pd, pdbdo);
            return pdLogic.CreatePaymentDetail(ref pdbdo, ref message);
        }

        public List<PaymentDetail> GetAllPaymentDetails()
        {
            List<PaymentDetail> pdList = new List<PaymentDetail>();
            foreach (PaymentDetailsBDO pdbdo in pdLogic.GetAllPaymentDetails())
            {
                PaymentDetail pd = new PaymentDetail();
                TranslatePaymentDetailBDOTopaymentDetailsDTO(pdbdo, pd);
                pdList.Add(pd);
            }
            return pdList;
        }

        public PaymentDetail GetPaymentDetail(int ORNo)
        {
            List<PaymentDetail> pdList = new List<PaymentDetail>();
            pdList = GetAllPaymentDetails();
            PaymentDetail pd = new PaymentDetail();
            pd = pdList.Find(pdl => pdl.ORNo == ORNo);

            return pd;
        }

        public void TranslatePaymentDetailsDTOToPaymentDetailsBDO(PaymentDetail pd, PaymentDetailsBDO pdbdo)
        {
            pdbdo.Amout = pd.Amout;
            pdbdo.DetailNumber = pd.DetailNumber;
            pdbdo.FeeID = pd.FeeID;
            pdbdo.ORNo = pd.ORNo;
        }

        public void TranslatePaymentDetailBDOTopaymentDetailsDTO(PaymentDetailsBDO pdbdo, PaymentDetail pd)
        {
            pd.Amout = pdbdo.Amout;
            pd.DetailNumber = pdbdo.DetailNumber;
            pd.FeeID = pdbdo.FeeID;
            pd.ORNo = pdbdo.ORNo;
        }
    }
}
