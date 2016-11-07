using eSARServices;
using eSARServiceInterface;
using eSARServiceModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace eSAR.Reports.GenerateProspectus
{
    public partial class ProspectusList : Telerik.WinControls.UI.RadForm
    {
        string zSY;
        string zGradeLevel;
        List<Subject> subj = new List<Subject>();

        public ProspectusList()
        {
            InitializeComponent();
        }

        public void setVars(string szSY, string szGradeLevel)
        {
            zSY = szSY;
            zGradeLevel = szGradeLevel;
        }

        private void ProspectusList_Load(object sender, EventArgs e)
        {
            ISubjectService ssR = new SubjectService();
            if (zGradeLevel == "0")
                subj = new List<Subject>(ssR.GetAllSubjects());
            else
                subj = new List<Subject>(ssR.GetAllSubjectsOfGradeLevel(zGradeLevel));

            gridView.DataSource = subj;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            RadPrintDocument document = new RadPrintDocument();
            document.DefaultPageSettings.Landscape = false;
            document.HeaderHeight = 60;
            document.HeaderFont = new Font("Arial", 10, FontStyle.Bold);
            document.MiddleHeader = "Dansalan College Foundation, Inc. \r\n Marinaut, Marawi City, Lanao del Sur";
            document.MiddleFooter = "Page [Page #] of [Total Pages]";
            document.AssociatedObject = this.gridView;
            radPrintDocument1 = document;

            RadPrintPreviewDialog dialog = new RadPrintPreviewDialog();
            dialog.Document = this.radPrintDocument1;
            dialog.ShowDialog();
        }
    }
}
