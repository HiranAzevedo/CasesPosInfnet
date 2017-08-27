using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStore.Domain.Entities
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }

        public int AlbumId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        //Relations

        [ForeignKey(name: nameof(OrderId))]
        public virtual Order Order { get; set; }

        [ForeignKey(name: nameof(AlbumId))]
        public virtual Album Album { get; set; }
    }
}
