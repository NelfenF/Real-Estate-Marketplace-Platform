using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateLibrary;

namespace RealEstateLibrary
{
    public class AccountLoginController
    {
        private AccountList allAccountsList; // private AccountList object called allAccountsList
        private AccountLogin currentLogin; // private AccountLogin object called currentLogin
        private List<Account> allAccounts; // private List object of Account objects called allAccounts

        public AccountLoginController() // public AccountLoginController initalizer 
        {
            allAccountsList = new AccountList(); // sets allAccountsList to a new AccountList object
            allAccounts = allAccountsList.GetAllAccounts(); // sets allAccounts to the returned value of GetAllAccounts function from the allAccountsList object
        }

        public void ResetAllAccounts() // public ResetAllAccounts function
        {
            allAccountsList = new AccountList(); // sets allAccountsList to a new AccountList object
            allAccounts = allAccountsList.GetAllAccounts(); // sets allAccounts to the returned value of GetAllAccounts function from the allAccountsList object
        }

        public void AccountLogin(string uName, string uPass) // public AccountLogin function that accepts two strings as parameters
        {
            allAccountsList = new AccountList(); // sets allAccountsList to a new AccountList object
            allAccounts = allAccountsList.GetAllAccounts(); // sets allAccounts to the returned value of GetAllAccounts function from the allAccountsList object
            currentLogin = new AccountLogin(uName, uPass, allAccounts); // sets currentLogin to a new AccountLogin object with uName, uPass, and allAccounts as parameters
        }

        public bool IsLoginValid() // public IsLoginValid function that returns a bool
        {
            if (currentLogin == null) // if currentLogin object is null then
            {
                return false; // return false
            }
            else // else a valid currentLogin object is present
            {
                return currentLogin.IsLoginValid(); // returns the returned value of IsLoginValid function from the currentLogin object
            }
        }

        public Account GetCurrentLoggedInAccount() // public GetCurrentLoggedInAccount function that returns a Account object
        {
            return currentLogin.GetCurrentLoggedInAccount(); // returns the returned value of GetCurrentLoggedInAccount function from the currentLogin object
        }

        public void MakeNewAccount(Dictionary<string, string> newAccInfo) // public MakeNewAccount function that accepts a String dictionary as parameters
        {
            allAccountsList.MakeNewAccount(newAccInfo); // calls the MakeNewAccount function from the allAccountsList object with newAccInfo as a parameter
        }

    }
}
