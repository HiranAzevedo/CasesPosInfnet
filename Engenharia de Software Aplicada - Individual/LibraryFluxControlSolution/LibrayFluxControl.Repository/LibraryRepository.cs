using LibraryFluxControl.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrayFluxControl.Repository
{
    public class LibraryRepository
    {
        private readonly List<ItemStock> _physicalStock = new List<ItemStock>();

        private readonly List<DigitalLog> _digitalStock = new List<DigitalLog>();

        public bool RetrievePhysicalItem(PhysicalItem item, string customerId)
        {
            var itemInStock = _physicalStock.FirstOrDefault(x => x.ItemId.Equals(item.Id));

            if (itemInStock == null)
            {
                return false;
            }

            if (itemInStock.StockBalance <= 0)
            {
                return false;
            }

            itemInStock.CustomerId.Add(customerId);
            itemInStock.StockBalance -= 1;
            return true;
        }

        public bool ReturnPhysicalItem(PhysicalItem item, string customerId)
        {
            var itemInStock = _physicalStock.FirstOrDefault(x => x.ItemId.Equals(item.Id));

            if (itemInStock == null)
            {
                return false;
            }

            if (!itemInStock.CustomerId.Remove(customerId))
            {
                return false;
            }

            itemInStock.StockBalance += 1;
            item.Notify();
            return true;
        }

        public bool RegisterNewPhysicalItem(PhysicalItem item, int stockBalance)
        {
            _physicalStock.Add(new ItemStock
            {
                ItemId = item.Id,
                StockBalance = stockBalance,
                CustomerId = new List<string>(),
            });

            return true;
        }

        public bool RegisterDigitalDownload(string itemId, string customerId)
        {
            _digitalStock.Add(new DigitalLog
            {
                ItemId = itemId,
                CustomerId = customerId,
                DateDownloaded = DateTime.Now
            });

            return true;
        }

        public List<string> GetCustomerId(string id)
        {
            return _digitalStock.Where(x => x.ItemId.Equals(id)).Select(x => x.CustomerId).ToList();
        }
    }

    internal class DigitalLog
    {
        public string ItemId { get; set; }

        public string CustomerId { get; set; }

        public DateTime DateDownloaded { get; set; }
    }

    internal class ItemStock
    {
        public string ItemId { get; set; }

        public List<string> CustomerId { get; set; }

        public int StockBalance { get; set; }
    }
}