namespace eSAR.Settings.ManageScholarship
{
    partial class frmScholarshipDetails
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.txtDescription = new Telerik.WinControls.UI.RadTextBox();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.gvScholarshipDetails = new Telerik.WinControls.UI.RadGridView();
            this.txtCondition = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txtPrivilege = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtScholarshipCode = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel89 = new Telerik.WinControls.UI.RadLabel();
            this.radPanel3 = new Telerik.WinControls.UI.RadPanel();
            this.btnSaveScholarship = new Telerik.WinControls.UI.RadButton();
            this.btnBackScholarship = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvScholarshipDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvScholarshipDetails.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCondition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrivilege)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtScholarshipCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel89)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).BeginInit();
            this.radPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveScholarship)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBackScholarship)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.txtDescription);
            this.radPanel1.Controls.Add(this.radPanel2);
            this.radPanel1.Controls.Add(this.txtCondition);
            this.radPanel1.Controls.Add(this.radLabel3);
            this.radPanel1.Controls.Add(this.radLabel2);
            this.radPanel1.Controls.Add(this.txtPrivilege);
            this.radPanel1.Controls.Add(this.radLabel1);
            this.radPanel1.Controls.Add(this.txtScholarshipCode);
            this.radPanel1.Controls.Add(this.radLabel89);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(538, 470);
            this.radPanel1.TabIndex = 2;
            // 
            // txtDescription
            // 
            this.txtDescription.AutoSize = false;
            this.txtDescription.Location = new System.Drawing.Point(291, 24);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(218, 113);
            this.txtDescription.TabIndex = 21;
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.gvScholarshipDetails);
            this.radPanel2.Location = new System.Drawing.Point(24, 171);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(485, 245);
            this.radPanel2.TabIndex = 28;
            // 
            // gvScholarshipDetails
            // 
            this.gvScholarshipDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvScholarshipDetails.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.gvScholarshipDetails.MasterTemplate.AllowDragToGroup = false;
            gridViewTextBoxColumn3.FieldName = "ScholarshipDiscountId";
            gridViewTextBoxColumn3.HeaderText = "ID";
            gridViewTextBoxColumn3.Name = "ScholarshipDiscountId";
            gridViewTextBoxColumn3.Width = 70;
            gridViewTextBoxColumn4.FieldName = "Discount";
            gridViewTextBoxColumn4.HeaderText = "Discount";
            gridViewTextBoxColumn4.Name = "Discount";
            gridViewTextBoxColumn4.Width = 216;
            this.gvScholarshipDetails.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.gvScholarshipDetails.Name = "gvScholarshipDetails";
            this.gvScholarshipDetails.ShowGroupPanel = false;
            this.gvScholarshipDetails.Size = new System.Drawing.Size(485, 245);
            this.gvScholarshipDetails.TabIndex = 48;
            this.gvScholarshipDetails.Text = "radGridView3";
            this.gvScholarshipDetails.CellBeginEdit += new Telerik.WinControls.UI.GridViewCellCancelEventHandler(this.gvScholarshipDiscounts_CellBeginEdit);
            this.gvScholarshipDetails.CellEditorInitialized += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvScholarships_CellEditorInitialized);
            this.gvScholarshipDetails.ValueChanging += new Telerik.WinControls.UI.ValueChangingEventHandler(this.gvScholarshipDiscounts_ValueChanging);
            this.gvScholarshipDetails.UserAddingRow += new Telerik.WinControls.UI.GridViewRowCancelEventHandler(this.gvScholarshipDiscount_UserAddingRow);
            this.gvScholarshipDetails.UserAddedRow += new Telerik.WinControls.UI.GridViewRowEventHandler(this.gvScholarshipDiscounts_UserAddedRow);
            // 
            // txtCondition
            // 
            this.txtCondition.Location = new System.Drawing.Point(83, 76);
            this.txtCondition.Name = "txtCondition";
            this.txtCondition.Size = new System.Drawing.Size(130, 20);
            this.txtCondition.TabIndex = 24;
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(219, 24);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(66, 18);
            this.radLabel3.TabIndex = 27;
            this.radLabel3.Text = "Description:";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(24, 78);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(58, 18);
            this.radLabel2.TabIndex = 25;
            this.radLabel2.Text = "Condition:";
            // 
            // txtPrivilege
            // 
            this.txtPrivilege.Location = new System.Drawing.Point(83, 50);
            this.txtPrivilege.Name = "txtPrivilege";
            this.txtPrivilege.Size = new System.Drawing.Size(130, 20);
            this.txtPrivilege.TabIndex = 22;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(24, 52);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(51, 18);
            this.radLabel1.TabIndex = 23;
            this.radLabel1.Text = "Privilege:";
            // 
            // txtScholarshipCode
            // 
            this.txtScholarshipCode.Location = new System.Drawing.Point(83, 24);
            this.txtScholarshipCode.Name = "txtScholarshipCode";
            this.txtScholarshipCode.Size = new System.Drawing.Size(130, 20);
            this.txtScholarshipCode.TabIndex = 20;
            // 
            // radLabel89
            // 
            this.radLabel89.Location = new System.Drawing.Point(24, 26);
            this.radLabel89.Name = "radLabel89";
            this.radLabel89.Size = new System.Drawing.Size(35, 18);
            this.radLabel89.TabIndex = 21;
            this.radLabel89.Text = "Code:";
            // 
            // radPanel3
            // 
            this.radPanel3.Controls.Add(this.btnSaveScholarship);
            this.radPanel3.Controls.Add(this.btnBackScholarship);
            this.radPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel3.Location = new System.Drawing.Point(0, 420);
            this.radPanel3.Name = "radPanel3";
            this.radPanel3.Size = new System.Drawing.Size(538, 50);
            this.radPanel3.TabIndex = 3;
            // 
            // btnSaveScholarship
            // 
            this.btnSaveScholarship.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveScholarship.Location = new System.Drawing.Point(354, 14);
            this.btnSaveScholarship.Name = "btnSaveScholarship";
            this.btnSaveScholarship.Size = new System.Drawing.Size(83, 24);
            this.btnSaveScholarship.TabIndex = 50;
            this.btnSaveScholarship.Text = "Save";
            this.btnSaveScholarship.Click += new System.EventHandler(this.btnSaveScholarship_Click);
            // 
            // btnBackScholarship
            // 
            this.btnBackScholarship.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackScholarship.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBackScholarship.Location = new System.Drawing.Point(443, 14);
            this.btnBackScholarship.Name = "btnBackScholarship";
            this.btnBackScholarship.Size = new System.Drawing.Size(83, 24);
            this.btnBackScholarship.TabIndex = 49;
            this.btnBackScholarship.Text = "Back";
            this.btnBackScholarship.Click += new System.EventHandler(this.btnBackScholarship_Click);
            // 
            // frmScholarshipDetails
            // 
            this.AcceptButton = this.btnSaveScholarship;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnBackScholarship;
            this.ClientSize = new System.Drawing.Size(538, 470);
            this.Controls.Add(this.radPanel3);
            this.Controls.Add(this.radPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmScholarshipDetails";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Scholarship";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.fmScholarship_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvScholarshipDetails.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvScholarshipDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCondition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrivilege)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtScholarshipCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel89)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).EndInit();
            this.radPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveScholarship)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBackScholarship)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadTextBox txtScholarshipCode;
        private Telerik.WinControls.UI.RadLabel radLabel89;
        private Telerik.WinControls.UI.RadTextBox txtPrivilege;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtCondition;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadTextBox txtDescription;
        private Telerik.WinControls.UI.RadGridView gvScholarshipDetails;
        private Telerik.WinControls.UI.RadPanel radPanel3;
        private Telerik.WinControls.UI.RadButton btnSaveScholarship;
        private Telerik.WinControls.UI.RadButton btnBackScholarship;
    }
}
