using LibraryFluxControl.Domain.Abstract;
using LibraryFluxControl.Domain.Domain;
using System;

namespace LibraryFluxControl.Domain.Factory
{
    public abstract class AbsLibraryItemsFactory
    {
        public abstract DigitalItem GetDigitalItem(string name);

        public abstract PhysicalItem GetPhysicalItem();
    }

    public class Library1ItemsFactory : AbsLibraryItemsFactory
    {
        public override DigitalItem GetDigitalItem(string name)
        {
            return new DigitalBook(name);
        }

        public override PhysicalItem GetPhysicalItem()
        {
            return new TechBook(Guid.NewGuid().ToString());
        }
    }

    public class Library2ItemsFactory : AbsLibraryItemsFactory
    {
        public override DigitalItem GetDigitalItem(string name)
        {
            return new AudioBook(name);
        }

        public override PhysicalItem GetPhysicalItem()
        {
            return new BiologicBook(Guid.NewGuid().ToString());
        }
    }
}