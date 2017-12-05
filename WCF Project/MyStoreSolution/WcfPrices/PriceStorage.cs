using System.Collections.Generic;

namespace WcfPrices
{
    public static class PriceStorage
    {
        public static Dictionary<string, decimal> SkuPrices { get; set; }

        static PriceStorage()
        {
            SkuPrices = new Dictionary<string, decimal>
            {
                ["1"] = 10m,
                ["2"] = 25.5m,
                ["3"] = 300m,
            };
        }
    }
}