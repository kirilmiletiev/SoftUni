using System;
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
            //Console.WriteLine("The Database is deleted");
            //context.Database.EnsureCreated();
            //Console.WriteLine("The Database is created");

            WebHost.Start(new StartUp());
        }
    }
}
