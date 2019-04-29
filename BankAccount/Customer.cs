using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class Customer
    {
        //Need a method to make sure new accounts do not match an already existing account number
        //Private data
        private int Number;
        private string Name;
        private List<Account> CustomerAccounts;

        //constructor
        public Customer(int custNum, string custName, List<Account> custAccounts)
        {
            CustomerNumber = custNum;
            CustomerName = custName;
            CustomerAccount = custAccounts;
        }

        //public properties
        public int CustomerNumber
        {
            get { return Number; }
            set
            {
                if(value < 0)
                {
                    throw new Exception("Customer number must be positive.");
                }
                else
                {
                    Number = value;
                }
            }
        }

        public string CustomerName
        {
            get { return Name; }
            set
            {
                if (value.Length == 0)
                {
                    throw new Exception("The customer name cannot be blank.");
                }
                else
                {
                    Name = value;
                }
            }
        }

        public List<Account> CustomerAccount
        {
            get { return CustomerAccounts; }
            set
            {
                CustomerAccounts = value;
            }
        }


        //methods
        //Method to add a new account to the customer
        public void AddAccount()
        {
            int selection, duration, acctNum, acctCredit;
            decimal balance;
            double interestRate;
            while (true)
            {
                try
                {
                    Console.WriteLine("Please select what type of account you are opening:" +
                      "\n1.Checking Account\n2.Savings Account\n3.Loan Account\n4.Exit");
                    selection = Convert.ToInt32(Console.ReadLine());

                    //Once a selection is made, it will go to the approprate account and request the required constructor variables
                    if (selection == 1)
                    {
                        Console.WriteLine("Please provide the following information to complete your checking account opening: ");
                        Console.WriteLine("Deposit amount:");
                        balance = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("Account Number:");
                        acctNum = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Credit Limit: ");
                        acctCredit = Convert.ToInt32(Console.ReadLine());
                        CustomerAccount.Add(new CheckingAccount(balance, acctNum, acctCredit));
                    }
                    else if (selection == 2)
                    {
                        Console.WriteLine("Please provide the following information to complete your savings account opening: ");
                        Console.WriteLine("Deposit amount:");
                        balance = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("Account Number:");
                        acctNum = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Interest Rate as a decimal: ");
                        interestRate = Convert.ToDouble(Console.ReadLine());
                        CustomerAccount.Add(new SavingsAccount(balance, acctNum, interestRate));
                    }
                    else if (selection == 3)
                    {
                        Console.WriteLine("Please provide the following information to complete your loan account opening: ");
                        Console.WriteLine("Principal amount:");
                        balance = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("Account Number:");
                        acctNum = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Interest Rate as decimal: ");
                        interestRate = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Duration of loan (in months): ");
                        duration = Convert.ToInt32(Console.ReadLine());
                        CustomerAccount.Add(new LoanAccount(balance, acctNum, balance, interestRate, duration));
                    }
                    else if (selection == 4)
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }

        }

        //While each account class has its own ToString, this method is the only one that will ever call an account ToString
        // and it prints out all of the accounts for a single customer with this method
        public override string ToString()
        {
            string accounts = "";
            foreach(Account a in CustomerAccounts)
            {
                accounts += a.ToString();
            }
            string displayString = "Customer Number: " + CustomerNumber + "\tName: " + CustomerName + "\tAccounts: " + accounts;

            return displayString;
        }
    }
}
