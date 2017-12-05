using System.ServiceModel;
using System.Threading.Tasks;
using WcfOrderServiceLib.PriceService;
using WcfOrderServiceLib.WarehouseService;

namespace WcfOrderServiceLib
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple, IgnoreExtensionDataObject = true, IncludeExceptionDetailInFaults = true)]
    public class OrderService : IOrderService
    {
        public async Task<string> CancelOrderAsync(Order order)
        {
            using (var wareHouseClient = new WarehouseServiceClient())
            {
                foreach (var item in order.Items)
                {
                    var currentStock = await wareHouseClient.GetStockValueAsync(item.SkuId).ConfigureAwait(false);
                    currentStock += item.SkuQtd;
                    await wareHouseClient.SetStockValueAsync(item.SkuId, currentStock);
                }

                OrderStorage.CancelOrder(order);
            }

            return order.OrderId;
        }

        public async Task<string> PlaceOrderAsync(Order order)
        {
            using (var priceClient = new PriceServiceClient())
            {
                var items = order.Items;

                foreach (var item in items)
                {
                    var expectedPrice = await priceClient.GetPriceAsync(item.SkuId).ConfigureAwait(false);

                    if (!expectedPrice.Equals(item.SkuSellPrice))
                    {
                        throw new OrderValueDontMatchException(order.StoreName, order.OrderId, $"{item.SkuId} price dont match");
                    }
                }

                using (var warehouseClient = new WarehouseServiceClient())
                {
                    foreach (var item in items)
                    {
                        var currentStock = await warehouseClient.GetStockValueAsync(item.SkuId);

                        if (currentStock > item.SkuQtd)
                        {
                            currentStock -= item.SkuQtd;

                            await warehouseClient.SetStockValueAsync(item.SkuId, currentStock);
                        }
                    }
                }

                OrderStorage.AddOrder(order);

                return order.OrderId;
            }
        }
    }
}
