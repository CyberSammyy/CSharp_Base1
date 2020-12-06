using System;
using Lesson8.CardSystem.Interfaces;

namespace Lesson8.CardSystem.Specific
{
    public class UniversalCard : CommonCard, ICashWihdrawal
    {
        public UniversalCard(string number, CardSecurity security, DateTime expirationDate, Customer owner, Bank emittent)
            : base(number, security, expirationDate, owner, emittent)
        {
            WithdrawCommissionPercent = 0.05m;
        }

        public decimal AtmWithdraw(decimal amount)
        {
            return Withdraw(amount);
            //if (Balance > amount - amount * WithdrawCommission(amount))
            //{
            //    Balance -= amount - amount * WithdrawCommission(amount);
            //    Emittent.ReceiveFunds(WithdrawCommission(amount)); Funds += amount * WithdrawCommission(amount);
            //    return amount - amount * WithdrawCommission(amount);
            //}
            //else
            //    return 0;
        }

        public override decimal DepositCommission(decimal amount)
        {
            return base.DepositCommission(amount);
        }

        public override decimal WithdrawCommission(decimal amount)
        {
            return amount * 0.005m;
        }
    }
}
