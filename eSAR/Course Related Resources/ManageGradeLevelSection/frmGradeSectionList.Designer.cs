namespace eSAR.Course_Related_Resources.ManageGradeLevelSection
{
    partial class frmGradeSectionList
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.btnEdit = new Telerik.WinControls.UI.RadButton();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            this.gvGradeSection = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGradeSection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGradeSection.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.btnEdit);
            this.radPanel1.Controls.Add(this.btnAdd);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel1.Location = new System.Drawing.Point(0, 401);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(747, 50);
            this.radPanel1.TabIndex = 0;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(658, 14);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(77, 24);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(577, 14);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(77, 24);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gvGradeSection
            // 
            this.gvGradeSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvGradeSection.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.gvGradeSection.MasterTemplate.AllowAddNewRow = false;
            this.gvGradeSection.MasterTemplate.AllowColumnReorder = false;
            this.gvGradeSection.MasterTemplate.AllowDeleteRow = false;
            this.gvGradeSection.MasterTemplate.AllowDragToGroup = false;
            this.gvGradeSection.MasterTemplate.AllowEditRow = false;
            this.gvGradeSection.MasterTemplate.AllowSearchRow = true;
            gridViewTextBoxColumn7.FieldName = "SY";
            gridViewTextBoxColumn7.HeaderText = "School Year";
            gridViewTextBoxColumn7.Name = "SY";
            gridViewTextBoxColumn7.Width = 100;
            gridViewTextBoxColumn8.FieldName = "GradeLevel";
            gridViewTextBoxColumn8.HeaderText = "Grade Level";
            gridViewTextBoxColumn8.Name = "GradeLevel";
            gridViewTextBoxColumn8.Width = 100;
            gridViewTextBoxColumn9.FieldName = "Section";
            gridViewTextBoxColumn9.HeaderText = "Section";
            gridViewTextBoxColumn9.Name = "Section";
            gridViewTextBoxColumn9.Width = 150;
            gridViewTextBoxColumn10.FieldName = "HomeRoom.RoomCode";
            gridViewTextBoxColumn10.HeaderText = "Home Room";
            gridViewTextBoxColumn10.Name = "HomeRoom";
            gridViewTextBoxColumn10.Width = 100;
            gridViewTextBoxColumn11.FieldName = "TeacherName";
            gridViewTextBoxColumn11.HeaderText = "Adviser";
            gridViewTextBoxColumn11.Name = "TeacherName";
            gridViewTextBoxColumn11.Width = 200;
            gridViewTextBoxColumn12.FieldName = "GradeSectionCode";
            gridViewTextBoxColumn12.HeaderText = "column1";
            gridViewTextBoxColumn12.IsVisible = false;
            gridViewTextBoxColumn12.Name = "GradeSectionCode";
            this.gvGradeSection.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12});
            this.gvGradeSection.MasterTemplate.EnableGrouping = false;
            this.gvGradeSection.Name = "gvGradeSection";
            this.gvGradeSection.ReadOnly = true;
            this.gvGradeSection.Size = new System.Drawing.Size(747, 401);
            this.gvGradeSection.TabIndex = 1;
            this.gvGradeSection.SelectionChanged += new System.EventHandler(this.gvGradeSection_SelectionChanged);
            this.gvGradeSection.DoubleClick += new System.EventHandler(this.btnEdit_Click);
            // 
            // frmGradeSectionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 451);
            this.Controls.Add(this.gvGradeSection);
            this.Controls.Add(this.radPanel1);
            this.Name = "frmGradeSectionList";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.Text = "List of HomeRoom Information";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.frmGradeSectionList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGradeSection.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGradeSection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadButton btnEdit;
        private Telerik.WinControls.UI.RadButton btnAdd;
        private Telerik.WinControls.UI.RadGridView gvGradeSection;
    }
}
