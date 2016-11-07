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

namespace eSAR.Settings.ManageTraitsbyLevel
{
    public partial class frmTraitsList : Telerik.WinControls.UI.RadForm
    {
        private Trait traitSelected;
        private List<Trait> traitList;

        public frmTraitsList()
        {
            InitializeComponent();
        }

        public void LoadTraits()
        {
            ITraitService traitService = new TraitService();
            string message = String.Empty;
            try
            {
                var traits = traitService.GetAllTraits();
                traitList = new List<Trait>(traits);
                gvTraits.DataSource = traitList;
                gvTraits.Refresh();

                if (gvTraits.RowCount != 0)
                    gvTraits.Rows[0].IsSelected = true;
            }
            catch (Exception ex)
            {
                message = "Error Loading Traits List";
                MessageBox.Show(ex.ToString());
            }

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            frmManageTraits fmManageTraits = new frmManageTraits();
            fmManageTraits.Op = "new";
            fmManageTraits.Show(this);
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (gvTraits.CurrentRow == null)
                return;

            if (gvTraits.CurrentRow.Index >= 0)
            {
                frmManageTraits fmManageTraits = new frmManageTraits();
                fmManageTraits.Op = "edit";
                fmManageTraits.SelectedTrait = traitSelected;
                fmManageTraits.Show();
            }
        }

        private void frmTraitsList_Load(object sender, EventArgs e)
        {
            LoadTraits();
        }

        private void gvTraits_SelectionChanged(object sender, EventArgs e)
        {
            int selectedIndex = gvTraits.CurrentRow.Index;


            if (selectedIndex >= 0)
            {
                string bID = gvTraits.Rows[selectedIndex].Cells["TraitsID"].Value.ToString();
                List<Trait> trait = new List<Trait>();
                trait = traitList.FindAll(x => x.TraitsID.ToString() == bID);

                traitSelected = new Trait();
                traitSelected = (Trait)trait[0];
            }
        }

        private void frmTraitsList_Activated(object sender, EventArgs e)
        {
            LoadTraits();
        }
    }
}
