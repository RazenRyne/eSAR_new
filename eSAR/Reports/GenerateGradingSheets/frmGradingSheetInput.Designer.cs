namespace eSAR.Reports.GenerateGradingSheets
{
    partial class frmGradingSheetInput
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
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            this.cmbSection = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.cmbGradeLevel = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.btnGenerate = new Telerik.WinControls.UI.RadButton();
            this.btnClose = new Telerik.WinControls.UI.RadButton();
            this.cmbSY = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.txtSection = new Telerik.WinControls.UI.RadTextBox();
            this.cmbReportType = new Telerik.WinControls.UI.RadDropDownList();
            this.lblType = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGradeLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenerate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbReportType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbSection
            // 
            this.cmbSection.DisplayMember = "Section";
            this.cmbSection.Location = new System.Drawing.Point(111, 74);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Size = new System.Drawing.Size(120, 20);
            this.cmbSection.TabIndex = 52;
            this.cmbSection.ValueMember = "GradeSectionCode";
            this.cmbSection.SelectedValueChanged += new System.EventHandler(this.cmbSection_SelectedValueChanged);
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(35, 74);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(45, 18);
            this.radLabel4.TabIndex = 51;
            this.radLabel4.Text = "Section:";
            // 
            // cmbGradeLevel
            // 
            this.cmbGradeLevel.DisplayMember = "Description";
            this.cmbGradeLevel.Location = new System.Drawing.Point(111, 48);
            this.cmbGradeLevel.Name = "cmbGradeLevel";
            this.cmbGradeLevel.Size = new System.Drawing.Size(120, 20);
            this.cmbGradeLevel.TabIndex = 50;
            this.cmbGradeLevel.ValueMember = "GradeLev";
            this.cmbGradeLevel.SelectedValueChanged += new System.EventHandler(this.cmbGradeLevel_SelectedValueChanged);
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(35, 48);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(39, 18);
            this.radLabel2.TabIndex = 49;
            this.radLabel2.Text = "Grade:";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(58, 162);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(83, 24);
            this.btnGenerate.TabIndex = 56;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(147, 162);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(83, 24);
            this.btnClose.TabIndex = 57;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmbSY
            // 
            this.cmbSY.DisplayMember = "SY";
            this.cmbSY.Location = new System.Drawing.Point(111, 22);
            this.cmbSY.Name = "cmbSY";
            this.cmbSY.Size = new System.Drawing.Size(120, 20);
            this.cmbSY.TabIndex = 63;
            this.cmbSY.ValueMember = "SY";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(35, 22);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(67, 18);
            this.radLabel1.TabIndex = 62;
            this.radLabel1.Text = "School Year:";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(35, 127);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(30, 18);
            this.radLabel3.TabIndex = 64;
            this.radLabel3.Text = "Title:";
            // 
            // txtSection
            // 
            this.txtSection.Location = new System.Drawing.Point(71, 126);
            this.txtSection.Name = "txtSection";
            this.txtSection.Size = new System.Drawing.Size(160, 20);
            this.txtSection.TabIndex = 65;
            // 
            // cmbReportType
            // 
            this.cmbReportType.DisplayMember = "Section";
            radListDataItem1.Text = "Subjects";
            radListDataItem2.Text = "Traits";
            this.cmbReportType.Items.Add(radListDataItem1);
            this.cmbReportType.Items.Add(radListDataItem2);
            this.cmbReportType.Location = new System.Drawing.Point(111, 100);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(120, 20);
            this.cmbReportType.TabIndex = 67;
            this.cmbReportType.Text = "Subjects";
            this.cmbReportType.ValueMember = "GradeSectionCode";
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(35, 100);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(33, 18);
            this.lblType.TabIndex = 66;
            this.lblType.Text = "Type:";
            // 
            // frmGradingSheetInput
            // 
            this.AcceptButton = this.btnGenerate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(272, 212);
            this.ControlBox = false;
            this.Controls.Add(this.cmbReportType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.txtSection);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.cmbSY);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.cmbSection);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.cmbGradeLevel);
            this.Controls.Add(this.radLabel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmGradingSheetInput";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grading Sheet Selection";
            this.Load += new System.EventHandler(this.frmGradingSheetInput_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbSection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGradeLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenerate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbReportType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadDropDownList cmbSection;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadDropDownList cmbGradeLevel;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton btnGenerate;
        private Telerik.WinControls.UI.RadButton btnClose;
        private Telerik.WinControls.UI.RadDropDownList cmbSY;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox txtSection;
        private Telerik.WinControls.UI.RadDropDownList cmbReportType;
        private Telerik.WinControls.UI.RadLabel lblType;
    }
}
