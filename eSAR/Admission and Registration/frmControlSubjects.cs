using System;
using System.Collections.Generic;
using Telerik.WinControls.UI;
using System.Windows.Forms;
using eSAR.Utility_Classes;
using eSARServices;
using eSARServiceInterface;
using eSARServiceModels;
using Newtonsoft.Json;

namespace eSAR.Admission_and_Registration
{
    public partial class frmControlSubjects : Telerik.WinControls.UI.RadForm
    {
        List<StudentSubject> ExistingSchedRemove = new List<StudentSubject>();
        List<StudentSchedule> RemoveFromControl = new List<StudentSchedule>();
        List<StudentSchedule> AddFromControl = new List<StudentSchedule>();
        List<StudentSchedule> AddFromAll = new List<StudentSchedule>();

        List<StudentSchedule> Schedules = new List<StudentSchedule>();
        List<StudentSchedule> controlSchedule = new List<StudentSchedule>();
        public string controlStudentId { get; set; }
        public Student ControlStudent { get; set; }
        public string SY { get; set; }
        List<StudentSubject> StudentSubs = new List<StudentSubject>();
        public List<StudentSchedule> ExistingSchedule = new List<StudentSchedule>();
        List<StudentSubject> FailedSubjects;
        public string GradeLevel { get; set; }
        public string Gender { get; set; }
        public StudentEnrollment EnrolMe = new StudentEnrollment();
        public List<StudentSchedule> Schedule = new List<StudentSchedule>();
        public List<StudentSchedule> ControlSchedule {
            get { return this.controlSchedule;  }
            set { this.controlSchedule = value; }
        }
        public StudentSchedule SelectedSchedule = new StudentSchedule();
        public List<StudentSchedule> AddedSched = new List<StudentSchedule>();
        public List<StudentSubject> subjects = new List<StudentSubject>();
        public List<GradeSection> sections;
        List<StudentSubject> listStSub = new List<StudentSubject>();
        StudentSubject stSubj = new StudentSubject();
        public int gradeSectionCode = -1;
        public Boolean changed { get; set; }
        public frmControlSubjects()
        {
            GlobalClass.fromScreen = String.Empty;
          //  GlobalClass.gvDatasource = 0;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmControlSubjects_Load(object sender, EventArgs e)
        {        

            IRegistrationService registrationService = new RegistrationService();
            string message = String.Empty;
            
            ControlStudent = registrationService.GetStudent(controlStudentId,ref message);
            StudentEnrollment enrStudent = new StudentEnrollment();

            SY = GlobalClass.currentsy;
            enrStudent = registrationService.GetStudentEnrolled(controlStudentId,SY);

            ISubjectAssignmentService schedService = new SubjectAssignmentService();
            sections = new List<GradeSection>(schedService.GetAllSections());
            List<GradeSection> gs = new List<GradeSection>();
            gs = sections.FindAll(s => s.GradeLevel == ControlStudent.GradeLevel);

            //   cbSection.DataSource = gs;

            int index = gs.FindIndex(s => s.Section == ControlStudent.Section);
            gradeSectionCode = gs[index].GradeSectionCode;
            loadSched();
            txtSection.Text = ControlStudent.Section;
          //  cbSection.Text = ControlStudent.Section;
            txtSY.Text = SY;
            txtGradeLevel.Text = ControlStudent.GradeLevel;
            txtStudentId.Text = ControlStudent.StudentId;
            txtStudentName.Text = ControlStudent.LastName + "," + ControlStudent.FirstName + " " + ControlStudent.MiddleName;
            txtPrevGPA.Text = ControlStudent.Average.ToString();
            txtUnitsFailed.Text = ControlStudent.UnitsFailedLastYear.ToString();
           
        }

        private void loadSched()
        {
            IRegistrationService registrationService = new RegistrationService();
            string message = String.Empty;

            EnrolMe.StudentSY = controlStudentId + SY;
            int prev = Int32.Parse(SY.Substring(0, 4));
            prev--;
            int sy = Int32.Parse(SY.Substring(5, 4));
            sy--;
            string prevSY = prev.ToString() + "-" + sy.ToString();

            string prevRecord = controlStudentId + prevSY;

            gvAllSchedules.DataSource = null;
            gvSchedule.DataSource = null;
            gvFail.DataSource = null;
        
            ExistingSchedRemove.Clear();

            FailedSubjects = new List<StudentSubject>(registrationService.GetFailedSubjects(prevRecord));
            StudentSubs = new List<StudentSubject>(registrationService.GetStudentSubjects(EnrolMe.StudentSY));
            Schedules = new List<StudentSchedule>(registrationService.GetSubjectSchedules(SY));

            if (StudentSubs.Count > 0)
            {
                ExistingSchedule = new List<StudentSchedule>(registrationService.GetStudentExistingSchedule(StudentSubs, SY));
            }

            if (ExistingSchedule.Count > 0)
            {
                foreach (StudentSchedule ss in ExistingSchedule)
                {
                    int index = Schedules.FindIndex(item => item.SubjectAssignments == ss.SubjectAssignments);
                    Schedules.RemoveAt(index);
                }
            }


            gvFail.DataSource = FailedSubjects;
            gvAllSchedules.DataSource = Schedules;

            if (ControlStudent.UnitsFailedLastYear == 0 && StudentSubs.Count == 0)
            {
              //  int sectionCode = (int)cbSection.SelectedValue;
                Schedule = new List<StudentSchedule>(registrationService.GetSubjectsOfSection(gradeSectionCode, SY));
                foreach (StudentSchedule sch in Schedule)
                {
                    StudentSubject ss = new StudentSubject()
                    {
                        StudentSY = controlStudentId + SY,
                        SubjectCode = sch.SubjectCode,
                        SubjectAssignments = sch.SubjectAssignments,
                        StudentEnrSubCode = controlStudentId + SY + sch.SubjectCode,
                        LockFirst = false,
                        LockSecond = false,
                        LockThird = false,
                        LockFourth = false,
                        FirstPeriodicRating = 0.00,
                        SecondPeriodicRating = 0.00,
                        ThirdPeriodicRating = 0.00,
                        FourthPeriodicRating = 0.00
                    };
                    subjects.Add(ss);
                }

                ControlSchedule = Schedule;
                GlobalClass.gvDatasource = 1;
                gvSchedule.DataSource = ControlSchedule;
                gvSchedule.ReadOnly = false;
            }
            else if (StudentSubs.Count > 0)
            {
                GlobalClass.gvDatasource = 2;
                ControlSchedule = ExistingSchedule;
                gvAllSchedules.ReadOnly = false;
                gvSchedule.ReadOnly = false;
                gvSchedule.DataSource = ControlSchedule;
            }
            else if (ControlStudent.UnitsFailedLastYear > 0)
            {
                GlobalClass.gvDatasource = 3;
                gvAllSchedules.ReadOnly = false;
                gvSchedule.ReadOnly = false;
            }
        }

        private void gvSchedule_CellEditorInitialized(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            RadCheckBoxEditor cbEditor = e.ActiveEditor as RadCheckBoxEditor;
            
               
            if (cbEditor != null)
            {
                cbEditor.ValueChanged -= cbEditor_ValueChanged;
                cbEditor.ValueChanged += cbEditor_ValueChanged;
            }
        }
        

        private void cbEditor_ValueChanged(object sender, EventArgs e)
        {
            StudentSchedule sa = new StudentSchedule();
            int i = gvSchedule.CurrentRow.Index;
            string subass=gvSchedule.Rows[i].Cells["SubjectAssignments"].Value.ToString();
            int index = ControlSchedule.FindIndex(item => item.SubjectAssignments == subass);
            ControlSchedule[index].Selected = false;
            sa = ControlSchedule[index];
         

            RadCheckBoxEditor cbEditor = sender as RadCheckBoxEditor;
            StudentSubject ss = new StudentSubject()
            {
                StudentSY = controlStudentId + SY,
                SubjectCode = sa.SubjectCode,
                SubjectAssignments = sa.SubjectAssignments,
                StudentEnrSubCode = controlStudentId + SY + sa.SubjectCode,
                LockFirst = false,
                LockSecond = false,
                LockThird = false,
                LockFourth = false,
                FirstPeriodicRating = 0.00,
                SecondPeriodicRating = 0.00,
                ThirdPeriodicRating = 0.00,
                FourthPeriodicRating = 0.00                
            };

            if ((Telerik.WinControls.Enumerations.ToggleState)cbEditor.Value == Telerik.WinControls.Enumerations.ToggleState.Off)
            {
                sa.Selected = false;
                AddFromControl.Add(sa);
                subjects.Add(ss);
                Schedules.Remove(sa);
               
            }
            else if ((Telerik.WinControls.Enumerations.ToggleState)cbEditor.Value == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                sa.Selected = false;
                RemoveFromControl.Add(sa);
                bool cont = ExistingSchedule.Contains(sa);
                if (cont) {
                    int ind = ExistingSchedule.FindIndex(item => item.SubjectAssignments == sa.SubjectAssignments);
                    StudentSubject sti = new StudentSubject()
                    {
                        StudentSY = controlStudentId + SY,
                        SubjectCode = ExistingSchedule[ind].SubjectCode,
                        SubjectAssignments = ExistingSchedule[ind].SubjectAssignments,
                        StudentEnrSubCode = controlStudentId + SY + ExistingSchedule[ind].SubjectCode,
                        LockFirst = false,
                        LockSecond = false,
                        LockThird = false,
                        LockFourth = false,
                        FirstPeriodicRating = 0.00,
                        SecondPeriodicRating = 0.00,
                        ThirdPeriodicRating = 0.00,
                        FourthPeriodicRating = 0.00
                    };
                    ExistingSchedRemove.Add(sti);
                }
                else 
                    subjects.Remove(ss);
                AddFromAll.Add(sa);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            IRegistrationService registrationService = new RegistrationService();
            ILogService logService = new LogService();
            if (ExistingSchedRemove.Count > 0)
            {
                if (registrationService.DeleteLoadedSubjects(controlStudentId, SY, ExistingSchedRemove))
                {

                    foreach (StudentSubject ss in ExistingSchedRemove)
                    {
                        string json = JsonConvert.SerializeObject(ss);
                        Log log = new Log
                        {
                            CLUD = "D",
                            LogDate = DateTime.Now,
                            TableName = "StudentSubject",
                            UserId = GlobalClass.user.UserId,
                            UserName = GlobalClass.user.UserName,
                            PassedData = json
                        };
                        logService.AddLogs(log);
                    }
                    MessageBox.Show(this, "Adding Student Subjects Successful .");
                    Close();
                }
                else
                {
                    MessageBox.Show(this, "Student Subjects Adding Failed.");
                    Close();
                }
            }
            if (subjects.Count > 0)
            {
                if (registrationService.ControlSubjects(controlStudentId, SY, subjects))
                {
                    foreach (StudentSubject ss in subjects)
                    {
                        string json = JsonConvert.SerializeObject(ss);
                        Log log = new Log
                        {
                            CLUD = "C",
                            LogDate = DateTime.Now,
                            TableName = "StudentSubject",
                            UserId = GlobalClass.user.UserId,
                            UserName = GlobalClass.user.UserName,
                            PassedData = json
                        };
                        logService.AddLogs(log);
                    }
                    MessageBox.Show(this, "Adding Student Subjects Successful .");
                    Close();
                }
                else
                {
                    MessageBox.Show(this, "Student Subjects Adding Failed.");
                    Close();
                }
            }
        }

         private void gvAllSchedules_CellEditorInitialized(object sender, GridViewCellEventArgs e)
        {
            RadCheckBoxEditor cbEditor1 = e.ActiveEditor as RadCheckBoxEditor;
          
            if (cbEditor1 != null)
            {
                cbEditor1.ValueChanged -= cbEditor1_ValueChanged;
                cbEditor1.ValueChanged += cbEditor1_ValueChanged;
            }
        }

        private void cbEditor1_ValueChanged(object sender, EventArgs e)
        {
            StudentSchedule sa = new StudentSchedule();
            int i = gvAllSchedules.CurrentRow.Index;
            string subass = gvAllSchedules.Rows[i].Cells["SubjectAssignments"].Value.ToString();
            int index = Schedules.FindIndex(item => item.SubjectAssignments == subass);

            Schedules[index].Selected = false;
            sa = Schedules[index];

            RadCheckBoxEditor cbEditor1 = sender as RadCheckBoxEditor;
                StudentSubject ss = new StudentSubject()
                {
                    StudentSY = controlStudentId + SY,
                    SubjectCode = sa.SubjectCode,
                    SubjectAssignments = sa.SubjectAssignments,
                    StudentEnrSubCode = controlStudentId + SY + sa.SubjectCode,
                    LockFirst = false,
                    LockSecond = false,
                    LockThird = false,
                    LockFourth = false,
                    FirstPeriodicRating = 0.00,
                    SecondPeriodicRating = 0.00,
                    ThirdPeriodicRating = 0.00,
                    FourthPeriodicRating = 0.00
                };

                if ((Telerik.WinControls.Enumerations.ToggleState)cbEditor1.Value == Telerik.WinControls.Enumerations.ToggleState.On)
                {
                    sa.Selected = false;
                    AddFromControl.Add(sa);
                    subjects.Add(ss);
                    Schedules.Remove(sa);
                }
                else if ((Telerik.WinControls.Enumerations.ToggleState)cbEditor1.Value == Telerik.WinControls.Enumerations.ToggleState.Off)
                {
                    sa.Selected = false;
                    ControlSchedule.Remove(sa);
                    subjects.Remove(ss);
                    AddFromAll.Add(sa);
                }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<StudentSchedule> ss = new List<StudentSchedule>();
            gvAllSchedules.DataSource = ss;
            gvSchedule.DataSource = ss;

            ControlSchedule.AddRange(AddFromControl);
            List<StudentSchedule> seltrue = ControlSchedule.FindAll(item => item.Selected == true);
            foreach (StudentSchedule s in seltrue)
            {
                int i = ControlSchedule.FindIndex(item => item.SubjectAssignments == s.SubjectAssignments);
                ControlSchedule[i].Selected = false;

            }
            gvAllSchedules.DataSource = Schedules;

            gvSchedule.DataSource = ControlSchedule;
            AddFromControl.Clear();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            List<StudentSchedule> ss = new List<StudentSchedule>();
            gvAllSchedules.DataSource = ss;
            gvSchedule.DataSource = ss;

            Schedules.AddRange(AddFromAll);

            List<StudentSchedule> selControlledTrue = AddFromAll.FindAll(item => item.Selected == true);

            IGradingService gradingService = new GradingService();
            listStSub = gradingService.GetStudentGrades(controlStudentId, SY);
            
            foreach (StudentSchedule sche in selControlledTrue) {
                if (listStSub != null)
                    stSubj = listStSub.Find(item => item.StudentSY == controlStudentId + SY && item.SubjectCode == sche.SubjectCode);

                if (stSubj != null)
                {
                    if (stSubj.FirstPeriodicRating > 0 || stSubj.SecondPeriodicRating > 0 || stSubj.ThirdPeriodicRating > 0 || stSubj.FourthPeriodicRating > 0 || stSubj.FinalRating > 0)
                    {
                        MessageBox.Show("Cannot remove " + stSubj.Description + ", already has grade/s inputted", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        int i = ControlSchedule.FindIndex(item => item.SubjectAssignments == sche.SubjectAssignments);
                        ControlSchedule[i].Selected = false;

                        int i3 = ExistingSchedRemove.FindIndex(item => item.SubjectAssignments == sche.SubjectAssignments);
                        ExistingSchedRemove.RemoveAt(i3);
                    }
                    else
                    {
                        int i = ControlSchedule.FindIndex(item => item.SubjectAssignments == sche.SubjectAssignments);
                        ControlSchedule.RemoveAt(i);

                        int i2 = Schedules.FindIndex(item => item.SubjectAssignments == sche.SubjectAssignments);
                        Schedules[i2].Selected = false;

                    }
                }
            }

                  
            gvAllSchedules.DataSource = Schedules;
            gvSchedule.DataSource = ControlSchedule;
            AddFromAll.Clear();
        }

        private void cbSection_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (changed)
            {
            IRegistrationService registrationService = new RegistrationService();
                int index = cbSection.SelectedIndex;
            GradeSection s = sections[index];
            registrationService.DeleteExistingSubjects(ControlStudent.StudentId + SY);
            registrationService.UpdateStudentSection(ControlStudent.StudentId + SY, s.GradeSectionCode, s.Section);

            Schedule = registrationService.GetSubjectsOfSection(s.GradeSectionCode, SY);
            subjects.Clear();
            foreach (StudentSchedule sch in Schedule)
                {
                    StudentSubject ss = new StudentSubject()
                    {
                        StudentSY = controlStudentId + SY,
                        SubjectCode = sch.SubjectCode,
                        SubjectAssignments = sch.SubjectAssignments,
                        StudentEnrSubCode = controlStudentId + SY + sch.SubjectCode,
                        LockFirst = false,
                        LockSecond = false,
                        LockThird = false,
                        LockFourth = false,
                        FirstPeriodicRating = 0.00,
                        SecondPeriodicRating = 0.00,
                        ThirdPeriodicRating = 0.00,
                        FourthPeriodicRating = 0.00
                    };
                    subjects.Add(ss);
                }

            ControlSchedule = Schedule;
            GlobalClass.gvDatasource = 1;
            gvSchedule.DataSource = ControlSchedule;
            gvSchedule.ReadOnly = false;
          
        }
    }

        private void btnChangeSection_Click(object sender, EventArgs e)
        {
            ISubjectAssignmentService schedService = new SubjectAssignmentService();
            sections = new List<GradeSection>(schedService.GetAllSectionsOfGradeLevel(ControlStudent.GradeLevel));
            //List<GradeSection> gs = new List<GradeSection>();
            //gs = sections.FindAll(s => s.GradeLevel == ControlStudent.GradeLevel);
            cbSection.DataSource = sections;
            cbSection.DisplayMember = "Section";
            cbSection.ValueMember = "GradeSectionCode";
            this.txtSection.Visible = false;
            this.cbSection.Visible = true;

            changed = true;
          
          //  cbSection.Text = ControlStudent.Section;

        }
    }
}
