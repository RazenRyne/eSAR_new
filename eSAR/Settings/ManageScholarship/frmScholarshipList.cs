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
    public partial class frmScholarshipList : Telerik.WinControls.UI.RadForm
    {
        private ScholarshipDiscount scholarshipSelected;
        private List<ScholarshipDiscount> scholarshipList;
        public frmScholarshipList()
        {
            InitializeComponent();
        }

        public void LoadScholarships()
        {
            IScholarshipService scholarshipService = new ScholarshipService();
            string message = String.Empty;
            try
            {
                var scholarships = scholarshipService.GetAllScholarships();
                scholarshipList = new List<ScholarshipDiscount>(scholarships);
                gvScholarship.DataSource = scholarships;
                gvScholarship.Refresh();

                if (gvScholarship.RowCount != 0)
                    gvScholarship.Rows[0].IsSelected = true;
            }
            catch (Exception ex)
            {
                message = "Error Loading Scholarship List";
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddScholarship_Click(object sender, EventArgs e)
        {
            frmScholarshipDetails fmScholarshipDetails = new frmScholarshipDetails();
            fmScholarshipDetails.Op = "new";
            fmScholarshipDetails.Show(this);
        }

        private void frmScholarshipList_Activated(object sender, EventArgs e)
        {
            LoadScholarships();
        }

        private void frmScholarshipList_Load(object sender, EventArgs e)
        {
            LoadScholarships();
        }

        private void btnEditScholarship_Click(object sender, EventArgs e)
        {
            if (gvScholarship.CurrentRow.Index >= 0)
            {
                frmScholarshipDetails fmScholarshipDetails = new frmScholarshipDetails();
                fmScholarshipDetails.Op = "edit";
                fmScholarshipDetails.SelectedScholarship = scholarshipSelected;
                fmScholarshipDetails.Show();
            }
        }

        private void gvScholarship_SelectionChanged(object sender, EventArgs e)
        {
            int selectedIndex = gvScholarship.CurrentRow.Index;

            if (selectedIndex >= 0)
            {
                string sID = gvScholarship.Rows[selectedIndex].Cells["ScholarshipCode"].Value.ToString();
                List<ScholarshipDiscount> item = new List<ScholarshipDiscount>();
                item = scholarshipList.FindAll(x => x.ScholarshipDiscountId.ToString() == sID);

                scholarshipSelected = new ScholarshipDiscount();
                scholarshipSelected = (ScholarshipDiscount)item[0];
            }
        }
    }
}
