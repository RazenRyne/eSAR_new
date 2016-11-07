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

namespace eSAR.Course_Related_Resources.ManageGradeLevelSection
{
    public partial class frmGradeSectionList : Telerik.WinControls.UI.RadForm
    {
        List<GradeSection> gradeSectionList;
        GradeSection gSectionSelected;
        public frmGradeSectionList()
        {
            InitializeComponent();
        }

        public void LoadGradeSections()
        {
            IGradeSectionService gService = new GradeSectionService();
            gradeSectionList = new List<GradeSection>(gService.GetAllGradeSections());
            gvGradeSection.DataSource = gradeSectionList;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ManageGradeLevelSection fmManageGradeSection = new ManageGradeLevelSection();
            fmManageGradeSection.Op = "new";
            fmManageGradeSection.ShowDialog(this);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gvGradeSection.CurrentRow == null)
                return;

            if (gvGradeSection.CurrentRow.Index >= 0)
            {
                ManageGradeLevelSection fmManageGradeSection = new ManageGradeLevelSection();
                fmManageGradeSection.Op = "edit";
                fmManageGradeSection.SelectedGradeSection = gSectionSelected;
                fmManageGradeSection.ShowDialog(this);
            }
        }

        private void gvGradeSection_SelectionChanged(object sender, EventArgs e)
        {
            int selectedIndex = gvGradeSection.CurrentRow.Index;


            if (selectedIndex >= 0)
            {
                string gsCode = gvGradeSection.Rows[selectedIndex].Cells["GradeSectionCode"].Value.ToString();
                List<GradeSection> item = new List<GradeSection>();
                item = gradeSectionList.FindAll(x => x.GradeSectionCode.ToString() == gsCode);
                

                gSectionSelected = new GradeSection();
                gSectionSelected = (GradeSection)item[0];
            }
        }
        private void frmGradeSectionList_Load(object sender, EventArgs e) {
            LoadGradeSections();
        }
    }

   
}
