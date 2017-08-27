using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicStore.Domain.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public decimal Total { get; set; }

        //Relations

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
