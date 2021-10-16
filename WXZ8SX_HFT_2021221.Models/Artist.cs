using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WXZ8SX_HFT_2021221.Models
{
    [Table("Artists")]
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ArtistName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public int NumberOfAlbums { get; set; }
    }
}
