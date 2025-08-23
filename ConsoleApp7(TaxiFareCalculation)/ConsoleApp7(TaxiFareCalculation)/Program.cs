namespace ConsoleApp7_TaxiFareCalculation_
{
    internal class Program
    {

        //sabit deyerler
        const double acilis = 1.50;
        const double gunduz_km = 12.00;
        const double gece_km = 15.00;
        const double Bekleme_brimi = 0.75;
        const double bavul_birimi = 5.00;
        const double havalimani = 20.00;
        const double minimum_tutar = 40.00;

        // ---- Gün Sonu Nəticələri ----
        static int toplamYolculuk = 0;
        static double toplamCiro = 0;
        static double maxTutar = 0;
        static int maxSaat = 0;
        static double minTutar = double.MaxValue;
        static int minSaat = 0;
        static int geceSayisi = 0;
        static int gündüzSayisi = 0;
        static void Main(string[] args)
        {
            int secim = -1;
            while (true)
            {
                Console.WriteLine("\n          Taksi Ücret Hesaplama   ");
                Console.WriteLine("1.Yeni Yolculuk Hesapla");
                Console.WriteLine("2.Gün Sonu Özeti Görüntüle");
                Console.WriteLine("0.Çıkış");
                Console.Write("Seçiminiz: ");
                string giris = Console.ReadLine();

                if (!int.TryParse(giris, out secim)) secim = -1;

                if (secim == 1)
                {
                    YeniYolculuk();
                }
                else if (secim == 2)
                {
                    GunSonuOzeti();
                }
                else if (secim == 0)
                {
                    Console.WriteLine("Programdan çıkılıyor...");
                }
                else
                {
                    Console.WriteLine("Hatalı seçim!");
                }
            }
        }
        static double KmUcretiSaatBazli(int saat)
        {
            if (saat >= 6 && saat <= 23)
                return gunduz_km;
            else
                return gece_km;
        }

        static double TabanUcret(double km, double kmBirim, double acilis)
        {
            return km * kmBirim + acilis;
        }
        static double BeklemeUcreti(int dakika, double birimDakika)
        {
            return dakika * birimDakika;
        }

        static double BavulUcreti(int adet, double birimBavul)
        {
            return adet * birimBavul;
        }

        static double HavaalaniUcreti(bool varMi, double sabitUcret)
        {
            if (varMi) return sabitUcret;
            return 0;
        }

        static double SurgeKatsayisi(int secim)
        {
            if (secim == 2) return 1.25;
            if (secim == 3) return 1.5;
            return 1.0;
        }

        static double MinimumUygula(double tutar, double minimum)
        {
            if (tutar < minimum) return minimum;
            return tutar;
        }

        static double IndirimUygula(double tutar, string kod)
        {
            if (kod == "IND10") return tutar * 0.9;
            if (kod == "SABIT5") return tutar - 5;
            return tutar;
        }

        static bool EvetHayirOku(string giris)
        {
            if (giris.ToUpper() == "E") return true;
            return false;
        }

        static void FisYazdir(double toplam, int saat)
        {
            Console.WriteLine("\n---- Yolculuk Fişi ----");
            Console.WriteLine("Saat: " + saat);
            Console.WriteLine("Tutar: " + toplam.ToString("0.00") + " TL");
            Console.WriteLine("---------------------------\n");
        }

        static void YeniYolculuk()
        {
            Console.WriteLine("\n---- Yeni Yolculuk ----");

            Console.Write("Saat (0-23): ");
            int saat = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("mesafe(km: )");
            double km = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Bekleme süresi (dk):");
            int dakika = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Bavul sayısı (0-5): ");
            int bavul = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Havaalanı ücreti var mı? (E/H): ");
            bool havaalaniVar = EvetHayirOku(Console.ReadLine());

            Console.WriteLine("Yoğunluk (1=Normal, 2=Yoğun, 3=Çok Yoğun):");
            int yogunluk = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("İndirim kodu (boş geçilebilir): ");
            string indirimKod = Console.ReadLine().ToUpper();

            double kmBrim = KmUcretiSaatBazli(saat);
            double taban = TabanUcret(km, kmBrim, acilis);
            double bekleme = BeklemeUcreti(dakika, Bekleme_brimi);
            double bavulUcreti = BavulUcreti(bavul, bavul_birimi);
            double hava  = HavaalaniUcreti(havaalaniVar, havalimani);

            double toplam = taban + bekleme + bavulUcreti + hava;
            toplam = MinimumUygula(toplam, minimum_tutar);
            toplam *= SurgeKatsayisi(yogunluk);
            toplam = IndirimUygula(toplam, indirimKod);
            if (toplam <0 )
            {
                toplam = 0;
            }
            toplamYolculuk++;
            toplamCiro += toplam;
            if (toplam > maxTutar) {
                maxTutar = toplam;
                maxSaat = saat;
            } 
            if (toplam < minTutar) {
                minTutar = toplam; 
                minSaat = saat;
            }

            if (saat >=6 && saat <=23)
            {
                gündüzSayisi++;
            }
            else
            {
                geceSayisi++;   

            }
        }

        static void GunSonuOzeti()
        {
            Console.WriteLine("\n---- Gün Sonu Özeti ----");
            Console.WriteLine("Toplam Yolculuk: " + toplamYolculuk);
            Console.WriteLine("Toplam Ciro: " + toplamCiro.ToString("0.00") + " TL");
            Console.WriteLine("En Yüksek Tutar: " + maxTutar.ToString("0.00") + " TL (Saat: " + maxSaat + ")");
            Console.WriteLine("En Düşük Tutar: " + minTutar.ToString("0.00") + " TL (Saat: " + minSaat + ")");
            Console.WriteLine("Gündüz Yolculuk Sayısı: " + gündüzSayisi);
            Console.WriteLine("Gece Yolculuk Sayısı: " + geceSayisi);
            Console.WriteLine("---------------------------\n");
        }
    }
}
