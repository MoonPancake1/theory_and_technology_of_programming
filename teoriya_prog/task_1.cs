using System;

namespace teoriya_prog
{
    internal static class Tasks
    {
        public static void Main(string[] args)
        {
            Task5();
        }

        
        // Пятый номер
        private static void Task5()
        {
            int lengthStick; // Длина стержня
            int diameterOut; // Внешний диамтер
            int materialStick = 1; // Материал для изготовления
            int thicknessWall; // Толщина стенки
            double volumeStick; // Объём стержня
            double weightStick; // Вес стержня
            string weightStickUoM; // Единицы измерения стержня

            string[] materialName =
            {
                "Поликарбонат", "Стекло", "Алюминий", "Железо", "Сталь",
                "Латунь", "Бронза", "Медь"
            }; // Название материала
            float[] materialDensity = { 1.2f, 2.2f, 2.7f, 7.8f, 7.9f, 8.3f, 8.7f, 8.9f }; // Плотность материала

            string acceptNextCalculate = "Y"; // Необходима для плавного перехода от одного расчёта к другому

            while (materialStick != 0)
            {
                Console.Write("Введите длину стержня в миллиметрах >");
                lengthStick = Convert.ToInt16(Console.ReadLine());
                Console.Write("Введите внешний диаметр стержня в миллиметрах >");
                diameterOut = Convert.ToInt16(Console.ReadLine());
                Console.Write("Введите толщину стенки стержня в миллиметрах >");
                thicknessWall = Convert.ToInt16(Console.ReadLine());

                if (thicknessWall * 2 <= diameterOut)
                {
                    materialStick = Task5SelectMaterial(materialName, materialDensity);

                    if (materialStick != 0)
                    {
                        volumeStick =  Task5CalculateDataStick(diameterOut, thicknessWall, lengthStick);
                        
                        weightStick = volumeStick * materialDensity[materialStick - 1];
        
                        weightStickUoM = "гр";
                        if (weightStick > 1000)
                        {
                            weightStick = Math.Round(weightStick / 1000.00, 2);
                            weightStickUoM = "кг";
                        }
        
                        Console.WriteLine("\n===================================");
                        Console.WriteLine($"Длина стержня: {lengthStick} мм.");
                        Console.WriteLine($"Внешний диамтер стержня: {diameterOut} мм.");
                        Console.WriteLine($"Толщина стенки: {thicknessWall} мм.");
                        Console.WriteLine($"Объём стержня: {volumeStick:f2} см.куб.");
                        Console.WriteLine($"Материал: {materialName[materialStick - 1]}");
                        Console.WriteLine($"Плотность материала: {materialDensity[materialStick - 1]} гр./см.куб.");
                        Console.WriteLine($"Масса стержня: {weightStick:f2} {weightStickUoM}.");
                        Console.WriteLine("===================================\n");

                        Console.Write("Желаете ли вы продолжить работу с программой? (Y/N) >");
                        acceptNextCalculate = Console.ReadLine();
                    }

                    if (acceptNextCalculate == "N" || acceptNextCalculate == "n")
                    {
                        materialStick = 0;
                    }
                }

                else
                {
                    Console.WriteLine("\nВы ввели некорректные характеристики стержня!\n");
                }
            }
        }

        private static int Task5SelectMaterial(string[] materialName, float[] materialDensity)
        {
            int materialStick; // Материал для изготовления
            Console.WriteLine("\n==============================");
            Console.WriteLine($"Материалы для изготовления:");
            for (int i = 0; i < materialName.Length; i++)
            {
                Console.WriteLine($"{i+1}. {materialName[i]}: {materialDensity[i]} гр./см.куб.");
            }
            Console.WriteLine("\nДля завершения работы программы введите 0\n");
            Console.WriteLine("==============================\n");
            
            Console.Write("Введите номер материала >");
            try
            {
                materialStick = Convert.ToInt16(Console.ReadLine());
        
                if ((materialStick > materialName.Length || materialStick < 1) && materialStick != 0)
                {
                    Console.WriteLine($"[ERROR]: Вы не можете выбрать такой материал. Введите значение от 1 до {materialName.Length}!");
                    materialStick = Task4SelectMaterial(materialName, materialDensity);
                }
                else if (materialStick == 0)
                {
                    return materialStick;
                }
            }
            catch (FormatException e)
            {
                materialStick = 0;
                Console.WriteLine($"[ERROR]: {e.Message}");
            }

            return materialStick;
        }

