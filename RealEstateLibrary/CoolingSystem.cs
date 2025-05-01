using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateLibrary;

namespace RealEstateLibrary
{
    public class CoolingSystem
    {
        private int coolingSystemID; // private int variable called heatingSystemID
        private string coolingSystemName; // private int variable string coolingSystemName

        public int CoolingSystemID // public int variable called CoolingSystemID
        { 
            get { return coolingSystemID; } // returns the value of coolingSystemID variable
            set { coolingSystemID = value; } // sets the value of coolingSystemID variable to whatever is passed to it
        }

        public string CoolingSystemName // public string variable called CoolingSystemName
        {
            get { return coolingSystemName; } // returns the value of coolingSystemName variable
            set { coolingSystemName = value; } // sets the value of coolingSystemName variable to whatever is passed to it
        }

        public CoolingSystem(int id, string name) // public CoolingSystem initalizer that accepts a int and string parameter
        {
            CoolingSystemID = id; // sets CoolingSystemID variable to the id parameter
            coolingSystemName = name; // sets coolingSystemName variable to the name parameter
        }
                
    }
}
