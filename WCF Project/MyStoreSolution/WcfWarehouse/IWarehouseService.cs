using System.ServiceModel;

namespace WcfWarehouse
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IWarehouseService
    {

        [OperationContract]
        int GetStockValue(string skuId);

        [OperationContract]
        void SetStockValue(string skuId, int Qtd);
    }
}
