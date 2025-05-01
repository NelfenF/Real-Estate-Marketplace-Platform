using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateLibrary;
namespace RealEstateLibrary
{
    internal class AccountList
    {
        private DBConnect databaseHandler = new DBConnect(); // private DBConnect object called databaseHandler set to a new DBConnect object
        private List<Account> accounts; // private List of Account objects called accounts
        public AccountList()  // public AccountList object initializer
        {
            accounts = new List<Account>(); // sets accounts to a new List of Account objects
            SqlCommand selectProcedure = new SqlCommand(); // SqlCommand object called selectProcedure set to a new SqlCommand object
            selectProcedure.CommandType = CommandType.StoredProcedure; // sets selectProceudre's CommandType to the StoredProcedure command type
            selectProcedure.CommandText = "SelectAllRegisteredAccounts"; // sets selectProceudre's CommandText to SelectAllRegisteredAccounts
            DataTable accountData = databaseHandler.GetDataSet(selectProcedure).Tables[0]; // DataTable object called accountData set to the first table of the returned value of GetDataSet function from the databaseHandler object with the selectProceudre as a parameter

            foreach (DataRow row in accountData.Rows) // foreach DataRow called row in accountData's rows do
            {
                accounts.Add(new Account((int)row["AccountID"], row["AccountUsername"].ToString(), row["AccountPassword"].ToString(), row["FirstName"].ToString(), row["LastName"].ToString(), row["PersonalPhoneNumber"].ToString(), row["PersonalEmail"].ToString(), (int)row["PersonalAddressZipCode"], row["PersonalAddressState"].ToString(), row["PersonalAddressCity"].ToString(), row["PersonalAddress"].ToString(), (int)row["WorkAddressZipCode"], row["WorkAddressState"].ToString(), row["WorkAddressCity"].ToString(), row["WorkAddress"].ToString(), row["WorkPhoneNumber"].ToString(), row["WorkEmail"].ToString(), row["WorkName"].ToString()));
            }
        }

        public List<Account> GetAllAccounts() // public GetAllAccounts function that returns a List of Account objects
        {
            return accounts; // returns accounts list object
        }

        public Account GetAccountByAccountID(int id) // public GetAccountByAccountID that accepts a int parameter and returns a Account object
        {
            foreach (Account agent in accounts) // foreach Account object called agent in accounts list object do
            {
                if (agent.AccountID == id) // if the current agent objects AccountID is equal to the passed id then
                {
                    return agent; // returns the current agent object
                }
            }
            return null; // returns null if no account is found
        }

        public void MakeNewAccount(Dictionary<string, string> newAccountInfo) // public MakeNewAccount function that accepts a string dictionary
        {
            SqlCommand insertProcedure = new SqlCommand(); // SqlCommand object called insertProcedure set to a new SqlCommand object
            insertProcedure.CommandType = CommandType.StoredProcedure; // sets insertProcedure's CommandType to the StoredProcedure command type
            insertProcedure.CommandText = "InsertNewRegisteredAccount"; // sets insertProcedure's CommandText to InsertNewRegisteredAccount
            insertProcedure.Parameters.AddWithValue("@AccountUsername", newAccountInfo["Username"]); // Adds a parameter with value to the insertProcedure object with @AccountUsername as the name and the newAccountInfo dictionarys Username as the value
            insertProcedure.Parameters.AddWithValue("@AccountPassword", newAccountInfo["Password"]); // Adds a parameter with value to the insertProcedure object with @AccountPassword as the name and the newAccountInfo dictionarys Password as the value
            insertProcedure.Parameters.AddWithValue("@FirstName", newAccountInfo["Firstname"]);  // Adds a parameter with value to the insertProcedure object with @FirstName as the name and the newAccountInfo dictionarys Firstname as the value
            insertProcedure.Parameters.AddWithValue("@LastName", newAccountInfo["Lastname"]); // Adds a parameter with value to the insertProcedure object with @LastName as the name and the newAccountInfo dictionarys Lastname as the value
            insertProcedure.Parameters.AddWithValue("@PersonalPhoneNumber", newAccountInfo["PeronsalPhone"]); // Adds a parameter with value to the insertProcedure object with @PersonalPhoneNumber as the name and the newAccountInfo dictionarys PeronsalPhone as the value
            insertProcedure.Parameters.AddWithValue("@PersonalEmail", newAccountInfo["PeronsalEmail"]); // Adds a parameter with value to the insertProcedure object with @PersonalEmail as the name and the newAccountInfo dictionarys PeronsalEmail as the value
            insertProcedure.Parameters.AddWithValue("@PersonalAddressZipCode", int.Parse(newAccountInfo["PeronsalZip"])); // Adds a parameter with value to the insertProcedure object with @PersonalAddressZipCode as the name and the newAccountInfo dictionarys PerosonalZip converted to an int as the value
            insertProcedure.Parameters.AddWithValue("@PersonalAddressState", newAccountInfo["PersonalState"]); // Adds a parameter with value to the insertProcedure object with @PersonalAddressState as the name and the newAccountInfo dictionarys PersonalState as the value
            insertProcedure.Parameters.AddWithValue("@PersonalAddressCity", newAccountInfo["PeronsalCity"]); // Adds a parameter with value to the insertProcedure object with @PersonalAddressCity as the name and the newAccountInfo dictionarys PeronsalCity as the value
            insertProcedure.Parameters.AddWithValue("@PersonalAddress", newAccountInfo["PeronsalAddress"]); // Adds a parameter with value to the insertProcedure object with @PersonalAddress as the name and the newAccountInfo dictionarys PeronsalAddress as the value
            insertProcedure.Parameters.AddWithValue("@WorkAddressZipCode", int.Parse(newAccountInfo["WorkZip"])); // Adds a parameter with value to the insertProcedure object with @WorkAddressZipCode as the name and the newAccountInfo dictionarys WorkZip converted to an int as the value
            insertProcedure.Parameters.AddWithValue("@WorkAddressState", newAccountInfo["WorkState"]); // Adds a parameter with value to the insertProcedure object with @WorkAddressState as the name and the newAccountInfo dictionarys WorkState as the value
            insertProcedure.Parameters.AddWithValue("@WorkAddressCity", newAccountInfo["WorkCity"]); // Adds a parameter with value to the insertProcedure object with @WorkAddressCity as the name and the newAccountInfo dictionarys WorkCity as the value
            insertProcedure.Parameters.AddWithValue("@WorkAddress", newAccountInfo["WorkAddress"]); // Adds a parameter with value to the insertProcedure object with @WorkAddress as the name and the newAccountInfo dictionarys WorkAddress as the value
            insertProcedure.Parameters.AddWithValue("@WorkPhoneNumber", newAccountInfo["WorkPhone"]); // Adds a parameter with value to the insertProcedure object with @WorkPhoneNumber as the name and the newAccountInfo dictionarys WorkPhone as the value
            insertProcedure.Parameters.AddWithValue("@WorkEmail", newAccountInfo["WorkEmail"]); // Adds a parameter with value to the insertProcedure object with @WorkEmail as the name and the newAccountInfo dictionarys WorkEmail as the value
            insertProcedure.Parameters.AddWithValue("@WorkName", newAccountInfo["WorkName"]); // Adds a parameter with value to the insertProcedure object with @WorkName as the name and the newAccountInfo dictionarys WorkName as the value
            databaseHandler.DoUpdate(insertProcedure); // calls the DoUpdated function from the databaseHandler object with insertProcedure as a parameter
        }

    }
}
