namespace eSAR.Settings.ManageUser
{
    partial class frmUserDetails
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
            Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem4 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem5 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem6 = new Telerik.WinControls.UI.RadListDataItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserDetails));
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txtUsername = new Telerik.WinControls.UI.RadTextBox();
            this.txtPassword = new Telerik.WinControls.UI.RadTextBox();
            this.txtFirstName = new Telerik.WinControls.UI.RadTextBox();
            this.txtMiddleName = new Telerik.WinControls.UI.RadTextBox();
            this.txtLastName = new Telerik.WinControls.UI.RadTextBox();
            this.txtRetypePWD = new Telerik.WinControls.UI.RadTextBox();
            this.cmbUserRole = new Telerik.WinControls.UI.RadDropDownList();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.lblPWD = new Telerik.WinControls.UI.RadLabel();
            this.lblRetypePWD = new Telerik.WinControls.UI.RadLabel();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.lblOldPWD = new Telerik.WinControls.UI.RadLabel();
            this.txtOldPWD = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.lblUserAst = new Telerik.WinControls.UI.RadLabel();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.lblOldAst = new Telerik.WinControls.UI.RadLabel();
            this.lblPWDast = new Telerik.WinControls.UI.RadLabel();
            this.lblReAst = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMiddleName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRetypePWD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUserRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPWD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRetypePWD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOldPWD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPWD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserAst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOldAst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPWDast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReAst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(13, 18);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(61, 18);
            this.radLabel1.TabIndex = 11;
            this.radLabel1.Text = "UserName:";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(13, 46);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(63, 18);
            this.radLabel2.TabIndex = 13;
            this.radLabel2.Text = "First Name:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(106, 16);
            this.txtUsername.MaxLength = 50;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(187, 20);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.Leave += new System.EventHandler(this.txtUsername_Leave);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(138, 172);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(155, 20);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(106, 42);
            this.txtFirstName.MaxLength = 50;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(187, 20);
            this.txtFirstName.TabIndex = 1;
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.Location = new System.Drawing.Point(106, 68);
            this.txtMiddleName.MaxLength = 50;
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(187, 20);
            this.txtMiddleName.TabIndex = 2;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(106, 94);
            this.txtLastName.MaxLength = 50;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(187, 20);
            this.txtLastName.TabIndex = 3;
            // 
            // txtRetypePWD
            // 
            this.txtRetypePWD.Location = new System.Drawing.Point(138, 198);
            this.txtRetypePWD.Name = "txtRetypePWD";
            this.txtRetypePWD.PasswordChar = '*';
            this.txtRetypePWD.Size = new System.Drawing.Size(155, 20);
            this.txtRetypePWD.TabIndex = 7;
            this.txtRetypePWD.TextChanged += new System.EventHandler(this.txtRetypePWD_TextChanged);
            // 
            // cmbUserRole
            // 
            radListDataItem1.Text = "Administrator";
            radListDataItem2.Text = "Principal";
            radListDataItem3.Text = "Registrar";
            radListDataItem4.Text = "Cashier";
            radListDataItem5.Text = "Teacher";
            radListDataItem6.Text = "Principal";
            this.cmbUserRole.Items.Add(radListDataItem1);
            this.cmbUserRole.Items.Add(radListDataItem2);
            this.cmbUserRole.Items.Add(radListDataItem3);
            this.cmbUserRole.Items.Add(radListDataItem4);
            this.cmbUserRole.Items.Add(radListDataItem5);
            this.cmbUserRole.Items.Add(radListDataItem6);
            this.cmbUserRole.Location = new System.Drawing.Point(106, 120);
            this.cmbUserRole.Name = "cmbUserRole";
            this.cmbUserRole.Size = new System.Drawing.Size(187, 20);
            this.cmbUserRole.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(210, 257);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 24);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(121, 257);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 24);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(13, 69);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(77, 18);
            this.radLabel3.TabIndex = 14;
            this.radLabel3.Text = "Middle Name:";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(13, 95);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(61, 18);
            this.radLabel4.TabIndex = 16;
            this.radLabel4.Text = "Last Name:";
            // 
            // lblPWD
            // 
            this.lblPWD.Location = new System.Drawing.Point(13, 174);
            this.lblPWD.Name = "lblPWD";
            this.lblPWD.Size = new System.Drawing.Size(56, 18);
            this.lblPWD.TabIndex = 21;
            this.lblPWD.Text = "Password:";
            // 
            // lblRetypePWD
            // 
            this.lblRetypePWD.Location = new System.Drawing.Point(12, 200);
            this.lblRetypePWD.Name = "lblRetypePWD";
            this.lblRetypePWD.Size = new System.Drawing.Size(98, 18);
            this.lblRetypePWD.TabIndex = 23;
            this.lblRetypePWD.Text = "Re-type Password:";
            // 
            // radLabel7
            // 
            this.radLabel7.Location = new System.Drawing.Point(14, 123);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(56, 18);
            this.radLabel7.TabIndex = 17;
            this.radLabel7.Text = "User Role:";
            // 
            // lblOldPWD
            // 
            this.lblOldPWD.Location = new System.Drawing.Point(13, 148);
            this.lblOldPWD.Name = "lblOldPWD";
            this.lblOldPWD.Size = new System.Drawing.Size(77, 18);
            this.lblOldPWD.TabIndex = 19;
            this.lblOldPWD.Text = "Old Password:";
            this.lblOldPWD.Visible = false;
            // 
            // txtOldPWD
            // 
            this.txtOldPWD.Location = new System.Drawing.Point(138, 146);
            this.txtOldPWD.Name = "txtOldPWD";
            this.txtOldPWD.PasswordChar = '*';
            this.txtOldPWD.Size = new System.Drawing.Size(155, 20);
            this.txtOldPWD.TabIndex = 5;
            this.txtOldPWD.Visible = false;
            // 
            // radLabel5
            // 
            this.radLabel5.AutoSize = false;
            this.radLabel5.Font = new System.Drawing.Font("Segoe UI", 7.25F, System.Drawing.FontStyle.Italic);
            this.radLabel5.ForeColor = System.Drawing.Color.Red;
            this.radLabel5.Location = new System.Drawing.Point(14, 224);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(292, 31);
            this.radLabel5.TabIndex = 24;
            this.radLabel5.Text = "*Password should consist of Numbers (0-9), lower case letters (a-z), and UPPER CA" +
    "SE LETTERS (A-Z)";
            // 
            // lblUserAst
            // 
            this.lblUserAst.ForeColor = System.Drawing.Color.Red;
            this.lblUserAst.Location = new System.Drawing.Point(6, 18);
            this.lblUserAst.Name = "lblUserAst";
            this.lblUserAst.Size = new System.Drawing.Size(11, 18);
            this.lblUserAst.TabIndex = 10;
            this.lblUserAst.Text = "*";
            // 
            // radLabel8
            // 
            this.radLabel8.ForeColor = System.Drawing.Color.Red;
            this.radLabel8.Location = new System.Drawing.Point(6, 45);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(11, 18);
            this.radLabel8.TabIndex = 12;
            this.radLabel8.Text = "*";
            // 
            // radLabel9
            // 
            this.radLabel9.ForeColor = System.Drawing.Color.Red;
            this.radLabel9.Location = new System.Drawing.Point(6, 95);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(11, 18);
            this.radLabel9.TabIndex = 15;
            this.radLabel9.Text = "*";
            // 
            // lblOldAst
            // 
            this.lblOldAst.ForeColor = System.Drawing.Color.Red;
            this.lblOldAst.Location = new System.Drawing.Point(5, 149);
            this.lblOldAst.Name = "lblOldAst";
            this.lblOldAst.Size = new System.Drawing.Size(11, 18);
            this.lblOldAst.TabIndex = 18;
            this.lblOldAst.Text = "*";
            this.lblOldAst.Visible = false;
            // 
            // lblPWDast
            // 
            this.lblPWDast.ForeColor = System.Drawing.Color.Red;
            this.lblPWDast.Location = new System.Drawing.Point(6, 175);
            this.lblPWDast.Name = "lblPWDast";
            this.lblPWDast.Size = new System.Drawing.Size(11, 18);
            this.lblPWDast.TabIndex = 20;
            this.lblPWDast.Text = "*";
            // 
            // lblReAst
            // 
            this.lblReAst.ForeColor = System.Drawing.Color.Red;
            this.lblReAst.Location = new System.Drawing.Point(5, 202);
            this.lblReAst.Name = "lblReAst";
            this.lblReAst.Size = new System.Drawing.Size(11, 18);
            this.lblReAst.TabIndex = 22;
            this.lblReAst.Text = "*";
            // 
            // frmUserDetails
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(318, 299);
            this.Controls.Add(this.txtRetypePWD);
            this.Controls.Add(this.lblReAst);
            this.Controls.Add(this.lblPWDast);
            this.Controls.Add(this.lblOldAst);
            this.Controls.Add(this.radLabel9);
            this.Controls.Add(this.radLabel8);
            this.Controls.Add(this.lblUserAst);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.lblOldPWD);
            this.Controls.Add(this.radLabel7);
            this.Controls.Add(this.txtOldPWD);
            this.Controls.Add(this.lblRetypePWD);
            this.Controls.Add(this.lblPWD);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cmbUserRole);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtMiddleName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmUserDetails";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Details";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.frmUserDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMiddleName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRetypePWD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUserRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPWD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRetypePWD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOldPWD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPWD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserAst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOldAst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPWDast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReAst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox txtUsername;
        private Telerik.WinControls.UI.RadTextBox txtPassword;
        private Telerik.WinControls.UI.RadTextBox txtFirstName;
        private Telerik.WinControls.UI.RadTextBox txtMiddleName;
        private Telerik.WinControls.UI.RadTextBox txtLastName;
        private Telerik.WinControls.UI.RadTextBox txtRetypePWD;
        private Telerik.WinControls.UI.RadDropDownList cmbUserRole;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel lblPWD;
        private Telerik.WinControls.UI.RadLabel lblRetypePWD;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadLabel lblOldPWD;
        private Telerik.WinControls.UI.RadTextBox txtOldPWD;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadLabel lblUserAst;
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private Telerik.WinControls.UI.RadLabel radLabel9;
        private Telerik.WinControls.UI.RadLabel lblOldAst;
        private Telerik.WinControls.UI.RadLabel lblPWDast;
        private Telerik.WinControls.UI.RadLabel lblReAst;
    }
}
