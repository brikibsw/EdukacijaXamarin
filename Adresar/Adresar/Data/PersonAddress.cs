using LiteDB;

namespace Adresar.Data
{
    public class PersonAddress
    {
        public int Id { get; set; }

        public string Street { get; set; }

        [BsonRef("cities")]
        public City City { get; set; }
    }
}
