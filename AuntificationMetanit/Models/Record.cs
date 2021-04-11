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
        public int RecordId { get; set; }

        [ForeignKey("UserInfo")]
        public Guid UserId { get; set; } 

        string Theme { get; set; }
        DateTime DateBegin { get; set; }




    }
}
