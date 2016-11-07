using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARServiceModels
{
    public class Building
    {
        List<Room> roomList = new List<Room>();
        public string BuildingCode { get; set; }
        public string BuildingName { get; set; }
        public string Description { get; set; }
        public Boolean Deactivated { get; set; }
       public List<Room> Rooms
        {
            get { return this.roomList; }
            set { this.roomList = value; }
        }
    }
}
