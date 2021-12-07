using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WXZ8SX_HFT_2021221.Models
{
    [Table("Genre")]
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }

        [Required]
        [MaxLength(100)]
        public string GenreName { get; set; }

        [NotMapped]
        public virtual ICollection<Album> Albums { get; set; }

        public Genre()
        {
            Albums = new HashSet<Album>();
        }
    }
}
