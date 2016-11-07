namespace eSAR.Settings.ManageStudentFees
{
    partial class StudentFeeList
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.btnEdit = new Telerik.WinControls.UI.RadButton();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            this.gvFees = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFees.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.btnEdit);
            this.radPanel2.Controls.Add(this.btnAdd);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel2.Location = new System.Drawing.Point(0, 389);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(823, 50);
            this.radPanel2.TabIndex = 1;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(742, 14);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(69, 24);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(669, 14);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(69, 24);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gvFees
            // 
            this.gvFees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvFees.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.gvFees.MasterTemplate.AllowAddNewRow = false;
            this.gvFees.MasterTemplate.AllowColumnReorder = false;
            this.gvFees.MasterTemplate.AllowDeleteRow = false;
            this.gvFees.MasterTemplate.AllowEditRow = false;
            this.gvFees.MasterTemplate.AllowSearchRow = true;
            gridViewTextBoxColumn8.FieldName = "FeeID";
            gridViewTextBoxColumn8.HeaderText = "Fee Code";
            gridViewTextBoxColumn8.IsVisible = false;
            gridViewTextBoxColumn8.Name = "FeeID";
            gridViewTextBoxColumn9.FieldName = "Amount";
            gridViewTextBoxColumn9.HeaderText = "Amount";
            gridViewTextBoxColumn9.Name = "Amount";
            gridViewTextBoxColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn9.Width = 100;
            gridViewTextBoxColumn10.FieldName = "FeeDescription";
            gridViewTextBoxColumn10.HeaderText = "Description";
            gridViewTextBoxColumn10.Name = "FeeDescription";
            gridViewTextBoxColumn10.Width = 250;
            gridViewTextBoxColumn11.FieldName = "NumPay";
            gridViewTextBoxColumn11.HeaderText = "# of Payments";
            gridViewTextBoxColumn11.Name = "NumPay";
            gridViewTextBoxColumn11.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn11.Width = 80;
            gridViewTextBoxColumn12.FieldName = "SYImplemented";
            gridViewTextBoxColumn12.HeaderText = "School Year";
            gridViewTextBoxColumn12.Name = "SYImplemented";
            gridViewTextBoxColumn12.Width = 100;
            gridViewTextBoxColumn13.FieldName = "GradeLev";
            gridViewTextBoxColumn13.HeaderText = "Grade Level";
            gridViewTextBoxColumn13.Name = "GradeLev";
            gridViewTextBoxColumn13.Width = 100;
            gridViewTextBoxColumn14.FieldName = "DiscountFullPay";
            gridViewTextBoxColumn14.HeaderText = "Discount for FP";
            gridViewTextBoxColumn14.Name = "DiscountFullPay";
            gridViewTextBoxColumn14.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn14.Width = 100;
            this.gvFees.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14});
            this.gvFees.MasterTemplate.EnableGrouping = false;
            this.gvFees.Name = "gvFees";
            this.gvFees.ReadOnly = true;
            this.gvFees.Size = new System.Drawing.Size(823, 389);
            this.gvFees.TabIndex = 2;
            this.gvFees.Text = "radGridView1";
            this.gvFees.SelectionChanged += new System.EventHandler(this.gvFees_SelectionChanged);
            this.gvFees.DoubleClick += new System.EventHandler(this.btnEdit_Click);
            // 
            // StudentFeeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 439);
            this.Controls.Add(this.gvFees);
            this.Controls.Add(this.radPanel2);
            this.Name = "StudentFeeList";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List of Student Fees";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.StudentFeeList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFees.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadButton btnEdit;
        private Telerik.WinControls.UI.RadButton btnAdd;
        private Telerik.WinControls.UI.RadGridView gvFees;
    }
}
