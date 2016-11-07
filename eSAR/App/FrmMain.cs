using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI.Docking;
using eSAR.Utility_Classes;
using eSAR.Settings.ManageBuilding;
using eSAR.Settings.ManageTimeSlot;
using eSAR.Admission_and_Registration;
using eSAR.Course_Related_Resources.ManageTeachers;
using eSAR.Course_Related_Resources.ManageSubject;
using eSAR.Settings.ManageUser;
using eSAR.Settings.ManageSY;
using eSAR.Settings.ManageScholarship;
using eSAR.Settings.ManageCurriculum;
using eSAR.Settings.ManageTraitsbyLevel;
using eSAR.Settings.ManageStudentFees;
using eSAR.Settings;
using eSAR.Course_Related_Resources.ManageGradeLevelSection;
using eSAR.Course_Related_Resources.ManageSchedule;
using eSAR.Billing_and_Payment.StudentPayment;
using eSAR.Billing_and_Payment.ManageReceipt;
using eSAR.Quarterly_Grading.Grading;
using eSAR.Reports.GenerateProspectus;
using eSAR.Reports.GeneratePromotional;
using eSAR.Reports.GenerateTeachersLoad;
using eSAR.Reports.GeneratePayment;
using eSAR.Reports.GenerateBilling;
using eSAR.Reports.GenerateSchedule;
using eSAR.Reports.GenerateStudentList;
using eSAR.Reports;
using eSAR.App;
using eSAR.Reports.GenerateGradingSheets;
using eSAR.Reports.GenerateStudentPermanentRecord;
using eSARServiceModels;

namespace eSAR.App
{
    public partial class FrmMain : Telerik.WinControls.UI.RadRibbonForm
    {
        public User LoggedInUser { get; set; }
        DocumentWindow UserDockWindow;
        DocumentWindow StudentDockWindow;
        DocumentWindow TeacherDockWindow;
        DocumentWindow BuildingDockWindow;
        DocumentWindow LearningAreaDockWindow;
        DocumentWindow TimeslotDockWindow;
        DocumentWindow ScholarshipDockWindow;
        DocumentWindow CurriculumDockWindow;
        DocumentWindow TraitDockWindow;
        DocumentWindow StudentFeeDockWindow;
        DocumentWindow GradeSectionDockWindow;
        DocumentWindow PermanentRecordDockWindow;
        DocumentWindow AdvisoryListDockWindow;
        DocumentWindow TeacherLoadingWindow;

        frmStudentList fmStudentList;
        frmUserList fmUserMain;
        frmTeacherList fmTeacherList;
        frmBuildingList fmBuildingList;
        frmLearningAreas fmLearningAreas;
        frmTimeSlotList fmTimeSlotList;
        frmSYList fmSYList;
        frmScholarshipList fmScholarshipList;
        frmManageCurriculum fmManageCurriculum;
        frmTraitsList fmTraitsList;
        StudentFeeList fmStudentFeeList;
        frmGradeSectionList fmGradeSectionList;
        ProspectusDetails prospectusDetails;
        PromotionalDetails promotionalDetails;
        TeachersLoadDetails teachersLoadDetails;
        LineChart religionDetails;
        PaymentDetails paymentDetails;
        BillingDetails billingDetails;
        ScheduleDetails scheduleDetails;
        StudentListDetails studentListDetails;
        LogoutDetails logoutDetails;        
        frmTeacherLoad fmTeacherLoad;
        frmAdvisersLoad fmAdvisersLoad;
        frmStudentSelection fmStudentSelection;
        FrmActivateTeacher fmActivateTeacher;

