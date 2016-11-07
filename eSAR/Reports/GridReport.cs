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
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace eSAR.Reports
{
    public partial class GridReport : Telerik.WinControls.UI.RadForm
    {
        List<StudentEnrollment> stEnrolled;
        string groupedBy;
        string sY;

        public GridReport()
        {
            InitializeComponent();
        }

   

        public void setVars(string szGroupedBy, string szSY)
        {
            groupedBy = szGroupedBy;
            sY = szSY;
        }

        private void GridReport_Load(object sender, EventArgs e)
        {
            loadList();
        }

        private void loadList()
        {
            IRegistrationService regService = new RegistrationService();
            stEnrolled = new List<StudentEnrollment>(regService.GetCurrentStudents(sY));
            
            gridView.DataSource = stEnrolled;

            switch (groupedBy)
            {
                case "Religion":
                    GroupDescriptor descriptor2 = new GroupDescriptor();
                    descriptor2.GroupNames.Add("Religion", ListSortDirection.Ascending);
                    this.gridView.GroupDescriptors.Add(descriptor2);
                    break;
                case "Grade Level":
                    GroupDescriptor descriptor4 = new GroupDescriptor();
                    descriptor4.GroupNames.Add("GradeLevel", ListSortDirection.Ascending);
                    this.gridView.GroupDescriptors.Add(descriptor4);
                    break;
                case "Section":
                    GroupDescriptor descriptor5 = new GroupDescriptor();
                    descriptor5.GroupNames.Add("GradeLevel", ListSortDirection.Ascending);
                    GroupDescriptor descriptor6 = new GroupDescriptor();
                    descriptor6.GroupNames.Add("Section", ListSortDirection.Ascending);
                    this.gridView.GroupDescriptors.Add(descriptor5);
                    this.gridView.GroupDescriptors.Add(descriptor6);
                    break;
                case "Gender":
                    GroupDescriptor descriptor3 = new GroupDescriptor();
                    descriptor3.GroupNames.Add("Gender", ListSortDirection.Ascending);
                    this.gridView.GroupDescriptors.Add(descriptor3);
                    break;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            RadPrintDocument document = new RadPrintDocument();
            document.DefaultPageSettings.Landscape = true;
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
