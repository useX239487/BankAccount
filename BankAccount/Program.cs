using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // add for file processing

namespace BankAccount
{
    class Program
    {
        static List<Customer> Customers = new List<Customer>();
        static List<Account> Accounts = new List<Account>();
        static void Main(string[] args)
        {
            //Reading in files, these methods automatically add the read data into the lists.
            ReadAccountFile();
            ReadCustomerFile();


            int selection=0;
            Customer interacting;
            int custNum;

            //Menu
            while (selection != 5)
            {
                Console.WriteLine("1. Add an account");
                Console.WriteLine("2. View account balances");
                Console.WriteLine("3. (admin)View all Account Balances");
                Console.WriteLine("4. Add new customer");
                Console.WriteLine("5. Exit");
                selection = Convert.ToInt32(Console.ReadLine());

                if(selection == 1)
                {
                    Console.WriteLine("Please enter your customer number:");
                    custNum = Convert.ToInt32(Console.ReadLine());
                    interacting = FindCustomer(custNum);
                    if(interacting != null)
                        interacting.AddAccount();
                }
                else if(selection == 2)
                {
                    Console.WriteLine("Please enter your customer number:");
                    custNum = Convert.ToInt32(Console.ReadLine());
                    interacting = FindCustomer(custNum);
                    if (interacting != null)
                        Console.WriteLine(interacting.ToString());
                }
                else if(selection ==3)
                {
                    foreach (Customer c in Customers)
                        Console.WriteLine(c.ToString());
                }
                else if (selection == 4)
                {
                    Console.Write("Please enter new customer name: ");
                    string newCus = Console.ReadLine();
                    int cusNum = 1;
                    {
                        cusNum += Customers.Last().CustomerNumber;
                    }
                    Customers.Add(new Customer(cusNum, newCus, new List<Account>()));
                    Console.WriteLine("New Customer Info:" + Customers.Last().ToString());
                }



                Console.WriteLine();
            }
        }

        //Customer file reader, this reader only allows for each customer to start 
        //with 1 account of each type.
        static public void ReadCustomerFile()
        {
            string[] fileLines = File.ReadAllLines("Proj6Cust.csv");
            string name;
            int number, acctID;
            List<Account> thisCust = new List<Account>();
            foreach (string s in fileLines)
            {
                thisCust = new List<Account>();
                string[] cells = s.Split(',');
                // Cell 0 contains the customer number
                number = (Convert.ToInt32(cells[0]));
                // cell 1 contains the name
                name = (cells[1].Trim());
                // cells 2-4 contain identifiers for where in the list of accounts their account is located, 1 cell for each account type
                // if the cell contains -1, then the customer does not have an account of this type
                for(int i=2; i<=4; i++)
                {
                    acctID = Convert.ToInt32(cells[i].Trim());
                    if (acctID != -1)
                    {
                        thisCust.Add(Accounts[acctID]);
                    }
                }
                Customers.Add(new Customer(number, name, thisCust));
            }
        }
        //Accounts file reader
        //This makes an assumption that all accounts have been entered correctly
        //This must be run before the customer reader in order for that to be able
        //to connect the accounts with their customers.
        static public void ReadAccountFile()
        {
            string[] fileLines = File.ReadAllLines("Proj6Acct.csv");
            int accountID, number, duration, credit;
            decimal balance;
            double IR;
            foreach (string s in fileLines)
            {
                string[] cells = s.Split(',');
                // Cell 0 contains the account identifier
                // 0 = Checking, 1 = Loan, 2 = Savings
                accountID = Convert.ToInt32(cells[0].Trim());
                if(accountID == 0)
                {
                    //cell 1 contains balance
                    balance = Convert.ToDecimal(cells[1].Trim());
                    //cell 2 contains acct num
                    number = Convert.ToInt32(cells[2].Trim());
                    //cell 3 contains credit limit
                    credit = Convert.ToInt32(cells[3].Trim());
                    Accounts.Add(new CheckingAccount(balance, number, credit));
                }
                else if(accountID == 1)
                {
                    //cell 1 contains balance (which will also be starting principal
                    balance = Convert.ToDecimal(cells[1].Trim());
                    //cell 2 contains acct num
                    number = Convert.ToInt32(cells[2].Trim());
                    //cell 4 contains Interest rate
                    IR = Convert.ToDouble(cells[4].Trim());
                    //cell 5 contains duration
                    duration = Convert.ToInt32(cells[5].Trim());
                    Accounts.Add(new LoanAccount(balance, number, balance, IR, duration));
                }
                //Assuming at this point that it must be a savings account
                else 
                {
                    //cell 1 contains balance
                    balance = Convert.ToDecimal(cells[1].Trim());
                    //cell 2 contains acct num
                    number = Convert.ToInt32(cells[2].Trim());
                    //cell 3 contains IR
                    IR = Convert.ToDouble(cells[3].Trim());
                    Accounts.Add(new SavingsAccount(balance, number, IR));
                }
            }
        }

        //Method to search for and return a customer, given their customer number
        static public Customer FindCustomer(int CustNum)
        {
            foreach(Customer c in Customers)
            {
                if (c.CustomerNumber == CustNum)
                {
                    return c;
                }
                    
            }
            Console.WriteLine("I was unable to find a customer with this number.");
            return null;
        }
    }
}
