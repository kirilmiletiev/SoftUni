using System;
using System.Collections.Generic;
using System.Text;
using BudEx.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BudEx.Data
{
    public class ApplicationDbContext : IdentityDbContext<BudExUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           
        }

        public DbSet<Courier> Couriers { get; set; }

        public DbSet<Packet> Packets { get; set; }

        public DbSet<BudExUserPacket> BudExUserPackets { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BudExUserPacket>().HasKey(k => new {k.BudExUserId, k.PacketId});
            


            //builder.Entity<BudExUser>().HasOne(g => g.Packets);

            // builder.Entity<BudExUser>().HasKey(x => new {x.Packets, x.Id});

            //builder.Entity<Packet>().HasOne(x=>x.Recipient).WithOne().HasKey(k => new {k.Recipient, k.Sender});

            //builder.Entity<Packet>().HasKey(k => new { k.Recipient, k.Sender });
            //builder.Entity<BudExUser>().HasMany<Packet>();
            //builder.Entity<Courier>().HasMany<Packet>();

            //builder.Entity<Packet>(x=>x.HasAlternateKey(y=>y.Sender));
            //builder.Entity<Packet>().HasOne(x => x.Courier);
            //builder.Entity<Courier>(x => x.HasMany<Packet>());
            //base.OnModelCreating(builder);
        }
    }
}
