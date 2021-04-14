using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuntificationMetanit.Models
{
    public class Record
    {
        [Key]
        public Guid RecordId { get; set; }

        [ForeignKey("UserInfo")]
        public Guid UserId { get; set; } 

       public string Theme { get; set; }
       public DateTime DateBegin { get; set; }


    }
}
