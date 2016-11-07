using eSARServices;
using eSARServiceInterface;
using eSARServiceModels;
using eSAR.Utility_Classes;
using Newtonsoft.Json;
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

namespace eSAR.Quarterly_Grading.Grading
{
    public partial class frmTraitsQuarterlyGrading : Telerik.WinControls.UI.RadForm
    {
        public int gradeSectionCode { get; set; }
        public string sy { get; set; }
        public string teacherName { get; set; }
        public string teacherId { get; set; }
        public string section { get; set; }
        public string gradeLevel { get; set; }
        List<StudentTrait> classList = new List<StudentTrait>();

        Teacher teacher = new Teacher();
        public Teacher teach
        {
            get { return teacher; }
            set { teacher = value; }
        }


        public frmTraitsQuarterlyGrading()
        {
            InitializeComponent();
        }

        private void frmTraitsQuarterlyGrading_Load(object sender, EventArgs e)
        {

            if (GlobalClass.user.UserType == "teach")
                btnUnlock.Hide();

            sy = GlobalClass.currentsy;

            txtSy.Text = sy;
            txtTeacherId.Text = teacherId;
            txtTeacherName.Text = teacherName;

            txtGradeLevel.Text = gradeLevel;
            txtSection.Text = section;

            IGradingService gradingService = new GradingService();

            classList = new List<StudentTrait>(gradingService.GetAdvisees(gradeSectionCode));
            gvTraitsGrades.DataSource = classList;

            GroupDescriptor descriptor5 = new GroupDescriptor();
            descriptor5.GroupNames.Add("StudentName", ListSortDirection.Ascending);
            this.gvTraitsGrades.GroupDescriptors.Add(descriptor5);

            gvTraitsGrades.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbQuarter_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            int selectedIndex = cmbQuarter.SelectedIndex;

            if (classList.Count > 0)
            {
                bool lockedfirst = (bool?)classList[0].LockFirst ?? false;
                bool lockedsec = (bool?)classList[0].LockSecond ?? false;
                bool lockedthird = (bool?)classList[0].LockThird ?? false;
                bool lockedfourth = (bool?)classList[0].LockFourth ?? false;
                switch (selectedIndex)
                {

                    case 1:
                        if (lockedfirst == true)
                            gvTraitsGrades.Columns["FirstPeriodicRating"].ReadOnly = true;
                        else
                            gvTraitsGrades.Columns["FirstPeriodicRating"].ReadOnly = false;

                        gvTraitsGrades.Columns["FirstPeriodicRating"].IsVisible = true;
                        gvTraitsGrades.Columns["FirstPeriodicRating"].Width = 100;
                        gvTraitsGrades.Columns["SecondPeriodicRating"].IsVisible = false;
                        gvTraitsGrades.Columns["ThirdPeriodicRating"].IsVisible = false;
                        gvTraitsGrades.Columns["FourthPeriodicRating"].IsVisible = false;
                        gvTraitsGrades.Columns["FinalRating"].IsVisible = false;

                        break;
                    case 2:
                        gvTraitsGrades.Columns["FirstPeriodicRating"].IsVisible = false;

                        if (lockedsec == true)
                            gvTraitsGrades.Columns["SecondPeriodicRating"].ReadOnly = true;
                        else
                            gvTraitsGrades.Columns["SecondPeriodicRating"].ReadOnly = false;

                        gvTraitsGrades.Columns["SecondPeriodicRating"].IsVisible = true;
                        gvTraitsGrades.Columns["SecondPeriodicRating"].Width = 100;
                        gvTraitsGrades.Columns["ThirdPeriodicRating"].IsVisible = false;
                        gvTraitsGrades.Columns["FourthPeriodicRating"].IsVisible = false;
                        gvTraitsGrades.Columns["FinalRating"].IsVisible = false;
                        break;
                    case 3:
                        gvTraitsGrades.Columns["FirstPeriodicRating"].IsVisible = false;
                        gvTraitsGrades.Columns["SecondPeriodicRating"].IsVisible = false;

                        if (lockedthird == true)
                            gvTraitsGrades.Columns["ThirdPeriodicRating"].ReadOnly = true;
                        else
                            gvTraitsGrades.Columns["ThirdPeriodicRating"].ReadOnly = false;

                        gvTraitsGrades.Columns["ThirdPeriodicRating"].IsVisible = true;
                        gvTraitsGrades.Columns["ThirdPeriodicRating"].Width = 100;
                        gvTraitsGrades.Columns["FourthPeriodicRating"].IsVisible = false;
                        gvTraitsGrades.Columns["FinalRating"].IsVisible = false;


                        break;
                    case 4:
                        gvTraitsGrades.Columns["FirstPeriodicRating"].IsVisible = false;
                        gvTraitsGrades.Columns["SecondPeriodicRating"].IsVisible = false;
                        gvTraitsGrades.Columns["ThirdPeriodicRating"].IsVisible = false;

                        if (lockedfourth == true)
                            gvTraitsGrades.Columns["FourthPeriodicRating"].ReadOnly = true;
                        else
                            gvTraitsGrades.Columns["FourthPeriodicRating"].ReadOnly = false;

                        gvTraitsGrades.Columns["FourthPeriodicRating"].IsVisible = true;
                        gvTraitsGrades.Columns["FourthPeriodicRating"].Width = 100;
                        gvTraitsGrades.Columns["FinalRating"].IsVisible = true;


                        break;
                    case 5:
                        gvTraitsGrades.Columns["FirstPeriodicRating"].IsVisible = false;
                        gvTraitsGrades.Columns["SecondPeriodicRating"].IsVisible = false;
                        gvTraitsGrades.Columns["ThirdPeriodicRating"].IsVisible = false;
                        gvTraitsGrades.Columns["FourthPeriodicRating"].IsVisible = false;
                        gvTraitsGrades.Columns["FinalRating"].IsVisible = true;
                        gvTraitsGrades.Columns["FinalRating"].Width = 100;
                        gvTraitsGrades.Columns["FinalRating"].ReadOnly = true;

                        break;
                    case 0:
                        if (lockedfirst == true)
                            gvTraitsGrades.Columns["FirstPeriodicRating"].ReadOnly = true;
                        else
                            gvTraitsGrades.Columns["FirstPeriodicRating"].ReadOnly = false;
                        gvTraitsGrades.Columns["FirstPeriodicRating"].IsVisible = true;
                        gvTraitsGrades.Columns["FirstPeriodicRating"].Width = 50;

                        if (lockedsec == true)
                            gvTraitsGrades.Columns["SecondPeriodicRating"].ReadOnly = true;
                        else
                            gvTraitsGrades.Columns["SecondPeriodicRating"].ReadOnly = false;
                        gvTraitsGrades.Columns["SecondPeriodicRating"].IsVisible = true;
                        gvTraitsGrades.Columns["SecondPeriodicRating"].Width = 50;
                        if (lockedthird == true)
                            gvTraitsGrades.Columns["ThirdPeriodicRating"].ReadOnly = true;
                        else
                            gvTraitsGrades.Columns["ThirdPeriodicRating"].ReadOnly = false;

                        gvTraitsGrades.Columns["ThirdPeriodicRating"].IsVisible = true;
                        gvTraitsGrades.Columns["ThirdPeriodicRating"].Width = 50;

                        if (lockedfourth == true)
                            gvTraitsGrades.Columns["FourthPeriodicRating"].ReadOnly = true;
                        else
                            gvTraitsGrades.Columns["FourthPeriodicRating"].ReadOnly = false;

                        gvTraitsGrades.Columns["FourthPeriodicRating"].IsVisible = true;
                        gvTraitsGrades.Columns["FourthPeriodicRating"].Width = 50;
                        gvTraitsGrades.Columns["FinalRating"].IsVisible = true;
                        gvTraitsGrades.Columns["FinalRating"].Width = 100;
                        break;

                }
            }
            gvTraitsGrades.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            IGradingService gradingService = new GradingService();
            if (gradingService.SaveTraitsGrade(classList))
            {
                foreach (StudentTrait ss in classList)
                    Log("U", "StudentTraits", ss);

                MessageBox.Show("Grades Saved Successfully");
                this.Close();

            }
            else
            {
                MessageBox.Show("Failed Saving Grades");

            }
        }

