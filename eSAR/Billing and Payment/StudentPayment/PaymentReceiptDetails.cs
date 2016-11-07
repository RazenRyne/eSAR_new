using eSAR.Billing_and_Payment.PrintReceipt;
using eSAR.Utility_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace eSAR.Billing_and_Payment.StudentPayment
{
    public partial class PaymentReceiptDetails : Telerik.WinControls.UI.RadForm
    {
        public string StudentID = string.Empty;
        public string StudentName = string.Empty;
        public string btnPushed { get; set; }
        public int ORno { get; set; }

        private string _ReceivedFrom = string.Empty;
        public string ReceivedFrom
        {
            get { return _ReceivedFrom; }
            set { _ReceivedFrom = value; }
        }

        private string _TIN = string.Empty;
        public string TIN
        {
            get { return _TIN; }
            set { _TIN = value; }
        }

        private string _AddressAt = string.Empty;
        public string AddressAt
        {
            get { return _AddressAt; }
            set { _AddressAt = value; }
        }

        private string _BusinessStyle = string.Empty;
        public string BusinessStyle
        {
            get { return _BusinessStyle; }
            set { _BusinessStyle = value; }
        }

        private float _Amount = 0;
        public float Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        private string _AmountInText = string.Empty;
        public string AmountInText
        {
            get { return _AmountInText; }
            set { _AmountInText = value; }
        }

        private string _PartialFull = string.Empty;
        public string PartialFull
        {
            get { return _PartialFull; }
            set { _PartialFull = value; }
        }

        public PaymentReceiptDetails()
        {
            InitializeComponent();
        }

     

        private void txtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            RadTextBox textBox = (RadTextBox)sender;
            // only allow one decimal point
            if (e.KeyChar == '.' && textBox.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            if (!char.IsControl(e.KeyChar) && textBox.SelectionLength == 0)
            {
                if (textBox.Text.IndexOf('.') > -1 && textBox.Text.Substring(textBox.Text.IndexOf('.')).Length >= 3)
                {
                    e.Handled = true;
                }
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtAmount.Text == string.Empty) txtAmount.Text = "0";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _ReceivedFrom = txtReceivedFrom.Text;
            _TIN = txtTIN.Text;
            _AddressAt = txtAddress.Text;
            _BusinessStyle = txtBusinessStyle.Text;
            _Amount = float.Parse(txtAmount.Text);
            _AmountInText = lblAmountInText.Text;
            _PartialFull = txtPartialFull.Text;
            btnPushed = btnOk.Text;

            frmPrintReceipt fmPrintReceipt = new frmPrintReceipt();
            fmPrintReceipt.setVars(ORno.ToString(), _ReceivedFrom, _TIN, _AddressAt, 
                _BusinessStyle, _AmountInText, _Amount.ToString(), _PartialFull);
            fmPrintReceipt.ShowDialog();

            if (fmPrintReceipt.bGenerated == true)
                this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnPushed = btnCancel.Text;
            this.Close();
        }

        private void PaymentReceiptDetails_Load(object sender, EventArgs e)
        {
            lblORNo.Text = ORno.ToString();
            lblStudentID.Text = StudentID;
            lblStudentName.Text = StudentName;
            txtAmount.Text = _Amount.ToString();
            lblAmountInText.Text = NumberToText.Convert(_Amount);
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            lblAmountInText.Text = NumberToText.Convert(float.Parse(txtAmount.Text));
        }
    }
}
