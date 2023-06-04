using System;

namespace CalAdei;

public class BankAccount
{
    public string Number { get; }
    public string Owner { get; set; }
    private static int s_accountNumberSeed = 1234567890;

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
    public BankAccount(string name, decimal initialBalance)
    {
        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;
        Owner = name; // Same as this.Owner = name
        MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");
    }
    private List<Transaction> _allTransactions = new List<Transaction>();

    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
        }
        var deposit = new Transaction(amount, date, note);
        _allTransactions.Add(deposit);
    }

    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
        }

        if (Balance - amount < 0)
        {
            throw new InvalidOperationException("Not sufficient funds for withdrawing");
        }

        Transaction withdraw = new Transaction(-amount, date, note);
        _allTransactions.Add(withdraw);
    }
    public string GetAccountHistory()
    {
        var report = new System.Text.StringBuilder();
        decimal balance = 0;
        report.AppendLine("Date\t\tAmount\tBalance\tNote");
        
        foreach (var item in _allTransactions)
        {
            balance += item.Amount;
            report.AppendLine($"{ item.Date.ToShortDateString()}\t{ item.Amount}\t{ balance}\t{ item.Notes} ");
        }
        return report.ToString();
    }

}