        private void Log(string clud, string table, Object obj)
        {
            ILogService logService = new LogService();
            string json = JsonConvert.SerializeObject(obj);
            Log log = new Log
            {
                CLUD = clud,
                LogDate = DateTime.Now,
                TableName = table,
                UserId = GlobalClass.user.UserId,
                UserName = GlobalClass.user.UserName,
                PassedData = json
            };
            logService.AddLogs(log);
        }

        private void gvTraitsGrades_CellValueChanged(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.Column.Name == "FirstPeriodicRating")
            {
                classList[index].FirstPeriodicRating = (Double)(e.Row.Cells["FirstPeriodicRating"].Value);
                classList[index].FirstEntered = DateTime.Now;

            }
            else if (e.Column.Name == "SecondPeriodicRating")
            {
                classList[index].SecondPeriodicRating = (Double)(e.Row.Cells["SecondPeriodicRating"].Value);
                classList[index].SecondEntered = DateTime.Now;

            }
            else if (e.Column.Name == "ThirdPeriodicRating")
            {
                classList[index].ThirdPeriodicRating = (Double)(e.Row.Cells["ThirdPeriodicRating"].Value);
                classList[index].ThirdEntered = DateTime.Now;

            }
            else if (e.Column.Name == "FourthPeriodicRating")
            {
                classList[index].FourthPeriodicRating = (Double)(e.Row.Cells["FourthPeriodicRating"].Value);
                classList[index].FourthEntered = DateTime.Now;
                classList[index].FinalRating = (Double)(e.Row.Cells["FourthPeriodicRating"].Value);


            }

        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            foreach (StudentTrait ss in classList)
            {
                if (ss.FirstPeriodicRating > 0 && ss.FirstEntered.HasValue && ss.LockFirst == false && !ss.FirstLocked.HasValue)
                {
                    ss.FirstLocked = DateTime.Now;
                    ss.LockFirst = true;
                }
                if (ss.SecondPeriodicRating > 0 && ss.SecondEntered.HasValue && ss.LockSecond == false && !ss.SecondLocked.HasValue)
                {
                    ss.SecondLocked = DateTime.Now;
                    ss.LockSecond = true;
                }
                if (ss.ThirdPeriodicRating > 0 && ss.ThirdEntered.HasValue && ss.LockThird == false && !ss.ThirdLocked.HasValue)
                {
                    ss.ThirdLocked = DateTime.Now;
                    ss.LockThird = true;
                }
                if (ss.FourthPeriodicRating > 0 && ss.FourthEntered.HasValue && ss.LockFourth == false && !ss.FourthLocked.HasValue)
                {
                    ss.FourthLocked = DateTime.Now;
                    ss.LockFourth = true;
                }
            }
            IGradingService gradingService = new GradingService();
            if (gradingService.SaveTraitsGrade(classList))
            {
                foreach (StudentTrait ss in classList)
                    Log("U", "StudentSubjects", ss);


                MessageBox.Show("Grades Locked Successfully");
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed Locking Grades");

            }
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            gvTraitsGrades.Columns["FirstPeriodicRating"].ReadOnly = false;
            gvTraitsGrades.Columns["SecondPeriodicRating"].ReadOnly = false;
            gvTraitsGrades.Columns["ThirdPeriodicRating"].ReadOnly = false;
            gvTraitsGrades.Columns["FourthPeriodicRating"].ReadOnly = false;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            RadPrintDocument document = new RadPrintDocument();
            document.DefaultPageSettings.Landscape = true;
            document.HeaderHeight = 60;
            document.HeaderFont = new Font("Arial", 10, FontStyle.Bold);
            document.MiddleHeader = "Dansalan College Foundation, Inc. \r\n Marinaut, Marawi City, Lanao del Sur";
            document.MiddleFooter = "Page [Page #] of [Total Pages]";
            document.AssociatedObject = this.gvTraitsGrades;
            radPrintDocument1 = document;

            RadPrintPreviewDialog dialog = new RadPrintPreviewDialog();
            dialog.Document = this.radPrintDocument1;
            dialog.ShowDialog();
        }
    }
}
