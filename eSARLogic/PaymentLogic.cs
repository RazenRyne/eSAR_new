using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARBDO;
using eSARDAL;

namespace eSARLogic
{
    public class PaymentLogic
    {
        PaymentDAO pDAO = new PaymentDAO();

        public List<PaymentBDO> GetALlPayments()
        {
            List<PaymentBDO> paymentBDO = new List<PaymentBDO>();
            foreach (PaymentBDO p in pDAO.GetAllPayments())
            {
                p.PaymentDetails = GetAllPaymentDetails(p.ORNo);

                paymentBDO.Add(p);
            }
            return paymentBDO;
        }

        public List<PaymentBDO> GetALlStudentsPayments(string studentID)
        {
            List<PaymentBDO> paymentBDO = new List<PaymentBDO>();
            foreach (PaymentBDO p in pDAO.GetAllStudentsPayments(studentID))
            {
                p.PaymentDetails = GetAllPaymentDetails(p.ORNo);

                paymentBDO.Add(p);
            }
            return paymentBDO;
        }

       
        public PaymentBDO GetPayment(int ORNo)
        {
            PaymentBDO p = new PaymentBDO();
            p = pDAO.GetPaymentBDO(ORNo);
            if (p != null)
                p.PaymentDetails = pDAO.GetAllPaymentDetailsForPayment(p.ORNo);
            return p;
        }

        public List<PaymentDetailsBDO> GetAllPaymentDetails(int ORNo)
        {
            return pDAO.GetAllPaymentDetailsForPayment(ORNo);
        }
        
        public Boolean CreatePayment(ref PaymentBDO payment, ref string message)
        {
            return pDAO.CreatePayment(ref payment, ref message);
        }
    }
}
