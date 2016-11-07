using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using eSAR.Utility_Classes;

namespace eSAR.Reports.GenerateSchedule
{
    public partial class ScheduleDetails : Telerik.WinControls.UI.RadForm
    {

        
        public ScheduleDetails()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void LoadMe(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            GlobalClass.WindowScheduleDetails = false;
        }

        private void btnSaveScholarshipDiscount_Click(object sender, EventArgs e)
        {

        }
    }
}
