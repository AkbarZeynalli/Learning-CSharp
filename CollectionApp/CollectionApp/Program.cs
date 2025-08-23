using System;

class Program
{
    static void Main()
    {
        int[,] notlar = new int[5, 3];
        double[] ogrOrt = new double[5];
        double[] dersOrt = new double[3];

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write($"Öğrenci {i + 1}, Ders {j + 1}: ");
                notlar[i, j] = int.Parse(Console.ReadLine());
            }
        }

        for (int i = 0; i < 5; i++)
        {
            int toplam = 0;
            for (int j = 0; j < 3; j++) {
                toplam += notlar[i, j];
            }
            ogrOrt[i] = toplam / 3.0;
            Console.WriteLine($"Öğrenci {i + 1} ort: {ogrOrt[i]}");
        }

        for (int j = 0; j < 3; j++)
        {
            int toplam = 0;
            for (int i = 0; i < 5; i++) {
                toplam += notlar[i, j];
            }
            dersOrt[j] = toplam / 5.0;
            Console.WriteLine($"Ders {j + 1} ort: {dersOrt[j]}");
        }

        int maxInd = 0;
        for (int i = 1; i < 5; i++)
            if (ogrOrt[i] > ogrOrt[maxInd]) maxInd = i;

        Console.WriteLine($"En yüksek ort. öğrenci: {maxInd + 1}, Ort: {ogrOrt[maxInd]}");
    }

}
