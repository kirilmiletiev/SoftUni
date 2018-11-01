using SIS.Framework;
using Torshiq.Data;

namespace Torshiq.App
{
    public class Launcher
    {
        public static void Main(string[] args)
        {
            //TorshiqDbContext context = new TorshiqDbContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            WebHost.Start(new StartUp());
        }
    }
}
