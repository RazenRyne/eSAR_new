using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARServiceModels
{
    public class User
    {
         
        public int UserId { get; set; }
         
        public string UserName { get; set; }
         
        public string Password { get; set; }
         
        public string LastName { get; set; }
         
        public string FirstName { get; set; }
         
        public string MiddleName { get; set; }
         
        public string UserTypeCode { get; set; }
         
        public bool Deactivated { get; set; }
    }
    
    public class UserType
    {
         
        public string UserTypeCode { get; set; }
         
        public string UsersType { get; set; }
    }
}
