using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Счет для подарочной карты
namespace oopTest.Classes
{
    public class GiftCardAccount : BanckAccount
    {
        public GiftCardAccount(string name, decimal initialBalance) : base (name, initialBalance) 
        { 
        }

        private readonly decimal _monthlyDeposit = 0m;

        public GiftCardAccount(string name, decimal initialBalance, decimal monthlyDeposit = 0) : base(name, initialBalance)
            => _monthlyDeposit = monthlyDeposit;
    }
}
