using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateLibrary;

namespace RealEstateLibrary
{
    public class PropertyPriceHistory
    {
        private int priceHistoryID; // private int variable called priceHistoryID
        private int propertyID; // private int variable called propertyID
        private decimal newPrice; // private decimal variable called newPrice
        private DateTime priceUpdateDate; // private DateTime object called priceUpdateDate

        public int PriceHistoryID // public int variable called PriceHistoryID
        { 
            get { return priceHistoryID; } // returns the value of priceHistoryID variable
            set { priceHistoryID = value; } // sets the value of priceHistoryID variable to whatever is passed to it
        }

        public int PropertyID // public int variable called PropertyID
        { 
            get { return propertyID; } // returns the value of propertyID variable
            set { propertyID = value; } // sets the value of propertyID variable to whatever is passed to it
        }

        public decimal NewPrice // public decimal variable called NewPrice
        { 
            get { return newPrice; } // returns the value of newPrice variable
            set { newPrice = value; } // sets the value of newPrice variable to whatever is passed to it
        }

        public DateTime PriceUpdateDate // public DateTime object called PriceUpdateDate
        {
            get { return priceUpdateDate; } // returns the value of priceUpdateDate object
            set { priceUpdateDate = value; } // sets the value of priceUpdateDate object to whatever is passed to it
        }

        public PropertyPriceHistory(int historyID, int propertyID, decimal newPrice, DateTime updateDate) // public PropertyPriceHistory initalizer that accepts a two ints, a decimal and DateTime parameter
        {
            PriceHistoryID = historyID; // sets PriceHistoryID variable to the historyID parameter
            PropertyID = propertyID; // sets PropertyID variable to the propertyID parameter
            NewPrice = newPrice; // sets NewPrice variable to the newPrice parameter
            PriceUpdateDate = updateDate; // sets PriceUpdateDate variable to the updateDate parameter
        }

        public PropertyPriceHistory(int propertyID, decimal newPrice, DateTime updateDate) // public PropertyPriceHistory initalizer that accepts a int, a decimal and DateTime parameter
        {
            PropertyID = propertyID; // sets PropertyID variable to the propertyID parameter
            NewPrice = newPrice; // sets NewPrice variable to the newPrice parameter
            PriceUpdateDate = updateDate; // sets PriceUpdateDate variable to the updateDate parameter
        }

    }
}
