using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepsWebApp.Db.Model;
using Microsoft.EntityFrameworkCore;

namespace DepsWebApp.Db
{
    public class UserContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }
    }
}
