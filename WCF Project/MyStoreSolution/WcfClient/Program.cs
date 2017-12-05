using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WcfClient.OrderService;

namespace WcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            DoOrders(0);

            try
            {
                DoOrdersBroken(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

            var taskCollection = new List<Task>();

            var taskNumber = default(int);

            for (int i = default(int); i < 100; i++)
            {
                taskCollection.Add(Task.Run(() =>
                {
                    try
                    {
                        DoOrders(taskNumber);

                        Console.WriteLine($"Thread {taskNumber}");

                        taskNumber++;
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

        private static void DoOrdersBroken(int taskNumber)
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
                    SkuSellPrice = 50m,
                    }
                    },
                    OrderId = "1",
                    OrderTotal = 20m,
                    StoreName = "MyStore",
                };

                orderClient.PlaceOrder(order);
                Console.WriteLine($"Fazendo pedido {taskNumber}");
                orderClient.CancelOrder(order);
                Console.WriteLine($"Cancelando {taskNumber}");
            }
        }

        private static void DoOrders(int taskNumber)
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
                Console.WriteLine($"Fazendo pedido {taskNumber}");
                orderClient.CancelOrder(order);
                Console.WriteLine($"Cancelando {taskNumber}");
            }
        }
    }
}
