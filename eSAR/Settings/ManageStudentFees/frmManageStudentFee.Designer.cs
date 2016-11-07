namespace eSAR.Settings.ManageStudentFees
{
    partial class frmManageStudentFee
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
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.txtDiscount = new Telerik.WinControls.UI.RadTextBox();
            this.cmbGradeLevel = new Telerik.WinControls.UI.RadDropDownList();
            this.txtAmount = new Telerik.WinControls.UI.RadTextBox();
            this.cmbSY = new Telerik.WinControls.UI.RadDropDownList();
            this.txtNumPay = new Telerik.WinControls.UI.RadTextBox();
            this.txtDescription = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGradeLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.radLabel8);
            this.radPanel1.Controls.Add(this.radLabel7);
            this.radPanel1.Controls.Add(this.txtDiscount);
            this.radPanel1.Controls.Add(this.cmbGradeLevel);
            this.radPanel1.Controls.Add(this.txtAmount);
            this.radPanel1.Controls.Add(this.cmbSY);
            this.radPanel1.Controls.Add(this.txtNumPay);
            this.radPanel1.Controls.Add(this.txtDescription);
            this.radPanel1.Controls.Add(this.radLabel6);
            this.radPanel1.Controls.Add(this.radLabel5);
            this.radPanel1.Controls.Add(this.radLabel4);
            this.radPanel1.Controls.Add(this.radLabel3);
            this.radPanel1.Controls.Add(this.radLabel2);
            this.radPanel1.Controls.Add(this.radLabel1);
            this.radPanel1.Location = new System.Drawing.Point(5, 6);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(499, 187);
            this.radPanel1.TabIndex = 0;
            // 
            // radLabel8
            // 
            this.radLabel8.Location = new System.Drawing.Point(431, 130);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(15, 18);
            this.radLabel8.TabIndex = 25;
            this.radLabel8.Text = "%";
            // 
            // radLabel7
            // 
            this.radLabel7.Location = new System.Drawing.Point(444, 61);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(2, 2);
            this.radLabel7.TabIndex = 24;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(378, 128);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDiscount.Size = new System.Drawing.Size(47, 20);
            this.txtDiscount.TabIndex = 23;
            this.txtDiscount.Text = "0";
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            this.txtDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_KeyPress);
            // 
            // cmbGradeLevel
            // 
            this.cmbGradeLevel.Location = new System.Drawing.Point(105, 93);
            this.cmbGradeLevel.Name = "cmbGradeLevel";
            this.cmbGradeLevel.Size = new System.Drawing.Size(132, 20);
            this.cmbGradeLevel.TabIndex = 22;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(378, 59);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAmount.Size = new System.Drawing.Size(101, 20);
            this.txtAmount.TabIndex = 21;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_KeyPress);
            // 
            // cmbSY
            // 
            this.cmbSY.Location = new System.Drawing.Point(105, 57);
            this.cmbSY.Name = "cmbSY";
            this.cmbSY.Size = new System.Drawing.Size(132, 20);
            this.cmbSY.TabIndex = 20;
            // 
            // txtNumPay
            // 
            this.txtNumPay.Location = new System.Drawing.Point(378, 92);
            this.txtNumPay.Name = "txtNumPay";
            this.txtNumPay.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNumPay.Size = new System.Drawing.Size(101, 20);
            this.txtNumPay.TabIndex = 19;
            this.txtNumPay.Text = "1";
            this.txtNumPay.Visible = false;
            this.txtNumPay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumPay_KeyPress);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(82, 17);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(284, 20);
            this.txtDescription.TabIndex = 18;
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(220, 130);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(153, 18);
            this.radLabel6.TabIndex = 17;
            this.radLabel6.Text = "% Discount for Full Payment :";
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(6, 95);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(86, 18);
            this.radLabel5.TabIndex = 16;
            this.radLabel5.Text = "For Grade Level:";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(6, 59);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(90, 18);
            this.radLabel4.TabIndex = 15;
            this.radLabel4.Text = "For School Year :";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(320, 61);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(52, 18);
            this.radLabel3.TabIndex = 14;
            this.radLabel3.Text = "Amount :";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(254, 94);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(118, 18);
            this.radLabel2.TabIndex = 13;
            this.radLabel2.Text = "Number of Payments :";
            this.radLabel2.Visible = false;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(6, 20);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(69, 18);
            this.radLabel1.TabIndex = 12;
            this.radLabel1.Text = "Description :";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(349, 227);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(69, 24);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(432, 227);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 24);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmManageStudentFee
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(510, 261);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.radPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmManageStudentFee";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Fees";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.frmManageStudentFee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGradeLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadTextBox txtDiscount;
        private Telerik.WinControls.UI.RadDropDownList cmbGradeLevel;
        private Telerik.WinControls.UI.RadTextBox txtAmount;
        private Telerik.WinControls.UI.RadDropDownList cmbSY;
        private Telerik.WinControls.UI.RadTextBox txtNumPay;
        private Telerik.WinControls.UI.RadTextBox txtDescription;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadLabel radLabel8;
    }
}
