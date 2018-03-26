using LibraryFluxControl.Domain.Abstract;

namespace LibraryFluxControl.Domain.WaitList
{
    internal abstract class AbsWaitPosition
    {
        public abstract void Update(PhysicalItem item);
    }
}
