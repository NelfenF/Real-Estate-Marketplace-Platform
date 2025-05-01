using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary
{
    [Serializable]
    public class Account
    {
        private int accountID; // private int variable called accountID
        private string accountUsername; // private string variable called accountUsername
        private string accountPassword; // private string variable called accountPassword
        private string firstName; // private string variable called firstName
        private string lastName; // private string variable called lastName
        private string personalPhoneNumber; // private string variable called personalPhoneNumber
        private string personalEmail; // private string variable called personalEmail
        private int personalAddressZipCode; // private int variable called personalAddressZipCode
        private string personalAddressState; // private string variable called personalAddressState
        private string personalAddressCity; // private string variable called personalAddressCity
        private string personalAddress; // private string variable called personalAddress
        private int workAddressZipCode; // private int variable called workAddressZipCode
        private string workAddressState; // private string variable called workAddressState
        private string workAddressCity; // private string variable called workAddressCity
        private string workAddress; // private string variable called workAddress
        private string workPhoneNumber; // private string variable called workPhoneNumber
        private string workEmail; // private string variable called workEmail
        private string workName; // private string variable called workName

        public int AccountID // public int variable called AccountID
        {
            get { return accountID; } // returns the value of accountID variable
            set { accountID = value; } // sets the value of accountID variable to whatever is passed to it
        }

        public string AccountUsername // public int string called AccountUsername
        {
            get { return accountUsername; } // returns the value of accountUsername variable
            set { accountUsername = value; } // sets the value of accountUsername variable to whatever is passed to it
        }

        public string AccountPassword // public int string called AccountPassword
        {
            get { return accountPassword; } // returns the value of accountPassword variable
            set { accountPassword = value; } // sets the value of accountPassword variable to whatever is passed to it
        }

        public string FirstName // public int string called FirstName
        {
            get { return firstName; } // returns the value of firstName variable
            set { firstName = value; } // sets the value of firstName variable to whatever is passed to it
        }

        public string LastName // public int string called LastName
        {
            get { return lastName; } // returns the value of lastName variable
            set { lastName = value; } // sets the value of lastName variable to whatever is passed to it
        }

        public string PersonalPhoneNumber // public int string called PersonalPhoneNumber
        {
            get { return personalPhoneNumber; } // returns the value of personalPhoneNumber variable
            set { personalPhoneNumber = value; } // sets the value of personalPhoneNumber variable to whatever is passed to it
        }

        public string PersonalEmail // public int string called PersonalEmail
        {
            get { return personalEmail; } // returns the value of personalEmail variable
            set { personalEmail = value; } // sets the value of personalEmail variable to whatever is passed to it
        }

        public int PersonsalAddressZipCode // public int variable called PersonsalAddressZipCode
        {
            get { return personalAddressZipCode; } // returns the value of personalAddressZipCode variable
            set { personalAddressZipCode = value; } // sets the value of personalAddressZipCode variable to whatever is passed to it
        } 

        public string PersonalAddressState // public int string called PersonalAddressState
        {
            get { return personalAddressState; } // returns the value of personalAddressState variable
            set { personalAddressState = value; } // sets the value of personalAddressState variable to whatever is passed to it
        }

        public string PersonalAddressCity // public int string called PersonalAddressCity
        { 
            get { return personalAddressCity; } // returns the value of personalAddressCity variable
            set { personalAddressCity = value; } // sets the value of personalAddressCity variable to whatever is passed to it
        }

        public string PersonalAddress // public int string called PersonalAddress
        {
            get { return personalAddress; } // returns the value of personalAddress variable
            set { personalAddress = value; } // sets the value of personalAddress variable to whatever is passed to it
        }

        public int WorkAddressZipCode // public int variable called WorkAddressZipCode
        {
            get { return workAddressZipCode; } // returns the value of workAddressZipCode variable
            set { workAddressZipCode = value; } // sets the value of workAddressZipCode variable to whatever is passed to it
        }

        public string WorkAddressState // public int string called WorkAddressState
        {
            get { return workAddressState; } // returns the value of workAddressState variable
            set { workAddressState = value; } // sets the value of workAddressState variable to whatever is passed to it
        }

        public string WorkAddressCity // public int string called WorkAddressCity
        {
            get { return workAddressCity; } // returns the value of workAddressCity variable
            set { workAddressCity = value; } // sets the value of workAddressCity variable to whatever is passed to it
        }

        public string WorkAddress // public int string called WorkAddress
        {
            get { return workAddress; } // returns the value of workAddress variable
            set { workAddress = value; } // sets the value of workAddress variable to whatever is passed to it
        }

        public string WorkPhoneNumber // public int string called WorkPhoneNumber
        {
            get { return workPhoneNumber; } // returns the value of workPhoneNumber variable
            set { workPhoneNumber = value; } // sets the value of workPhoneNumber variable to whatever is passed to it
        }

        public string WorkEmail // public int string called WorkEmail
        { 
            get { return workEmail; } // returns the value of workEmail variable
            set { workEmail = value; } // sets the value of workEmail variable to whatever is passed to it
        }

        public string WorkName // public int string called WorkName
        {
            get { return workName; } // returns the value of workName variable
            set { workName = value; } // sets the value of workName variable to whatever is passed to it
        }

        public Account(int id, string user, string pass, string fname, string lname, string pNumber, string pEmail, int pZip, string pState, string pCity, string pAddress, int wZip, string wState, string wCity, string wAddress, string wNumber, string wEmail, string wName) // public Account initalizer that accetps 3 ints and 15 strings as parameters
        {
            AccountID = id; // sets AccountID to the id parameter
            AccountUsername = user; // sets AccountUsername to the user parameter
            AccountPassword = pass; // sets AccountPassword to the pass parameter
            FirstName = fname; // sets FirstName to the fname parameter
            LastName = lname; // sets LastName to the lname parameter
            PersonalPhoneNumber = pNumber; // sets PersonalPhoneNumber to the pNumber parameter
            PersonalEmail = pEmail; // sets PersonalEmail to the pEmail parameter
            PersonsalAddressZipCode = pZip; // sets PersonsalAddressZipCode to the pZip parameter
            PersonalAddressState = pState; // sets PersonalAddressState to the pState parameter
            PersonalAddressCity = pCity; // sets PersonalAddressCity to the pCity parameter
            PersonalAddress = pAddress; // sets PersonalAddress to the pAddress parameter
            WorkAddressZipCode = wZip; // sets WorkAddressZipCode to the wZip parameter
            WorkAddressState = wState; // sets WorkAddressState to the wState parameter
            WorkAddressCity = wCity; // sets WorkAddressCity to the wCity parameter
            WorkAddress = wAddress; // sets WorkAddress to the wAddress parameter
            WorkPhoneNumber = wNumber; // sets WorkPhoneNumber to the wNumber parameter
            WorkEmail = wEmail;// sets WorkEmail to the wEmail parameter
            WorkName = wName; // sets WorkName to the wName parameter

        }

    }
}
