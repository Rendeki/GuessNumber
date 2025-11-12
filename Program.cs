using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices.Marshalling;
namespace Lab_work2
    {
        class Program
        {

        static void Main(string[] args)
        {
            int playerInput;


            Console.WriteLine("Игра - отгадай ответ");
            bool isGameRun = true;
            while (isGameRun)
            {
                Console.WriteLine("Меню:\n 1.Отгадай ответ\n 2.Об авторе\n 3.Выход\n");
                Console.WriteLine("Введите число: ");
                while (!int.TryParse(Console.ReadLine(), out playerInput))
                {

                    Console.WriteLine("Ошибка ввода, введите число: ");
                }
                switch (playerInput)
                {
                    case 1:
                        bool isGuessRight = false;
                        double aVariable, bVariable, result, playerGuess;
                        int countGuess = 3;

                        Console.WriteLine("Введите A: ");
                        while (!double.TryParse(Console.ReadLine(), out aVariable))
                        {
                            Console.WriteLine("Ошибка ввода, повторите попытку ввода числа A");
                        }
                        Console.WriteLine("Введите B: ");
                        while (!double.TryParse(Console.ReadLine(), out bVariable))
                        {
                            Console.WriteLine("Ошибка ввода, повторите попытку ввода числа B");
                        }
                        result = Math_Alg(aVariable, bVariable);
                        if (result != -1)
                        {
                            result = Math.Round(result, 2);
                            Console.WriteLine($"Угадайте результат функции до двух знаков после запятой, количество попыток: {countGuess}");
                            while (isGuessRight == false && countGuess > 0)
                            {
                                Console.WriteLine("Введите результат функции по вашему предположению, количество оставшихся" +
                                    $" попыток: {countGuess}");
                                while (!double.TryParse(Console.ReadLine(), out playerGuess))
                                {
                                    Console.WriteLine("Ошибка ввода, введите вещественное число");
                                }
                                if (Math.Round(playerGuess, 2) == result)
                                {
                                    isGuessRight = true;
                                }
                                else
                                {
                                    countGuess--;
                                    Console.WriteLine("Ответ неверный");
                                }
                            }
                            if (isGuessRight)
                            {
                                Console.WriteLine("Вы угадали ответ, поздравляем с победой!\n");
                            }
                            else
                            {
                                Console.WriteLine($"Вы не угадали ответ. Правильный ответ: {result}\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Функция не определена при данных значения");
                        }
                        break;
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("Корчагин Сергей Павлович, группа: 6101-090301D\n");
                        break;
                    case 3:
                        Console.WriteLine("Вы уверены что желаете закрыть программу? (д/н)");
                        char exitInp;
                        bool tryExit = true;
                        while (tryExit)
                        {
                            while (!char.TryParse(Console.ReadLine(), out exitInp) && exitInp != 'д')
                            {
                                Console.WriteLine("Ошибка ввода, введите букву >д< или >н<");
                            }
                            switch (exitInp)
                            {
                                case 'д':
                                    tryExit = false;
                                    isGameRun = false;
                                    break;
                                case 'н':
                                    tryExit = false;
                                    Console.WriteLine();
                                    break;
                                default:
                                    Console.WriteLine("Ошибка ввода, попробуйте снова");
                                    break;
                            }
                        }
                        break;

                    default:
                        Console.WriteLine("Ошибка ввода, повторите попытку");
                        break;
                }
            }
        }
                static double Math_Alg(double a, double b)
                {
                    try
                    {
                        double resOfAlg = (Math.Pow(Math.Sin(a), 2) + Math.Pow(Math.Cos(b), 3)) /
                        (Math.Pow(Math.Sin(a), 3) - Math.Pow(Math.Cos(b), 2));
                        if (resOfAlg > 0)
                        {
                            return Math.Sqrt(resOfAlg);
                        }
                        else
                        {
                            Console.WriteLine("Отрицательное число под корнем");
                            return -1;
                        }
                    }
                    catch (DivideByZeroException)
                    {
                        Console.WriteLine("Деление на ноль");
                        return -1;
                }
            }
        }   
    }

/*          const double pNumber = Math.PI;
            const double eNumber = Math.E;

            Console.WriteLine("Нахождение значения функции через значения переменных A и B");
            Console.Write("Введите A: ");
            string strA = Console.ReadLine();
            double aVariable = double.Parse(strA);
            Console.Write("Введите B: ");
            string strB = Console.ReadLine();
            double bVariable = double.Parse(strB);

            double resultOfEquation = Math.Sqrt((Math.Pow(Math.Sin(aVariable), 2) + Math.Pow(Math.Cos(bVariable), 3)) /
                (Math.Pow(Math.Sin(aVariable), 3) - Math.Pow(Math.Cos(bVariable), 2)));
            Console.Write("Значение функции = ");   
            Console.WriteLine(Math.Round(resultOfEquation, 2));
        }
    }
}
*/





