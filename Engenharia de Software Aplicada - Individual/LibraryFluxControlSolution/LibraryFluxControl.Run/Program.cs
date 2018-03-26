using LibraryFluxControl.Domain;
using LibraryFluxControl.Domain.DownloadLink;
using LibraryFluxControl.Domain.Factory;
using LibraryFluxControl.Domain.WaitList;
using LibrayFluxControl.Repository;
using System;

namespace LibraryFluxControl.Run
{
    class Program
    {
        private static void Main(string[] args)
        {
            //FACTORY
            AbsLibraryItemsFactory factory = new Library1ItemsFactory();
            var physicalItem = factory.GetPhysicalItem();

            var repository = new LibraryRepository();
            repository.RegisterNewPhysicalItem(physicalItem, 10);

            var customer = new Customer();

            //OBSERVER
            var customerWaiting = new Customer { Email = "cliente10@email.com" };

            physicalItem.AddWaitList(new WaitPosition(customerWaiting));
            repository.RetrievePhysicalItem(physicalItem, customer.Id);
            repository.ReturnPhysicalItem(physicalItem, customer.Id);


            //DECORATOR
            var digitalItem = factory.GetDigitalItem("DIGITAL ENTITY");
            var source = new S3DownloadSource(digitalItem);
            Console.WriteLine(source.GetDownloadLink());
        }
    }
}
