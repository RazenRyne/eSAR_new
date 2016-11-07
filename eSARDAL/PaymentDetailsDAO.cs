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
    public class PaymentDetailsDAO
    {
        public List<PaymentDetailsBDO> GetAllPaymentDetails()
        {
            List<PaymentDetail> paymentDetailsList = new List<PaymentDetail>();
            List<PaymentDetailsBDO> paymentDetailsBDOList = new List<PaymentDetailsBDO>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                var allPaymentDetails = (DCEnt.PaymentDetails);
                paymentDetailsList = allPaymentDetails.ToList<PaymentDetail>();
            }

         
            foreach (PaymentDetail pd in paymentDetailsList)
            {
                PaymentDetailsBDO paymentDetailsBDO = new PaymentDetailsBDO();
                ConvertPaymentDetailsToPaymentDetailsBDO(pd, paymentDetailsBDO);
                paymentDetailsBDOList.Add(paymentDetailsBDO);
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
            return paymentDetailsBDOList;
        }

        public PaymentDetailsBDO GetPaymentDetails(int ORNo)
        {
            PaymentDetail paymentDetail = null;
            PaymentDetailsBDO paymentDetailsBDO = new PaymentDetailsBDO();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                paymentDetail = (from pd in DCEnt.PaymentDetails
                                 where pd.ORNo == ORNo
                                 select pd).FirstOrDefault();
            }

        
            ConvertPaymentDetailsToPaymentDetailsBDO(paymentDetail, paymentDetailsBDO);
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
            return paymentDetailsBDO;
        }

        public Boolean CreatePaymentDetail(ref PaymentDetailsBDO paymentDetailsBDO, ref string message)
        {
            message = "Payment Detail Added Successfully";
            bool ret = true;

            PaymentDetail paymentDetail = new PaymentDetail();
            try
            {
                ConvertPaymentDetailsBDOToPaymentDetails(paymentDetailsBDO, paymentDetail);
                using (var DCEnt = new DCFIEntities())
                {
                    DCEnt.PaymentDetails.Attach(paymentDetail);
                    DCEnt.Entry(paymentDetail).State = System.Data.Entity.EntityState.Added;
                    int num = DCEnt.SaveChanges();

                    if (num != 1)
                    {
                        ret = false;
                        message = "Adding of Payment Details failed";
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
        

        public void ConvertPaymentDetailsToPaymentDetailsBDO(PaymentDetail pd, PaymentDetailsBDO paymentDetailsBDO)
        {
            paymentDetailsBDO.Amout = (float) pd.Amount;
            paymentDetailsBDO.DetailNumber = pd.DetailNumber;
            paymentDetailsBDO.FeeID = pd.FeeID;
            paymentDetailsBDO.ORNo = (int) pd.ORNo;
        }

        public void ConvertPaymentDetailsBDOToPaymentDetails(PaymentDetailsBDO paymentDetailsBDO, PaymentDetail pd)
        {
            pd.Amount = paymentDetailsBDO.Amout;
            pd.DetailNumber = paymentDetailsBDO.DetailNumber;
            pd.FeeID = paymentDetailsBDO.FeeID;
            pd.ORNo = paymentDetailsBDO.ORNo;
        }
    }
}
