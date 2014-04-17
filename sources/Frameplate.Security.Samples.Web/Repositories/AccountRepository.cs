namespace Frameplate.Security.Samples.Web.Repositories
{
    using System.Collections.Generic;
    using Models;

    public static class AccountRepository
    {
        public static readonly IEnumerable<Account> Accounts
            = new[]
            {
                new Account(1, "admin", Role.Admin, "123456"), 
                new Account(2, "user", Role.User, "123456"), 
            };
    }
}