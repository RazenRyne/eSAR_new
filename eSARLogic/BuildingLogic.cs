using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARDAL;
using eSARBDO;

namespace eSARLogic
{
    public class BuildingLogic
    {
        BuildingDAO bdao = new BuildingDAO();

        public List<BuildingBDO> GetAllBuildings()
        {
            List<BuildingBDO> buildBDO = new List<BuildingBDO>();
            foreach (BuildingBDO b in bdao.GetAllBuildings())
            {
                b.Rooms = GetAllRooms(b.BuildingCode);
                
                buildBDO.Add(b);
            }
            return buildBDO;
        }

        public BuildingBDO GetBuilding(string buildingCode)
        {
            BuildingBDO b = new BuildingBDO();
            b = bdao.GetBuildingBDO(buildingCode);
            if (b != null)
                b.Rooms = bdao.GetAllRoomsForBuilding(b.BuildingCode);
            return b;
        }

        public List<RoomBDO> GetAllRooms(string buildingCode) {
            return bdao.GetAllRoomsForBuilding(buildingCode);
        }

        public bool CreateBuilding(ref BuildingBDO building, ref string message)
        {
            return bdao.CreateBuilding(ref building, ref message);
        }

        public bool UpdateBuilding(ref BuildingBDO building, ref string message) {
            return bdao.UpdateBuilding(ref building, ref message);
        }

    }
}
