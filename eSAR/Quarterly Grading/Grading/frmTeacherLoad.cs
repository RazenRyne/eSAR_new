using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using eSAR.Utility_Classes;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;
using eSARServices;
using eSARServiceInterface;
using eSARServiceModels;

namespace eSAR.Quarterly_Grading.Grading
{
    public partial class frmTeacherLoad : Telerik.WinControls.UI.RadForm
    {

        private TeacherLoad subjectSelected = new TeacherLoad();


        Teacher Tcher = new Teacher();
        SubjectAssignment subject = new SubjectAssignment();
        public string sy;
        public Teacher teacher
        {
            get { return this.Tcher; }
            set { this.Tcher = value; }
        }

        public SubjectAssignment Sub
        {
            get { return this.subject; }
            set { this.subject = value; }
        }

        List<TeacherLoad> teacherLoad = new List<TeacherLoad>();

        public frmTeacherLoad()
        {

            InitializeComponent();
        }

        private void frmTeacherLoad_Load(object sender, EventArgs e)
        {
            IGradingService gradingService = new GradingService();
            sy = GlobalClass.currentsy;

            string fname = GlobalClass.user.FirstName;
            string lname = GlobalClass.user.LastName;
            string mname = GlobalClass.user.MiddleName;
            teacher = gradingService.GetTeacher(lname, mname, fname);



            LoadTeacherSubjects();
            GroupDescriptor descriptor5 = new GroupDescriptor();
            descriptor5.GroupNames.Add("TeacherName", ListSortDirection.Ascending);
            this.gvSubjects.GroupDescriptors.Add(descriptor5);
        }

        public void LoadTeacherSubjects()
        {
            IGradingService gradingService = new GradingService();
            String message = String.Empty;

            try
            {
                if (GlobalClass.userTypeCode == "admin" || GlobalClass.user.UserType == "reg" || GlobalClass.user.UserType == "princ")
                {
                    var load = gradingService.GetAllTeachersLoad(sy);
                    teacherLoad = new List<TeacherLoad>(load);
                    gvSubjects.DataSource = teacherLoad;

                }
                else if (GlobalClass.user.UserType == "teach")
                {
                    var load = gradingService.GetTeacherLoad(teacher.TeacherId, sy);
                    teacherLoad = new List<TeacherLoad>(load);
                    gvSubjects.DataSource = teacherLoad;
                }
                gvSubjects.Refresh();
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

        private void btnAddGrade_Click(object sender, EventArgs e)
        {
            if (gvSubjects.CurrentRow == null)
                return;

            frmQuarterlyGrading fmGrading = new frmQuarterlyGrading();
            fmGrading.selectedSubject = subjectSelected;
            fmGrading.teach = teacher;
            fmGrading.SubjectAssignments = subjectSelected.SubjectAssignments;
            fmGrading.sy = sy;
            
            fmGrading.ShowDialog();
        }


        private void gvSubjects_SelectionChanged(object sender, EventArgs e)
        {
            if (gvSubjects.CurrentRow != null)
            {
                if (gvSubjects.CurrentRow.Index != -1)
                {
                    subjectSelected.SubjectAssignments = gvSubjects.SelectedRows[0].Cells["SubjectAssignments"].Value.ToString();
                    subjectSelected.SubjectCode = gvSubjects.SelectedRows[0].Cells["SubjectCode"].Value.ToString();
                    subjectSelected.SubjectDescription = gvSubjects.SelectedRows[0].Cells["SubjectDescription"].Value.ToString();
                    subjectSelected.TimeslotInfo = gvSubjects.SelectedRows[0].Cells["TimeslotInfo"].Value.ToString();
                    teacher.TeacherId = gvSubjects.SelectedRows[0].Cells["TeacherId"].Value.ToString();
                    teacher.TeacherName = gvSubjects.SelectedRows[0].Cells["TeacherName"].Value.ToString();
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            RadPrintDocument document = new RadPrintDocument();
            document.DefaultPageSettings.Landscape = true;
            document.HeaderHeight = 60;
            document.HeaderFont = new Font("Arial", 10, FontStyle.Bold);
            document.MiddleHeader = "Dansalan College Foundation, Inc. \r\n Marinaut, Marawi City, Lanao del Sur";
            document.MiddleFooter = "Page [Page #] of [Total Pages]";
            document.AssociatedObject = this.gvSubjects;
            radPrintDocument1 = document;

            RadPrintPreviewDialog dialog = new RadPrintPreviewDialog();
            dialog.Document = this.radPrintDocument1;
            dialog.ShowDialog();
        }
    }
}