using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Newtonsoft.Json;
using eSAR.Utility_Classes;
using eSARServices;
using eSARServiceInterface;
using eSARServiceModels;

namespace eSAR.Course_Related_Resources.ManageSchedule
{
    public partial class frmScheduleDetails : Telerik.WinControls.UI.RadForm
    {
        public String Op { get; set; }
        public SubjectAssignment SelectedSchedule { get; set; }
        public List<SubjectAssignment> schedules;
        public List<Teacher> academicTeachers;
        public List<Teacher> teachers;
        List<Teacher> availTeach;
        public List<Room> rooms;
        List<Room> availRooms;
        public List<Timeslot> timeslots = new List<Timeslot>();
        List<Timeslot> availTimeSlot=new List<Timeslot>();
        public List<GradeSection> sections;
        public List<GradeLevel> gradeLevels;
        public List<Subject> subjects;
        public string currentSY;
        public string gradelevel;
        public string section;
        public int sectioncode;
        public List<SubjectAssignment> createdSchedule = new List<SubjectAssignment>();
        List<SubjectAssignment> slist = new List<SubjectAssignment>();
        List<Room> roomUsed = new List<Room>();
        List<Teacher> teacherUsed = new List<Teacher>();
        bool academicSubject = false;

        public frmScheduleDetails()
        {
            InitializeComponent();
          
            InitializeLists();
        }

        private void InitializeLists()
        {
            ISubjectAssignmentService schedService = new SubjectAssignmentService();
            currentSY = schedService.GetCurrentSY();
            gradeLevels = new List<GradeLevel>(schedService.GetAllGradeLevels());
            gradeLevels.RemoveAll(x => x.GradeLev == "0");
            sections = new List<GradeSection>(schedService.GetAllSections());
            subjects = new List<Subject>(schedService.GetAllSubjects());
            
            timeslots = new List<Timeslot>(schedService.GetTimeslots());
            rooms = new List<Room>(schedService.GetAllRooms());
            teachers = new List<Teacher>(schedService.GetAllTeachers());
        }

        private void frmScheduleDetails_Load(object sender, EventArgs e)
        {
            ISubjectAssignmentService schedService = new SubjectAssignmentService();
            schedules = new List<SubjectAssignment>(schedService.GetAllSchedules());
            LoadSchedules();
        }

        public void LoadSchedules()
        {
            SetComboBoxes();
               // SetFields();
        }

        private void SetFields()
        {
            cmbGradeLevel.SelectedValue = SelectedSchedule.GradeLevel;
            cmbSection.SelectedValue = SelectedSchedule.GradeSectionCode;
            SetSchedGrid();
        }

        private void SetSchedGrid()
        {
            if (SelectedSchedule != null)
            {
                ISubjectAssignmentService schedService = new SubjectAssignmentService();
                createdSchedule = new List<SubjectAssignment>(schedService.GetStudentExSchedule(SelectedSchedule.GradeSectionCode, currentSY));
                gvSchedule.DataSource = createdSchedule;
            }
        }

        private void SetComboBoxes()
        {
            //Disable();
            cmbGradeLevel.DataSource = gradeLevels;
            if (cmbGradeLevel.SelectedIndex >= 0)
                cmbGradeLevel.SelectedIndex = 0;

            if (cmbSection.SelectedIndex >= 0)
                cmbSection.SelectedIndex = 0;

            if (cmbSubject.SelectedIndex >= 0)
                cmbSubject.SelectedIndex = 0;

          }

       
        private void btnCancelSchedule_Click(object sender, EventArgs e)
        {
            this.Close();
        }
  


    
     
