using System.ServiceModel;

namespace WcfWarehouse
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true, ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerSession)]
    public class WarehouseService : IWarehouseService
    {
        public int GetStockValue(string skuId)
        {
            return WareHouseStorage.GetStockValue(skuId);
        }

        public void SetStockValue(string skuId, int qtd)
        {
            WareHouseStorage.SetStockValue(skuId, qtd);
        }
    }
}
