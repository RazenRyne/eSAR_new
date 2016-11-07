namespace eSAR.Reports.GenerateTeachersLoad
{
    partial class TeachersLoadDetails
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
            this.cmbTeacher = new Telerik.WinControls.UI.RadDropDownList();
            this.btnSaveScholarshipDiscount = new Telerik.WinControls.UI.RadButton();
            this.btnClose = new Telerik.WinControls.UI.RadButton();
            this.radLabel89 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTeacher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveScholarshipDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel89)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.cmbTeacher);
            this.radPanel1.Controls.Add(this.btnSaveScholarshipDiscount);
            this.radPanel1.Controls.Add(this.btnClose);
            this.radPanel1.Controls.Add(this.radLabel89);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(287, 117);
            this.radPanel1.TabIndex = 5;
            // 
            // cmbTeacher
            // 
            this.cmbTeacher.Location = new System.Drawing.Point(90, 27);
            this.cmbTeacher.Name = "cmbTeacher";
            this.cmbTeacher.Size = new System.Drawing.Size(151, 20);
            this.cmbTeacher.TabIndex = 51;
            // 
            // btnSaveScholarshipDiscount
            // 
            this.btnSaveScholarshipDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveScholarshipDiscount.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSaveScholarshipDiscount.Location = new System.Drawing.Point(58, 63);
            this.btnSaveScholarshipDiscount.Name = "btnSaveScholarshipDiscount";
            this.btnSaveScholarshipDiscount.Size = new System.Drawing.Size(83, 24);
            this.btnSaveScholarshipDiscount.TabIndex = 50;
            this.btnSaveScholarshipDiscount.Text = "Print";
            this.btnSaveScholarshipDiscount.Click += new System.EventHandler(this.LoadMe);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(147, 63);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(83, 24);
            this.btnClose.TabIndex = 49;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // radLabel89
            // 
            this.radLabel89.Location = new System.Drawing.Point(45, 27);
            this.radLabel89.Name = "radLabel89";
            this.radLabel89.Size = new System.Drawing.Size(39, 18);
            this.radLabel89.TabIndex = 21;
            this.radLabel89.Text = "Name:";
            // 
            // TeachersLoadDetails
            // 
            this.AcceptButton = this.btnSaveScholarshipDiscount;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(287, 117);
            this.ControlBox = false;
            this.Controls.Add(this.radPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TeachersLoadDetails";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Teachers Load";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.LoadMe);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTeacher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveScholarshipDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel89)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadDropDownList cmbTeacher;
        private Telerik.WinControls.UI.RadButton btnSaveScholarshipDiscount;
        private Telerik.WinControls.UI.RadButton btnClose;
        private Telerik.WinControls.UI.RadLabel radLabel89;
    }
}
