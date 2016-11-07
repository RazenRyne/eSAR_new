using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace eSAR.Reports.GenerateGradingSheets
{
    public partial class frmGradingSheetTemplate1 : Telerik.WinControls.UI.RadForm
    {
        string _sy = string.Empty;
        string _gradeLevel = string.Empty;
        string _sectionCode = string.Empty;
        string _teacher = string.Empty;
        string _gradeLevelSection = string.Empty;
        string _title = string.Empty;

        public frmGradingSheetTemplate1()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void setVars(string SY, string gradeLevel, string sectionCode, string teacher, string gradeLevelSection, string title)
        {
            _sy = SY;
            _gradeLevel = gradeLevel;
            _sectionCode = sectionCode;
            _teacher = teacher;
            _gradeLevelSection = gradeLevelSection;
            _title = title;
        }

        private void frmGradingSheetTemplate1_Load(object sender, EventArgs e)
        {
            reportViewer1.ReportSource.Parameters["SY"].Value = _sy;
            reportViewer1.ReportSource.Parameters["GradeLevel"].Value = _gradeLevel;
            reportViewer1.ReportSource.Parameters["SectionCode"].Value = _sectionCode;
            reportViewer1.ReportSource.Parameters["HomeroomTeacher"].Value = _teacher;
            reportViewer1.ReportSource.Parameters["GradeLevelSection"].Value = _gradeLevelSection;
            reportViewer1.ReportSource.Parameters["Title"].Value = _title;

            this.reportViewer1.RefreshReport();
        }
    }
}
