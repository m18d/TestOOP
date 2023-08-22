using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Счет для начисления процентов
namespace oopTest.Classes
{
    public class InterestEarningAccount : BanckAccount
    {
        public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance)
        { }

        public override void PerformMonthEndTransactions()
        {
            if (Balance > 500m)
            {
                decimal interest = Balance * 0.05m;
                MakeDeposit(interest, DateTime.Now, "apply monthly interest");
            }
        }
    }
}
