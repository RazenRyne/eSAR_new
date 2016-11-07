using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace eSAR.Utility_Classes
{
    public static class GlobalClass
    {
        public static LoggedUser user { get; set; }
        public static string currentsy { get; set; }
        public static string selectedSY { get; set; }
        public static string receiptCurrent { get; set; }
        public static string receiptFrom { get; set; }
        public static string receiptTo { get; set; }
        public static string userTypeCode { get; set; }
        public static Boolean UserLoggedIn { get; set; }
        public static Boolean WindowStatusManageReceipt { get; set; }
        public static Boolean WindowStatusPaymentDetails { get; set; }
        public static Boolean WindowProspectusDetails { get; set; }
        public static Boolean WindowPromotionalDetails { get; set; }
        public static Boolean WindowTeachersLoadDetails { get; set; }
        public static Boolean WindowReligionDetails { get; set; }
        public static Boolean WindowAttendanceDetails { get; set; }
        public static Boolean WindowPaymentDetails { get; set; }
        public static Boolean WindowBillingDetails { get; set; }
        public static Boolean WindowScheduleDetails { get; set; }
        public static Boolean WindowStudentListDetails { get; set; }
        public static Boolean WindowLogoutDetails { get; set; }
        public static string fromScreen { get; set; }
        public static Nullable<int> gvDatasource { get; set; }
        //public static List<StudentSchedule>
    }

   public class LoggedUser {
        public  int UserId { get; set; }
        public  string UserName { get; set; }
        public  string LastName { get; set; }
        public  string FirstName { get; set; }
        public  string MiddleName { get; set; }
        public  string UserType { get; set; }
    }
    

}


