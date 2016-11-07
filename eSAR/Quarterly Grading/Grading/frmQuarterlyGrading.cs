using eSAR.Utility_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Newtonsoft.Json;
using eSARServices;
using eSARServiceInterface;
using eSARServiceModels;

namespace eSAR.Quarterly_Grading.Grading
{
    public partial class frmQuarterlyGrading : Telerik.WinControls.UI.RadForm
    {
        TeacherLoad SubjectSelected = new TeacherLoad();
        public string sy { get; set; }
        public string teacherName { get; set; }
        List<StudentSubject> classList = new List<StudentSubject>();
        Teacher teacher = new Teacher();
       
        public Teacher teach
        {
            get { return teacher; }
            set { teacher = value; }
        }
        public TeacherLoad selectedSubject
        {
            get { return SubjectSelected; }
            set { SubjectSelected = value; }
        }
        public string SubjectAssignments { get; set; }


        public frmQuarterlyGrading()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            foreach (StudentSubject ss in classList) {
                if (ss.FirstPeriodicRating > 0 && ss.FirstEntered.HasValue && ss.LockFirst==false && !ss.FirstLocked.HasValue)
                {
                    ss.FirstLocked = DateTime.Now;
                    ss.LockFirst = true;
                }
                 if (ss.SecondPeriodicRating > 0 && ss.SecondEntered.HasValue && ss.LockSecond == false && !ss.SecondLocked.HasValue)
                {
                    ss.SecondLocked = DateTime.Now;
                    ss.LockSecond = true;
                }
                 if (ss.ThirdPeriodicRating > 0 && ss.ThirdEntered.HasValue && ss.LockThird==false && !ss.ThirdLocked.HasValue)
                {
                    ss.ThirdLocked = DateTime.Now;
                    ss.LockThird = true;
                }
                if (ss.FourthPeriodicRating > 0 && ss.FourthEntered.HasValue && ss.LockFourth==false && !ss.FourthLocked.HasValue)
                {
                    ss.FourthLocked = DateTime.Now;
                    ss.LockFourth = true;
                }
            }

            IGradingService gradingService = new GradingService();
            if (gradingService.SaveClassGrades(classList))
            {
                foreach (StudentSubject ss in classList)
                   Log("U", "StudentSubjects", ss);
                    
                
                MessageBox.Show("Grades Locked Successfully");
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed Locking Grades");

            }

        }

        private void frmQuarterlyGrading_Load(object sender, EventArgs e)
        {
            if (GlobalClass.user.UserType == "teach")
                btnUnlock.Hide();

            sy = GlobalClass.currentsy;

            SubjectAssignments = selectedSubject.SubjectAssignments;
            txtSy.Text = sy;
            txtTeacherId.Text = teacher.TeacherId;
            txtTeacherName.Text = teacher.TeacherName;

            txtSubjectCode.Text = selectedSubject.SubjectCode;
            txtDescription.Text = selectedSubject.SubjectDescription;
            txtTimeslotInfo.Text = selectedSubject.TimeslotInfo;

            IGradingService gradingService = new GradingService();

            classList = new List<StudentSubject>(gradingService.GetClassList(SubjectAssignments));
            gvGrades.DataSource = classList;
         
            gvGrades.Hide();


        }

        private void gvGrades_CellBeginEdit(object sender, Telerik.WinControls.UI.GridViewCellCancelEventArgs e)
        {
            if ((int)this.gvGrades.CurrentRow.Cells[2].Value > 0)
            {
                e.Cancel = true;
            }
        }

        private void cmbQuarter_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            int selectedIndex = cmbQuarter.SelectedIndex;

