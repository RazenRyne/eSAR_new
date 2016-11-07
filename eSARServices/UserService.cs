using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARBDO;
using eSARLogic;
using eSARServiceInterface;
using eSARServiceModels;


namespace eSARServices
{
    public class UserService : IUserService
    {
        UserLogic userLogic = new UserLogic();
        public User GetUser(string username)
        {
            UserBDO ubdo = new UserBDO();
            ubdo = userLogic.GetUser(username);
            User u = new User();
            TranslateUserBDOToUserDTO(ubdo, u);

            return u;
        }

        public Boolean AuthenticateUser(string username, string password, ref string message)
        {
            Boolean ret = false;
            ret = userLogic.AuthenticateUser(username, password, ref message);

            return ret;
        }

        public Boolean CreateUser(ref User user, ref string message)
        {
            message = String.Empty;
            UserBDO userBDO = new UserBDO();
            TranslateUserDTOToUserBDO(user, userBDO);
            return userLogic.CreateUser(ref userBDO, ref message);
        }

        public Boolean UpdateUser(ref User user, ref string message)
        {

            message = String.Empty;
            UserBDO userBDO = new UserBDO();
            TranslateUserDTOToUserBDO(user, userBDO);
            return userLogic.UpdateUser(ref userBDO, ref message);
        }

        public List<User> GetAllUsers()
        {

            List<UserBDO> userBDOList = userLogic.GetAllUsers();
            List<User> allUsers = new List<User>();
            foreach (UserBDO userBDO in userBDOList)
            {
                User user = new User();
                TranslateUserBDOToUserDTO(userBDO, user);
                allUsers.Add(user);
            }
            return allUsers;
        }

        public Boolean DeactivateUser(int userId, ref string message)
        {

            message = String.Empty;
            return userLogic.DeactivateUser(userId, ref message);
        }

        public Boolean ActivateUser(int userId, ref string message)
        {

            message = String.Empty;
            return userLogic.ActivateUser(userId, ref message);
        }

        public Boolean DeleteUser(int userId, ref string message)
        {

            message = String.Empty;
            return userLogic.DeleteUser(userId, ref message);
        }

        public List<UserType> GetAllUserTypes()
        {

            List<UserTypeBDO> userTypeBDOList = userLogic.GetAllUserTypes();
            List<UserType> allUserTypes = new List<UserType>();
            foreach (UserTypeBDO userTypeBDO in userTypeBDOList)
            {
                UserType userType = new UserType();
                TranslateUserTypeBDOToUserTypeDTO(userTypeBDO, userType);
                allUserTypes.Add(userType);
            }
            return allUserTypes;
        }

        public void TranslateUserTypeBDOToUserTypeDTO(UserTypeBDO userTypeBDO, UserType userType)
        {
            userType.UsersType = userTypeBDO.UsersType;
            userType.UserTypeCode = userTypeBDO.UserTypeCode;
        }

        public void TranslateUserDTOToUserBDO(User user, UserBDO userBDO)
        {
            UserTypeBDO ut = new UserTypeBDO();
            ut.UserTypeCode = user.UserTypeCode;
            userBDO.UserId = user.UserId;
            userBDO.FirstName = user.FirstName;
            userBDO.LastName = user.LastName;
            userBDO.MiddleName = user.MiddleName;
            userBDO.UserName = user.UserName;
            userBDO.Password = user.Password;
            userBDO.UserType = ut;
        }

        public void TranslateUserBDOToUserDTO(UserBDO userBDO, User user)
        {
            user.UserId = userBDO.UserId;
            user.FirstName = userBDO.FirstName;
            user.LastName = userBDO.LastName;
            user.MiddleName = userBDO.MiddleName;
            user.UserName = userBDO.UserName;
            user.Password = userBDO.Password;
            user.UserTypeCode = userBDO.UserType.UserTypeCode;
        }

        public string GetCurrentSy()
        {
            SchoolYearService sys = new SchoolYearService();
            SchoolYear sy = sys.GetCurrentSY();
            return sy.SY;
        }
    }
}
