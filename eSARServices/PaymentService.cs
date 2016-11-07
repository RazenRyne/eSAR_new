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
    public class PaymentService : IPaymentService
    {
        PaymentLogic plogic = new PaymentLogic();
        StudentLogic stuLogic = new StudentLogic();
        TeacherLogic teachLogic = new TeacherLogic();

        public bool CreatePayment(ref Payment payment, ref string message)
        {
            PaymentBDO pbdo = new PaymentBDO();
            TranslatePaymentToPaymentBDO(payment, pbdo);
            return plogic.CreatePayment(ref pbdo, ref message);
        }

        public List<Payment> GetAllPayments()
        {
            List<Payment> plist = new List<Payment>();
            foreach (PaymentBDO pbdo in plogic.GetALlPayments())
            {
                string[] arrStudent = new string[2];
                Payment p = new Payment();
                TranslatePaymentBDOToPayment(pbdo, p);
                arrStudent = GetStudentName(pbdo.StudentId);
                p.StudentName = arrStudent[0];
                p.Balance = float.Parse(arrStudent[1]);
                plist.Add(p);
            }
            return plist;
        }

        public List<Payment> GetAllStudentsPayments(string studentID)
        {
            List<Payment> plist = new List<Payment>();
            foreach (PaymentBDO pbdo in plogic.GetALlStudentsPayments(studentID))
            {
                string[] arrStudent = new string[2];
                Payment p = new Payment();
                TranslatePaymentBDOToPayment(pbdo, p);
                arrStudent = GetStudentName(pbdo.StudentId);
                p.StudentName = arrStudent[0];
                p.Balance = float.Parse(arrStudent[1]);
                plist.Add(p);
            }
            return plist;
        }


        public String[] GetStudentName(string studentid)
        {
            StudentBDO stuBDO = new StudentBDO();
            stuBDO = stuLogic.GetStudent(studentid);
            string[] arrStudent = new string[2];
            arrStudent[0] = stuBDO.LastName + ", " + stuBDO.FirstName + " " + stuBDO.MiddleName;
            arrStudent[1] = stuBDO.RunningBalance.ToString();

            return arrStudent;
        }



        public Payment GetPayment(int ORNo, ref string message)
        {
            Payment pment = new Payment();
            PaymentBDO pbdo = plogic.GetPayment(ORNo);
            if (pbdo != null)
            {
                TranslatePaymentBDOToPaymentDTO(pbdo, pment);
            }
            else message = "Payment Does Not Exists";

            return pment;
        }

        public List<PaymentDetail> GetAllPaymentDetails(int ORNo)
        {
            List<PaymentDetail> pdlist = new List<PaymentDetail>();
            foreach (PaymentDetailsBDO pdbdo in plogic.GetAllPaymentDetails(ORNo))
            {
                PaymentDetail pd = new PaymentDetail();
                TranslatePaymentDetailsBDOToPaymentDetailsDTO(pdbdo, pd);
                pdlist.Add(pd);
            }
            return pdlist;
        }

        public void TranslatePaymentToPaymentBDO(Payment p, PaymentBDO pbdo)
        {
            pbdo.BusinessStyle = p.BusinessStyle;
            pbdo.Cancelled = p.Cancelled;
            pbdo.ORNo = p.ORNo;
            pbdo.PaidAt = p.PaidAt;
            pbdo.PaidTo = p.PaidTo;
            //pbdo.PaymentDetails = ToPaymentDetailsBDOList(p.PaymentDetails);
            pbdo.ReceivedFrom = p.ReceivedFrom;
            pbdo.SettlementFor = p.SettlementFor;
            pbdo.StudentId = p.StudentId;
            pbdo.TIN = p.TIN;
            pbdo.Amount = p.Amount;
            pbdo.Adres = p.Adres;
        }

        public void TranslatePaymentBDOToPaymentDTO(PaymentBDO pBDO, Payment pment)
        {
            pment.BusinessStyle = pBDO.BusinessStyle;
            pment.Cancelled = pBDO.Cancelled;
            pment.ORNo = pBDO.ORNo;
            pment.PaidAt = pBDO.PaidAt;
            pment.PaidTo = pBDO.PaidTo;
            //pment.PaymentDetails = ToPaymentDetailDTO(pBDO.PaymentDetails);
            pment.ReceivedFrom = pBDO.ReceivedFrom;
            pment.SettlementFor = pBDO.SettlementFor;
            pment.StudentId = pBDO.StudentId;
            pment.TIN = pBDO.TIN;
            pment.Amount = (float)pBDO.Amount;
            pment.Adres = pBDO.Adres;
        }

        public List<PaymentDetail> ToPaymentDetailDTO(List<PaymentDetailsBDO> pdbdoList)
        {
            List<PaymentDetail> pdList = new List<PaymentDetail>();
            foreach (PaymentDetailsBDO pdBDO in pdbdoList)
            {
                PaymentDetail pd = new PaymentDetail();
                TranslatePaymentDetailsBDOToPaymentDetailsDTO(pdBDO, pd);
                pdList.Add(pd);
            }
            return pdList;
        }

        public void TranslatePaymentBDOToPayment(PaymentBDO pbdo, Payment p)
        {
            p.BusinessStyle = pbdo.BusinessStyle;
            p.Cancelled = pbdo.Cancelled;
            p.ORNo = pbdo.ORNo;
            p.PaidAt = pbdo.PaidAt;
            p.PaidTo = pbdo.PaidTo;
            //p.PaymentDetails = ToPaymentDetailsList(pbdo.PaymentDetails);
            p.ReceivedFrom = pbdo.ReceivedFrom;
            p.SettlementFor = pbdo.SettlementFor;
            p.StudentId = pbdo.StudentId;
            p.TIN = pbdo.TIN;
            p.Amount = pbdo.Amount ?? 0;
            p.Adres = pbdo.Adres;
        }

        public void TranslatePaymentDetailsBDOToPaymentDetailsDTO(PaymentDetailsBDO pdbdo, PaymentDetail pd)
        {
            pdbdo.Amout = pd.Amout;
            pdbdo.DetailNumber = pd.DetailNumber;
            pdbdo.FeeID = pd.FeeID;
            pdbdo.ORNo = pd.ORNo;
        }

        public void TranslatePaymentDetailsToPaymentDetailsBDO(PaymentDetail payment, PaymentDetailsBDO pdbdo)
        {
            pdbdo.Amout = payment.Amout;
            pdbdo.DetailNumber = payment.DetailNumber;
            pdbdo.FeeID = payment.FeeID;
            pdbdo.ORNo = payment.ORNo;
        }

        public List<PaymentDetail> ToPaymentDetailsList(List<PaymentDetailsBDO> pdbdoList)
        {
            List<PaymentDetail> pdList = new List<PaymentDetail>();
            foreach (PaymentDetailsBDO pdbdo in pdbdoList)
            {
                PaymentDetail pd = new PaymentDetail();
                TranslatePaymentDetailsBDOToPaymentDetailsDTO(pdbdo, pd);
                pdList.Add(pd);
            }
            return pdList;
        }

        public List<PaymentDetailsBDO> ToPaymentDetailsBDOList(List<PaymentDetail> pdList)
        {
            List<PaymentDetailsBDO> pdbdoList = new List<PaymentDetailsBDO>();
            foreach (PaymentDetail pd in pdList)
            {
                PaymentDetailsBDO pdbdo = new PaymentDetailsBDO();
                TranslatePaymentDetailsToPaymentDetailsBDO(pd, pdbdo);
                pdbdoList.Add(pdbdo);
            }
            return pdbdoList;
        }
    }
}
