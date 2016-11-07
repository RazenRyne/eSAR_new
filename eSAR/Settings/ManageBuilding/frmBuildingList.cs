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

namespace eSAR.Settings.ManageBuilding
{
    public partial class frmBuildingList : Telerik.WinControls.UI.RadForm
    {
        private Building buildingSelected;
        private List<Building> buildingList;
        public frmBuildingList()
        {
            InitializeComponent();
        }

        public void LoadBuildings()
        {
            IBuildingService buildingService = new BuildingService();
            string message = String.Empty;
            try
            {
                var buildings = buildingService.GetAllBuildings();
                buildingList = new List<Building>(buildings);
                gvBuilding.DataSource = buildings;
                gvBuilding.Refresh();

                if (gvBuilding.RowCount != 0)
                    gvBuilding.Rows[0].IsSelected = true;
            }
            catch (Exception ex)
            {
                message = "Error Loading Building List";
                MessageBox.Show(ex.ToString());
            }

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddBuilding_Click(object sender, EventArgs e)
        {
            frmBuildingDetails fmBuildingDetails = new frmBuildingDetails();
            fmBuildingDetails.Op = "new";
            fmBuildingDetails.ShowDialog(this);
        }

        private void frmBuildingList_Activated(object sender, EventArgs e)
        {
            LoadBuildings();
        }

        private void frmBuildingList_Load(object sender, EventArgs e)
        {
            LoadBuildings();
        }

        private void btnEditBuilding_Click(object sender, EventArgs e)
        {
            if (gvBuilding.CurrentRow.Index >= 0)
            {
                frmBuildingDetails fmBuildingDetails = new frmBuildingDetails();
                fmBuildingDetails.Op = "edit";
                fmBuildingDetails.SelectedBuilding = buildingSelected;
                fmBuildingDetails.ShowDialog();
            }
        }

        private void gvBuilding_SelectionChanged(object sender, EventArgs e)
        {
            int selectedIndex = gvBuilding.CurrentRow.Index;


            if (selectedIndex >= 0)
            {
                string bID = gvBuilding.Rows[selectedIndex].Cells["BuildingCode"].Value.ToString();
                List<Building> item = new List<Building>();
                item = buildingList.FindAll(x => x.BuildingCode.ToString() == bID);

                buildingSelected = new Building();
                buildingSelected = (Building)item[0];
            }
        }
    }
}
