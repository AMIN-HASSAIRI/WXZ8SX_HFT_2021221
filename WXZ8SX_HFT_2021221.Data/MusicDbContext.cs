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
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Song> Songs { get; set; }

        public MusicDbContext()
        {
            Database.EnsureCreated();
        }

        public MusicDbContext(DbContextOptions<MusicDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DB.mdf;Integrated Security=True");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Album>(entity => entity.HasOne(x => x.Genre)
            .WithMany(x => x.Albums)
            .HasForeignKey(x => x.GenreId)
            .OnDelete(DeleteBehavior.ClientSetNull));

            modelBuilder.Entity<Album>(entity => entity.HasOne(x => x.Artist)
            .WithMany(x => x.Albums)
            .HasForeignKey(x => x.ArtistId)
            .OnDelete(DeleteBehavior.ClientSetNull));

            modelBuilder.Entity<Song>(entity => entity.HasOne(x => x.Album)
            .WithMany(x => x.Songs)
            .HasForeignKey(x => x.AlbumId)
            .OnDelete(DeleteBehavior.ClientSetNull));


            modelBuilder.Seed();

            //modelBuilder.Entity<Artist>().HasData(
            //    new Artist 
            //    { 
            //        ArtistId = 0, ArtistName = "", DateOfBirth = DateTime.Parse("00/00/0000"), NumberOfAlbums = 0
            //    });
        }
    }
}
