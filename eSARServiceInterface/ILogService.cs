using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSARServiceModels;

namespace eSARServiceInterface
{
    public interface ILogService
    {

         
        Boolean AddLogs(Log log);

         
        List<Log> GetAllLogs();

         
        List<Log> GetAllLogsByDate(DateTime from, DateTime to);

    }
}