        private static double Task5CalculateDataStick(int diameterOut, int thicknessWall, int lengthStick)
        {
            double volumeStick; // Объём стержня
            
            volumeStick = Math.PI * (Math.Pow(diameterOut, 2) - Math.Pow((diameterOut - 2 * thicknessWall), 2)) / 4 *
                lengthStick / 1000;

            return volumeStick;
        }
        
        
        
        // Четвёртый номер
        private static void Task4()
        {
            int lengthStick; // Длина стержня
            int diameterOut; // Внешний диамтер
            int materialStick = 1; // Материал для изготовления
            int thicknessWall; // Толщина стенкиd
            
            string[] materialName = {"Поликарбонат", "Стекло", "Алюминий", "Железо", "Сталь", 
                "Латунь", "Бронза", "Медь"}; // Название материала
            float[] materialDensity = {1.2f, 2.2f, 2.7f, 7.8f, 7.9f, 8.3f, 8.7f, 8.9f}; // Плотность материала
            
            string acceptNextCalculate = "Y"; // Необходима для плавного перехода от одного расчёта к другому
            
            while (materialStick != 0)
            {
                Console.Write("Введите длину стержня в миллиметрах >");
                lengthStick = Convert.ToInt16(Console.ReadLine());
                Console.Write("Введите внешний диаметр стержня в миллиметрах >");
                diameterOut = Convert.ToInt16(Console.ReadLine());
                Console.Write("Введите толщину стенки стержня в миллиметрах >");
                thicknessWall = Convert.ToInt16(Console.ReadLine());

                if (thicknessWall * 2 <= diameterOut)
                {
                    materialStick = Task4SelectMaterial(materialName, materialDensity);
                    
                    if (materialStick != 0)
                    {
                        Task4CalculateDataStick(diameterOut, thicknessWall, lengthStick, 
                            materialDensity[materialStick - 1], materialName[materialStick - 1]);

                        Console.Write("Желаете ли вы продолжить работу с программой? (Y/N) >");
                        acceptNextCalculate = Console.ReadLine();
                    }

                    if (acceptNextCalculate == "N" || acceptNextCalculate == "n")
                    {
                        materialStick = 0;
                    }
                }
                
                else
                {
                    Console.WriteLine("\nВы ввели некорректные характеристики стержня!\n");
                }
            }
        }
            
        private static int Task4SelectMaterial(string[] materialName, float[] materialDensity)
        {
            int materialStick; // Материал для изготовления
            Console.WriteLine("\n==============================");
            Console.WriteLine($"Материалы для изготовления:");
            for (int i = 0; i < materialName.Length; i++)
            {
                Console.WriteLine($"{i+1}. {materialName[i]}: {materialDensity[i]} гр./см.куб.");
            }
            Console.WriteLine("\nДля завершения работы программы введите 0\n");
            Console.WriteLine("==============================\n");
            
            Console.Write("Введите номер материала >");
            try
            {
                materialStick = Convert.ToInt16(Console.ReadLine());
        
                if ((materialStick > materialName.Length || materialStick < 1) && materialStick != 0)
                {
                    Console.WriteLine($"[ERROR]: Вы не можете выбрать такой материал. Введите значение от 1 до {materialName.Length}!");
                    materialStick = Task4SelectMaterial(materialName, materialDensity);
                }
                else if (materialStick == 0)
                {
                    return materialStick;
                }
            }
            catch (FormatException e)
            {
                materialStick = 0;
                Console.WriteLine($"[ERROR]: {e.Message}");
            }

            return materialStick;
        }

