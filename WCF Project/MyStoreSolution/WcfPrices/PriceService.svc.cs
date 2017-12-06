using System.ServiceModel;

namespace WcfPrices
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true, ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerSession)]
    public class PriceService : IPriceService
    {
        public decimal GetPrice(string skuId)
        {
            var couldGet = PriceStorage.SkuPrices.TryGetValue(skuId, out decimal value);

            return couldGet ? value : throw new NoPriceException(skuId, "Dont have price");
        }
    }
}
