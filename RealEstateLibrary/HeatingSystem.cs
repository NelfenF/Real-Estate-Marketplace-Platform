using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateLibrary;

namespace RealEstateLibrary
{
    public class HeatingSystem
    { 
        private int heatingSystemID; // private int variable called heatingSystemID
        private string heatingSystemName; // private string variable called heatingSystemName

        public int HeatingSystemID // public int variable called HeatingSystemID
        {
            get { return heatingSystemID; } // returns the value of heatingSystemID variable
            set { heatingSystemID = value; } // sets the value of heatingSystemID variable to whatever is passed to it
        }

        public string HeatingSystemName // public string variable called HeatingSystemName
        {
            get { return heatingSystemName; } // returns the value of heatingSystemName variable
            set { heatingSystemName = value; } // sets the value of heatingSystemName variable to whatever is passed to it
        }

        public HeatingSystem(int id, string name) // public HeatingSystem initalizer that accepts a int and string parameter
        {
            HeatingSystemID = id; // sets HeatingSystemID variable to the id parameter
            HeatingSystemName = name; // sets HeatingSystemName variable to the name parameter
        }
    }
}
