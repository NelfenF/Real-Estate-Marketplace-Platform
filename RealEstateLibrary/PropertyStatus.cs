using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateLibrary;

namespace RealEstateLibrary
{
    public class PropertyStatus
    {
        private int statusID; // private int variable called statusID
        private int propertyID; // private int variable called propertyID
        private string currentStatus; // private string variable called currentStatus
        private DateTime lastUpdate; // private DateTime variable called lastUpdate

        public int StatusID // public int variable called StatusID
        {
            get { return statusID; } // returns the value of statusID variable
            set { statusID = value; } // sets the value of statusID variable to whatever is passed to it
        }

        public int PropertyID // public int variable called PropertyID
        {
            get { return propertyID; } // returns the value of propertyID variable
            set { propertyID = value; } // sets the value of propertyID variable to whatever is passed to it
        }

        public string CurrentStatus // public string variable called CurrentStatus
        { 
            get { return currentStatus; } // returns the value of currentStatus variable
            set { currentStatus = value; } // sets the value of currentStatus variable to whatever is passed to it
        }

        public DateTime LastUpdate // public DateTime object called LastUpdate
        {
            get { return lastUpdate; } // returns the value of lastUpdate object
            set { lastUpdate = value; } // sets the value of lastUpdate variable to whatever is passed to it
        }


        public PropertyStatus(int statusID, int propertyID, string currentStatus, DateTime lastUpdate) // public Statuses initalizer that accepts two int, string, and DateTime parameters
        {
            StatusID = statusID; // sets StatusID variable to the statusID parameter
            PropertyID = propertyID; // sets PropertyID variable to the propertyID parameter
            CurrentStatus = currentStatus; // sets CurrentStatus variable to the currentStatus parameter
            LastUpdate = lastUpdate; // sets LastUpdate object to the lastUpdate object
        }
    }
}
