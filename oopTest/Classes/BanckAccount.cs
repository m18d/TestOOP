using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopTest.Classes
{
    //Банковский счет.
    public class BanckAccount
    {
        private static int s_accountNumberSeed = 1234567890;

        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance 
        {
            get
            {
                decimal balance = 0;
                foreach (var item in _allTransactions) 
                {
                    balance += item.Amount;
                }

                return balance;
            }
        }

        public BanckAccount(string name, decimal initialBalance) 
        {
            this.Number = s_accountNumberSeed.ToString();
            s_accountNumberSeed++;

            this.Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        }

        private List<Transaction> _allTransactions = new List<Transaction>();

        public void MakeDeposit(decimal amount, DateTime date, string Note)
        {
            if (amount <= 0) 
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, Note);
            _allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string Note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, Note);
            _allTransactions.Add(withdrawal);
        }

        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            foreach (var transactiom in _allTransactions)
            {
                balance += transactiom.Amount;
                report.AppendLine($"{transactiom.Date.ToShortDateString()}\t{transactiom.Amount}\t{balance}\t{transactiom.Notes}");
            }

            return report.ToString();
        }
    }
}
