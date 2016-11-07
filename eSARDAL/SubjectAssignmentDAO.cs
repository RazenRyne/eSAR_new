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
    public class SubjectAssignmentDAO
    {
        public string currentSY { get; set; }
        public List<SubjectAssignmentBDO> GetAllSchedules(string schoolYear)
        {
            List<SubjectAssignment> saList = new List<SubjectAssignment>();
            List<SubjectAssignmentBDO> sabdoList = new List<SubjectAssignmentBDO>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                var allSchedule = (from sched in DCEnt.SubjectAssignments
                                   where sched.SY == schoolYear && sched.Deactivated == false
                                   select sched).ToList<SubjectAssignment>();
                saList = allSchedule;



                foreach (SubjectAssignment sa in saList)
                {
                    SubjectAssignmentBDO saBDO = new SubjectAssignmentBDO();
                    ConvertSubjectAssignmentToSubjectAssignmentBDO(sa, saBDO);
                    sabdoList.Add(saBDO);
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
            return sabdoList;
        }

        public List<SubjectAssignmentBDO> GetAllSchedules()
        {
            SchoolYearDAO syd = new SchoolYearDAO();
            currentSY = syd.CurrentSY();
            List<SubjectAssignment> saList = new List<SubjectAssignment>();
            List<SubjectAssignmentBDO> sabdoList = new List<SubjectAssignmentBDO>();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                var allSchedule = (from sched in DCEnt.SubjectAssignments
                                   where sched.Deactivated == false && sched.SY.Equals(currentSY)
                                   select sched).ToList<SubjectAssignment>();
                saList = allSchedule;



                foreach (SubjectAssignment sa in saList)
                {
                    SubjectAssignmentBDO saBDO = new SubjectAssignmentBDO();
                    ConvertSubjectAssignmentToSubjectAssignmentBDO(sa, saBDO);
                    sabdoList.Add(saBDO);
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
            return sabdoList;
        }

        public List<SubjectAssignmentBDO> GetAllSchedulesbySection(int iGradeSection)
        {
            SchoolYearDAO syd = new SchoolYearDAO();
            currentSY = syd.CurrentSY();
            List<SubjectAssignment> saList = new List<SubjectAssignment>();
            List<SubjectAssignmentBDO> sabdoList = new List<SubjectAssignmentBDO>();
            try{ 
            using (var DCEnt = new DCFIEntities())
            {
                var allSchedule = (from sched in DCEnt.SubjectAssignments
                                   where sched.Deactivated == false && sched.SY.Equals(currentSY) && sched.GradeSectionCode == iGradeSection
                                   select sched).ToList<SubjectAssignment>();
                saList = allSchedule;



                foreach (SubjectAssignment sa in saList)
                {
                    SubjectAssignmentBDO saBDO = new SubjectAssignmentBDO();
                    ConvertSubjectAssignmentToSubjectAssignmentBDO(sa, saBDO);
                    sabdoList.Add(saBDO);
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
            return sabdoList;
        }


        public SubjectAssignmentBDO GetScheduleInfo(int sAi)
        {
            SchoolYearDAO syd = new SchoolYearDAO();
            currentSY = syd.CurrentSY();
            SubjectAssignment schedInfo = new SubjectAssignment();
            SubjectAssignmentBDO saBDO = new SubjectAssignmentBDO();
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                schedInfo = (from sched in DCEnt.SubjectAssignments
                             where sched.Deactivated == false && sched.SY.Equals(currentSY) && sched.SubjectAssignmentsID == sAi
                             select sched).FirstOrDefault<SubjectAssignment>();
                    
                ConvertSubjectAssignmentToSubjectAssignmentBDO(schedInfo, saBDO);
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
            return saBDO;
        }
        public void ConvertSubjectAssignmentToSubjectAssignmentBDO(SubjectAssignment sa, SubjectAssignmentBDO sabdo)
        {
            sabdo.Deactivated = (bool)sa.Deactivated;
            GradeSectionDAO gd = new GradeSectionDAO();
            GradeSectionBDO g = new GradeSectionBDO();
            g = gd.GetGradeSectionBDO((int)sa.GradeSectionCode);
            sabdo.GradeSection = g;
            sabdo.GradeSectionCode = g.GradeSectionCode;
            RoomBDO r = new RoomBDO();
            RoomDAO rd = new RoomDAO();
            rd.ConvertRoomToRoomBDO(sa.Room, r);
            sabdo.Room = r;
            sabdo.RoomId = r.RoomId;
            SubjectDAO sd = new SubjectDAO();
            SubjectBDO sb = new SubjectBDO();
            sd.ConvertSubjectToSubjectBDO(sa.Subject, sb);
            sabdo.Subject = sb;
            sabdo.SubjectAssignmentsID = sa.SubjectAssignmentsID;
            sabdo.SubjectCode = sa.SubjectCode;
            sabdo.SY = sa.SY;
            TeacherDAO td = new TeacherDAO();
            TeacherBDO tb = new TeacherBDO();
            td.ConvertTeacherToTeacherBDO(sa.Teacher, tb);
            sabdo.Teacher = tb;
            sabdo.TeacherId = tb.TeacherId;
            TimeslotDAO tid = new TimeslotDAO();
            TimeslotBDO tib = new TimeslotBDO();
            tid.ConvertTimeslotToTimeslotBDO(sa.Timeslot, tib);
            sabdo.Timeslot = tib;
            sabdo.TimeSlotCode = tib.TimeSlotCode;

            sabdo.GradeLevel = g.GradeLevel;
        }

        public Boolean CreateSchedule(ref SubjectAssignmentBDO sched, ref string message)
        {
            message = "Schedule Added Successfully";
            bool ret = true;

            SubjectAssignment sa = new SubjectAssignment();
            try { 
            ConvertSubjectAssignmentBDOToSubjectAssignment(sched, sa);
            using (var DCEnt = new DCFIEntities())
            {
                DCEnt.SubjectAssignments.Add(sa);
                DCEnt.Entry(sa).State = System.Data.Entity.EntityState.Added;
                int num = DCEnt.SaveChanges();
                sched.SubjectAssignmentsID = sa.SubjectAssignmentsID;

                if (num == 0)
                {
                    ret = false;
                    message = "Adding of Schedule failed";
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

        public void ConvertSubjectAssignmentBDOToSubjectAssignment(SubjectAssignmentBDO sa, SubjectAssignment sabdo)
        {

            sabdo.Deactivated = (bool)sa.Deactivated;
            sabdo.GradeSectionCode = sa.GradeSectionCode;
            sabdo.RoomId = sa.RoomId;
            sabdo.SubjectAssignmentsID = sa.SubjectAssignmentsID;
            sabdo.SubjectCode = sa.SubjectCode;
            sabdo.SY = sa.SY;
            sabdo.TeacherId = sa.TeacherId;
            sabdo.TimeSlotCode = sa.TimeSlotCode;

        }

        public Boolean UpdateSchedule(ref SubjectAssignmentBDO schedBDO, ref string message)
        {
            message = "Schedule updated successfully.";
            Boolean ret = true;
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                var schedID = schedBDO.SubjectAssignmentsID;
                SubjectAssignment schedInDB = (from s in DCEnt.SubjectAssignments
                                               where s.SubjectAssignmentsID == schedID
                                               select s).FirstOrDefault();
                if (schedInDB == null)
                {
                    throw new Exception("No schedule with ID " + schedBDO.SubjectAssignmentsID);
                }
                DCEnt.SubjectAssignments.Remove(schedInDB);
                ConvertSubjectAssignmentBDOToSubjectAssignment(schedBDO, schedInDB);

                DCEnt.SubjectAssignments.Attach(schedInDB);
                DCEnt.Entry(schedInDB).State = System.Data.Entity.EntityState.Modified;
                int num = DCEnt.SaveChanges();

                if (num == 0)
                {
                    ret = false;
                    message = "No schedules is updated.";
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

        public Boolean DeleteSchedule(int schedID, ref string message)
        {
            message = "Schedule Deleted successfully.";
            Boolean ret = true;
            try { 
            using (var DCEnt = new DCFIEntities())
            {
                SubjectAssignment schedInDB = (from s in DCEnt.SubjectAssignments
                                               where s.SubjectAssignmentsID == schedID
                                               select s).FirstOrDefault();

                if (schedInDB == null)
                {
                    throw new Exception("No sched with ID " + schedID);
                }

                DCEnt.SubjectAssignments.Remove(schedInDB);
                DCEnt.Entry(schedInDB).State = System.Data.Entity.EntityState.Deleted;
                int num = DCEnt.SaveChanges();
                if (num != 1)
                {
                    ret = false;
                    message = "Deletion of User Failed.";
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

        public List<SubjectAssignmentBDO> GetTeacherLoad(string TeacherId, string schoolYear)
        {
            List<SubjectAssignment> saList = new List<SubjectAssignment>();
            List<SubjectAssignmentBDO> sabdoList = new List<SubjectAssignmentBDO>();
            try{ 
            using (var DCEnt = new DCFIEntities())
            {
                var allSchedule = (from sched in DCEnt.SubjectAssignments
                                   where sched.SY == schoolYear && sched.TeacherId.Equals(TeacherId)
                                   select sched).ToList<SubjectAssignment>();
                saList = allSchedule;



                foreach (SubjectAssignment sa in saList)
                {
                    SubjectAssignmentBDO saBDO = new SubjectAssignmentBDO();
                    ConvertSubjectAssignmentToSubjectAssignmentBDO(sa, saBDO);
                    sabdoList.Add(saBDO);
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
            return sabdoList;
        }

        public List<SubjectAssignmentBDO> GetScheduleOfSection(int GradeSectionCode)
        {
            List<SubjectAssignment> saList = new List<SubjectAssignment>();
            List<SubjectAssignmentBDO> sabdoList = new List<SubjectAssignmentBDO>();
            try {
              using (var DCEnt = new DCFIEntities())
            {
                var allSchedule = (from sched in DCEnt.SubjectAssignments
                                   where sched.GradeSectionCode == GradeSectionCode
                                   select sched).ToList<SubjectAssignment>();
                saList = allSchedule;


                foreach (SubjectAssignment sa in saList)
                {
                    SubjectAssignmentBDO saBDO = new SubjectAssignmentBDO();
                    ConvertSubjectAssignmentToSubjectAssignmentBDO(sa, saBDO);
                    sabdoList.Add(saBDO);
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
            return sabdoList;
        }
    }
}
