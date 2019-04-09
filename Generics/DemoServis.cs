using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Demo
{
    public class DemoServis<T>
        where T : IBasic
    {
        public int Pero(T obj)
        {
            obj.Print();
            return obj.Id;
        }
    }
}
