using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Infnet.MusicStore.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Order
    {
        [JsonProperty("OrderId")]
        public int OrderId { get; set; }

        [JsonProperty("OrderDate")]
        public DateTime OrderDate { get; set; }

        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("Address")]
        public string Address { get; set; }

        [JsonProperty("City")]
        public string City { get; set; }

        [JsonProperty("State")]
        public string State { get; set; }

        [JsonProperty("PostalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("Country")]
        public string Country { get; set; }

        [JsonProperty("Phone")]
        public string Phone { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Total")]
        public decimal Total { get; set; }

        [JsonProperty(nameof(OrderDetail))]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}