using eSARServices;
using eSARServiceInterface;
using eSARServiceModels;
using eSAR.Utility_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace eSAR.Reports.GenerateStudentPermanentRecord
{
    public partial class frmStudentSelection : Telerik.WinControls.UI.RadForm
    {
        private Student studentSelected;
        private List<Student> studentList;

        public frmStudentSelection()
        {
            InitializeComponent();
        }

        public void LoadStudents()
        {
            IStudentService studentService = new StudentService();
            string message = String.Empty;
            try
            {
                var students = studentService.GetAllStudents();
                studentList = new List<Student>(students);
                gvStudent.DataSource = students;
                gvStudent.Refresh();

                if (gvStudent.RowCount != 0)
                    gvStudent.Rows[0].IsSelected = true;
            }
            catch (Exception ex)
            {
                message = "Error Loading Student List";
                MessageBox.Show(ex.ToString());
            }

        }

        private void frmStudentSelection_Load(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void frmStudentSelection_Activated(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void gvStudent_SelectionChanged(object sender, EventArgs e)
        {
            int selectedIndex = gvStudent.CurrentRow.Index;

            if (selectedIndex >= 0)
            {
                string sID = gvStudent.Rows[selectedIndex].Cells["StudentId"].Value.ToString();
                studentSelected = studentList.Find(x => x.StudentId.ToString() == sID);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (studentSelected != null)
            {
                GeneratePermanentRec gpr = new GeneratePermanentRec();
                gpr._studentID = studentSelected.StudentId;
                gpr.Show();
            }
        }
    }
}
