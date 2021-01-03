using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MES.Web.Model
{
    public abstract class BASE
    {
        public DateTime CREATED_DATE { get; set; } = DateTime.Now;
        public DateTime? UPDATED_DATE { get; set; }

        //public int? CREATED_USER_ID { get; set; }
        //public int? UPDATED_USER_ID { get; set; }

        //[ForeignKey("CREATED_USER_ID")]
        //public USER CREATED_USER { get; set; }

        //[ForeignKey("UPDATED_USER_ID")]
        //public USER UPDATED_USER { get; set; }

        public bool IS_DELETED { get; set; }
    }
}
