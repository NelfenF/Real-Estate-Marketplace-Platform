using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateLibrary;

namespace RealEstateLibrary
{
    public class PropertyImage
    {
        private int imageID; // private int variable called imageID
        private int propertyID; // private int variable called propertyID
        private string imageURL; // private string variable called imageURL
        private string imageDescription; // private string variable called imageDescription

        public int ImageID // public int variable called ImageID
        { 
            get { return imageID; } // returns the value of imageID variable
            set { imageID = value; } // sets the value of imageID variable to whatever is passed to it
        }

        public int PropertyID // public int variable called PropertyID
        {
            get { return propertyID; }  // returns the value of propertyID variable
            set { propertyID = value; } // sets the value of propertyID variable to whatever is passed to it
        }

        public string ImageURL // public string variable called ImageURL
        {
            get { return imageURL; } // returns the value of imageURL variable
            set { imageURL = value; } // sets the value of imageURL variable to whatever is passed to it
        }

        public string ImageDescription // public string variable called ImageDescription
        {
            get { return imageDescription; } // returns the value of imageDescription variable
            set { imageDescription = value; } // sets the value of imageDescription variable to whatever is passed to it
        }

        public PropertyImage(int imgID, int propertyID, string imgURL, string caption) // public PropertyImage initalizer that accepts two ints and two string parameter
        {
            ImageID = imgID; // sets ImageID variable to the imgID parameter
            PropertyID = propertyID; // sets PropertyID variable to the propertyID parameter
            ImageURL = imgURL; // sets ImageURL variable to the imgURL parameter
            ImageDescription = caption; // sets ImageDescription variable to the caption parameter
        }

        public PropertyImage(int propertyID, string imgURL, string caption) // public PropertyImage initalizer that accepts a int and two string parameter
        {
            PropertyID = propertyID; // sets PropertyID variable to the propertyID parameter
            ImageURL = imgURL; // sets ImageURL variable to the imgURL parameter
            ImageDescription = caption; // sets ImageDescription variable to the caption parameter
        }

        public PropertyImage(string imgURL, string caption) // public PropertyImage initalizer that accepts two string parameter
        {
            ImageURL = imgURL; // sets ImageURL variable to the imgURL parameter
            ImageDescription = caption; // sets ImageDescription variable to the caption parameter
        }
    }
}
