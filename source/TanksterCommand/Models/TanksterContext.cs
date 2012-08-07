using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TanksterCommand.Models
{
    public class TanksterContext : DbContext
    {

        public TanksterContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Profile> Profiles { get; set; }

    }
}