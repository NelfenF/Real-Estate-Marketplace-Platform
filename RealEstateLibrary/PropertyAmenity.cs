using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateLibrary;

namespace RealEstateLibrary
{
    public class PropertyAmenity
    {
        private int amenityPropertyID; // private int variable called amenityPropertyID
        private int amenityID; // private int variable called amenityID
        private int propertyID; // private int variable called propertyID

        public int AmenityPropertyID // public int variable called AmenityPropertyID
        {
            get { return amenityPropertyID; } // returns the value of amenityPropertyID variable
            set { amenityPropertyID = value; } // sets the value of amenityPropertyID variable to whatever is passed to it
        }

        public int AmenityID // public int variable called AmenityID
        {
            get { return amenityID; } // returns the value of amenityID variable
            set { amenityID = value; } // sets the value of amenityID variable to whatever is passed to it
        }

        public int PropertyID // public int variable called PropertyID
        {
            get { return propertyID; } // returns the value of propertyID variable
            set { propertyID = value; } // sets the value of propertyID variable to whatever is passed to it
        }


        public PropertyAmenity(int amenityPropertID, int propertyAmenityID, int propertyID) // public Statuses initalizer that accepts three int parameter
        {
            AmenityPropertyID = amenityPropertID; // sets AmenityPropertyID variable to the amenityPropertID parameter
            AmenityID = propertyAmenityID; // sets AmenityID variable to the propertyAmenityID parameter
            PropertyID = propertyID; // sets PropertyID variable to the propertyID parameter

        }

    }
}
