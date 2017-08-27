using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicStore.Domain.Entities
{
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }

        public string Name { get; set; }

        //Relations

        public virtual ICollection<Album> Albuns { get; set; }
    }
}