        public FrmMain()
        {
            if (GlobalClass.UserLoggedIn == false)
            {
                frmLogIn f = new frmLogIn();
                f.ShowDialog();
            }

            InitializeComponent();

            if (GlobalClass.userTypeCode == "cash")
            {
                this.btnStudent.Enabled = true;
                this.btnTeacher.Enabled = false;
                this.btnActivateTeacher.Enabled = false;
                this.btnLearningArea.Enabled = false;
                this.btnManageSchedule.Enabled = false;
                this.btnUser.Enabled = false;
                this.btnBuildings.Enabled = false;
                this.btnTimeSlot.Enabled = false;
                this.btnCurriculum.Enabled = false;
                this.btnTraits.Enabled = false;
                this.btnFees.Enabled = true;
                this.btnGradeSection.Enabled = false;
                this.btnSY.Enabled = false;
                this.btnPayment.Enabled = true;
                this.btnManageReceipt.Enabled = true;
                this.btnQuarterlyGrading.Enabled = false;
                this.btnTraitsGrading.Enabled = false;
                this.radButtonElement3.Enabled = false;
                this.btnPromotionalList.Enabled = false;
                this.btnTeachersLoadList.Enabled = false;
                this.radButtonElement4.Enabled = true;
                this.btnBillingList.Enabled = true;
                this.btnScheduleList.Enabled = false;
                this.radButtonElement5.Enabled = false;
                this.radRibbonBarGroup15.Enabled = false;
                this.radRibbonBarGroup17.Enabled = false;
                this.radButtonElement2.Enabled = true;
                this.radRibbonBarGroup18.Enabled = false;
            } else if (GlobalClass.userTypeCode == "princ")
            {
                this.btnStudent.Enabled = false;
                this.btnTeacher.Enabled = true;
                this.btnActivateTeacher.Enabled = false;
                this.btnLearningArea.Enabled = true;
                this.btnManageSchedule.Enabled = true;
                this.btnUser.Enabled = false;
                this.btnBuildings.Enabled = true;
                this.btnTimeSlot.Enabled = true;
                this.btnCurriculum.Enabled = true;
                this.btnTraits.Enabled = true;
                this.btnFees.Enabled = false;
                this.btnGradeSection.Enabled = true;
                this.btnSY.Enabled = true;
                this.btnPayment.Enabled = false;
                this.btnManageReceipt.Enabled = false;
                this.btnQuarterlyGrading.Enabled = false;
                this.btnTraitsGrading.Enabled = false;
                this.radButtonElement3.Enabled = true;
                this.btnPromotionalList.Enabled = false;
                this.btnTeachersLoadList.Enabled = true;
                this.radButtonElement4.Enabled = true;
                this.btnBillingList.Enabled = true;
                this.btnScheduleList.Enabled = true;
                this.radButtonElement5.Enabled = true;
                this.radRibbonBarGroup15.Enabled = true;
                this.radRibbonBarGroup17.Enabled = true;
                this.radButtonElement2.Enabled = true;
                this.radRibbonBarGroup18.Enabled = false;
            } else if (GlobalClass.userTypeCode == "reg")
            {
                this.btnStudent.Enabled = true;
                this.btnTeacher.Enabled = false;
                this.btnActivateTeacher.Enabled = false;
                this.btnLearningArea.Enabled = false;
                this.btnManageSchedule.Enabled = false;
                this.btnUser.Enabled = false;
                this.btnBuildings.Enabled = false;
                this.btnTimeSlot.Enabled = false;
                this.btnCurriculum.Enabled = false;
                this.btnTraits.Enabled = false;
                this.btnFees.Enabled = false;
                this.btnGradeSection.Enabled = false;
                this.btnSY.Enabled = false;
                this.btnPayment.Enabled = false;
                this.btnManageReceipt.Enabled = false;
                this.btnQuarterlyGrading.Enabled = true;
                this.btnTraitsGrading.Enabled = true;
                this.radButtonElement3.Enabled = true;
                this.btnPromotionalList.Enabled = true;
                this.btnTeachersLoadList.Enabled = true;
                this.radButtonElement4.Enabled = true;
                this.btnBillingList.Enabled = true;
                this.btnScheduleList.Enabled = true;
                this.radButtonElement5.Enabled = true;
                this.radRibbonBarGroup15.Enabled = true;
                this.radRibbonBarGroup17.Enabled = true;
                this.radButtonElement2.Enabled = true;
                this.radRibbonBarGroup18.Enabled = false;
            } else if(GlobalClass.userTypeCode == "teach")
            {
                this.btnStudent.Enabled = false;
                this.btnTeacher.Enabled = false;
                this.btnActivateTeacher.Enabled = false;
                this.btnLearningArea.Enabled = false;
                this.btnManageSchedule.Enabled = false;
                this.btnUser.Enabled = false;
                this.btnBuildings.Enabled = false;
                this.btnTimeSlot.Enabled = false;
                this.btnCurriculum.Enabled = false;
                this.btnTraits.Enabled = false;
                this.btnFees.Enabled = false;
                this.btnGradeSection.Enabled = false;
                this.btnSY.Enabled = false;
                this.btnPayment.Enabled = false;
                this.btnManageReceipt.Enabled = false;
                this.btnQuarterlyGrading.Enabled = true;
                this.btnTraitsGrading.Enabled = true;
                this.radButtonElement3.Enabled = false;
                this.btnPromotionalList.Enabled = false;
                this.btnTeachersLoadList.Enabled = false;
                this.radButtonElement4.Enabled = false;
                this.btnBillingList.Enabled = false;
                this.btnScheduleList.Enabled = false;
                this.radButtonElement5.Enabled = false;
                this.radRibbonBarGroup15.Enabled = false;
                this.radRibbonBarGroup17.Enabled = false;
                this.radButtonElement2.Enabled = true;
                this.radRibbonBarGroup18.Enabled = false;
            }

            
        }

