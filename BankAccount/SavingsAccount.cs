using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class SavingsAccount : Account
    {
        //private data
        private double InterestRate;

        //Constructor
        public SavingsAccount(decimal AcctBalance, int AcctNumber, double AcctInterest)
        {
            AccountInterest = AcctInterest;
            AccountNum = AcctNumber;
            AccountBalance = AcctBalance;
        }


        //public properties
        public double AccountInterest
        {
            get { return InterestRate; }
            set
            {
                if(value < 0)
                {
                    throw new Exception("An interest rate cannot be less than 0.");
                }
                else
                {
                    InterestRate = value;
                }
            }
        }

        //Methods
        //Calculates the amount of interset to be deposited, and increases the balance by that amount
        public void MonthlyInt()
        {
            double increase = ((double)AccountBalance * AccountInterest);
            AccountBalance += (decimal)increase;
        }

        public override string ToString()
        {
            string displayString = "\nAccount Number: " + AccountNum + "\tAccount Balance: " + AccountBalance + "\tAccount Interest Rate:" + AccountInterest;

            return displayString;
        }
    }
}
