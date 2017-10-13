using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infnet.MusicStore.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Cart
    {
        [JsonProperty("CartId")]
        public int CartId { get; set; }

        [JsonProperty("AlbumId")]
        public int AlbumId { get; set; }

        [JsonProperty("Count")]
        public int Count { get; set; }

        [JsonProperty("DateCreated")]
        public DateTime DateCreated { get; set; }

        [ForeignKey(nameof(AlbumId))]
        public virtual Album Albun { get; set; }
    }
}