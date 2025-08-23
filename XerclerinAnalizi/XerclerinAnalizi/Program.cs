using System.Runtime.CompilerServices;

namespace XerclerinAnalizi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;
            decimal toplamQidaXerci = 0;
            decimal toplamNeqliyyatXerci = 0;
            decimal toplamTehsilXerci = 0;
            decimal toplamKommunikasiyaXerci = 0;
            decimal toplamKommunalXerci = 0;
            decimal toplamDigerXerci = 0;
            do
            {
                Console.WriteLine("Salam, xərclərin analizinə xoş gəlmisiniz!");
                Console.WriteLine("1.Qida:");
                Console.WriteLine("2.Nəqliyyat:");
                Console.WriteLine("3.Təhsil:");
                Console.WriteLine("4.Kommunikasiya (internet, telefon və.s):");
                Console.WriteLine("5.Kommunal:");
                Console.WriteLine("6.Digər:");
                Console.WriteLine("7.Çıxış");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        toplamQidaXerci = Qida();
                        Console.WriteLine($"Həftəlik Qida xərci: {toplamQidaXerci} AZN");
                        break;
                    case 2:
                        toplamNeqliyyatXerci = Neqliyyat();
                        Console.WriteLine($"Həftəlik Nəqliyyat xərci: {toplamNeqliyyatXerci} AZN");
                        break;
                    case 3:
                        toplamTehsilXerci = Tehsil();
                        Console.WriteLine($"Həftəlik Təhsil xərci: {toplamTehsilXerci} AZN");
                        break;
                    case 4:
                        toplamKommunikasiyaXerci = Kommunikasiya();
                        Console.WriteLine($"Həftəlik Kommunikasiya xərci: {toplamKommunikasiyaXerci} AZN");
                        break;
                    case 5:
                        toplamKommunalXerci = Kommunal();
                        Console.WriteLine($"Həftəlik Kommunal xərci: {toplamKommunalXerci} AZN");
                        break;
                    case 6:
                        toplamDigerXerci = Diger();
                        Console.WriteLine($"Həftəlik Digər xərci: {toplamDigerXerci} AZN");
                        break;
                    case 7:
                        Console.WriteLine("Proqramdan çıxılır...");
                        break;

                }
            }
            while (choice != 7);
            Console.WriteLine($"Həftə ərzində toplam xərc: {UmumiXerc(toplamQidaXerci, toplamNeqliyyatXerci, toplamTehsilXerci, toplamKommunikasiyaXerci, toplamKommunalXerci, toplamDigerXerci)} AZN");

            decimal enCoxXerc = EnCoxXerc(toplamQidaXerci, toplamNeqliyyatXerci, toplamTehsilXerci, toplamKommunikasiyaXerci, toplamKommunalXerci, toplamDigerXerci);
            Console.WriteLine($"Ən çox hansı növ üçün xərc çəkilib  və miqdarı {enCoxXerc}");

            decimal enAzXerc = EnAzXerc(toplamQidaXerci, toplamNeqliyyatXerci, toplamTehsilXerci, toplamKommunikasiyaXerci, toplamKommunalXerci, toplamDigerXerci);
            Console.WriteLine($"Ən az hansı növ üçün xərc çəkilib  və miqdarı {enAzXerc}");

            decimal gunlukOrtalamaXerc = GunlukOrtalamaXerc(UmumiXerc(toplamQidaXerci, toplamNeqliyyatXerci, toplamTehsilXerci, toplamKommunikasiyaXerci, toplamKommunalXerci, toplamDigerXerci));
            Console.WriteLine($"Günlük ortalama xərc nə qədərdir: {gunlukOrtalamaXerc}");
        }

        public static decimal Qida()
        {
            decimal totalQida = 0;
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"{i + 1}. günün Qida xərcini daxil edin: ");
                decimal qidaXerci = Convert.ToDecimal(Console.ReadLine());
                totalQida += qidaXerci;
            }
            return totalQida;
        }
        public static decimal Neqliyyat()
        {
            decimal totalNeqliyyat = 0;
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"{i + 1}. günün Nəqliyyat xərcini daxil edin: ");
                decimal neqliyyatXerci = Convert.ToDecimal(Console.ReadLine());
                totalNeqliyyat += neqliyyatXerci;
            }
            return totalNeqliyyat;
        }
        public static decimal Tehsil()
        {
            decimal totalTehsil = 0;
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"{i + 1}. günün Təhsil xərcini daxil edin: ");
                decimal tehsilXerci = Convert.ToDecimal(Console.ReadLine());
                totalTehsil += tehsilXerci;
            }
            return totalTehsil;
        }
        public static decimal Kommunikasiya()
        {
            decimal totalKommunikasiya = 0;
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"{i + 1}. günün Kommunikasiya xərcini daxil edin: ");
                decimal kommunikasiyaXerci = Convert.ToDecimal(Console.ReadLine());
                totalKommunikasiya += kommunikasiyaXerci;
            }
            //Console.WriteLine($"Həftəlik Kommunikasiya xərci: {totalKommunikasiya} AZN");
            return totalKommunikasiya;
        }
        public static decimal Kommunal()
        {
            decimal totalKommunal = 0;
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"{i + 1}. günün Kommunal xərcini daxil edin: ");
                decimal kommunalXerci = Convert.ToDecimal(Console.ReadLine());
                totalKommunal += kommunalXerci;
            }
            //Console.WriteLine($"Həftəlik Kommunal xərci: {totalKommunal} AZN");
            return totalKommunal;
        }
        public static decimal Diger()
        {
            decimal totalDiger = 0;
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"{i + 1}. günün Digər xərcini daxil edin: ");
                decimal digerXerci = Convert.ToDecimal(Console.ReadLine());
                totalDiger += digerXerci;
            }
            return totalDiger;
        }
        public static decimal UmumiXerc(decimal qida, decimal neqliyyat, decimal tehsil, decimal kommunikasiya, decimal kommunal, decimal diger)
        {
            decimal umumiXerc = qida + neqliyyat + tehsil + kommunikasiya + kommunal + diger;
            return umumiXerc;
        }

        public static decimal EnCoxXerc(decimal qida, decimal neqliyyat, decimal tehsil, decimal kommunikasiya, decimal kommunal, decimal diger)
        {
            decimal maxXerc = Math.Max(qida, Math.Max(neqliyyat, Math.Max(tehsil, Math.Max(kommunikasiya, Math.Max(kommunal, diger)))));
            return maxXerc;
        }

        public static decimal EnAzXerc(decimal qida, decimal neqliyyat, decimal tehsil, decimal kommunikasiya, decimal kommunal, decimal diger)
        {
            decimal minimumXerc = Math.Min(qida, Math.Min(neqliyyat, Math.Min(tehsil, Math.Min(kommunikasiya, Math.Min(kommunal, diger)))));
            return minimumXerc;
        }

        public static decimal GunlukOrtalamaXerc(decimal umumiXerc)
        {
            decimal gunlukOrtalama = Math.Round(umumiXerc / 7);
            return gunlukOrtalama;
        }
    }
}
