Console.WriteLine("Doğulduğunuz günü daxil edin:");
int day = int.Parse(Console.ReadLine());
Console.WriteLine("Doğulduğunuz ayı daxil edin:");
int month = int.Parse(Console.ReadLine());
Console.WriteLine("Doğulduğunuz ili daxil edin:");
int year = int.Parse(Console.ReadLine());

DateTime birthDate = new DateTime(year, month, day);
DateTime now = DateTime.Now;

int totalMonthsLived = (now.Year - birthDate.Year) * 12 + now.Month - birthDate.Month;
if (now.Day < birthDate.Day)
{
    totalMonthsLived--;
}

int totalDaysLived =(int)(now -  birthDate).TotalDays;
if (now.Day < birthDate.Day)
{
    totalDaysLived--;
}

Console.WriteLine($"Yaşadığınız ay sayı: {totalMonthsLived}");
Console.WriteLine($"Yaşadığınız gün sayı: {totalDaysLived}");