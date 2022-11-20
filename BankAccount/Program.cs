using System.Collections.Generic;
using System.Threading;
using BankAccount;

List<string> history = new List<string>();

Console.WriteLine("\t Welcome to StoneX Bank!");
Console.WriteLine("\t--- Create new user ---");
Thread.Sleep(1000);
Console.WriteLine();

Console.WriteLine("Name:");
var name = Console.ReadLine();
Console.WriteLine("Surname:");
var surname = Console.ReadLine();
Console.WriteLine("Login:");
var login = Console.ReadLine();
Console.WriteLine("Password:");
var password = Console.ReadLine();

Account account = new Account(name, surname, login, password);
Console.WriteLine("Succesfully added!");

Thread.Sleep(1000);

Console.Clear();

Console.WriteLine($"\t    | StoneX Bank Menu |");
Console.WriteLine();
Console.WriteLine($"\tHello {name} {surname}!");
Console.WriteLine();

Console.WriteLine(
    "\n \t --- Choose an action ---" +
    "\n \t 1. Top up your balance" +
    "\n \t 2. Withdraw money" +
    "\n \t 3. Check your balance" +
    "\n \t 4. Transaction history" +
    "\n \t 5. Exit");

var input = Console.ReadKey();
var key = input.KeyChar;
int value;
{
    if (int.TryParse(key.ToString(), out value))
    {
        Console.WriteLine();
        RouteChoice(value);
    }
    else
        Console.WriteLine("Invalid Entry.");
}


Console.Write("Press any key to exit...");
Console.ReadKey(false);

Console.ReadLine();


void Deposit(Account account, List<string> history)
{
    Console.WriteLine("Deposit money: ");
    double cash = Double.Parse(Console.ReadLine());
    account.Deposit(cash);
    history.Add($"|->|Deposited: {cash}. Current balance: {account.ShowBalance}");
}

void Withdraw(Account account, List<string> history)
{
    Console.WriteLine("Withdraw moeny: ");
    double cash = Double.Parse(Console.ReadLine());
    account.Withdraw(cash);
    history.Add($" |<-| Withdrawn: {cash}. Current balance: {account.ShowBalance}");
}

void Check(Account account)
{
    account.ShowBalance();
}

void ShowHistory(List<string> history)
{
    foreach (var transaction in history)
        Console.WriteLine(transaction);
}

void RouteChoice(int menuChoice)
{
    switch (menuChoice)
    {
        case 1:
            Deposit(account, history);
              break;
        case 2:
            Withdraw(account, history);
            break;
        case 3:
            Check(account);
            break;
        case 4:
            ShowHistory(history);
            break;
        case 5:
            break;
        default:
            Console.WriteLine("Invalid Entry!");
            break;
    }
}