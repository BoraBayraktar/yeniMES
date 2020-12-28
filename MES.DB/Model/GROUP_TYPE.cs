using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MES.DB.Model
{
    public partial class GROUP_TYPE : BASE
    {
        [Key]
        public int ID { get; set; }    

        [StringLength(50)]
        public string TYPE_NAME { get; set; }
    }
}
