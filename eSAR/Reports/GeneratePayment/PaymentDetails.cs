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

namespace eSAR.Reports.GeneratePayment
{
    public partial class PaymentDetails : Telerik.WinControls.UI.RadForm
    {

        
        public PaymentDetails()
        {
            InitializeComponent();
        }

      
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            GlobalClass.WindowPaymentDetails = false;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            PaymentReport pm = new PaymentReport();
            if (txtIDNumber.Text != string.Empty)
            {
                if (txtIDNumber.Text != "All")
                {
                if (chkStudentID())
                {
                    pm.setVars(txtIDNumber.Text);
                    pm.ShowDialog();
                }
                else
                    MessageBox.Show("ID Number does not exist", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                {
                    pm.setVars(txtIDNumber.Text);
                    pm.ShowDialog();
                }
              
            
            }
        }

   
        private bool chkStudentID()
        {
            Student student = new Student();
            string msg = string.Empty;
            IStudentService studentService = new StudentService();
            
            student = studentService.GetStudent(txtIDNumber.Text, ref msg);
            if (student.StudentId != null)
            {               
                return true;
            }
            else
                return false;
        }

        private void PaymentDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
