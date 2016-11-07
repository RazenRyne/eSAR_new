using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARServiceModels
{
    public class Payment
    {
        //List<PaymentDetail> paymentList = new List<PaymentDetail>();
         
        public int ORNo { get; set; }
         
        public string StudentId { get; set; }
         
        public string StudentName { get; set; }
         
        public string SettlementFor { get; set; }
         
        public string ReceivedFrom { get; set; }
         
        public string TIN { get; set; }
         
        public string PaidAt { get; set; }
         
        public string BusinessStyle { get; set; }
         
        public int PaidTo { get; set; }
         
        public string PaidToName { get; set; }
         
        public Boolean Cancelled { get; set; }
         
        public float Amount { get; set; }
         
        public string Adres { get; set; }

        public float Balance { get; set; }
        // 
        //public List<PaymentDetail> PaymentDetails
        //{
        //    get { return this.paymentList; }
        //    set { this.paymentList = value; }
        //}
    }
}
