using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infnet.MusicStore.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Album
    {
        [Key]
        [JsonProperty("AlbumId")]
        public int AlbumId { get; set; }

        [JsonProperty("GenreId")]
        public int GenreId { get; set; }

        [JsonProperty("ArtistId")]
        public int ArtistId { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Price")]
        public decimal Price { get; set; }

        [JsonProperty("AlbumArtUrl")]
        public string AlbumArtUrl { get; set; }

        [ForeignKey(nameof(ArtistId))]
        public virtual Artist Artist { get; set; }

        [ForeignKey(nameof(GenreId))]
        public virtual Genre Genre { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}