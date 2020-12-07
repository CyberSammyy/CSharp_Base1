using System;
using System.Collections.Generic;
using System.Text;
using Lesson8.CardSystem.Interfaces;

namespace Lesson8
{
    class Terminal
    {
        public void PaymentWithdraw(ICashWihdrawal card, string paymentDetails, decimal amount)
        {
            card.AtmWithdraw(amount);
            //Logic for transfering money to another account
        }
        public void TransferWithdraw(ICashWihdrawal card2income, ICashWihdrawal card2withdraw, decimal amount)
        {
            card2income.TerminalTransfer(ref card2withdraw, amount); 
        }
    }
}
