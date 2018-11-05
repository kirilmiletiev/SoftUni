using Microsoft.EntityFrameworkCore;
using PANDA.App.Models;

namespace PANDA.App.Data
{
    public class PandaContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public DbSet<Package> Packages { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        public DbSet<PackageReceipt> PackageReceipts { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Panda;Integrated Security=True;");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
