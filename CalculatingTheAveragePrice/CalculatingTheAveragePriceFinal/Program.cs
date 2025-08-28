namespace CalculatingTheAveragePriceFinal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[,] qiymetler = new double[5, 3];
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{i + 1}. Telebenin qiymeti: ");
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine($"{j + 1}. Dersin qiyeti: ");
                    qiymetler[i, j] = double.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("\n---Her öğrencinin ders ortalamasını bulun.---");
            double[] dersOrtalamasi = new double[5];
            for (int i = 0; i < 5; i++)
            {
                double toplam = 0;
                for (int j = 0; j < 3; j++)
                {
                    toplam += qiymetler[i, j];
                }
                dersOrtalamasi[i] = toplam / 3;
                Console.WriteLine($"{i + 1}. Telebenin ortalamasi: {dersOrtalamasi[i]}");
            }

            Console.WriteLine("\n---Her dersin ortalamasını bulun.---");
            for (int i = 0; i < 5; i++)
            {
                double toplam = 0;

                for (int j = 0; j < 3; j++)
                {
                    toplam += qiymetler[j, i];
                }
                double dersOrtalama = toplam / 5;
                Console.WriteLine($"{i + 1}. Dersin ortalamasi: {dersOrtalama}");
            }
            double enYuksekOrtalama = dersOrtalamasi[0];
            double enYuksekTelebe = 0;
            for (int i = 0; i < 5; i++)
            {
                if (dersOrtalamasi[i] > enYuksekOrtalama)
                {
                    enYuksekOrtalama = dersOrtalamasi[i];
                    enYuksekTelebe = i;
                }

            }
            Console.WriteLine($"\nEn yuksek ortalamaya sahip telebe: {enYuksekTelebe + 1}, Ortalamasi: {enYuksekOrtalama}");
        }
    }
}
