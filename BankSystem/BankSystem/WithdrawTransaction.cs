using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    class WithdrawTransaction
    {
        private Account _account;
        private decimal _amount;
        private bool _executed;
        private bool _success;
        private bool _reversed;


        public WithdrawTransaction(Account account, decimal amount)
        {
            _account = account;
            _amount = amount;
        }

        public void Print()
        {
            if(_executed == true)
            {
                Console.WriteLine("Your withdraw was successful. " +
                    "You withdrew {0}", _amount);
            }
            else if(_executed == false)
            {
                Console.WriteLine("Your withdraw was unsuccessful! " +
                    "please check your account balance and try again.");
            }
        }

        public void Execute()
        {
            try
            {
                
            }
            catch
            {
                throw new InvalidOperationException("");
            }
        }

        public void Rollback()
        {

        }

        public bool Executed
        {
            get { return _executed; }
        }

        public bool Success
        {
            get { return _success; }
        }

        public bool Reversed
        {
            get { return _reversed; }
        }
    }
}
