namespace eSAR.Settings.ManageTimeSlot
{
    partial class frmTimeSlotList
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
            this.gvTimeSlot = new Telerik.WinControls.UI.RadGridView();
            this.pnFooter = new Telerik.WinControls.UI.RadPanel();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            this.btnEdit = new Telerik.WinControls.UI.RadButton();
            this.btnDelete = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.gvTimeSlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTimeSlot.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnFooter)).BeginInit();
            this.pnFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gvTimeSlot
            // 
            this.gvTimeSlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvTimeSlot.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.gvTimeSlot.MasterTemplate.AllowAddNewRow = false;
            this.gvTimeSlot.MasterTemplate.AllowColumnReorder = false;
            this.gvTimeSlot.MasterTemplate.AllowDeleteRow = false;
            this.gvTimeSlot.MasterTemplate.AllowDragToGroup = false;
            this.gvTimeSlot.MasterTemplate.AllowEditRow = false;
            this.gvTimeSlot.MasterTemplate.AllowSearchRow = true;
            gridViewTextBoxColumn1.FieldName = "TimeslotCode";
            gridViewTextBoxColumn1.HeaderText = "Code";
            gridViewTextBoxColumn1.Name = "TimeslotCode";
            gridViewTextBoxColumn1.Width = 150;
            gridViewTextBoxColumn2.FieldName = "TimeStart";
            gridViewTextBoxColumn2.HeaderText = "Time Start";
            gridViewTextBoxColumn2.Name = "TimeStart";
            gridViewTextBoxColumn2.Width = 256;
            gridViewTextBoxColumn3.FieldName = "TimeEnd";
            gridViewTextBoxColumn3.HeaderText = "Time End";
            gridViewTextBoxColumn3.Name = "TimeEnd";
            gridViewTextBoxColumn3.Width = 250;
            gridViewTextBoxColumn4.FieldName = "Days";
            gridViewTextBoxColumn4.HeaderText = "Days";
            gridViewTextBoxColumn4.Name = "Days";
            gridViewTextBoxColumn4.Width = 250;
            this.gvTimeSlot.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.gvTimeSlot.MasterTemplate.ShowRowHeaderColumn = false;
            this.gvTimeSlot.Name = "gvTimeSlot";
            this.gvTimeSlot.ShowGroupPanel = false;
            this.gvTimeSlot.Size = new System.Drawing.Size(955, 434);
            this.gvTimeSlot.TabIndex = 3;
            this.gvTimeSlot.Text = "radGridView1";
            this.gvTimeSlot.SelectionChanged += new System.EventHandler(this.gvTimeSlot_SelectionChanged);
            this.gvTimeSlot.DoubleClick += new System.EventHandler(this.btnEdit_Click);
            // 
            // pnFooter
            // 
            this.pnFooter.Controls.Add(this.btnAdd);
            this.pnFooter.Controls.Add(this.btnEdit);
            this.pnFooter.Controls.Add(this.btnDelete);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 434);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(955, 50);
            this.pnFooter.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(681, 14);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(83, 24);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(770, 14);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(83, 24);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(859, 14);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(83, 24);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmTimeSlotList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 484);
            this.Controls.Add(this.gvTimeSlot);
            this.Controls.Add(this.pnFooter);
            this.Name = "frmTimeSlotList";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Time Slots";
            this.ThemeName = "ControlDefault";
            this.Activated += new System.EventHandler(this.frmTimeSlotList_Activated);
            this.Load += new System.EventHandler(this.frmTimeSlotList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvTimeSlot.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTimeSlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnFooter)).EndInit();
            this.pnFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gvTimeSlot;
        private Telerik.WinControls.UI.RadPanel pnFooter;
        private Telerik.WinControls.UI.RadButton btnAdd;
        private Telerik.WinControls.UI.RadButton btnEdit;
        private Telerik.WinControls.UI.RadButton btnDelete;
    }
}
