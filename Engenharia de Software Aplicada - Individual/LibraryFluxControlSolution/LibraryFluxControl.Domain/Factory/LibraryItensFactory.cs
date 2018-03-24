using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryFluxControl.Domain.Abstract;

namespace LibraryFluxControl.Domain.Factory
{
    abstract class AbsLibraryItemsFactory
    {
        public abstract DigitalItem GetDigitalItem();

        public abstract PhysicalItem GetPhysicalItem();
    }

    class Library1ItemsFactory : AbsLibraryItemsFactory
    {
        public override DigitalItem GetDigitalItem()
        {
            throw new NotImplementedException();
        }

        public override PhysicalItem GetPhysicalItem()
        {
            throw new NotImplementedException();
        }
    }

    class Library2ItemsFactory : AbsLibraryItemsFactory
    {
        public override DigitalItem GetDigitalItem()
        {
            throw new NotImplementedException();
        }

        public override PhysicalItem GetPhysicalItem()
        {
            throw new NotImplementedException();
        }
    }
}
