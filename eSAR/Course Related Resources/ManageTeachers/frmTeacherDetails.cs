using eSAR.Utility_Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using eSARServices;
using eSARServiceInterface;
using eSARServiceModels;

namespace eSAR.Course_Related_Resources.ManageTeachers
{

    public partial class frmTeacherDetails : Telerik.WinControls.UI.RadForm
    {
        private string szTeacherID = string.Empty;
        private Image img = null;

        class RegionDic
        {
            public string RegionNumber { get; set; }
            public string Region { get; set; }
        }

        private List<RegionDic> regions = new List<RegionDic>()
         {
                new RegionDic() {RegionNumber="ARMM",Region="Autonomous Region in Muslim Mindanao"  },
                new RegionDic() {RegionNumber="CAR",Region="Cordillera Administrative Region"  },
                new RegionDic() {RegionNumber="NCR",Region="National Capital Region"  },
                new RegionDic() {RegionNumber="NIR",Region="Negros Island Region"  },
                new RegionDic(){RegionNumber="Region I",Region="Ilocos Region" },
                new RegionDic(){RegionNumber="Region II",Region="Cagayan Valley" },
                new RegionDic() {RegionNumber="Region III",Region="Central Luzon"  },
                new RegionDic() {RegionNumber="Region IV-A",Region="CALABARZON"  },
                new RegionDic() {RegionNumber="Region IV-B",Region="MIMAROPA"  },
                new RegionDic() {RegionNumber="Region V",Region="Bicol Region"  },
                new RegionDic() {RegionNumber="Region VI",Region="Western Visayas"  },
                new RegionDic() {RegionNumber="Region VII",Region="Central Visayas"  },
                new RegionDic() {RegionNumber="Region VIII",Region="Eastern Visayas"  },
                new RegionDic() {RegionNumber="Region IX",Region="Zamboanga Peninsula"  },
                new RegionDic() {RegionNumber="Region X",Region="Northern Mindanao"  },
                new RegionDic() {RegionNumber="Region XI",Region="Davao Region"  },
                new RegionDic() {RegionNumber="Region XII",Region="Soccsksargen"  },
                new RegionDic() {RegionNumber="Region XIII",Region="Caraga"  },
           };

       
        public string Op { get; set; }
        
        public Teacher SelectedTeacher { get; set; }

        List<WorkExperience> workExp;
        List<WorkExperience> workExp1= new List<WorkExperience>();
        List<TeacherChildren> teachChild;
        List<TeacherChildren> teachChild1= new List<TeacherChildren>();
        List<TeacherEligibility> teachElig;
        List<TeacherEligibility> teachElig1= new List<TeacherEligibility>();
        List<TeacherEducationalBackground> educBack;
        List<TeacherEducationalBackground> educBack1= new List<TeacherEducationalBackground>();
        List<TrainingSeminar> trainSem;
        List<TrainingSeminar> trainSem1 = new List<TrainingSeminar>() ;

        List<TeacherChildren> teachChildCompare;
        List<Teacher> teacherCompare;
        

