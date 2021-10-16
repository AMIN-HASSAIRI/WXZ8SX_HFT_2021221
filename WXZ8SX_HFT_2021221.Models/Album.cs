using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WXZ8SX_HFT_2021221.Models
{
    [Table("Albums")]
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }

        [Required]
        [MaxLength(100)]
        public string AlbumName { get; set; }

        [Required]
        public DateTime ReleasedDate { get; set; }

        [Required]
        public int NumberOfSongs { get; set; }

        public double Rating { get; set; }

        public double Length { get; set; }

        [NotMapped]
        public Artists Artist { get; set; }

        [ForeignKey(nameof(Artist))]
        public int ArtistId { get; set; }

        [NotMapped]
        public Genres Genre { get; set; }

        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }
    }
}
