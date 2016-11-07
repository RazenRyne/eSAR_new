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
    public partial class frmManageTraits : Telerik.WinControls.UI.RadForm
    {
        public string Op { get; set; }
        public Trait SelectedTrait { get; set; }
        public List<Trait> ExistingTraits { get; set; }

        public frmManageTraits()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadMe() {
            var list = new[]
         {
            new { Number = 1, Name = "Pre-school" },
            new { Number = 2, Name = "Elementary" },
            new { Number = 3, Name = "Secondary" }
            };
            cmbCategory.DataSource = list;
            cmbCategory.ValueMember = "Number";
            cmbCategory.DisplayMember = "Name";

            txtDescription.Text = String.Empty;
            chkCurrent.Checked = true;

            ITraitService traitService = new TraitService();
            ExistingTraits = new List<Trait>(traitService.GetAllTraits());

        }

        private void frmManageTraits_Load(object sender, EventArgs e)
        {
            LoadMe();
            if (Op.Equals("edit")) {
                SetFields();
            }
        }

        private void SetFields() {
            txtDescription.Text = SelectedTrait.Description;
            chkCurrent.Checked = SelectedTrait.CurrTrait;
            cmbCategory.SelectedValue = SelectedTrait.Category;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save() {
            IRegistrationService regService = new RegistrationService();
            ITraitService traitService = new TraitService();
            Boolean ret = false;
            string message = String.Empty;
            Trait trait = new Trait()
            {
                Description = txtDescription.Text.ToString(),
                CurrTrait = chkCurrent.Checked,
                Category = Int32.Parse(cmbCategory.SelectedValue.ToString())
            };
            if (ExistingTraits.Exists(t => t.Category == trait.Category && t.Description == trait.Description && t.CurrTrait==trait.CurrTrait))
            {
                MessageBox.Show(this, "Trait for that Category already Exists", "Trait Exists");
            }
            else
            {
                if (Op.Equals("edit"))
                {
                    trait.TraitsID = SelectedTrait.TraitsID;
                    ret = traitService.UpdateTrait(ref trait, ref message);
                }
                else
                {
                    ret = traitService.CreateTrait(ref trait, ref message);
                    if (ret && trait.CurrTrait)
                    {
                        List<Trait> updatedTraits = new List<Trait>(traitService.GetAllTraits());
                        Trait savedTrait = new Trait();
                        savedTrait = updatedTraits.Find(t => t.Category == trait.Category && t.Description == trait.Description && t.CurrTrait == trait.CurrTrait);
                        ret = regService.UpdateStudentCharacters(savedTrait);
                    }
                }

                if (ret)
                    MessageBox.Show(this, "Saved Successfully");
                
            }

            this.Close();
        }
       
    }
}
