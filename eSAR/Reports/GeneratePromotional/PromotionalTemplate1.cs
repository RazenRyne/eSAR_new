using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace eSAR.Reports.GeneratePromotional
{
    public partial class PromotionalTemplate1 : Telerik.WinControls.UI.RadForm
    {
        string _sy = string.Empty;
        string _gradeLevel = string.Empty;
        string _sectionCode = string.Empty;
        string _section = string.Empty;
        string _teacher = string.Empty;
        string _category = string.Empty;
        string _title = string.Empty;


        public PromotionalTemplate1()
        {
            InitializeComponent();
        }

        public void setVars(string SY, string gradeLevel, string sectionCode, string section, string teacher, string category, string title)
        {
            _sy = SY;
            _gradeLevel = gradeLevel;
            _sectionCode = sectionCode;
            _section = section;
            _teacher = teacher;
            _category = category;
            _title = title;
        }

        private void PromotionalTemplate1_Load(object sender, EventArgs e)
        {
            reportViewer1.ReportSource.Parameters["SY"].Value = _sy;
            reportViewer1.ReportSource.Parameters["GradeLevel"].Value = _gradeLevel;
            reportViewer1.ReportSource.Parameters["SectionCode"].Value = _sectionCode;
            reportViewer1.ReportSource.Parameters["Section"].Value = _section;
            reportViewer1.ReportSource.Parameters["Category"].Value = _category;
            reportViewer1.ReportSource.Parameters["TeacherName"].Value = _teacher;
            reportViewer1.ReportSource.Parameters["Title"].Value = _title;

            this.reportViewer1.RefreshReport();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            this.reportViewer1.ExportReport("XLS", null);
        }
    }
}
