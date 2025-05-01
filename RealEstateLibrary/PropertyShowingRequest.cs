using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateLibrary;

namespace RealEstateLibrary
{
    public class PropertyShowingRequest
    { 
        private int showingID; // private int variable called showingID
        private int propertyID; // private int variable called propertyID
        private string buyerFirstName; // private string variable called buyerFirstName
        private string buyerLastName; // private string variable called buyerLastName
        private string buyerEmail; // private string variable called buyerEmail
        private string buyerPhoneNumber; // private string variable called buyerPhoneNumber
        private DateTime preferredDayTime; // private DateTime object called preferredDayTime

        public int ShowingID // public int variable called ShowingID
        {
            get { return showingID; } // returns the value of showingID variable
            set { showingID = value; } // sets the value of showingID variable to whatever is passed to it
        }

        public int PropertyID // public int variable called PropertyID
        {
            get { return propertyID; } // returns the value of propertyID variable
            set { propertyID = value; } // sets the value of propertyID variable to whatever is passed to it
        }

        public string BuyerFirstName // public string variable called BuyerFirstName
        {   get { return buyerFirstName; } // returns the value of buyerFirstName variable
            set { buyerFirstName = value; }  // sets the value of buyerFirstName variable to whatever is passed to it
        }

        public string BuyerLastName // public string variable called BuyerLastName
        {
            get { return buyerLastName; } // returns the value of buyerLastName variable
            set { buyerLastName = value; } // sets the value of buyerLastName variable to whatever is passed to it
        }

        public string BuyerEmail // public string variable called BuyerEmail
        {
            get { return buyerEmail; } // returns the value of buyerEmail variable
            set { buyerEmail = value; } // sets the value of buyerEmail variable to whatever is passed to it
        }

        public string BuyerPhoneNumber // public string variable called BuyerPhoneNumber
        {
            get { return buyerPhoneNumber; } // returns the value of buyerPhoneNumber variable
            set { buyerPhoneNumber = value; } // sets the value of buyerPhoneNumber variable to whatever is passed to it
        }

        public DateTime PreferredDayTime // public int object called PreferredDayTime
        {
            get { return preferredDayTime; } // returns the value of preferredDayTime object
            set { preferredDayTime = value; } // sets the value of preferredDayTime object to whatever is passed to it
        }



        public PropertyShowingRequest(int showingID, int propertyID, string firstName, string lastName, string email, string phone, DateTime showingDay) // public PropertyShowingRequest initalizer that accepts a two ints, four strings, and a DateTime parameters
        {
            ShowingID = showingID; // sets ShowingID variable to the showingID parameter
            PropertyID = propertyID; // sets PropertyID variable to the propertyID parameter
            BuyerFirstName = firstName; // sets BuyerFirstName variable to the firstName parameter
            BuyerLastName = lastName; // sets BuyerLastName variable to the lastName parameter
            BuyerEmail = email; // sets BuyerEmail variable to the email parameter
            BuyerPhoneNumber = phone; // sets BuyerPhoneNumber variable to the phone parameter
            PreferredDayTime = showingDay; // sets PreferredDayTime variable to the showingDay parameter
        }

        public PropertyShowingRequest(int propertyID, string firstName, string lastName, string email, string phone, DateTime showingDay) // public PropertyShowingRequest initalizer that accepts a int, four strings, and a DateTime parameters
        {
            PropertyID = propertyID; // sets PropertyID variable to the propertyID parameter
            BuyerFirstName = firstName; // sets BuyerFirstName variable to the firstName parameter
            BuyerLastName = lastName; // sets BuyerLastName variable to the lastName parameter
            BuyerEmail = email; // sets BuyerEmail variable to the email parameter
            BuyerPhoneNumber = phone; // sets BuyerPhoneNumber variable to the phone parameter
            PreferredDayTime = showingDay; // sets PreferredDayTime variable to the showingDay parameter
        }


    }
}
