using LibraryFluxControl.Domain.Abstract;
using System;

namespace LibraryFluxControl.Domain.WaitList
{
    public class WaitPosition : AbsWaitPosition
    {
        private readonly string _email;

        public WaitPosition(Customer customer)
        {
            _email = customer.Email;
        }

        public override void Update(PhysicalItem item)
        {
            Console.WriteLine($"Send email to: {_email}");
        }
    }
}
