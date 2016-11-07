using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using eSAR.Utility_Classes;
using eSARServices;
using eSARServiceInterface;
using eSARServiceModels;

namespace eSAR.Admission_and_Registration
{
    public partial class ScheduleSelector : Telerik.WinControls.UI.RadForm
    {
        List<StudentSchedule> Schedules = new List<StudentSchedule>();
        public List<StudentSchedule> ControlSched = new List<StudentSchedule>();
        public List<StudentSchedule> AddToSched = new List<StudentSchedule>();
        public string Sy { get; set; }
        public int ds { get; set; }

        public Student ControlStudent { get; set; }

        public ScheduleSelector()
        {
            InitializeComponent();
        }

        private void ScheduleSelector_Load(object sender, EventArgs e)
        {
            Sy = GlobalClass.currentsy;
            IRegistrationService regService = new RegistrationService();
            Schedules=new List<StudentSchedule>(regService.GetSubjectSchedules(Sy));
            gvSchedule.DataSource = Schedules;
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

            int i = gvSchedule.CurrentRow.Index;
            StudentSchedule sa = Schedules[i];
            RadCheckBoxEditor cbEditor = sender as RadCheckBoxEditor;
            if ((Telerik.WinControls.Enumerations.ToggleState)cbEditor.Value == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                int index = -1;
                index = ControlSched.FindIndex(item => item.TimeSlotCode.Substring(0, 2) == sa.TimeSlotCode.Substring(0, 2));

                if (index == -1)
                {
                    Schedules[i].Selected = true;
                    AddToSched.Add(Schedules[i]);
                }
                else
                {
                    MessageBox.Show(this, "Schedule Selected is Conflicting. Select another schedule");
                    cbEditor.Value = Telerik.WinControls.Enumerations.ToggleState.Off;
                }
            }
            else if ((Telerik.WinControls.Enumerations.ToggleState)cbEditor.Value == Telerik.WinControls.Enumerations.ToggleState.Off)
            {
                AddToSched.Remove(sa);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            frmControlSubjects fmControlSubjects = new frmControlSubjects();
            if (GlobalClass.gvDatasource == 1)
                fmControlSubjects.Schedule = AddToSched;

            if (GlobalClass.gvDatasource == 2)
            {
                ControlSched.AddRange(AddToSched);
                fmControlSubjects.AddedSched = AddToSched;
              
            }

            if (GlobalClass.gvDatasource == 3)
                fmControlSubjects.ControlSchedule = AddToSched;

            GlobalClass.fromScreen = "Selector";
            fmControlSubjects.controlStudentId = this.ControlStudent.StudentId;
           
            fmControlSubjects.Show();
            this.Close();
           
        }
    }
}
