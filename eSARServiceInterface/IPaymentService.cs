using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARServiceModels;

namespace eSARServiceInterface
{
    public interface IPaymentService
    {
         
        Boolean CreatePayment(ref Payment payment, ref string message);
         
        List<Payment> GetAllPayments();
         
        List<PaymentDetail> GetAllPaymentDetails(int ORNo);
         
        Payment GetPayment(int ORNo, ref string message);
         
        List<Payment> GetAllStudentsPayments(string studentID);

        String[] GetStudentName(string studentid);
    }
}
