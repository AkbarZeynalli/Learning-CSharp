namespace XərclərinAnalizi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Xərclərin Analizi Proqramı");
            int secim = 0;
            decimal toplamQida = 0;
            decimal toplamNeqliyyat = 0;
            decimal toplamTehsil = 0;
            decimal toplamKommunikasiya = 0;
            decimal toplamKommunal = 0;

            do
            {
                Console.WriteLine("1.Qida");
                Console.WriteLine("2.Nəqliyyat");
                Console.WriteLine("3.Təhsil");
                Console.WriteLine("4.Kommunikasiya (internet, telefon və.s) ");
                Console.WriteLine("5.Kommunal");
                Console.WriteLine("6.Hebasat və Cixis");
                Console.WriteLine("Hansı xərcləri daxil etmək istəyirsiniz? (1-7): ");
                secim = Convert.ToInt32(Console.ReadLine());

                switch (secim)
                {
                    case 1:
                        toplamQida = Qida();
                        Console.WriteLine($"Toplam qida xərcləri: {toplamQida} AZN");
                        break;
                    case 2:
                        toplamNeqliyyat = Nəqliyyat();
                        Console.WriteLine($"Toplam nəqliyyat xərcləri: {toplamNeqliyyat} AZN");
                        break;
                    case 3:
                        toplamTehsil = Tehsil();
                        Console.WriteLine($"Toplam təhsil xərcləri: {toplamTehsil} AZN");
                        break;
                    case 4:
                        toplamKommunikasiya = Kommunikasiya();
                        Console.WriteLine($"Toplam kommunikasiya xərcləri: {toplamKommunikasiya} AZN");
                        break;
                    case 5:
                        toplamKommunal = Kommunal();
                        Console.WriteLine($"Toplam kommunal xərcləri: {toplamKommunal} AZN");
                        break;
                    case 6:
                        decimal toplamXerc = ToplamXerc(toplamQida, toplamNeqliyyat, toplamTehsil, toplamKommunikasiya, toplamKommunal);
                        decimal enCoxXerc = EnCoxXerc(toplamQida, toplamNeqliyyat, toplamTehsil, toplamKommunikasiya, toplamKommunal);
                        decimal enAzXerc = EnAzXerc(toplamQida, toplamNeqliyyat, toplamTehsil, toplamKommunikasiya, toplamKommunal);
                        decimal ortalamaXerc = OrtalamaXerc(toplamQida, toplamNeqliyyat, toplamTehsil, toplamKommunikasiya, toplamKommunal);
                        Hesabat(toplamXerc, enCoxXerc, enAzXerc, ortalamaXerc);
                        break;


                }

            }
            while (secim>1&&secim<6);
            ;
        }
        static decimal Qida()
        {
            decimal toplamQida = 0;
            Console.WriteLine("Qida xərclərini daxil edin:");
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"Gün {i + 1} xercini daxil edin: ");
                decimal xerc = Convert.ToDecimal(Console.ReadLine());
                toplamQida += xerc;
            }
            return toplamQida;
        }
        static decimal Nəqliyyat()
        {
            decimal toplamNeqliyyat = 0;
            Console.WriteLine("Nəqliyyat xərclərini daxil edin:");
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"Gün {i + 1} xercini daxil edin: ");
                decimal xerc = Convert.ToDecimal(Console.ReadLine());
                toplamNeqliyyat += xerc;
            }
            return toplamNeqliyyat;
        }
        static decimal Tehsil()
        {
            decimal toplamTehsil = 0;
            Console.WriteLine("Təhsil xərclərini daxil edin:");
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"Gün {i + 1} xercini daxil edin: ");
                decimal xerc = Convert.ToDecimal(Console.ReadLine());
                toplamTehsil += xerc;
            }
            return toplamTehsil;
        }
        static decimal Kommunikasiya()
        {
            decimal toplamKommunikasiya = 0;
            Console.WriteLine("Kommunikasiya xərclərini daxil edin:");
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"Gün {i + 1} xercini daxil edin: ");
                decimal xerc = Convert.ToDecimal(Console.ReadLine());
                toplamKommunikasiya += xerc;
            }
            return toplamKommunikasiya;
        }
        static decimal Kommunal()
        {
            decimal toplamKommunal = 0;
            Console.WriteLine("Kommunal xərclərini daxil edin:");
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"Gün {i + 1} xercini daxil edin: ");
                decimal xerc = Convert.ToDecimal(Console.ReadLine());
                toplamKommunal += xerc;
            }
            return toplamKommunal;
        }
        static void Hesabat(decimal toplamXerc, decimal enCoxXerc,decimal enAzXerc,decimal ortalamaXerc)
        {
            Console.WriteLine($"Ümumi xərclər: {toplamXerc} AZN");
            Console.WriteLine($"Ən çox hansı növ üçün xərc çəkilib və miqdarı: {enCoxXerc}");
            Console.WriteLine($"Ən az hansı növ üçün xərc çəkilib və miqdarı: {enAzXerc}");
            Console.WriteLine($"Günlük ortalama xərc nə qədərdir: {ortalamaXerc}");
            Console.WriteLine("Proqramdan çıxılır...");
         
        }
        static decimal ToplamXerc(decimal qida, decimal neqliyat, decimal tehsil, decimal kom, decimal komunal)
        {
            decimal toplam = qida + neqliyat + tehsil + kom + komunal;
            return toplam;
        }
        static decimal EnCoxXerc(decimal qida, decimal neqliyat, decimal tehsil, decimal kom, decimal komunal)
        {
            decimal maxXerc = Math.Max(Math.Max(qida, neqliyat), Math.Max(tehsil, Math.Max(kom, komunal)));
            return maxXerc;
        }
        static decimal EnAzXerc(decimal qida, decimal neqliyat, decimal tehsil, decimal kom, decimal komunal)
        {
            decimal minXerc = Math.Min(Math.Min(qida, neqliyat), Math.Min(tehsil, Math.Min(kom, komunal)));
            return minXerc;
        }
        static decimal OrtalamaXerc(decimal qida, decimal neqliyat, decimal tehsil, decimal kom, decimal komunal)
        {
            decimal toplamXerc = ToplamXerc(qida, neqliyat, tehsil, kom, komunal);
            decimal ortalama = toplamXerc / 7;
            return ortalama;
        }
    }
}
