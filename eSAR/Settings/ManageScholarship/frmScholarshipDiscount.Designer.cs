namespace eSAR.Settings.ManageScholarship
{
    partial class frmScholarshipDiscount
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
            this.btnSaveScholarshipDiscount = new Telerik.WinControls.UI.RadButton();
            this.btnCancelScholarshipDiscount = new Telerik.WinControls.UI.RadButton();
            this.cmbFee = new Telerik.WinControls.UI.RadDropDownList();
            this.txtCode = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txtDiscount = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel89 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveScholarshipDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelScholarshipDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel89)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.btnSaveScholarshipDiscount);
            this.radPanel1.Controls.Add(this.btnCancelScholarshipDiscount);
            this.radPanel1.Controls.Add(this.cmbFee);
            this.radPanel1.Controls.Add(this.txtCode);
            this.radPanel1.Controls.Add(this.radLabel2);
            this.radPanel1.Controls.Add(this.txtDiscount);
            this.radPanel1.Controls.Add(this.radLabel1);
            this.radPanel1.Controls.Add(this.radLabel89);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(254, 169);
            this.radPanel1.TabIndex = 3;
            // 
            // btnSaveScholarshipDiscount
            // 
            this.btnSaveScholarshipDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveScholarshipDiscount.Location = new System.Drawing.Point(40, 111);
            this.btnSaveScholarshipDiscount.Name = "btnSaveScholarshipDiscount";
            this.btnSaveScholarshipDiscount.Size = new System.Drawing.Size(83, 24);
            this.btnSaveScholarshipDiscount.TabIndex = 50;
            this.btnSaveScholarshipDiscount.Text = "Save";
            this.btnSaveScholarshipDiscount.Click += new System.EventHandler(this.btnSaveScholarshipDiscount_Click);
            // 
            // btnCancelScholarshipDiscount
            // 
            this.btnCancelScholarshipDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelScholarshipDiscount.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelScholarshipDiscount.Location = new System.Drawing.Point(129, 111);
            this.btnCancelScholarshipDiscount.Name = "btnCancelScholarshipDiscount";
            this.btnCancelScholarshipDiscount.Size = new System.Drawing.Size(83, 24);
            this.btnCancelScholarshipDiscount.TabIndex = 49;
            this.btnCancelScholarshipDiscount.Text = "Cancel";
            this.btnCancelScholarshipDiscount.Click += new System.EventHandler(this.btnCancelScholarshipDiscount_Click);
            // 
            // cmbFee
            // 
            this.cmbFee.Location = new System.Drawing.Point(82, 73);
            this.cmbFee.Name = "cmbFee";
            this.cmbFee.Size = new System.Drawing.Size(130, 20);
            this.cmbFee.TabIndex = 26;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(82, 21);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(130, 20);
            this.txtCode.TabIndex = 23;
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(23, 75);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(26, 18);
            this.radLabel2.TabIndex = 25;
            this.radLabel2.Text = "Fee:";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(82, 47);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(130, 20);
            this.txtDiscount.TabIndex = 22;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(23, 49);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(53, 18);
            this.radLabel1.TabIndex = 23;
            this.radLabel1.Text = "Discount:";
            // 
            // radLabel89
            // 
            this.radLabel89.Location = new System.Drawing.Point(24, 24);
            this.radLabel89.Name = "radLabel89";
            this.radLabel89.Size = new System.Drawing.Size(35, 18);
            this.radLabel89.TabIndex = 21;
            this.radLabel89.Text = "Code:";
            // 
            // frmScholarshipDiscount
            // 
            this.AcceptButton = this.btnSaveScholarshipDiscount;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelScholarshipDiscount;
            this.ClientSize = new System.Drawing.Size(254, 169);
            this.ControlBox = false;
            this.Controls.Add(this.radPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmScholarshipDiscount";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Scholarship Discount";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.frmScholarshipDiscount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveScholarshipDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelScholarshipDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel89)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox txtDiscount;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel89;
        private Telerik.WinControls.UI.RadTextBox txtCode;
        private Telerik.WinControls.UI.RadDropDownList cmbFee;
        private Telerik.WinControls.UI.RadButton btnSaveScholarshipDiscount;
        private Telerik.WinControls.UI.RadButton btnCancelScholarshipDiscount;
    }
}
