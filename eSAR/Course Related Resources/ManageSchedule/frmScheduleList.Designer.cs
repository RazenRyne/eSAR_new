namespace eSAR.Course_Related_Resources.ManageSchedule
{
    partial class frmScheduleList
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
            Telerik.WinControls.UI.SchedulerDailyPrintStyle schedulerDailyPrintStyle1 = new Telerik.WinControls.UI.SchedulerDailyPrintStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScheduleList));
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.radScheduler1 = new Telerik.WinControls.UI.RadScheduler();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.radPanel3 = new Telerik.WinControls.UI.RadPanel();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.cmbSection = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.cmbGradeLevel = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.btnCancelSchedule = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radScheduler1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).BeginInit();
            this.radPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGradeLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.radScheduler1);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Location = new System.Drawing.Point(0, 44);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1076, 534);
            this.radPanel1.TabIndex = 1;
            // 
            // radScheduler1
            // 
            this.radScheduler1.ActiveViewType = Telerik.WinControls.UI.SchedulerViewType.Week;
            this.radScheduler1.AllowAppointmentCreateInline = false;
            this.radScheduler1.AllowAppointmentMove = false;
            this.radScheduler1.AllowAppointmentResize = false;
            this.radScheduler1.AllowCopyPaste = Telerik.WinControls.UI.CopyPasteMode.Disallow;
            this.radScheduler1.Culture = new System.Globalization.CultureInfo("en-PH");
            this.radScheduler1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radScheduler1.Location = new System.Drawing.Point(0, 0);
            this.radScheduler1.Name = "radScheduler1";
            schedulerDailyPrintStyle1.AppointmentFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            schedulerDailyPrintStyle1.DateEndRange = new System.DateTime(2015, 11, 11, 0, 0, 0, 0);
            schedulerDailyPrintStyle1.DateHeadingFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            schedulerDailyPrintStyle1.DateStartRange = new System.DateTime(2015, 11, 6, 0, 0, 0, 0);
            schedulerDailyPrintStyle1.PageHeadingFont = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold);
            this.radScheduler1.PrintStyle = schedulerDailyPrintStyle1;
            this.radScheduler1.ReadOnly = true;
            this.radScheduler1.ShowAppointmentStatus = false;
            this.radScheduler1.ShowItemToolTips = false;
            this.radScheduler1.ShowNavigationElements = false;
            this.radScheduler1.Size = new System.Drawing.Size(1076, 534);
            this.radScheduler1.TabIndex = 0;
            this.radScheduler1.Text = "radScheduler1";
            this.radScheduler1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radScheduler1_MouseClick);
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.radPanel3);
            this.radPanel2.Controls.Add(this.btnCancelSchedule);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel2.Location = new System.Drawing.Point(0, 0);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(1076, 44);
            this.radPanel2.TabIndex = 41;
            // 
            // radPanel3
            // 
            this.radPanel3.BackColor = System.Drawing.Color.White;
            this.radPanel3.Controls.Add(this.radButton1);
            this.radPanel3.Controls.Add(this.cmbSection);
            this.radPanel3.Controls.Add(this.radLabel4);
            this.radPanel3.Controls.Add(this.cmbGradeLevel);
            this.radPanel3.Controls.Add(this.radLabel2);
            this.radPanel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.radPanel3.Location = new System.Drawing.Point(0, 0);
            this.radPanel3.Name = "radPanel3";
            this.radPanel3.Size = new System.Drawing.Size(969, 44);
            this.radPanel3.TabIndex = 42;
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(424, 13);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(83, 20);
            this.radButton1.TabIndex = 55;
            this.radButton1.Text = "Apply Filter";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // cmbSection
            // 
            this.cmbSection.DisplayMember = "Section";
            this.cmbSection.Enabled = false;
            this.cmbSection.Location = new System.Drawing.Point(284, 13);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Size = new System.Drawing.Size(130, 20);
            this.cmbSection.TabIndex = 54;
            this.cmbSection.ValueMember = "GradeSectionCode";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(233, 13);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(45, 18);
            this.radLabel4.TabIndex = 53;
            this.radLabel4.Text = "Section:";
            // 
            // cmbGradeLevel
            // 
            this.cmbGradeLevel.DisplayMember = "Description";
            this.cmbGradeLevel.Location = new System.Drawing.Point(90, 13);
            this.cmbGradeLevel.Name = "cmbGradeLevel";
            this.cmbGradeLevel.Size = new System.Drawing.Size(130, 20);
            this.cmbGradeLevel.TabIndex = 52;
            this.cmbGradeLevel.ValueMember = "GradeLev";
            this.cmbGradeLevel.SelectedValueChanged += new System.EventHandler(this.cmbGradeLevel_SelectedValueChanged);
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(42, 13);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(39, 18);
            this.radLabel2.TabIndex = 51;
            this.radLabel2.Text = "Grade:";
            // 
            // btnCancelSchedule
            // 
            this.btnCancelSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelSchedule.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelSchedule.Location = new System.Drawing.Point(980, 10);
            this.btnCancelSchedule.Name = "btnCancelSchedule";
            this.btnCancelSchedule.Size = new System.Drawing.Size(83, 24);
            this.btnCancelSchedule.TabIndex = 45;
            this.btnCancelSchedule.Text = "Close";
            this.btnCancelSchedule.Click += new System.EventHandler(this.btnCancelSchedule_Click);
            // 
            // frmScheduleList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelSchedule;
            this.ClientSize = new System.Drawing.Size(1076, 578);
            this.ControlBox = false;
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.radPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmScheduleList";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List of Subject Schedules";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.frmScheduleList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radScheduler1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).EndInit();
            this.radPanel3.ResumeLayout(false);
            this.radPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGradeLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadButton btnCancelSchedule;
        private Telerik.WinControls.UI.RadScheduler radScheduler1;
        private Telerik.WinControls.UI.RadPanel radPanel3;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadDropDownList cmbSection;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadDropDownList cmbGradeLevel;
        private Telerik.WinControls.UI.RadLabel radLabel2;
    }
}
