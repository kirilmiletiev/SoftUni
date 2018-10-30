using Microsoft.EntityFrameworkCore;
using Torshiq.Models;

namespace Torshiq.Data
{
    public class TorshiqDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Report> Reports { get; set; }

        public DbSet<TaskSector> TaskSectors { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.;Database=Torshiq;Integrated Security=True;");

            base.OnConfiguring(optionsBuilder);
        }

       
    }
}
