using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARBDO;
using eSARLogic;
using eSARServiceInterface;
using eSARServiceModels;

namespace eSARServices
{
    public class TimeslotService : ITimeslotService
    {
        TimeslotLogic timeslotLogic = new TimeslotLogic();
        public Timeslot GetTimeslot(string timeslotCode)
        {
            TimeslotBDO tbdo = new TimeslotBDO();
            tbdo = timeslotLogic.GetTimeslot(timeslotCode);
            Timeslot t = new Timeslot();
            TranslateTimeslotBDOToTimeslotDTo(tbdo, t);

            return t;
        }

        public Boolean CreateTimeslot(ref Timeslot timeslot, ref string message)
        {
            message = String.Empty;
            TimeslotBDO tbdo = new TimeslotBDO();
            TranslateTimeslotDTOToTimeslotBDo(timeslot, tbdo);
            return timeslotLogic.CreateTimeslot(ref tbdo, ref message);
        }

        public Boolean UpdateTimeslot(ref Timeslot timeslot, ref string message)
        {
            message = String.Empty;
            TimeslotBDO tBDO = new TimeslotBDO();
            TranslateTimeslotDTOToTimeslotBDo(timeslot, tBDO);
            return timeslotLogic.UpdateTimeslot(ref tBDO, ref message);
        }

        public List<Timeslot> GetAllTimeslots()
        {
            List<TimeslotBDO> tBDOList = timeslotLogic.GetAllTimeslots();
            List<Timeslot> allTimeslot = new List<Timeslot>();
            foreach (TimeslotBDO tBDO in tBDOList)
            {
                Timeslot t = new Timeslot();
                TranslateTimeslotBDOToTimeslotDTo(tBDO, t);
                allTimeslot.Add(t);
            }
            return allTimeslot;
        }

        public Boolean DeactivateTimeslot(string timeslotCode, ref string message)
        {

            message = String.Empty;
            return timeslotLogic.DeactivateTimeslot(timeslotCode, ref message);
        }

        public Boolean ActivateTimeslot(string timeslotCode, ref string message)
        {

            message = String.Empty;
            return timeslotLogic.ActivateTimeslot(timeslotCode, ref message);
        }

        public Boolean DeleteTimeslot(string timeslotCode, ref string message)
        {

            message = String.Empty;
            return timeslotLogic.DeleteTimeslot(timeslotCode, ref message);
        }

        public void TranslateTimeslotDTOToTimeslotBDo(Timeslot timeslot, TimeslotBDO tBDO)
        {
            tBDO.TimeSlotCode = timeslot.TimeSlotCode;
            tBDO.TimeStart = timeslot.TimeStart;
            tBDO.TimeEnd = timeslot.TimeEnd;
            tBDO.Days = timeslot.Days;
            tBDO.TotalMins = timeslot.TotalMins;
        }

        public void TranslateTimeslotBDOToTimeslotDTo(TimeslotBDO tBDO, Timeslot timeslot)
        {
            timeslot.TimeSlotCode = tBDO.TimeSlotCode;
            timeslot.TimeStart = tBDO.TimeStart;
            timeslot.TimeEnd = tBDO.TimeEnd;
            timeslot.Days = tBDO.Days;
            timeslot.TotalMins = tBDO.TotalMins;
            timeslot.TimeSlotInfo = tBDO.Days + " " + tBDO.TimeStart + "-" + tBDO.TimeEnd;
        }
    }
}