        public frmTeacherDetails()
        {
            InitializeComponent();            
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFirstName.Text) && !string.IsNullOrEmpty(txtLastName.Text))
                Save();
            else
            {
                MessageBox.Show("First Name and Last Name should not be empty");
                return;
            }
        }

        private void Save()
        {
            string szGender = string.Empty;
            string szBloodType = string.Empty;
            bool acad = false;
            if (cmbGender.Text == "Female") szGender = "F";
            if (cmbGender.Text == "Male") szGender = "M";

            if (cmbBloodType.Text == "A") szBloodType = "A";
            if (cmbBloodType.Text == "O") szBloodType = "O";
            if (cmbBloodType.Text == "AB") szBloodType = "AB";
            if (cmbBloodType.Text == "A") szBloodType = "A";
            if (radioAcademic.Checked == true && radioNonAcad.Checked == false) acad = true;
            else if (radioAcademic.Checked == false && radioNonAcad.Checked == true) acad = false;
            else if (radioAcademic.Checked == false && radioNonAcad.Checked == false) acad = false;
            Boolean ret = false;
            string message = String.Empty;

            byte[] bImage = null;
            if (pbImage.BackgroundImage != null) bImage = imageToByteArray(pbImage.BackgroundImage, ImageFormat.Png);

            TeacherService teacherService = new TeacherService();

            String fName = txtFirstName.Text;
            String mName = txtMiddleName.Text;
            String lName = txtLastName.Text;

            String cName = fName.Trim() + mName.Trim() + lName.Trim();

            var teachers = teacherService.GetAllTeachers();

            teacherCompare = new List<Teacher>(teachers);

            Teacher teacher = new Teacher()
            {
                TeacherId = txtTeacherID.Text,
                BloodType = szBloodType,
                CivilStatus = cmbCivilState.Text,
                DOB = dtBirth.Value,
                DateOfAppointment = dtAppointment.Value,
                EmailAddress = txtEmailAdd.Text,
                EmploymentStatus = txtEmploymentState.Text,
                DialectSpoken = txtDialect.Text,
                FirstName = txtFirstName.Text,
                MiddleName = txtMiddleName.Text,
                LastName = txtLastName.Text,
                Gender = szGender,
                HeightCm = int.Parse(txtHeight.Text),
                WeightKg = double.Parse(txtWeight.Text),
                MobileNo = txtCellphone.Text,
                PAMunicipality = txtPA_Municipality.Text,
                PAProvince = txtPA_Province.Text,
                PARegion = cmbPA_Region.SelectedValue.ToString(),
                PAStreetName = txtPA_StreetName.Text,
                POBMunicipality = txtPOB_Municipality.Text,
                POBProvince = txtPOB_Province.Text,
                PagIBIGNo = txtPagIbig.Text,
                PhilHealthNo = txtPhilHealth.Text,
                PreviousSchool = txtSchoolReassigned.Text,
                RAMunicipality = txtRes_Municipality.Text,
                RAProvince = txtRes_Province.Text,
                RARegion = cmbRes_Region.SelectedValue.ToString(),
                RAStreetName = txtRes_StreetName.Text,
                ResTelephoneNo = txtRes_TelNo.Text,
                SSSNum = txtSSS.Text,
                SpouseBusinessAdd = txtSpouse_BusinessAdd.Text,
                SpouseEmployerName = txtSpouse_Employer.Text,
                SpouseFirstName = txtSpouse_FirstName.Text,
                SpouseLastName = txtSpouse_LastName.Text,
                SpouseMiddleName = txtSpouse_MiddleName.Text,
                SpouseOccupation = txtSpouse_Occupation.Text,
                SpouseTelephoneNo = txtSpouse_Contact.Text,
                TIN = txtTIN.Text,
                Image = bImage,
                PERAA = txtPERAA.Text,
                Academic = acad,
                Salary = double.Parse(txtSalary.Text),
                Department = txtDepartment.Text,

                TeacherChildrens = teachChild,
                TeacherEducationalBackgrounds = educBack,
                TeacherEligibilities = teachElig,
                WorkExperiences = workExp,
                TrainingSeminars=trainSem,
                
            };



            if (Op.Equals("edit"))
            {
                ret = teacherService.UpdateTeacher(ref teacher, ref message);
                ILogService logService = new LogService();
                teacher.TeacherChildrens = null;
                teacher.TeacherEducationalBackgrounds = null;
                teacher.TeacherEligibilities = null;
                teacher.TrainingSeminars = null;
                teacher.WorkExperiences = null;

                Log("U", "Teachers", teacher);
               
                foreach (TeacherChildren tc in teachChild)
                   Log("U", "TeacherChildren", tc);
                   
                foreach (TeacherEducationalBackground teb in educBack)
                   Log("U", "TeacherEducationalBackground", teb);
                 
                foreach (TeacherEligibility te in teachElig)
                    Log("U", "TeacherEligibilities", te);                

                foreach (WorkExperience we in workExp)
                    Log("U", "WorkExperiences", we);
                    
                
                foreach (TrainingSeminar ts in trainSem)
                   Log("U", "TrainingSeminars", ts);
                   
                
            }
            
            else
            {
                foreach (Teacher tc in teacherCompare)
                {
                    String compareString = tc.FirstName.Trim() + tc.MiddleName.Trim() + tc.LastName.Trim();
                    if (cName.Equals(compareString))
                    {
                        MessageBox.Show("Teacher already exist!");
                        break;
                    }
                    else
                    {
                        ret = teacherService.CreateTeacher(ref teacher, ref message);
                        Log("C", "Teachers", teacher);
                        
                    }
                }
            }

           // if (ret)
                MessageBox.Show("Saved Successfully");
            //else
            //    MessageBox.Show("Error Saving");

            Close();
        }

        private void frmTeacherDetails_Load(object sender, EventArgs e)
        {
            pageViewTeacher.SelectedPage = pageViewTeacher.Pages[0];
            List<RegionDic> ResRegion = new List<RegionDic>(regions);
            List<RegionDic> PARegion = new List<RegionDic>(regions);
            cmbPA_Region.DataSource = PARegion;
            cmbRes_Region.DataSource = ResRegion;

            if (Op.Equals("edit"))
            {
                SetFields();
                SetGrids();
            }

            if (Op.Equals("new"))
            {
                ITeacherService teacherService = new TeacherService();
                szTeacherID = teacherService.GenerateTeacherId();
                txtTeacherID.Text = szTeacherID;
                BindGrids();
            }
        }

        private void BindGrids() {
            teachChild = new List<TeacherChildren>();
            gvChildren.DataSource = teachChild;
            teachElig = new List<TeacherEligibility>();
            gvEligibility.DataSource = teachElig;
            educBack = new List<TeacherEducationalBackground>();
            gvEducBack.DataSource = educBack;
            trainSem = new List<TrainingSeminar>();
            gvTrainSem.DataSource = trainSem;
            workExp = new List<WorkExperience>();
            gvWorkExp.DataSource = workExp;

        }

        private void SetGrids() {
            SetChildrenGrid();
            SetEducationGrid();
            SetWorkGrid();
            SetTrainSemGrid();
            SetEligGrid();
        }

        private void SetTrainSemGrid() {
            trainSem= new List<TrainingSeminar>(SelectedTeacher.TrainingSeminars);
           gvTrainSem.DataSource = trainSem;
           
           
        }
        private void SetWorkGrid() {
           workExp = new List<WorkExperience>(SelectedTeacher.WorkExperiences);
           gvWorkExp.DataSource =workExp;
           
        }
        private void SetEducationGrid() {
            educBack = new List<TeacherEducationalBackground>(SelectedTeacher.TeacherEducationalBackgrounds);
            gvEducBack.DataSource = educBack;
       
        }
        private void SetChildrenGrid() {
          teachChild=new List<TeacherChildren>(SelectedTeacher.TeacherChildrens);
           gvChildren.DataSource =teachChild;
        }
        private void SetEligGrid() {
            teachElig = new List<TeacherEligibility>(SelectedTeacher.TeacherEligibilities);
            gvEligibility.DataSource =teachElig;
        }


        private void SetFields()
        {
            txtTeacherID.Enabled = false;
            txtTeacherID.Text = SelectedTeacher.TeacherId;
            if (SelectedTeacher.Image != null)
            {
                img = byteArrayToImage(SelectedTeacher.Image);
                pbImage.BackgroundImage = ResizeImage(100, 100, img);
            }
            txtFirstName.Text = SelectedTeacher.FirstName;
            txtMiddleName.Text = SelectedTeacher.MiddleName;
            txtLastName.Text = SelectedTeacher.LastName;
            dtBirth.Value = SelectedTeacher.DOB;

            if (SelectedTeacher.Gender == "F") cmbGender.Text = "Female";
            if (SelectedTeacher.Gender == "M") cmbGender.Text = "Male";

            if (SelectedTeacher.BloodType == "A") cmbBloodType.Text = "A";
            if (SelectedTeacher.BloodType == "O") cmbBloodType.Text = "O";
            if (SelectedTeacher.BloodType == "AB") cmbBloodType.Text = "AB";
            if (SelectedTeacher.BloodType == "A") cmbBloodType.Text = "A";

            cmbCivilState.Text = SelectedTeacher.CivilStatus;
            txtCellphone.Text = SelectedTeacher.MobileNo;
            txtDialect.Text = SelectedTeacher.DialectSpoken;
            txtEmailAdd.Text = SelectedTeacher.EmailAddress;
            txtPOB_Province.Text = SelectedTeacher.POBProvince;
            txtPOB_Municipality.Text = SelectedTeacher.POBMunicipality;
            txtTIN.Text = SelectedTeacher.TIN;
            txtPagIbig.Text = SelectedTeacher.PagIBIGNo;
            txtSSS.Text = SelectedTeacher.SSSNum;
            txtPhilHealth.Text = SelectedTeacher.PhilHealthNo;
            txtPERAA.Text = SelectedTeacher.PERAA;
            cmbBloodType.Text = SelectedTeacher.BloodType;
            txtHeight.Text = SelectedTeacher.HeightCm.ToString();
            txtWeight.Text = SelectedTeacher.WeightKg.ToString();
            dtAppointment.Value = SelectedTeacher.DateOfAppointment;
            txtEmploymentState.Text = SelectedTeacher.EmploymentStatus;
            txtSchoolReassigned.Text = SelectedTeacher.PreviousSchool;
            txtSpouse_FirstName.Text = SelectedTeacher.SpouseFirstName;
            txtSpouse_MiddleName.Text = SelectedTeacher.SpouseMiddleName;
            txtSpouse_LastName.Text = SelectedTeacher.SpouseLastName;
            txtSpouse_Occupation.Text = SelectedTeacher.SpouseOccupation;
            txtSpouse_BusinessAdd.Text = SelectedTeacher.SpouseBusinessAdd;
            txtSpouse_Employer.Text = SelectedTeacher.SpouseEmployerName;
            txtSpouse_Contact.Text = SelectedTeacher.SpouseTelephoneNo;
            txtRes_StreetName.Text = SelectedTeacher.RAStreetName;
            txtRes_Province.Text = SelectedTeacher.RAProvince;
            txtRes_Municipality.Text = SelectedTeacher.RAMunicipality;
            cmbRes_Region.SelectedValue = SelectedTeacher.RARegion;
            txtRes_TelNo.Text = SelectedTeacher.ResTelephoneNo;
            txtPA_StreetName.Text = SelectedTeacher.PAStreetName;
            txtPA_Province.Text = SelectedTeacher.PAProvince;
            txtPA_Municipality.Text = SelectedTeacher.PAMunicipality;
            cmbPA_Region.SelectedValue = SelectedTeacher.PARegion;
            if (SelectedTeacher.Academic == true)
                radioAcademic.Checked = true;
            else
                radioNonAcad.Checked = true;

            Age age = new Age(dtAppointment.Value, DateTime.Today);
            txtYearsService.Text = (age.Years + " years, " + age.Months + " months, " + age.Days + " days");
            txtSalary.Text = SelectedTeacher.Salary.ToString() ?? "0.00";
            txtDepartment.Text = SelectedTeacher.Department;
        }
                

        private void btnImage_Click(object sender, EventArgs e)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtTeacherID_Leave(object sender, EventArgs e)
        {
            Teacher teach = new Teacher();
            string msg = string.Empty;
            ITeacherService teacherService = new TeacherService();

            if (txtTeacherID.Text == string.Empty) txtTeacherID.Text = szTeacherID;

           
            teach = teacherService.GetTeacher(txtTeacherID.Text, ref msg);
            if (teach.TeacherId != null)
            {
                MessageBox.Show("Teacher ID already exist!");
                txtTeacherID.Text = szTeacherID;
                txtTeacherID.Focus();
                return;
            }
        }

        private void txtEmailAdd_Leave(object sender, EventArgs e)
        {
            RegexUtilities util = new RegexUtilities();
            if (txtEmailAdd.Text != string.Empty)
            {
                if (!util.IsValidEmail(txtEmailAdd.Text))
                {
                    MessageBox.Show("Invalid E-mail Address");
                    txtEmailAdd.Focus();
                    return;
                }
            }
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

        private void txtHeight_TextChanged(object sender, EventArgs e)
        {
            if (txtHeight.Text == string.Empty) txtHeight.Text = "0";
        }

        private void txtWeight_TextChanged(object sender, EventArgs e)
        {
            if (txtWeight.Text == string.Empty) txtWeight.Text = "0";
        }


        private void gvChildren_UserAddedRow(object sender, GridViewRowEventArgs e)
        {
            
            int index = this.gvChildren.RowCount - 1;
            teachChild[index].TeacherId = this.txtTeacherID.Text;

            String fName = this.teachChild[index].FirstName;
            String mName = this.teachChild[index].MiddleName;
            String lName = this.teachChild[index].LastName;

            if (string.IsNullOrEmpty(fName) || string.IsNullOrEmpty(mName) || string.IsNullOrEmpty(lName))
                return;

            String cName = fName.Trim() + mName.Trim() + lName.Trim();

            if (SelectedTeacher != null)
                teachChildCompare = new List<TeacherChildren>(SelectedTeacher.TeacherChildrens);
            else
                teachChildCompare = new List<TeacherChildren>();

            foreach (TeacherChildren tc in teachChildCompare)
            {
                String compareString = tc.FirstName.Trim() + tc.MiddleName.Trim() + tc.LastName.Trim();
                if (cName.Equals(compareString))
                {
                    MessageBox.Show("Child already exist!");
                    teachChild.RemoveAt(index);
                    gvChildren.DataSource = teachChild1;
                    gvChildren.DataSource = teachChild;
                    break;
                }
                else
                {
                    gvChildren.DataSource = teachChild1;
                    gvChildren.DataSource = teachChild;
                }
            }
        }

        private void frmTeacherDetails_Activated(object sender, EventArgs e)
        {
        
        }

        private void gvEducBack_UserAddedRow(object sender, GridViewRowEventArgs e)
        {

            int index = this.gvEducBack.RowCount - 1;
            educBack[index].TeacherId = this.txtTeacherID.Text;
            
            gvEducBack.DataSource = educBack1;
            gvEducBack.DataSource = educBack;
        }

        private void gvEligibility_UserAddedRow(object sender, GridViewRowEventArgs e)
        {

            int index = this.gvEligibility.RowCount - 1;
            teachElig[index].TeacherId = this.txtTeacherID.Text;


            gvEligibility.DataSource = teachElig1;
            gvEligibility.DataSource = teachElig;
        }

        private void gvTrainSem_UserAddedRow(object sender, GridViewRowEventArgs e)
        {
            int index = this.gvTrainSem.RowCount - 1;
            trainSem[index].TeacherId = this.txtTeacherID.Text;

            gvTrainSem.DataSource =trainSem1;
            gvTrainSem.DataSource = trainSem;
        }

        private void gvWorkExp_UserAddedRow(object sender, GridViewRowEventArgs e)
        {
            int index = this.gvWorkExp.RowCount - 1;
            workExp[index].TeacherId = this.txtTeacherID.Text;

            gvWorkExp.DataSource = workExp1;
            gvWorkExp.DataSource = workExp;
        }

        private void txtTeacherID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Log(string clud,string table, Object obj) {
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

        private void txtSalary_TextChanged(object sender, EventArgs e)
        {
            if (txtSalary.Text == string.Empty) txtSalary.Text = "0";
        }

        private void dtAppointment_Leave(object sender, EventArgs e)
        {
            if (dtAppointment.Value != null)
            {
                Age age = new Age(dtAppointment.Value, DateTime.Today);
                txtYearsService.Text = (age.Years + " years, " + age.Months + " months, " + age.Days + " days");

            }
        }

    }
}
