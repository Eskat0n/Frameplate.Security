namespace Frameplate.Security.Web.Utility
{
    using System;
    using System.Security.Principal;

    [Serializable]
    public class FrameplateIdentity : MarshalByRefObject, IIdentity
    {
        private readonly AccountData _accountData;

        public FrameplateIdentity(AccountData accountData, string name)
        {
            Name = name;
            _accountData = accountData;
        }

        public object Id
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
            get { return Id != null; }
        }
    }
}