using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicStore.Domain.Entities
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        //Relations
        public virtual ICollection<Album> Albuns { get; set; }
    }
}
