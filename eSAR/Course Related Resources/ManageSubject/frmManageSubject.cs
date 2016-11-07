using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Newtonsoft.Json;
using eSAR.Utility_Classes;
using eSARServices;
using eSARServiceInterface;
using eSARServiceModels;

namespace eSAR.Course_Related_Resources.ManageSubject
{
    public partial class frmManageSubject : Telerik.WinControls.UI.RadForm
    {
        public string Op { get; set; }
        public LearningArea SelectedLearningArea { get; set; }
        List<GradeLevel> gradeLevel = new List<GradeLevel>();
        List<Subject> subjects;
        List<Subject> subjects1 = new List<Subject>();
        List<Subject> oldSubjects = new List<Subject>();
        GridViewComboBoxColumn colGradeLevel;
        GradeLevel gLevelSelected = new GradeLevel();
        Subject oldsub = new Subject();

        string oldGL = string.Empty;
        

        private int oldIndex = -1;
        public frmManageSubject()
        {
            InitializeComponent();

        }

        private void gvSubjects_CellEditorInitialized(object sender, GridViewCellEventArgs e)
        {
            if (e.Row is GridViewNewRowInfo)
            {
                var editor = e.ActiveEditor as RadDropDownListEditor;
                if (editor != null)
                {
                    editor.ValueChanged -= new EventHandler(editor_ValueChanged);
                    editor.ValueChanged += new EventHandler(editor_ValueChanged);
                }
            }
        }

