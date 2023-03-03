using System;
using System.Xml.Linq;

namespace ContactBook_v2
{
    public class Programm
    {
        private static ContactsList _contactsLists;

        public static void Main(string[] args)
        {
            _contactsLists = new ContactsList(100);
            bool isContinue = true;

            Interface.Welcome();

            while (isContinue)
            {
                Thread.Sleep(800);
                Console.Clear();

                Interface.MainInfo(_contactsLists.GetContactsCount());

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
                        isContinue = false;
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
            bool isInputCorrect = InputInformation(out string name, out string phoneNumber, out string adress);

            if (isInputCorrect)
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

                bool isInputCorrect = InputInformation(out string name, out string phoneNumber, out string adress);

                if (isInputCorrect)
                {
                    contact[userChoice].Name = name;
                    contact[userChoice].PhoneNumber = phoneNumber;
                    contact[userChoice].Address = adress;

                    Console.WriteLine("Контакт успешно отредактирован!");
                }
            }
            else
            {
                Console.WriteLine($"\nУказан некорректный номер контакта.\nВы ввели: {userInput}");
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
                Console.WriteLine($"\nУказан некорректный номер контакта.\nВы ввели: {userInput}");
            }

            return userInput;
        }

        private static bool InputInformation(out string name, out string phoneNumber, out string adress)
        {
            Console.Write("\nВведите имя: ");
            name = Console.ReadLine();

            Console.Write("\nВведите номер телефона: ");
            phoneNumber = Console.ReadLine();

            Console.Write("\nВведите город проживания: ");
            adress = Console.ReadLine();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(adress))
            {
                Console.WriteLine("\nВы ввели некорректное значение!");

                if (string.IsNullOrEmpty(name))
                    Console.WriteLine($"Указано некорректное имя. Поле пустое.");
                if (string.IsNullOrEmpty(phoneNumber))
                    Console.WriteLine($"Указано некорректный номер телефона. Поле пустое");
                if (string.IsNullOrEmpty(adress))
                    Console.WriteLine($"Указано некорректный город проживания. Поле пустое");

                Console.ReadKey();

                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
