using System;

namespace ContactBook_v1
{
    public class Programm
    {
        public static void Main(string[] args)
        {
            bool isContinue = true;
            string[] contactBook = new string[150];

            contactBook[0] = "Имя1 - 64568451";
            contactBook[1] = "Имя2 - 64568451";
            contactBook[2] = "Имя3 - 64568451";
            contactBook[3] = "Имя4 - 64568451";
            contactBook[4] = "Имя5 - 64568451";


            while (isContinue)
            {
                Thread.Sleep(750);
                Console.Clear();

                Console.WriteLine($"Чего изволите?\n" +
                                  $"1 - Показать список контактов\n" +
                                  $"2 - Добавить новый контакт\n" +
                                  $"3 - Удалить контакт\n" +
                                  $"0 - Выход");

                string userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1": // Показать список контактов

                        for (int i = 0; i < contactBook.Length; i++)
                        {
                            if (contactBook[i] == null)
                                break;

                            Console.WriteLine((i + 1) + ". " + contactBook[i]);
                        }

                        Console.WriteLine("Нажмите любую кнопку для продолжения");
                        Console.ReadKey();
                        break;

                    case "2": // Добавить контакт

                        Console.Write("Введите новый контакт: ");
                        string newContact = Console.ReadLine();

                        for (int i = 0; i < contactBook.Length; i++)
                        {
                            if (contactBook[i] == null)
                            {
                                contactBook[i] = newContact;
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
                            Console.WriteLine("Некорректный ввод!");
                            break;
                        }
                        else
                        {
                            contactBook[userInput] = null;
                        }

                        for (int i = 0; i < contactBook.Length; i++)
                        {
                            if (contactBook[i] == null && contactBook[i + 1] != null)
                            {
                                (contactBook[i], contactBook[i + 1]) = (contactBook[i + 1], contactBook[i]);
                            }
                            else if (contactBook[i] == null && contactBook[i + 1] == null)
                            {
                                break;
                            }
                        }

                        break;

                    case "0": // Выход
                        isContinue = false;
                        Console.WriteLine("Ждем Вас снова!");
                        break;

                    default:

                        Console.WriteLine("Такой команды нет! Вы ввели: " + userChoice);
                        break;
                }
            }
        }
    }
}