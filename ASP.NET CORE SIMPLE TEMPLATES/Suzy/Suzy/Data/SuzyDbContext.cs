using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Suzy.Data.Models;

namespace Suzy.Data
{
    public class SuzyDbContext : IdentityDbContext<User>
    {
        public SuzyDbContext(DbContextOptions<SuzyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Package> Packages { get; set; }

        public DbSet<Sender> Senders { get; set; }

        public DbSet<Recipient> Recipients { get; set; }

        public DbSet<Courier> Couriers { get; set; }
    }
}
