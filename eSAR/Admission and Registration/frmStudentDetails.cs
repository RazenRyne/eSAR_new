using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Newtonsoft.Json;
using eSAR.Utility_Classes;
using eSARServices;
using eSARServiceInterface;
using eSARServiceModels;

namespace eSAR.Admission_and_Registration
{
    public partial class frmStudentDetails : Telerik.WinControls.UI.RadForm
    {
        private string szStudentID = string.Empty;
        private Image img = null;
        public string Op { get; set; }
        public Student SelectedStudent { get; set; }

        List<GradeLevel> gradeLevel;

        public frmStudentDetails()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

 
        private void frmStudentDetails_Load(object sender, EventArgs e)
        {
            pvStudent.SelectedPage = pvStudent.Pages[0];

            IGradeLevelService glService = new GradeLevelService();
            gradeLevel = new List<GradeLevel>(glService.GetAllGradeLevels());
            if (gradeLevel.Count > 0)
                gradeLevel[0].Description = "None";

            cmbGradeLevel.DataSource = gradeLevel;
            cmbGradeLevel.ValueMember = "GradeLev";
            cmbGradeLevel.DisplayMember = "Description";

          
            if (Op.Equals("new"))
            {
                GenerateStudentID();
                cmbGradeLevel.SelectedIndex = 0;
                btnEditID.Visible = false;
            }

            if (Op.Equals("edit"))
            {
                SetFields();
            }
        }

        private void SetFields()
        {
          
            txtStudentId.Enabled = false;
            txtStudentId.Text = SelectedStudent.StudentId;
            txtLRN.Text = SelectedStudent.StudentLRN;
            txtFirstName.Text = SelectedStudent.FirstName;
            txtMiddleName.Text = SelectedStudent.MiddleName;
            txtLastName.Text = SelectedStudent.LastName;
            txtSchoolLastAttended.Text = SelectedStudent.SchoolLastAttended;
            txtPrevGPA.Text =SelectedStudent.Average.ToString();
            cmbGradeLevel.SelectedValue = SelectedStudent.GradeBeforeDC;
            if (SelectedStudent.Image != null)
            {
                img = byteArrayToImage(SelectedStudent.Image);
                pbImage.BackgroundImage = ResizeImage(100, 100, img);
            }
            if (SelectedStudent.Gender == "M")
                cmbGender.Text = "Male";
            if (SelectedStudent.Gender == "F")
                cmbGender.Text = "Female";
            dtDOB.Value = (DateTime)SelectedStudent.DOB;
            cbReligion.Text = SelectedStudent.Religion;
            if (SelectedStudent.MadrasahEnrolled == true)
                chkMadrasah.Checked = true;
            else
                chkMadrasah.Checked = false;

            if (SelectedStudent.Card == true)
                chkReportCard.Checked = true;
            else
                chkReportCard.Checked = false;

            if (SelectedStudent.GoodMoral == true)
                chkGoodMoral.Checked = true;
            else
                chkGoodMoral.Checked = false;

            if (SelectedStudent.BirthCertificate == true)
                chkBirthCertificate.Checked = true;
            else
                chkBirthCertificate.Checked = false;

            txtPOB_Street.Text = SelectedStudent.POBAddress;
            txtPOB_Town.Text = SelectedStudent.POBTownCity;
            txtPOB_Province.Text = SelectedStudent.POBProvince;
            txtPOB_Brgy.Text = SelectedStudent.POBBarangay;

            txtHA_Street.Text = SelectedStudent.HomeAddress;
            txtHA_Brgy.Text = SelectedStudent.HomeBarangay;
            txtHA_Town.Text = SelectedStudent.HomeTownCity;
            txtHA_Province.Text = SelectedStudent.HomeProvince;
            
            txtFather_FullName.Text = SelectedStudent.FathersName;
            txtFather_Occupation.Text = SelectedStudent.FathersOccupation;
            txtFather_EducAttainment.Text = SelectedStudent.FathersEducation;
            txtFather_Income.Text = SelectedStudent.FathersAverageYearlyIncome.ToString();

            txtMother_FullName.Text = SelectedStudent.MothersMaidenName;
            txtMother_Occupation.Text = SelectedStudent.MothersOccupation;
            txtMother_Income.Text = SelectedStudent.MothersAverageYearlyIncome.ToString();
            txtMother_EducAttainment.Text = SelectedStudent.MothersEducation;


            txtGuardian_FullName.Text = SelectedStudent.GuardiansName;
            txtGuardian_Income.Text = SelectedStudent.GuardiansAverageYearlyIncome.ToString();
            txtGuardian_Occupation.Text = SelectedStudent.GuardiansOccupation;
            txtCurrentGradeLevel.Text = SelectedStudent.GradeLevel;
            if (SelectedStudent.GradeLevel != null)
            {
                radLabel6.Visible = false;
                cmbGradeLevel.Visible = false;
            }
        }

