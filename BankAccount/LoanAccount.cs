using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class LoanAccount : Account
    {
        //private data
        private decimal Principal;
        private double Interest;
        private int Duration;


        //constructor
        public LoanAccount(decimal AcctBalance, int AcctNumber, decimal AcctPrincipal, double AcctInt, int AcctDuration)
        {
            AccountBalance = AcctBalance;
            AccountNum = AcctNumber;
            AccountPrincipal = AcctPrincipal;
            AccountInterest = AcctInt;
            AccountDuration = AcctDuration;
        }

        //public properties
        public decimal AccountPrincipal
        {
            get { return Principal; }
            set
            {
                if(value < 0)
                {
                    throw new Exception("Loan principal cannot be less than 0.");
                }
                else
                {
                    Principal = value;
                }
            }
        }

        public double AccountInterest
        {
            get { return Interest; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Loan interest cannot be less than 0.");
                }
                else
                {
                    Interest = value;
                }
            }
        }

        public int AccountDuration
        {
            get { return Duration; }
            set
            {
                if (value < 6)
                {
                    throw new Exception("Sorry, the minimum loan period is 6 months.");
                }
                else
                {
                    Duration = value;
                }
            }
        }

        //methods
        //Calculates the amount of interset to be deposited, and increases the balance by that amount
        public void MonthlyInt()
        {
            double increase = ((double)AccountBalance * AccountInterest);
            AccountBalance += (decimal)increase;
        }

        public override string ToString()
        {
            string displayString = "\nAccount Number: " + AccountNum + "\tAccount Balance: " + AccountBalance + "\tAccount Interest Rate: " + AccountInterest + "\tDuration: " + AccountDuration;

            return displayString;
        }
    }
}
