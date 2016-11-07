using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARServiceModels;

namespace eSARServiceInterface
{
    public interface IRoomService
    {
         
        Boolean UpdateRoom(ref Room room, ref string message);
         
        Boolean CreateRoom(ref Room room, ref string message);
         
        List<Room> GetAllRooms();

    }
}
