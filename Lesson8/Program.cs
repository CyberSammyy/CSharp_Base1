using System;
using Lesson8.CardSystem;
using Lesson8.CardSystem.Interfaces;

namespace Lesson8
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank("qwe", 1_000_000);
            Atm atm = new Atm();
            Customer customer = new Customer("qwe", "qwe", 123456789, new Address());
            Customer customer2 = new Customer("qweqwe", "qweqwe", 123123123, new Address());

            CommonCard card = bank.EmitCard("sav", customer);
            CommonCard card1 = bank.EmitCard("plat", customer);
            CommonCard card2 = bank.EmitCard("univ", customer2);
            CommonCard card3 = bank.EmitCard("plat", customer2);
            customer.AddCards(new[] { card, card1 });
            customer2.AddCards(new[] { card2, card3 });
            card.Deposit(150);
            card.Withdraw(120);
            card1.Deposit(215_000);
            card3.Deposit(3_000_000);
            card2.Deposit(23_445);
            atm.Withdraw(card1 as ICashWihdrawal, 1200);
            Console.ReadKey();
        }
    }
}
