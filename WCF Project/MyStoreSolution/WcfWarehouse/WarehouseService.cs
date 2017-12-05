using System.ServiceModel;

namespace WcfWarehouse
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class WarehouseService : IWarehouseService
    {
        public int GetStockValue(string skuId)
        {
            return WareHouseStorage.GetStockValue(skuId);
        }

        public bool SetStockValue(string skuId, int qtd)
        {
            return WareHouseStorage.SetStockValue(skuId, qtd);
        }
    }
}
