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

namespace eSAR.Course_Related_Resources.ManageGradeLevelSection
{
    public partial class ManageGradeLevelSection : Telerik.WinControls.UI.RadForm
    {
        public String Op { get; set; }
        public GradeSection SelectedGradeSection { get; set; }
        public List<GradeLevel> gLevels;
        public List<Teacher> teachers;
        public List<Room> rooms;
        public List<SchoolYear> sys;
        public List<Teachers> tList= new List<Teachers>();
        public SchoolYear currentSy;
        

        public ManageGradeLevelSection()
        {
            InitializeComponent();
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManageGradeLevelSection_Load(object sender, EventArgs e)
        {

            SetComboBoxes();
            if (Op == "edit")
            {
                SetFields();
            }
            
        }
        private void SetFields() {
            txtSection.Text = SelectedGradeSection.Section;
            cmbGradeLevel.SelectedValue = SelectedGradeSection.GradeLevel;
            cmbSchoolYear.SelectedValue = SelectedGradeSection.SY;
            cmbRoom.SelectedValue = SelectedGradeSection.HomeRoomNumber;
            cmbTeacher.SelectedValue = SelectedGradeSection.HomeRoomTeacherId;
            cmbClass.SelectedValue = SelectedGradeSection.Class;
        }

        private void SetComboBoxes() {
            IGradeSectionService gService = new GradeSectionService();
            gLevels= new List<GradeLevel>(gService.GetAllGradeLevels());
            teachers = new List<Teacher>(gService.GetAllTeachers());
            
            sys = new List<SchoolYear>(gService.GetAllSchoolYears());
            rooms = new List<Room>(gService.GetAllRooms());
            List<int> classNum = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            cmbClass.DataSource = classNum;

            cmbGradeLevel.DataSource = gLevels;
            cmbGradeLevel.ValueMember = "GradeLev";
            cmbGradeLevel.DisplayMember = "Description";
            cmbRoom.DataSource = rooms;
            cmbRoom.ValueMember = "RoomId";
            cmbRoom.DisplayMember = "RoomCode";
            cmbSchoolYear.DataSource = sys;
            cmbSchoolYear.ValueMember = "SY";
            cmbSchoolYear.DisplayMember = "SY";

            cmbTeacher.DataSource = teachers;
            cmbTeacher.ValueMember = "TeacherID";
            cmbTeacher.DisplayMember = "TeacherName";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            GradeSection gs = new GradeSection();
          
            gs.GradeLevel = cmbGradeLevel.SelectedValue.ToString();
            gs.HomeRoomNumber = Int32.Parse(cmbRoom.SelectedValue.ToString());
            gs.HomeRoomTeacherId = cmbTeacher.SelectedValue.ToString();
            gs.Section = txtSection.Text.ToString();
            gs.SY = cmbSchoolYear.SelectedValue.ToString();
            gs.Class = Int32.Parse(cmbClass.Text.ToString());

            string message=String.Empty;
            bool ret = false;
            IGradeSectionService gservice = new GradeSectionService();
            if (Op == "edit")
            {
                gs.GradeSectionCode = SelectedGradeSection.GradeSectionCode;
                ret = gservice.UpdateGradeSection(ref gs, ref message);
                Log("U", "GradeSections", gs);
                
            }
            else
            {
               ret = gservice.CreateGradeSection(ref gs, ref message);
                Log("C", "GradeSections", gs);
                
            }

            if (ret)
            {
                MessageBox.Show(this, "Saved Successfully");
                this.Close();
            }
            else
                MessageBox.Show(this, "Error in saving");
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

    public class Teachers {
        public String TeacherID { get; set; }
        public String TeacherName { get; set; }
    }
}
