using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Newtonsoft.Json;
using eSAR.Reports.GenerateStudentPermanentRecord;
using eSARServices;
using eSARServiceInterface;
using eSARServiceModels;
using eSAR.Utility_Classes;
using Telerik.WinControls.UI;
using Telerik.WinControls.Data;

namespace eSAR.Admission_and_Registration
{
    public partial class frmStudentList : Telerik.WinControls.UI.RadForm
    {
        private List<string> RegisteredStudents;
        private Student studentSelected;
        private List<Student> studentList;
        List<GradeLevel> gradeLevel;
        List<GradeSection> sections;

        public frmStudentList()
        {
            InitializeComponent();
            if (GlobalClass.userTypeCode == "cash")
            {
                this.btnRegister.Enabled = false;
                this.btnControl.Enabled = false;
                this.btnAdd.Enabled = false;
                this.btnEdit.Enabled = false;
                this.btnDelete.Enabled = false;
                this.btnGenerate.Enabled = false;
            }
            else if (GlobalClass.userTypeCode == "reg")
            {
                this.btnAssess.Enabled = false;
                this.btnGenerate.Enabled = false;
            }
            else if (GlobalClass.userTypeCode == "princ") {
                this.btnGenerate.Enabled = true;
            }
            else if (GlobalClass.userTypeCode == "teach")
            {
                this.btnGenerate.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmStudentDetails fmStudentDetails = new frmStudentDetails();
            fmStudentDetails.Op = "new";
            fmStudentDetails.ShowDialog(this);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gvStudent.CurrentRow == null)
                return;

            if (gvStudent.CurrentRow.Index >= 0 && GlobalClass.userTypeCode != "cash")
            {
                frmStudentDetails fmStudentDetails = new frmStudentDetails();
                fmStudentDetails.Op = "edit";
                fmStudentDetails.SelectedStudent = studentSelected;
                fmStudentDetails.ShowDialog(this);
            }
        }

        private void frmStudentList_Load(object sender, EventArgs e)
        {
            LoadStudents();   
          
        }