        private void loadAvailableRooms()
        {
            List<SubjectAssignment> roomSchedule = new List<SubjectAssignment>(schedules.FindAll(s => s.SY == GlobalClass.currentsy));
            Timeslot selectedTimeslot = new Timeslot();
            string szVal = string.Empty;
            cmbTimeslot.ValueMember = "TimeSlotCode";
            cmbTimeslot.DisplayMember = "TimeSlotInfo";
            szVal = cmbTimeslot.SelectedValue.ToString();
            selectedTimeslot = timeslots.Find(x => x.TimeSlotCode == szVal);

            string[] dayArray = selectedTimeslot.Days.Split(',');

            int selected_TimeStart = timeStringToInt(selectedTimeslot.TimeStart);
            int selected_TimeEnd = timeStringToInt(selectedTimeslot.TimeEnd);

            availRooms = new List<Room>(rooms);

            foreach (Room rm in rooms)
            {
                foreach (SubjectAssignment rS in roomSchedule)
                {
                    if (rS.RoomId == rm.RoomId)
                    {
                        foreach (string sDay in dayArray)
                        {
                            if (rS.Days.Contains(sDay))
                            {
                                int compared_TimeStart = timeStringToInt(rS.Timestart);
                                int compared_TimeEnd = timeStringToInt(rS.TimeEnd);

                                if ((compared_TimeStart <= selected_TimeStart && compared_TimeEnd <= selected_TimeEnd && compared_TimeEnd > selected_TimeStart) ||
                                            (compared_TimeStart >= selected_TimeStart && compared_TimeEnd <= selected_TimeEnd) ||
                                            (compared_TimeStart >= selected_TimeStart && compared_TimeStart < selected_TimeEnd && compared_TimeEnd > selected_TimeEnd))
                                {
                                    availRooms.RemoveAll(x => x.RoomId == rS.RoomId);
                                }
                            }
                        }
                    }
                }
            }

            if (availRooms.Count > 0)
            {
                cmbRoom.Enabled = true;
                cmbRoom.ValueMember = "RoomId";
                cmbRoom.DisplayMember = "RoomCode";
                cmbRoom.DataSource = availRooms;
            }

        }

        private void loadAvailableTeachers()
        {
            List<SubjectAssignment> roomSchedule = new List<SubjectAssignment>(schedules.FindAll(s => s.SY == GlobalClass.currentsy));
            Timeslot selectedTimeslot = new Timeslot();
            string szVal = string.Empty;
            szVal = cmbTimeslot.SelectedValue.ToString();
            selectedTimeslot = timeslots.Find(x => x.TimeSlotCode == szVal);

            string[] dayArray = selectedTimeslot.Days.Split(',');

            int selected_TimeStart = timeStringToInt(selectedTimeslot.TimeStart);
            int selected_TimeEnd = timeStringToInt(selectedTimeslot.TimeEnd);

          
            availTeach = new List<Teacher>(teachers);

            foreach (Teacher tc in teachers)
            {
                foreach (SubjectAssignment rS in roomSchedule)
                {
                    if (rS.TeacherId == tc.TeacherId)
                    {
                        foreach (string sDay in dayArray)
                        {
                            if (rS.Days.Contains(sDay))
                            {
                                int compared_TimeStart = timeStringToInt(rS.Timestart);
                                int compared_TimeEnd = timeStringToInt(rS.TimeEnd);

                                if ((compared_TimeStart <= selected_TimeStart && compared_TimeEnd <= selected_TimeEnd && compared_TimeEnd > selected_TimeStart) ||
                                            (compared_TimeStart >= selected_TimeStart && compared_TimeEnd <= selected_TimeEnd) ||
                                            (compared_TimeStart >= selected_TimeStart && compared_TimeStart < selected_TimeEnd && compared_TimeEnd > selected_TimeEnd))
                                {
                                    availTeach.RemoveAll(x => x.TeacherId == rS.TeacherId);
                                }
                            }
                        }
                    }
                }
            }
     
          

            if (availTeach.Count > 0)
            {
                cmbTeacher.Enabled = true;
                cmbTeacher.ValueMember = "TeacherId";
                cmbTeacher.DisplayMember = "TeacherName";

                if (academicSubject == true)
                {
                    academicTeachers = new List<Teacher>(teachers.FindAll(x => x.Academic == true));
                    cmbTeacher.DataSource = availTeach;
                }
                else
                {
                    cmbTeacher.DataSource = availTeach;
                }
                //cmbTeacher.DataSource = availTeach;
            }

        }
       

