using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARServiceModels;
using eSARServiceInterface;
using eSARLogic;
using eSARBDO;

namespace eSARServices
{
    public class LogService : ILogService
    {
        LogLogic logl = new LogLogic();
        public bool AddLogs(Log log)
        {
            LogBDO logBDO = new LogBDO();
            TranslateLogToLogBDO(log, logBDO);
            return logl.AddLog(logBDO);
        }

        public List<Log> GetAllLogs()
        {
            List<Log> logList = new List<Log>();
            List<LogBDO> logBDOList = new List<LogBDO>();
            logBDOList = logl.GetAllLogs();
            foreach (LogBDO lb in logBDOList)
            {
                Log log = new Log();
                TranslateLogBDOToLog(lb, log);
                logList.Add(log);
            }
            return logList;
        }

        public List<Log> GetAllLogsByDate(DateTime from, DateTime to)
        {
            List<Log> logList = new List<Log>();
            List<LogBDO> logBDOList = new List<LogBDO>();
            logBDOList = logl.GetAllLogs(from, to);
            foreach (LogBDO lb in logBDOList)
            {
                Log log = new Log();
                TranslateLogBDOToLog(lb, log);
                logList.Add(log);
            }
            return logList;
        }

        public void TranslateLogToLogBDO(Log log, LogBDO logBDO)
        {
            logBDO.CLUD = log.CLUD;
            logBDO.LogDate = log.LogDate;
            logBDO.PassedData = log.PassedData;
            logBDO.TableName = log.TableName;
            logBDO.UserId = log.UserId;
            logBDO.UserName = log.UserName;

        }

        public void TranslateLogBDOToLog(LogBDO logBDO, Log log)
        {
            log.CLUD = logBDO.CLUD;
            log.LogDate = logBDO.LogDate;
            log.LogId = logBDO.LogId;
            log.PassedData = logBDO.PassedData;
            log.TableName = logBDO.TableName;
            log.UserId = logBDO.UserId;
            log.UserName = logBDO.UserName;

        }
    }
}
