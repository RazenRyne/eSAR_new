using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARServiceModels;

namespace eSARServiceInterface
{
    public interface IUserService
    {
         
        Boolean AuthenticateUser(string username, string password, ref string message);
         
        User GetUser(string username);
         
        Boolean CreateUser(ref User user, ref string message);
         
        Boolean UpdateUser(ref User user, ref string message);
         
        List<User> GetAllUsers();
         
        Boolean DeactivateUser(int userId, ref string message);
         
        Boolean ActivateUser(int userId, ref string message);
         
        Boolean DeleteUser(int userId, ref string message);
         
        List<UserType> GetAllUserTypes();
         
        string GetCurrentSy();
        // TODO: Add your service operations here
    }

}
