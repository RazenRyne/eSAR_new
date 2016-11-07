namespace eSAR.Settings.ManageScholarship
{
    partial class frmScholarshipList
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.gvScholarship = new Telerik.WinControls.UI.RadGridView();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.btnAddScholarship = new Telerik.WinControls.UI.RadButton();
            this.btnEditScholarship = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvScholarship)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvScholarship.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddScholarship)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditScholarship)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.gvScholarship);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(955, 484);
            this.radPanel1.TabIndex = 1;
            // 
            // gvScholarship
            // 
            this.gvScholarship.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvScholarship.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.gvScholarship.MasterTemplate.AllowAddNewRow = false;
            this.gvScholarship.MasterTemplate.AllowColumnReorder = false;
            this.gvScholarship.MasterTemplate.AllowDeleteRow = false;
            this.gvScholarship.MasterTemplate.AllowDragToGroup = false;
            this.gvScholarship.MasterTemplate.AllowEditRow = false;
            this.gvScholarship.MasterTemplate.AllowSearchRow = true;
            gridViewTextBoxColumn5.FieldName = "ScholarshipCode";
            gridViewTextBoxColumn5.HeaderText = "Scholarship Code";
            gridViewTextBoxColumn5.Name = "ScholarshipCode";
            gridViewTextBoxColumn5.Width = 206;
            gridViewTextBoxColumn5.WrapText = true;
            gridViewTextBoxColumn6.FieldName = "Description";
            gridViewTextBoxColumn6.HeaderText = "Description";
            gridViewTextBoxColumn6.Name = "Description";
            gridViewTextBoxColumn6.Width = 400;
            gridViewTextBoxColumn6.WrapText = true;
            gridViewTextBoxColumn7.FieldName = "Privilege";
            gridViewTextBoxColumn7.HeaderText = "Privilege";
            gridViewTextBoxColumn7.Name = "Privilege";
            gridViewTextBoxColumn7.Width = 200;
            gridViewTextBoxColumn7.WrapText = true;
            gridViewTextBoxColumn8.FieldName = "Condition";
            gridViewTextBoxColumn8.HeaderText = "Condition";
            gridViewTextBoxColumn8.Name = "Condition";
            gridViewTextBoxColumn8.Width = 131;
            this.gvScholarship.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8});
            this.gvScholarship.MasterTemplate.EnableGrouping = false;
            this.gvScholarship.Name = "gvScholarship";
            this.gvScholarship.ShowGroupPanel = false;
            this.gvScholarship.Size = new System.Drawing.Size(955, 484);
            this.gvScholarship.TabIndex = 46;
            this.gvScholarship.Text = "radGridView3";
            this.gvScholarship.SelectionChanged += new System.EventHandler(this.gvScholarship_SelectionChanged);
            this.gvScholarship.DoubleClick += new System.EventHandler(this.btnEditScholarship_Click);
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.btnAddScholarship);
            this.radPanel2.Controls.Add(this.btnEditScholarship);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel2.Location = new System.Drawing.Point(0, 434);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(955, 50);
            this.radPanel2.TabIndex = 41;
            // 
            // btnAddScholarship
            // 
            this.btnAddScholarship.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddScholarship.Location = new System.Drawing.Point(771, 14);
            this.btnAddScholarship.Name = "btnAddScholarship";
            this.btnAddScholarship.Size = new System.Drawing.Size(83, 24);
            this.btnAddScholarship.TabIndex = 46;
            this.btnAddScholarship.Text = "Add";
            this.btnAddScholarship.Click += new System.EventHandler(this.btnAddScholarship_Click);
            // 
            // btnEditScholarship
            // 
            this.btnEditScholarship.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditScholarship.Location = new System.Drawing.Point(860, 14);
            this.btnEditScholarship.Name = "btnEditScholarship";
            this.btnEditScholarship.Size = new System.Drawing.Size(83, 24);
            this.btnEditScholarship.TabIndex = 44;
            this.btnEditScholarship.Text = "Edit";
            this.btnEditScholarship.Click += new System.EventHandler(this.btnEditScholarship_Click);
            // 
            // frmScholarshipList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 484);
            this.Controls.Add(this.radPanel2);
            this.Controls.Add(this.radPanel1);
            this.Name = "frmScholarshipList";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scholarship List";
            this.ThemeName = "ControlDefault";
            this.Activated += new System.EventHandler(this.frmScholarshipList_Activated);
            this.Load += new System.EventHandler(this.frmScholarshipList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvScholarship.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvScholarship)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAddScholarship)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditScholarship)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadButton btnAddScholarship;
        private Telerik.WinControls.UI.RadButton btnEditScholarship;
        private Telerik.WinControls.UI.RadGridView gvScholarship;
    }
}
