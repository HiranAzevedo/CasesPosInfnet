using LibraryFluxControl.Domain.Factory;

namespace LibraryFluxControl.Domain
{
    class Librarian
    {
        private AbsLibraryItemsFactory libraryInUse;

        public Librarian(AbsLibraryItemsFactory factory)
        {
            libraryInUse = factory;
        }
    }
}
