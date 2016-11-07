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
    public class LogDAO
    {
        public Boolean AddLog(LogBDO log)
        {
            //string message = "Log Added Successfully";
            bool ret = true;
            try
            {
                Log l = new Log();
                ConvertLogBDOToLog(log, l);
                using (var DCEnt = new DCFIEntities())
                {
                    DCEnt.Logs.Add(l);
                    DCEnt.Entry(l).State = System.Data.Entity.EntityState.Added;
                    int num = DCEnt.SaveChanges();
                     if (num < 1)
                    {
                        ret = false;
                       
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

        public List<LogBDO> GetAllLogs()
        {
            List<LogBDO> logblist = new List<LogBDO>();
            List<Log> logslist = new List<Log>();
            
            try
            {
                using (var DCEnt = new DCFIEntities())
                {
                    var allLogs = (DCEnt.Logs);
                    logslist = allLogs.ToList<Log>();



                    foreach (Log b in logslist)
                    {
                        LogBDO lBDO = new LogBDO();
                        ConvertLogToLogBDO(b, lBDO);
                        logblist.Add(lBDO);
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
             return logblist;
        }


        public List<LogBDO> GetAllLogs(DateTime fromd, DateTime to)
        {
            List<LogBDO> logblist = new List<LogBDO>();
            List<Log> logslist = new List<Log>();

            try
            {
                using (var DCEnt = new DCFIEntities())
                {
                    var allLogs = (from l in DCEnt.Logs
                                   where l.LogDate>=fromd ||  l.LogDate<=to
                                   select l);
                    logslist = allLogs.ToList<Log>();



                    foreach (Log b in logslist)
                    {
                        LogBDO lBDO = new LogBDO();
                        ConvertLogToLogBDO(b, lBDO);
                        logblist.Add(lBDO);
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
            return logblist;
        }

        public void ConvertLogToLogBDO(Log log, LogBDO logBDO)
        {
            logBDO.CLUD = log.CLUD;
            logBDO.LogDate = log.LogDate;
            logBDO.PassedData = log.PassedData;
            logBDO.TableName = log.TableName;
            logBDO.UserId = log.UserId;
            logBDO.UserName = log.UserName;
            log.LogId = logBDO.LogId;
        }

        public void ConvertLogBDOToLog(LogBDO logBDO, Log log)
        {
            log.CLUD = logBDO.CLUD;
            log.LogDate = logBDO.LogDate;
          
            log.PassedData = logBDO.PassedData;
            log.TableName = logBDO.TableName;
            log.UserId = logBDO.UserId;
            log.UserName = logBDO.UserName;

        }
    }
}
