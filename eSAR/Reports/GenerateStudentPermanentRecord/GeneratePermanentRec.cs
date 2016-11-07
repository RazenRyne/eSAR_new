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
    public partial class GeneratePermanentRec : Telerik.WinControls.UI.RadForm
    {
        public string _studentID { get; set; }

        public GeneratePermanentRec()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GeneratePermanentRec_Load(object sender, EventArgs e)
        {
            reportViewer1.ReportSource.Parameters["StudentID"].Value = _studentID;

            this.reportViewer1.RefreshReport();
        }
    }
}
