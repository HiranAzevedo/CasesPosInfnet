using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStore.Domain.Entities
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }

        public string Title { get; set; }

        public string Price { get; set; }

        public string AlbumArtURL { get; set; }

        //Relations

        public int GenreId { get; set; }

        [ForeignKey(name: nameof(GenreId))]
        public virtual Genre Genre { get; set; }

        public int ArtistId { get; set; }

        [ForeignKey(name: nameof(ArtistId))]
        public virtual Artist Artist { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }
}
