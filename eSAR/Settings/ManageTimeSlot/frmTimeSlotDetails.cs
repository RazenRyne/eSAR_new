
using eSARServices;
using eSARServiceInterface;
using eSARServiceModels;
using eSAR.Utility_Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace eSAR.Settings.ManageTimeSlot
{
    public partial class frmTimeSlotDetails : Telerik.WinControls.UI.RadForm
    {
        public string Op { get; set; }
        public Timeslot SelectedTimeslot { get; set; }
        public List<Timeslot> timeslotList { get; set; }


        public frmTimeSlotDetails()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmTimeSlotDetails_Load(object sender, EventArgs e)
        {
            string[] stringArray = new string[7];

            if (Op.Equals("edit"))
            {
                txtTimeslotCode.Enabled = false;
                txtTimeslotCode.Text = SelectedTimeslot.TimeSlotCode;
                tPStart.Value = DateTime.ParseExact(SelectedTimeslot.TimeStart, "hh:mm tt", System.Globalization.CultureInfo.CurrentCulture);
                tpEnd.Value = DateTime.ParseExact(SelectedTimeslot.TimeEnd, "hh:mm tt", System.Globalization.CultureInfo.CurrentCulture);

                stringArray = SelectedTimeslot.Days.Split(',');

                chkSunday.Checked = SelectedTimeslot.Days.Contains("Sun");
                chkMonday.Checked = SelectedTimeslot.Days.Contains("Mon");
                chkTuesday.Checked = SelectedTimeslot.Days.Contains("Tue");
                chkWednesday.Checked = SelectedTimeslot.Days.Contains("Wed");
                chkThursday.Checked = SelectedTimeslot.Days.Contains("Thu");
                chkFriday.Checked = SelectedTimeslot.Days.Contains("Fri");
                chkSaturday.Checked = SelectedTimeslot.Days.Contains("Sat");


            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(txtTimeslotCode.Text))
            {
                MessageBox.Show("Please fill up Timeslot Code");
                return;
            }
            else
            {
                if (tPStart.Value < tpEnd.Value)
                    SaveUser();
                else
                {
                    MessageBox.Show("Time End should be greater than Time Start");
                    tPStart.Focus();
                }
            }
        }

        private void SaveUser()
        {
            try
            {
                Boolean ret = false;
                string message = String.Empty;

                List<String> list = new List<String>();
                if (chkSunday.Checked == true) list.Add("Sun");
                if (chkMonday.Checked == true) list.Add("Mon");
                if (chkTuesday.Checked == true) list.Add("Tue");
                if (chkWednesday.Checked == true) list.Add("Wed");
                if (chkThursday.Checked == true) list.Add("Thu");
                if (chkFriday.Checked == true) list.Add("Fri");
                if (chkSaturday.Checked == true) list.Add("Sat");

                string szDays = string.Empty;
                szDays = string.Join(",", list.ToArray());

                DateTime? dtTimeStart = DateTime.Now;
                DateTime? dtTimeEnd = DateTime.Now;

                dtTimeStart = tPStart.Value;
                dtTimeEnd = tpEnd.Value;

                ITimeslotService tService = new TimeslotService();
                Timeslot timeslot = new Timeslot()
                {
                    TimeSlotCode = txtTimeslotCode.Text,
                    TimeStart = dtTimeStart.Value.ToString("hh:mm tt"),
                    TimeEnd = dtTimeEnd.Value.ToString("hh:mm tt"),
                    Days = szDays
                };

                if (Op.Equals("edit"))
                {
                    timeslot.TimeSlotCode = SelectedTimeslot.TimeSlotCode;
                    ret = tService.UpdateTimeslot(ref timeslot, ref message);
                    Log("U", "Timeslots", timeslot);
                }
                else
                {
                    ret = tService.CreateTimeslot(ref timeslot, ref message);
                    Log("C", "Timeslots", timeslot);
                }

                MessageBox.Show("Saved Successfully!");

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        private void txtTimeslotCode_Leave(object sender, EventArgs e)
        {
            if (!Op.Equals("edit"))
            {
                if (timeslotList.Exists(x => x.TimeSlotCode == txtTimeslotCode.Text))
                {
                    MessageBox.Show("Code already exists");
                    txtTimeslotCode.Text = "";
                    txtTimeslotCode.Focus();
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

