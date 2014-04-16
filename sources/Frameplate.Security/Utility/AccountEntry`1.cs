namespace Frameplate.Security.Utility
{
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;

    public class AccountEntry<TId>
    {
        internal AccountEntry()
        {
        }

        public AccountEntry(Account<TId> account)
        {
            Id = account.Id;
        }

        public TId Id { get; set; }

        public string Serialize()
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new XmlSerializer(typeof (AccountEntry<TId>));
                formatter.Serialize(stream, this);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        public static AccountEntry<TId> Deserialize<TId>(string value)
        {
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(value)))
            {
                var formatter = new XmlSerializer(typeof(AccountEntry<TId>));
                return (AccountEntry<TId>) formatter.Deserialize(stream);
            }
        }
    }
}