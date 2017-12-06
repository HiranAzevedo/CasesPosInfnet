using System.Collections.Concurrent;
using System.ServiceModel;

namespace WcfWarehouse
{
    public static class WareHouseStorage
    {
        public static ConcurrentDictionary<string, int> Warehouses = new ConcurrentDictionary<string, int>
        {
            ["1"] = 10,
        };

        public static void SetStockValue(string skuId, int qtd)
        {
            if (qtd < default(int))
            {
                throw new FaultException<NoStockException>(new NoStockException());
            }

            var resultRemove = Warehouses.TryRemove(skuId, out int value);
            if (resultRemove)
            {
                var resultadd = Warehouses.TryAdd(skuId, qtd);
                if (!resultadd)
                {
                    throw new FaultException<NoStockException>(new NoStockException());
                }
            }
            else
            {
                throw new FaultException<NoStockException>(new NoStockException());
            }
        }

        public static int GetStockValue(string skuId)
        {
            if (Warehouses.TryGetValue(skuId, out int qtd))
            {
                return qtd;
            }

            return 0;
        }
    }
}