        //User Settings clicked
        private void btnUser_Click(object sender, EventArgs e)
        {
           
            if (UserDockWindow == null)
            {
                UserDockWindow = new DocumentWindow();
                UserDockWindow.CloseAction = DockWindowCloseAction.Close;
                fmUserMain = new frmUserList();
                fmUserMain.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fmUserMain.TopLevel = false;
                fmUserMain.Dock = DockStyle.Fill;
                UserDockWindow.Text =  fmUserMain.Text;
                UserDockWindow.Controls.Add(fmUserMain);
                this.radDock1.AddDocument(UserDockWindow);
                fmUserMain.Show();
            }
            else
            {
                UserDockWindow.Show();
            }
        }

        
      //Student Clicked
        private void btnStudent_Click(object sender, EventArgs e)
        {
            if (StudentDockWindow == null)
            {
                StudentDockWindow = new DocumentWindow();
                StudentDockWindow.CloseAction = DockWindowCloseAction.Close;
                fmStudentList = new frmStudentList();
                fmStudentList.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fmStudentList.TopLevel = false;
                fmStudentList.Dock = DockStyle.Fill;
                StudentDockWindow.Text = fmStudentList.Text;
                StudentDockWindow.Controls.Add(fmStudentList);
                this.radDock1.AddDocument(StudentDockWindow);
                fmStudentList.Show();
            }
            else
            {
                StudentDockWindow.Show();
            }
            this.radDock1.ActiveWindow = StudentDockWindow;
        }

        private void FrmMain_Activated(object sender, EventArgs e)
        {
            string szActive = string.Empty;
            if (radDock1.ActiveWindow != null)
            {
                szActive = radDock1.ActiveWindow.Text;

                switch (szActive)
                {
                    case "User List":
                        fmUserMain.LoadUsers();
                        break;
                    case "Student List":
                        fmStudentList.LoadStudents();
                        break;
                    case "Faculty and Staff List":
                        fmTeacherList.LoadTeachers();
                        break;
                    case "Building List":
                        fmBuildingList.LoadBuildings();
                        break;
                    case "Time Slots":
                        fmTimeSlotList.LoadTimeslots();
                        break;
                    case "Manage Curriculum":
                        fmManageCurriculum.LoadCurriculums();
                        break;
                    case "List of Traits":
                        fmTraitsList.LoadTraits();
                        break;
                    case "Learning Areas List":
                        fmLearningAreas.LoadLearningAreas();
                        break;
                    case "Scholarship List":
                        fmScholarshipList.LoadScholarships();
                        break;
                    case "List of Student Fees":
                        fmStudentFeeList.LoadStudentFees();
                        break;
                    case "List of HomeRoom Information":
                        fmGradeSectionList.LoadGradeSections();
                        break;
                    case "List of Subjects Load":
                        fmTeacherLoad.LoadTeacherSubjects();
                        break;
                    case "List of Advisory Classes":
                        fmAdvisersLoad.LoadGradeSections();
                        break;
                    case "Student List Selection":
                        fmStudentSelection.LoadStudents();
                        break;
                    default:
                        break;
                }
                
       
            }
        }

