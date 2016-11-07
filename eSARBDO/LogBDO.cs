using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSARBDO
{
    public class LogBDO
    {
        public int LogId { get; set; }
        public string CLUD { get; set; }
        public int UserId { get; set; }
        public string TableName { get; set; }
        public System.DateTime LogDate { get; set; }
        public string PassedData { get; set; }
        public string UserName { get; set; }
    }
}
