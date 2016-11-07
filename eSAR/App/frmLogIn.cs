using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Security.Cryptography;
using eSAR.Utility_Classes;
using Newtonsoft.Json;
using eSARServices;
using eSARServiceInterface;
using eSARServiceModels;

namespace eSAR.App
{
    public partial class frmLogIn : Telerik.WinControls.UI.RadForm
    {

        public frmLogIn()
        {
            InitializeComponent();
        }

        private void butLogin_Click(object sender, EventArgs e)
        {
            try {
                IUserService userService = new UserService();
                string message = String.Empty;
                if (txtPassword.Text.Equals("Enter Password") || txtPassword.Text.Equals(String.Empty) || txtUsername.Text.Equals("Enter Username") || txtUsername.Text.Equals(String.Empty))
                {
                    MessageBox.Show(this, "Username and Password is Required", "Required Fields");
                }
                else
                {
                    if (userService.AuthenticateUser(txtUsername.Text, txtPassword.Text, ref message))
                    {
                        User u = new User();
                        u = userService.GetUser(txtUsername.Text);
                        LoggedUser lu = new LoggedUser();

                        lu.UserId = u.UserId;
                        lu.UserName = u.UserName;
                        lu.LastName = u.LastName;
                        lu.FirstName = u.FirstName;
                        lu.MiddleName = u.MiddleName;
                        lu.UserType = u.UserTypeCode;

                        GlobalClass.UserLoggedIn = true;
                        GlobalClass.user = lu;
                        GlobalClass.currentsy = userService.GetCurrentSy();
                        GlobalClass.userTypeCode = lu.UserType;

                        ILogService logService = new LogService();
                        string json = JsonConvert.SerializeObject(lu);
                        Log log = new Log
                        {
                            CLUD = "L",
                            LogDate = DateTime.Now,
                            TableName = "Users",
                            UserId = GlobalClass.user.UserId,
                            UserName = GlobalClass.user.UserName,
                            PassedData = json
                        };
                        logService.AddLogs(log);
                        Close();
                    }
                    else MessageBox.Show(this, message, "Login Failed");
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Unable to Establish the network connection. Please check if network is connected.", "LogIn Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
    }
            
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Close();
            Application.Exit();
        }

        private void frmLogIn_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Escape)
            //{
            //    this.Close();
            //}
        }
    }
}
