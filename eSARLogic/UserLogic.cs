using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARBDO;
using eSARDAL;
using System.Security.Cryptography;

namespace eSARLogic
{
    public class UserLogic
    {
        UserDAO userDAO = new UserDAO();
        public UserBDO GetUser(string username) {
            return userDAO.GetUserBDO(username);
        }

        public UserBDO GetUser(int userId)
        {
            return userDAO.GetUserBDO(userId);
        }

        public List<UserBDO> GetAllUsers() {
            return userDAO.GetAllUsers();
        }

        public Boolean AuthenticateUser(string username, string password, ref string message) {
            Boolean ret = false;
            UserBDO userBDO = new UserBDO();
            message = "Incorrect Username/Password";
            userBDO = GetUser(username);

            if (userBDO != null)
            {
                if (ComparePasswords(userBDO.Password, password))
                {
                    message = "WELCOME " + username;
                    ret = true;
                }
            }
            
            return ret;
        }

        public static bool ComparePasswords(string PasswordHash, string Password)
        {
            if (string.IsNullOrEmpty(PasswordHash) || string.IsNullOrEmpty(Password)) return false;
            if (PasswordHash.Length < 40 || Password.Length < 1) return false;

            byte[] salt = new byte[20];
            byte[] key = new byte[20];
            byte[] hash = Convert.FromBase64String(PasswordHash);

            try
            {
                Buffer.BlockCopy(hash, 0, salt, 0, 20);
                Buffer.BlockCopy(hash, 20, key, 0, 20);

                using (var hashBytes = new Rfc2898DeriveBytes(Password, salt, 10000))
                {
                    byte[] newKey = hashBytes.GetBytes(20);

                    if (newKey != null)
                        if (newKey.SequenceEqual(key))
                            return true;
                }
                return false;
            }
            finally
            {
                if (salt != null)
                    Array.Clear(salt, 0, salt.Length);
                if (key != null)
                    Array.Clear(key, 0, key.Length);
                if (hash != null)
                    Array.Clear(hash, 0, hash.Length);
            }
        }


        public Boolean CreateUser(ref UserBDO userBDO, ref string message) {
            Boolean ret = false;
            UserBDO uBDO = GetUser(userBDO.UserName);
            if (uBDO == null)
                ret = userDAO.CreateUser(ref userBDO, ref message);
            else
                message = "Username already exists. Please select another username";

            return ret;
        }

        public Boolean UserExists(int userId) {
            Boolean ret = true;
            var userInDB = GetUser(userId);

            if (userInDB == null)
                ret = false;

            return ret;
        }

        public Boolean UpdateUser(ref UserBDO userBDO, ref string message) {
            if (UserExists(userBDO.UserId))
                return userDAO.UpdateUser(ref userBDO, ref message);
            else
            {
                message = "Cannot get user for this ID";
                return false;
            }
        }

        public Boolean DeactivateUser(int userId, ref string message) {
            if (UserExists(userId))
                return userDAO.DeactivateUser(userId, ref message);
            else
            {
                message = "Cannot get user for this ID";
                return false;
            }
        }

        public Boolean ActivateUser(int userId, ref string message)
        {
            if (UserExists(userId))
                return userDAO.ActivateUser(userId, ref message);
            else
            {
                message = "Cannot get user for this ID";
                return false;
            }
        }

        public Boolean DeleteUser(int userId, ref string message) {
            if (UserExists(userId))
                return userDAO.DeleteUser(userId, ref message);
            else
            {
                message = "Cannot get user for this ID";
                return false;
            }
        }

        public List<UserTypeBDO> GetAllUserTypes()
        {
            return userDAO.GetAllUserTypes();
        }

    }
}
