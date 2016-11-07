using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARDAL;
using eSARBDO;
namespace eSARLogic
{
   public  class LogLogic
    {
        LogDAO logd = new LogDAO();
        public Boolean AddLog(LogBDO log) {
            return logd.AddLog(log);
        }
        public List<LogBDO> GetAllLogs()
        {
            List<LogBDO> logslist = new List<LogBDO>();
            return logd.GetAllLogs();
        }
        public List<LogBDO> GetAllLogs(DateTime from, DateTime to)
        {
            List<LogBDO> logslist = new List<LogBDO>();
            return logd.GetAllLogs(from, to);
        }
    }
}