        private static void Task4CalculateDataStick(int diameterOut, int thicknessWall, int lengthStick,
            float materialDensity, string materialName)
        {
            double volumeStick; // Объём стержня
            double weightStick; // Вес стержня
            string weightStickUoM; // Единицы измерения стержня
            
            volumeStick = Math.PI * (Math.Pow(diameterOut, 2) - Math.Pow((diameterOut - 2 * thicknessWall), 2)) / 4 *
                lengthStick / 1000;

            weightStick = volumeStick * materialDensity;
        
            weightStickUoM = "гр";
            if (weightStick > 1000)
            {
                weightStick = Math.Round(weightStick / 1000.00, 2);
                weightStickUoM = "кг";
            }
        
            Console.WriteLine("\n===================================");
            Console.WriteLine($"Длина стержня: {lengthStick} мм.");
            Console.WriteLine($"Внешний диамтер стержня: {diameterOut} мм.");
            Console.WriteLine($"Толщина стенки: {thicknessWall} мм.");
            Console.WriteLine($"Объём стержня: {volumeStick:f2} см.куб.");
            Console.WriteLine($"Материал: {materialName}");
            Console.WriteLine($"Плотность материала: {materialDensity} гр./см.куб.");
            Console.WriteLine($"Масса стержня: {weightStick:f2} {weightStickUoM}.");
            Console.WriteLine("===================================");
        }
        
        
        // Третий номер
        private static void Task3()
        {
            int lengthStick; // Длина стержня
            int diameterOut; // Внешний диамтер
            int materialStick = 1; // Материал для изготовления
            int thicknessWall; // Толщина стенкиd

            string materialName; // Название материала
            float materialDensity; // Плотность материала
            
            string acceptNextCalculate = "Y"; // Необходима для плавного перехода от одного расчёта к другому
            
            while (materialStick != 0)
            {
                Console.Write("Введите длину стержня в миллиметрах >");
                lengthStick = Convert.ToInt16(Console.ReadLine());
                Console.Write("Введите внешний диаметр стержня в миллиметрах >");
                diameterOut = Convert.ToInt16(Console.ReadLine());
                Console.Write("Введите толщину стенки стержня в миллиметрах >");
                thicknessWall = Convert.ToInt16(Console.ReadLine());

                if (thicknessWall * 2 <= diameterOut)
                {
                    materialStick = Task3SelectMaterial();
                    switch (materialStick)
                    {
                        
                        case 1:
                            materialName = "Алюминий";
                            materialDensity = 2.7f;
                            break;
                        
                        case 2:
                            materialName = "Железо";
                            materialDensity = 7.8f;
                            break;
                        
                        case 3:
                            materialName = "Сталь";
                            materialDensity = 7.9f;
                            break;
                        
                        case 4:
                            materialName = "Латунь";
                            materialDensity = 8.3f;
                            break;
                        
                        case 5:
                            materialName = "Бронза";
                            materialDensity = 8.7f;
                            break;
                        
                        case 6:
                            materialName = "Медь";
                            materialDensity = 8.9f;
                            break;
                        
                        default:
                            materialName = "Алюминий";
                            materialDensity = 2.7f;
                            break;
                        
                    }
                    if (materialStick != 0)
                    {
                        Task3CalculateDataStick(diameterOut, thicknessWall, lengthStick, materialDensity, materialName);

                        Console.Write("Желаете ли вы продолжить работу с программой? (Y/N) >");
                        acceptNextCalculate = Console.ReadLine();
                    }

                    if (acceptNextCalculate == "N" || acceptNextCalculate == "n")
                    {
                        materialStick = 0;
                    }
                }
                
                else
                {
                    Console.WriteLine("\nВы ввели некорректные характеристики стержня!\n");
                }
            }
        }

