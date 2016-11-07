using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Newtonsoft.Json;
using eSAR.Utility_Classes;
using eSARServices;
using eSARServiceInterface;
using eSARServiceModels;

namespace eSAR.Settings.ManageBuilding
{
    public partial class frmBuildingDetails : Telerik.WinControls.UI.RadForm
    {
        public string Op { get; set; }
        public Building SelectedBuilding { get; set; }

        List<Room> rooms;
        List<Room> rooms1 = new List<Room>();

        public frmBuildingDetails()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            IBuildingService buildingService = new BuildingService();
            Boolean ret = false;
            string message = String.Empty;
            Building building = new Building()
            {
                BuildingCode = txtBuildingCode.Text.ToString(),
                Description = txtDescription.Text.ToString(),
                BuildingName = txtName.Text.ToString(),
                Rooms = rooms

            };
            if (Op.Equals("edit"))
            {
                ret = buildingService.UpdateBuilding(ref building, ref message);
              
                building.Rooms = null;
                Log("U", "Buildings", building);
                if (rooms.Count > 0)
                {
                    foreach (Room r in rooms)
                        Log("C", "Rooms", r);
                }
                
                if (ret)
                    MessageBox.Show("Saved Successfully");
                else
                    MessageBox.Show("Error Saving");
                Close();

            }
            else
            {
                String la = txtBuildingCode.Text.ToString();
                if (la.Equals(String.Empty))
                {
                    MessageBox.Show("Provide Building Code");
                }
                else
                {
                    ret = buildingService.CreateBuilding(ref building, ref message);
                    building.Rooms = null;
                    Log("C", "Buildings", building);
                    if (rooms.Count > 0)
                    {
                        foreach (Room r in rooms)
                            Log("C", "Rooms", r);
                    }
                    if (ret)
                        MessageBox.Show("Saved Successfully");
                    else
                        MessageBox.Show("Error Saving");
                    Close();
                }
            }

            
        }

        private void frmBuildingDetails_Load(object sender, EventArgs e)
        {
            if (Op.Equals("edit"))
            {
                SetFields();
                SetRoomGrid();
            }

            if (Op.Equals("new"))
            {
                IBuildingService buildingService = new BuildingService();
                BindRoomGrid();
            }
        }

        private void SetFields()
        {
            txtBuildingCode.Enabled = false;
            txtBuildingCode.Text = SelectedBuilding.BuildingCode;
            txtDescription.Text = SelectedBuilding.Description;
            txtName.Text = SelectedBuilding.BuildingName;
        }
        private void BindRoomGrid()
        {
            rooms = new List<Room>();
            gvRooms.DataSource = rooms;
        }

        private void SetRoomGrid()
        {
            rooms = new List<Room>(SelectedBuilding.Rooms);
            this.gvRooms.DataSource = rooms;
        }

        private void gvRooms_UserAddedRow(object sender, Telerik.WinControls.UI.GridViewRowEventArgs e)
        {

            int index = this.gvRooms.RowCount - 1;
            rooms[index].BuildingCode = this.txtBuildingCode.Text;
            rooms[index].RoomCode = this.txtBuildingCode.Text + this.rooms[index].RoomNumber.ToString();
            rooms[index].Deactivated = false;
            gvRooms.DataSource = rooms1;
            gvRooms.DataSource = rooms;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvRooms_UserAddingRow(object sender, Telerik.WinControls.UI.GridViewRowCancelEventArgs e)
        {
            var newRN = new object();
            newRN = e.Rows[0].Cells["RoomNumber"].Value;

            if (newRN != null)
            {
                if (rooms.Exists(x => x.RoomNumber == newRN.ToString()))
                {
                    MessageBox.Show("Room already existed");
                    e.Cancel = true;
                }
            }
            else
            {
                MessageBox.Show("Room Number should not be empty");
                e.Cancel = true;
            }
        }

        private void gvRooms_CellValidating(object sender, Telerik.WinControls.UI.CellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 3) // 1 should be your column index
            {
                int i;

                if (!int.TryParse(Convert.ToString(e.Value), out i))
                {
                    MessageBox.Show("Please enter numeric value");
                    e.Cancel = true;
                }
            }
        }

        private void gvRooms_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.CellElement.ColumnInfo.HeaderText == "Room Number")
                {
                    if (!string.IsNullOrEmpty(rooms[e.RowIndex].RoomCode))
                        e.CellElement.Enabled = false;
                }
            }
        }

        private void txtBuildingCode_Leave(object sender, EventArgs e)
        {
            Building bldg = new Building();
            string msg = string.Empty;
            IBuildingService bldgService = new BuildingService();

           
            bldg = bldgService.GetBuilding(txtBuildingCode.Text, ref msg);
            if (bldg.BuildingCode != null)
            {
                MessageBox.Show("Building Code already exist!");
                txtBuildingCode.Text = string.Empty;
                txtBuildingCode.Focus();
                return;
            }
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
