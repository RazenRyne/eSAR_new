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
using Telerik.WinControls.UI;

namespace eSAR.Quarterly_Grading.Grading
{
    public partial class frmAdvisersLoad : Telerik.WinControls.UI.RadForm
    {
        string sy = String.Empty;
        List<GradeSection> gradeSectionList;
        GradeSection gSectionSelected;
        Teacher teacher = new Teacher();
        public frmAdvisersLoad()
        {
            InitializeComponent();
        }

        public void LoadGradeSections()
        {
            String message = String.Empty;
            IGradeSectionService gService = new GradeSectionService();
            gradeSectionList = new List<GradeSection>(gService.GetAllGradeSections());
            try
            {
                if (GlobalClass.userTypeCode == "admin" || GlobalClass.user.UserType == "reg")
                {
                    gvGradeSection.DataSource = gradeSectionList;

                }
                else if (GlobalClass.user.UserType == "teach")
                {
                   var advisoryClass= gradeSectionList.FindAll(item => item.HomeRoomTeacherId == teacher.TeacherId);
                    gvGradeSection.DataSource = advisoryClass;
                    
                }
                gvGradeSection.Refresh();
            }
            catch (Exception ex)
            {
                message = "Error Loading Teachers Load";
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvGradeSection_SelectionChanged(object sender, EventArgs e)
        {
            int selectedIndex = -1;
            if (gvGradeSection.CurrentRow != null)
                selectedIndex = gvGradeSection.CurrentRow.Index;


            if (selectedIndex >= 0)
            {
                string gsCode = gvGradeSection.Rows[selectedIndex].Cells["GradeSectionCode"].Value.ToString();
                List<GradeSection> item = new List<GradeSection>();
                item = gradeSectionList.FindAll(x => x.GradeSectionCode.ToString() == gsCode);
                
                gSectionSelected = new GradeSection();
                gSectionSelected = (GradeSection)item[0];
            }
        }

        private void frmAdvisersLoad_Load(object sender, EventArgs e)
        {
            IGradeSectionService gService = new GradeSectionService();
            sy = GlobalClass.currentsy;

            string fname = GlobalClass.user.FirstName;
            string lname = GlobalClass.user.LastName;
            string mname = GlobalClass.user.MiddleName;
            teacher = new Teacher() {
                FirstName = fname
            };
           teacher = gService.GetTeacher(lname, mname, fname);
           LoadGradeSections();
        }

        private void btnAddGrades_Click(object sender, EventArgs e)
        {
            if (gvGradeSection.CurrentRow == null)
                return;
            
            frmTraitsQuarterlyGrading fmTraitsGrading = new frmTraitsQuarterlyGrading();
            fmTraitsGrading.gradeSectionCode = gSectionSelected.GradeSectionCode;
            fmTraitsGrading.sy = sy;
            fmTraitsGrading.gradeLevel = gSectionSelected.GradeLevel;
            fmTraitsGrading.section = gSectionSelected.Section;
            fmTraitsGrading.teacherId = gSectionSelected.HomeRoomTeacherId;
            fmTraitsGrading.teacherName = gSectionSelected.TeacherName;
            fmTraitsGrading.Show();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            RadPrintDocument document = new RadPrintDocument();
            document.DefaultPageSettings.Landscape = true;
            document.HeaderHeight = 60;
            document.HeaderFont = new Font("Arial", 10, FontStyle.Bold);
            document.MiddleHeader = "Dansalan College Foundation, Inc. \r\n Marinaut, Marawi City, Lanao del Sur";
            document.MiddleFooter = "Page [Page #] of [Total Pages]";
            document.AssociatedObject = this.gvGradeSection;
            radPrintDocument1 = document;

            RadPrintPreviewDialog dialog = new RadPrintPreviewDialog();
            dialog.Document = this.radPrintDocument1;
            dialog.ShowDialog();
        }
    }
}
