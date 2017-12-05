using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WcfClient.OrderService;

namespace WcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            DoOrders();

            var taskCollection = new List<Task>();

            for (int i = default(int); i < 100; i++)
            {
                taskCollection.Add(Task.Run(() =>
                {
                    try
                    {
                        DoOrders();
                        Console.WriteLine("Round");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }));
            }

            Task.WhenAll(taskCollection);

            Console.ReadLine();
        }

        private static void DoOrders()
        {
            using (var orderClient = new OrderServiceClient())
            {
                orderClient.ClientCredentials.UserName.UserName = "admin";
                orderClient.ClientCredentials.UserName.Password = "admin";

                var order = new Order
                {
                    ClientName = "Hiran",
                    Items = new List<OrderItem>
                    {
                    new OrderItem{
                    SkuId = "1",
                    SkuQtd = 2,
                    SkuSellPrice = 10m,
                    }
                    },
                    OrderId = "1",
                    OrderTotal = 20m,
                    StoreName = "MyStore",
                };

                orderClient.PlaceOrder(order);
                Console.WriteLine("Fazendo pedido");
                orderClient.CancelOrder(order);
                Console.WriteLine("Cancelando");
            }
        }
    }
}
