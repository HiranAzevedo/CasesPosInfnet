using System.Collections.Concurrent;

namespace WcfOrderServiceLib
{
    public static class OrderStorage
    {
        public static ConcurrentDictionary<string, Order> OrdersPlaced { get; set; }

        public static bool AddOrder(Order order)
        {
            return OrdersPlaced.TryAdd(order.OrderId, order);
        }

        public static bool CancelOrder(Order order)
        {
            return OrdersPlaced.TryRemove(order.OrderId, out order);
        }

        static OrderStorage()
        {
            OrdersPlaced = new ConcurrentDictionary<string, Order>();
        }
    }
}
