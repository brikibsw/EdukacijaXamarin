using System;
using System.Collections.Generic;

namespace Adresar.Data
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public List<PersonAddress> Addresses { get; set; }
        public List<ContactInfo> ContactInfos { get; set; }
    }
}
