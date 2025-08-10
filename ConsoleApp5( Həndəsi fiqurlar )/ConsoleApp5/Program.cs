namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int selectMainMenuOption;
            bool isMainMenu = true;
            do
            {
                Console.WriteLine("ƏSAS MENYU");
                Console.WriteLine("1.Sahənin hesablanması");
                Console.WriteLine("2.Perimetr hesablanması");
                Console.WriteLine("3.Çıxış");
                Console.Write("Rəqəm daxil edin:");
                selectMainMenuOption = int.Parse(Console.ReadLine());

                if (selectMainMenuOption == 1 || selectMainMenuOption == 2)
                {
                    bool isSubMenu = true;
                    do
                    {
                        if (selectMainMenuOption == 1)
                        {
                            Console.WriteLine("Sahənin hesablanması üçün 1-dən 5-ə qədər rəqəm daxil edin:\n" +
                                "1.Kvadrat\n" +
                                "2.Düzbucaqlı\n" +
                                "3.Üçbucaq\n" +
                                "4.Çevrə\n" +
                                "5.Əsas Menyu");
                            int shapeChoice = int.Parse(Console.ReadLine());
                            switch (shapeChoice)
                            {
                                case 1:
                                    Console.Write("Kvadratın tərəfini daxil edin: ");
                                    double side = double.Parse(Console.ReadLine());
                                    double squareArea = side * side;
                                    Console.WriteLine($"Kvadratın sahəsi: {squareArea}");
                                    break;
                                case 2:
                                    Console.Write("Düzbucaqlının uzunluğunu daxil edin: ");
                                    double length = Convert.ToDouble(Console.ReadLine());
                                    Console.Write("Düzbucaqlının enini daxil edin: ");
                                    double width = Convert.ToDouble(Console.ReadLine());
                                    double rectangleArea = length * width;
                                    Console.WriteLine($"Düzbucaqlının sahəsi: {rectangleArea}");
                                    break;
                                case 3:
                                    Console.Write("Üçbucağın əsasını daxil edin: ");
                                    double baseLength = Convert.ToDouble(Console.ReadLine());
                                    Console.Write("Üçbucağın hündürlüyünü daxil edin: ");
                                    double height = Convert.ToDouble(Console.ReadLine());
                                    double triangleArea = 0.5 * baseLength * height;
                                    Console.WriteLine($"Üçbucağın sahəsi: {triangleArea}");
                                    break;
                                case 4:
                                    Console.Write("Çevrənin radiusunu daxil edin: ");
                                    double radius = Convert.ToDouble(Console.ReadLine());
                                    double circleArea = Math.PI * radius * radius;
                                    Console.WriteLine($"Çevrənin sahəsi: {circleArea}");
                                    break;
                                case 5:
                                    isSubMenu = false;
                                    break;
                                default:
                                    Console.WriteLine("Yanlış seçim, yenidən cəhd edin.");
                                    break;
                            }
                        }
                        else if (selectMainMenuOption == 2)
                        {
                            Console.WriteLine("Perimetrin hesablanması üçün 1-dən 5-ə qədər rəqəm daxil edin:\n" +
                                "1.Kvadrat\n" +
                                "2.Düzbucaqlı\n" +
                                "3.Üçbucaq\n" +
                                "4.Çevrə\n" +
                                "5.Əsas Menyu");
                            int perimeterChoice = Convert.ToInt32(Console.ReadLine());
                            switch (perimeterChoice)
                            {
                                case 1:
                                    Console.Write("Kvadratın tərəfini daxil edin: ");
                                    double side = Convert.ToDouble(Console.ReadLine());
                                    double squarePerimeter = 4 * side;
                                    Console.WriteLine($"Kvadratın perimetri: {squarePerimeter}");
                                    break;
                                case 2:
                                    Console.Write("Düzbucaqlının uzunluğunu daxil edin: ");
                                    double length = Convert.ToDouble(Console.ReadLine());
                                    Console.Write("Düzbucaqlının enini daxil edin: ");
                                    double width = Convert.ToDouble(Console.ReadLine());
                                    double rectanglePerimeter = 2 * (length + width);
                                    Console.WriteLine($"Düzbucaqlının perimetri: {rectanglePerimeter}");
                                    break;
                                case 3:
                                    Console.Write("Üçbucağın birinci tərəfini daxil edin: ");
                                    double side1 = Convert.ToDouble(Console.ReadLine());
                                    Console.Write("Üçbucağın ikinci tərəfini daxil edin: ");
                                    double side2 = Convert.ToDouble(Console.ReadLine());
                                    Console.Write("Üçbucağın üçüncü tərəfini daxil edin: ");
                                    double side3 = Convert.ToDouble(Console.ReadLine());
                                    double trianglePerimeter = side1 + side2 + side3;
                                    Console.WriteLine($"Üçbucağın perimetri: {trianglePerimeter}");
                                    break;
                                case 4:
                                    Console.Write("Çevrənin radiusunu daxil edin: ");
                                    double radius = Convert.ToDouble(Console.ReadLine());
                                    double circlePerimeter = 2 * Math.PI * radius;
                                    Console.WriteLine($"Çevrənin perimetri: {circlePerimeter}");
                                    break;
                                case 5:
                                    isSubMenu = false;
                                    break;
                                default:
                                    Console.WriteLine("Yanlış seçim, yenidən cəhd edin.");
                                    break;
                            }
                        }
                    }
                    while (isSubMenu);
                }
                else if (selectMainMenuOption == 3)
                {
                    Console.WriteLine("Proqramdan çıxmağa əminsiniz ?(h/y)");
                    char exitChoice = char.Parse(Console.ReadLine().ToLower());
                    if (exitChoice == 'h')
                    {
                        isMainMenu = false;
                        Console.WriteLine("Proqramdan çıxılır...");
                    }

                }


            } while (isMainMenu);
        }
    }
}
