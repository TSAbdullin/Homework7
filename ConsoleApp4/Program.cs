using ConsoleApp4.Bank;
using ConsoleApp4.Bank.Enums;

class StartProgram
{
    public static void Main(string[] args)
    {
        //////////////////////////////
        Console.WriteLine("Упражнение 8.1 В класс банковский счет, созданный в упражнениях 7.1- 7.3 добавить\r\nметод, " +
            "который переводит деньги с одного счета на другой. У метода два параметра: ссылка\r\nна объект класса банковский счет " +
            "откуда снимаются деньги, второй параметр – сумма.\n");
        BankAccount user1 = new BankAccount(10000, TypeOfBankAccount.Current);
        BankAccount user2 = new BankAccount(200, TypeOfBankAccount.Current);
        BankAccount user3 = new BankAccount(1000, TypeOfBankAccount.Savings);
        user1.Transfer(user2, 200);
        user2.Transfer(user3, 200);
        //////////////////////////////

    }
}