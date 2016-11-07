using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using eSARServices;
using eSARServiceInterface;
using eSARServiceModels;
using eSAR.Utility_Classes;
using Newtonsoft.Json;

namespace eSAR.Settings.ManageUser
{
    public partial class frmUserList : Telerik.WinControls.UI.RadForm
    {
        private User userSelected;
        private List<User> userList;

        public frmUserList()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmUserDetails fmUserDetails = new frmUserDetails();
            fmUserDetails.Op = "add";
            fmUserDetails.userList = this.userList;
            fmUserDetails.ShowDialog(this);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gvUser.CurrentRow.Index >= 0)
            {
                frmUserDetails fmUserDetails = new frmUserDetails();
                fmUserDetails.Op = "edit";
                fmUserDetails.SelectedUser = userSelected;
                fmUserDetails.ShowDialog(this);
            }
        }

        private void frmUserList_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void frmUserList_Activated(object sender, EventArgs e)
        {
            LoadUsers();
        }

        public void LoadUsers() {
            IUserService userService = new UserService();
            string message = String.Empty;
            try
            {
                var users = userService.GetAllUsers();
                userList = new List<User>(users);
                gvUser.DataSource = users;
                gvUser.Refresh();

                if (gvUser.RowCount != 0)
                    gvUser.Rows[0].IsSelected = true;
            }
            catch (Exception ex)
            {
                message = "Error Loading UserList";
                MessageBox.Show(ex.ToString());
            }

        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (userSelected != null)
            {
                IUserService userService = new UserService();
                string message = String.Empty;

                if (!userService.DeleteUser(userSelected.UserId, ref message))
                {

                    MessageBox.Show("Deletion of User Failed");
                }
                else
                {
                    userSelected.Deactivated = true;
                    Log("D", "Users", userSelected);
                    MessageBox.Show("Deleted succesfully!");
                }
            }
        }

        private void gvUser_SelectionChanged(object sender, EventArgs e)
        {
            int selectedIndex =  gvUser.CurrentRow.Index;
            

            if (selectedIndex >= 0)
            {
                string uID = gvUser.Rows[selectedIndex].Cells["UserId"].Value.ToString();
                List<User> item = new List<User>();
                item = userList.FindAll(x => x.UserId.ToString() == uID);

                userSelected = new User();
                userSelected = (User)item[0];                
           
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
