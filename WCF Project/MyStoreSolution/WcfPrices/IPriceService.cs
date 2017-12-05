using System.ServiceModel;

namespace WcfPrices
{
    [ServiceContract]
    public interface IPriceService
    {
        [OperationContract]
        decimal GetPrice(string skuId);
    }
}
