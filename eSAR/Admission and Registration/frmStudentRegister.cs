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

namespace eSAR.Admission_and_Registration
{
    public partial class frmStudentRegister : Telerik.WinControls.UI.RadForm
    {
        Student RegStude = new Student();
        public List<string> EnrolledStudents = new List<string>();
        public string StudentId { get; set; }
        public Student RegisterStudent
        {
            get { return this.RegStude; }
            set { RegStude = value; }
        }

        public List<GradeSection> sectionsForGradeLevel = new List<GradeSection>();
        public string SY { get; set; }
        List<ScholarshipDiscount> Discounts;
        public string GradeLevel { get; set; }
        public string Gender { get; set; }
        public StudentEnrollment EnrolMe = new StudentEnrollment();
        

        public frmStudentRegister()
        {
            
            InitializeComponent();
        }

        private void Promote()
        {
            if (String.IsNullOrEmpty(RegisterStudent.GradeLevel)) 
                     RegisterStudent.GradeLevel =RegisterStudent.GradeBeforeDC;
                                
            switch (RegisterStudent.GradeLevel)
            {
                case "0": GradeLevel="N";
                    break;
                case "N":
                    GradeLevel = "K1";
                    break;
                case "K1":
                    GradeLevel = "K2";
                    break;
                case "K2":
                    GradeLevel = "1";
                    break;
                case "1":
                    GradeLevel = "2";
                    break;
                case "2":
                    GradeLevel = "3";
                    break;
                case "3":
                    GradeLevel = "4";
                    break;
                case "4":
                    GradeLevel = "5";
                    break;
                case "5":
                    GradeLevel = "6";
                    break;
                case "6":
                    GradeLevel = "7";
                    break;
                case "8":
                    GradeLevel = "9";
                    break;
                case "9":
                    GradeLevel = "10";
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (sectionsForGradeLevel.Count > 0)
            {

                IRegistrationService registrationService = new RegistrationService();

                EnrolMe.StudentSY = RegisterStudent.StudentId + SY;
                EnrolMe.StudentId = RegisterStudent.StudentId;
                EnrolMe.SY = SY;
                EnrolMe.GradeLevel = GradeLevel;
                EnrolMe.Dismissed = false;
                if (!String.IsNullOrEmpty(cmbScholarship.SelectedValue.ToString()))
                {
                    EnrolMe.DiscountId = Int32.Parse(cmbScholarship.SelectedValue.ToString());
                }
                EnrolMe.Rank = (int)RegisterStudent.ranking;
                //EnrolMe.GradeSectionCode=
                if (EnrolMe.Stat.Equals("b") || EnrolMe.Stat.Equals("c"))
                {
                    if (registrationService.EnrolStudent(EnrolMe))
                    {
                        Log("C", "StudentEnrolments", EnrolMe);
                        Log("U", "Students", EnrolMe);
                        Log("C", "StudentTraits", EnrolMe);

                        MessageBox.Show(this, "Student Successfully Registered.");
                        //frmControlSubjects fmControlSubjects = new frmControlSubjects();
                        //fmControlSubjects.controlStudentId = RegisterStudent.StudentId;
                        //  fmControlSubjects.changed = false;
                       // fmControlSubjects.ShowDialog(this);

                    }
                    else
                    {
                        MessageBox.Show(this, "Student Registration Failed.");
                    }
                }
                else
                {
                    if (registrationService.EnrolStudent(EnrolMe))
                    {
                        Log("C", "StudentEnrolments", EnrolMe);
                        Log("U", "Students", EnrolMe);
                        Log("C", "StudentTraits", EnrolMe);

                        MessageBox.Show(this, "Student Successfully Registered.");

                       // frmControlSubjects fmControlSubjects = new frmControlSubjects();
                        //fmControlSubjects.controlStudentId = RegisterStudent.StudentId;
                        //  fmControlSubjects.changed = false;
                      //  fmControlSubjects.ShowDialog(this);


                    }
                    else
                        MessageBox.Show(this, "Student Registration Failed.");
                }
            }
            else MessageBox.Show(this, "Student Registration Failed: No sections for GradeLevel " + GradeLevel);
            this.Close();
        }

        private void frmStudentRegister_Load(object sender, EventArgs e)
        {
            IRegistrationService registrationService = new RegistrationService();
            IGradeSectionService gsService = new GradeSectionService();
            
            if (String.IsNullOrEmpty(RegisterStudent.GradeLevel))
            {
                chkRetain.Checked = false;
                chkPromote.Checked = true;
                chkIrreg.Checked = false;
                Promote();
                EnrolMe.Stat = "a";
            }
            else
            {
                
                RegisterStudent =registrationService.StudentInfoWithRank(StudentId,GradeLevel,Gender);
               
                decimal cri = 3.50M;
          
                if (RegisterStudent.UnitsFailedLastYear.CompareTo(0.0M) == 0)
                {
                    chkRetain.Checked = false;
                    chkPromote.Checked = true;
                    chkIrreg.Checked = false;
                    Promote();
                    EnrolMe.Stat = "a";
                }
                else if (RegisterStudent.UnitsFailedLastYear.CompareTo(cri) > 0)
                {
                    chkRetain.Checked = true;
                    chkPromote.Checked = false;
                    chkIrreg.Checked = false;
                    EnrolMe.Stat = "c";
                    GradeLevel = RegisterStudent.GradeLevel;
                }
                else if (RegisterStudent.UnitsFailedLastYear.CompareTo(cri) <= 0)
                {
                    chkRetain.Checked = false;
                    chkPromote.Checked = false;
                    chkIrreg.Checked = true;
                    Promote();
                    EnrolMe.Stat = "b";
                }
            }
            SY = GlobalClass.currentsy;
            Discounts = new List<ScholarshipDiscount>(registrationService.GetScholarshipDiscounts());

            txtSY.Text = SY;
            txtStudentId.Text = RegisterStudent.StudentId;
            txtName.Text = RegisterStudent.LastName + "," + RegisterStudent.FirstName + " " + RegisterStudent.MiddleName;
            txtGpa.Text = RegisterStudent.Average.ToString();
            txtFailed.Text = RegisterStudent.UnitsFailedLastYear.ToString();
            txtranking.Text = RegisterStudent.ranking.ToString();
            txtPrevGradeLevel.Text = RegisterStudent.GradeLevel;
            cmbScholarship.DataSource = Discounts;
            cmbScholarship.ValueMember = "ScholarshipDiscountId";
            cmbScholarship.DisplayMember = "Scholarship";
            cmbScholarship.SelectedValue = RegisterStudent.ScholarshipDiscountId;
            sectionsForGradeLevel = gsService.GetAllSectionsForGrade(GradeLevel);
        }

        private Boolean IsNew(Student student)
        {
            if (String.IsNullOrEmpty(student.GradeLevel))
                return true;
            else return false;
        }
        private void radButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbScholarship_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

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
