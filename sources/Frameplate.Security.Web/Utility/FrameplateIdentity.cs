namespace Frameplate.Security.Web.Utility
{
    using System;
    using System.Security.Principal;

    [Serializable]
    public class FrameplateIdentity<TId> : MarshalByRefObject, IIdentity
    {
        private readonly AccountData<TId> _accountData;

        public FrameplateIdentity(AccountData<TId> accountData, string name)
        {
            Name = name;
            _accountData = accountData;
        }

        public TId Id
        {
            get { return _accountData.Id; }
        }

        public string Name { get; private set; }

        public string AuthenticationType
        {
            get { return "Frameplate"; }
        }

        public bool IsAuthenticated
        {
            get { return Equals(Id, default(TId)) == false; }
        }
    }
}