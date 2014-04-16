namespace Frameplate.Security.Web.Utility
{
    using System;
    using System.Security.Principal;

    [Serializable]
    public class CustomIdentity<TId> : MarshalByRefObject, IIdentity
    {
        private readonly AccountEntry<TId> _accountEntry;

        public CustomIdentity(AccountEntry<TId> accountEntry, string name)
        {
            Name = name;
            _accountEntry = accountEntry;
        }

        public TId Id
        {
            get { return _accountEntry.Id; }
        }

        public string Name { get; private set; }

        public string AuthenticationType
        {
            get { return "Custom"; }
        }

        public bool IsAuthenticated
        {
            get { return Id.Equals(default(TId)) == false; }
        }
    }
}