            if (classList.Count > 0)
            {
                bool lockedfirst = (bool)classList[0].LockFirst;
                bool lockedsec = (bool)classList[0].LockSecond;
                bool lockedthird = (bool)classList[0].LockThird;
                bool lockedfourth = (bool)classList[0].LockFourth;
                switch (selectedIndex)
                {

                    case 1:
                        if (lockedfirst == true)
                            gvGrades.Columns["FirstPeriodicRating"].ReadOnly = true;
                        else
                            gvGrades.Columns["FirstPeriodicRating"].ReadOnly = false;

                        gvGrades.Columns["FirstPeriodicRating"].IsVisible = true;
                        gvGrades.Columns["FirstPeriodicRating"].Width = 100;
                        gvGrades.Columns["SecondPeriodicRating"].IsVisible = false;
                        gvGrades.Columns["ThirdPeriodicRating"].IsVisible = false;
                        gvGrades.Columns["FourthPeriodicRating"].IsVisible = false;
                        gvGrades.Columns["FinalRating"].IsVisible = false;
                        gvGrades.Columns["Proficiency"].IsVisible = false;
                        gvGrades.Columns["Remarks"].IsVisible = false;
                        
                        break;
                    case 2:
                        gvGrades.Columns["FirstPeriodicRating"].IsVisible = false;

                        if (lockedsec == true)
                            gvGrades.Columns["SecondPeriodicRating"].ReadOnly = true;
                        else
                            gvGrades.Columns["SecondPeriodicRating"].ReadOnly = false;

                        gvGrades.Columns["SecondPeriodicRating"].IsVisible = true;
                        gvGrades.Columns["SecondPeriodicRating"].Width = 100;
                        gvGrades.Columns["ThirdPeriodicRating"].IsVisible = false;
                        gvGrades.Columns["FourthPeriodicRating"].IsVisible = false;
                        gvGrades.Columns["FinalRating"].IsVisible = false;
                        gvGrades.Columns["Proficiency"].IsVisible = false;
                        gvGrades.Columns["Remarks"].IsVisible = false;
                        break;
                    case 3:
                        gvGrades.Columns["FirstPeriodicRating"].IsVisible = false;
                        gvGrades.Columns["SecondPeriodicRating"].IsVisible = false;

                        if (lockedthird == true)
                            gvGrades.Columns["ThirdPeriodicRating"].ReadOnly = true;
                        else
                            gvGrades.Columns["ThirdPeriodicRating"].ReadOnly = false;

                        gvGrades.Columns["ThirdPeriodicRating"].IsVisible = true;
                        gvGrades.Columns["ThirdPeriodicRating"].Width = 100;
                        gvGrades.Columns["FourthPeriodicRating"].IsVisible = false;
                        gvGrades.Columns["FinalRating"].IsVisible = false;
                        gvGrades.Columns["Proficiency"].IsVisible = false;
                        gvGrades.Columns["Remarks"].IsVisible = false;
                        break;
                    case 4:
                        gvGrades.Columns["FirstPeriodicRating"].IsVisible = false;
                        gvGrades.Columns["SecondPeriodicRating"].IsVisible = false;
                        gvGrades.Columns["ThirdPeriodicRating"].IsVisible = false;

                        if (lockedfourth == true)
                            gvGrades.Columns["FourthPeriodicRating"].ReadOnly = true;
                        else
                            gvGrades.Columns["FourthPeriodicRating"].ReadOnly = false;

                        gvGrades.Columns["FourthPeriodicRating"].IsVisible = true;
                        gvGrades.Columns["FourthPeriodicRating"].Width = 100;
                        gvGrades.Columns["FinalRating"].IsVisible = true;
                        gvGrades.Columns["Remarks"].IsVisible = true;
                        gvGrades.Columns["Remarks"].ReadOnly = false;
                        gvGrades.Columns["Proficiency"].IsVisible = true;
                        gvGrades.Columns["Proficiency"].ReadOnly = true;
                        break;
                    case 5:
                        gvGrades.Columns["FirstPeriodicRating"].IsVisible = false;
                        gvGrades.Columns["SecondPeriodicRating"].IsVisible = false;
                        gvGrades.Columns["ThirdPeriodicRating"].IsVisible = false;
                        gvGrades.Columns["FourthPeriodicRating"].IsVisible = false;
                        gvGrades.Columns["FinalRating"].IsVisible = true;
                        gvGrades.Columns["FinalRating"].Width = 100;
                        gvGrades.Columns["FinalRating"].ReadOnly = true;
                        gvGrades.Columns["Remarks"].IsVisible = true;
                        gvGrades.Columns["Remarks"].ReadOnly = false;
                        gvGrades.Columns["Proficiency"].IsVisible = true;
                        gvGrades.Columns["Proficiency"].ReadOnly = true;
                        break;
                    case 0:
                        if (lockedfirst == true)
                            gvGrades.Columns["FirstPeriodicRating"].ReadOnly = true;
                        else
                            gvGrades.Columns["FirstPeriodicRating"].ReadOnly = false;
                        gvGrades.Columns["FirstPeriodicRating"].IsVisible = true;
                        gvGrades.Columns["FirstPeriodicRating"].Width = 50;

                        if (lockedsec == true)
                            gvGrades.Columns["SecondPeriodicRating"].ReadOnly = true;
                        else
                            gvGrades.Columns["SecondPeriodicRating"].ReadOnly = false;
                        gvGrades.Columns["SecondPeriodicRating"].IsVisible = true;
                        gvGrades.Columns["SecondPeriodicRating"].Width = 50;
                        if (lockedthird == true)
                            gvGrades.Columns["ThirdPeriodicRating"].ReadOnly = true;
                        else
                            gvGrades.Columns["ThirdPeriodicRating"].ReadOnly = false;

                        gvGrades.Columns["ThirdPeriodicRating"].IsVisible = true;
                        gvGrades.Columns["ThirdPeriodicRating"].Width = 50;

                        if (lockedfourth == true)
                            gvGrades.Columns["FourthPeriodicRating"].ReadOnly = true;
                        else
                            gvGrades.Columns["FourthPeriodicRating"].ReadOnly = false;

                        gvGrades.Columns["FourthPeriodicRating"].IsVisible = true;
                        gvGrades.Columns["FourthPeriodicRating"].Width = 50;
                        gvGrades.Columns["FinalRating"].IsVisible = true;
                        gvGrades.Columns["FinalRating"].Width = 100;
                        gvGrades.Columns["Proficiency"].IsVisible = true;
                        gvGrades.Columns["Remarks"].IsVisible = true;
                        gvGrades.Columns["Remarks"].ReadOnly = false;

                        break;

                }
            }
            gvGrades.Show();
        }

        private void gvGrades_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.Column.Name == "FirstPeriodicRating") {
                classList[index].FirstPeriodicRating =(Double)(e.Row.Cells["FirstPeriodicRating"].Value);
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
                
                if (classList[index].FinalRating > 90)
                    classList[index].Proficiency = "O";
                else if (classList[index].FinalRating >= 85)
                    classList[index].Proficiency = "VS";
                else if (classList[index].FinalRating >= 80)
                    classList[index].Proficiency = "S";
                else if (classList[index].FinalRating >= 75)
                    classList[index].Proficiency = "FS";
                else if (classList[index].FinalRating <= 74)
                    classList[index].Proficiency = "D";
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            IGradingService gradingService = new GradingService();
            if (gradingService.SaveClassGrades(classList)) {
                foreach (StudentSubject ss in classList)
                    Log("U", "StudentSubjects", ss);
                 
                    MessageBox.Show("Grades Saved Successfully");
                    this.Close();
                
            }
            else{
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

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            foreach (StudentSubject ss in classList)
            {
                if (ss.FirstPeriodicRating > 0 && ss.FirstEntered.HasValue && ss.LockFirst == true && ss.FirstLocked.HasValue)
                {
                    ss.FirstLocked = null;
                    ss.LockFirst = false;
                }
                if (ss.SecondPeriodicRating > 0 && ss.SecondEntered.HasValue && ss.LockSecond == true && ss.SecondLocked.HasValue)
                {
                    ss.SecondLocked = null;
                    ss.LockSecond = false;
                }
                if (ss.ThirdPeriodicRating > 0 && ss.ThirdEntered.HasValue && ss.LockThird == true && ss.ThirdLocked.HasValue)
                {
                    ss.ThirdLocked = null;
                    ss.LockThird = false;
                }
                if (ss.FourthPeriodicRating > 0 && ss.FourthEntered.HasValue && ss.LockFourth == true && ss.FourthLocked.HasValue)
                {
                    ss.FourthLocked = null;
                    ss.LockFourth = false;
                }
            }

            IGradingService gradingService = new GradingService();
            if (gradingService.SaveClassGrades(classList))
            {
                foreach (StudentSubject ss in classList)
                    Log("U", "StudentSubjects", ss);


                MessageBox.Show("Grades UnLocked Successfully");
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed UnLocking Grades");

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
            document.AssociatedObject = this.gvGrades;
            radPrintDocument1 = document;

            RadPrintPreviewDialog dialog = new RadPrintPreviewDialog();
            dialog.Document = this.radPrintDocument1;
            dialog.ShowDialog();
        }
    }
}
