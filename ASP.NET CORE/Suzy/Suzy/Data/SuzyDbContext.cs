using System;
using System.Collections.Generic;
using System.Linq;
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

        private void Seed()
        {
            Recipient recipient = new Recipient()
            {
                Age = 20,
                Address = "Mladost4",
                FirstName = "Pesho",
                LastName = "Peshev",
                PhoneNumber = "0888888888",
                UserName = "pesho@abv.bg"
            };
            this.Recipients.Add(recipient);

            var user = Users.FirstOrDefault(x => x.UserName == "pesho@abv.bg");
            user.PhoneNumber = recipient.PhoneNumber;
        }

        public DbSet<Package> Packages { get; set; }

        public DbSet<Sender> Senders { get; set; }

        public DbSet<Recipient> Recipients { get; set; }

        public DbSet<Courier> Couriers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Package>().HasMany<User>();
            base.OnModelCreating(builder);
        }

        
    }
}
