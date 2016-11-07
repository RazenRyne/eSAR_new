using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARBDO;
using eSARDAL;

namespace eSARLogic
{
    public class PaymentDetailsLogic
    {
        PaymentDetailsDAO pdDAO = new PaymentDetailsDAO();

        public List<PaymentDetailsBDO> GetAllPaymentDetails()
        {
            return pdDAO.GetAllPaymentDetails();
        }

        public Boolean CreatePaymentDetail(ref PaymentDetailsBDO paymentDetailsBDO, ref string message)
        {
            Boolean ret = false;
            ret = pdDAO.CreatePaymentDetail(ref paymentDetailsBDO, ref message);
            return ret;
        }
        
    }
}
