using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using eSAR.Utility_Classes;
using eSARServices;
using eSARServiceInterface;
using eSARServiceModels;

namespace eSAR.Reports.GenerateProspectus
{
    public partial class ProspectusDetails : Telerik.WinControls.UI.RadForm
    {
        public List<SchoolYear> schoolYears;
        public List<GradeLevel> gradeLevels;

        public ProspectusDetails()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void btnCancelScholarshipDiscount_Click(object sender, EventArgs e)
        {
            this.Close();
            GlobalClass.WindowProspectusDetails = false;
        }

        private void LoadMe(object sender, EventArgs e)
        {
            IFeeService feeService = new FeeService();
            gradeLevels = new List<GradeLevel>(feeService.GetAllGradeLevels());
            schoolYears = new List<SchoolYear>(feeService.GetLastFiveSY());

            cmbGradeLevel.DataSource = gradeLevels;
            cmbGradeLevel.ValueMember = "GradeLev";
            cmbGradeLevel.DisplayMember = "Description";

            cmbSY.DataSource = schoolYears;
            cmbSY.ValueMember = "SY";
            cmbSY.DisplayMember = "SY";


        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            ProspectusList plist = new ProspectusList();
            plist.setVars(cmbSY.SelectedValue.ToString(), cmbGradeLevel.SelectedValue.ToString());
            plist.Show();
        }
    }
}
