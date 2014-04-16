namespace Frameplate.Security.Tests
{
    using System;
    using NUnit.Framework;
    using Web.Utility;

    [TestFixture]
    public class CustomIdentityTests
    {
        internal class Stub
        {
            protected bool Equals(Stub other)
            {
                return true;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != GetType()) return false;
                return Equals((Stub) obj);
            }
        }

        private static readonly object[] ShouldProcessClassAndStructIdentifiersSource =
        {
            4, string.Empty, "Test", new Guid("52de76a6-dded-4dda-8d8e-774d19de556a"), new Stub()
        };

        [Test]
        [TestCaseSource("ShouldProcessClassAndStructIdentifiersSource")]
        public void ShouldProcessClassAndStructIdentifiers(object id)
        {
            var account = new Account<object>(id, "Login");
            var accountEntry = new AccountEntry<object>(account);
            var identity = new CustomIdentity(accountEntry,
                                              account.Login);

            Assert.IsTrue(identity.IsAuthenticated);
        }
    }    
}
