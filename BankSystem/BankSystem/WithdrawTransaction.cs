using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    class WithdrawTransaction
    {
        private Account _account;
        private decimal _amount;
        private bool _executed = false;
        private bool _success = false;
        private bool _reversed = false;


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
            if (_executed == false)
            {
                if (_account.Withdraw(_amount) == true)
                {
                    _executed = true;
                    _success = true;
                }
                else if (_account.Withdraw(_amount) == false)
                {
                    throw new InvalidOperationException("Transaction fail: Insufficient funds.");
                }
                
            }
            else if(_executed == true)
            {
                throw new InvalidOperationException("Withdraw has already been executed.");
            }
        }

        public void Rollback()
        {
            if(_reversed == false && _executed == true)
            {
                _account.Deposit(_amount);
                _reversed = true;
            }
            else if(_reversed == true || _executed == false)
            {
                if(_reversed == true)
                {
                    throw new InvalidOperationException("The transaction has already been reversed.");
                }
                else if (_executed == false)
                {
                    throw new InvalidOperationException("The withdraw has not been successfully processed yet.");
                }   
            }
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
