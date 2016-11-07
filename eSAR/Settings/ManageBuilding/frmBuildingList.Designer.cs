namespace eSAR.Settings.ManageBuilding
{
    partial class frmBuildingList
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
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.gvBuilding = new Telerik.WinControls.UI.RadGridView();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.btnAddBuilding = new Telerik.WinControls.UI.RadButton();
            this.btnEditBuilding = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvBuilding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBuilding.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddBuilding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditBuilding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.gvBuilding);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(849, 475);
            this.radPanel1.TabIndex = 0;
            // 
            // gvBuilding
            // 
            this.gvBuilding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvBuilding.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.gvBuilding.MasterTemplate.AllowAddNewRow = false;
            this.gvBuilding.MasterTemplate.AllowColumnReorder = false;
            this.gvBuilding.MasterTemplate.AllowDeleteRow = false;
            this.gvBuilding.MasterTemplate.AllowDragToGroup = false;
            this.gvBuilding.MasterTemplate.AllowEditRow = false;
            this.gvBuilding.MasterTemplate.AllowRowReorder = true;
            this.gvBuilding.MasterTemplate.AllowSearchRow = true;
            gridViewTextBoxColumn1.FieldName = "BuildingCode";
            gridViewTextBoxColumn1.HeaderText = "Building Code";
            gridViewTextBoxColumn1.Name = "BuildingCode";
            gridViewTextBoxColumn1.Width = 100;
            gridViewTextBoxColumn1.WrapText = true;
            gridViewTextBoxColumn2.FieldName = "BuildingName";
            gridViewTextBoxColumn2.HeaderText = "Building Name";
            gridViewTextBoxColumn2.Name = "BuildingName";
            gridViewTextBoxColumn2.Width = 250;
            gridViewTextBoxColumn2.WrapText = true;
            gridViewTextBoxColumn3.FieldName = "Description";
            gridViewTextBoxColumn3.HeaderText = "Description";
            gridViewTextBoxColumn3.Name = "Description";
            gridViewTextBoxColumn3.Width = 324;
            gridViewTextBoxColumn3.WrapText = true;
            this.gvBuilding.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3});
            this.gvBuilding.MasterTemplate.EnableGrouping = false;
            this.gvBuilding.MasterTemplate.ShowFilteringRow = false;
            this.gvBuilding.Name = "gvBuilding";
            this.gvBuilding.Size = new System.Drawing.Size(849, 475);
            this.gvBuilding.TabIndex = 45;
            this.gvBuilding.Text = "radGridView3";
            this.gvBuilding.SelectionChanged += new System.EventHandler(this.gvBuilding_SelectionChanged);
            this.gvBuilding.DoubleClick += new System.EventHandler(this.btnEditBuilding_Click);
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.btnAddBuilding);
            this.radPanel2.Controls.Add(this.btnEditBuilding);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel2.Location = new System.Drawing.Point(0, 425);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(849, 50);
            this.radPanel2.TabIndex = 40;
            // 
            // btnAddBuilding
            // 
            this.btnAddBuilding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddBuilding.Location = new System.Drawing.Point(665, 14);
            this.btnAddBuilding.Name = "btnAddBuilding";
            this.btnAddBuilding.Size = new System.Drawing.Size(83, 24);
            this.btnAddBuilding.TabIndex = 46;
            this.btnAddBuilding.Text = "Add";
            this.btnAddBuilding.Click += new System.EventHandler(this.btnAddBuilding_Click);
            // 
            // btnEditBuilding
            // 
            this.btnEditBuilding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditBuilding.Location = new System.Drawing.Point(754, 14);
            this.btnEditBuilding.Name = "btnEditBuilding";
            this.btnEditBuilding.Size = new System.Drawing.Size(83, 24);
            this.btnEditBuilding.TabIndex = 44;
            this.btnEditBuilding.Text = "Edit";
            this.btnEditBuilding.Click += new System.EventHandler(this.btnEditBuilding_Click);
            // 
            // frmBuildingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 475);
            this.Controls.Add(this.radPanel2);
            this.Controls.Add(this.radPanel1);
            this.Name = "frmBuildingList";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.Text = "Building List";
            this.ThemeName = "ControlDefault";
            this.Activated += new System.EventHandler(this.frmBuildingList_Activated);
            this.Load += new System.EventHandler(this.frmBuildingList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvBuilding.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBuilding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAddBuilding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditBuilding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadButton btnAddBuilding;
        private Telerik.WinControls.UI.RadButton btnEditBuilding;
        private Telerik.WinControls.UI.RadGridView gvBuilding;
    }
}
