namespace DemoArrays
{
    public class Kalkulator
    {
        public static int Zbroji(int x, int y, int z = 0, int q = 0)
        {
            return x + y + z + q;
        }

        public static int Oduzmi(int x, int y)
        {
            return x - y;
        }

        public static int Mnozi(int x, int y)
        {
            return x * y;
        }

        public static int Djeli(int x, int y)
        {
            return x / y;
        }
    }
}
