namespace eSAR.Quarterly_Grading.Grading
{
    partial class frmAdvisersLoad
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdvisersLoad));
            Telerik.WinControls.UI.RadPrintWatermark radPrintWatermark1 = new Telerik.WinControls.UI.RadPrintWatermark();
            this.gvGradeSection = new Telerik.WinControls.UI.RadGridView();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.btnAddGrades = new Telerik.WinControls.UI.RadButton();
            this.btnPrint = new Telerik.WinControls.UI.RadButton();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.radPrintDocument1 = new Telerik.WinControls.UI.RadPrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.gvGradeSection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGradeSection.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddGrades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gvGradeSection
            // 
            this.gvGradeSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvGradeSection.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.gvGradeSection.MasterTemplate.AllowAddNewRow = false;
            this.gvGradeSection.MasterTemplate.AllowColumnReorder = false;
            this.gvGradeSection.MasterTemplate.AllowDeleteRow = false;
            this.gvGradeSection.MasterTemplate.AllowDragToGroup = false;
            this.gvGradeSection.MasterTemplate.AllowEditRow = false;
            this.gvGradeSection.MasterTemplate.AllowSearchRow = true;
            gridViewTextBoxColumn1.FieldName = "GradeLevel";
            gridViewTextBoxColumn1.HeaderText = "Grade Level";
            gridViewTextBoxColumn1.Name = "GradeLevel";
            gridViewTextBoxColumn1.Width = 100;
            gridViewTextBoxColumn2.FieldName = "Section";
            gridViewTextBoxColumn2.HeaderText = "Section";
            gridViewTextBoxColumn2.Name = "Section";
            gridViewTextBoxColumn2.Width = 150;
            gridViewTextBoxColumn3.FieldName = "HomeRoom.RoomCode";
            gridViewTextBoxColumn3.HeaderText = "Home Room";
            gridViewTextBoxColumn3.Name = "HomeRoom";
            gridViewTextBoxColumn3.Width = 100;
            gridViewTextBoxColumn4.FieldName = "TeacherName";
            gridViewTextBoxColumn4.HeaderText = "Adviser";
            gridViewTextBoxColumn4.Name = "TeacherName";
            gridViewTextBoxColumn4.Width = 200;
            gridViewTextBoxColumn5.FieldName = "GradeSectionCode";
            gridViewTextBoxColumn5.HeaderText = "column1";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "GradeSectionCode";
            this.gvGradeSection.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.gvGradeSection.MasterTemplate.EnableGrouping = false;
            this.gvGradeSection.Name = "gvGradeSection";
            this.gvGradeSection.ReadOnly = true;
            this.gvGradeSection.Size = new System.Drawing.Size(800, 410);
            this.gvGradeSection.TabIndex = 2;
            this.gvGradeSection.SelectionChanged += new System.EventHandler(this.gvGradeSection_SelectionChanged);
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.btnPrint);
            this.radPanel2.Controls.Add(this.btnAddGrades);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel2.Location = new System.Drawing.Point(0, 410);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(800, 39);
            this.radPanel2.TabIndex = 4;
            // 
            // btnAddGrades
            // 
            this.btnAddGrades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddGrades.Location = new System.Drawing.Point(628, 6);
            this.btnAddGrades.Name = "btnAddGrades";
            this.btnAddGrades.Size = new System.Drawing.Size(77, 24);
            this.btnAddGrades.TabIndex = 0;
            this.btnAddGrades.Text = "Add Grades";
            this.btnAddGrades.Click += new System.EventHandler(this.btnAddGrades_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(711, 6);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(77, 24);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // radPrintDocument1
            // 
            this.radPrintDocument1.FooterFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPrintDocument1.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPrintDocument1.Watermark = radPrintWatermark1;
            // 
            // frmAdvisersLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 449);
            this.Controls.Add(this.gvGradeSection);
            this.Controls.Add(this.radPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmAdvisersLoad";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List of Advisory Classes";
            this.Load += new System.EventHandler(this.frmAdvisersLoad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvGradeSection.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGradeSection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAddGrades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gvGradeSection;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadButton btnAddGrades;
        private Telerik.WinControls.UI.RadButton btnPrint;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private Telerik.WinControls.UI.RadPrintDocument radPrintDocument1;
    }
}
