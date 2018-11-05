using System;
using PANDA.App.Data;
using SIS.Framework;

namespace PANDA.App
{
    public class Launcher
    {
        static void Main(string[] args)
        {
            //PandaContext context = new PandaContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();
            //Console.WriteLine("Database is restarted...");

            WebHost.Start(new StartUp());
        }
    }
}
