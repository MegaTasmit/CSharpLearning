using System;

namespace FourthVideo
{
    public static class Programm
    {
        public static void Main(string[] args)
        {
            decimal savedNumber = 0;
            bool isEnd = false;

            while (isEnd == false)
            {
                decimal firstNumber = 0;
                string operation = "";
                decimal secondNumber = 0;

                bool correctFirstNumber = false;
                bool correctSecondNumber = true;

                Console.Clear();
                MainInfo(savedNumber);

                if (savedNumber != 0)
                {
                    firstNumber = savedNumber;
                    correctFirstNumber = true;
                }
                else
                {
                    Console.WriteLine("Введите первое число:");
                    correctFirstNumber = decimal.TryParse(Console.ReadLine(), out firstNumber);
                }

                Console.WriteLine("Введите действие");
                operation = Console.ReadLine();

                if (operation.ToLower() != "x" && operation.ToLower() != "y")
                {
                    Console.WriteLine("Введите второе число");
                    correctSecondNumber = decimal.TryParse(Console.ReadLine(), out secondNumber);
                }
                else if (operation.ToLower() != "y")
                { 
                    savedNumber = 0; 
                }

                bool isNumbersCorrect = correctFirstNumber && correctSecondNumber;

                if (isNumbersCorrect == true)
                {

                    switch (operation.ToLower())
                    {
                        case "+":
                            Sum(firstNumber, secondNumber, out savedNumber);
                            break;

                        case "-":
                            Minus(firstNumber, secondNumber, out savedNumber);
                            break;

                        case "*":
                            Multiply(firstNumber, secondNumber, out savedNumber);
                            break;

                        case "/":
                            Divide(firstNumber, secondNumber, out savedNumber);
                            break;

                        case "y":
                            isEnd = true;
                            Console.WriteLine("Благодарим Вас за использование нашего калькулятора!");
                            Thread.Sleep(1000);
                            break;

                        case "x":
                            Console.WriteLine("Сохраненное число обнулено");
                            Thread.Sleep(700);
                            break;

                        default:
                            Console.WriteLine("Некорректная математическая операция!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Укажите корректные числа!");
                }
            }
        }

        public static void Sum(decimal x, decimal y, out decimal savedNumber)
        {
            decimal result = x + y;
            Console.WriteLine("\nОтвет: " + result);

            SaveAndEnd(result, out savedNumber);
        }

        public static void Minus(decimal x, decimal y, out decimal savedNumber)
        {
            decimal result = x - y;
            Console.WriteLine("\nОтвет: " + result);

            SaveAndEnd(result, out savedNumber);
        }

        public static void Multiply(decimal x, decimal y, out decimal savedNumber)
        {
            decimal result = x * y;
            Console.WriteLine("\nОтвет: " + result);

            SaveAndEnd(result, out savedNumber);
        }

        public static void Divide(decimal x, decimal y, out decimal savedNumber)
        {
            decimal result = x;

            if (y != 0)
            {
                result = x / y;
                Console.WriteLine("\nОтвет: " + result);
            }
            else
            {
                Console.WriteLine("На ноль делить нельзя!");
            }

            SaveAndEnd(result, out savedNumber);
        }

        public static void MainInfo(decimal savedNumber)
        {
            Console.SetCursorPosition(5, 0);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Калькулятор");

            Console.SetCursorPosition(50, 0);
            Console.Write("Текущий результат: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(savedNumber);

            Console.SetCursorPosition(50, 1);
            Console.Write("x - сбросить число");

            Console.SetCursorPosition(50, 2);
            Console.Write("у - Выход");

            Console.SetCursorPosition(0, 2);
        }

        public static decimal SaveAndEnd(decimal result, out decimal savedNumber)
        {
            savedNumber = result;

            Console.WriteLine("\nДля продолжения нажмите любую кнопку");
            Console.ReadKey();

            return savedNumber;
        }
    }
}
