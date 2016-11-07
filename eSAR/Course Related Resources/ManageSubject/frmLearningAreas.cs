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

namespace eSAR.Course_Related_Resources.ManageSubject
{
    public partial class frmLearningAreas : Telerik.WinControls.UI.RadForm
    {
        private LearningArea learningAreaSelected;
        private List<LearningArea> learningAreaList;
        public frmLearningAreas()
        {
            InitializeComponent();

        }

        public void LoadLearningAreas() {
            ILearningAreaService laService = new LearningAreaService();
            string message = String.Empty;
            try
            {
                var lAreas = laService.GetAllLearningAreas();
                learningAreaList = new List<LearningArea>(lAreas);
                gvLearningArea.DataSource = lAreas;
                gvLearningArea.Refresh();

                if (gvLearningArea.RowCount != 0)
                    gvLearningArea.Rows[0].IsSelected = true;
            }
            catch (Exception ex)
            {
                message = "Error Loading LearningArea List";
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddBuilding_Click(object sender, EventArgs e)
        {
            frmManageSubject fmManageSubject = new frmManageSubject();
            fmManageSubject.Op = "new";
            fmManageSubject.ShowDialog(this);
        }

        private void btnEditBuilding_Click(object sender, EventArgs e)
        {
            if (gvLearningArea.CurrentRow.Index >= 0)
            {
                frmManageSubject fmManageSubject = new frmManageSubject();
                fmManageSubject.Op = "edit";
                fmManageSubject.SelectedLearningArea = learningAreaSelected;
                fmManageSubject.ShowDialog();
            }
        }

        private void frmLearningAreas_Load(object sender, EventArgs e)
        {
            LoadLearningAreas();
        }

        private void frmLearningAreas_Activated(object sender, EventArgs e)
        {
            LoadLearningAreas();
        }

        private void gvLearningArea_SelectionChanged(object sender, EventArgs e)
        {
            int selectedIndex = gvLearningArea.CurrentRow.Index;


            if (selectedIndex >= 0)
            {
                string laCode = gvLearningArea.Rows[selectedIndex].Cells["LearningAreaCode"].Value.ToString();
                List<LearningArea> item = new List<LearningArea>();
                item = learningAreaList.FindAll(x => x.LearningAreaCode.ToString() == laCode);

                learningAreaSelected = new LearningArea();
                learningAreaSelected = (LearningArea)item[0];
            }
        }

        private void btnDeleteBuilding_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
