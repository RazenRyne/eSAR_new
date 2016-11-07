using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Globalization;
using Telerik.WinControls.UI;
using Newtonsoft.Json;
using eSAR.Utility_Classes;
using eSARServices;
using eSARServiceInterface;
using eSARServiceModels;

namespace eSAR.Settings.ManageStudentFees
{
    public partial class frmManageStudentFee : Telerik.WinControls.UI.RadForm
    {
        public string Op { get; set; }
        public List<Fee> ExistingFees { get; set; }
        public Fee SelectedFee;
        public List<GradeLevel> gradeLevels;
        public List<SchoolYear> schoolYears;

        public frmManageStudentFee()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save() {
            IFeeService feeService = new FeeService();
            Boolean ret = false;
            string message = String.Empty;
            string dis = txtDiscount.Text.ToString();
            float discount = (float.Parse(dis))/100f;
            Fee fee = new Fee()
            {
                NumPay = Int32.Parse(txtNumPay.Text),
                FeeDescription = txtDescription.Text,
                Amount = double.Parse(txtAmount.Text),
                SYImplemented = cmbSY.SelectedValue.ToString(),
                GradeLevel = cmbGradeLevel.SelectedValue.ToString(),
                DiscountFullPay = discount
            };
            if (Op.Equals("new"))
            {
                if (ExistingFees.Exists(t => t.FeeDescription == fee.FeeDescription && t.GradeLevel == fee.GradeLevel && t.SYImplemented == fee.SYImplemented))
                {
                    MessageBox.Show(this, "Fee for the Grade Level already Exists", "Fee Exists");
                }
                else
                    ret = feeService.CreateFee(ref fee, ref message);
                    Log("C", "Fees", fee);
                if (ret)
                    MessageBox.Show(this, "Saved Successfully");
                else
                    MessageBox.Show(this, "Error Saving");


                this.Close();
            }
            else if (Op.Equals("edit"))
                {
                    fee.FeeID = SelectedFee.FeeID;
                    ret = feeService.UpdateFee(ref fee, ref message);
                Log("U", "Fees", fee);
                if (ret)
                    MessageBox.Show(this, "Saved Successfully");
                else
                    MessageBox.Show(this, "Error Saving");

                this.Close();
            }
                     
        }

        private void frmManageStudentFee_Load(object sender, EventArgs e)
        {
            LoadMe();
            if (Op.Equals("edit"))
            {
                SetFields();
            }
        }

        private void SetFields() {
            txtAmount.Text = SelectedFee.Amount.ToString();
            txtDescription.Text = SelectedFee.FeeDescription.ToString();
            txtDiscount.Text = (SelectedFee.DiscountFullPay * 100).ToString();
            txtNumPay.Text = SelectedFee.NumPay.ToString();
            cmbGradeLevel.SelectedValue = SelectedFee.GradeLevel;
            cmbSY.SelectedValue = SelectedFee.SYImplemented;

        }
        private void LoadMe() {
          IFeeService feeService = new FeeService();
            ExistingFees = new List<Fee>(feeService.GetAllFees());
            gradeLevels = new List<GradeLevel>(feeService.GetAllGradeLevels());
            schoolYears = new List<SchoolYear>(feeService.GetLastFiveSY());
           
            cmbGradeLevel.DataSource = gradeLevels;
            cmbGradeLevel.ValueMember = "GradeLev";
            cmbGradeLevel.DisplayMember = "Description";
            cmbSY.DataSource = schoolYears;
            cmbSY.ValueMember = "SY";
            cmbSY.DisplayMember = "SY";

            txtAmount.Text ="0.00";
            txtDescription.Text = String.Empty;
            txtDiscount.Text = "0";
            txtNumPay.Text = "1";

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

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscount.Text == string.Empty) txtDiscount.Text = "0";
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtAmount.Text == string.Empty) txtAmount.Text = "0";
        }

        private void txtNumPay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Log(string clud, string table, Object obj)
        {
            ILogService logService = new LogService();
            string json = JsonConvert.SerializeObject(obj);
            Log log = new Log
            {
                CLUD = clud,
                LogDate = DateTime.Now,
                TableName = table,
                UserId = GlobalClass.user.UserId,
                UserName = GlobalClass.user.UserName,
                PassedData = json
            };
            logService.AddLogs(log);
        }
    }
}
