using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARServiceModels;

namespace eSARServiceInterface
{
    public interface ITimeslotService
    {

         
        Timeslot GetTimeslot(string timeslotCode);
         
        Boolean CreateTimeslot(ref Timeslot timeslot, ref string message);
         
        Boolean UpdateTimeslot(ref Timeslot timeslot, ref string message);
         
        List<Timeslot> GetAllTimeslots();
         
        Boolean DeactivateTimeslot(string timeslotCode, ref string message);
         
        Boolean ActivateTimeslot(string timeslotCode, ref string message);
         
        Boolean DeleteTimeslot(string timeslotCode, ref string message);
    }

}
