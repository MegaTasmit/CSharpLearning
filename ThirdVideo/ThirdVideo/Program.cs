// See https://aka.ms/new-console-template for more information


Console.WriteLine("Есть два исхода:\n1 - Просмотреть телефонный справочник\n2 - Сыграть в БлэкДжек");
string userChoice = Console.ReadLine();
switch (userChoice)
{
    #region Телефонный справочник
    case "1": // Телефонная книжка

        bool isEnd = true;
        string[] phoneBook = new string[150];

        phoneBook[0] = "Имя1 - 64568451";
        phoneBook[1] = "Имя2 - 64568451";
        phoneBook[2] = "Имя3 - 64568451";
        phoneBook[3] = "Имя4 - 64568451";
        phoneBook[4] = "Имя5 - 64568451";


        while (isEnd)
        {
            Thread.Sleep(750);
            Console.Clear();
            Console.SetCursorPosition(0, 20);
            for (int i = 0; i < phoneBook.Length; i++)
            {
                if (phoneBook[i] == null)
                    break;

                Console.WriteLine((i + 1) + ". " + phoneBook[i]);
            }
            Console.SetCursorPosition(0, 0);

            Console.WriteLine($"Чего изволите?\n" +
                              $"1 - Показать список контактов\n" +
                              $"2 - Добавить новый контакт\n" +
                              $"3 - Удалить контакт\n" +
                              $"0 - Выход");

            switch (Console.ReadLine())
            {
                case "1": // Показать список контактов

                    for (int i = 0; i < phoneBook.Length; i++)
                    {
                        if (phoneBook[i] == null)
                            break;

                        Console.WriteLine((i + 1) + ". " + phoneBook[i]);
                    }

                    Console.WriteLine("Нажмите любую кнопку для продолжения");
                    Console.ReadKey();
                    break;

                case "2": // Добавить контакт

                    Console.Write("Введите новый контакт: ");
                    string newContact = Console.ReadLine();

                    for (int i = 0; i < phoneBook.Length; i++)
                    {
                        if (phoneBook[i] == null)
                        {
                            phoneBook[i] = newContact;
                            break;
                        }
                    }

                    Console.WriteLine("Контакт успешно добавлен!");
                    break;

                case "3": // Удалить контакт

                    Console.Write("Введите номер контакта, который Вы хотите удалить: ");
                    bool isSuccess = int.TryParse(Console.ReadLine(), out int userInput);

                    if (!isSuccess)
                    {
                        Console.WriteLine(" Некорректный ввод!");
                        break;
                    }
                    else
                    {
                        phoneBook[userInput] = null;
                    }

                    for (int i = 0; i < phoneBook.Length; i++)
                    {
                        if (phoneBook[i] == null && phoneBook[i + 1] != null)
                        {
                            (phoneBook[i], phoneBook[i + 1]) = (phoneBook[i + 1], phoneBook[i]);
                        }
                        else if (phoneBook[i] == null && phoneBook[i + 1] == null)
                        {
                            break;
                        }
                    }

                    break;

                case "0": // Выход
                    isEnd = false;
                    Console.WriteLine("Ждем Вас снова!");
                    break;

                default:

                    Console.WriteLine("Команда не существует!");
                    break;
            }
        }

        break;
    #endregion

    #region Самопальный блэкджек чисто на рандоме =)

    case "2": // Первоначальный вариант решения, когда только услышал, что делаем BlackJack
        Console.Clear();
        
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
        break;

    #endregion

    default:

        Console.WriteLine("Ах, каков хитрец! Нет такого варианта =)");
        break;
}


// BlackJack - первый вариант реализации, когда услышал задание


