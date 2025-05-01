using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateLibrary;

namespace RealEstateLibrary
{
    public class PropertyRoom
    {
        private int roomID; // private int variable called roomID
        private int propertyID; // private int variable called propertyID
        private string roomType; // private string variable called roomType
        private decimal roomLength; // private decimal variable called roomLength
        private decimal roomWidth; // private decimal variable called roomWidth
        private decimal totalSqFt; // private decimal variable called totalSqFt

        public int RoomID // public int variable called RoomID
        {
            get { return roomID; } // returns the value of roomID variable
            set { roomID = value; } // sets the value of roomID variable to whatever is passed to it
        }

        public int PropertyID // public int variable called PropertyID
        {
            get { return propertyID; } // returns the value of propertyID variable
            set { propertyID = value; } // sets the value of propertyID variable to whatever is passed to it
        }

        public string RoomType // public string variable called RoomType
        { 
            get { return roomType; } // returns the value of roomType variable
            set { roomType = value; } // sets the value of roomType variable to whatever is passed to it
        }

        public decimal RoomLength // public decimal variable called RoomLength
        {
            get { return roomLength; } // returns the value of roomLength variable
            set { roomLength = value; } // sets the value of roomLength variable to whatever is passed to it
        }

        public decimal RoomWidth // public decimal variable called RoomWidth
        {
            get { return roomWidth; } // returns the value of roomWidth variable
            set { roomWidth = value; } // sets the value of roomWidth variable to whatever is passed to it
        }

        public decimal TotalSqFt // public decimal variable called TotalSqFt
        {
            get { return totalSqFt; } // returns the value of totalSqFt variable
            set { totalSqFt = value; } // sets the value of totalSqFt variable to whatever is passed to it
        }

        public PropertyRoom(int rId, int pId, string type, decimal len, decimal wid, decimal totalFt)  // public PropertyRoom initalizer that accepts a two ints, a string, and three decimal parameter
        {
            RoomID = rId; // sets RoomID variable to the rId parameter
            PropertyID = pId; // sets PropertyID variable to the pId parameter
            RoomType = type; // sets RoomType variable to the type parameter
            RoomLength = len; // sets RoomLength variable to the len parameter
            RoomWidth = wid; // sets RoomWidth variable to the wid parameter
            TotalSqFt = totalFt; // sets TotalSqFt variable to the totalFt parameter
        }

        public PropertyRoom(string type, decimal len, decimal wid, decimal totalFt) // public PropertyRoom initalizer that accepts, a string, and three decimal parameter
        {
            RoomType = type; // sets RoomType variable to the type parameter
            RoomLength = len; // sets RoomLength variable to the len parameter
            RoomWidth = wid; // sets RoomWidth variable to the wid parameter
            TotalSqFt = totalFt; // sets TotalSqFt variable to the totalFt parameter
        }

        public PropertyRoom(string type, decimal len, decimal wid) // public PropertyRoom initalizer that accepts, a string, and two decimal parameter
        {
            RoomType = type; // sets RoomType variable to the type parameter
            RoomLength = len; // sets RoomLength variable to the len parameter
            RoomWidth = wid; // sets RoomWidth variable to the wid parameter
            TotalSqFt = len * wid; // sets TotalSqFt to the passed len parameter multiplied by the passed wid parameter
        }

        public PropertyRoom(string type, string len, string wid) // public PropertyRoom initalizer that accepts, three string parameter
        {
            RoomType = type; // sets RoomType variable to the type parameter
            RoomLength = decimal.Parse(len); // sets RoomLength variable to the len parameter converted to a decimal
            RoomWidth = decimal.Parse(wid); // sets RoomWidth variable to the wid parameter converted to a decimal
            TotalSqFt = RoomLength * RoomWidth; // sets TotalSqFt to the value of RoomLength mutliplied by RoomWidth
        }

    }
}
