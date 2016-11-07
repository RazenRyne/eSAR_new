namespace eSARReportLibrary
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for PromoReportTemplate1.
    /// </summary>
    public partial class PromoReportTemplate1 : Telerik.Reporting.Report
    {
        public PromoReportTemplate1()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void PromoReportTemplate1_ItemDataBound(object sender, EventArgs e)
        {
            txtHeader1.Width = this.Width;
            txtHeader2.Width = this.Width;
            txtHeader3.Width = this.Width;
            txtHeader4.Width = this.Width;
            txtHeader5.Width = this.Width;
            txtTitle.Width = this.Width;
        }

    }
}