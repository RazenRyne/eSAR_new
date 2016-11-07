using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using eSARServices;
using eSARServiceInterface;
using eSARServiceModels;

namespace eSAR.Settings.ManageScholarship
{
    public partial class frmScholarshipDiscount : Telerik.WinControls.UI.RadForm
    {
        public string Op { get; set; }
        public string feeCode { get; set; }
        public string scholarshipCode { get; set; }
        public List<ScholarshipDiscount> sd { get; set; }

        public frmScholarshipDiscount()
        {
            InitializeComponent();
        }

        private void frmScholarshipDiscount_Load(object sender, EventArgs e)
        {
            if (Op.Equals("newScholarshipDiscount"))
            {
                txtCode.Text = scholarshipCode.ToString();
                txtCode.Enabled = false;

                IScholarshipService fSC = new ScholarshipService();
                cmbFee.ValueMember = "FeeID";
                cmbFee.DisplayMember = "FeeDescription";
            }
        }

        private void btnSaveScholarshipDiscount_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {

            frmScholarshipDetails fmScholarshipDetails = new frmScholarshipDetails();

            double dis = double.Parse(txtDiscount.Text);
            String txtC = txtCode.Text.ToString();




            Close();
        }


        private void btnCancelScholarshipDiscount_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