        void editor_ValueChanged(object sender, EventArgs e)
        {
            var editor = gvSubjects.ActiveEditor as RadDropDownListEditor;
            if (editor != null)
            {
                var editorElement = editor.EditorElement as RadDropDownListEditorElement;
                if (editorElement.SelectedIndex == -1)
                {

                    MessageBox.Show(this, "Please select a grade level.", "Grade Level Required");
                    gvSubjects.CancelEdit();
                }
                else
                {
                    gLevelSelected = gradeLevel[editorElement.SelectedIndex];
                    gvSubjects.EndEdit();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (Op.Equals("new"))
                Save();
            //else
            //    this.Close();
        }

        private void Save()
        {
            ILearningAreaService laService = new LearningAreaService();
            Boolean ret = false;
            string message = String.Empty;
            bool chec = checkAcademic.Checked;
            LearningArea learningArea = new LearningArea()
            {
                LearningAreaCode = txtLearningAreaCode.Text.ToString(),
                Description = txtDescription.Text.ToString(),
                Units = Double.Parse(txtUnits.Text.ToString()),
                Subjects = subjects,
                RatePerUnit = Double.Parse(txtRate.Text.ToString()),
                RatePerSubject = Double.Parse(txtRatePerSubject.Text.ToString()),
                Academic = chec
            };
            if (Op.Equals("edit"))
            {
                ret = laService.UpdateLearningArea(ref learningArea, ref message);
                Log("U", "LearningArea", learningArea);

                foreach (Subject s in subjects) {
                    Log("U", "Subject", s);
                }
                
                if (ret)
                    MessageBox.Show("Saved Successfully");
                else
                    MessageBox.Show("Error Saving");


                if (Op.Equals("edit"))
                    Close();
            }
            else
            {
                String la = txtLearningAreaCode.Text.ToString();

                if (la.Equals(String.Empty))
                {
                    MessageBox.Show("Provide Learning Area Code");
                }
                else
                {
                    ret = laService.CreateLearningArea(ref learningArea, ref message);
                    Log("C", "LearningAreas", learningArea);
                   

                    if (ret)
                        MessageBox.Show("Saved Successfully");
                    else
                        MessageBox.Show("Error Saving");

                    if (Op.Equals("new"))
                    {
                        Op = "edit";
                        txtLearningAreaCode.Enabled = false;
                        this.Size = new Size(812, 571);
                        gvSubjects.Enabled = true;
                    }
                }
            }
        }

        private void frmManageSubject_Load(object sender, EventArgs e)
        {
            
            ILearningAreaService laService = new LearningAreaService();
            IGradeLevelService glService = new GradeLevelService();
            gradeLevel = new List<GradeLevel>(glService.GetAllGradeLevels());
            

            colGradeLevel = new GridViewComboBoxColumn("GradeLevel");            
            colGradeLevel.HeaderText = "Grade Level";
            colGradeLevel.FieldName = "GradeLevel";
            colGradeLevel.ValueMember = "GradeLev";
            colGradeLevel.DisplayMember = "Description";
            colGradeLevel.Width = 110;

            colGradeLevel.DataSource = gradeLevel;

            gvSubjects.Columns.Add(colGradeLevel);


            if (Op.Equals("edit"))
            {
                SetFields();
                SetSubjectGrid();
                this.Size = new Size(812, 571);
            }

            if (Op.Equals("new"))
            {
                BindSubjectGrid();
                gvSubjects.Enabled = false; 
                btnSave.Enabled = false;
                this.Size = new Size(812, 209);
            }
        }

        private void SetFields()
        {
            txtLearningAreaCode.Enabled = false;
            txtLearningAreaCode.Text = SelectedLearningArea.LearningAreaCode;
            txtDescription.Text = SelectedLearningArea.Description;
            txtUnits.Text = SelectedLearningArea.Units.ToString();
            txtRate.Text = SelectedLearningArea.RatePerUnit.ToString();
            txtRatePerSubject.Text = SelectedLearningArea.RatePerSubject.ToString();
            checkAcademic.Checked = (bool)SelectedLearningArea.Academic;
            gvSubjects.Enabled = true;
        }

        private void BindSubjectGrid()
        {
            subjects = new List<Subject>();
            gvSubjects.DataSource = subjects;
        }

        private void SetSubjectGrid()
        {
            subjects = new List<Subject>(SelectedLearningArea.Subjects);            
            this.gvSubjects.DataSource = subjects;
        }


        private void gvSubjects_UserAddedRow(object sender, Telerik.WinControls.UI.GridViewRowEventArgs e)
        {
            int index = this.gvSubjects.RowCount - 1;

            if (oldSubjects.Exists(x => x.GradeLevel == gLevelSelected.GradeLev) == true)
            {
                Subject returnedSub = new Subject();
                returnedSub = oldSubjects.Find(x => x.GradeLevel == gLevelSelected.GradeLev);
                subjects[index].SubjectID = returnedSub.SubjectID;
                subjects[index].SubjectCode = returnedSub.SubjectCode;
                subjects[index].MPW = returnedSub.MPW;
                oldSubjects.RemoveAll(x => x.SubjectCode == returnedSub.SubjectCode);

            }
            else
            {
                subjects[index].SubjectID = 0;
                subjects[index].SubjectCode = this.txtLearningAreaCode.Text + gLevelSelected.GradeLev;
                
            }

            subjects[index].LearningAreaCode = this.txtLearningAreaCode.Text;
            subjects[index].GradeLevel = gLevelSelected.GradeLev;
            gvSubjects.DataSource = subjects1;
            gvSubjects.DataSource = subjects;
            gLevelSelected = null;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }   

        private void gvSubjects_UserAddingRow(object sender, GridViewRowCancelEventArgs e)
        {
            var newGL = new object();
            var newGD = new object();
            var newMPW = new object();
            newGL = e.Rows[0].Cells["GradeLevel"].Value;
            newGD = e.Rows[0].Cells["Description"].Value;
            newMPW = e.Rows[0].Cells["MPW"].Value;
            if (newGD == null)
            {
                MessageBox.Show("Subject Description should not be empty");
                e.Cancel = true;
            }
            else if (newGL == null)
            {
                MessageBox.Show("Grade Level should not be empty");
                e.Cancel = true;
            }
            else if (newMPW == null)
            {
                MessageBox.Show("Minutes per week should not be empty");
                e.Cancel = true;
            }
            else
            {
                if (subjects.FindAll(x => x.GradeLevel == newGL.ToString()).Count > 0)
                {
                    MessageBox.Show("Subject for this Grade Level already exist");
                    e.Cancel = true;
                }
            }

        }


        private void gvSubjects_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 3)
                {
                    oldGL = gvSubjects.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    if (subjects[e.RowIndex].SubjectID != 0)
                    {
                        e.Cancel = true;
                    }

                }
            }
        }

