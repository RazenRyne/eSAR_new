using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARBDO
{
    public class BuildingBDO
    {
        List<RoomBDO> roomList = new List<RoomBDO>();
        public string BuildingCode { get; set; }
        public string BuildingName { get; set; }
        public string Description { get; set; }
        public Boolean Deactivated { get; set; }

        public List<RoomBDO> Rooms
        {
            get { return this.roomList; }
            set { this.roomList = value; }
        }
    }

}
