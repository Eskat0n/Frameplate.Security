namespace Frameplate.Security.Web.Utility
{
    using System;
    using System.Security.Principal;

    [Serializable]
    public class CustomIdentity : MarshalByRefObject, IIdentity
    {
        private readonly AccountEntry<object> _accountEntry;

        public CustomIdentity(AccountEntry<object> accountEntry, string name)
        {
            Name = name;
            _accountEntry = accountEntry;
        }

        public object Id
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
            get { return Id != null; }
        }
    }
}