using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuntificationMetanit.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public Guid UserId { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [ScaffoldColumn(false)]
        [DataType(DataType.Password)]
        
        public string Password { get; set; }

        public List<Record> Records { get; set; }
        public User()
        {
            Records = new List<Record>();
        }

    }
}
