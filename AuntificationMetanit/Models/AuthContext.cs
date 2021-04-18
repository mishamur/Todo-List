using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AuntificationMetanit.Models
{
    public class AuthContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        //Запись(Памятка)
        public DbSet<Record> Records { get; set; }
        //Встреча
        public DbSet<Meeting> Meetings { get; set; }
        //Дело
        public DbSet<Case> Cases { get; set; }
        public AuthContext(DbContextOptions<AuthContext> options) :  base(options)
        {
           Database.EnsureCreated();

        }

    }
}
