using System.Collections.Generic;

namespace Adresar.Data
{
    public class AdresarDatabase
    {
        public List<City> Cities { get; set; }
        public List<ContactInfo> ContactInfos { get; set; }
        public List<ContactType> ContactTypes { get; set; }
        public List<PersonAddress> PersonAddresses { get; set; }
        public List<Person> Persons { get; set; }
    }
}
