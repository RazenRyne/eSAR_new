using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARBDO;
using eSARDAL;

namespace eSARLogic
{
    public class RoomLogic
    {
        RoomDAO rDAO = new RoomDAO();

        public List<RoomBDO> GetAllRooms()
        {
            return rDAO.GetAllRooms();
        }

        public Boolean CreateRoom(ref RoomBDO roomBDO, ref string message)
        {
            Boolean ret = false;
            ret = rDAO.CreateRoom(ref roomBDO, ref message);
            return ret;
        }

        public Boolean UpdateRoom(ref RoomBDO roomBDO, ref string message)
        {
            if (RoomExists(roomBDO.RoomCode))
                return rDAO.UpdateRoom(ref roomBDO, ref message);
            else
            {
                message = "Cannot get room for this Code";
                return false;
            }
        }

        private Boolean RoomExists(string roomCode) {
            Boolean ret = false;
            var roomInDB = rDAO.GetRoom(roomCode);

            if (roomInDB == null)
                ret = false;

            return ret;
        }
    }
}
