using System;
namespace CalAdei;

class Program
{
    public static void Main(string[] args)
    {
        BankAccount account = new BankAccount("Roland Dodoo", 1000);
        account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
        account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
        Console.WriteLine(account.GetAccountHistory());

       
    }
}


