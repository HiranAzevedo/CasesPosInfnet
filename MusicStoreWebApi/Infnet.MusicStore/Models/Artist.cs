using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Infnet.MusicStore.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Artist
    {
        [Key]
        [JsonProperty("ArtistId")]
        public int ArtistId { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        public virtual ICollection<Album> Albuns { get; set; }
    }
}