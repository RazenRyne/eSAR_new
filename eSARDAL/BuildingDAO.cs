using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARBDO;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace eSARDAL
{
    public class BuildingDAO
    {
        public BuildingBDO GetBuildingBDO(string buildingCode)
        {
            BuildingBDO buildingBDO = null;
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                Building bldg = (from b in DCEnt.Buildings
                                 where b.BuildingCode == buildingCode
                                 select b).FirstOrDefault();
                if (bldg != null)
                {
                    buildingBDO = new BuildingBDO();
                    ConvertBuildingToBuildingBDO(bldg, buildingBDO);
                }
            }
        }catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return buildingBDO;
        }

        public List<BuildingBDO> GetAllBuildings() {
            List<BuildingBDO> bBDOList = new List<BuildingBDO>();
            List<Building> bList = new List<Building>();
            try
            {
                using (var DCEnt = new DCFIEntities())
                 {
                     var allBuildings = (DCEnt.Buildings);
                     bList = allBuildings.ToList<Building>();
           

           
                     foreach (Building b in bList) {
                       BuildingBDO bBDO = new BuildingBDO();
                       ConvertBuildingToBuildingBDO(b, bBDO);
                      bBDOList.Add(bBDO);
                     }
                  }
             }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return bBDOList;
        }


        public Boolean CreateBuilding(ref BuildingBDO buildBDO, ref string message)
        {
            message = "Building Added Successfully";
            bool ret = true;
            try { 
            Building b = new Building();
            ConvertBuildingBDOToBuilding(buildBDO,b);
            using (var DCEnt = new DCFIEntities())
            {
                DCEnt.Buildings.Add(b);
                DCEnt.Entry(b).State = System.Data.Entity.EntityState.Added;
                int num = DCEnt.SaveChanges();
                buildBDO.BuildingCode = b.BuildingCode;

                if (num < 1)
                {
                    ret = false;
                    message = "Adding of Building failed";
                }
            }
        }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
}
            }
            return ret;
        }

        public Boolean UpdateBuilding(ref BuildingBDO buildBDO, ref string message)
        {
            message = "Building updated successfully.";
            Boolean ret = true;
            List<Room> toRemove;
            List<Room> toAdd;
            List<Room> toUpdate;
            Building b = new Building();
            try { 
            ConvertBuildingBDOToBuilding(buildBDO, b);
            Building buildingInDB = new Building();
            using (var DCEnt = new DCFIEntities())
            {
                var buildingCode = buildBDO.BuildingCode;
                buildingInDB = (from bee in DCEnt.Buildings
                                where bee.BuildingCode == buildingCode
                                select bee).FirstOrDefault();
                if (buildingInDB == null)
                {
                    throw new Exception("No Building with BuildingCode " + buildBDO.BuildingCode);
                }


                // 1st Part
                if (buildingInDB.Rooms.Count == 0)
                {
                    foreach (Room rm in b.Rooms)
                    {
                        buildingInDB.Rooms.Add(rm);
                    }
                }
                else
                {
                    toRemove = new List<Room>();
                    toAdd = new List<Room>();
                    toUpdate = new List<Room>();
                    if (buildingInDB.Rooms.Count < b.Rooms.Count)
                    {
                        foreach (Room r in b.Rooms)
                        {
                            List<Room> rIn = buildingInDB.Rooms.Where(ro => ro.RoomCode == r.RoomCode).ToList<Room>();
                            if (rIn.Count == 0)
                                toAdd.Add(r);

                        }
                        foreach (Room r in buildingInDB.Rooms)
                        {
                            int co = b.Rooms.Where(ro => ro.RoomCode == r.RoomCode).Count();
                            if (co == 0)
                                toRemove.Add(r);
                        }

                    }
                    else if (buildingInDB.Rooms.Count > b.Rooms.Count)
                    {
                        foreach (Room r in b.Rooms)
                        {
                            List<Room> rIn = buildingInDB.Rooms.Where(ro => ro.RoomCode == r.RoomCode).ToList<Room>();
                            if (rIn.Count == 0)
                                toAdd.Add(r);

                        }
                        foreach (Room r in buildingInDB.Rooms)
                        {
                            int co = b.Rooms.Where(ro => ro.RoomCode == r.RoomCode).Count();
                            if (co == 0)
                                toRemove.Add(r);
                        }

                    }
                    else if (buildingInDB.Rooms.Count == b.Rooms.Count)
                    {
                        foreach (Room r in b.Rooms)
                        {
                            List<Room> rIn = buildingInDB.Rooms.Where(ro => ro.RoomCode == r.RoomCode).ToList<Room>();
                            if (rIn.Count == 0)
                                toAdd.Add(r);

                        }
                        foreach (Room r in buildingInDB.Rooms)
                        {
                            int co = b.Rooms.Where(ro => ro.RoomCode == r.RoomCode).Count();
                            if (co == 0)
                                toRemove.Add(r);
                        }

                    }

                    foreach (Room r in b.Rooms)
                    {
                        List<Room> rIn = buildingInDB.Rooms.Where(ro => ro.RoomCode == r.RoomCode).ToList<Room>();

                        if (rIn.Exists(p => p.RoomCode == r.RoomCode))
                        {
                            if (!CompareRoom(rIn[0], r))
                            {
                                toUpdate.Add(r);
                            }
                        }
                    }

                    foreach (Room r in toAdd)
                    {
                        buildingInDB.Rooms.Add(r);

                    }

                    foreach (Room r in toRemove)
                    {
                        DCEnt.Rooms.Remove(r);
                        DCEnt.Entry(r).State = System.Data.Entity.EntityState.Deleted;
                    }

                    foreach (Room r in toUpdate)
                    {
                        var roomIn = (from rm in DCEnt.Rooms
                                      where rm.RoomId == r.RoomId
                                      select rm).FirstOrDefault<Room>();

                        DCEnt.Rooms.Remove(roomIn);
                     
                        roomIn.BuildingCode = r.BuildingCode;
                        roomIn.Capacity = r.Capacity;
                        roomIn.Deactivated = r.Deactivated;
                        roomIn.Description = r.Description;
                        roomIn.RoomCode = r.RoomCode;
                        roomIn.RoomNumber = r.RoomNumber;
                        roomIn.RoomId = r.RoomId;

                        DCEnt.Rooms.Attach(roomIn);
                        DCEnt.Entry(roomIn).State = System.Data.Entity.EntityState.Modified;
                    }
                                       
                }
                    if (CompareBuilding(buildingInDB, b))
                    {
                        DCEnt.SaveChanges();                                                                                                                                          //    DCEnt.Entry(r).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {

                        buildingInDB.BuildingCode = b.BuildingCode;
                        buildingInDB.BuildingName = b.BuildingName;
                        buildingInDB.Description = b.Description;

                        DCEnt.Entry(buildingInDB).State = System.Data.Entity.EntityState.Modified;
                        DCEnt.SaveChanges();
                    }

                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return ret;
        }


        private Boolean CompareBuilding(Building inDB, Building inNew){
            if (inDB.BuildingCode == inNew.BuildingCode && inDB.BuildingName == inNew.BuildingName && inDB.Description == inNew.Description)
                return true;
            else return false;
        }

        private Boolean CompareRoom(Room inDB, Room inNew)
        {
            if (inDB.BuildingCode == inNew.BuildingCode && inDB.Description == inNew.Description && inDB.Capacity == inNew.Capacity && inDB.RoomCode==inNew.RoomCode && inDB.RoomId==inNew.RoomId)
                return true;
            else return false;
        }


        public List<RoomBDO> GetAllRoomsForBuilding(string buildingCode) {
            List<Room> rooms = null;
            List<RoomBDO> rbdoList = new List<RoomBDO>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                rooms = (from r in DCEnt.Rooms
                        where r.BuildingCode== buildingCode
                        select r).ToList<Room>();

           
            foreach (Room r in rooms) {
                RoomBDO roomBDO = new RoomBDO();
                ConvertRoomToRoomBDO(r, roomBDO);
                rbdoList.Add(roomBDO);
            }
            }
        }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
}
            }
            return rbdoList;
        }

        private void ConvertRoomToRoomBDO(Room r, RoomBDO roomBDO)
        {
            roomBDO.BuildingCode = r.BuildingCode;
            roomBDO.Capacity = (int)r.Capacity;
            roomBDO.Deactivated = r.Deactivated;
            roomBDO.Description = r.Description;
            roomBDO.RoomCode = r.RoomCode;
            roomBDO.RoomNumber = r.RoomNumber;
            roomBDO.RoomId = r.RoomId;
        }
        

        private void ConvertBuildingToBuildingBDO(Building b, BuildingBDO bdo) {
            
            bdo.BuildingCode = b.BuildingCode;
            bdo.BuildingName = b.BuildingName;
            bdo.Deactivated = b.Deactivated;
            bdo.Description = b.Description;
           // bdo.Rooms = ToRoomBDOList(b.Rooms);
        }

        private List<RoomBDO> ToRoomBDOList(ICollection<Room> rooms) {
            List<RoomBDO> rBDOList = new List<RoomBDO>();
            foreach (Room r in rooms) {
                RoomBDO rbdo = new RoomBDO();
                rbdo.BuildingCode = r.BuildingCode;
                rbdo.Capacity = (int)r.Capacity;
                rbdo.Deactivated = r.Deactivated;
                rbdo.Description = r.Description;
                rbdo.RoomCode = r.RoomCode;
                rbdo.RoomNumber = r.RoomNumber;
                rbdo.RoomId = r.RoomId;
                rBDOList.Add(rbdo);
            }
            return rBDOList;
        }

        private void ConvertBuildingBDOToBuilding(BuildingBDO bdo, Building b)
        {
            b.BuildingCode = bdo.BuildingCode;
            b.BuildingName = bdo.BuildingName;
            b.Deactivated = bdo.Deactivated;
            b.Description = bdo.Description;
            b.Rooms =ToRoomList(bdo.Rooms);
        }

        private List<Room> ToRoomList(List<RoomBDO> rooms)
        {
            List<Room> rList = new List<Room>();
            foreach (RoomBDO rbdo in rooms)
            {
                Room r = new Room();
                r.BuildingCode = rbdo.BuildingCode;
                r.Capacity = (int)rbdo.Capacity;
                r.Deactivated = rbdo.Deactivated;
                r.Description = rbdo.Description;
                r.RoomCode = rbdo.RoomCode;
                r.RoomNumber = rbdo.RoomNumber;
                r.RoomId = rbdo.RoomId;
                rList.Add(r);
            }
            return rList;
        }
    }
}
