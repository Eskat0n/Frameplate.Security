namespace Frameplate.Security.Tests
{
    using System;
    using NUnit.Framework;
    using Web.Utility;

    [TestFixture]
    public class CustomIdentityTests
    {
        private class Stub
        {
            protected bool Equals(Stub other)
            {
                throw new NotImplementedException();
            }

            public override int GetHashCode()
            {
                throw new NotImplementedException();
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                return obj.GetType() == GetType();
            }
        }

        private static readonly object[] ShouldProcessClassAndStructIdentifiersSource =
        {
            4, string.Empty, "Test", new Guid("52de76a6-dded-4dda-8d8e-774d19de556a"), new Stub()
        };

        [Test]
        [TestCaseSource("ShouldProcessClassAndStructIdentifiersSource")]
        public void ShouldProcessClassAndStructIdentifiers<T>(T id)
        {
            var account = new Account<T>(id, "Login");
            var accountEntry = new AccountEntry<T>(account);
            var identity = new CustomIdentity<T>(accountEntry,
                                                 account.Login);

            Assert.IsTrue(identity.IsAuthenticated);
        }
    }    
}