        private void btnAddSchedule_Click(object sender, EventArgs e)
        {
            if (cmbGradeLevel.Text != string.Empty && cmbSection.Text != string.Empty && cmbTimeslot.Text != string.Empty && 
                cmbSubject.Text != string.Empty && cmbTeacher.Text != string.Empty && cmbRoom.Text != string.Empty)
            {
                Timeslot t = new Timeslot();
                t = timeslots.Find(x => x.TimeSlotCode == cmbTimeslot.SelectedValue.ToString());

                GradeSection gs = new GradeSection();
                gs = sections.Find(x => x.GradeSectionCode == sectioncode);

                Subject su = new Subject();
                su = subjects.Find(x => x.SubjectCode == cmbSubject.SelectedValue.ToString());

                Room rm = new Room();
                rm = rooms.Find(x => x.RoomId == Int32.Parse(cmbRoom.SelectedValue.ToString()));

                Teacher tc = new Teacher();
                tc = teachers.Find(x => x.TeacherId == cmbTeacher.SelectedValue.ToString());

                SubjectAssignment sa = new SubjectAssignment();
                sa.GradeLevel = cmbGradeLevel.SelectedValue.ToString() ;
                sa.TeacherName = cmbTeacher.Text;
                sa.SY = currentSY;
                sa.Subject = su;
                sa.SubjectCode = su.SubjectCode;
                sa.SubjectDescription = su.Description;
                sa.TimeslotInfo = t.TimeSlotInfo;
                sa.TimeSlotCode = t.TimeSlotCode;
                sa.Room = rm;
                sa.RoomId = rm.RoomId;
                sa.RoomCode = rm.RoomCode;
                sa.Teacher = tc;
                sa.TeacherId = tc.TeacherId;
                sa.Section = section;
                sa.GradeSection = gs;
                sa.GradeSectionCode = gs.GradeSectionCode;
                sa.Timeslot = t;
                sa.Timestart = t.TimeStart;
                sa.TimeEnd = t.TimeEnd;
                sa.Days = t.Days;
                sa.Deactivated = false;
                createdSchedule.Add(sa);
                schedules.Add(sa);

                
                cmbTimeslot.DataSource = null;
                availTimeSlot.RemoveAll(x => x.TimeSlotCode == t.TimeSlotCode);
                if (availTimeSlot.Count > 0)
                {
                    cmbTimeslot.DataSource = availTimeSlot;
                    cmbTimeslot.SelectedIndex = 0;
                    cmbTimeslot.Refresh();
                }
                else
                    cmbTimeslot.Enabled = false;

                gvSchedule.DataSource = null;
                gvSchedule.DataSource = schedules.FindAll(x => x.GradeSectionCode == sectioncode);
                gvSchedule.Refresh();

                // LoadSchedules();


            }
        }
        
        private void SaveSchedule()
        {
            Boolean ret = false;

            ISubjectAssignmentService schedService = new SubjectAssignmentService();
           
            ret = schedService.CreateSchedule(createdSchedule);
            foreach (SubjectAssignment sa in createdSchedule) 
                Log("C", "SubjectAssignments",sa);
              
            if (ret)
            {
                schedules = new List<SubjectAssignment>(schedService.GetAllSchedules());
                createdSchedule.Clear();
                InitializeLists();
                LoadSchedules();
                

                MessageBox.Show(this, "Schedule saved successfully!");
            }
            else
            {
                MessageBox.Show("Error Saving");
            }
        }

