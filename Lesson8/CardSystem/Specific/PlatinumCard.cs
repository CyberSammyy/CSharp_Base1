using System;
using Lesson8.CardSystem.Interfaces;

namespace Lesson8.CardSystem.Specific
{
    public class PlatinumCard : CommonCard, ICashWihdrawal, ICashDeposit
    {
        public PlatinumCard(string number, CardSecurity security, DateTime expirationDate, Customer owner, Bank emittent)
            : base(number, security, expirationDate, owner, emittent)
        {
            WithdrawCommissionPercent = 0.10m;
            TransferPaymentCommisionPersent = 0.15m;
        }

        public decimal AtmWithdraw(decimal amount)
        {
            return Withdraw(amount);
            //if (Balance > amount - amount * WithdrawCommission(amount))
            //{
            //    Balance -= amount - amount * WithdrawCommission(amount);
            //    Emittent.Funds += amount * WithdrawCommission(amount);
            //    return amount - amount * WithdrawCommission(amount);
            //}
            //else
            //    return 0;
        }

        public override void Income(decimal amount)
        {
            base.Income(amount);
        }

        public override decimal DepositCommission(decimal amount)
        {
            if (amount > 10_000)
            {
                return base.DepositCommission(amount) / 2;
            }
            else
            {
                return base.DepositCommission(amount) + 15;
            }
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

        public override decimal WithdrawCommission(decimal amount)
        {
            return 20;
        }
    }
}
