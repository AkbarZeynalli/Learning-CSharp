Console.WriteLine("Aile üzvlərinin sayı: "); 
int aileUzvleriSayisi = int.Parse(Console.ReadLine() ?? "0");
Console.WriteLine("Gün ərzində xərclənən yol pulu:");
int yolPulu = int.Parse(Console.ReadLine() ?? "0");
Console.WriteLine("Gün ərzində xərclənən qida pulu:");
int qidaPulu = int.Parse(Console.ReadLine() ?? "0");
Console.WriteLine("Gün ərzində xərclənən digər pulu:");
int digerPulu = int.Parse(Console.ReadLine() ?? "0");
Console.WriteLine("Ay ərzində xərclənən su pulu");
int suPulu = int.Parse(Console.ReadLine() ?? "0");
Console.WriteLine("Ay ərzində xərclənən elektrik pulu");
int elektrikPulu = int.Parse(Console.ReadLine() ?? "0");
Console.WriteLine("Ay ərzində xərclənən qaz pulu");
int qazPulu = int.Parse(Console.ReadLine() ?? "0");
Console.WriteLine("Ay ərzində xərclənən internet pulu");
int internetPulu = int.Parse(Console.ReadLine() ?? "0");
Console.WriteLine("Ay ərzində xərclənən Komendat pulu");
int komendatPulu = int.Parse(Console.ReadLine() ?? "0");


int gunlukAdamXerc = (yolPulu + qidaPulu + digerPulu) * 30;
int gunlukXerc = gunlukAdamXerc * aileUzvleriSayisi;
int aylikKomunalXerc = suPulu + elektrikPulu + qazPulu + internetPulu;
int aylikXerc = gunlukXerc +aylikKomunalXerc+ komendatPulu;


Console.WriteLine($"Ay ərzində xərclənən ümumi pul: {aylikXerc} AZN");
Console.WriteLine($"Gün ərzində bir adamın xərclədiyi pul: {gunlukAdamXerc} AZN");
Console.WriteLine($"Gün ərzində  {aileUzvleriSayisi} üçün xərclənən pul: {gunlukXerc} AZN");
Console.WriteLine($"Aylıq komunal xərc: {aylikKomunalXerc}");
