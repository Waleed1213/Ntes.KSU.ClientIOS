using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ntes.KSU.ClientIOS.DataAccess
{
    public class AlertJson
    {
        public string alert_id { get; set; }
        public string description { get; set; }
        public string photo { get; set; }
        public string user_id { get; set; }
        public string date_time { get; set; }
        public string approved { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string dp { get; set; }
        public string facebook_id { get; set; }
        public string user_fb_token { get; set; }
        public string created { get; set; }
        public string f_user_id { get; set; }
        public string f_alert_id { get; set; }
        public string fav { get; set; }
    }
}