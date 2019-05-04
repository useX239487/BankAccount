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
            double increase = ((double)AccountBalance * AccountInterest / 12); // divide by 12, interest rate is annual. 
            AccountBalance += (decimal)increase;
        }

        public void LoanPayment(decimal PaymentAmount)
        {
            if (AccountBalance - PaymentAmount < 0)
                throw new Exception("Loan balance cannot be reduced below $0.00.");
            else
                AccountBalance -= PaymentAmount;
        }

        public override string ToString()
        {
            string displayString = "\nAccount Number: " + AccountNum + "\tAccount Balance: " + AccountBalance.ToString("C2") + "\tAccount Interest Rate: " + AccountInterest.ToString("P3") + "\tDuration: " + AccountDuration;

            return displayString;
        }
    }
}
