namespace ConsoleApp6_Array_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int toplanan  = IkiEdedinToplami(10, 5);
            int ferq = IkiEdedinFerqi(10, 5);
            int hasil = IkiEdedinHasili(10, 5);
            int qismet = IkiEdedinQismeti(10, 5);

            Console.WriteLine("Ededlerin cemi: " + toplanan);
            Console.WriteLine("Ededlerin ferqi: " + ferq);
            Console.WriteLine("Ededlerin hasili: " + hasil);
            Console.WriteLine("Ededlerin qismeti: " + qismet);
        }
        static int IkiEdedinToplami(int a ,int b)
        {
            int c = a + b;
            return c;
        }
        static int IkiEdedinFerqi(int a, int b)
        {
            int d = a - b;
            return d;
        }
        static int IkiEdedinHasili(int a, int b)
        {
            int e = a * b;
            return e;
        }
        static int IkiEdedinQismeti(int a,int b)
        {
            int f = a / b;
            return f;
        }
    }
}
