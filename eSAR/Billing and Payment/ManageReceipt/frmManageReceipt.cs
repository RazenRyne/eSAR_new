using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using eSAR.Utility_Classes;
using eSAR.App;

namespace eSAR.Billing_and_Payment.ManageReceipt
{
    public partial class frmManageReceipt : Telerik.WinControls.UI.RadForm
    {

        public frmManageReceipt()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            GlobalClass.receiptCurrent = txtReceiptFrom.Text.ToString();
            GlobalClass.receiptFrom = txtReceiptFrom.Text.ToString();
            GlobalClass.receiptTo = txtReceiptTo.Text.ToString();
            if (GlobalClass.receiptFrom == "" || GlobalClass.receiptTo == "")
            {
                MessageBox.Show("Please don't leave any field blank");
            } else if (Int32.Parse(GlobalClass.receiptFrom) >= Int32.Parse(GlobalClass.receiptTo))
            {
                MessageBox.Show("Receipt Number From should be less than or not equal Receipt Number To");
            }
            else { 
                MessageBox.Show("Saved Successfully");
                GlobalClass.WindowStatusManageReceipt = false;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            GlobalClass.WindowStatusManageReceipt = false;
            Close();
        }
    }
}
