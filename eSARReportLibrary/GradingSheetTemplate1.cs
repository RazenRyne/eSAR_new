namespace eSARReportLibrary
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for GradingSheetTemplate1.
    /// </summary>
    public partial class GradingSheetTemplate1 : Telerik.Reporting.Report
    {
        public GradingSheetTemplate1()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void GradingSheetTemplate1_ItemDataBound(object sender, EventArgs e)
        {
            txtHeaderDC.Width = crosstab1.Width;
            txtHeaderPlace.Width = crosstab1.Width;
            txtHeaderTitle.Width = crosstab1.Width;
            txtSY.Width = crosstab1.Width;
        }
    }
}