        private void GenerateStudentID()
        {
            IStudentService studentService = new StudentService();
            szStudentID = studentService.GenerateStudentId();
            txtStudentId.Text = szStudentID;
        }

        private void btnInsertImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "BMP Files (*.bmp, *.dib, *.rle|*.bmp;*.dib;*.rle|" +
                                   "JPEG Files (*.jpg,*.jpeg,*.jpe, *.jfif|*.jpg;*.jpeg;*.jpe;*.jfif|" +
                                   "GIF Files (*.gif)|*.gif|" +
                                   "PNG Files (*.png)|*.png|" +
                                   "All Files (*.*)|*.*";
            DialogResult res = openFileDialog1.ShowDialog();

            if (res == DialogResult.OK)
            {
                pbImage.BackgroundImage = ResizeImage(100, 100, Image.FromFile(openFileDialog1.FileName));
            }
        }

        //convert image to byte array
        public byte[] imageToByteArray(System.Drawing.Image imageIn, System.Drawing.Imaging.ImageFormat imgFormat)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, imgFormat);
            ms.Dispose();
            ms.Close();
            return ms.ToArray();
        }

        //convert byte array to image
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        //Image resizing
        public static System.Drawing.Image ResizeImage(int maxWidth, int maxHeight, System.Drawing.Image Image)
        {
            int width = Image.Width;
            int height = Image.Height;
            if (width > maxWidth || height > maxHeight)
            {
                //The flips are in here to prevent any embedded image thumbnails -- usually from cameras
                //from displaying as the thumbnail image later, in other words, we want a clean
                //resize, not a grainy one.
                Image.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipX);
                Image.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipX);

                float ratio = 0;
                if (width > height)
                {
                    ratio = (float)width / (float)height;
                    width = maxWidth;
                    height = Convert.ToInt32(Math.Round((float)width / ratio));
                }
                else
                {
                    ratio = (float)height / (float)width;
                    height = maxHeight;
                    width = Convert.ToInt32(Math.Round((float)height / ratio));
                }

                //return the resized image
                return Image.GetThumbnailImage(width, height, null, IntPtr.Zero);
            }


            //return the original resized image
            return Image;
        }

        private void txtStudentId_Leave(object sender, EventArgs e)
        {
            Student student = new Student();
            string msg = string.Empty;
            IStudentService studentService = new StudentService();

            if (txtStudentId.Text == string.Empty) txtStudentId.Text = szStudentID;


            student = studentService.GetStudent(txtStudentId.Text, ref msg);
            if (student.StudentId != null)
            {
                MessageBox.Show("Student ID already exist!");
                txtStudentId.Text = szStudentID;
                txtStudentId.Focus();
                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFirstName.Text) && !string.IsNullOrEmpty(txtLastName.Text) && cmbGradeLevel.SelectedIndex>=0 && !string.IsNullOrEmpty(txtPrevGPA.Text))
                Save();
            else
            {
                MessageBox.Show("First Name, Last Name and Grade Level should not be empty");
                return;
            }
        }

        private void Save()
        {
            string szGender = string.Empty;
            if (cmbGender.Text == "Female") szGender = "F";
            if (cmbGender.Text == "Male") szGender = "M";
            Boolean ret = false;
            string message = String.Empty;

            byte[] bImage = null;
            if (pbImage.BackgroundImage != null) bImage = imageToByteArray(pbImage.BackgroundImage, ImageFormat.Png);
            var convertDecimal = Convert.ToDecimal(txtFail.Text);
            IStudentService studentService = new StudentService();
            int schoId= studentService.GetScholarshipDiscountId("none");
            Student student = new Student();

            student.StudentId = txtStudentId.Text;
            student.FirstName = txtFirstName.Text;
            student.MiddleName = txtMiddleName.Text;
            student.LastName = txtLastName.Text;
            student.Average = double.Parse(txtPrevGPA.Text);
            student.Image = bImage;
            student.SchoolLastAttended = txtSchoolLastAttended.Text;
            student.GradeBeforeDC = cmbGradeLevel.SelectedValue.ToString();
            student.DOB = dtDOB.Value;
            student.MadrasahEnrolled = chkMadrasah.Checked;
            student.Card = chkReportCard.Checked;
            student.GoodMoral = chkGoodMoral.Checked;
            student.Gender = szGender;
            student.BirthCertificate = chkBirthCertificate.Checked;
            student.POBAddress = txtPOB_Street.Text;
            student.POBBarangay = txtPOB_Brgy.Text;
            student.POBProvince = txtPOB_Province.Text;
            student.POBTownCity = txtPOB_Town.Text;
            student.HomeAddress = txtHA_Street.Text;
            student.HomeProvince = txtHA_Province.Text;
            student.HomeBarangay = txtHA_Brgy.Text;
            student.HomeTownCity = txtHA_Town.Text;
            student.FathersName = txtFather_FullName.Text;
            student.FathersOccupation = txtFather_Occupation.Text;
            student.FathersAverageYearlyIncome = double.Parse(txtFather_Income.Text);
            student.FathersEducation = txtFather_EducAttainment.Text;
            student.MothersMaidenName = txtMother_FullName.Text;
            student.MothersEducation = txtMother_EducAttainment.Text;
            student.MothersOccupation = txtMother_Occupation.Text;
            student.MothersAverageYearlyIncome = double.Parse(txtMother_Income.Text);
            student.GuardiansName = txtGuardian_FullName.Text;
            student.GuardiansOccupation = txtGuardian_Occupation.Text;
            student.GuardiansAverageYearlyIncome = double.Parse(txtGuardian_Income.Text);
            student.ScholarshipDiscountId = schoId;
            student.UnitsFailedLastYear = convertDecimal;
            student.DateAdmitted = System.DateTime.Now;
            student.Religion = cbReligion.Text;
            student.StudentLRN = txtLRN.Text;


            if (Op.Equals("edit"))
            {
                student.GradeLevel = SelectedStudent.GradeLevel;
                student.Section = SelectedStudent.Section;
                ret = studentService.UpdateStudent(ref student, ref message);
                Log("U", "Students", student);
                
            }
            else
            {
                ret = studentService.CreateStudent(ref student, ref message);
                Log("C", "Students", student);
              
            }
            if (ret)
                MessageBox.Show("Saved Successfully");
            else
                MessageBox.Show("Error Saving");

            Close();
        }

        private void txtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            RadTextBox textBox = (RadTextBox)sender;
            // only allow one decimal point
            if (e.KeyChar == '.' && textBox.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            if (!char.IsControl(e.KeyChar) && textBox.SelectionLength == 0)
            {
                if (textBox.Text.IndexOf('.') > -1 && textBox.Text.Substring(textBox.Text.IndexOf('.')).Length >= 3)
                {
                    e.Handled = true;
                }
            }
        }

        private void txtFather_Income_TextChanged(object sender, EventArgs e)
        {
            if (txtFather_Income.Text == string.Empty) txtFather_Income.Text = "0";
        }

        private void txtMother_Income_TextChanged(object sender, EventArgs e)
        {
            if (txtMother_Income.Text == string.Empty) txtMother_Income.Text = "0";
        }

        private void txtGuardian_Income_TextChanged(object sender, EventArgs e)
        {
            if (txtGuardian_Income.Text == string.Empty) txtGuardian_Income.Text = "0";
        }

        private void txtStudentId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private int calculateAge(DateTime dob)
        {
            int ageInYears = 0;

            ageInYears = DateTime.Now.Year - dob.Year;
            
            if (ageInYears > 0)
            {
                if (DateTime.Now.Month < dob.Month)
                    ageInYears--;

                if (DateTime.Now.Month == dob.Month)
                    if (DateTime.Now.Day < dob.Day)
                        ageInYears--;
            }
            else
                ageInYears = 0;
          

            return ageInYears;
        }

     
        private void btnPromote_Click(object sender, EventArgs e)
        {
            frmStudentRegister fmStudentRegister = new frmStudentRegister();
            fmStudentRegister.Show(this);
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

        private void txtPrevGPA_TextChanged(object sender, EventArgs e)
        {
            if (txtPrevGPA.Text == string.Empty) txtPrevGPA.Text = "0";
        }

        private void txtFail_TextChanged(object sender, EventArgs e)
        {
            if (txtFail.Text == string.Empty) txtFail.Text = "0";
        }

       
    }
}
 