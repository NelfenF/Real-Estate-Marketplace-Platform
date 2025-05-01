using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateLibrary;

namespace RealEstateLibrary
{
    public class SewerUtility
    {
        private int sewerUtilityID; // private int variable called sewerUtilityID
        private string sewerUtilityName; // private string variable called sewerUtilityName

        public int SewerUtilityID // public int variable called SewerUtilityID
        {
            get { return sewerUtilityID; } // returns the value of sewerUtilityID variable
            set { sewerUtilityID = value; } // sets the value of sewerUtilityID variable to whatever is passed to it
        }

        public string SewerUtilityName // public string variable called SewerUtilityName
        {
            get { return sewerUtilityName; } // returns the value of sewerUtilityName variable
            set { sewerUtilityName = value; } // sets the value of sewerUtilityName variable to whatever is passed to it
        }

        public SewerUtility(int id, string name) // public SewerUtility initalizer that accepts a int and string parameter
        {
            SewerUtilityID = id; // sets SewerUtilityID variable to the id parameter
            SewerUtilityName = name; // sets SewerUtilityName variable to the id parameter
        }
    }
}
