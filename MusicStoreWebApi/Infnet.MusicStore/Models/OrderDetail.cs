using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infnet.MusicStore.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class OrderDetail
    {
        [Key]
        [JsonProperty("OrderDetailId")]
        public int OrderDetailId { get; set; }

        [JsonProperty("OrderId")]
        public int OrderId { get; set; }

        [JsonProperty("AlbumId")]
        public int AlbumId { get; set; }

        [JsonProperty("Quantity")]
        public int Quantity { get; set; }

        [JsonProperty("UnitPrice")]
        public decimal UnitPrice { get; set; }

        [ForeignKey(nameof(AlbumId))]
        public virtual Album Album { get; set; }

        [ForeignKey(nameof(OrderId))]
        public virtual Order Order { get; set; }
    }
}