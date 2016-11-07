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
    public class GradeSectionDAO
    {
        public List<GradeSectionBDO> GetAllGradeSections(string currentSY)
        {
            List<GradeSection> gsList = new List<GradeSection>();
            List<GradeSectionBDO> gsBDOList = new List<GradeSectionBDO>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                var allGradeSections = (from gs in DCEnt.GradeSections
                                        where gs.SY == currentSY
                                        orderby gs.GradeLevel, gs.Class
                                        select gs);
                gsList = allGradeSections.ToList<GradeSection>();
                    
            foreach (GradeSection gs in gsList)
            {
                GradeSectionBDO gsBDO = new GradeSectionBDO();
                ConvertGradeSectionToGradeSectionBDO(gs, gsBDO);
                gsBDOList.Add(gsBDO);
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
            return gsBDOList;
        }

        public GradeSectionBDO GetGradeSectionBDO(int gradesectioncode)
        {
            GradeSection gsec = new GradeSection();
            GradeSectionBDO gsBDO = new GradeSectionBDO();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                gsec = (from gs in DCEnt.GradeSections
                                        where gs.GradeSectionCode == gradesectioncode
                                        select gs).FirstOrDefault<GradeSection>();

                 ConvertGradeSectionToGradeSectionBDO(gsec, gsBDO);
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
            return gsBDO;
        }


        public Boolean CreateGradeSection(ref GradeSectionBDO gsBDO, ref string message)
        {
            message = "Grade Section Added Successfully";
            bool ret = true;

            GradeSection gs = new GradeSection();
            try{ 
            ConvertGradeSectionBDOToGradeSection(gsBDO, gs);
            using (var DCEnt = new DCFIEntities())
            {
                DCEnt.GradeSections.Attach(gs);
                DCEnt.Entry(gs).State = System.Data.Entity.EntityState.Added;
                int num = DCEnt.SaveChanges();

                if (num != 1)
                {
                    ret = false;
                    message = "Adding of Grade Section failed";
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

        public Boolean UpdateGradeSection(ref GradeSectionBDO gsBDO, ref string message)
        {
            message = "Grade Section updated successfully.";
            Boolean ret = true;
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                var gsCode = gsBDO.GradeSectionCode;
                   GradeSection gsInDB = (from gs in DCEnt.GradeSections
                                      where gs.GradeSectionCode== gsCode
                                      select gs).FirstOrDefault();
                if (gsInDB == null)
                {
                    throw new Exception("No Grade Section with Grade Section Code " + gsBDO.GradeSectionCode);
                }
                DCEnt.GradeSections.Remove(gsInDB);

                gsInDB.Deactivated = gsBDO.Deactivated;
                gsInDB.GradeLevel = gsBDO.GradeLevel;
                gsInDB.GradeSectionCode = gsBDO.GradeSectionCode;
                gsInDB.HomeRoomNumber = gsBDO.HomeRoomNumber;
                gsInDB.HomeRoomTeacherId = gsBDO.HomeRoomTeacherId;
                gsInDB.Section = gsBDO.Section;
                gsInDB.SY = gsBDO.SY;
                gsInDB.Class = gsBDO.Class;
                DCEnt.GradeSections.Attach(gsInDB);
                DCEnt.Entry(gsInDB).State = System.Data.Entity.EntityState.Modified;
                int num = DCEnt.SaveChanges();

                if (num != 1)
                {
                    ret = false;
                    message = "No grade section is updated.";
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

        public List<GradeSectionBDO> GetAllGradeSections()
        {
            List<GradeSectionBDO> gsBDOList = new List<GradeSectionBDO>();
            List<GradeSection> gsList = new List<GradeSection>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                var allGradeSections = (from gs in DCEnt.GradeSections
                                        orderby gs.GradeLevel, gs.Class
                                        select gs);
                gsList = allGradeSections.ToList<GradeSection>();



            foreach (GradeSection gs in gsList)
            {
                GradeSectionBDO gsBDO = new GradeSectionBDO();
                ConvertGradeSectionToGradeSectionBDO(gs, gsBDO);
                gsBDOList.Add(gsBDO);
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
            return gsBDOList;
        }

        public string GetGradeLevel(int GradeSectionCode) {
            List<GradeSectionBDO> gslist = new List<GradeSectionBDO>();
            gslist=GetAllGradeSections();
            int index = 0;
            index = gslist.FindIndex(item => item.GradeSectionCode == GradeSectionCode);
            return gslist[index].GradeLevel;
        }

        public void ConvertGradeSectionToGradeSectionBDO(GradeSection gs, GradeSectionBDO gsBDO) {
            RoomDAO r = new RoomDAO();
            RoomBDO room = new RoomBDO();
            TeacherDAO t = new TeacherDAO();
            TeacherBDO teach = new TeacherBDO();
            SchoolYearDAO s = new SchoolYearDAO();
            SchoolYearBDO sy = new SchoolYearBDO();

            s.ConvertSYToSYBDO(gs.SchoolYear, sy);
            t.ConvertTeacherToTeacherBDO(gs.Teacher, teach);
            r.ConvertRoomToRoomBDO(gs.Room, room);

            gsBDO.Deactivated = gs.Deactivated;
            gsBDO.GradeLevel = gs.GradeLevel;
            gsBDO.GradeSectionCode = gs.GradeSectionCode;
            gsBDO.HomeRoomNumber = (int)gs.HomeRoomNumber;
            gsBDO.HomeRoomTeacherId = gs.HomeRoomTeacherId;
            gsBDO.Section = gs.Section;
            gsBDO.SY = gs.SY;
            gsBDO.Class = gs.Class;

            gsBDO.HomeRoom = room;
            gsBDO.HomeRoomTeacher = teach;
            gsBDO.SchoolYear = sy;
        }

        public void ConvertGradeSectionBDOToGradeSection(GradeSectionBDO gsBDO, GradeSection gs) {
       
            gs.Deactivated = gsBDO.Deactivated;
            gs.GradeLevel = gsBDO.GradeLevel;
            gs.GradeSectionCode = gsBDO.GradeSectionCode;
            gs.HomeRoomNumber = gsBDO.HomeRoomNumber;
            gs.HomeRoomTeacherId = gsBDO.HomeRoomTeacherId;
            gs.Section = gsBDO.Section;
            gs.SY = gsBDO.SY;
            gs.Class = gsBDO.Class;
         }

    }
}
