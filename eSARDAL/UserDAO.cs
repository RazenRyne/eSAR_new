using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARBDO;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace eSARDAL
{
    public class UserDAO
    {
        public UserBDO GetUserBDO(string username)
        {
            UserBDO userBDO = null;
            UserTypeBDO utype = null;
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                 User user = (from u in DCEnt.Users
                             where u.UserName== username
                             select u).FirstOrDefault();
                if (user != null) {
                    utype = new UserTypeBDO() {
                        UserTypeCode = user.UserTypeCode
                    };
                    userBDO = new UserBDO()
                    {
                        UserId = user.UserId,
                        UserName = user.UserName,
                        Password = user.Password,
                        LastName = user.LastName,
                        FirstName = user.FirstName,
                        MiddleName = user.MiddleName,
                        UserType = utype
                    };
               }
            }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return userBDO;
        }

        public UserBDO GetUserBDO(int userId)
        {
            UserBDO userBDO = null;
            UserTypeBDO utype = null;
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                User user = (from u in DCEnt.Users
                             where u.UserId == userId
                             select u).FirstOrDefault();
                if (user != null)
                {
                    utype = new UserTypeBDO()
                    {
                        UserTypeCode = user.UserTypeCode
                    };
                    userBDO = new UserBDO()
                    {
                        UserId = user.UserId,
                        UserName = user.UserName,
                        Password = user.Password,
                        LastName = user.LastName,
                        FirstName = user.UserName,
                        MiddleName = user.MiddleName,
                        UserType = utype
                    };
                }
            }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return userBDO;
        }


        public User GetUser(int userId)
        {
            User user = null;
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                 user = (from u in DCEnt.Users
                             where u.UserId== userId
                             select u).FirstOrDefault();
                
            }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return user;

        }

        public List<UserBDO> GetAllUsers()
        {
            List<User> userList = new List<User>();
            List<UserBDO> userBDOList = new List<UserBDO>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
              var  allUsers = (DCEnt.Users);
                userList = allUsers.ToList<User>();
            }

 
            foreach (User u in userList) {
                UserBDO userBDO = new UserBDO();
                ConvertUserToUserBDO(u,userBDO);
                userBDOList.Add(userBDO);
            }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return userBDOList;
        }

        private void ConvertUserToUserBDO(User user, UserBDO userBDO) {
            UserTypeBDO ut = new UserTypeBDO();
            ut.UserTypeCode = user.UserTypeCode;

            userBDO.UserId = user.UserId;
            userBDO.FirstName = user.FirstName;
            userBDO.LastName = user.LastName;
            userBDO.MiddleName = user.MiddleName;
            userBDO.UserName = user.UserName;
            userBDO.Password = user.Password;
            userBDO.Deactivated = user.Deactivated;
            userBDO.UserType = ut;

        }
        public Boolean CreateUser(ref UserBDO userBDO, ref string message) {
            message = "User Added Successfully";
            bool ret = true;

             UserType ut = new UserType()
                {
                    UserType1 = userBDO.UserType.UsersType,
                    UserTypeCode = userBDO.UserType.UserTypeCode
                };
             User u = new User()
                {
                   
                    UserName = userBDO.UserName,
                    Password = userBDO.Password,
                    LastName = userBDO.LastName,
                    FirstName = userBDO.FirstName,
                    MiddleName = userBDO.MiddleName,
                    UserTypeCode = userBDO.UserType.UserTypeCode,
                    UserType = ut
                };
            try { 
              using (var DCEnt = new DCFIEntities()) {
                    DCEnt.Users.Attach(u);
                    DCEnt.Entry(u).State = System.Data.Entity.EntityState.Added;
                    int num = DCEnt.SaveChanges();
                    userBDO.UserId = u.UserId;

                    if (num != 1) {
                        ret = false;
                        message = "Adding of User failed"; 
                    }
            }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return ret;
        }

        public Boolean UpdateUser(ref UserBDO userBDO, ref string message) {
            message = "User updated successfully.";
            Boolean ret = true;
            try { 
            using (var DCEnt = new DCFIEntities()) {
                var userID = userBDO.UserId;
                User userInDB = (from u in DCEnt.Users
                                 where u.UserId == userID
                                 select u).FirstOrDefault();
                if (userInDB == null)
                {
                    throw new Exception("No user with ID " + userBDO.UserId);
                }
                DCEnt.Users.Remove(userInDB);
                UserType ut = new UserType();
                ut.UserTypeCode = userBDO.UserType.UserTypeCode;
                ut.UserType1 = userBDO.UserType.UsersType;

                userInDB.LastName = userBDO.LastName;
                userInDB.FirstName = userBDO.FirstName;
                userInDB.MiddleName = userBDO.MiddleName;
                userInDB.UserName = userBDO.UserName;
                userInDB.Password = userBDO.Password;
                userInDB.Deactivated = userBDO.Deactivated;
                userInDB.UserTypeCode = ut.UserTypeCode;

                DCEnt.Users.Attach(userInDB);
                DCEnt.Entry(userInDB).State = System.Data.Entity.EntityState.Modified;
                int num = DCEnt.SaveChanges();

                if (num != 1) {
                    ret = false;
                    message = "No user is updated."; 
                }
            }
        }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
}
            }
            return ret;

        }

        public Boolean DeactivateUser(int userId, ref string message) {
            message = "User deactivated successfully.";
            Boolean ret = true;
            try { 
            using (var DCEnt = new DCFIEntities())
            {
               User userInDB = (from u in DCEnt.Users
                                 where u.UserId == userId
                                 select u).FirstOrDefault();

                if (userInDB == null)
                {
                    throw new Exception("No user with ID " + userId);
                }

                DCEnt.Users.Remove(userInDB);

                userInDB.Deactivated = true;

                DCEnt.Users.Attach(userInDB);
                DCEnt.Entry(userInDB).State = System.Data.Entity.EntityState.Modified;
                int num = DCEnt.SaveChanges();
                if (num != 1)
                {
                    ret = false;
                    message = "Deactivation Failed.";
                }
            }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return ret;

        }


        public Boolean ActivateUser(int userId, ref string message)
        {
            message = "User Activated successfully.";
            Boolean ret = true;
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                User userInDB = (from u in DCEnt.Users
                                 where u.UserId == userId
                                 select u).FirstOrDefault();

                if (userInDB == null)
                {
                    throw new Exception("No user with ID " + userId);
                }

                DCEnt.Users.Remove(userInDB);

                userInDB.Deactivated = false;

                DCEnt.Users.Attach(userInDB);
                DCEnt.Entry(userInDB).State = System.Data.Entity.EntityState.Modified;
                int num = DCEnt.SaveChanges();
                if (num != 1)
                {
                    ret = false;
                    message = "Activation Failed.";
                }
            }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return ret;

        }

        public Boolean DeleteUser(int userId, ref string message) {
            message = "User Deleted successfully.";
            Boolean ret = true;
            try{ 
            using (var DCEnt = new DCFIEntities())
            {
                User userInDB = (from u in DCEnt.Users
                                 where u.UserId == userId
                                 select u).FirstOrDefault();

                if (userInDB == null)
                {
                    throw new Exception("No user with ID " + userId);
                }

                DCEnt.Users.Remove(userInDB);
                DCEnt.Entry(userInDB).State = System.Data.Entity.EntityState.Deleted;
                int num = DCEnt.SaveChanges();
                if (num != 1)
                {
                    ret = false;
                    message = "Deletion of User Failed.";
                }
            }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return ret;
        }

        public List<UserTypeBDO> GetAllUserTypes()
        {
            List<UserType> userTypeList = new List<UserType>();
            List<UserTypeBDO> userTypeBDOList = new List<UserTypeBDO>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                var allUserTypes = (DCEnt.UserTypes);
                userTypeList = allUserTypes.ToList<UserType>();
            }

          
            foreach (UserType u in userTypeList)
            {
                UserTypeBDO userTypeBDO = new UserTypeBDO();
                ConvertUserTypeToUserTypeBDO(u, userTypeBDO);
                userTypeBDOList.Add(userTypeBDO);
            }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return userTypeBDOList;
        }

        private void ConvertUserTypeToUserTypeBDO(UserType u, UserTypeBDO userTypeBDO) {
            userTypeBDO.UserTypeCode = u.UserTypeCode;
            userTypeBDO.UsersType = u.UserType1;
                
        }
    }
}

