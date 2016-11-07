using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.Linq;
using Newtonsoft.Json;
using eSAR.Utility_Classes;
using eSARServices;
using eSARServiceInterface;
using eSARServiceModels;

namespace eSAR.Settings.ManageCurriculum
{
    public partial class frmCurriculumDetails : Telerik.WinControls.UI.RadForm
    {
        public Boolean ret;
        public string Op { get; set; }
        public Curriculum SelectedCurriculum { get; set; }
        public List<GradeLevel> gradeLevels;

        public List<CurriculumSubject> currSub = new List<CurriculumSubject>();
        public List<CurriculumSubject> currSub1 = new List<CurriculumSubject>();
        public List<CurriculumSubject> currSub2 = new List<CurriculumSubject>();

        IGradeLevelService gs = new GradeLevelService();
        ICurriculumService cs = new CurriculumService();
        CurriculumSubject addedCurrSub;

        List<SubjectsDetails> subDetails;

        List<Curriculum> curr;

        public frmCurriculumDetails()
        {
            InitializeComponent();
           
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            
            string message = String.Empty;
            Curriculum c = new Curriculum();

            ICurriculumService curriculumService = new CurriculumService();

            var curri = curriculumService.GetAllCurriculums();

            curr = new List<Curriculum>(curri);

            if (chkCurrent.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                c.CurrentCurr = true;
            }

            c.CurriculumCode = txtCurrCode.Text;
            c.CurriculumSubjects = currSub1;
            c.Description = txtDescription.Text;

            String cCode = txtCurrCode.Text.Trim();
            if (Op.Equals("new"))
            {
                foreach (Curriculum cu in curr)
                {
                    String currcode = cu.CurriculumCode;
                    if (cCode.Equals(currcode))
                    {
                        MessageBox.Show("Curriculum already exist!");
                        break;
                    }
                    else
                    {


                        if (Op.Equals("new"))
                        {
                            ret = cs.CreateCurriculum(ref c, ref message);
                            c.CurriculumSubjects = null;
                            Log("C", "Curriculums", c);
                            if (ret)
                            {
                                foreach (CurriculumSubject cs in currSub1)
                                    Log("C", "CurriculumSubjects", cs);

                                MessageBox.Show(this, message, "Add Successful");
                                Op = "edit";
                                //Comment this part. The current pocess is not working. 
                                //New process is to add the curriculum then update.
                                //this.txtCurrCode.Enabled = false;
                                //this.Size = new Size(851, 503);
                                //radGroupBox2.Visible = true;
                                this.Close();

                            }
                            else
                                MessageBox.Show(this, message, "Add Failed");
                        }
                    }
                }


               
            }

            else if (Op.Equals("edit"))
            {
                ret = cs.UpdateCurriculum(ref c, ref message);
                c.CurriculumSubjects = null;
                Log("U", "Curriculums", c);
                if (ret)
                {
                    foreach (CurriculumSubject cs in currSub1)
                        Log("C", "CurriculumSubjects", cs);
                    MessageBox.Show(this, message, "Update Successful");
                    this.Close();
                }
                else
                    MessageBox.Show(this, message, "Update Failed");
            }
                  
        }

     
        private void frmCurriculumDetails_Load(object sender, EventArgs e)
        {

            if (Op.Equals("edit"))
            {
                SetFields();
            }
            if (Op.Equals("new"))
            {
                // BindSubjectGrid();
                radGroupBox2.Visible = false;
                this.Size = new Size(851, 211);
            }

            subDetails = new List<SubjectsDetails>();
            currSub = new List<CurriculumSubject>(cs.GetAllSubjectDetails());
            foreach (CurriculumSubject cs in currSub)
            {
                SubjectsDetails sd = new SubjectsDetails();
                sd.Academic = cs.Academic;
                sd.CurrDescription = cs.CurrDescription;
                sd.CurrentCurr = cs.CurrentCurr;
                sd.CurriculumCode = cs.CurriculumCode;
                sd.CurrSubCode = cs.CurrSubCode;
                sd.Deactivated = cs.Deactivated;
                sd.GradeLevel = cs.GradeLevel;
                sd.LearningAreaCode = cs.LearningAreaCode;
                sd.RatePerUnit = cs.RatePerUnit;
                sd.Subj = cs.Subj;
                sd.SubjectCode = cs.SubjectCode;
                sd.SubjectDescription = cs.SubjectDescription;
                sd.Units = cs.Units;
                
                
                if (currSub1 != null)
                {
                    List<CurriculumSubject> matches = currSub1.Where(p => p.SubjectCode== cs.SubjectCode).ToList<CurriculumSubject>();
                    if (matches.Count>0)
                        sd.Added = true;
                    else
                        sd.Added = false;
                }else

                     sd.Added = false;
               
              
                subDetails.Add(sd);
            }
            gvSubjects.DataSource = subDetails;
           
        }

