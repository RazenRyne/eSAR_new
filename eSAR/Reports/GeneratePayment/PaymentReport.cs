using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using eSAR.Utility_Classes;
using eSARServices;
using eSARServiceInterface;
using eSARServiceModels;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace eSAR.Reports.GeneratePayment
{
    public partial class PaymentReport : Telerik.WinControls.UI.RadForm
    {
        List<Payment> payment = new List<Payment>();
        string IDnum;
      
        public PaymentReport()
        {
            InitializeComponent();
         
        }

        public void setVars(string szIDnum)
        {
            IDnum = szIDnum;
        }

        private void loadList()
        {
           IPaymentService payService = new PaymentService();

            if (IDnum == "All")
                payment = new List<Payment>(payService.GetAllPayments());
            else
                payment = new List<Payment>(payService.GetAllStudentsPayments(IDnum));
                    

            gridView.DataSource = payment;

            GroupDescriptor descriptor = new GroupDescriptor();
            descriptor.GroupNames.Add("Student", ListSortDirection.Ascending);

 
            this.gridView.GroupDescriptors.Add(descriptor);

            GridViewSummaryItem summaryItem;

            if (IDnum != "All")
                summaryItem = new GridViewSummaryItem("Amount", "Total: {0}  Balance: " + payment[0].Balance, GridAggregateFunction.Sum);
            else
                summaryItem = new GridViewSummaryItem("Amount", "Total: {0}", GridAggregateFunction.Sum);



            GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem();
            summaryRowItem.Add(summaryItem);

            this.gridView.SummaryRowsBottom.Add(summaryRowItem);       

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            RadPrintDocument document = new RadPrintDocument();
            document.DefaultPageSettings.Landscape = true;
            document.HeaderHeight = 60;
            document.HeaderFont = new Font("Arial", 10, FontStyle.Bold);
            document.MiddleHeader = "Dansalan College Foundation, Inc. \r\n Marinaut, Marawi City, Lanao del Sur";
            document.MiddleFooter = "Page [Page #] of [Total Pages]";
            document.AssociatedObject = this.gridView;
            radPrintDocument1 = document;

            RadPrintPreviewDialog dialog = new RadPrintPreviewDialog();
            dialog.Document = this.radPrintDocument1;
            dialog.ShowDialog();
        }

        private void PaymentReport_Load(object sender, EventArgs e)
        {
            loadList();
        }
    }
}
