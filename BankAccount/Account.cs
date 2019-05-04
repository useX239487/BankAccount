using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    // All other account classes inherit this one, all accounts have a number and balance
    class Account
    {
        //Private Data
        int AccountNumber;
        decimal Balance;

        // Don't really want anyone to be able to create just an Account, would have to specify the type of account
        //Public Constructors
        //public Account(decimal AcctBalance, int AcctNum)
        //{
        //    AcctBalance = AccountBalance;
        //    AcctNum = AccountNumber;
        //}

        //Public Properties
        public decimal AccountBalance
        {
            get { return Balance; }
            set
            {
                if(value < 0)
                {
                    throw new Exception("Account balance cannot be less than 0.");
                }
                else
                {
                    Balance = value;
                }
            }
        }

        public int AccountNum
        {
            get { return AccountNumber; }
            set
            {
                if(value < 0)
                {
                    throw new Exception("Account number cannot be less than 0.");
                }
                else
                {
                    AccountNumber = value;
                }
            }
        }



        //Public Methods

        //Allows customer to deposit money to increase balance, deposit cannot be negative
        public void Deposit(decimal dep)
        {
            Balance += dep;
        }

        //Allows customer to withdraw money to decrease balance, balance cannot become negative
        public void Withdraw(decimal withd)
        {
            if(Balance - withd < 0)
            {
                Console.WriteLine("You have insufficient funds for this withdraw.");
            }
            else
            {
                Balance -= withd;
            }
        }

        //Inquiry method simply returns the current account balance
        public void BalanceInquity()
        {
            Console.WriteLine($"The current balance of Account {AccountNum} is {AccountBalance}.");
        }

        //This is overriden by all other accounts that inherit it in order to print out the necessary
        //information for that class.
        public override string ToString()
        {
            string displayString = "\nAccount Number: " + AccountNum + "\tAccount Balance: " + AccountBalance.ToString("C2");

            return displayString;
        }
    }
}
