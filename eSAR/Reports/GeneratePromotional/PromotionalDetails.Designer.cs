namespace eSAR.Reports.GeneratePromotional
{
    partial class PromotionalDetails
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
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.cmbSection = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.cmbSY = new Telerik.WinControls.UI.RadDropDownList();
            this.btnGenerate = new Telerik.WinControls.UI.RadButton();
            this.btnCancelScholarshipDiscount = new Telerik.WinControls.UI.RadButton();
            this.cmbGradeLevel = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel89 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenerate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelScholarshipDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGradeLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel89)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.cmbSection);
            this.radPanel1.Controls.Add(this.radLabel1);
            this.radPanel1.Controls.Add(this.cmbSY);
            this.radPanel1.Controls.Add(this.btnGenerate);
            this.radPanel1.Controls.Add(this.btnCancelScholarshipDiscount);
            this.radPanel1.Controls.Add(this.cmbGradeLevel);
            this.radPanel1.Controls.Add(this.radLabel2);
            this.radPanel1.Controls.Add(this.radLabel89);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(283, 155);
            this.radPanel1.TabIndex = 4;
            // 
            // cmbSection
            // 
            this.cmbSection.Location = new System.Drawing.Point(111, 79);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Size = new System.Drawing.Size(130, 20);
            this.cmbSection.TabIndex = 53;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(49, 79);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(45, 18);
            this.radLabel1.TabIndex = 52;
            this.radLabel1.Text = "Section:";
            // 
            // cmbSY
            // 
            this.cmbSY.Location = new System.Drawing.Point(111, 27);
            this.cmbSY.Name = "cmbSY";
            this.cmbSY.Size = new System.Drawing.Size(130, 20);
            this.cmbSY.TabIndex = 51;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(69, 116);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(83, 24);
            this.btnGenerate.TabIndex = 50;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnCancelScholarshipDiscount
            // 
            this.btnCancelScholarshipDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelScholarshipDiscount.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelScholarshipDiscount.Location = new System.Drawing.Point(158, 116);
            this.btnCancelScholarshipDiscount.Name = "btnCancelScholarshipDiscount";
            this.btnCancelScholarshipDiscount.Size = new System.Drawing.Size(83, 24);
            this.btnCancelScholarshipDiscount.TabIndex = 49;
            this.btnCancelScholarshipDiscount.Text = "Close";
            this.btnCancelScholarshipDiscount.Click += new System.EventHandler(this.btnCancelScholarshipDiscount_Click);
            // 
            // cmbGradeLevel
            // 
            this.cmbGradeLevel.Location = new System.Drawing.Point(111, 53);
            this.cmbGradeLevel.Name = "cmbGradeLevel";
            this.cmbGradeLevel.Size = new System.Drawing.Size(130, 20);
            this.cmbGradeLevel.TabIndex = 26;
            this.cmbGradeLevel.SelectedValueChanged += new System.EventHandler(this.cmbGradeLevel_SelectedValueChanged);
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(27, 53);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(67, 18);
            this.radLabel2.TabIndex = 25;
            this.radLabel2.Text = "Grade Level:";
            // 
            // radLabel89
            // 
            this.radLabel89.Location = new System.Drawing.Point(69, 27);
            this.radLabel89.Name = "radLabel89";
            this.radLabel89.Size = new System.Drawing.Size(26, 18);
            this.radLabel89.TabIndex = 21;
            this.radLabel89.Text = "S.Y.:";
            // 
            // PromotionalDetails
            // 
            this.AcceptButton = this.btnGenerate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelScholarshipDiscount;
            this.ClientSize = new System.Drawing.Size(283, 155);
            this.ControlBox = false;
            this.Controls.Add(this.radPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PromotionalDetails";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prospectus";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.LoadMe);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenerate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelScholarshipDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGradeLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel89)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadDropDownList cmbSection;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDropDownList cmbSY;
        private Telerik.WinControls.UI.RadButton btnGenerate;
        private Telerik.WinControls.UI.RadButton btnCancelScholarshipDiscount;
        private Telerik.WinControls.UI.RadDropDownList cmbGradeLevel;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel89;
    }
}
