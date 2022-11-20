using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class Account
    {
        private string _accNumber;
        private string _password;
        private string _name;
        private string _surname;
        private double _balance;

        public Account(string name, string surname, string accountNumber, string password)
        {
            _name = name;
            _surname = surname;
            _accNumber = accountNumber;
            _password = password;            
        }

        public string GetAccountNumber() => this._accNumber;
        public string ShowBalance() => $"Hi {this._name}! Your account balance is {this._balance}.";
        public double Withdraw(double money)
        {
            if (this._balance >= money)
            {
                this._balance = this._balance - money;
                Console.WriteLine("The money was successfully withdrawn");
            }
            else Console.WriteLine("Such an operation is not possible");

            return this._balance;
        }
        public bool Deposit(double cash)
        {
            double prevBalance = this._balance;
            this._balance = this._balance + cash;
            if (this._balance == prevBalance + cash) return true;
            else return false;
        }
    }
}
