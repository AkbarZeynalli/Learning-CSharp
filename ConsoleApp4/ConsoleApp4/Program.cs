
namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Genislenmis Tibbi Sigorta Teklifi Sistemi");
            Console.WriteLine("Yaşınızı daxil edin:");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Cinsinizi daxil edin (K/Q):");
            char gender = Convert.ToChar(Console.ReadLine().ToLower());
            Console.WriteLine(" Siqaret cekir mi? (b/x)");
            char smoking = Convert.ToChar(Console.ReadLine().ToLower());

            Console.WriteLine("Evvelki ciddi xestelik tarixcesi var mi? (b/x)");
            char previousIllness = Convert.ToChar(Console.ReadLine().ToLower());
            Console.WriteLine("Yasadigi bolge (1.Baki, 2.Gence, 3.Sumqayit, 4.Digeleri)");
            string region = Console.ReadLine();
            Console.WriteLine("Istifadecinin avtomobil markasi (1.BMW, 2.Mercedes, 3.Toyota, 4Hyundai, 5.Digeri)");
            string carBrand = Console.ReadLine();

            int bazaQiymeti = 200; // Baza qiymet
            //int elaveQiymet = 0; // Elave qiymet
            int agePrice = 0;
            if (age > 0 && age <= 18)
            {
                agePrice += 50; // 18 yasindan kicik olanlar ucun elave qiymet
            }
            else if (age >= 19 && age <= 40)
            {
                agePrice += 100; // 19-40 yas araligindaki insanlar ucun elave qiymet
            }
            else if (age >= 41 && age <= 60)
            {
                agePrice += 200; // 41-60 yas araligindaki insanlar ucun elave qiymet
            }
            else if (age > 60)
            {
                agePrice += 300; // 60 yasindan boyuk olanlar ucun elave qiymet
            }
            int genderPrice = 0;
            if (gender =='k' ||gender =='K')
            {
                genderPrice +=50; // Kişilər ucun elave qiymet
            }
            else
            {
                genderPrice += 0; // Qadınlar ucun elave qiymet yoxdur
            }
            int smokingPrice = 0;
            if (smoking == 'b' ||smoking == 'B')
            {smokingPrice += 100; // Siqaret cekenler uc

            }
            int seriousIllness = 0;
            if (previousIllness == 'b')
            {
                seriousIllness += 200; // Evvelki ciddi xestelik tarixcesi olanlar ucun elave qiymet
            }
            int regionPrice = 0;
            switch (region)
            {
                case "1": // Baki
                    regionPrice += 100; // Baki ucun elave qiymet
                    break;
                case "2": // Gence
                    regionPrice += 80; // Gence ucun elave qiymet
                    break;
                case "3": // Sumqayit
                    regionPrice += 70; // Sumqayit ucun elave qiymet
                    break;
                default: // Digeleri
                    regionPrice += 50; // Digelere elave qiymet
                    break;
            }
            int carBrandPrice = 0;
            switch (carBrand)
            {
                case "1": // BMW
                    carBrandPrice += 150; // BMW ucun elave qiymet
                    break;
                case "2": // Mercedes
                    carBrandPrice += 200; // Mercedes ucun elave qiymet
                    break;
                case "3": // Toyota
                    carBrandPrice += 100; // Toyota ucun elave qiymet
                    break;
                case "4": // Hyundai
                    carBrandPrice += 80; // Hyundai ucun elave qiymet
                    break;
                default: // Digeleri
                    carBrandPrice += 50; // Digelere elave qiymet
                    break;
            }
            int toplamQiymet = bazaQiymeti + agePrice + genderPrice + smokingPrice + seriousIllness + regionPrice + carBrandPrice;
            Console.WriteLine($"Yaşına görə məbləğ: {agePrice} AZN");
            Console.WriteLine($"Cinsə görə məbləğ: {genderPrice} AZN");
            Console.WriteLine($"Siqaretə görə məbləğ: {smokingPrice} AZN");
            Console.WriteLine($"Ciddi xəstəlik tarixçəsinə görə məbləğ: {seriousIllness} AZN");
            Console.WriteLine($"Yaşadığı bölgəyə görə məbləğ: {regionPrice} AZN");
            Console.WriteLine($"Avtomobil markasına görə məbləğ: {carBrandPrice} AZN");
            Console.WriteLine($"Toplam Sığorta Qiyməti: {toplamQiymet} AZN");
        }
    }
}
