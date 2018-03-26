using LibraryFluxControl.Domain.Abstract;

namespace LibraryFluxControl.Domain.DownloadLink
{
    public abstract class DownloadSourceDecorator : DigitalItem
    {
        protected DigitalItem Item;

        protected DownloadSourceDecorator(DigitalItem item) : base(item.Name)
        {
            Item = item;
        }

        public abstract string GetDownloadLink();
    }
}
