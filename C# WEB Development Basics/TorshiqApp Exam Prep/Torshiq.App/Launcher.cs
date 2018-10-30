using SIS.Framework;

namespace Torshiq.App
{
    public class Launcher
    {
        public static void Main(string[] args)
        {
            WebHost.Start(new StartUp());
        }
    }
}
