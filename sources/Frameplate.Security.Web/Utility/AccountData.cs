namespace Frameplate.Security.Web.Utility
{
    using Newtonsoft.Json;

    public class AccountData
    {
        protected AccountData()
        {
        }

        public static AccountData Create<TId>(IAccount<TId> account)
        {
            return new AccountData<TId>{Id = account.Id};
        }

        public object Id { get; set; }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this, GetConverter());
        }

        public static AccountData Deserialize(string value)
        {
            return JsonConvert.DeserializeObject<AccountData>(value, GetConverter());
        }

        private static JsonSerializerSettings GetConverter()
        {
            return new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
        }
    }

    public class AccountData<TId> : AccountData
    {
        public new TId Id
        {
            get { return (TId) base.Id; }
            set { base.Id = value; }
        }
    }
}