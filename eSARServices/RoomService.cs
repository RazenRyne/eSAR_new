using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARServiceModels;
using eSARServiceInterface;
using eSARBDO;
using eSARLogic;

namespace eSARServices
{
    public class RoomService : IRoomService
    {
        RoomLogic rLogic = new RoomLogic();
        public bool CreateRoom(ref Room room, ref string message)
        {
            RoomBDO roomBDO = new RoomBDO();
            TranslateRoomDTOtoRoomBDO(room, roomBDO);
            return rLogic.CreateRoom(ref roomBDO, ref message);
        }

        public List<Room> GetAllRooms()
        {
            List<Room> roomList = new List<Room>();
            foreach (RoomBDO rbdo in rLogic.GetAllRooms())
            {
                Room r = new Room();
                TranslateRoomBDOtoRoomDTO(rbdo, r);
                roomList.Add(r);
            }
            return roomList;
        }

        public Room GetRoom(int roomcode)
        {
            List<Room> roomList = new List<Room>();
            roomList = GetAllRooms();
            Room r = new Room();
            r = roomList.Find(rm => rm.RoomId == roomcode);


            return r;
        }


        public Boolean UpdateRoom(ref Room room, ref string message)
        {
            RoomBDO roomBDO = new RoomBDO();
            TranslateRoomDTOtoRoomBDO(room, roomBDO);
            return rLogic.UpdateRoom(ref roomBDO, ref message);
        }

        public void TranslateRoomDTOtoRoomBDO(Room room, RoomBDO rBDO)
        {
            rBDO.BuildingCode = room.BuildingCode;
            rBDO.Capacity = room.Capacity;
            rBDO.Deactivated = room.Deactivated;
            rBDO.Description = room.Description;
            rBDO.RoomCode = room.RoomCode;
            rBDO.RoomNumber = room.RoomNumber;
            rBDO.RoomId = room.RoomId;
        }

        public void TranslateRoomBDOtoRoomDTO(RoomBDO room, Room r)
        {
            r.RoomId = room.RoomId;
            r.BuildingCode = room.BuildingCode;
            r.Capacity = room.Capacity;
            r.Deactivated = room.Deactivated;
            r.Description = room.Description;
            r.RoomCode = room.RoomCode;
            r.RoomNumber = room.RoomNumber;
        }
    }
}
