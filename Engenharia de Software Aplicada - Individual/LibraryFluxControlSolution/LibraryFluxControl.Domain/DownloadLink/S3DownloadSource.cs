using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryFluxControl.Domain.Abstract;

namespace LibraryFluxControl.Domain.DownloadLink
{
    public class S3DownloadSource : DownloadSourceDecorator
    {
        public S3DownloadSource(DigitalItem item) : base(item)
        {
        }

        public override string GetDownloadLink()
        {
            throw new NotImplementedException();
        }
    }
}