        private void radDock1_DockWindowClosing(object sender, DockWindowCancelEventArgs e)
        {
            string szActive = radDock1.ActiveWindow.Text;

            switch (szActive)
            {

                case "User List":
                    UserDockWindow = null;
                    break;
                case "Student List":
                    StudentDockWindow = null;
                    break;
                case "Faculty and Staff List":
                    TeacherDockWindow = null;
                    break;
                case "Building List":
                    BuildingDockWindow = null;
                    break;
                case "Learning Areas List":
                    LearningAreaDockWindow = null;
                    break;
                case "Time Slots":
                    TimeslotDockWindow = null;
                    break;
                case "Manage Curriculum":
                    CurriculumDockWindow = null;
                    break;
                case "List of Traits":
                    TraitDockWindow = null;
                    break;
                case "Scholarship List":
                    ScholarshipDockWindow = null;
                    break;
                case "List of Student Fees":
                    StudentFeeDockWindow = null;
                    break;
                case "List of HomeRoom Information":
                    GradeSectionDockWindow = null;
                    break;
                case "Student List Selection":
                    PermanentRecordDockWindow = null;
                    break;
                case "List of Subjects Load":
                    TeacherLoadingWindow = null;
                    break;
                case "List of Advisory Classes":
                    AdvisoryListDockWindow = null;
                    break;
                default:
                    break;
            }
        }

        private void btnTeacher_Click(object sender, EventArgs e)
        {
            if (TeacherDockWindow == null)
            {
                TeacherDockWindow = new DocumentWindow();
                TeacherDockWindow.CloseAction = DockWindowCloseAction.Close;
                fmTeacherList = new frmTeacherList();
                fmTeacherList.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fmTeacherList.TopLevel = false;
                fmTeacherList.Dock = DockStyle.Fill;
                TeacherDockWindow.Text = fmTeacherList.Text;
                TeacherDockWindow.Controls.Add(fmTeacherList);
                this.radDock1.AddDocument(TeacherDockWindow);
                fmTeacherList.Show();
            }
            else
            {
                TeacherDockWindow.Show();
            }
            this.radDock1.ActiveWindow = TeacherDockWindow;
        }

        private void btnBuildings_Click(object sender, EventArgs e)
        {

            if (BuildingDockWindow == null)
            {
                BuildingDockWindow = new DocumentWindow();
                BuildingDockWindow.CloseAction = DockWindowCloseAction.Close;
                fmBuildingList = new frmBuildingList();
                fmBuildingList.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fmBuildingList.TopLevel = false;
                fmBuildingList.Dock = DockStyle.Fill;
                BuildingDockWindow.Text = fmBuildingList.Text;
                BuildingDockWindow.Controls.Add(fmBuildingList);
                this.radDock1.AddDocument(BuildingDockWindow);
                fmBuildingList.Show();
            }
            else
            {
                BuildingDockWindow.Show();
            }
            this.radDock1.ActiveWindow = BuildingDockWindow;
        }

        private void btnLearningArea_Click(object sender, EventArgs e)
        {
            if (LearningAreaDockWindow == null)
            {
                LearningAreaDockWindow = new DocumentWindow();
                LearningAreaDockWindow.CloseAction = DockWindowCloseAction.Close;
                fmLearningAreas = new frmLearningAreas();
                fmLearningAreas.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fmLearningAreas.TopLevel = false;
                fmLearningAreas.Dock = DockStyle.Fill;
                LearningAreaDockWindow.Text = fmLearningAreas.Text;
                LearningAreaDockWindow.Controls.Add(fmLearningAreas);
                this.radDock1.AddDocument(LearningAreaDockWindow);
                fmLearningAreas.Show();
            }
            else
            {
                LearningAreaDockWindow.Show();
            }
            this.radDock1.ActiveWindow = LearningAreaDockWindow;
        }

