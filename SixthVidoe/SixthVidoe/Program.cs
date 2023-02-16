using SixthVideo;
using System;

namespace SixthVideo
{

    public class Programm
    {
        private static IssueList _issueList;

        public static void Main(string[] args)
        {
            /*
            ToDo List

            1. Возможности
            - Посмотреть список задач
            - Добавить новую задачу
            - Удалить задачу
            - Пометить задачу как выполненную
            - Взять задачу в работу
            - Редактировать задачу

            2. Задача
            - Цель
            - Дата создания
            - Статус

            3. Статус
            - Новое
            - В работе
            - Выполнено

            */

            _issueList = new IssueList(100);
            bool isEnd = false;

            Console.SetCursorPosition(15, 5);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Добро пожаловать в планировщик задач!");
            Console.ForegroundColor = ConsoleColor.White;

            while (isEnd == false)
            {
                MainStructure();

                Console.WriteLine($"Что Вы хотите сделать?\n1 - Просмотреть весь список задач\n" +
                                  $"2 - Добавить новую задачу\n" +
                                  $"3 - Удалить задачу\n" +
                                  $"4 - Редактировать наименование задачи\n" +
                                  $"5 - Взять задачу в работу\n" +
                                  $"6 - Пометить задачу как выполненную\n" +
                                  $"0 - Выйти");
                
                string userInput = Console.ReadLine();
                switch(userInput)
                {
                    case Operations.SHOW_ALL_ISSUES:
                        ShowIssues();
                        Console.WriteLine("\nДля продолжения нажмите на любую кнопку");
                        Console.ReadKey();
                        break;

                    case Operations.ADD_NEW_ISSUE:
                        AddNewIssue();
                        break;

                    case Operations.DELETE_ISSUE:
                        DeleteIssue();
                        break;

                    case Operations.EDIT_ISSUE:
                        EditTitle();
                        break;

                    case Operations.TAKE_ISSUE:
                        TakeIssue();
                        break;

                    case Operations.COMPLETE_ISSUE:
                        CompleteIssue();
                        break;

                    case Operations.EXIT: 
                        isEnd = true;

                        Console.WriteLine("Благодарим Вас за использование приложения!");
                        Thread.Sleep(1000);
                        break;

                    default:
                        Console.WriteLine("Такой команды не существует!");
                        break;
                }
            }
        }

        private static void ShowIssues()
        {
            MainStructure();

            // Временно проверка корректности вывода
            Issue[] issues = _issueList.GetIssues();

            for (int i = 0; i < issues.Length; i++)
            {
                int index = i + 1;
                Console.WriteLine($"\n{index}. Наименование задачи: {issues[i].Title}\n" +
                                  $"Дата последнего изменения: {issues[i].DateTime}\n" +
                                  $"Текущее состояние: {issues[i].Status}");
            }
        }

        private static void AddNewIssue()
        {
            Console.WriteLine("\nВведите наименование задачи:");
            string title = Console.ReadLine();

            if (string.IsNullOrEmpty(title) == false)
                _issueList.AddIssue(title);

            Console.WriteLine("\nЗадача успешно добавлена");
        }

        private static void DeleteIssue()
        {
            ShowIssues();

            bool isNumberCorrect = IsNumberCorrect(out int issueIndex);

            if (isNumberCorrect == true)
            {
                _issueList.DeleteIssue(issueIndex);
                Console.WriteLine("\nЗадача успешно удалена!");
            }
        }

        private static void EditTitle()
        {
            ShowIssues();

            bool isNumberCorrect = IsNumberCorrect(out int issueIndex);

            if (isNumberCorrect == true)
            {
                Console.WriteLine("\nВведите новое название задачи: ");
                string title = Console.ReadLine();

                if (string.IsNullOrEmpty(title) == false)
                {
                    _issueList.EditTitle(title, issueIndex);
                    Console.WriteLine("\nНаименование задачи успешно изменено");
                }
                else
                {
                    Console.WriteLine("\nНаименование не может быть пустым!");
                }
            }
        }

        private static void TakeIssue()
        {
            ShowIssues();

            bool isNumberCorrect = IsNumberCorrect(out int issueIndex);

            if (isNumberCorrect == true)
            {
                _issueList.TakeIssue(issueIndex);
                Console.WriteLine("\nЗадача взята в работу!");
            }
        }

        private static void CompleteIssue()
        {
            ShowIssues();

            bool isNumberCorrect = IsNumberCorrect(out int issueIndex);

            if (isNumberCorrect == true)
            {
                _issueList.CompleteIssue(issueIndex);
                Console.WriteLine("\nЗадача выполнена!");
            }
        }

        private static bool IsNumberCorrect(out int issueIndex)
        {
            Console.WriteLine("\nУкажите номер задачи:");

            bool isGoodNumber = int.TryParse(Console.ReadLine(), out issueIndex);
            issueIndex -= 1;

            if (isGoodNumber == true && issueIndex >= 0 && issueIndex < _issueList.GetIssuesCount())
                return true;
            else
            {
                Console.WriteLine("\nВведен некорректный номер задачи");
                return false;
            }
        }

        private static void MainStructure()
        {
            Thread.Sleep(800);
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(20, 0);
            Console.WriteLine("Список задач");
            Console.SetCursorPosition(71, 0);
            Console.WriteLine("Список задач в работе:");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Задачи в работе:");
            int issueInWorkString = 2;

            Issue[] issues = _issueList.GetIssues();

            for (int i = 0; i < issues.Length; i++)
            {
                if (issues[i].Status == Status.В_работе)
                {
                    Console.SetCursorPosition(71, issueInWorkString);
                    Console.WriteLine(issues[i].Title);
                    issueInWorkString++;
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i <= issueInWorkString; i++)
            {
                Console.SetCursorPosition(70, i);
                Console.WriteLine("|");
            }
            for (int i = 0; i < 70; i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.WriteLine("-");
            }
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(0, 2);
        }
    }

}
