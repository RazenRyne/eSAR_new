using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARBDO;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace eSARDAL
{
    public class PaymentDAO
    {
        public PaymentBDO GetPaymentBDO(int ORNo)
        {
            PaymentBDO paymentBDO = null;
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                Payment pymnt = (from p in DCEnt.Payments
                                 where p.ORNo == ORNo
                                 select p).FirstOrDefault();
                if (pymnt != null)
                {
                    paymentBDO = new PaymentBDO();
                    ConvertPaymentToPaymentBDO(pymnt, paymentBDO);
                }
            }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return paymentBDO;
        }

        public List<PaymentBDO> GetAllPayments()
        {
            List<Payment> pList = new List<Payment>();
            List<PaymentBDO> pBDOList = new List<PaymentBDO>();
            try
            {
            using (var DCEnt = new DCFIEntities())
            {
                var allPayments = (DCEnt.Payments);
                pList = allPayments.ToList<Payment>();
            }

           
            foreach (Payment p in pList)
            {
                PaymentBDO pBDO = new PaymentBDO();
                ConvertPaymentToPaymentBDO(p, pBDO);
                pBDOList.Add(pBDO);
            }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return pBDOList;
        }

        public List<PaymentBDO> GetAllStudentsPayments(string studentID)
        {
            List<Payment> pList = new List<Payment>();
            using (var DCEnt = new DCFIEntities())
            {
                var allPayments = (from p in DCEnt.Payments
                                   where p.StudentId == studentID
                                   select p);
                pList = allPayments.ToList<Payment>();
               
            }

            List<PaymentBDO> pBDOList = new List<PaymentBDO>();
            foreach (Payment p in pList)
            {
                PaymentBDO pBDO = new PaymentBDO();
                ConvertPaymentToPaymentBDO(p, pBDO);
                pBDOList.Add(pBDO);
            }
            return pBDOList;
        }
       
        public Boolean CreatePayment(ref PaymentBDO payBDO, ref string message)
        {
            message = "Payment Added Successfully";
            bool ret = true;

            Payment p = new Payment();
            try { 
            ConvertPaymentBDOToPayment(payBDO, p);
            using (var DCEnt = new DCFIEntities())
            {
                DCEnt.Payments.Add(p);
                DCEnt.Entry(p).State = System.Data.Entity.EntityState.Added;
                int num = DCEnt.SaveChanges();
                payBDO.ORNo = p.ORNo;

                if (num < 1)
                {
                    ret = false;
                    message = "Adding of Payment failed";
                }
            }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return ret;
        }

       public List<PaymentDetailsBDO> GetAllPaymentDetailsForPayment(int ORNo)
        {
            List<PaymentDetail> paymentDetails = null;
            List<PaymentDetailsBDO> pbdoList = new List<PaymentDetailsBDO>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                paymentDetails = (from pd in DCEnt.PaymentDetails
                                  where pd.ORNo == ORNo
                                  select pd).ToList<PaymentDetail>();
            }
            foreach (PaymentDetail pd in paymentDetails)
            {
                PaymentDetailsBDO paymentDetailsBDO = new PaymentDetailsBDO();
                ConvertPaymentDetailsToPaymentDetailsBDO(pd, paymentDetailsBDO);
                pbdoList.Add(paymentDetailsBDO);
            }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return pbdoList;
        }

        private void ConvertPaymentDetailsToPaymentDetailsBDO(PaymentDetail pd, PaymentDetailsBDO paymentDetailsBDO)
        {
            paymentDetailsBDO.Amout = (float) pd.Amount;
            paymentDetailsBDO.DetailNumber = pd.DetailNumber;
            paymentDetailsBDO.FeeID = pd.FeeID;
            paymentDetailsBDO.ORNo = (int) pd.ORNo;
        }

        private void ConvertPaymentToPaymentBDO(Payment p, PaymentBDO paymentBDO)
        {
            paymentBDO.BusinessStyle = p.BusinessStyle;
            paymentBDO.Cancelled = p.Cancelled;
            paymentBDO.ORNo = p.ORNo;
            paymentBDO.PaidAt = p.PaidAt;
            paymentBDO.PaidTo = (int)p.PaidTo;
            paymentBDO.ReceivedFrom = p.ReceivedFrom;
            paymentBDO.SettlementFor = p.SettlementFor;
            paymentBDO.StudentId = p.StudentId;
            paymentBDO.TIN = p.TIN;
            paymentBDO.Amount = (float?)p.Amount;
            paymentBDO.Adres = p.Adres;
        }

        private void ConvertPaymentBDOToPayment(PaymentBDO pbdo, Payment p)
        {
            p.BusinessStyle = pbdo.BusinessStyle;
            p.Cancelled = pbdo.Cancelled;
            p.ORNo = pbdo.ORNo;
            p.PaidAt = pbdo.PaidAt;
            p.PaidTo = (int)pbdo.PaidTo;
            p.ReceivedFrom = pbdo.ReceivedFrom;
            p.SettlementFor = pbdo.SettlementFor;
            p.StudentId = pbdo.StudentId;
            p.TIN = pbdo.TIN;
            p.Amount = pbdo.Amount;
            p.Adres = pbdo.Adres;
            //p.PaymentDetails = ToPaymentDetailsList(pbdo.PaymentDetails);
        }

        private List<PaymentDetail> ToPaymentDetailsList(List<PaymentDetailsBDO> paymentDetails)
        {
            List<PaymentDetail> pdList = new List<PaymentDetail>();
            foreach (PaymentDetailsBDO pdbdo in paymentDetails)
            {
                PaymentDetail pd = new PaymentDetail();
                pd.Amount = pdbdo.Amout;
                pd.DetailNumber = pdbdo.DetailNumber;
                pd.FeeID = pdbdo.FeeID;
                pd.ORNo = pdbdo.ORNo;
            }
            return pdList;
        }


    }
}
