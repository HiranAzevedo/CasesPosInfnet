using System.ServiceModel;
using System.Threading.Tasks;

namespace WcfOrderServiceLib
{
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        Task<string> PlaceOrderAsync(Order order);

        [OperationContract]
        Task<string> CancelOrderAsync(Order order);
    }
}

