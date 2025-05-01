using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateLibrary;

namespace RealEstateLibrary
{
    public class AccountLogin
    {
        private string accountUsername; // private string variable called accountUsername
        private string accountPassword; // private string variable called accountPassword
        private bool isValidAccount = false; // private bool called isValidAccount set to false
        private Account currentLoggedInAccount; // private Account object called currentLoggedInAccount
        public AccountLogin(string uName, string uPass, List<Account> allAccounts) // public AccountLogin initalizer that accepts two strings and a List of account objects
        {
            if (CheckUserAccount(uName, uPass, allAccounts) == true) // if the retuned value of CheckUSerAccount is equal to true with uName, uPass, and allAccounts as parameters then
            {
                accountUsername = uName; // sets accountUsername to uName
                accountPassword = uPass; // sets accountPassword to uPass
                isValidAccount = true; // sets isValidAccount to true
            } 
            else // else CheckUserAccount returns false
            {
                isValidAccount = false; // sets isValidAccount to false
            }
        }

        private bool CheckUserAccount(string userName, string userPass, List<Account> allAccounts) // private CheckUserAccount that returns a bool and accepts two strings and a List of Account objects as parameters
        {
            foreach(Account userAccount in allAccounts) // foreach Account object called userAccount in allAccounts list object do
            {
                if(userAccount.AccountUsername == userName) // if the current userAccount objects AccountUsername is equal to the passed userName then
                {
                    if(userAccount.AccountPassword== userPass)  // if the current userAccount objects AccountPassword is equal to the passed userPass then
                    {
                        currentLoggedInAccount = userAccount; // sets currentLoggedInAccount to the current userAccount object
                        return true; // returns true
                    }
                }
            }
            return false; // returns false
        }

        public bool IsLoginValid() // public IsLoginValid function that returns a bool
        {
            return isValidAccount; // returns isValidAccount 
        }

        public Account GetCurrentLoggedInAccount() // public GetCurrentLoggedInAccount function that returns a Account object
        {
            return currentLoggedInAccount; // returns currentLoggedInAccount object
        }


    }
}
