using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using eSARServices;
using eSARServiceInterface;
using eSARServiceModels;


namespace eSAR.Settings.ManageScholarship
{
    public partial class frmScholarshipDetails : Telerik.WinControls.UI.RadForm
    {
        public string Op { get; set; }
        public ScholarshipDiscount SelectedScholarship { get; set; }

        GridViewComboBoxColumn colFee;

        //public List<Fee> fee;

        //Fee feeSelected = new Fee();

        List<ScholarshipDiscount> sdList = new List<ScholarshipDiscount>();
    //    List<Fee> feeList = new List<Fee>(); 

        ScholarshipDiscount sDiscountSelected = new ScholarshipDiscount();

        List<ScholarshipDiscount> scholarshipDiscountList;
        List<ScholarshipDiscount> oldScholarshipDiscountList;

        public int feeid;

        string oldS = string.Empty;


        public frmScholarshipDetails()
        {
            InitializeComponent();
        }

        private void gvScholarships_CellEditorInitialized(object sender, GridViewCellEventArgs e)
        {
            if (e.Row is GridViewNewRowInfo)
            {
                var editor = e.ActiveEditor as RadDropDownListEditor;
                if (editor != null)
                {
                    editor.ValueChanged -= new EventHandler(editor_ValueChanged);
                    editor.ValueChanged += new EventHandler(editor_ValueChanged);
                }
            }
        }

        void editor_ValueChanged(object sender, EventArgs e)
        {
            var editor = gvScholarshipDetails.ActiveEditor as RadDropDownListEditor;
            if(editor != null)
            {
                var editorElement = editor.EditorElement as RadDropDownListEditorElement;
                if (editorElement.SelectedIndex == -1)
                {
                    MessageBox.Show(this, "Please select a Fee.");
                    gvScholarshipDetails.CancelEdit();
                }
                else
                {
                    feeid = (int)editor.Value;
           //         feeSelected = fee[editorElement.SelectedIndex];
                    gvScholarshipDetails.EndEdit();
                }
            }
        }
        
        private void btnSaveScholarship_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            IScholarshipService sService = new ScholarshipService();
            Boolean ret = false;
            string message = String.Empty;
            ScholarshipDiscount scholarship = new ScholarshipDiscount();
            if (Op.Equals("edit"))
                ret = sService.UpdateScholarship(ref scholarship, ref message);
            else
                ret = sService.CreateScholarship(ref scholarship, ref message);

            if (ret)
                MessageBox.Show("Saved Successfully");
            else
                MessageBox.Show("Error Saving");

            if (Op.Equals("edit"))
                Close();
            if (Op.Equals("new"))
            {
                Op = "edit";
                txtScholarshipCode.Enabled = false;
                gvScholarshipDetails.Enabled = true;
            }
            this.Close();
        }

        private void fmScholarship_Load(object sender, EventArgs e)
        {
            IScholarshipService sService = new ScholarshipService();

            colFee = new GridViewComboBoxColumn("Fee");
            colFee.HeaderText = "Fee";
            colFee.FieldName = "FeeID";
            colFee.ValueMember = "FeeID";
            colFee.DisplayMember = "FeeDescription";
            colFee.Width = 180;


            gvScholarshipDetails.Columns.Add(colFee);

            if (Op.Equals("edit"))
            {
                SetField();
                SetScholarshipDiscountGrid();
            }

            if (Op.Equals("new"))
            {
                BindScholarshipDiscountGrid();
                gvScholarshipDetails.Enabled = false;
            }

        }

        private void SetField()
        {
            txtScholarshipCode.Enabled = false;
            gvScholarshipDetails.Enabled = true;
        }

        private void BindScholarshipDiscountGrid()
        {
            scholarshipDiscountList = new List<ScholarshipDiscount>();
            gvScholarshipDetails.DataSource = scholarshipDiscountList;
        }

        private void SetScholarshipDiscountGrid()
        {
            scholarshipDiscountList = new List<ScholarshipDiscount>();
            this.gvScholarshipDetails.DataSource = scholarshipDiscountList;
        }

        private void gvScholarshipDiscounts_UserAddedRow(object sender, Telerik.WinControls.UI.GridViewRowEventArgs e)
        {
            int index = this.gvScholarshipDetails.RowCount - 1;

            gvScholarshipDetails.DataSource = scholarshipDiscountList;
        }


        private void btnBackScholarship_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvScholarshipDiscount_UserAddingRow(object sender, GridViewRowCancelEventArgs e)
        {
            var newFee = new object();
            newFee = e.Rows[0].Cells["FeeID"].Value;

            if (newFee == null)
            {
                MessageBox.Show("Scholarship Discount should not be empty");
                e.Cancel = true;
            }
        }

        private void gvScholarshipDiscounts_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 2)
                {
                    oldS = gvScholarshipDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
            }
        }

        public void gvScholarshipDiscounts_ValueChanging(object sender, ValueChangingEventArgs e)
        {
            if (gvScholarshipDetails.CurrentRow.Index >= 0)
            {
                sDiscountSelected = new ScholarshipDiscount()
                {
                    ScholarshipDiscountId = scholarshipDiscountList[gvScholarshipDetails.CurrentRow.Index].ScholarshipDiscountId,
                    Discount = scholarshipDiscountList[gvScholarshipDetails.CurrentRow.Index].Discount,
                    Deactivated = false,
                };

                oldScholarshipDiscountList.Add(sDiscountSelected);

            }
        }

        private void txtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            RadTextBox textBox = (RadTextBox)sender;
            if (e.KeyChar   == '.' && textBox.Text.IndexOf('.') > -1)
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


        
        
    }
}
