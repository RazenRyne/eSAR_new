namespace eSAR.Billing_and_Payment.ManageReceipt
{
    partial class frmManageReceipt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageReceipt));
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel89 = new Telerik.WinControls.UI.RadLabel();
            this.txtReceiptTo = new Telerik.WinControls.UI.RadTextBox();
            this.txtReceiptFrom = new Telerik.WinControls.UI.RadTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel89)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReceiptTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReceiptFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.btnSave);
            this.radPanel2.Controls.Add(this.btnCancel);
            this.radPanel2.Controls.Add(this.radLabel1);
            this.radPanel2.Controls.Add(this.radLabel89);
            this.radPanel2.Controls.Add(this.txtReceiptTo);
            this.radPanel2.Controls.Add(this.txtReceiptFrom);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel2.Location = new System.Drawing.Point(0, 2);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(306, 137);
            this.radPanel2.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(72, 91);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 24);
            this.btnSave.TabIndex = 46;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(161, 91);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 24);
            this.btnCancel.TabIndex = 47;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(40, 55);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(80, 18);
            this.radLabel1.TabIndex = 23;
            this.radLabel1.Text = "Receipt No. To";
            // 
            // radLabel89
            // 
            this.radLabel89.Location = new System.Drawing.Point(40, 28);
            this.radLabel89.Name = "radLabel89";
            this.radLabel89.Size = new System.Drawing.Size(93, 18);
            this.radLabel89.TabIndex = 22;
            this.radLabel89.Text = "Receipt No. From";
            // 
            // txtReceiptTo
            // 
            this.txtReceiptTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReceiptTo.Location = new System.Drawing.Point(159, 53);
            this.txtReceiptTo.MaxLength = 10;
            this.txtReceiptTo.Name = "txtReceiptTo";
            this.txtReceiptTo.Size = new System.Drawing.Size(115, 20);
            this.txtReceiptTo.TabIndex = 21;
            this.txtReceiptTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_KeyPress);
            // 
            // txtReceiptFrom
            // 
            this.txtReceiptFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReceiptFrom.Location = new System.Drawing.Point(159, 27);
            this.txtReceiptFrom.MaxLength = 10;
            this.txtReceiptFrom.Name = "txtReceiptFrom";
            this.txtReceiptFrom.Size = new System.Drawing.Size(115, 20);
            this.txtReceiptFrom.TabIndex = 20;
            this.txtReceiptFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_KeyPress);
            // 
            // frmManageReceipt
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(306, 139);
            this.Controls.Add(this.radPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmManageReceipt";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Receipt";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            this.radPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel89)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReceiptTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReceiptFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadTextBox txtReceiptTo;
        private Telerik.WinControls.UI.RadTextBox txtReceiptFrom;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel89;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadButton btnCancel;
    }
}
