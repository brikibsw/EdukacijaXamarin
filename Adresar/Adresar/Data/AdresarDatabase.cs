using LiteDB;
using System;
using Xamarin.Forms;

namespace Adresar.Data
{
    public class AdresarDatabase : IDisposable
    {
        private readonly LiteDatabase db;
        public AdresarDatabase()
        {
            db = new LiteDatabase(DependencyService.Get<IDataBaseAccess>().DatabasePath());
            Cities = db.GetCollection<City>("cities");
            ContactInfos = db.GetCollection<ContactInfo>("contactinfos");
            ContactTypes = db.GetCollection<ContactType>("contacttypes");
            PersonAddresses = db.GetCollection<PersonAddress>("personaddresses");
            Persons = db.GetCollection<Person>("persons");
        }

        public LiteCollection<City> Cities { get; }
        public LiteCollection<ContactInfo> ContactInfos { get; }
        public LiteCollection<ContactType> ContactTypes { get; }
        public LiteCollection<PersonAddress> PersonAddresses { get; }
        public LiteCollection<Person> Persons { get; }

        public void Dispose()
        {
            if( db != null )
            {
                db.Dispose();
            }
        }
    }
}
