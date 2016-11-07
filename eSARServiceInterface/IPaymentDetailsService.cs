using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARServiceModels;

namespace eSARServiceInterface
{
    public interface IPaymentDetailsService
    {
       
        Boolean CreatePaymentDetail(ref PaymentDetail pd, ref string message);
        
        List<PaymentDetail> GetAllPaymentDetails();
    }
}
