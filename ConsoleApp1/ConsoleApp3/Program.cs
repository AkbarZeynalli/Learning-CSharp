Console.InputEncoding = System.Text.Encoding.UTF8;
Console.OutputEncoding = System.Text.Encoding.UTF8;


Console.WriteLine("Admı daxil edin: ");
string ad = Console.ReadLine() ?? "Ad daxil edilmədi";
Console.WriteLine("Soyad daxil edin: ");
string soyad = Console.ReadLine() ?? "Soyad daxil edilmədi";
Console.WriteLine("Atanızın adını daxil edin: ");
string ataAdi = Console.ReadLine() ?? "Ata adı daxil edilmədi";
Console.WriteLine("Doğulduğunuz yeri daxil edin: ");
string dogulduguYer = Console.ReadLine() ?? "Doğulduğunuz yer daxil edilmədi";
Console.WriteLine("Doğulduğunuz ili daxil edin: ");
int dogumGunu = int.Parse(Console.ReadLine() ?? "0");
int indikiIl = DateTime.Now.Year;
int yas = indikiIl - dogumGunu;
Console.WriteLine("Cinsiyətinizi daxil edin: [K/Q]");
string genderInput = Console.ReadLine();
string cinsiyet = genderInput == "K" ? "oğlu" : "qızı";
Console.WriteLine("Yaşadığınız şəhəri daxil edin: ");
string seher = Console.ReadLine() ?? "Şəhər daxil edilmədi";
Console.WriteLine("Tələbəsiniz ?: [H/Y]");
string talebe = Console.ReadLine();
string universitet = string.Empty;
if (talebe.ToLower() == "h")
{
    Console.WriteLine("Universiteti daxil ediniz: ");
    universitet = Console.ReadLine() ?? "Universitet daxil edilmədi";
}
else
{
    universitet = "Tələbə deyil";
}
Console.WriteLine("İşləyirsiniz ?: [H/Y]");
string isleyir = Console.ReadLine();
string isletme = string.Empty;
if (isleyir.ToLower() == "h")
{
    Console.WriteLine("İş yerinizi daxil ediniz: ");
    isletme = Console.ReadLine() ?? "İş yeri daxil edilmədi";
}
else
{
    isletme = "İş yeri yoxdur";
}

string tecumeiHal = $"Mən, {ad} {soyad} {ataAdi} {cinsiyet}, {dogumGunu}-ci ildə {dogulduguYer} rayonunda anadan olmuşam. " +
    $"Hal-hazırda {yas} yaşım var və {seher} şəhərində yaşayıram. " +
    $"Təhsil: {(universitet != "Tələbə deyil" ? universitet + " universitetində təhsil alıram." : "Tələbə deyiləm.")} " +
    $"İş: {(isletme != "İş yeri yoxdur" ? isletme + " müəssisəsində işləyirəm." : "Hal-hazırda işləmirəm.")}";

Console.WriteLine("\nTecümeyi-hal:");
Console.WriteLine(tecumeiHal);