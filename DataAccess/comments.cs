using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using SQLite;

namespace Ntes.KSU.ClientIOS.DataAccess
{
    [Table("comments")]
    public class Comments
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int comments_id { get; set; }
        [MaxLength(8)]
        public string description { get; set; }
        public string user_id { get; set; }

        public int alert_id { get; set; }
        public DateTime date_time { get; set; }

    }

}