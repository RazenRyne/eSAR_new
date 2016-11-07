using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using eSAR.Reports.GeneratePromotional;
using eSARServices;
using eSARServiceInterface;
using eSARServiceModels;

namespace eSAR.Reports.GenerateGradingSheets
{
    public partial class frmGradingSheetInput : Telerik.WinControls.UI.RadForm
    {

         List<GradeSection> sections;
        GradeSection gradeSection = new GradeSection();
         List<GradeLevel> gradeLevels;
        List<SchoolYear> schoolYear;
        Teacher teach = new Teacher();
        IGradeSectionService gsService = new GradeSectionService();
        string _report = string.Empty;

        public frmGradingSheetInput()
        {
            InitializeComponent();

            InitializeLists();
        }

        public void setVars (string report)
        {
            _report = report;
        }

        private void InitializeLists()
        {
            gradeLevels = new List<GradeLevel>(gsService.GetAllGradeLevels ());
            gradeLevels.RemoveAll(x => x.GradeLev == "0");
            schoolYear = new List<SchoolYear>(gsService.GetAllSchoolYears());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGradingSheetInput_Load(object sender, EventArgs e)
        {
            cmbGradeLevel.DataSource = gradeLevels;
            cmbGradeLevel.SelectedIndex = 0;
            cmbSY.DataSource = schoolYear;
            cmbSY.SelectedIndex = 0;
            if (_report == "Promotional")
            {
                lblType.Visible = false;
                cmbReportType.Visible = false;
            }

           
        }

        private void cmbSection_SelectedValueChanged(object sender, EventArgs e)
        {
            string msg = string.Empty;
            if (gradeSection != null)
                teach = gsService.GetTeacherDetail(gradeSection.HomeRoomTeacherId, ref msg);
        }

        private void cmbGradeLevel_SelectedValueChanged(object sender, EventArgs e)
        {
            string msg = string.Empty;
            if (cmbGradeLevel.SelectedIndex != -1)
            {
                sections = new List<GradeSection>(gsService.GetAllSectionsForGrade(cmbGradeLevel.SelectedValue.ToString()));
                cmbSection.DataSource = sections;
                cmbSection.SelectedIndex = 0;

                gradeSection = sections.Find(x => x.GradeSectionCode == int.Parse(cmbSection.SelectedValue.ToString()));

                if (gradeSection != null)
                    teach = gsService.GetTeacherDetail(gradeSection.HomeRoomTeacherId, ref msg);
            }

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string teacherName = string.Empty;
            if (cmbSection.SelectedIndex == -1)
                return;

            if (teach != null)
            {
                teacherName = teach.LastName + ", " + teach.FirstName + " ";
                if (teach.MiddleName != string.Empty || teach.MiddleName == " ")
                {
                    teacherName = teacherName + " " + teach.MiddleName.Substring(0, 1) + ".";
                }
            }

            GradeLevel glSelected = new GradeLevel();
            glSelected = gradeLevels.Find(x => x.GradeLev == cmbGradeLevel.SelectedValue.ToString());
            string category = string.Empty;

            switch (glSelected.Category)
            {
                case 1:
                    category = "Primary";
                    break;
                case 2:
                    category = "Secondary";
                    break;
                case 3:
                    category = "Tertiary";
                    break;
                case 4:
                    category = "College";
                    break;
                default:
                    category = "";
                    break;
            }


            string gradeLevelSection = cmbGradeLevel.Text + " - " + cmbSection.Text;

            if (cmbGradeLevel.Text != string.Empty || cmbSection.Text != string.Empty
                || cmbSY.Text != string.Empty)
            {
                if (_report == "Grading Sheet")
                {
                    if (cmbReportType.Text == "Subjects")
                    {
                        frmGradingSheetTemplate1 fmGradingSheet = new frmGradingSheetTemplate1();
                        fmGradingSheet.setVars(cmbSY.Text, cmbGradeLevel.SelectedValue.ToString(), cmbSection.SelectedValue.ToString(), teacherName, gradeLevelSection, txtSection.Text);
                        fmGradingSheet.ShowDialog();
                    }

                    if (cmbReportType.Text == "Traits")
                    {
                        frmGradingSheetTrait1 fmGradingSheet = new frmGradingSheetTrait1();
                        fmGradingSheet.setVars(cmbSY.Text, cmbGradeLevel.SelectedValue.ToString(), cmbSection.SelectedValue.ToString(), teacherName, gradeLevelSection, txtSection.Text, glSelected.Category);
                        fmGradingSheet.ShowDialog();
                    }
                }

                if (_report == "Promotional")
                {
                    PromotionalTemplate1 pm1 = new PromotionalTemplate1();
                    pm1.setVars(cmbSY.Text, cmbGradeLevel.SelectedValue.ToString(), cmbSection.SelectedValue.ToString(),cmbSection.Text, teacherName, category, txtSection.Text);
                    pm1.Show();
                }
            }
        }
    }
}
