using System;
using LibraryFluxControl.Domain.Abstract;

namespace LibraryFluxControl.Domain.DownloadLink
{
    public abstract class DownloadSourceDecorator : DigitalItem
    {
        DigitalItem Item;

        protected string SourceName;
        protected string baseUrl;

        protected DownloadSourceDecorator(DigitalItem item)
        {
            Item = item;
        }

        public abstract string GetDownloadLink();

    }
}
