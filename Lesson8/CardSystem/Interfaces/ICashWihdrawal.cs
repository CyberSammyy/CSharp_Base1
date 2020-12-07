using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson8.CardSystem.Interfaces
{
    public interface ICashWihdrawal
    {
        decimal AtmWithdraw(decimal amount);
        void TerminalTransfer(ref ICashWihdrawal card2, decimal amount);
        void Income(decimal amount);
    }
}
