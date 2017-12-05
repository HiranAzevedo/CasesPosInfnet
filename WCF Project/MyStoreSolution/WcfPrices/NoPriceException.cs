using System;

namespace WcfPrices
{
    public class NoPriceException : Exception
    {
        public string SkuId { get; set; }

        public NoPriceException(string skuId, string message) : base(message)
        {
            SkuId = skuId;
        }
    }
}