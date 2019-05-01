using System.IO;
using Adresar.Data;
using Adresar.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseAccess))]
namespace Adresar.Droid
{
    public class DatabaseAccess : IDataBaseAccess
    {
        public string DatabasePath()
        {
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "adresar.db");

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }

            return path;
        }
    }
}