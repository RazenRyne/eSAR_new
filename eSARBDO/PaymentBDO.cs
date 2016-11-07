using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARBDO
{
    public class PaymentBDO
    {
        List<PaymentDetailsBDO> paymentList = new List<PaymentDetailsBDO>();
        public int ORNo { get; set; }
        public string StudentId { get; set; }
        public string SettlementFor { get; set; }
        public string ReceivedFrom { get; set; }
        public string TIN { get; set; }
        public string PaidAt { get; set; }
        public string BusinessStyle { get; set; }
        public int PaidTo { get; set; }
        public Boolean Cancelled { get; set; }
        public Nullable<float> Amount { get; set; }
        public string Adres { get; set; }

        public List<PaymentDetailsBDO> PaymentDetails
        {
            get { return this.paymentList; }
            set { this.paymentList = value; }
        }
    }
}
