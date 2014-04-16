namespace Frameplate.Security.Tests
{
    using System;
    using System.Collections.Generic;
    using Moq;
    using NUnit.Framework;
    using Web;

    [TestFixture]
    public class AuthenticationServiceTests
    {
        private Mock<IAuthenticationService> _authenticationServiceMock;

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            _authenticationServiceMock = new Mock<IAuthenticationService>();
        }

        [Test]
        public void Test()
        {
            var account = new Account<int>(5, "Login");

            _authenticationServiceMock.Object.SignIn(account);
        }
    }
}