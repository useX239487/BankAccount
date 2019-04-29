using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class CheckingAccount : Account
    {
        //private data
        private int creditLimit;

        //Constructor
        public CheckingAccount(decimal AcctBalance, int AcctNumber, int AcctCredit)
        {
            AccountCredit = AcctCredit;
            AccountNum = AcctNumber;
            AccountBalance = AcctBalance;
        }

        //Public Properties
        public int AccountCredit
        {
            get { return creditLimit; }
            set
            {
                if (value >= 0)
                {
                    creditLimit = value;
                }
                else
                {
                    throw new Exception("Credit limit cannot be less than 0.");
                }
            }
        }




        //Methods
        //New Withdraw method that allow a withdraw down to 0 minus the credit limit
        public new void Withdraw(decimal withd)
        {
            if (AccountBalance - withd < 0 - AccountCredit)
            {
                Console.WriteLine("You have insufficient funds for this withdraw.");
            }
            else
            {
                AccountBalance -= withd;
            }
            //Charge overdraft fee if balance is now less than 0
            if (AccountBalance < 0)
            {
                AccountBalance -= 25;
            }
        }

        public override string ToString()
        {
            string displayString = "\nAccount Number: " + AccountNum + "\tAccount Balance: " + AccountBalance + "\tAccount Credit:" + AccountCredit;

            return displayString;
        }
    }
}
