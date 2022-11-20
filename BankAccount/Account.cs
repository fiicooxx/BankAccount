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
        private double _balance;

        public Account(string name, string accountNumber, string password)
        {
            _name = name;
            _accNumber = accountNumber;
            _password = password;            
        }

        public string GetAccountNumber() => this._accNumber;
        public double GetBalance() => this._balance;
        public string ShowBalance() => $"Hi {this._name}! Your account balance is {this._balance}.";
        public double Withdraw(double money)
        {
            if (this._balance >= money)
            {
                this._balance = this._balance - money;
                Console.WriteLine("The money was successfully withdrawn!");
            }
            else Console.WriteLine("Such an operation is not possible!");

            return this._balance;
        }
        public bool CheckDeposit(double cash)
        {
            double prevBalance = this._balance;
            this._balance = this._balance + cash;
            if (this._balance == prevBalance + cash) return true;
            else return false;
        }
        public double Deposit(double cash)
        {
            if (CheckDeposit(cash))
                return this._balance;
            else throw new Exception();
        }
    }
}
