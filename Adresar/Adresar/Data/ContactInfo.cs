using LiteDB;

namespace Adresar.Data
{
    public class ContactInfo
    {
        public int Id { get; set; }

        [BsonRef("contacttypes")]
        public ContactType ContactType { get; set; }

        public string Value { get; set; }
    }
}
