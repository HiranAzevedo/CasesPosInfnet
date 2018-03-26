using LibraryFluxControl.Domain.Abstract;

namespace LibraryFluxControl.Domain.WaitList
{
    public abstract class AbsWaitPosition
    {
        public abstract void Update(PhysicalItem item);
    }
}
