using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WXZ8SX_HFT_2021221.Models;

namespace WXZ8SX_HFT_2021221.Data
{
    public class MusicDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Amin\source\repos\WXZ8SX_HFT_2021221\WXZ8SX_HFT_2021221.Data\DB.mdf;Integrated Security=True");

        }
    }
}
