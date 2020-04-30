using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    class Account
    {
        private decimal _balance;
        private String _name;
        bool validDeposit = false;
        bool validWithdraw = false;


        public String Name
        {
            get { return _name; }
        }

        public Account(String name, decimal balance)
        {
            _name = name;
            _balance = balance;
        }

        public Boolean Deposit(decimal amount)
        {
            if(amount > 0)
            {
                _balance += amount;
                validDeposit = true;
            }else if(amount < 0)
            {
                validDeposit = false;
            }


            return validDeposit;
        }

        public Boolean Withdraw(decimal amount)
        {
            if(amount > _balance)
            {
                validWithdraw = false;
            }else if(amount <= _balance)
            {
                _balance -= amount;
                validWithdraw = true;
            }


            return validWithdraw;        
        }

        public void Print()
        {
            Console.WriteLine("Account Name: " + _name);
            Console.WriteLine("Account Balance: " + _balance);
        }
    }
}
