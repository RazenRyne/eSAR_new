using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace eSAR.Billing_and_Payment.PrintReceipt
{
    public partial class frmPrintReceipt : Telerik.WinControls.UI.RadForm
    {
        string _ORNo = string.Empty;
        string _receivedFrom = string.Empty;
        string _TIN = string.Empty;
        string _address = string.Empty;
        string _businessStyle = string.Empty;
        string _amountInText = string.Empty;
        string _amount = string.Empty;
        string _settlementFor = string.Empty;
        public bool bGenerated = false;

        public frmPrintReceipt()
        {
            InitializeComponent();
        }
        
        public void setVars(string szORNo, string szReceivedFrom, string szTIN, string szAddress,
            string szBusinessStyle, string szAmountInText, string szAmount, string szSettlementFor)
        {
            _ORNo = szORNo;
            _receivedFrom = szReceivedFrom;
            _TIN = szTIN;
            _address = szAddress;
            _businessStyle = szBusinessStyle;
            _amountInText = szAmountInText;
            _amount = szAmount;
            _settlementFor = szSettlementFor;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bGenerated = true;
            this.Close();
        }

        private void frmPrintReceipt_Load(object sender, EventArgs e)
        {
            reportViewer1.ReportSource.Parameters["ORNo"].Value = _ORNo;
            reportViewer1.ReportSource.Parameters["ReceiveFrom"].Value = _receivedFrom;
            reportViewer1.ReportSource.Parameters["TIN"].Value = _TIN;
            reportViewer1.ReportSource.Parameters["Address"].Value = _address;
            reportViewer1.ReportSource.Parameters["BusinessStyle"].Value = _businessStyle;
            reportViewer1.ReportSource.Parameters["AmountInText"].Value = _amountInText;
            reportViewer1.ReportSource.Parameters["Amount"].Value = _amount;
            reportViewer1.ReportSource.Parameters["SettlementFor"].Value = _settlementFor;
        
            this.reportViewer1.RefreshReport();
        }
    }
}
