using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARServiceModels
{
    public class Room
    {
        public string RoomCode { get; set; }
        
        public string RoomNumber { get; set; }
        
        public string BuildingCode { get; set; }
        
        public int Capacity { get; set; }
        
        public string Description { get; set; }
        
        public Boolean Deactivated { get; set; }
        
        public int RoomId { get; set; }
    }
}
