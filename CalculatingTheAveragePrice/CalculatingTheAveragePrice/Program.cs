namespace CalculatingTheAveragePrice
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
                    Console.WriteLine($"{j + 1}. Ders qiymetini girin: ");
                    qiymetler[i, j] = double.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("\n--- Her öğrencinin ders ortalamasını bulun---");
            double[] telebeOrtalamasi = new double[5];

            for (int i = 0; i < 5; i++)
            {
                double toplam = 0;
                for (int j = 0; j < 3; j++)
                {
                    toplam += qiymetler[i, j];
                }
                telebeOrtalamasi[i] = toplam / 3;
                Console.WriteLine($"{i + 1}. Telebenin ortalamasi: {telebeOrtalamasi[i]}");
            }

            Console.WriteLine("\n--- Her dersin ortalamasını bulun---");
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

            double enYuksekOrtalama = telebeOrtalamasi[0];
            int enYuksekTelebe = 0;

            for (int i = 0; i < 5; i++)
            {
                if (telebeOrtalamasi[i] > enYuksekOrtalama)
                {
                    enYuksekOrtalama = telebeOrtalamasi[i];
                    enYuksekTelebe = i;
                }

            }
            Console.WriteLine($"\nEn yuksek ortalamaya sahip telebe: {enYuksekTelebe + 1}, Ortalamasi: {enYuksekOrtalama}");

        }
    }
}
