using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WcfOrderServiceLib
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public string OrderId { get; set; }

        [DataMember]
        public List<OrderItem> Items { get; set; }

        [DataMember]
        public decimal OrderTotal { get; set; }

        [DataMember]
        public string ClientName { get; set; }

        [DataMember]
        public string StoreName { get; set; }
    }

    [DataContract]
    public class OrderItem
    {
        [DataMember]
        public string SkuId { get; set; }

        [DataMember]
        public int SkuQtd { get; set; }

        [DataMember]
        public decimal SkuSellPrice { get; set; }
    }
}
