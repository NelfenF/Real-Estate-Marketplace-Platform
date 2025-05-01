using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateLibrary;

namespace RealEstateLibrary
{
    public class PropertyOfferStatus
    {
        private int statusID; // private int variable called statusID
        private int offerID; // private int variable called offerID
        private string currentStatus; // private string variable called currentStatus

        public int StatusID // public int variable called StatusID
        {
            get { return statusID; } // returns the value of statusID variable
            set { statusID = value; } // sets the value of statusID variable to whatever is passed to it
        }

        public int OfferID // public int variable called OfferID
        { 
            get { return offerID; } // returns the value of offerID variable
            set { offerID = value; } // sets the value of offerID variable to whatever is passed to it
        }

        public string CurrentStatus // public string variable called CurrentStatus
        {
            get { return currentStatus; } // returns the value of currentStatus variable
            set { currentStatus = value; } // sets the value of currentStatus variable to whatever is passed to it
        }

        public PropertyOfferStatus(int statusID, int offerID, string status) // public Statuses initalizer that accepts two ints and string parameter
        {
            StatusID = statusID; // sets StatusID variable to the statusID parameter
            OfferID = offerID; // sets OfferID variable to the offerID parameter
            CurrentStatus = status; // sets CurrentStatus variable to the status parameter
        }

        public PropertyOfferStatus(int offerID, string status) // public Statuses initalizer that accepts a int and string parameter
        {
            OfferID = offerID; // sets OfferID variable to the offerID parameter
            CurrentStatus = status; // sets CurrentStatus variable to the status parameter
        }
    }
}
