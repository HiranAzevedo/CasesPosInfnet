using System.Collections.Concurrent;

namespace WcfWarehouse
{
    public static class WareHouseStorage
    {
        public static ConcurrentDictionary<string, int> Warehouses { get; set; }

        public static bool SetStockValue(string skuId, int qtd)
        {
            return Warehouses.TryAdd(skuId, qtd);
        }

        public static int GetStockValue(string skuId)
        {
            if (Warehouses.TryGetValue(skuId, out int qtd))
            {
                return qtd;
            }

            return 0;
        }

        static WareHouseStorage()
        {
            Warehouses = new ConcurrentDictionary<string, int>
            {
                ["1"] = 1000,
                ["2"] = 10
            };
        }
    }
}