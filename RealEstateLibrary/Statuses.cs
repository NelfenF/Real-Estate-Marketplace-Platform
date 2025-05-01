using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateLibrary;

namespace RealEstateLibrary
{

    public class Statuses
    {
        private int statusID; // private int variable called statusID
        private string statusName; // private string variable called statusName

        public int StatusID // public int variable called StatusID
        {
            get { return statusID; } // returns the value of statusID variable
            set { statusID = value; } // sets the value of statusID variable to whatever is passed to it
        }

        public string StatusName // public string variable called StatusName
        {
            get { return statusName; } // returns the value of statusName variable
            set { statusName = value; } // sets the value of statusName variable to whatever is passed to it
        }

        public Statuses(int id, string name) // public Statuses initalizer that accepts a int and string parameter
        {
            StatusID = id; // sets StatusID variable to the id parameter
            StatusName = name; // sets StatusName variable to the name parameter

        }
    }
}
