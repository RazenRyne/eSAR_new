namespace eSAR.Reports.GenerateStudentPermanentRecord
{
    partial class frmStudentSelection
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
            this.gvStudent = new Telerik.WinControls.UI.RadGridView();
            this.pnFooter = new Telerik.WinControls.UI.RadPanel();
            this.btnGenerate = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.gvStudent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStudent.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnFooter)).BeginInit();
            this.pnFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenerate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
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
            this.gvStudent.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.gvStudent.MasterTemplate.EnableGrouping = false;
            this.gvStudent.Name = "gvStudent";
            this.gvStudent.ShowGroupPanel = false;
            this.gvStudent.Size = new System.Drawing.Size(727, 451);
            this.gvStudent.TabIndex = 7;
            this.gvStudent.Text = "radGridView1";
            this.gvStudent.SelectionChanged += new System.EventHandler(this.gvStudent_SelectionChanged);
            // 
            // pnFooter
            // 
            this.pnFooter.Controls.Add(this.btnGenerate);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 451);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(727, 50);
            this.pnFooter.TabIndex = 6;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(579, 14);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(136, 24);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Load Permanent Record";
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // frmStudentSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 501);
            this.Controls.Add(this.gvStudent);
            this.Controls.Add(this.pnFooter);
            this.Name = "frmStudentSelection";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student List Selection";
            this.Activated += new System.EventHandler(this.frmStudentSelection_Activated);
            this.Load += new System.EventHandler(this.frmStudentSelection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvStudent.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStudent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnFooter)).EndInit();
            this.pnFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnGenerate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gvStudent;
        private Telerik.WinControls.UI.RadPanel pnFooter;
        private Telerik.WinControls.UI.RadButton btnGenerate;
    }
}