        private void btnTimeSlot_Click(object sender, EventArgs e)
        {
            if (TimeslotDockWindow == null)
            {
                TimeslotDockWindow = new DocumentWindow();
                TimeslotDockWindow.CloseAction = DockWindowCloseAction.Close;
                fmTimeSlotList = new frmTimeSlotList();
                fmTimeSlotList.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fmTimeSlotList.TopLevel = false;
                fmTimeSlotList.Dock = DockStyle.Fill;
                TimeslotDockWindow.Text = fmTimeSlotList.Text;
                TimeslotDockWindow.Controls.Add(fmTimeSlotList);
                this.radDock1.AddDocument(TimeslotDockWindow);
                fmTimeSlotList.Show();
            }
            else
            {
                TimeslotDockWindow.Show();
            }
            this.radDock1.ActiveWindow = TimeslotDockWindow;
        }

        private void btnManageSY_Click(object sender, EventArgs e)
        {
            fmSYList = new frmSYList();
            fmSYList.ShowDialog();
            
        }

        private void btnScholarship_Click(object sender, EventArgs e)
        {
            if (ScholarshipDockWindow == null)
            {
                ScholarshipDockWindow = new DocumentWindow();
                ScholarshipDockWindow.CloseAction = DockWindowCloseAction.Close;
                fmScholarshipList = new frmScholarshipList();
                fmScholarshipList.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fmScholarshipList.TopLevel = false;
                fmScholarshipList.Dock = DockStyle.Fill;
                ScholarshipDockWindow.Text = fmScholarshipList.Text;
                ScholarshipDockWindow.Controls.Add(fmScholarshipList);
                this.radDock1.AddDocument(ScholarshipDockWindow);
                fmScholarshipList.Show();
            }
            else
            {
                ScholarshipDockWindow.Show();
            }
            this.radDock1.ActiveWindow = ScholarshipDockWindow;
        }

        private void btnCurriculum_Click(object sender, EventArgs e)
        {
            if (CurriculumDockWindow == null)
            {
                CurriculumDockWindow = new DocumentWindow();
                CurriculumDockWindow.CloseAction = DockWindowCloseAction.Close;
                fmManageCurriculum = new frmManageCurriculum();
                fmManageCurriculum.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fmManageCurriculum.TopLevel = false;
                fmManageCurriculum.Dock = DockStyle.Fill;
                CurriculumDockWindow.Text = fmManageCurriculum.Text;
                CurriculumDockWindow.Controls.Add(fmManageCurriculum);
                this.radDock1.AddDocument(CurriculumDockWindow);
                fmManageCurriculum.Show();
            }
            else
            {
                CurriculumDockWindow.Show();
            }
            this.radDock1.ActiveWindow = CurriculumDockWindow;
        }

        private void btnTraits_Click(object sender, EventArgs e)
        {
            if (TraitDockWindow == null)
            {
                TraitDockWindow = new DocumentWindow();
                TraitDockWindow.CloseAction = DockWindowCloseAction.Close;
                fmTraitsList = new frmTraitsList();
                fmTraitsList.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fmTraitsList.TopLevel = false;
                fmTraitsList.Dock = DockStyle.Fill;
                TraitDockWindow.Text = fmTraitsList.Text;
                TraitDockWindow.Controls.Add(fmTraitsList);
                this.radDock1.AddDocument(TraitDockWindow);
                fmTraitsList.Show();
            }
            else
            {
                TraitDockWindow.Show();
            }
            this.radDock1.ActiveWindow = TraitDockWindow;
        }

        private void btnFees_Click(object sender, EventArgs e)
        {

            if (StudentFeeDockWindow == null)
            {
                StudentFeeDockWindow = new DocumentWindow();
                StudentFeeDockWindow.CloseAction = DockWindowCloseAction.Close;
                fmStudentFeeList = new StudentFeeList();
                fmStudentFeeList.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fmStudentFeeList.TopLevel = false;
                fmStudentFeeList.Dock = DockStyle.Fill;
                StudentFeeDockWindow.Text = fmStudentFeeList.Text;
                StudentFeeDockWindow.Controls.Add(fmStudentFeeList);
                this.radDock1.AddDocument(StudentFeeDockWindow);
                fmStudentFeeList.Show();
            }
            else
            {
                StudentFeeDockWindow.Show();
            }
            this.radDock1.ActiveWindow = StudentFeeDockWindow;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            ribbonTab1.IsSelected = true;
        }