        private void SetTimeSlotCombo() {
           
            //Get timeslot that are already assigned
            List<Timeslot> usedtslot = new List<Timeslot>();
            foreach (SubjectAssignment sch in schedules)
            {
                if (sch.GradeLevel == gradelevel && sch.GradeSectionCode == int.Parse(cmbSection.SelectedValue.ToString()))
                {
                    Timeslot ts = new Timeslot();
                    ts.TimeSlotCode = sch.TimeSlotCode;
                    ts.TimeSlotInfo = sch.TimeslotInfo;
                    ts.TimeStart = sch.Timestart;
                    ts.TimeEnd = sch.TimeEnd;
                    ts.Days = sch.Days;
                    usedtslot.Add(ts);
                }
            }

            //get the list of all timeslots
            availTimeSlot = new List<Timeslot>(timeslots); //timeslots;

            //Remove timeslots that are already been used
            if (usedtslot.Count > 0)
            {
                foreach (Timeslot t in usedtslot) { 
                  string times = t.TimeSlotCode;
                 availTimeSlot.RemoveAll(a => a.TimeSlotCode == times);
                }
            }


            //Remove timeslots that are conflicting to other schedules
            #region ConflictTimeslotsFilter
            List<Timeslot> compareTimeSlot = new List<Timeslot>();
            List<String> tCodelist;

            foreach (Timeslot t in usedtslot)
            {
                string[] dayArray = t.Days.Split(',');
                int t_TimeStart = timeStringToInt(t.TimeStart);
                int t_TimeEnd = timeStringToInt(t.TimeEnd);
                compareTimeSlot = availTimeSlot;
                tCodelist = new List<String>();

                foreach (Timeslot ct in compareTimeSlot)
                {
                    foreach (string sDay in dayArray)
                    {
                        if (ct.Days.Contains(sDay))
                        {
                            int ct_TimeStart = timeStringToInt(ct.TimeStart);
                            int ct_TimeEnd = timeStringToInt(ct.TimeEnd);
                    

                            if ((ct_TimeStart <= t_TimeStart && ct_TimeEnd <= t_TimeEnd && ct_TimeEnd > t_TimeStart) ||
                                    (ct_TimeStart >= t_TimeStart && ct_TimeEnd <= t_TimeEnd) ||
                                    (ct_TimeStart >= t_TimeStart && ct_TimeStart < t_TimeEnd && ct_TimeEnd > t_TimeEnd))
                            {
                                tCodelist.Add(ct.TimeSlotCode);
                            }
                        }
                    }
                   
                }

                //Remove conflicted schedules against the used schedules
                foreach (string code in tCodelist)
                {
                    availTimeSlot.RemoveAll(x => x.TimeSlotCode == code);
                    compareTimeSlot = null;
                }
            }

            #endregion


            //assign new list of Timeslot on the dropdown box
            if (availTimeSlot.Count > 0)
            {
                cmbTimeslot.Enabled = true;
                cmbTimeslot.ValueMember = "TimeslotCode";
                cmbTimeslot.DisplayMember = "TimeslotInfo";
                cmbTimeslot.DataSource = availTimeSlot;
                cmbTimeslot.SelectedIndex = 0;
            }
        }

        //convert am && pm time to integer
        private int timeStringToInt(string szTime)
        {
            int iVal = 0;

            szTime = szTime.Replace(":", "");

            if (szTime.Substring((szTime.Length - 2), 2) == "PM")
            {
                iVal = int.Parse(szTime.Replace(" PM", ""));
                if (iVal <= 1200)
                    iVal = iVal + 1200;
                else
                    iVal = iVal + 0;
            }
            else
                iVal = int.Parse(szTime.Replace(" AM", ""));

            return iVal;
        }

        private void Disable()
        {
            DisableSome();
            cmbSection.Enabled = false;
            cmbSubject.Enabled = false;
        }

