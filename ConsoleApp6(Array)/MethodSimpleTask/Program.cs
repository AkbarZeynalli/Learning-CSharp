using System.Linq.Expressions;

namespace MethodSimpleTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int secim = 0;
            decimal toplama = 0;
            decimal cixma = 0;
            decimal vurma = 0;
            decimal bolme = 0;
            decimal ustAlma = 0;
            do
            {
                secim = Menu();
                switch (secim)
                {
                    case 1:

                        toplama = Toplama();
                        Yazdir("Toplama", toplama);
                        break;
                    case 2:
                        cixma = Cixma();
                        Yazdir("Çıxma", cixma);
                        break;
                    case 3:
                        vurma = Vurma();
                        Yazdir("Vurma", vurma);
                        break;
                    case 4:
                        bolme = Bolme();
                        if (bolme != 0)
                        {
                            Yazdir("Bölmə", bolme);
                        }
                        break;
                    case 5:
                        ustAlma = UstAlma();
                        Yazdir("Üst alma", ustAlma);
                        break;
                    case 6:
                        Console.WriteLine("Proqramdan çıxılır...");
                        break;



                }
            }
            while (secim > 1 && secim < 6);
        }
        static decimal Toplama()
        {
            Console.WriteLine("1.ci ədədi daxil edin:");
            int a1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("2.ci ədədi daxil edin:");
            int b1 = Convert.ToInt32(Console.ReadLine());
            decimal toplam = a1 + b1;
            return toplam;
        }
        static decimal Cixma()
        {
            Console.WriteLine("1.ci ədədi daxil edin:");
            int a2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("2.ci ədədi daxil edin:");
            int b2 = Convert.ToInt32(Console.ReadLine());
            decimal cixma = a2 - b2;
            return cixma;
        }
        static decimal Vurma()
        {
            Console.WriteLine("1.ci ədədi daxil edin:");
            int a3 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("2.ci ədədi daxil edin:");
            int b3 = Convert.ToInt32(Console.ReadLine());
            decimal vurma = a3 * b3;
            return vurma;
        }
        static decimal Bolme()
        {
            Console.WriteLine("1.ci ədədi daxil edin:");
            int a4 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("2.ci ədədi daxil edin:");
            int b4 = Convert.ToInt32(Console.ReadLine());
            if (b4 == 0)
            {
                Console.WriteLine("Bölmə sıfıra bölünə bilməz.");
                return 0;
            }
            decimal bolme = (decimal)a4 / b4;
            return bolme;
        }
        static decimal UstAlma()
        {
            Console.WriteLine("Ədəd daxil edin:");
            int a5 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Üst almaq üçün ədəd daxil edin:");
            int b5 = Convert.ToInt32(Console.ReadLine());
            decimal ustAlma = (decimal)Math.Pow(a5, b5);
            return ustAlma;
        }
        static int Menu()
        {
            Console.WriteLine("1. Toplama ");
            Console.WriteLine("2. Çıxma ");
            Console.WriteLine("3. Vurma ");
            Console.WriteLine("4. Bölmə ");
            Console.WriteLine("5. Üst alma");
            Console.WriteLine("6. Çıxış ");
            int secim = Convert.ToInt32(Console.ReadLine());
            return secim;

        }
        static void Yazdir(string operation, decimal value)
        {
            Console.WriteLine($"{operation} nəticəsi: {value}");

        }
    }

}
