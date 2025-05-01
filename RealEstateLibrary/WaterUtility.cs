using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateLibrary;

namespace RealEstateLibrary
{
    public class WaterUtility
    {
        private int waterUtilityID; // private int variable called waterUtilityID
        private string waterUtilityName; // private string variable called waterUtilityName

        public int WaterUtilityID // public int variable called WaterUtilityID
        {
            get { return waterUtilityID; } // gets the value of waterUtilityID variable
            set { waterUtilityID = value; } // sets the value of waterUtilityID variable to whatever is passed to it
        }

        public string WaterUtilityName // public string variable called WaterUtilityName
        {
            get { return waterUtilityName; } // gets the value of waterUtilityName variable
            set { waterUtilityName = value; } // sets the value of waterUtilityName variable to whatever is passed to it
        }

        public WaterUtility(int id, string name) // public WaterUtility initalizer that accepts a int and string parameter
        {
            WaterUtilityID = id; // sets WaterUtilityID variable to the id parameter
            WaterUtilityName = name; // sets WaterUtilityName variable to the id name
        }
    }
}
