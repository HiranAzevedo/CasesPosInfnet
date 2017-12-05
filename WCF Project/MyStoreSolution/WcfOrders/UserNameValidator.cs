using System;
using System.IdentityModel.Selectors;
using System.ServiceModel;

namespace WcfOrders
{
    public class UserNameValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName == null || password == null)
            {
                throw new ArgumentNullException();
            }

            if (!userName.Equals("admin", StringComparison.OrdinalIgnoreCase) && !password.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                throw new FaultException("incorrect credentials");
            }
        }
    }
}