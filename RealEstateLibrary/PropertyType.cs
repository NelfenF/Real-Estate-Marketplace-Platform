using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateLibrary;

namespace RealEstateLibrary
{
    public class PropertyType
    {
        private int typeID; // private int variable called typeID
        private string typeName; // private string variable called typeName

        public int TypeID // public int variable called TypeID
        {
            get { return typeID; } // returns the value of typeID variable
            set { typeID = value; } // sets the value of typeID variable to whatever is passed to it
        } 

        public string TypeName // public string variable called TypeName
        {
            get { return typeName; } // returns the value of TypeName variable
            set { typeName = value; } // sets the value of TypeName variable to whatever is passed to it
        }

        public PropertyType(int id, string name) // public PropertyType initalizer that accepts a int and string parameter
        {
            TypeID = id; // sets TypeID variable to the id parameter
            TypeName = name; // sets TypeName variable to the name parameter
        }
    }
}
