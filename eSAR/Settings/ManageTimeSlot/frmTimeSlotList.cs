using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using eSAR.Settings.ManageTimeSlot;
using Newtonsoft.Json;
using eSAR.Utility_Classes;
using eSARServices;
using eSARServiceInterface;
using eSARServiceModels;

namespace eSAR.Settings.ManageTimeSlot
{
    public partial class frmTimeSlotList : Telerik.WinControls.UI.RadForm
    {
        private Timeslot timeslotSelected;
        private List<Timeslot> timeslotList;
        public frmTimeSlotList()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmTimeSlotDetails fmTimeslotDetails = new frmTimeSlotDetails();
            fmTimeslotDetails.timeslotList = timeslotList;
            fmTimeslotDetails.Op = "new";
            fmTimeslotDetails.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gvTimeSlot.CurrentRow == null)
                return;

            frmTimeSlotDetails fmTimeslotDetails = new frmTimeSlotDetails();
            fmTimeslotDetails.timeslotList = timeslotList;
            fmTimeslotDetails.SelectedTimeslot = timeslotSelected;
            fmTimeslotDetails.Op = "edit";
            fmTimeslotDetails.ShowDialog();
        }

        public void LoadTimeslots()
        {
            ITimeslotService tService = new TimeslotService();
            string message = String.Empty;
            try
            {
                var timeslot = tService.GetAllTimeslots();
                timeslotList = new List<Timeslot>(timeslot);
                gvTimeSlot.DataSource = timeslotList;
                gvTimeSlot.Refresh();

                if (gvTimeSlot.RowCount != 0)
                    gvTimeSlot.Rows[0].IsSelected = true;
            }
            catch (Exception ex)
            {
                message = "Error Loading List of Timeslots";
                MessageBox.Show(ex.ToString());
            }

        }

        private void gvTimeSlot_SelectionChanged(object sender, EventArgs e)
        {
            int selectedIndex = gvTimeSlot.CurrentRow.Index;


            if (selectedIndex >= 0)
            {
                string tCode = gvTimeSlot.Rows[selectedIndex].Cells["TimeslotCode"].Value.ToString();
                List<Timeslot> item = new List<Timeslot>();
                item = timeslotList.FindAll(x => x.TimeSlotCode.ToString() == tCode);

                timeslotSelected = new Timeslot();
                timeslotSelected = (Timeslot)item[0];

            }
        }

        private void frmTimeSlotList_Load(object sender, EventArgs e)
        {
            LoadTimeslots();
        }

        private void frmTimeSlotList_Activated(object sender, EventArgs e)
        {
            LoadTimeslots();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (timeslotSelected != null)
            {
                ITimeslotService tService = new TimeslotService();
                string message = String.Empty;

                if (!tService.DeleteTimeslot(timeslotSelected.TimeSlotCode, ref message))
                {
                   
                    MessageBox.Show("Deletion of Timeslot Failed");
                }
                else
                {
                    Log("D", "Timeslots", timeslotSelected);
                    MessageBox.Show("Deleted succesfully!");
                }
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
