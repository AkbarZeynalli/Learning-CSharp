namespace Vurma_Cədvəli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vurma cədvəli");

            int size = 10; 

            for (int i = 1; i <= size; i++)
            {
                for (int j = 1; j <= size; j++)
                {
                    Console.Write((i * j) + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
