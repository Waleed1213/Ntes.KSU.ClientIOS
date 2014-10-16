using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using SQLite;

namespace Ntes.KSU.ClientIOS.DataAccess
{
        [Table("LoginUser")]
        public class LoginUser
        {
            [PrimaryKey, AutoIncrement, Column("_id")]
            public int user_id { get; set; }
            [MaxLength(8)]
            public string first_name { get; set; }
            public string facebook_id { get; set; }

            public string dp { get; set; }
         
            public string last_name { get; set; }
            public DateTime created { get; set; }
            public string token { get; set; }

        }
    
}