using System;

namespace LibraryFluxControl.Domain.Abstract
{
    public abstract class DigitalItem
    {
        internal string Name;

        internal string ItemId;

        protected DigitalItem(string name)
        {
            ItemId = Guid.NewGuid().ToString("N");
            Name = name;
        }
    }
}