        private static void Task3CalculateDataStick(double diameterOut, int thicknessWall, int lengthStick, 
            float materialDensity, string materialName)
        {
            double volumeStick; // Объём стержня
            double weightStick; // Вес стержня
            string weightStickUoM; // Единицы измерения стержня
            
            volumeStick = Math.PI * (Math.Pow(diameterOut, 2) - Math.Pow((diameterOut - 2 * thicknessWall), 2)) / 4 *
                lengthStick / 1000;

            weightStick = volumeStick * materialDensity;
        
            weightStickUoM = "гр";
            if (weightStick > 1000)
            {
                weightStick = Math.Round(weightStick / 1000.00, 2);
                weightStickUoM = "кг";
            }
        
            Console.WriteLine("\n===================================");
            Console.WriteLine($"Длина стержня: {lengthStick} мм.");
            Console.WriteLine($"Внешний диамтер стержня: {diameterOut} мм.");
            Console.WriteLine($"Толщина стенки: {thicknessWall} мм.");
            Console.WriteLine($"Объём стержня: {volumeStick:f2} см.куб.");
            Console.WriteLine($"Материал: {materialName}");
            Console.WriteLine($"Плотность материала: {materialDensity} гр./см.куб.");
            Console.WriteLine($"Масса стержня: {weightStick:f2} {weightStickUoM}.");
            Console.WriteLine("===================================");
        }

        private static int Task3SelectMaterial()
        {
            int materialStick; // Материал для изготовления
            Console.WriteLine("\n==============================");
            Console.WriteLine($"Материалы для изготовления:");
            Console.WriteLine("1. Алюминий: 2.7 гр./см.куб.");
            Console.WriteLine("2. Железо: 7.8 гр./см.куб.");
            Console.WriteLine("3. Сталь: 7.9 гр./см.куб.");
            Console.WriteLine("4. Латунь: 8.3 гр./см.куб.");
            Console.WriteLine("5. Бронза: 8.7 гр./см.куб.");
            Console.WriteLine("6. Медь: 8.9 гр./см.куб.");
            Console.WriteLine("\nДля завершения работы программы введите 0\n");
            Console.WriteLine("==============================");
            
            Console.Write("Введите номер материала >");
            try
            {
                materialStick = Convert.ToInt16(Console.ReadLine());
        
                if ((materialStick > 6 || materialStick < 1) && materialStick != 0)
                {
                    Console.WriteLine($"[ERROR]: Вы не можете выбрать такой материал. Введите значение от 1 до 6!");
                    materialStick = Task3SelectMaterial();
                }
                else if (materialStick == 0)
                {
                    return materialStick;
                }
            }
            catch (FormatException e)
            {
                materialStick = 0;
                Console.WriteLine($"[ERROR]: {e.Message}");
            }

            return materialStick;
        }
        
        
        // Второй номер
        private static void Task2()
        {
            int lengthStick; // Длина стержня
            int diameterOut; // Внешний диамтер
            int materialStick = 0; // Материал для изготовления
            int thicknessWall; // Толщина стенки
            double weightStick; // Вес стержня
            double volumeStick; // Объём стержня
            double materialDensity = 0; // Плотность материалла
            string weightStickUoM; // Единицы измерения стержня
            string materialName = null; // Название материала
            
            Console.Write("Введите длину стержня в миллиметрах >");
            lengthStick = Convert.ToInt16(Console.ReadLine());
            Console.Write("Введите внешний диаметр стержня в миллиметрах >");
            diameterOut = Convert.ToInt16(Console.ReadLine());
            Console.Write("Введите толщину стенки стержня в миллиметрах >");
            thicknessWall = Convert.ToInt16(Console.ReadLine());
            
            volumeStick = Math.PI * (Math.Pow(diameterOut, 2) - Math.Pow((diameterOut - 2 * thicknessWall), 2)) / 4 *
                lengthStick / 1000;

            if (materialStick < 1 || materialStick > 4)
            {
                materialStick = Task2SelectMaterial();

                switch (materialStick)
                {
                    case 1:
                        materialName = "Алюминий";
                        materialDensity = 2.7;    
                        break;
                    
                    case 2:
                        materialName = "Железо";
                        materialDensity = 7.8;
                        break;
                    
                    case 3:
                        materialName = "Сталь";
                        materialDensity = 7.9;
                        break;
                    
                    case 4:
                        materialName = "Медь";
                        materialDensity = 8.9;
                        break;
                    
                    default:
                        // Значение по умолчанию не будет отрабатывать, т.к. у нас гарантировано будет целое число от 
                        // 1 до 4 включительно
                        materialName = "Алюминий";
                        materialDensity = 2.7;
                        break;
                }
                
                weightStick = volumeStick * materialDensity;
            
                weightStickUoM = "гр";
                if (weightStick > 1000)
                {
                    weightStick = Math.Round(weightStick / 1000.00, 2);
                    weightStickUoM = "кг";
                }
            
                Console.WriteLine("\n===================================");
                Console.WriteLine($"Длина стержня: {lengthStick} мм.");
                Console.WriteLine($"Внешний диамтер стержня: {diameterOut} мм.");
                Console.WriteLine($"Толщина стенки: {thicknessWall} мм.");
                Console.WriteLine($"Объём стержня: {volumeStick:f2} см.куб.");
                Console.WriteLine($"Материал: {materialName}");
                Console.WriteLine($"Плотность материала: {materialDensity} гр./см.куб.");
                Console.WriteLine($"Масса стержня: {weightStick:f2} {weightStickUoM}.");
                Console.WriteLine("===================================");
            }
            
        }

