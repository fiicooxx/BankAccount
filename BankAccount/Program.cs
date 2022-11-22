using System.Collections.Generic;
using System.Threading;
using BankAccount;

// --- USER CREATE --- //
List<string> history = new List<string>();

// please enter here a path possible to make new .txt file so we are able to create new user :)
string path = "C:\\Users\\Fisix\\OneDrive\\Pulpit\\login_data.txt";

Console.WriteLine("| Welcome to StoneX Bank! |");
Console.WriteLine();
Console.WriteLine("--- REGISTRATION ---");
Thread.Sleep(1000);
Console.WriteLine();

string name, repName, userName, repUserName, password, repPassword = string.Empty;

Console.WriteLine("Create your name: ");
name = Console.ReadLine();
Console.WriteLine("Create a username: ");
userName = Console.ReadLine();
Console.WriteLine("Create a password ");
password = Console.ReadLine();

using (StreamWriter sw = new StreamWriter(File.Create(path)))
{
    sw.WriteLine(name);
    sw.WriteLine(userName);
    sw.WriteLine(password);
    sw.Close();
}
Account account = new Account(name, userName, password);
Console.WriteLine("Succesfully added!");
Thread.Sleep(1000);
Console.Clear();

// --- USER LOGIN --- //
login:
Console.WriteLine("| Welcome to StoneX Bank! |");
Console.WriteLine();
Console.WriteLine("--- LOGIN ---");
Thread.Sleep(1000);
Console.WriteLine();

Console.WriteLine("login: ");
userName = Console.ReadLine();
Console.WriteLine("password: ");
password = Console.ReadLine();

using (StreamReader sw = new StreamReader(File.Open(path, FileMode.Open)))
{
    sw.ReadLine();
    repUserName = sw.ReadLine();
    repPassword = sw.ReadLine();
    sw.Close();
}

if (userName == repUserName && password == repPassword)
{
    Console.WriteLine("Login successful!");
}
else
{
    Console.WriteLine("Login failed");
    Thread.Sleep(1500);
    Console.Clear();
    goto login;
}

Thread.Sleep(1000);
Console.Clear();

// --- OPENS MENU --- //
Console.WriteLine($"| StoneX Bank Menu |");
Console.WriteLine();
Console.WriteLine($"*>> Hello {name}! <<*");
Console.WriteLine();

// --- NAVIGATION --- //
menu:
Console.WriteLine(
    "\n --- Choose an action ---" +
    "\n 1. Top up your balance" +
    "\n 2. Withdraw money" +
    "\n 3. Check your balance" +
    "\n 4. Transaction history" +
    "\n Press any other key to exit...");

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
Console.Clear();

// --- METHODS --- //
void Check(Account account)
{
    Console.Clear();
    Console.WriteLine(account.ShowBalance());
}

void Deposit(Account account, List<string> history)
{
    Console.Clear();
    Console.WriteLine("Deposit money: ");
    double cash = Double.Parse(Console.ReadLine());
    account.Deposit(cash);
    history.Add($"|->| Deposited: {cash}. Current balance: {account.GetBalance()}.");
    Console.WriteLine("Successfuly deposited!");
}

void Withdraw(Account account, List<string> history)
{
    Console.Clear();
    Console.WriteLine("Withdraw money: ");
    double cash = Double.Parse(Console.ReadLine());
    account.Withdraw(cash);
    history.Add($"|<-| Withdrawn: {cash}. Current balance: {account.GetBalance()}.");
}

void ShowHistory(List<string> history)
{
    Console.Clear();
    foreach (var transaction in history)
        Console.WriteLine(transaction);
}
