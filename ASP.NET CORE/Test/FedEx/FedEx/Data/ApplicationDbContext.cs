using System;
using System.Collections.Generic;
using System.Text;
using FedEx.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FedEx.Data
{
    public class ApplicationDbContext : IdentityDbContext<FedExUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Courier> Couriers { get; set; }

        public DbSet<Packet> Packets { get; set; }

       // public DbSet<Recipient> Recipients  { get; set; }

       // public DbSet<Sender> Senders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FedExUser>().HasMany<Packet>();
            base.OnModelCreating(builder);
        }
    }
}
