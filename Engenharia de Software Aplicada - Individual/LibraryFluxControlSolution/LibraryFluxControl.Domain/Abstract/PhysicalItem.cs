using System.Collections.Generic;
using LibraryFluxControl.Domain.WaitList;

namespace LibraryFluxControl.Domain.Abstract
{
    internal abstract class PhysicalItem
    {
        private readonly List<AbsWaitPosition> _waitList = new List<AbsWaitPosition>();

        public void AddWaitList(AbsWaitPosition customerWaiting)
        {
            _waitList.Add(customerWaiting);
        }

        public void RemoveWaitList(AbsWaitPosition custWaitPosition)
        {
            _waitList.Remove(custWaitPosition);
        }

        //Chamar notify quando item entrar no estoque
        public void Notify()
        {
            foreach (var waitingCustomer in _waitList)
            {
                waitingCustomer.Update(this);
            }
        }

        internal string ItemId;
    }
}
