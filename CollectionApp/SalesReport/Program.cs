namespace SalesReport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] product = new int[4, 7];   
            int[] toplamSatis = new int[4];   
            int[] gunToplam = new int[7];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.Write($"Product {i + 1}, Day {j + 1} satış: ");
                    product[i, j] = int.Parse(Console.ReadLine());
                }
            }


            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    toplamSatis[i] += product[i, j];
                    gunToplam[j] += product[i, j];
                }
                Console.WriteLine($"Ürün {i + 1} toplam satış: {toplamSatis[i]}");
            }

            int maxUrun = 0;
            for (int i = 1; i < 4; i++)
                if (toplamSatis[i] > toplamSatis[maxUrun]) maxUrun = i;
            Console.WriteLine($"En çok satan ürün: Ürün {maxUrun + 1}");

            int maxGun = 0;
            for (int j = 1; j < 7; j++)
                if (gunToplam[j] > gunToplam[maxGun]) maxGun = j;
            Console.WriteLine($"En çok satış yapılan gün: Gün {maxGun + 1}");

        }
    }
}