        private void DisableSome() {
            cmbTimeslot.Enabled = false;
            cmbTeacher.Enabled = false;
            cmbRoom.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedIndex = gvSchedule.CurrentRow.Index;
            
            if (selectedIndex >= 0)
            {
                int iSelectedSAid = int.Parse(gvSchedule.Rows[selectedIndex].Cells["SubjectAssignmentId"].Value.ToString());
                if (iSelectedSAid == 0)
                {
                    schedules.RemoveAll(x => x.SubjectAssignmentsID == 0 && x.SubjectCode == gvSchedule.Rows[selectedIndex].Cells["SubjectCode"].Value.ToString()
                                   && x.TimeslotInfo == gvSchedule.Rows[selectedIndex].Cells["TimeslotInfo"].Value.ToString() && x.RoomCode == gvSchedule.Rows[selectedIndex].Cells["RoomCode"].Value.ToString()
                                   && x.TeacherId == gvSchedule.Rows[selectedIndex].Cells["TeacherId"].Value.ToString() && x.Section == gvSchedule.Rows[selectedIndex].Cells["Section"].Value.ToString());

                    createdSchedule.RemoveAll(x => x.SubjectAssignmentsID == 0 && x.SubjectCode == gvSchedule.Rows[selectedIndex].Cells["SubjectCode"].Value.ToString()
                                        && x.TimeslotInfo == gvSchedule.Rows[selectedIndex].Cells["TimeslotInfo"].Value.ToString() && x.RoomCode == gvSchedule.Rows[selectedIndex].Cells["RoomCode"].Value.ToString()
                                        && x.TeacherId == gvSchedule.Rows[selectedIndex].Cells["TeacherId"].Value.ToString() && x.Section == gvSchedule.Rows[selectedIndex].Cells["Section"].Value.ToString());
                }
                else
                {
                    schedules.RemoveAll(x => x.SubjectAssignmentsID == iSelectedSAid && x.SubjectCode == gvSchedule.Rows[selectedIndex].Cells["SubjectCode"].Value.ToString()
                                   && x.TimeslotInfo == gvSchedule.Rows[selectedIndex].Cells["TimeslotInfo"].Value.ToString() && x.RoomCode == gvSchedule.Rows[selectedIndex].Cells["RoomCode"].Value.ToString()
                                   && x.TeacherId == gvSchedule.Rows[selectedIndex].Cells["TeacherId"].Value.ToString() && x.Section == gvSchedule.Rows[selectedIndex].Cells["Section"].Value.ToString());


                    ISubjectAssignmentService schedService = new SubjectAssignmentService();
                    string message = String.Empty;
                    schedService.DeleteSchedule(iSelectedSAid, ref message);
                    Log("D", "StudentSubjects", gvSchedule.Rows[selectedIndex]);
                    
                }


                InitializeLists();
                LoadSchedules();

                gvSchedule.DataSource = null;
                gvSchedule.DataSource = schedules.FindAll(x => x.GradeSectionCode == sectioncode); ;
                gvSchedule.Refresh();

            }
            
        }

        
        private void cmbGradeLevel_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbGradeLevel.SelectedIndex != -1)
            {
                gradelevel = cmbGradeLevel.SelectedValue.ToString();
                List<GradeSection> gs = new List<GradeSection>();
                List<Subject> sub = new List<Subject>();

                gs = sections.FindAll(s => s.GradeLevel == gradelevel);
                sub = subjects.FindAll(t => t.GradeLevel == gradelevel);


                cmbSection.DataSource = gs;               
                cmbSubject.DataSource = sub;

                if (gs.Count <= 0)
                {
                    cmbSection.Text = string.Empty;
                    cmbSection.Enabled = false;
                    cmbSubject.Enabled = false;
                    cmbTimeslot.Enabled = false;
                    return;
                }
                else
                {
                    cmbSection.Enabled = true;
                    cmbSubject.Enabled = true;
                   
                }
            }
        }

        private void cmbSection_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbSection.SelectedValue != null)
            {
                int iSectionCode = int.Parse(cmbSection.SelectedValue.ToString());
                List<SubjectAssignment> sa = new List<SubjectAssignment>();
                sa = new List<SubjectAssignment>(schedules.FindAll(x => x.GradeSectionCode == iSectionCode && x.GradeLevel == gradelevel));
                gvSchedule.DataSource = sa;

                string code = cmbSection.SelectedValue.ToString();
                sectioncode = Int32.Parse(code);
                section = cmbSection.Text.ToString();

                //existingSchedule = new List<SubjectAssignment>(schedules.FindAll(s => s.GradeSectionCode == sectioncode && s.SY == GlobalClass.currentsy));

                cmbTimeslot.DataSource = null;
                SetTimeSlotCombo();

            }
        }

        private void cmbTimeslot_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbTimeslot.SelectedIndex != -1)
            {
                loadAvailableRooms();
                loadAvailableTeachers();
            }
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            frmScheduleList fmCalendar = new frmScheduleList();
            fmCalendar.Show();
        }
    

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSchedule();
        }

        private void cmbSubject_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbSubject.SelectedIndex >= 0)
            {
                Subject sb = new Subject();
                sb = subjects.Find(x => x.SubjectCode == cmbSubject.SelectedValue.ToString());

                academicSubject = sb.Academic;

                //if (sb.Academic ==true)
                //{
                //    academicTeachers = new List<Teacher>(teachers.FindAll(x => x.Academic == true));
                //    cmbTeacher.DataSource = academicTeachers;
                //}
                //else
                //{
                //    cmbTeacher.DataSource = teachers;
                //}
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
    }
}
