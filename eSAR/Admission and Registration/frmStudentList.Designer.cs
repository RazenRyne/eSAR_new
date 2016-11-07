namespace eSAR.Admission_and_Registration
{
    partial class frmStudentList
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.pnFooter = new Telerik.WinControls.UI.RadPanel();
            this.btnGenerate = new Telerik.WinControls.UI.RadButton();
            this.btnControl = new Telerik.WinControls.UI.RadButton();
            this.btnAssess = new Telerik.WinControls.UI.RadButton();
            this.btnRegister = new Telerik.WinControls.UI.RadButton();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            this.btnEdit = new Telerik.WinControls.UI.RadButton();
            this.btnDelete = new Telerik.WinControls.UI.RadButton();
            this.gvStudent = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pnFooter)).BeginInit();
            this.pnFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenerate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAssess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRegister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStudent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStudent.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // pnFooter
            // 
            this.pnFooter.Controls.Add(this.btnGenerate);
            this.pnFooter.Controls.Add(this.btnControl);
            this.pnFooter.Controls.Add(this.btnAssess);
            this.pnFooter.Controls.Add(this.btnRegister);
            this.pnFooter.Controls.Add(this.btnAdd);
            this.pnFooter.Controls.Add(this.btnEdit);
            this.pnFooter.Controls.Add(this.btnDelete);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 434);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(955, 50);
            this.pnFooter.TabIndex = 2;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(540, 14);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(136, 24);
            this.btnGenerate.TabIndex = 7;
            this.btnGenerate.Text = "Load Permanent Record";
            this.btnGenerate.Visible = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnControl
            // 
            this.btnControl.Location = new System.Drawing.Point(101, 14);
            this.btnControl.Name = "btnControl";
            this.btnControl.Size = new System.Drawing.Size(103, 24);
            this.btnControl.TabIndex = 6;
            this.btnControl.Text = "Assign Subjects";
            this.btnControl.Click += new System.EventHandler(this.btnControl_Click);
            // 
            // btnAssess
            // 
            this.btnAssess.Location = new System.Drawing.Point(210, 14);
            this.btnAssess.Name = "btnAssess";
            this.btnAssess.Size = new System.Drawing.Size(83, 24);
            this.btnAssess.TabIndex = 5;
            this.btnAssess.Text = "Assess";
            this.btnAssess.Click += new System.EventHandler(this.btnAssess_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(12, 14);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(83, 24);
            this.btnRegister.TabIndex = 4;
            this.btnRegister.Text = "Register";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(682, 14);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(83, 24);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(771, 14);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(83, 24);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(860, 14);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(83, 24);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Dismiss";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // gvStudent
            // 
            this.gvStudent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvStudent.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.gvStudent.MasterTemplate.AllowAddNewRow = false;
            this.gvStudent.MasterTemplate.AllowColumnReorder = false;
            this.gvStudent.MasterTemplate.AllowDeleteRow = false;
            this.gvStudent.MasterTemplate.AllowEditRow = false;
            this.gvStudent.MasterTemplate.AllowRowReorder = true;
            this.gvStudent.MasterTemplate.AllowSearchRow = true;
            this.gvStudent.MasterTemplate.AutoExpandGroups = true;
            gridViewTextBoxColumn1.FieldName = "StudentId";
            gridViewTextBoxColumn1.HeaderText = "Student ID";
            gridViewTextBoxColumn1.MaxLength = 50;
            gridViewTextBoxColumn1.Name = "StudentId";
            gridViewTextBoxColumn1.Width = 150;
            gridViewTextBoxColumn2.FieldName = "LastName";
            gridViewTextBoxColumn2.HeaderText = "Last Name";
            gridViewTextBoxColumn2.MaxLength = 50;
            gridViewTextBoxColumn2.Name = "LastName";
            gridViewTextBoxColumn2.Width = 257;
            gridViewTextBoxColumn3.FieldName = "FirstName";
            gridViewTextBoxColumn3.HeaderText = "First Name";
            gridViewTextBoxColumn3.MaxLength = 50;
            gridViewTextBoxColumn3.Name = "FirstName";
            gridViewTextBoxColumn3.Width = 260;
            gridViewTextBoxColumn4.FieldName = "MiddleName";
            gridViewTextBoxColumn4.HeaderText = "Middle Name";
            gridViewTextBoxColumn4.MaxLength = 50;
            gridViewTextBoxColumn4.Name = "MiddleName";
            gridViewTextBoxColumn4.Width = 270;
            gridViewTextBoxColumn5.FieldName = "Gender";
            gridViewTextBoxColumn5.HeaderText = "Gender";
            gridViewTextBoxColumn5.Name = "Gender";
            gridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn6.FieldName = "GradeLevel";
            gridViewTextBoxColumn6.HeaderText = "Grade Level";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "GradeLevel";
            gridViewTextBoxColumn7.FieldName = "GradeBeforeDC";
            gridViewTextBoxColumn7.HeaderText = "GradeBeforeDC";
            gridViewTextBoxColumn7.IsVisible = false;
            gridViewTextBoxColumn7.Name = "GradeBeforeDC";
            gridViewTextBoxColumn8.HeaderText = "Grade Level";
            gridViewTextBoxColumn8.Name = "GradeLevelDesc";
            gridViewTextBoxColumn8.Width = 100;
            gridViewTextBoxColumn9.FieldName = "Section";
            gridViewTextBoxColumn9.HeaderText = "Section";
            gridViewTextBoxColumn9.Name = "Section";
            gridViewTextBoxColumn9.Width = 100;
            this.gvStudent.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9});
            this.gvStudent.MasterTemplate.EnableAlternatingRowColor = true;
            this.gvStudent.MasterTemplate.PageSize = 50;
            this.gvStudent.Name = "gvStudent";
            this.gvStudent.ShowGroupPanel = false;
            this.gvStudent.Size = new System.Drawing.Size(955, 434);
            this.gvStudent.TabIndex = 5;
            this.gvStudent.Text = "radGridView1";
            this.gvStudent.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.gvStudent_CellFormatting);
            this.gvStudent.SelectionChanged += new System.EventHandler(this.gvStudent_SelectionChanged);
            this.gvStudent.DoubleClick += new System.EventHandler(this.btnEdit_Click);
            // 
            // frmStudentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 484);
            this.Controls.Add(this.gvStudent);
            this.Controls.Add(this.pnFooter);
            this.Name = "frmStudentList";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Student List";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.frmStudentList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnFooter)).EndInit();
            this.pnFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnGenerate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAssess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRegister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStudent.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStudent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadPanel pnFooter;
        private Telerik.WinControls.UI.RadButton btnAdd;
        private Telerik.WinControls.UI.RadButton btnEdit;
        private Telerik.WinControls.UI.RadButton btnDelete;
        private Telerik.WinControls.UI.RadButton btnRegister;
        private Telerik.WinControls.UI.RadGridView gvStudent;
        private Telerik.WinControls.UI.RadButton btnAssess;
        private Telerik.WinControls.UI.RadButton btnControl;
        private Telerik.WinControls.UI.RadButton btnGenerate;
    }
}
