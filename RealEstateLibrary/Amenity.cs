using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateLibrary;

namespace RealEstateLibrary
{
    public class Amenity
    {
        private int amenityID; // private int variable called amenityID
        private string amenityName; // private string variable called amenityName

        public int AmenityID // public int variable called AmenityID
        {
            get { return amenityID; } // returns the value of amenityID variable
            set {amenityID = value; } // sets the value of amenityID variable to whatever is passed to it
        }

        public string AmenityName // public int string called AmenityName
        {
            get { return amenityName; } // returns the value of amenityName variable
            set { amenityName = value; } // sets the value of amenityName variable to whatever is passed to it
        }

        public Amenity(int amenityID, string amenity) // public Amenity initalizer that accepts a int and string parameter
        {
            AmenityID = amenityID; // sets AmenityID variable to the amenityID parameter
            AmenityName = amenity; // sets AmenityName variable to the amenity parameter
        }
    }
}
