using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using eSARServices;
using eSARServiceInterface;
using eSARServiceModels;

namespace eSAR.Course_Related_Resources.ManageSchedule
{
    public partial class frmScheduleList : Telerik.WinControls.UI.RadForm
    {
        List<SubjectAssignment> scheduleList;
        List<SubjectAssignment> filterScheduleList;


        public List<GradeSection> sections;
        public List<GradeLevel> gradeLevels;
        public string gradelevel;

        public frmScheduleList()
        {
            InitializeComponent();
            InitializeLists();
        }

        private void InitializeLists()
        {
            ISubjectAssignmentService schedService = new SubjectAssignmentService();
            scheduleList = new List<SubjectAssignment>(schedService.GetAllSchedules());
            gradeLevels = new List<GradeLevel>(schedService.GetAllGradeLevels());
            gradeLevels.RemoveAll(x => x.GradeLev == "0");
            sections = new List<GradeSection>(schedService.GetAllSections());
        }

        private void SetComboBoxes()
        {
            //Disable();
            cmbGradeLevel.DataSource = gradeLevels;
            //cmbGradeLevel.SelectedIndex = 0;
        }

        public void LoadSchedules()
        {
            SetComboBoxes();
            filterScheduleList = new List<SubjectAssignment>(scheduleList.FindAll
                (x => x.GradeLevel == cmbGradeLevel.SelectedValue.ToString() &&
                x.GradeSectionCode == (int)cmbSection.SelectedValue));
        }

   
        private void btnCancelSchedule_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void frmScheduleList_Load(object sender, EventArgs e)
        {
            SchedulerWeekView dayView = this.radScheduler1.GetWeekView();
            
            //dayView.DayCount = 7;
            dayView.RangeFactor = ScaleRange.TenMinutes;
            dayView.RulerStartScale = 6;
            dayView.RulerEndScale = 18;

            LoadSchedules();
            radScheduler1.Appointments.Clear();
            setScheduleToScheduler();
        }

        private void setScheduleToScheduler()
        {
            DateTime timeStart = new DateTime();
            DateTime timeEnd = new DateTime();
            string summary = string.Empty;
            string description = string.Empty;
            List<DateTime> lDT = new List<DateTime>();

            foreach (SubjectAssignment sa in filterScheduleList)
            {

                if (sa.Days != null)
                {
                    string[] days = sa.Days.Split(',');

                    for (int i = 0; i < days.Length; i++)
                    {
                        lDT = getDayDates(DateTime.Now.Month, DateTime.Now.Year, days[i]);

                        foreach (DateTime dt in lDT)
                        {
                            timeStart = DateTime.Parse(dt.Month.ToString() + "-" + dt.Day.ToString() + "-" + dt.Year.ToString() + " " + sa.Timestart);
                            timeEnd = DateTime.Parse(dt.Month.ToString() + "-" + dt.Day.ToString() + "-" + dt.Year.ToString() + " " + sa.TimeEnd);
                            summary = sa.SubjectCode + "\r\n" + sa.RoomCode + "\r\n" + sa.TeacherName + "\r\n";// + "\r\n" + sa.Section;
                            description = sa.TeacherName + "\r\n" + sa.Section;

                            Appointment appointment =
                                new Appointment(timeStart, timeEnd, summary, description);
                            
                            this.radScheduler1.Appointments.Add(appointment);
                        }

                    }
                }

            }

        }

        private List<DateTime> getDayDates(int month, int year, string dayOfWeek)
        {
            string szDay = string.Empty;
            switch (dayOfWeek)
            {
                case "Sun":
                    szDay = "Sunday";
                    break;
                case "Mon":
                    szDay = "Monday";
                    break;
                case "Tue":
                    szDay = "Tuesday";
                    break;
                case "Wed":
                    szDay = "Wednesday";
                    break;
                case "Thu":
                    szDay = "Thursday";
                    break;
                case "Fri":
                    szDay = "Friday";
                    break;
                case "Sat":
                    szDay = "Saturday";
                    break;
            }

            List<DateTime> weekdays = new List<DateTime>();
            DateTime basedt = new DateTime(year, month, 1);
            while ((basedt.Month == month) && (basedt.Year == year))
            {
                if (basedt.DayOfWeek.ToString() == szDay)  //(DayOfWeek.Monday | DayOfWeek.Tuesday | DayOfWeek.Wednesday | DayOfWeek.Thursday | DayOfWeek.Friday))
                {
                    weekdays.Add(new DateTime(basedt.Year, basedt.Month, basedt.Day));
                }
                basedt = basedt.AddDays(1);
            }
            return weekdays;
        }

        private void cmbGradeLevel_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbGradeLevel.SelectedIndex != -1)
            {
                gradelevel = cmbGradeLevel.SelectedValue.ToString();
                List<GradeSection> gs = new List<GradeSection>();
                gs = sections.FindAll(s => s.GradeLevel == gradelevel);

                if (gs.Count > 0)
                {
                    cmbSection.ValueMember = "GradeSectionCode";
                    cmbSection.DisplayMember = "Section";
                    cmbSection.DataSource = gs;
                    cmbSection.Enabled = true;
                }
                else
                    cmbSection.DataSource = null;
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            radScheduler1.Appointments.Clear();
            if (cmbGradeLevel.Text != string.Empty && cmbSection.Text != string.Empty)
            {
                LoadSchedules();
                
                setScheduleToScheduler();
            }
        }

        private void radScheduler1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button.ToString().ToLower() == "right")
            {
                //SendKeys.Send("{Esc}");
                return;
            }
        }
    }
}
