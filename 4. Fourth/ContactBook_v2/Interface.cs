namespace ContactBook_v2
{
    public class Interface
    {
        public static void Welcome()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.SetCursorPosition(20, 7);
            Console.WriteLine("Добро пожаловать в телефонную книгу!");

            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void MainInfo(int ContactsCount)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.SetCursorPosition(10, 0);
            Console.WriteLine("Телефонная книга");


            Console.SetCursorPosition(50, 0);
            Console.Write($"Количество записей: "); 
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(ContactsCount);

            Console.WriteLine("\n");
        }
    }
}