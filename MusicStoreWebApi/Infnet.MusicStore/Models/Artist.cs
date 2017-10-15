using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Infnet.MusicStore.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Artist
    {
        [Key]
        [JsonProperty(nameof(ArtistId))]
        public int ArtistId { get; set; }

        [JsonProperty(nameof(Name))]
        public string Name { get; set; }

        [JsonProperty(nameof(Albuns))]
        public virtual ICollection<Album> Albuns { get; set; }
    }
}