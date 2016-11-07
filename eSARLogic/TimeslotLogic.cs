using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARBDO;
using eSARDAL;

namespace eSARLogic
{
    public class TimeslotLogic
    {
        TimeslotDAO tDAO = new TimeslotDAO();

        public TimeslotBDO GetTimeslot(string timeslotCode)
        {
            return tDAO.GetTimeslotBDO(timeslotCode);
        }

        public List<TimeslotBDO> GetAllTimeslots()
        {
            return tDAO.GetAllTimeslot();
        }

        public Boolean CreateTimeslot(ref TimeslotBDO timeslotBDO, ref string message)
        {
            Boolean ret = false;
            TimeslotBDO tBDO = GetTimeslot(timeslotBDO.TimeSlotCode);
            if (tBDO == null)
                ret = tDAO.CreateTimeslot(ref timeslotBDO, ref message);
            else
                message = "Code already exists. Please select another Code";

            return ret;
        }

        public Boolean TimeslotExists(string timeslotCode)
        {
            Boolean ret = true;
            var tInDB = GetTimeslot(timeslotCode);

            if (tInDB == null)
                ret = false;

            return ret;
        }

        public Boolean UpdateTimeslot(ref TimeslotBDO timeslotBDO, ref string message)
        {
            if (TimeslotExists(timeslotBDO.TimeSlotCode))
                return tDAO.UpdateTimeslot(ref timeslotBDO, ref message);
            else
            {
                message = "Cannot get the Timeslot for this Code";
                return false;
            }
        }

        public Boolean DeactivateTimeslot(string timeslotCode, ref string message)
        {
            if (TimeslotExists(timeslotCode))
                return tDAO.DeactivateTimeslot(timeslotCode, ref message);
            else
            {
                message = "Cannot get the Timeslot for this Code";
                return false;
            }
        }

        public Boolean ActivateTimeslot(string timeslotCode, ref string message)
        {
            if (TimeslotExists(timeslotCode))
                return tDAO.ActivateTimeslot(timeslotCode, ref message);
            else
            {
                message = "Cannot get the Timeslot for this Code";
                return false;
            }
        }

        public Boolean DeleteTimeslot(string timeslotCode, ref string message)
        {
            if (TimeslotExists(timeslotCode))
                return tDAO.DeleteTimeslot(timeslotCode, ref message);
            else
            {
                message = "Cannot get the Timeslot for this Code";
                return false;
            }
        }
    }
}
