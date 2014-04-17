namespace Frameplate.Security.Samples.Web.Models
{
    public class Account : IRoleAccount<int, Role>
    {
        public Account(int id, string login, Role role, string password)
        {
            Id = id;
            Login = login;
            Role = role;
            Password = password;
        }

        public int Id { get; private set; }

        public string Login { get; private set; }
        
        public Role Role { get; private set; }

        public string Password { get; private set; }
    }
}