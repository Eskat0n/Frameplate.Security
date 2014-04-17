namespace Frameplate.Security.Web.Utility
{
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;

    public class AccountData<TId>
    {
        internal AccountData()
        {
        }

        public AccountData(IAccount<TId> account)
        {
            Id = account.Id;
        }

        public TId Id { get; set; }

        public string Serialize()
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new XmlSerializer(typeof (AccountData<TId>));
                formatter.Serialize(stream, this);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        public static AccountData<TId> Deserialize(string value)
        {
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(value)))
            {
                var formatter = new XmlSerializer(typeof(AccountData<TId>));
                return (AccountData<TId>) formatter.Deserialize(stream);
            }
        }
    }
}