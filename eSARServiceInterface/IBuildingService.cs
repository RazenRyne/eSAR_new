using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARServiceModels;
namespace eSARServiceInterface
{
    public interface IBuildingService
    {
         Boolean UpdateBuilding(ref Building building, ref string message);
         Boolean CreateBuilding(ref Building building, ref string message);
      
        List<Building> GetAllBuildings();
      
        List<Room> GetAllRooms(string buildingCode);
      
        Building GetBuilding(string buildingCode, ref string message);
    }
}
