namespace eSAR.Course_Related_Resources.ManageSubject
{
    partial class frmManageSubject
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageSubject));
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.gvSubjects = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.txtRatePerSubject = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.checkAcademic = new Telerik.WinControls.UI.RadCheckBox();
            this.txtRate = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.txtDescription = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txtUnits = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtLearningAreaCode = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel89 = new Telerik.WinControls.UI.RadLabel();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSubjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSubjects.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRatePerSubject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkAcademic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLearningAreaCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel89)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.radGroupBox1);
            this.radPanel1.Controls.Add(this.radGroupBox2);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(804, 488);
            this.radPanel1.TabIndex = 0;
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.gvSubjects);
            this.radGroupBox1.HeaderText = "Subjects";
            this.radGroupBox1.Location = new System.Drawing.Point(17, 131);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(772, 340);
            this.radGroupBox1.TabIndex = 40;
            this.radGroupBox1.Text = "Subjects";
            // 
            // gvSubjects
            // 
            this.gvSubjects.Location = new System.Drawing.Point(4, 23);
            // 
            // 
            // 
            this.gvSubjects.MasterTemplate.AllowColumnReorder = false;
            this.gvSubjects.MasterTemplate.AllowDeleteRow = false;
            this.gvSubjects.MasterTemplate.AllowDragToGroup = false;
            gridViewTextBoxColumn1.FieldName = "SubjectCode";
            gridViewTextBoxColumn1.HeaderText = "Subject Code";
            gridViewTextBoxColumn1.Name = "SubjectCode";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 145;
            gridViewTextBoxColumn2.FieldName = "Description";
            gridViewTextBoxColumn2.HeaderText = "Description";
            gridViewTextBoxColumn2.Name = "Description";
            gridViewTextBoxColumn2.Width = 370;
            gridViewTextBoxColumn3.FieldName = "MPW";
            gridViewTextBoxColumn3.HeaderText = "Minutes per Week";
            gridViewTextBoxColumn3.Name = "MPW";
            gridViewTextBoxColumn3.Width = 100;
            this.gvSubjects.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3});
            this.gvSubjects.MasterTemplate.EnableGrouping = false;
            this.gvSubjects.MasterTemplate.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysHide;
            this.gvSubjects.Name = "gvSubjects";
            this.gvSubjects.Size = new System.Drawing.Size(763, 312);
            this.gvSubjects.TabIndex = 6;
            this.gvSubjects.Text = "Subjects";
            this.gvSubjects.CellBeginEdit += new Telerik.WinControls.UI.GridViewCellCancelEventHandler(this.gvSubjects_CellBeginEdit);
            this.gvSubjects.CellEditorInitialized += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvSubjects_CellEditorInitialized);
            this.gvSubjects.ValueChanging += new Telerik.WinControls.UI.ValueChangingEventHandler(this.gvSubjects_ValueChanging);
            this.gvSubjects.UserAddingRow += new Telerik.WinControls.UI.GridViewRowCancelEventHandler(this.gvSubjects_UserAddingRow);
            this.gvSubjects.UserAddedRow += new Telerik.WinControls.UI.GridViewRowEventHandler(this.gvSubjects_UserAddedRow);
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.txtRatePerSubject);
            this.radGroupBox2.Controls.Add(this.radLabel4);
            this.radGroupBox2.Controls.Add(this.checkAcademic);
            this.radGroupBox2.Controls.Add(this.txtRate);
            this.radGroupBox2.Controls.Add(this.radLabel3);
            this.radGroupBox2.Controls.Add(this.txtDescription);
            this.radGroupBox2.Controls.Add(this.radLabel2);
            this.radGroupBox2.Controls.Add(this.txtUnits);
            this.radGroupBox2.Controls.Add(this.radLabel1);
            this.radGroupBox2.Controls.Add(this.txtLearningAreaCode);
            this.radGroupBox2.Controls.Add(this.radLabel89);
            this.radGroupBox2.HeaderText = "Learning Area";
            this.radGroupBox2.Location = new System.Drawing.Point(16, 13);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(773, 109);
            this.radGroupBox2.TabIndex = 0;
            this.radGroupBox2.Text = "Learning Area";
            // 
            // txtRatePerSubject
            // 
            this.txtRatePerSubject.Location = new System.Drawing.Point(485, 72);
            this.txtRatePerSubject.Name = "txtRatePerSubject";
            this.txtRatePerSubject.Size = new System.Drawing.Size(88, 20);
            this.txtRatePerSubject.TabIndex = 25;
            this.txtRatePerSubject.Text = "0";
            this.txtRatePerSubject.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(377, 71);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(90, 18);
            this.radLabel4.TabIndex = 26;
            this.radLabel4.Text = "Rate per Subject:";
            // 
            // checkAcademic
            // 
            this.checkAcademic.Location = new System.Drawing.Point(114, 76);
            this.checkAcademic.Name = "checkAcademic";
            this.checkAcademic.Size = new System.Drawing.Size(69, 18);
            this.checkAcademic.TabIndex = 2;
            this.checkAcademic.Text = "Academic";
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(485, 46);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(88, 20);
            this.txtRate.TabIndex = 5;
            this.txtRate.Text = "0";
            this.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_KeyPress);
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(393, 47);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(74, 18);
            this.radLabel3.TabIndex = 24;
            this.radLabel3.Text = "Rate per Unit:";
            // 
            // txtDescription
            // 
            this.txtDescription.AutoSize = false;
            this.txtDescription.Location = new System.Drawing.Point(483, 18);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(251, 21);
            this.txtDescription.TabIndex = 3;
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(401, 23);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(66, 18);
            this.radLabel2.TabIndex = 23;
            this.radLabel2.Text = "Description:";
            // 
            // txtUnits
            // 
            this.txtUnits.Location = new System.Drawing.Point(114, 47);
            this.txtUnits.Name = "txtUnits";
            this.txtUnits.Size = new System.Drawing.Size(88, 20);
            this.txtUnits.TabIndex = 4;
            this.txtUnits.Text = "0";
            this.txtUnits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUnits.TextChanged += new System.EventHandler(this.txtUnits_TextChanged);
            this.txtUnits.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_KeyPress);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(20, 50);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(92, 18);
            this.radLabel1.TabIndex = 21;
            this.radLabel1.Text = "Number of Units:";
            // 
            // txtLearningAreaCode
            // 
            this.txtLearningAreaCode.Location = new System.Drawing.Point(114, 21);
            this.txtLearningAreaCode.Name = "txtLearningAreaCode";
            this.txtLearningAreaCode.Size = new System.Drawing.Size(142, 20);
            this.txtLearningAreaCode.TabIndex = 1;
            this.txtLearningAreaCode.TextChanged += new System.EventHandler(this.txtLearningAreaCode_TextChanged);
            this.txtLearningAreaCode.Leave += new System.EventHandler(this.txtLearningAreaCode_Leave);
            // 
            // radLabel89
            // 
            this.radLabel89.Location = new System.Drawing.Point(5, 22);
            this.radLabel89.Name = "radLabel89";
            this.radLabel89.Size = new System.Drawing.Size(107, 18);
            this.radLabel89.TabIndex = 19;
            this.radLabel89.Text = "Learning Area Code:";
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.btnSave);
            this.radPanel2.Controls.Add(this.btnCancel);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel2.Location = new System.Drawing.Point(0, 488);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(804, 53);
            this.radPanel2.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(617, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 24);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(706, 16);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 24);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmManageSubject
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(804, 541);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.radPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmManageSubject";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Learning Area";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.frmManageSubject_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvSubjects.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSubjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRatePerSubject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkAcademic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLearningAreaCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel89)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox txtDescription;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox txtUnits;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtLearningAreaCode;
        private Telerik.WinControls.UI.RadLabel radLabel89;
        private Telerik.WinControls.UI.RadTextBox txtRate;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView gvSubjects;
        private Telerik.WinControls.UI.RadCheckBox checkAcademic;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadTextBox txtRatePerSubject;
        private Telerik.WinControls.UI.RadLabel radLabel4;
    }
}
