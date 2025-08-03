namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ümumi Əmək haqqını Daxil edin:(Tam ədəd)");
            int umumiEmekHaqqi = int.Parse(Console.ReadLine());

            Console.WriteLine("Ailə vəziyətini daxil edin: (e / E: evli, b / B: subay, d / D: dul)");
            char aileVeziyyeti = char.Parse(Console.ReadLine());

            int usaqSayi = 0;
            if (aileVeziyyeti == 'e' || aileVeziyyeti == 'E' || aileVeziyyeti == 'd' || aileVeziyyeti == 'D')
            {
                Console.WriteLine("Uşaq sayını daxil edin:");
                usaqSayi = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Əlil olub-olmaması (e / E: bəli, h / N: yox)");
            char elilOlubOlmamasi = char.Parse(Console.ReadLine());

            double aileMuavineti = 0;
            int usaqPulu = 0;
            if (aileVeziyyeti == 'e' || aileVeziyyeti == 'E')
            {
                aileMuavineti = 50;
                if (usaqSayi == 1)
                {
                 
                    usaqPulu += 30;
                }
                else if (usaqSayi == 2)
                {
                   
                    usaqPulu += 55;
                }
                else if (usaqSayi == 3)
                {
                   
                    usaqPulu += 75;
                }
                else if (usaqSayi > 3)
                {
                    usaqPulu += 75 + (usaqSayi - 3) * 15;
                }
            }
            else if (aileVeziyyeti == 'd' || aileVeziyyeti == 'D')
            {
                if (usaqSayi == 1)
                {
                    usaqPulu += 30;
                }
                else if (usaqSayi == 2)
                {
                    usaqPulu += 55;
                }
                else if (usaqSayi == 3)
                {
                    usaqPulu += 75;
                }
                else if (usaqSayi > 3)
                {
                    usaqPulu += 75 + (usaqSayi - 3) * 15;
                }
            }
            else
            {
                aileMuavineti = 0;
            }

            double vergiFaizi = 0;
            if (umumiEmekHaqqi <= 1000)
            {
                vergiFaizi = 0.15;
            }
            else if (umumiEmekHaqqi > 1000 && umumiEmekHaqqi <= 2000)
            {
                vergiFaizi = 0.20;
            }
            else if (umumiEmekHaqqi > 2000 && umumiEmekHaqqi <= 3000)
            {
                vergiFaizi = 0.25;
            }
            else
            {
                vergiFaizi = 0.30;
            }

            if (elilOlubOlmamasi == 'e' || elilOlubOlmamasi == 'E')
            {
                vergiFaizi /= 2;
            }

            double vergi = umumiEmekHaqqi * vergiFaizi;

            Console.WriteLine($"ailə müavinəti {aileMuavineti}");
            Console.WriteLine($"uşaq pulu {usaqPulu}");
            Console.WriteLine($"gəlir vergisi dərəcəsi: {vergiFaizi * 100}");
            Console.WriteLine($"gəlir vergisinin məbləği: {vergi}");
            Console.WriteLine($"ümumi əmək haqqı: {umumiEmekHaqqi + aileMuavineti + usaqPulu}");
            Console.WriteLine($"xalis əmək haqqı: {umumiEmekHaqqi + aileMuavineti + usaqPulu - vergi}");
        }
    }
}
