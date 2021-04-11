using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuntificationMetanit.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public Guid UserId { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [ScaffoldColumn(false)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public List<Record> records { get; set; }

        
    }
}