        private void SetFields()
        {
         
            txtCurrCode.Text = SelectedCurriculum.CurriculumCode;
            txtDescription.Text = SelectedCurriculum.Description;
            chkCurrent.Checked = SelectedCurriculum.CurrentCurr;
            currSub1 = new List<CurriculumSubject>(cs.GetCurriculumSubjects(SelectedCurriculum.CurriculumCode));
            radGroupBox2.Visible = true;
          }

        private void cmbGradeLevel_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            subDetails = new List<SubjectsDetails>();
           
            ICurriculumService ss = new CurriculumService();
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvSubjects_CellEditorInitialized(object sender, GridViewCellEventArgs e)
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
            addedCurrSub = new CurriculumSubject();
            int i = gvSubjects.CurrentRow.Index;
            RadCheckBoxEditor cbEditor = sender as RadCheckBoxEditor;
            if ((Telerik.WinControls.Enumerations.ToggleState)cbEditor.Value == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                subDetails[i].Added = true;
                addedCurrSub.Academic = currSub[i].Academic;
                addedCurrSub.CurrDescription = txtDescription.Text;
                if (chkCurrent.CheckState == 0)
                    addedCurrSub.CurrentCurr = false;
                else
                    addedCurrSub.CurrentCurr = true;
                addedCurrSub.CurriculumCode = txtCurrCode.Text;
                addedCurrSub.CurrSubCode = txtCurrCode.Text.ToString() + currSub[i].SubjectCode;
                addedCurrSub.Deactivated = false;
                addedCurrSub.GradeLevel = currSub[i].GradeLevel;
                addedCurrSub.LearningAreaCode = currSub[i].LearningAreaCode;
                addedCurrSub.RatePerUnit = currSub[i].RatePerUnit;
                addedCurrSub.SubjectCode = currSub[i].SubjectCode;
                addedCurrSub.Subj = currSub[i].Subj;
                addedCurrSub.SubjectDescription = currSub[i].SubjectDescription;
                addedCurrSub.Units = currSub[i].Units;

                currSub1.Add(addedCurrSub);
               
            }
            else if ((Telerik.WinControls.Enumerations.ToggleState)cbEditor.Value == Telerik.WinControls.Enumerations.ToggleState.Off)
            {
                subDetails[i].Added = false;
                addedCurrSub.Academic = currSub[i].Academic;
                addedCurrSub.CurrDescription = txtDescription.Text;
                if (chkCurrent.CheckState == 0)
                    addedCurrSub.CurrentCurr = false;
                else
                    addedCurrSub.CurrentCurr = true;
                addedCurrSub.CurriculumCode = txtCurrCode.Text;
                addedCurrSub.CurrSubCode = txtCurrCode.Text.ToString() + currSub[i].SubjectCode;
                addedCurrSub.Deactivated = false;
                addedCurrSub.GradeLevel = currSub[i].GradeLevel;
                addedCurrSub.LearningAreaCode = currSub[i].LearningAreaCode;
                addedCurrSub.RatePerUnit = currSub[i].RatePerUnit;
                addedCurrSub.SubjectCode = currSub[i].SubjectCode;
                addedCurrSub.Subj = currSub[i].Subj;
                addedCurrSub.SubjectDescription = currSub[i].SubjectDescription;
                addedCurrSub.Units = currSub[i].Units;

                var index = currSub1.FindIndex(a => a.CurrSubCode == addedCurrSub.CurrSubCode);
                currSub1.RemoveAt(index);         
            }
            addedCurrSub = null;
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
