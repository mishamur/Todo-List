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
        public DbSet<Record> Records { get; set; }

        public AuthContext(DbContextOptions<AuthContext> options) :  base(options)
        {
            Database.EnsureCreated();

        }

    }
}