        private static int Task2SelectMaterial()
        {
            int materialStick; // Материал для изготовления
            Console.WriteLine("\n==============================");
            Console.WriteLine($"Материалы для изготовления:");
            Console.WriteLine($"1. Алюминий: 2.7 гр./см.куб.");
            Console.WriteLine($"2. Железо: 7.8 гр./см.куб.");
            Console.WriteLine($"3. Сталь: 7.9 гр./см.куб.");
            Console.WriteLine($"4. Медь: 8.9 гр./см.куб.");
            Console.WriteLine("==============================");
            
            Console.Write("Введите номер материала >");
            materialStick = Convert.ToInt16(Console.ReadLine());
        
            if (materialStick > 4 || materialStick < 1)
            {
                throw new Exception("Вы не можете выбрать такой материал. Введите значение от 1 до 4!");
            }

            return materialStick;
        }
        
        
        // Первый номер
        private static void Task1()
        {
            const double pi = 3.141592; 
            Console.WriteLine("Введите внешний радиус стержня в миллиметрах: ");
            var radiusOut = double.Parse(Console.ReadLine() ?? string.Empty); // Внешний радиус 
            Console.WriteLine("Введите внутренний радиус стержня в миллиметрах: ");
            var radiusIn = double.Parse(Console.ReadLine() ?? string.Empty); // Внутренний радиус
            if (radiusOut < radiusIn)
            {
                throw new Exception("Внешний радиус не может быть меньше внутреннего!");
            }
            Console.WriteLine("Введите длину стержня в миллиметрах: ");
            var lengthStick = int.Parse(Console.ReadLine() ?? string.Empty); // Длина стержня
            Console.WriteLine("Введите плотность материала в гр./см.куб.: ");
            var densityStick = double.Parse(Console.ReadLine() ?? string.Empty); // Плотность материала
            
            // Объём стержня
            var volumeStick = pi * lengthStick * (Math.Pow(radiusOut, 2) - Math.Pow(radiusIn, 2)) / 1_000.00;
            volumeStick = Math.Round(volumeStick, 2);
            
            // Масса стержня
            var weightStick = volumeStick * densityStick;
            weightStick = Math.Round(weightStick, 2);
            string weightStickUoM = "гр";
            if (weightStick > 1000)
            {
                weightStick = Math.Round(weightStick / 1000.00, 2);
                weightStickUoM = "кг";
            }
            
            Console.WriteLine("\n===================================");
            Console.WriteLine($"Внешний радиус стержня: {radiusOut} мм.");
            Console.WriteLine($"Внутренний радиус стержня: {radiusIn} мм.");
            Console.WriteLine($"Длина стержня: {lengthStick} мм.");
            Console.WriteLine($"Объём стержня: {volumeStick} см.куб.");
            Console.WriteLine($"Плотность материала: {densityStick} гр./см.куб.");
            Console.WriteLine($"Масса стержня: {weightStick} {weightStickUoM}.");
            Console.WriteLine("===================================");
        }
        
    }
}