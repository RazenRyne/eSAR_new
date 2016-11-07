namespace eSAR.Settings
{
    partial class FrmActivateTeacher
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
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtLName = new Telerik.WinControls.UI.RadTextBox();
            this.txtMName = new Telerik.WinControls.UI.RadTextBox();
            this.txtFName = new Telerik.WinControls.UI.RadTextBox();
            this.btnActivate = new Telerik.WinControls.UI.RadButton();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnActivate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.radLabel4);
            this.radPanel2.Controls.Add(this.radLabel3);
            this.radPanel2.Controls.Add(this.radLabel2);
            this.radPanel2.Controls.Add(this.radLabel1);
            this.radPanel2.Controls.Add(this.txtLName);
            this.radPanel2.Controls.Add(this.txtMName);
            this.radPanel2.Controls.Add(this.txtFName);
            this.radPanel2.Location = new System.Drawing.Point(4, 12);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(402, 146);
            this.radPanel2.TabIndex = 2;
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(8, 12);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(143, 18);
            this.radLabel4.TabIndex = 19;
            this.radLabel4.Text = "Enter Teacher\'s Information";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(8, 97);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(64, 18);
            this.radLabel3.TabIndex = 18;
            this.radLabel3.Text = "Last Name :";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(8, 70);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(80, 18);
            this.radLabel2.TabIndex = 17;
            this.radLabel2.Text = "Middle Name :";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(8, 45);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(66, 18);
            this.radLabel1.TabIndex = 16;
            this.radLabel1.Text = "First Name :";
            // 
            // txtLName
            // 
            this.txtLName.AutoSize = false;
            this.txtLName.Location = new System.Drawing.Point(98, 95);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(252, 20);
            this.txtLName.TabIndex = 2;
            // 
            // txtMName
            // 
            this.txtMName.AutoSize = false;
            this.txtMName.Location = new System.Drawing.Point(98, 69);
            this.txtMName.Name = "txtMName";
            this.txtMName.Size = new System.Drawing.Size(252, 20);
            this.txtMName.TabIndex = 1;
            // 
            // txtFName
            // 
            this.txtFName.AutoSize = false;
            this.txtFName.Location = new System.Drawing.Point(98, 43);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(252, 20);
            this.txtFName.TabIndex = 0;
            // 
            // btnActivate
            // 
            this.btnActivate.Location = new System.Drawing.Point(263, 179);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(65, 24);
            this.btnActivate.TabIndex = 3;
            this.btnActivate.Text = "Activate";
            this.btnActivate.Click += new System.EventHandler(this.btnActivate_Click);
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(334, 179);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(65, 24);
            this.radButton1.TabIndex = 4;
            this.radButton1.Text = "Cancel";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // FrmActivateTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 215);
            this.ControlBox = false;
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.btnActivate);
            this.Controls.Add(this.radPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmActivateTeacher";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Activate Teacher";
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            this.radPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnActivate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadTextBox txtFName;
        private Telerik.WinControls.UI.RadTextBox txtLName;
        private Telerik.WinControls.UI.RadTextBox txtMName;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton btnActivate;
        private Telerik.WinControls.UI.RadButton radButton1;
    }
}
