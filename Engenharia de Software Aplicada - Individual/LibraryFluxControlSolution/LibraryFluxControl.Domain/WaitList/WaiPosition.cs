using LibraryFluxControl.Domain.Abstract;
using System;

namespace LibraryFluxControl.Domain.WaitList
{
    internal class WaiPosition : AbsWaitPosition
    {
        private readonly string _email;

        public WaiPosition(string email)
        {
            _email = email;
        }

        public override void Update(PhysicalItem item)
        {
            Console.WriteLine($"Send email to: {_email}");
        }
    }
}
