using System;

namespace BlackJack_Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool isThatsAll = false;

            while (!isThatsAll)
            {
                Random random = new Random();

                int playerScore = 0;
                int computerScore = 0;
                bool isGameEnd = false;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Добро пожаловать в казино!\n");
                Console.ForegroundColor = ConsoleColor.White;

                // Computer logic
                computerScore += random.Next(2, 12);
                computerScore += random.Next(2, 12);
                while (computerScore < 16)
                    computerScore += random.Next(2, 12);

                //player
                playerScore += random.Next(2, 12);
                playerScore += random.Next(2, 12);
                while (!isGameEnd)
                {
                    Console.WriteLine($"\nВаш счет: {playerScore}");
                    Console.WriteLine("Желаете взять еще карту?   1 - да, 2 - нет");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            playerScore += random.Next(2, 12);
                            break;
                        case "2":
                            isGameEnd = true;
                            break;
                        default:
                            Console.WriteLine("Некорректный ввод!");
                            break;
                    }
                    if (playerScore > 21)
                    {
                        isGameEnd = true;
                    }
                }

                Console.WriteLine($"\n===================================\n\nВаш счет: {playerScore}");
                Console.WriteLine($"Счет Вашего оппонента {computerScore}\n");

                if (playerScore == computerScore || (computerScore > 21 && playerScore > 21))
                    Console.WriteLine("Ничья!");
                else if (playerScore > computerScore && playerScore < 22 || playerScore < computerScore && computerScore > 22)
                    Console.WriteLine("Вы победили!");
                else if (playerScore < computerScore && computerScore < 22 || playerScore > computerScore && playerScore > 22)
                    Console.WriteLine("Вы проиграли...");

                Console.WriteLine("\nСыграть еще?   1 - да, 2 - нет");
                switch (Console.ReadLine())
                {
                    case "1":
                        playerScore = 0;
                        computerScore = 0;
                        isGameEnd = false;
                        Console.Clear();
                        break;
                    case "2":
                        Console.WriteLine("Спасибо за игру!");
                        isThatsAll = true;
                        Thread.Sleep(1000);
                        return;
                    default:
                        Console.WriteLine("Некорректный ввод!");
                        break;
                }
            }
        }
    }
}
        


