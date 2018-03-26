using LibraryFluxControl.Domain.WaitList;
using System.Collections.Generic;

namespace LibraryFluxControl.Domain.Abstract
{
    public abstract class PhysicalItem
    {
        private readonly List<AbsWaitPosition> _waitList = new List<AbsWaitPosition>();
        public readonly string Id;

        protected PhysicalItem(string id)
        {
            Id = id;
        }

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
    }
}
