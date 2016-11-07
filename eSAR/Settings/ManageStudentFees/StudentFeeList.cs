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

namespace eSAR.Settings.ManageStudentFees
{
    public partial class StudentFeeList : Telerik.WinControls.UI.RadForm
    {
        private Fee feeSelected;
        private List<Fee> feeList;
        public StudentFeeList()
        {
            InitializeComponent();
        }
        public void LoadStudentFees()
        {
            IFeeService feeService = new FeeService();
            string message = String.Empty;
            try
            {
                var fees = feeService.GetAllFees();
                feeList = new List<Fee>(fees);
                gvFees.DataSource = feeList;
                gvFees.Refresh();

                if (gvFees.RowCount != 0)
                    gvFees.Rows[0].IsSelected = true;
            }
            catch (Exception ex)
            {
                message = "Error Loading Fees List";
                MessageBox.Show(ex.ToString());
            }

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmManageStudentFee fmManageStudentFee = new frmManageStudentFee();
            fmManageStudentFee.Op = "new";
            fmManageStudentFee.ShowDialog(this);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gvFees.CurrentRow.Index >= 0)
            {
                frmManageStudentFee fmManageStudentFee = new frmManageStudentFee();
                fmManageStudentFee.Op = "edit";
                fmManageStudentFee.SelectedFee = feeSelected;
                fmManageStudentFee.ShowDialog();
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvFees_SelectionChanged(object sender, EventArgs e)
        {
            int selectedIndex = gvFees.CurrentRow.Index;


            if (selectedIndex >= 0)
            {
                string bID = gvFees.Rows[selectedIndex].Cells["FeeID"].Value.ToString();
                List<Fee> fee = new List<Fee>();
                fee = feeList.FindAll(x => x.FeeID.ToString() == bID);

                feeSelected = new Fee();
                feeSelected = (Fee)fee[0];
            }

        }

        private void StudentFeeList_Load(object sender, EventArgs e)
        {
            LoadStudentFees();
        }
    }
}