        public void LoadStudents()
        {
            IGradeLevelService glService = new GradeLevelService();
            gradeLevel = new List<GradeLevel>(glService.GetAllGradeLevels());
            if (gradeLevel.Count > 0)
                gradeLevel[0].Description = "None";

            IGradeSectionService sectionService = new GradeSectionService();
            sections = new List<GradeSection>(sectionService.GetAllGradeSections());

            IRegistrationService registrationService = new RegistrationService();
            RegisteredStudents= new List<string>(registrationService.GetEnrolledStudents(GlobalClass.currentsy));
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

        private void frmStudentList_Activated(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void gvStudent_SelectionChanged(object sender, EventArgs e)
        {
            int selectedIndex = gvStudent.CurrentRow.Index;
            
            if (selectedIndex >= 0)
            {
                string sID = gvStudent.Rows[selectedIndex].Cells["StudentId"].Value.ToString();
                List<Student> item = new List<Student>();
                item = studentList.FindAll(x => x.StudentId.ToString() == sID);

                studentSelected = new Student();
                studentSelected = (Student)item[0];

            }
        }

       

        private void btnAssess_Click(object sender, EventArgs e)
        {
            if (gvStudent.CurrentRow == null)
                return;

            if (gvStudent.CurrentRow.Index >= 0)
            {
                if (!RegisteredStudents.Contains(studentSelected.StudentId))
                    MessageBox.Show(this, "Student Should be Registered First!");
                else
                {
                    AssessStudent fmAssessment = new AssessStudent();
                    fmAssessment.StudentId = studentSelected.StudentId;
                    fmAssessment.ShowDialog(this);
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (gvStudent.CurrentRow == null)
                return;

            if (gvStudent.CurrentRow.Index >= 0)
            {
                String next = "";
                if (String.IsNullOrEmpty(studentSelected.GradeLevel))
                {
                    if (!(String.IsNullOrEmpty(studentSelected.GradeBeforeDC)))
                    {
                        next = getNext(studentSelected.GradeBeforeDC);

                    }
                    else {
                        next = "N";
                    }
                }
                List<GradeSection> gradeSec = sections.FindAll(p => p.GradeLevel.Equals(next));
                if (RegisteredStudents.Contains(studentSelected.StudentId))
                {
                    MessageBox.Show(this, "Student Already Registered!");
                }
                else if (gradeSec.Count == 0)
                {
                    MessageBox.Show("Cannot register student, No Section created yet. \n Please contact admin.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    frmStudentRegister fmStudentRegister = new frmStudentRegister();
                    fmStudentRegister.StudentId = studentSelected.StudentId;
                    //  if(String.IsNullOrEmpty(studentSelected.GradeLevel))

                    fmStudentRegister.GradeLevel = studentSelected.GradeLevel;
                    fmStudentRegister.RegisterStudent = studentSelected;
                    fmStudentRegister.Gender = studentSelected.Gender;
                    fmStudentRegister.Show(this);
                }
            }
        }
        private String getNext(String g)
        {
            GradeLevelService gls = new GradeLevelService();
            GradeLevel grade = gls.NextGradeLevel(g);
            return grade.GradeLev;


            //switch (g)
            //{
            //    case "0":
            //        return "N";
            //    case "N":
            //        return "K1";
                    
            //    case "K1":
            //        return "K2";
                    
            //    case "K2":
            //        return "1";
                    
            //    case "1":
            //        return "2";
                    
            //    case "2":
            //        return "3";
                    
            //    case "3":
            //        return "4";
                    
            //    case "4":
            //        return "5";
                    
            //    case "5":
            //        return "6";
            //    case "6":
            //        return "7";
                    
            //    case "8":
            //        return "9";
                    
            //    case "9":
            //        return "10";
            //    default: return null;

            //}
        }


        private void btnControl_Click(object sender, EventArgs e)
        {
            if (gvStudent.CurrentRow == null)
                return;

            if (gvStudent.CurrentRow.Index >= 0)
            {
                if (!RegisteredStudents.Contains(studentSelected.StudentId))
                    MessageBox.Show(this, "Student Needs to be Registered First!");
                else
                {
                    frmControlSubjects fmControlSubjects = new frmControlSubjects();
                    fmControlSubjects.controlStudentId = studentSelected.StudentId;

                    fmControlSubjects.ShowDialog(this);
                }
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (gvStudent.CurrentRow == null)
                return;

            string message = String.Empty;
            IStudentService studentService = new StudentService();
            if (studentService.DismissStudent(studentSelected.StudentId, ref message)) {
                ILogService logService = new LogService();
                studentSelected.Dismissed = true;
                string json = JsonConvert.SerializeObject(studentSelected);
                Log log = new Log
                {
                    CLUD = "D",
                    LogDate = DateTime.Now,
                    TableName = "Students",
                    UserId = GlobalClass.user.UserId,
                    UserName = GlobalClass.user.UserName,
                    PassedData = json
                };
                logService.AddLogs(log);

            }

            MessageBox.Show(this, "Student Dismissed");
                        
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

        private void gvStudent_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            string szGradeLev = string.Empty; 
            GradeLevel gl;
            foreach (GridViewRowInfo rowInfo in gvStudent.Rows)
            {
                foreach (GridViewCellInfo cellInfo in rowInfo.Cells)
                {
                    
                    gl = new GradeLevel();

                    if (cellInfo.ColumnInfo.Name == "GradeLevel")
                    {
                        szGradeLev = string.Empty;
                        if (cellInfo.Value != null)
                            szGradeLev = cellInfo.Value.ToString();
                    }

                    if (cellInfo.ColumnInfo.Name == "GradeBeforeDC")
                    {
                        if (cellInfo.Value != null)
                            if (szGradeLev == string.Empty || szGradeLev == null)
                                szGradeLev = cellInfo.Value.ToString();
                    }


                    if (cellInfo.ColumnInfo.Name == "GradeLevelDesc")
                    {
                        if (szGradeLev == string.Empty || szGradeLev == null)
                            cellInfo.Value = string.Empty;
                        else
                        {
                            gl = gradeLevel.Find(x => x.GradeLev == szGradeLev);
                            cellInfo.Value = gl.Description;
                        }
                    }
                }
            }
        }
    }
}
