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
            TransferPaymentCommisionPersent = 0.03m;
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

        public void TerminalTransfer(ref ICashWihdrawal card2income, decimal amount)
        {
            if (amount + amount * TransferPaymentCommisionPersent < this.Balance)
            {
                this.Balance -= amount + amount * TransferPaymentCommisionPersent;
                this.Emittent.Funds += amount * TransferPaymentCommisionPersent;
                card2income.Income(amount);
            }
            else
            {
                Console.WriteLine("Not enough money!");
            }
        }
        public override void Income(decimal amount)
        {
            base.Income(amount);
        }
        public override decimal WithdrawCommission(decimal amount)
        {
            return amount * 0.005m;
        }
    }
}
