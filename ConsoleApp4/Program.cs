using ConsoleApp4.Bank;
using ConsoleApp4.Bank.Enums;
using Homework7.Song;
using System.Text;

// хочу красиво внедрить LINQ запрос в какое-нибудь из заданий :З
class StartProgram
{
    public static void Main(string[] args)
    {
        ////////////////////////////////
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.WriteLine("Упражнение 8.1 В класс банковский счет, созданный в упражнениях 7.1- 7.3 добавить\r\nметод, " +
            "который переводит деньги с одного счета на другой. У метода два параметра: ссылка\r\nна объект класса банковский счет " +
            "откуда снимаются деньги, второй параметр – сумма.\n");
        Console.ResetColor();

        var user1 = new BankAccount(10000, TypeOfBankAccount.Current);
        var user2 = new BankAccount(200, TypeOfBankAccount.Current);
        var user3 = new BankAccount(1000, TypeOfBankAccount.Savings);
        user1.Transfer(user2, 200);
        user2.Transfer(user3, 200);

        user1.PrintInfo();
        //////////////////////////////

        //////////////////////////////
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.WriteLine("Упражнение 8.2 Реализовать метод, который в качестве входного параметра принимает\r\nстроку string, " +
            "возвращает строку типа string, буквы в которой идут в обратном порядке.\r\nПротестировать метод.\n");
        Console.ResetColor();

        Console.Write("Введите строку: ");
        var stringText = Console.ReadLine();

        Console.WriteLine($"Начальная строка: {stringText}\nРезультат: {ReverseString(stringText)}");
        //////////////////////////////

        //////////////////////////////
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.WriteLine("Упражнение 8.3 Написать программу, которая спрашивает у пользователя имя файла. Если\r\nтакого файла не существует, " +
            "то программа выдает пользователю сообщение и заканчивает\r\nработу, иначе в выходной файл записывается содержимое исходного файла, " +
            "но заглавными\r\nбуквами.");
        Console.ResetColor();

        Console.Write("Введите имя файла: ");
        var nameOfFile = Console.ReadLine();

        if (nameOfFile is null)
        {
            throw new ArgumentNullException("Файла нет");
        }

        try
        {
            var textFromFile = File.ReadAllText("../../../Files/" + nameOfFile + ".txt");
            File.WriteAllText("../../../Files/Output.txt", textFromFile.ToUpper());

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        //////////////////////////////


        //////////////////////////////
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.WriteLine("\nУпражнение 8.4 Реализовать метод, который проверяет реализует ли входной параметр\r\nметода интерфейс System.IFormattable. " +
            "Использовать оператор is и as. (Интерфейс\r\nIFormattable обеспечивает функциональные возможности форматирования значения объекта\r\nв " +
            "строковое представление.)\n");
        Console.ResetColor();

        int number = 17;
        var date = DateTime.Now;
        var letter = 'f';
        var obj = new object();

        // Проверяем каждый
        Console.WriteLine(IsFormattable(number));
        Console.WriteLine(IsFormattable(date));
        Console.WriteLine(IsFormattable(letter));
        Console.WriteLine(IsFormattable(obj));
        //////////////////////////////

        //////////////////////////////
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.WriteLine("\nДомашнее задание 8.1 Работа со строками. Дан текстовый файл, содержащий ФИО и e-mail\r\nадрес. " +
            "Разделителем между ФИО и адресом электронной почты является символ #:" +
            "Сформировать новый файл, содержащий список адресов электронной почты.\r\nПредусмотреть метод, выделяющий из строки адрес почты. " +
            "Методу в\r\nкачестве параметра передается символьная строка s, e-mail возвращается в той же строке s:\r\npublic void SearchMail (ref string s).\n");
        Console.ResetColor();

        var file = File.ReadAllLines("../../../Files/Data.txt");
        var emails = from email in file
                     let text = GetEmailWithRef(email)
                     where text != String.Empty && text is not null
                     select text;

        var outputPATH = "../../../Files/OutputEmail.txt";
        File.WriteAllLines(outputPATH, emails);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Адреса электронной почты успешно записаны в файл)");
        Console.ResetColor();
        //////////////////////////////

        //////////////////////////////
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.WriteLine("Домашнее задание 8.2 Список песен. В методе Main создать список из четырех песен. " +
            "В\r\nцикле вывести информацию о каждой песне. Сравнить между собой первую и вторую\r\nпесню в списке. " +
            "Песня представляет собой класс с методами для заполнения каждого из\r\nполей, методом вывода данных о песне на печать, " +
            "методом, который сравнивает между\r\nсобой два объекта:\n");
        Console.ResetColor();

        var song1 = new Song("Firework", "Katy Perry");
        var song2 = new Song("Февраль", "Баста", song1);
        var song3 = new Song("Enemy", "Imagine Dragons", song2);
        var song4 = new Song("Firework", "Katy Perry", song3);

        var currentSong = song4; // переменная, которая хранит текущую песню
        
        while (currentSong != null) // выводим все песни
        {
            currentSong.PrintInfo();
            currentSong = currentSong.GetPrev(); // присваиваем текущей песне предыдущую песню
        }

        Console.WriteLine($"Сравниваем две разные песни song1 и song2 - {song1.Equals(song2)}");
        Console.WriteLine($"Сравниваем две одинаковые песни song1 и song4 - {song1.Equals(song4)}");
        //////////////////////////////
    }

    /// <summary>
    /// Вспомогательный метод для LINQ запроса, чтобы внутри LINQ вызвать, чтобы тот в свою очередь по ссылке поменял значение 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    static string GetEmailWithRef(string str) // АХАХАХАХА какой кринж сделал, но я хотел внедрить LINQ запрос :>
    {
        SearchMail(ref str); // метод меняет str по ссылке
        return str;
    }

    /// <summary>
    /// Метод, который по ссылке поменяет значение str, оставив в нем только email адрес
    /// </summary>
    /// <param name="str"></param>
    public static void SearchMail(ref string str)
    {
        if (str is not null)
        {
            var parts = str.Split('#');

            if (parts.Length == 2)
            {
                str = parts[1].Trim(); // присваиваем значение в виде электронной почты, удаляя пробелы
            }
            else
            {
                str = String.Empty;
            }
        }
    }

    /// <summary>
    /// Метод, который выводит строку в обратном порядке эффективно
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string ReverseString(string text)
    {
        var resultText = new StringBuilder(text.Length);

        for (int i = 0; i < text.Length; i++)
        {
            resultText.Append(text[text.Length - i - 1]);
        }

        return resultText.ToString();
    }


    /// <summary>
    /// Метод проверяет реализует ли входной параметр метода интерфейс System.IFormattable
    /// </summary>
    /// <param name="o"></param>
    /// <returns></returns>
    public static bool IsFormattable(object o)
    {
        var value = o as IFormattable;

        return value is not null ? true : false;
    }
}