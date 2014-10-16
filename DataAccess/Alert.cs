using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ntes.KSU.ClientIOS.DataAccess
{
    public class Alert
    {
        public int alert_id { get; set; }
        public string description { get; set; }
        public string photo { get; set; }
        public string user_id { get; set; }
        public DateTime date_time { get; set; }
        public int approved { get; set; }
    }
}
