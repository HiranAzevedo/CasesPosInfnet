using LibraryFluxControl.Domain.Abstract;

namespace LibraryFluxControl.Domain.DownloadLink
{
    public class S3DownloadSource : DownloadSourceDecorator
    {
        private const string BaseUrl = "https://s3.amazonaws.com/LibraryFlux/{0}";

        public S3DownloadSource(DigitalItem item) : base(item)
        {
        }

        public override string GetDownloadLink()
        {
            return string.Format(BaseUrl, Item.Name);
        }
    }
}
