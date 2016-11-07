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

namespace eSAR.Course_Related_Resources.ManageTeachers
{
    public partial class frmTeacherList : Telerik.WinControls.UI.RadForm
    {
        private Teacher teacherSelected;
        private List<Teacher> teacherList;

        

        public frmTeacherList()
        {
            InitializeComponent();
        }


        public void LoadTeachers()
        {
            ITeacherService teacherService = new TeacherService();
            string message = String.Empty;
            try
            {
                var teachers = teacherService.GetAllTeachers();
                teacherList = new List<Teacher>(teachers);
                gvTeacher.DataSource = teachers;
                gvTeacher.Refresh();

                if (gvTeacher.RowCount != 0)
                    gvTeacher.Rows[0].IsSelected = true;
            }
            catch (Exception ex)
            {
                message = "Error Loading Faculty List";
                MessageBox.Show(ex.ToString());
            }

        }

   
        private void frmTeacherList_Activated(object sender, EventArgs e)
        {
            //LoadTeachers();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmTeacherDetails fmTeacherDetails = new frmTeacherDetails();
            fmTeacherDetails.Op = "new";
            fmTeacherDetails.ShowDialog(this);
        }

        private void frmTeacherList_Load(object sender, EventArgs e)
        {
            LoadTeachers();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gvTeacher.CurrentRow.Index >= 0)
            {
                frmTeacherDetails fmTeacherDetails = new frmTeacherDetails();
                fmTeacherDetails.Op = "edit";
                fmTeacherDetails.SelectedTeacher = teacherSelected;
                fmTeacherDetails.ShowDialog(this);
            }
        }

        private void gvTeacher_SelectionChanged(object sender, EventArgs e)
        {
            int selectedIndex = -1;

            if (gvTeacher.CurrentRow != null)
                selectedIndex = gvTeacher.CurrentRow.Index;


            if (selectedIndex >= 0)
            {
                string tID = gvTeacher.Rows[selectedIndex].Cells["TeacherId"].Value.ToString();
                List<Teacher> item = new List<Teacher>();
                item = teacherList.FindAll(x => x.TeacherId.ToString() == tID);

                teacherSelected = new Teacher();
                teacherSelected = (Teacher)item[0];

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (teacherSelected != null)
            {
                ITeacherService teacherService = new TeacherService();
                string message = String.Empty;

                if (!teacherService.DeactivateTeacher(teacherSelected.TeacherId, ref message))
                {
                    teacherSelected.Deactivated = true;
                    Log("D", "Teachers", teacherSelected);
                    
                    MessageBox.Show("Deactivation of User Failed");
                }
                else
                {
                    MessageBox.Show("Deactivated succesfully!");
                }
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
