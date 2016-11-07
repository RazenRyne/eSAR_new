using eSARServiceInterface;
using eSARServiceModels;
using eSARServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace eSAR.Reports.GenerateStudentPermanentRecord
{
    public partial class frmReportDetailsPR : Telerik.WinControls.UI.RadForm
    {
        List<GradeLevel> gradeLevels;
        IGradeSectionService gsService = new GradeSectionService();
        string studentID = string.Empty;

        public frmReportDetailsPR()
        {
            InitializeComponent();

            InitializeLists();
        }

        public void setVars(string _studentID)
        {
            studentID = _studentID;
        }

        private void InitializeLists()
        {
            gradeLevels = new List<GradeLevel>(gsService.GetAllGradeLevels());
            gradeLevels.RemoveAll(x => x.GradeLev == "0");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReportDetailsPR_Load(object sender, EventArgs e)
        {
            cmbGradeLevel.DataSource = gradeLevels;
            cmbGradeLevel.SelectedIndex = 0;
        }
    }
}
