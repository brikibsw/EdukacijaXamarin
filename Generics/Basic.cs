using System;

namespace Generics.SimpleDemo
{
    public class Basic<T> where T : struct
    {
        public T Id { get; set; }
    }

    class Osoba : Basic<int>
    {

    }

    class Zivotinja : Basic<Guid>
    {
    }
}
