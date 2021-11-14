using ConsoleTools;
using System;
using WXZ8SX_HFT_2021221.Models;

namespace WXZ8SX_HFT_2021221.Client
{
    class Program
    {
        static RestService rest = new RestService("http://localhost:49755");

        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);

            //RestService rest = new RestService("http://localhost:49755");

            var menu = new ConsoleMenu(args, level: 0)
               .Add(">> GET ALBUMS", () => GetAlbums())
               .Add("Close", ConsoleMenu.Close)
               .Add("Exit", () => Environment.Exit(0))
               .Configure(config =>
               {
                   config.Selector = "--> ";
                   config.EnableFilter = true;
                   config.Title = "Main menu";
                   config.EnableWriteTitle = true;
                   config.EnableBreadcrumb = true;
               });


            menu.Show();

        }
        private static void GetAlbums()
        {
            var allAlbums = rest.Get<Album>("album");
            foreach (var item in allAlbums)
            {
                Console.WriteLine(item.AlbumName);
            }
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }
    }
}
