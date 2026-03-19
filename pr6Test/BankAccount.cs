using System;
namespace pr6Test
{
    public class BankAccount
    {
        private readonly string m_customerName;
        private double m_balance;
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";
        public const string CreditBelowZeroMessage = "Credit amount below zero";
        private BankAccount() { }

        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }


        public string CustomerName
        {
            get { return m_customerName; }
        }


        public double Balance
        {
            get { return m_balance; }
        }
        /// <summary>
        /// Этот метод списывает с баланса указанную вами сумму.
        /// </summary>
        /// <param name="amount">Какую сумму списать</param>
        public void Debit(double amount)
        {

            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }
            m_balance -= amount;
        }
        /// <summary>
        /// Этот метод увеличивет баланс на указанную вами сумму.
        /// </summary>
        /// <param name="amount">На какую сумму увеличить</param>
        public void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, CreditBelowZeroMessage);
            }
            m_balance += amount;
        }

        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr. Roman Abramovich", 11.99);


            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balance is ${0}", ba.Balance);
            Console.ReadLine();
        }
    }

}