        private void btnGradeSection_Click(object sender, EventArgs e)
        {
            if (GradeSectionDockWindow == null)
            {
                GradeSectionDockWindow = new DocumentWindow();
                GradeSectionDockWindow.CloseAction = DockWindowCloseAction.Close;
                fmGradeSectionList = new frmGradeSectionList();
                fmGradeSectionList.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fmGradeSectionList.TopLevel = false;
                fmGradeSectionList.Dock = DockStyle.Fill;
                GradeSectionDockWindow.Text = fmGradeSectionList.Text;
                GradeSectionDockWindow.Controls.Add(fmGradeSectionList);
                this.radDock1.AddDocument(GradeSectionDockWindow);
                fmGradeSectionList.Show();
            }
            else
            {
                GradeSectionDockWindow.Show();
            }
            this.radDock1.ActiveWindow = GradeSectionDockWindow;
        }

        private void btnManageSchedule_Click(object sender, EventArgs e)
        {

            frmScheduleDetails fmSched = new frmScheduleDetails();
            fmSched.ShowDialog(this);
        }

        private void btnQuarterlyGrading_Click(object sender, EventArgs e)
        {
          
            if (TeacherLoadingWindow == null)
            {
                TeacherLoadingWindow = new DocumentWindow();
                TeacherLoadingWindow.CloseAction = DockWindowCloseAction.Close;
                fmTeacherLoad = new frmTeacherLoad();
                fmTeacherLoad.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fmTeacherLoad.TopLevel = false;
                fmTeacherLoad.Dock = DockStyle.Fill;
                TeacherLoadingWindow.Text = fmTeacherLoad.Text;
                TeacherLoadingWindow.Controls.Add(fmTeacherLoad);
                this.radDock1.AddDocument(TeacherLoadingWindow);
                fmTeacherLoad.Show();
            }
            else
            {
                TeacherLoadingWindow.Show();
            }
            this.radDock1.ActiveWindow = TeacherLoadingWindow;

        }

     

       
        private void btnAttendanceList_Click(object sender, EventArgs e)
        {
            if (GlobalClass.WindowAttendanceDetails == true)
            {

            }
            else
            {
                PaymentReport attendanceDetails = new PaymentReport();
                attendanceDetails.Show(this);
                GlobalClass.WindowAttendanceDetails = true;
            }
        }

   

        private void btnBillingList_Click(object sender, EventArgs e)
        {
                BillingDetails billingDetails = new BillingDetails();
                billingDetails.ShowDialog(this);
        }

        //private void btnScheduleList_Click(object sender, EventArgs e)
        //{
        //        ScheduleDetails scheduleDetails = new ScheduleDetails();
        //        scheduleDetails.ShowDialog(this);
        //        scheduleDetails.Location = new Point(25, 25);
        //}

     
        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (GlobalClass.WindowLogoutDetails == true)
            {

            }
            else
            {
                LogoutDetails logoutDetails = new LogoutDetails();
                logoutDetails.Show(this);
                GlobalClass.WindowLogoutDetails = true;
            }
        }

        private void mnuLogOut_Click(object sender, EventArgs e)
        {
            
        }

        private void radButtonElement2_Click(object sender, EventArgs e)
        {
                LogoutDetails logoutDetails = new LogoutDetails();
                logoutDetails.Show(this);
        }

        private void radButtonElement3_Click(object sender, EventArgs e)
        {
            
                ProspectusDetails prospectusDetails = new ProspectusDetails();
                prospectusDetails.ShowDialog(this);
        }

        private void radButtonElement4_Click(object sender, EventArgs e)
        {
                PaymentDetails paymentDetails = new PaymentDetails();
                paymentDetails.ShowDialog(this);
        }

        private void radButtonElement5_Click(object sender, EventArgs e)
        {
                StudentListDetails studentListDetails = new StudentListDetails();
                studentListDetails.ShowDialog(this);
        }

       

