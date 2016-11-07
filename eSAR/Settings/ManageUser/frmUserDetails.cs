using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Security.Cryptography;
using System.Linq;
using Newtonsoft.Json;
using eSAR.Utility_Classes;
using eSARServices;
using eSARServiceInterface;
using eSARServiceModels;

namespace eSAR.Settings.ManageUser
{
   

    public partial class frmUserDetails : Telerik.WinControls.UI.RadForm
    {

        public string Op { get; set; }
        public User SelectedUser { get; set; }

        public List<User> userList { get; set;  }

        private string oldPassword = string.Empty;
      

        public frmUserDetails()
        {
            InitializeComponent();
        }   

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmUserDetails_Load(object sender, EventArgs e)
        {
            if (Op.Equals("edit"))
            {
                lblOldAst.Visible = true;
                lblOldPWD.Visible = true;
                txtOldPWD.Visible = true;
                lblUserAst.Visible = false;
                lblPWDast.Visible = false;
                lblReAst.Visible = false;
                lblPWD.Text = "New Password:";
                lblRetypePWD.Text = "Re-Type New Password:";
                txtUsername.Enabled = false;
                txtFirstName.Text = SelectedUser.FirstName;
                txtLastName.Text = SelectedUser.LastName;
                txtMiddleName.Text = SelectedUser.MiddleName;
                txtUsername.Text = SelectedUser.UserName;
                oldPassword = SelectedUser.Password;
                loadUserTypes();
                cmbUserRole.SelectedValue = SelectedUser.UserTypeCode;
            }
            else
                loadUserTypes();
                
        }

        private void loadUserTypes()
        {
            IUserService userService = new UserService();
            cmbUserRole.DataSource = userService.GetAllUserTypes();
            cmbUserRole.DisplayMember = "UsersType";
            cmbUserRole.ValueMember = "UserTypeCode";

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (bPass(txtPassword.Text) == false)
            {
                MessageBox.Show("Password should consist of Numbers (0-9), lower case letters (a-z), and UPPER CASE LETTERS (A-Z)", "Password Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (Op.Equals("edit"))
            {
                if (String.IsNullOrEmpty(txtUsername.Text) || String.IsNullOrEmpty(txtFirstName.Text)
                    || String.IsNullOrEmpty(txtLastName.Text) || String.IsNullOrEmpty(txtOldPWD.Text))
                {
                    MessageBox.Show("Please fill up all important(*) fields");
                    return;
                }
                else
                {
                   SaveUser();
                }
            }
            else
            {
                if (String.IsNullOrEmpty(txtUsername.Text) || String.IsNullOrEmpty(txtFirstName.Text)
                || String.IsNullOrEmpty(txtLastName.Text) || String.IsNullOrEmpty(txtPassword.Text)
                || String.IsNullOrEmpty(txtRetypePWD.Text))
                {
                    MessageBox.Show("Please fill up all important(*) fields");
                    return;
                }
                else
                    SaveUser();
            }
                
        }

        private bool bPass(string passwordText)
        {
            bool result =
               passwordText.Any(c => char.IsUpper(c)) &&
               passwordText.Any(c => char.IsLower(c)) &&
               passwordText.Any(c => char.IsDigit(c));
            return result;
        }

        private void SaveUser()
        {
            try
            {
                Boolean ret = false;
                string message = String.Empty;
                

                if (Op.Equals("edit"))
                {
                    if (!ComparePasswords(oldPassword, txtOldPWD.Text))
                    {
                        message = "Passwords do not match";
                        MessageBox.Show("Incorrect old password entered", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (!txtPassword.Text.ToString().Equals(txtRetypePWD.Text.ToString()))
                {
                    message = "Passwords did not match";
                    MessageBox.Show("Password did not match");
                    return;
                }
                else
                {
                    string hashPWD = GenerateKeyHash(txtPassword.Text);

                    IUserService userService = new UserService();
                    User user = new User()
                    {
                        UserName = txtUsername.Text,
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        MiddleName = txtMiddleName.Text,
                        Password = hashPWD,
                        UserTypeCode = cmbUserRole.SelectedValue.ToString()
                    };

                    if (Op.Equals("edit"))
                    {
                        user.UserId = SelectedUser.UserId;
                        if (!String.IsNullOrEmpty(txtPassword.Text))
                            user.Password = hashPWD;
                        else
                            user.Password = oldPassword;

                        ret = userService.UpdateUser(ref user, ref message);
                        Log("U", "Users", user);
                    }
                    else
                    {
                        ret = userService.CreateUser(ref user, ref message);
                        Log("C", "Users", user);
                    }
                }


                MessageBox.Show("Saved Successfully!");

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }


        //pwd

        public static string GenerateKeyHash(string Password)
        {
            if (string.IsNullOrEmpty(Password)) return null;
            if (Password.Length < 1) return null;

            byte[] salt = new byte[20];
            byte[] key = new byte[20];
            byte[] ret = new byte[40];

            try
            {
                using (RNGCryptoServiceProvider randomBytes = new RNGCryptoServiceProvider())
                {
                    randomBytes.GetBytes(salt);

                    using (var hashBytes = new Rfc2898DeriveBytes(Password, salt, 10000))
                    {
                        key = hashBytes.GetBytes(20);
                        Buffer.BlockCopy(salt, 0, ret, 0, 20);
                        Buffer.BlockCopy(key, 0, ret, 20, 20);
                    }
                }
                // returns salt/key pair
                return Convert.ToBase64String(ret);
            }
            finally
            {
                if (salt != null)
                    Array.Clear(salt, 0, salt.Length);
                if (key != null)
                    Array.Clear(key, 0, key.Length);
                if (ret != null)
                    Array.Clear(ret, 0, ret.Length);
            }
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

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPassword.Text))
            {
                lblPWDast.Visible = true;
                lblReAst.Visible = true;
            }
            else
            {
                lblPWDast.Visible = false;
                lblReAst.Visible = false;
            }
        }

        private void txtRetypePWD_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtRetypePWD.Text))
            {
                lblPWDast.Visible = true;
                lblReAst.Visible = true;
            }
            else
            {
                lblPWDast.Visible = false;
                lblReAst.Visible = false;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (!Op.Equals("Edit"))
            {            
                if (userList.Exists(x => x.UserName == txtUsername.Text))
                {
                    MessageBox.Show("UserName already exists");
                    txtUsername.Text = "";
                    txtUsername.Focus();
                }
            }
        }
        private void Log(string clud, string table, Object obj)
        {
           ILogService logService = new LogService();
            string json = JsonConvert.SerializeObject(obj);
            Log log = new Log
            {
                CLUD = clud,
                LogDate = DateTime.Now,
                TableName = table,
                UserId = GlobalClass.user.UserId,
                UserName = GlobalClass.user.UserName,
                PassedData = json
            };
            logService.AddLogs(log);
        }
    }
}
