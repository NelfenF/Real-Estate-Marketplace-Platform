using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateLibrary;

namespace RealEstateLibrary
{
    public class PropertyOffer
    { 
        private int offerID; // private int variable called offerID
        private int propertyID; // private int variable called propertyID
        private string buyerFirstName; // private string variable called buyerFirstName
        private string buyerLastName; // private string variable called buyerLastName
        private decimal offerAmount; // private decimal variable called offerAmount
        private string offerType; // private string variable called offerType
        private string buyerPhoneNumber; // private string variable called buyerPhoneNumber
        private string buyerEmail; // private string variable called buyerEmail
        private string sellCurrentHouse; // private string variable called sellCurrentHouse
        private DateTime moveInDate; // private DateTime object called moveInDate
        private DateTime offerDate; // private DateTime object called offerDate

        public int OfferID // public int variable called OfferID
        {
            get { return offerID; } // returns the value of offerID variable
            set { offerID = value; } // sets the value of offerID variable to whatever is passed to it
        }

        public int PropertyID // public int variable called PropertyID
        {
            get { return propertyID; } // returns the value of propertyID variable
            set { propertyID = value; } // sets the value of propertyID variable to whatever is passed to it
        }

        public string BuyerFirstName // public string variable called BuyerFirstName
        {
            get { return buyerFirstName; } // returns the value of buyerFirstName variable
            set { buyerFirstName = value; } // sets the value of buyerFirstName variable to whatever is passed to it
        }

        public string BuyerLastName // public string variable called BuyerLastName
        {
            get { return buyerLastName; } // returns the value of buyerLastName variable
            set { buyerLastName = value; } // sets the value of buyerLastName variable to whatever is passed to it
        } 

        public decimal OfferAmount // public decimal variable called OfferAmount
        {
            get { return offerAmount; } // returns the value of offerAmount variable
            set { offerAmount = value; } // sets the value of offerAmount variable to whatever is passed to it
        }

        public string OfferType // public string variable called OfferType
        {
            get { return offerType; } // returns the value of offerType variable
            set { offerType = value; } // sets the value of offerType variable to whatever is passed to it
        }

        public string BuyerPhoneNumber // public string variable called BuyerPhoneNumber
        {
            get { return buyerPhoneNumber; } // returns the value of buyerPhoneNumber variable
            set { buyerPhoneNumber = value; } // sets the value of buyerPhoneNumber variable to whatever is passed to it
        }

        public string BuyerEmail // public string variable called BuyerEmail
        {
            get { return buyerEmail; } // returns the value of buyerEmail variable
            set { buyerEmail = value; } // sets the value of buyerEmail variable to whatever is passed to it
        }

        public string SellCurrentHouse // public string variable called SellCurrentHouse
        {
            get { return sellCurrentHouse; } // returns the value of sellCurrentHouse variable
            set { sellCurrentHouse = value; } // sets the value of sellCurrentHouse variable to whatever is passed to it
        }

        public DateTime MoveInDate // public DateTime object called MoveInDate
        {
            get { return moveInDate; } // returns the value of moveInDate object
            set { moveInDate = value; } // sets the value of moveInDate object to whatever is passed to it
        }

        public DateTime OfferDate // public DateTime object called OfferDate
        {
            get { return offerDate; } // returns the value of offerDate object
            set { offerDate = value; } // sets the value of offerDate object to whatever is passed to it
        }


        public PropertyOffer(int offerID, int propertyID, string firstName, string lastName, decimal offerAmount, string offerType, string phone, string email, string sellHouse, DateTime moveInDate, DateTime offerDate) // public PropertyOffer initalizer that accepts two ints, six strings, a decimal, and two DateTime parameter
        {
            OfferID = offerID; // sets OfferID variable to the offerID parameter
            PropertyID = propertyID; // sets PropertyID variable to the propertyID parameter
            BuyerFirstName = firstName; // sets BuyerFirstName variable to the firstName parameter
            BuyerLastName = lastName; // sets BuyerLastName variable to the lastName parameter
            OfferAmount = offerAmount; // sets OfferAmount variable to the offerAmount parameter
            OfferType = offerType; // sets OfferType variable to the offerType parameter
            BuyerPhoneNumber = phone; // sets BuyerPhoneNumber variable to the phone parameter
            BuyerEmail = email; // sets BuyerEmail variable to the email parameter
            SellCurrentHouse = sellHouse; // sets SellCurrentHouse variable to the sellHouse parameter
            MoveInDate = moveInDate; // sets MoveInDate variable to the moveInDate parameter
            OfferDate = offerDate; // sets OfferDate variable to the offerDate parameter
        }

        public PropertyOffer(int propertyID, string firstName, string lastName, decimal offerAmount, string offerType, string phone, string email, string sellHouse, DateTime moveInDate) // public PropertyOffer initalizer that accepts two ints, five strings, a decimal, and a DateTime parameter
        {
            PropertyID = propertyID; // sets PropertyID variable to the propertyID parameter
            BuyerFirstName = firstName; // sets BuyerFirstName variable to the firstName parameter
            BuyerLastName = lastName; // sets BuyerLastName variable to the lastName parameter
            OfferAmount = offerAmount; // sets OfferAmount variable to the offerAmount parameter
            OfferType = offerType; // sets OfferType variable to the offerType parameter
            BuyerPhoneNumber = phone; // sets BuyerPhoneNumber variable to the phone parameter
            BuyerEmail = email; // sets BuyerEmail variable to the email parameter
            SellCurrentHouse = sellHouse; // sets SellCurrentHouse variable to the sellHouse parameter
            MoveInDate = moveInDate; // sets MoveInDate variable to the moveInDate parameter
        }
    }
}
