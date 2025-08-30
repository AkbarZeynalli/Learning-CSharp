namespace SalesReport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[,] salesRaport = new double[4, 7];
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"{i + 1}. məhsulun 7 günlük satışlarını giriniz:");
                for (int j = 0; j < 7; j++)
                {
                    Console.WriteLine($"{j + 1}. günün satışını daxil edin: ");
                    salesRaport[i, j] = double.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("\n--- Ürünlerin Toplam Satışları ---");
            double[] productSales = new double[4];
            for (int i = 0; i < 4; i++)
            {
                double sum = 0;
                for (int j = 0; j < 7; j++)
                {
                    sum += salesRaport[i, j];
                }
                productSales[i] = sum;

                Console.WriteLine($"{i + 1}. məhsulun həftəlik satışları: {productSales[i]}");
            }

            double maxProductSales = productSales[0];
            int maxProductIndex = 0;
            for (int i = 1; i < productSales.Length; i++)
            {
                if (productSales[i] > maxProductSales)
                {
                    maxProductSales = productSales[i];
                    maxProductIndex = i;
                }
            }
            Console.WriteLine($"\nƏn çox satan məhsul: {maxProductIndex + 1}. məhsul - {maxProductSales} satış ilə");

            Console.WriteLine("\n--- Günlük Toplam Satışlar ---");

            double[] dailySales = new double[7];
            for (int j = 0; j < 7; j++)
            {
                double sum = 0;
                for (int i = 0; i < 4; i++)
                {
                    sum += salesRaport[i, j];
                }
                dailySales[j] = sum;
                Console.WriteLine($"{j + 1}. günün toplam satışları: {dailySales[j]}");
            }
            double maxDailySales = dailySales[0];
            int maxDailyIndex = 0;
            for (int j = 1; j < dailySales.Length; j++)
            {
                if (dailySales[j] > maxDailySales)
                {
                    maxDailySales = dailySales[j];
                    maxDailyIndex = j;
                }
            }
            Console.WriteLine($"\nƏn çox satış olan gün: {maxDailyIndex + 1}. gün - {maxDailySales} satış ilə");
            Console.WriteLine("\nProqramı bitirmək üçün bir düyməyə basın...");
        }
    }
}
