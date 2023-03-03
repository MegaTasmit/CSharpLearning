using System;

namespace FifthVideo
{
    public class Programm
    {
        private static ContactsList _contactsLists;

        public static void Main(string[] args)
        {
            Welcome();

            _contactsLists = new ContactsList(100);
            bool isEnd = false;

            while (isEnd == false)
            {
                Thread.Sleep(800);
                Console.Clear();

                MainInfo(_contactsLists.GetContactsCount());

                Console.WriteLine($"Выберите действие:\n" +
                                  $"1 - Показать все контакты\n" +
                                  $"2 - Добавить новый контакт\n" +
                                  $"3 - Редактировать контакт\n" +
                                  $"4 - Удалить контакт\n" +
                                  $"0 - Закрыть приложение");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case Operation.SHOW_ALL_CONTACTS:
                        ShowContacts();

                        Console.WriteLine("\nДля продолжения нажмите любую кнопку");
                        Console.ReadKey();

                        break;

                    case Operation.ADD_NEW_CONTACT:
                        AddNewContact();
                        break;

                    case Operation.EDIT_CONTACT:
                        EditContact();
                        break;

                    case Operation.DELETE_CONTACT:
                        userInput = DeleteContact();
                        break;

                    case Operation.EXIT:
                        isEnd = true;
                        Console.WriteLine("Благодарим за пользование приложением");
                        break;

                    default:

                        Console.WriteLine("Некорректная команда!");
                        break;

                }
            }
        }

        private static void ShowContacts()
        {
            Contact[] contacts = _contactsLists.GetContacts();

            for (int i = 0; i < contacts.Length; i++)
            {
                int ordinaryNumber = i + 1;
                Console.WriteLine($"\n{ordinaryNumber}\n" +
                                  $"Имя: {contacts[i].Name}\n" +
                                  $"Номер телефона: {contacts[i].PhoneNumber}\n" +
                                  $"Где проживает: {contacts[i].Address}");
            }
        }

        private static void AddNewContact()
        {
            Console.Write("\nВведите имя: ");
            string name = Console.ReadLine();

            Console.Write("\nВведите номер телефона: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("\nВведите город проживания: ");
            string adress = Console.ReadLine();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(adress))
            {
                Console.WriteLine("Вы ввели некорректное значение! Добавить такой контакт невозможно");
            }
            else
            {
                Contact contact = new Contact(name, phoneNumber, adress);
                _contactsLists.AddContact(contact);

                Console.WriteLine("Контакт добавлен!");
            }
        }

        private static string EditContact()
        {
            ShowContacts();

            Console.WriteLine("\nКакой контакт Вы хотите изменить?");
            string userInput = Console.ReadLine();

            bool isNumberCorrect = int.TryParse(userInput, out int userChoice);
            userChoice -= 1;
            if (isNumberCorrect == true && userChoice >= 0 && userChoice < _contactsLists.GetContactsCount())
            {
                Contact[] contact = _contactsLists.GetContacts();

                Console.Write("\nУкажите новое имя: ");
                string name = Console.ReadLine();

                Console.Write("\nУкажите новый номер телефона: ");
                string phoneNumber = Console.ReadLine();

                Console.Write("\nУкажите новый адрес: ");
                string adress = Console.ReadLine();

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(adress))
                {
                    Console.WriteLine("Вы ввели некорректное значение! Внести такие корректировки невозможно");
                }
                else
                {
                    contact[userChoice].Name = name;
                    contact[userChoice].PhoneNumber = phoneNumber;
                    contact[userChoice].Address = adress;

                    Console.WriteLine("Контакт успешно отредактирован!");
                }
            }
            else
            {
                Console.WriteLine("\nУказан некорректный номер контакта.");
            }

            return userInput;
        }

        private static string DeleteContact()
        {
            string userInput;
            ShowContacts();

            Console.Write("\nКакой контакт Вы хотите удалить?");
            userInput = Console.ReadLine();

            bool isNumberCorrect = int.TryParse(userInput, out int contactIndex);
            contactIndex -= 1;

            if (isNumberCorrect == true && contactIndex >= 0 && contactIndex < _contactsLists.GetContactsCount())
            {
                _contactsLists.DeleteContact(contactIndex);

                Console.WriteLine("Контакт успешно удален");
            }
            else
            {
                Console.WriteLine("\nУказан некорректный номер контакта.");
            }

            return userInput;
        }

        private static void Welcome()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.SetCursorPosition(20, 7);
            Console.WriteLine("Добро пожаловать в телефонную книгу!");

            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void MainInfo(int namesCount)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.SetCursorPosition(10, 0);
            Console.WriteLine("Телефонная книга");


            Console.SetCursorPosition(50, 0);
            Console.WriteLine($"Количество записей: {namesCount}");

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
