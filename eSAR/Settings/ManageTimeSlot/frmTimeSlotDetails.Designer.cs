namespace eSAR.Settings.ManageTimeSlot
{
    partial class frmTimeSlotDetails
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
            this.txtTimeslotCode = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.chkSunday = new Telerik.WinControls.UI.RadCheckBox();
            this.chkMonday = new Telerik.WinControls.UI.RadCheckBox();
            this.chkTuesday = new Telerik.WinControls.UI.RadCheckBox();
            this.chkWednesday = new Telerik.WinControls.UI.RadCheckBox();
            this.chkThursday = new Telerik.WinControls.UI.RadCheckBox();
            this.chkFriday = new Telerik.WinControls.UI.RadCheckBox();
            this.chkSaturday = new Telerik.WinControls.UI.RadCheckBox();
            this.tPStart = new Telerik.WinControls.UI.RadTimePicker();
            this.tpEnd = new Telerik.WinControls.UI.RadTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeslotCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSunday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMonday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTuesday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWednesday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkThursday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFriday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSaturday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tPStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tpEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTimeslotCode
            // 
            this.txtTimeslotCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTimeslotCode.Location = new System.Drawing.Point(109, 23);
            this.txtTimeslotCode.MaxLength = 5;
            this.txtTimeslotCode.Name = "txtTimeslotCode";
            this.txtTimeslotCode.Size = new System.Drawing.Size(128, 20);
            this.txtTimeslotCode.TabIndex = 0;
            this.txtTimeslotCode.Leave += new System.EventHandler(this.txtTimeslotCode_Leave);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(16, 25);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(35, 18);
            this.radLabel1.TabIndex = 13;
            this.radLabel1.Text = "Code:";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(16, 49);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(59, 18);
            this.radLabel2.TabIndex = 14;
            this.radLabel2.Text = "Time Start:";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(16, 75);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(55, 18);
            this.radLabel3.TabIndex = 15;
            this.radLabel3.Text = "Time End:";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(16, 99);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(33, 18);
            this.radLabel4.TabIndex = 16;
            this.radLabel4.Text = "Days:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(65, 210);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 24);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(154, 210);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 24);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkSunday
            // 
            this.chkSunday.Location = new System.Drawing.Point(55, 100);
            this.chkSunday.Name = "chkSunday";
            this.chkSunday.Size = new System.Drawing.Size(57, 18);
            this.chkSunday.TabIndex = 3;
            this.chkSunday.Text = "Sunday";
            // 
            // chkMonday
            // 
            this.chkMonday.Location = new System.Drawing.Point(160, 100);
            this.chkMonday.Name = "chkMonday";
            this.chkMonday.Size = new System.Drawing.Size(61, 18);
            this.chkMonday.TabIndex = 4;
            this.chkMonday.Text = "Monday";
            // 
            // chkTuesday
            // 
            this.chkTuesday.Location = new System.Drawing.Point(55, 124);
            this.chkTuesday.Name = "chkTuesday";
            this.chkTuesday.Size = new System.Drawing.Size(61, 18);
            this.chkTuesday.TabIndex = 5;
            this.chkTuesday.Text = "Tuesday";
            // 
            // chkWednesday
            // 
            this.chkWednesday.Location = new System.Drawing.Point(160, 124);
            this.chkWednesday.Name = "chkWednesday";
            this.chkWednesday.Size = new System.Drawing.Size(78, 18);
            this.chkWednesday.TabIndex = 6;
            this.chkWednesday.Text = "Wednesday";
            // 
            // chkThursday
            // 
            this.chkThursday.Location = new System.Drawing.Point(55, 148);
            this.chkThursday.Name = "chkThursday";
            this.chkThursday.Size = new System.Drawing.Size(66, 18);
            this.chkThursday.TabIndex = 7;
            this.chkThursday.Text = "Thursday";
            // 
            // chkFriday
            // 
            this.chkFriday.Location = new System.Drawing.Point(160, 148);
            this.chkFriday.Name = "chkFriday";
            this.chkFriday.Size = new System.Drawing.Size(50, 18);
            this.chkFriday.TabIndex = 8;
            this.chkFriday.Text = "Friday";
            // 
            // chkSaturday
            // 
            this.chkSaturday.Location = new System.Drawing.Point(55, 172);
            this.chkSaturday.Name = "chkSaturday";
            this.chkSaturday.Size = new System.Drawing.Size(64, 18);
            this.chkSaturday.TabIndex = 9;
            this.chkSaturday.Text = "Saturday";
            // 
            // tPStart
            // 
            this.tPStart.Location = new System.Drawing.Point(109, 48);
            this.tPStart.MaxValue = new System.DateTime(9999, 12, 31, 23, 59, 59, 0);
            this.tPStart.MinValue = new System.DateTime(((long)(0)));
            this.tPStart.Name = "tPStart";
            this.tPStart.Size = new System.Drawing.Size(107, 20);
            this.tPStart.TabIndex = 1;
            this.tPStart.TabStop = false;
            this.tPStart.Text = "radTimePicker1";
            this.tPStart.Value = new System.DateTime(2015, 8, 15, 14, 8, 46, 937);
            // 
            // tpEnd
            // 
            this.tpEnd.Location = new System.Drawing.Point(109, 73);
            this.tpEnd.MaxValue = new System.DateTime(9999, 12, 31, 23, 59, 59, 0);
            this.tpEnd.MinValue = new System.DateTime(((long)(0)));
            this.tpEnd.Name = "tpEnd";
            this.tpEnd.Size = new System.Drawing.Size(107, 20);
            this.tpEnd.TabIndex = 2;
            this.tpEnd.TabStop = false;
            this.tpEnd.Value = new System.DateTime(2015, 8, 15, 14, 8, 46, 937);
            // 
            // frmTimeSlotDetails
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(269, 258);
            this.ControlBox = false;
            this.Controls.Add(this.tpEnd);
            this.Controls.Add(this.tPStart);
            this.Controls.Add(this.chkSaturday);
            this.Controls.Add(this.chkFriday);
            this.Controls.Add(this.chkThursday);
            this.Controls.Add(this.chkWednesday);
            this.Controls.Add(this.chkTuesday);
            this.Controls.Add(this.chkMonday);
            this.Controls.Add(this.chkSunday);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.txtTimeslotCode);
            this.Controls.Add(this.radLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTimeSlotDetails";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage TimeSlots";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.frmTimeSlotDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeslotCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSunday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMonday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTuesday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWednesday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkThursday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFriday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSaturday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tPStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tpEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBox txtTimeslotCode;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadCheckBox chkSunday;
        private Telerik.WinControls.UI.RadCheckBox chkMonday;
        private Telerik.WinControls.UI.RadCheckBox chkTuesday;
        private Telerik.WinControls.UI.RadCheckBox chkWednesday;
        private Telerik.WinControls.UI.RadCheckBox chkThursday;
        private Telerik.WinControls.UI.RadCheckBox chkFriday;
        private Telerik.WinControls.UI.RadCheckBox chkSaturday;
        private Telerik.WinControls.UI.RadTimePicker tPStart;
        private Telerik.WinControls.UI.RadTimePicker tpEnd;
    }
}
