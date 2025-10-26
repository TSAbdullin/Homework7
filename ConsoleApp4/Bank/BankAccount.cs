using ConsoleApp4.Bank.Enums;

namespace ConsoleApp4.Bank
{
    internal class BankAccount
    {
        private long _accountNumber; // поле для номера счета,
        private decimal _balance; // баланс
        private TypeOfBankAccount _typeOfBankAccount; // тип счета
        private static long _idCounter = 1;

        public BankAccount(decimal balance, TypeOfBankAccount typeOfBankAccount)
        {
            _accountNumber = _idCounter++;
            _balance = balance;
            _typeOfBankAccount = typeOfBankAccount;
        }

        /// <summary>
        /// Вывод денег
        /// </summary>
        /// <param name="money"></param>
        /// <exception cref="ArgumentException"></exception>
        public void Withdraw(decimal money) // метод для вывода денег
        {
            if (money <= 0)
            {
                throw new ArgumentException("Сумма не может быть отрицательной!\n");
            }

            if (_balance >= money)
            {
                _balance -= money;
                Console.WriteLine($"Сумма {money} успешно выведена!\nТекущий баланс: {_balance}\n");
            }
            else
            {
                Console.WriteLine("На балансе недостаточно средств!\n");
            }
        }

        /// <summary>
        /// Метод для пополнения баланса
        /// </summary>
        /// <param name="money"></param>
        /// <exception cref="ArgumentException"></exception>
        public void RefillBalance(decimal money) // метод для пополнения баланса
        {
            if (money <= 0)
            {
                throw new ArgumentException("Сумма пополнения не может быть отрицательной!\n");
            }

            _balance += money;
            Console.WriteLine($"Баланс успешно пополнен на {money}\nТекущий баланс: {_balance}\n");
        }


        /// <summary>
        /// Метод для перевода денег на целевой счет
        /// </summary>
        /// <param name="targetBankAccount"></param>
        /// <param name="money"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void Transfer(BankAccount targetBankAccount, decimal money)
        {
            if (targetBankAccount is null)
            {
                throw new ArgumentNullException("Пользователя не существует");
            }

            if ((_typeOfBankAccount == TypeOfBankAccount.Current) && (targetBankAccount._typeOfBankAccount == TypeOfBankAccount.Current))
            {
                if (money > _balance)
                {
                    throw new ArgumentException("Сумма превышает баланс!");
                }

                if (money < 0)
                {
                    Console.WriteLine("Нельзя перевести отрицательную сумму!");
                }
                else if (money == 0)
                {
                    Console.WriteLine("Заполните сумму, числом, отличным от нуля!");
                }
                else
                {
                    _balance -= money;
                    targetBankAccount._balance += money;
                    Console.WriteLine($"Сумма {money} успешно переведена по номеру {targetBankAccount._accountNumber}");
                }
            }
            else
            {
                Console.WriteLine("Невозможно перевести!"); 
                // смысл в том, что как я понял перевести сразу на прямую на сберегательный счет другого пользователя нельзя
                // можно только на свой, и в принципе со сберегательного счета на чужие счета ложить нельзя
            }

            
        }

        /// <summary>
        /// Метод для вывода информации о номере счета, балансе и типе счета
        /// </summary>
        public void PrintInfo()
        {
            Console.WriteLine($"Номер счета: {_accountNumber}\nБаланс: {_balance}\nТип счета: {_typeOfBankAccount}");
        }
    }
}