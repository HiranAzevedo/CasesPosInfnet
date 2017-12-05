using System;

namespace WcfOrderServiceLib
{
    public class OrderValueDontMatchException : Exception
    {
        public string OrderId { get; set; }

        public string Store { get; set; }

        public OrderValueDontMatchException(string storeName, string orderId, string message) : base(message)
        {
            OrderId = orderId;
            Store = storeName;
        }
    }
}