        private void gvSubjects_ValueChanging(object sender, ValueChangingEventArgs e)
        {
            if (gvSubjects.CurrentRow.Index >= 0)
            {
                oldsub = new Subject()
                {
                    Description = subjects[gvSubjects.CurrentRow.Index].Description,
                    GradeLevel = subjects[gvSubjects.CurrentRow.Index].GradeLevel,
                    LArea = subjects[gvSubjects.CurrentRow.Index].LArea,
                    LearningAreaCode = subjects[gvSubjects.CurrentRow.Index].LearningAreaCode,
                    SubjectCode = subjects[gvSubjects.CurrentRow.Index].SubjectCode,
                    SubjectID = subjects[gvSubjects.CurrentRow.Index].SubjectID,
                    MPW=subjects[gvSubjects.CurrentRow.Index].MPW
                };

                oldSubjects.Add(oldsub);

                if (e.NewValue != e.OldValue)
                {
                    if (gvSubjects.CurrentColumn.Index == 3)
                    {
                        if (subjects.FindAll(x => x.GradeLevel == e.NewValue.ToString()).Count <= 0)
                        {                            
                            if (oldSubjects.Exists(x => x.GradeLevel == e.NewValue.ToString()) == true)
                            {
                                Subject returnedSub = new Subject();
                                returnedSub = oldSubjects.Find(x => x.GradeLevel == e.NewValue.ToString());
                                subjects[gvSubjects.CurrentRow.Index].SubjectID = returnedSub.SubjectID;
                                subjects[gvSubjects.CurrentRow.Index].SubjectCode = returnedSub.SubjectCode;
                                subjects[gvSubjects.CurrentRow.Index].MPW = returnedSub.MPW;
                                oldSubjects.RemoveAll(x => x.SubjectCode == returnedSub.SubjectCode);
                            }
                            else
                            {
                                subjects[gvSubjects.CurrentRow.Index].SubjectID = 0;
                                subjects[gvSubjects.CurrentRow.Index].SubjectCode = this.txtLearningAreaCode.Text + e.NewValue.ToString();
                            }

                            subjects[gvSubjects.CurrentRow.Index].LearningAreaCode = this.txtLearningAreaCode.Text;
                            gvSubjects.Rows[gvSubjects.CurrentRow.Index].Cells[0].Value = this.txtLearningAreaCode.Text + e.NewValue.ToString();
                            subjects[gvSubjects.CurrentRow.Index].GradeLevel = e.NewValue.ToString();

                        }
                        else
                        {
                            MessageBox.Show("Subject for this Grade Level already exist");
                            e.Cancel = true;
                        }
                    }
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

        private void txtUnits_TextChanged(object sender, EventArgs e)
        {
            if (txtUnits.Text.Equals(String.Empty)) txtUnits.Text = "0";
        }

        private void txtLearningAreaCode_Leave(object sender, EventArgs e)
        {
            LearningArea la = new LearningArea();
            string msg = string.Empty;
            ILearningAreaService laService = new LearningAreaService();

            la = laService.GetLearningArea(txtLearningAreaCode.Text);
            if (la.LearningAreaCode != null)
            {
                MessageBox.Show("Learning Area already exist!");
                txtLearningAreaCode.Text = string.Empty;
                txtLearningAreaCode.Focus();
                return;
            }
        }

        private void txtLearningAreaCode_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
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
