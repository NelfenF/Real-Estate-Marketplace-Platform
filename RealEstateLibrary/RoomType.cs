using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateLibrary;

namespace RealEstateLibrary
{
    public class RoomType
    {
        private int roomTypeID; // private int variable called roomTypeID
        private string roomTypeName; // private variable string called roomTypeName

        public int RoomTypeID // public int variable called RoomTypeID
        {
            get { return roomTypeID; } // returns the value of roomTypeID variable
            set { roomTypeID = value; } // sets the value of roomTypeID variable to whatever is passed to it
        }

        public string RoomTypeName // public string variable called RoomTypeName
        {
            get { return roomTypeName; } // returns the value of roomTypeName variable
            set { roomTypeName = value; } // sets the value of roomTypeName variable to whatever is passed to it
        }

        public RoomType(int id, string name) // public Statuses initalizer that accepts a int and string parameter
        {
            RoomTypeID = id; // sets StatusID variable to the id parameter
            RoomTypeName = name; // sets StatusName variable to the id parameter
        } 
    }
}
