using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Newtonsoft.Json;
using eSAR.Utility_Classes;
using eSARServices;
using eSARServiceInterface;
using eSARServiceModels;

namespace eSAR.Settings.ManageSY
{
    public partial class frmSYList : Telerik.WinControls.UI.RadForm
    {
        private SchoolYear SYSelected;
        private SchoolYear SYcurrent = new SchoolYear();
        private List<SchoolYear> SYList;
        public frmSYList()
        {
            InitializeComponent();
        }

        public void LoadSY()
        {
            gvSY.DataSource = null;
            ISchoolYearService syService = new SchoolYearService();
            string message = String.Empty;
            try
            {
                var sy = syService.GetAllSY();
                SYList = new List<SchoolYear>(sy);
                gvSY.DataSource = SYList;
                gvSY.Refresh();

                if (gvSY.RowCount != 0)
                    gvSY.Rows[0].IsSelected = true;


                SYcurrent = SYList.Find(x => x.CurrentSY == true);
            }
            catch (Exception ex)
            {
                message = "Error Loading List of School Years";
                MessageBox.Show(ex.ToString());
            }

        }

        private void frmSYList_Load(object sender, EventArgs e)
        {
            LoadSY();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SYSelected != null)
            {
                ISchoolYearService syService = new SchoolYearService();
                string message = String.Empty;

                if (!syService.DeleteSY(SYSelected.SY, ref message))
                {
                    message = "Deletion of School Year Failed";
                }
                else
                {
                   
                    Log("D", "SchoolYear", SYSelected);
                    MessageBox.Show("Deleted succesfully!");
                }
            }
        }

        private void gvSY_SelectionChanged(object sender, EventArgs e)
        {
            if (gvSY.RowCount != 0 && gvSY.CurrentRow != null)
            {
                int selectedIndex = gvSY.CurrentRow.Index;


                if (selectedIndex >= 0)
                {
                    string tCode = gvSY.Rows[selectedIndex].Cells["SY"].Value.ToString();
                    List<SchoolYear> item = new List<SchoolYear>();
                    item = SYList.FindAll(x => x.SY.ToString() == tCode);

                    SYSelected = new SchoolYear();
                    SYSelected = (SchoolYear)item[0];

                }
            }
        }

        private void txtSY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSY.Text))
            {                
                return;
            }
            else
            {
               
                    if (SYList.Exists(x => x.SY.Substring(0, 4) == txtSY.Text))
                    {
                        MessageBox.Show("SY already exists");
                        txtSY.Text = "";
                        txtSY.Focus();
                    }
                    else
                        SaveSY();
                
            }
        }

        private void SaveSY()
        {
            try
            {
                Boolean ret = false;
                string message = String.Empty;

                int SYto = 0;
                SYto = int.Parse(txtSY.Text) + 1;
                                
                ISchoolYearService syService = new SchoolYearService();
                SchoolYear schoolyear = new SchoolYear()
                {
                    SY = txtSY.Text + "-" + SYto.ToString(),
                    CurrentSY = false
                };

              
                ret = syService.CreateSY(ref schoolyear, ref message);
                Log("C", "SchoolYear", schoolyear);
                MessageBox.Show("Saved Successfully!");
                LoadSY();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        private void gvSY_CellValueChanged(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                UpdateCurrentSY(e.Row.Cells[0].Value.ToString(), true);
                if (SYcurrent != null)
                {
                    UpdateCurrentSY(SYcurrent.SY, false);
                    GlobalClass.currentsy = SYcurrent.SY;
                    SYcurrent.CurrentSY = false;
                    Log("U", "SchoolYear", SYcurrent);
                }
                gvSY.DataSource = null;
                LoadSY();
            }
        }

        private void UpdateCurrentSY(string szSY, bool bSY)
        {
            try
            {
                Boolean ret = false;
                string message = String.Empty;

                ISchoolYearService syService = new SchoolYearService();
                SchoolYear schoolyear = new SchoolYear()
                {
                    SY = szSY,
                    CurrentSY = bSY
                };


                ret = syService.UpdateSY(ref schoolyear, ref message);
                schoolyear.CurrentSY = true;
                Log("U", "SchoolYear", schoolyear);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }   


        private void gvSY_ValueChanging(object sender, ValueChangingEventArgs e)
        {            
            if (gvSY.CurrentRow  != null)
                {
                if (e.NewValue != e.OldValue)
                {
                    UpdateCurrentSY(gvSY.Rows[gvSY.CurrentRow.Index].Cells[0].Value.ToString(), true);
                    if (SYcurrent != null)
                    {
                        UpdateCurrentSY(SYcurrent.SY, false);
                        SYcurrent.CurrentSY = false;
                        Log("U", "SchoolYear", SYcurrent);
                    }
                     gvSY.DataSource = null;
                    LoadSY();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
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
