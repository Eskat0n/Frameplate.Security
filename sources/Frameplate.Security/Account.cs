namespace Frameplate.Security
{
    using System;

    public class Account<TId> : IAccount<TId>
    {
        public Account(TId id, string login)
        {
            if (id.Equals(default(TId)))
                throw new ArgumentException("credential");
            if (login == null) 
                throw new ArgumentNullException("login");

            Id = id;
            Login = login;
        }

        public TId Id { get; private set; }

        public string Login { get; private set; }
    }
}