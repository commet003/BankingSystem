using System;

namespace BankApp
{
    class BankSystem
    {

        public enum MenuOption
        {
            Withdraw,
            Deposit,
            Print,
            Quit
        }

        public static MenuOption ReadUserOption()
        {
            int menuInput;
            MenuOption menuOption;
            bool validInput = false;

            do
            {
                
                Console.WriteLine("1: Withdraw money from your account.");
                Console.WriteLine("2: Deposit money into your account.");
                Console.WriteLine("3: Print the balance of your account.");
                Console.WriteLine("4: Quit");
                Console.WriteLine("Please enter the number of the option you want to select.");
                menuInput = Convert.ToInt32(Console.ReadLine());

                if(menuInput < 1 || menuInput > 4)
                {
                    Console.Clear();
                    Console.WriteLine("ERROR: Incorrect selection. Please try again!");     
                    validInput = false;
                }
                else
                {
                    if(menuInput == 1)
                    {
                        menuOption = MenuOption.Withdraw;
                        validInput = true;
                        return menuOption;
                    }
                    else if(menuInput == 2)
                    {
                        menuOption = MenuOption.Deposit;
                        validInput = true;
                        return menuOption;
                    }
                    else if(menuInput == 3)
                    {
                        menuOption = MenuOption.Print;
                        validInput = true;
                        return menuOption;
                    }
                    else if(menuInput == 4)
                    {
                        menuOption = MenuOption.Quit;
                        validInput = true;
                        return menuOption;
                    }
                    
                }

            } while (validInput == false);

            return MenuOption.Print;
        }
        static void Main(string[] args)
        {
            Account testAccount = new Account("Corie Rhodes", 2369);
            MenuOption option = ReadUserOption();

            if(option == MenuOption.Withdraw)
            {
                DoWithdraw(testAccount);
            }
            else if(option == MenuOption.Deposit)
            {
                DoDeposit(testAccount);
            }
            else if(option == MenuOption.Print)
            {
                DoPrint(testAccount);
            }
            else if(option == MenuOption.Quit)
            {
                Environment.Exit(0);
            }


            void DoDeposit(Account account)
            {
                decimal amount = 50;

                if(account.Deposit(amount) == true)
                {
                    account.Deposit(amount);
                    Console.WriteLine("Your deposit was successful");
                }
                
            }

            void DoWithdraw(Account account)
            {
                decimal amount = 80;
                if (account.Withdraw(amount) == true)
                {
                    Console.WriteLine("Your withdraw was successful!");
                    account.Withdraw(amount);
                }
                else if(account.Withdraw(amount) == false)
                {
                    Console.WriteLine("Your withdraw was unsuccessful, Please check your account balance and try again.");
                }
            }

            void DoPrint(Account account)
            {
                account.Print();
            }
            

        }
    }
}
