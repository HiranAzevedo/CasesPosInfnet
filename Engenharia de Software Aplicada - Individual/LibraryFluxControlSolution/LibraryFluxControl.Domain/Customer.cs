using System;

namespace LibraryFluxControl.Domain
{
    public class Customer
    {
        public string Id { get; set; }

        public Customer()
        {
            Id = Guid.NewGuid().ToString("N");
        }
    }
}
