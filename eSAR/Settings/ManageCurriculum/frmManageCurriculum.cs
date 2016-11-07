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

namespace eSAR.Settings.ManageCurriculum
{
    public partial class frmManageCurriculum : Telerik.WinControls.UI.RadForm
    {
        private List<Curriculum> currList = new List<Curriculum>();
        Curriculum currSelected;

        public frmManageCurriculum()
        {
            InitializeComponent();
        }

        public void LoadCurriculums()
        {
            ICurriculumService currService = new CurriculumService();
            string message = String.Empty;
            try
            {
                var currs = currService.GetAllCurriculums();
                currList = new List<Curriculum>(currs);
                gvCurriculum.DataSource = currs;
                gvCurriculum.Refresh();

                if (gvCurriculum.RowCount != 0)
                    gvCurriculum.Rows[0].IsSelected = true;
            }
            catch (Exception ex)
            {
                message = "Error Loading Curriculum List";
                MessageBox.Show(ex.ToString());
            }

        }

        private void frmManageCurriculum_Load(object sender, EventArgs e)
        {
            LoadCurriculums();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCurriculumDetails fmCurriculumDetails = new frmCurriculumDetails();
            fmCurriculumDetails.Op = "new";
            fmCurriculumDetails.ShowDialog(this);
        }

        private void frmManageCurriculum_Activated(object sender, EventArgs e)
        {
            LoadCurriculums();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gvCurriculum.CurrentRow.Index >= 0)
            {
                frmCurriculumDetails fmCurriculumDetails = new frmCurriculumDetails();
                fmCurriculumDetails.Op = "edit";
                fmCurriculumDetails.SelectedCurriculum = currSelected;
                fmCurriculumDetails.ShowDialog();
            }
        }

        private void gvCurriculum_SelectionChanged(object sender, EventArgs e)
        {
            int selectedIndex = gvCurriculum.CurrentRow.Index;


            if (selectedIndex >= 0)
            {
                string cID = gvCurriculum.Rows[selectedIndex].Cells["CurriculumCode"].Value.ToString();
                List<Curriculum> item = new List<Curriculum>();
                item = currList.FindAll(x => x.CurriculumCode.ToString() == cID);

                currSelected = new Curriculum();
                currSelected = (Curriculum)item[0];
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
