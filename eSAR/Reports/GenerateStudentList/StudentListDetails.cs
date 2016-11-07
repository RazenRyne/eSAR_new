using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using eSARServices;
using eSARServiceInterface;
using eSARServiceModels;
using eSAR.Utility_Classes;

namespace eSAR.Reports.GenerateStudentList
{
    public partial class StudentListDetails : Telerik.WinControls.UI.RadForm
    {
        public String Op { get; set; }
        public SubjectAssignment SelectedSchedule { get; set; }
         List<SchoolYear> syList;
        public string currentSY;
        public string gradelevel;
        public string section;
        public int sectioncode;


        public StudentListDetails()
        {
            InitializeComponent();
            InitializeLists();
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void InitializeLists()
        {
            ISubjectAssignmentService schedService = new SubjectAssignmentService();
            
            syList = new List<SchoolYear>(schedService.GetAllSY());
        }

        private void LoadMe(object sender, EventArgs e)
        {
            SetComboBoxes();
        }

        private void SetComboBoxes()
        {
            cmbSY.DataSource = syList;
            if (syList.Count > 0)
                cmbSY.Text = GlobalClass.currentsy;
            else
                cmbSY.Enabled = false;
            
        }

     

      


        private void btnClose_Click(object sender, EventArgs e)
        {
            GlobalClass.WindowStudentListDetails = false;
            this.Close();
        }

   
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            switch (cmbReportType.Text)
            {
                case "Grid":
                    GridReport gR = new GridReport();
                    gR.setVars(cmbGroupBy.Text, cmbSY.Text);
                    gR.Show();
                    break;
                case "Bar Chart":
                    BarChart bC = new BarChart();
                    bC.setVars(cmbGroupBy.Text, cmbSY.Text);
                    bC.Show();
                    break;
                case "Line Chart":
                    LineChart lC = new LineChart();
                    lC.setVars(cmbGroupBy.Text, cmbSY.Text);
                    lC.Show();
                    break;
                case "Pie Chart":
                    PieChart pC = new PieChart();
                    pC.setVars(cmbGroupBy.Text, cmbSY.Text);
                    pC.Show();
                    break;
            }
        }

        private void cmbReportType_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
