//using Abp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticket_Booking_system.Model;

namespace Ticket_Booking_system.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            //builder.Entity<Department>().property<bool>("isDeleted");
          //  ModelBuilder.Filter("IsDeleted", (ISoftDelete d) => d.IsDeleted, false);

            
        }

        public DbSet<Department> departments { get; set; }

        public DbSet<Role> roles { get; set; }
        public DbSet<Tickets> tickets { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Booking> bookings { get; set; }


    }
}