        private void btnTraitsGrading_Click(object sender, EventArgs e)
        {
            if (AdvisoryListDockWindow == null)
            {
                AdvisoryListDockWindow = new DocumentWindow();
                AdvisoryListDockWindow.CloseAction = DockWindowCloseAction.Close;
                fmAdvisersLoad = new frmAdvisersLoad();
                fmAdvisersLoad.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fmAdvisersLoad.TopLevel = false;
                fmAdvisersLoad.Dock = DockStyle.Fill;
                AdvisoryListDockWindow.Text = fmAdvisersLoad.Text;
                AdvisoryListDockWindow.Controls.Add(fmAdvisersLoad);
                this.radDock1.AddDocument(AdvisoryListDockWindow);
                fmAdvisersLoad.Show();
            }
            else
            {
                AdvisoryListDockWindow.Show();
            }
            this.radDock1.ActiveWindow = AdvisoryListDockWindow;
        }

        private void radButtonElement12_Click(object sender, EventArgs e)
        {
            frmGradingSheetInput fmGradeSheet = new frmGradingSheetInput();
            fmGradeSheet.setVars("Grading Sheet");
            fmGradeSheet.ShowDialog();
        }

        private void radButtonElement8_Click(object sender, EventArgs e)
        {
            frmGradingSheetInput fmGradeSheet = new frmGradingSheetInput();
            fmGradeSheet.setVars("Promotional");
            fmGradeSheet.ShowDialog();
        }

        private void radButtonElement13_Click(object sender, EventArgs e)
        {
            if (PermanentRecordDockWindow == null)
            {
                PermanentRecordDockWindow = new DocumentWindow();
                PermanentRecordDockWindow.CloseAction = DockWindowCloseAction.Close;
                fmStudentSelection = new frmStudentSelection();
                fmStudentSelection.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                fmStudentSelection.TopLevel = false;
                fmStudentSelection.Dock = DockStyle.Fill;
                PermanentRecordDockWindow.Text = fmStudentSelection.Text;
                PermanentRecordDockWindow.Controls.Add(fmStudentSelection);
                this.radDock1.AddDocument(PermanentRecordDockWindow);
                fmStudentSelection.Show();
            }
            else
            {
                PermanentRecordDockWindow.Show();
            }
            this.radDock1.ActiveWindow = PermanentRecordDockWindow;
        }

        private void btnPayment_Click_1(object sender, EventArgs e)
        {
            if (GlobalClass.receiptFrom == null)
            {
                MessageBox.Show("Set Receipt Number First");
            }
            else {

                if (GlobalClass.WindowStatusPaymentDetails == true)
                {

                }
                else
                {
                    frmPaymentDetails fmPaymentDetails = new frmPaymentDetails();
                    fmPaymentDetails.Show(this);
                    GlobalClass.WindowStatusPaymentDetails = true;
                }
            }
        }

        private void btnManageReceipt_Click_1(object sender, EventArgs e)
        {
            if (GlobalClass.WindowStatusManageReceipt == true)
            {

            }
            else {
                frmManageReceipt fmManageReceipt = new frmManageReceipt();
                fmManageReceipt.Show(this);
                GlobalClass.WindowStatusManageReceipt = true;
            }
        }

        private void btnTeachersLoadList_Click_1(object sender, EventArgs e)
        {
            frmTeacherLoad fmTeachLoad = new frmTeacherLoad();
            fmTeachLoad.ShowDialog();
        }

        private void btnScheduleList_Click_1(object sender, EventArgs e)
        {
            ScheduleDetails scheduleDetails = new ScheduleDetails();
            scheduleDetails.ShowDialog(this);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void radButtonElement15_Click(object sender, EventArgs e)
        {
            if (GlobalClass.WindowLogoutDetails == true)
            {

            }
            else
            {
                LogoutDetails logoutDetails = new LogoutDetails();
                logoutDetails.Show(this);
                GlobalClass.WindowLogoutDetails = true;
            }
        }

        private void radButtonElement7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void radButtonElement11_Click(object sender, EventArgs e)
        {
            fmActivateTeacher = new FrmActivateTeacher();
            fmActivateTeacher.ShowDialog(this);
        }
    }
}

