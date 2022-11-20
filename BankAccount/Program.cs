using System.Collections.Generic;
using System.Threading;
using BankAccount;

// --- USER CREATE --- //
List<string> history = new List<string>();

Console.WriteLine("\t Welcome to StoneX Bank!");
Console.WriteLine("\t--- Create new user ---");
Thread.Sleep(1000);
Console.WriteLine();

Console.WriteLine("Name:");
var name = Console.ReadLine();
Console.WriteLine("Login:");
var login = Console.ReadLine();
Console.WriteLine("Password:");
var password = Console.ReadLine();

Account account = new Account(name, login, password);
Console.WriteLine("Succesfully added!");

Thread.Sleep(1000);

Console.Clear();

// --- OPENS MENU --- //
Console.WriteLine($"\t    | StoneX Bank Menu |");
Console.WriteLine();
Console.WriteLine($"\tHello {name}!");
Console.WriteLine();

// --- NAVIGATION --- //
menu:
Console.WriteLine(
    "\n \t --- Choose an action ---" +
    "\n \t 1. Top up your balance" +
    "\n \t 2. Withdraw money" +
    "\n \t 3. Check your balance" +
    "\n \t 4. Transaction history" +
    "\n \t Press any other key to exit...");

var input = Console.ReadKey();
var key = input.KeyChar;
int value;

if (int.TryParse(key.ToString(), out value))
{
    switch (value)
    {
        case 1:
            Deposit(account, history);
            goto menu;
        case 2:
            Withdraw(account, history);
            goto menu;
        case 3:
            Check(account);
            goto menu;
        case 4:
            ShowHistory(history);
            goto menu;
        default:
            Console.WriteLine("Goodbye!");
            break;
    }
}
Console.ReadKey(false);
Console.ReadLine();

// --- METHODS --- //
void Check(Account account)
{
    Console.WriteLine(account.ShowBalance());
}

void Deposit(Account account, List<string> history)
{
    Console.WriteLine("Deposit money: ");
    double cash = Double.Parse(Console.ReadLine());
    account.Deposit(cash);
    history.Add($"|->|Deposited: {cash}. Current balance: {account.GetBalance()}.");
}

void Withdraw(Account account, List<string> history)
{
    Console.WriteLine("Withdraw moeny: ");
    double cash = Double.Parse(Console.ReadLine());
    account.Withdraw(cash);
    history.Add($"|<-| Withdrawn: {cash}. Current balance: {account.GetBalance()}.");
}

void ShowHistory(List<string> history)
{
    foreach (var transaction in history)
        Console.WriteLine(transaction);
}
