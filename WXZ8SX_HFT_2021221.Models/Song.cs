using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WXZ8SX_HFT_2021221.Models
{
    [Table("Songs")]
    public class Song
    {
        [Key]
        public int SongId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public double Length { get; set; }

        [Required]
        [MaxLength(250)]
        public string Writer { get; set; }

        [Required]
        [MaxLength(100)]
        public string Singer { get; set; }

        [NotMapped]
        public Album Album { get; set; }
        [ForeignKey(nameof(Album))]
        public int AlbumId { get; set; }
    }
}
