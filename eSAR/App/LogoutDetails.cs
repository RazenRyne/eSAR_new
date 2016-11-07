using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using eSAR.Utility_Classes;

namespace eSAR.App
{
    public partial class LogoutDetails : Telerik.WinControls.UI.RadForm
    {

        
        public LogoutDetails()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }


        private void btnYes_Click(object sender, EventArgs e)
        {
            Application.Restart();
            
            //GlobalClass.currentsy = null;
            //GlobalClass.fromScreen = null;
            //GlobalClass.gvDatasource = null;
            //GlobalClass.receiptCurrent = null;
            //GlobalClass.receiptFrom = null;
            //GlobalClass.receiptTo = null;
            //GlobalClass.selectedSY = null;
            //GlobalClass.user = null;
            //GlobalClass.UserLoggedIn = false;
            //GlobalClass.WindowAttendanceDetails = false;
            //GlobalClass.WindowBillingDetails = false;
            //GlobalClass.WindowPaymentDetails = false;
            //GlobalClass.WindowPromotionalDetails = false;
            //GlobalClass.WindowProspectusDetails = false;
            //GlobalClass.WindowReligionDetails = false;
            //GlobalClass.WindowScheduleDetails = false;
            //GlobalClass.WindowStatusManageReceipt = false;
            //GlobalClass.WindowStatusPaymentDetails = false;
            //GlobalClass.WindowStudentListDetails = false;
            //GlobalClass.WindowTeachersLoadDetails = false;
            //GlobalClass.WindowLogoutDetails = false;

            //this.Close();
            
            frmLogIn FrmLogin = new frmLogIn();
            FrmLogin.ShowDialog();


        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
            GlobalClass.WindowLogoutDetails = false;
        }
    }
}
