using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateLibrary;

namespace RealEstateLibrary
{
    public class PropertyTypeList
    {
        private DBConnect databaseHandler = new DBConnect(); // private DBConnect object called databaseHandler set to a new DBConnect object
        private List<PropertyType> allPropertyType = new List<PropertyType>(); // private List of PropertyType objects called allPropertyType set to a new list of PropertyType

        public PropertyTypeList() // public PropertyTypeList object initializer
        {
            allPropertyType = new List<PropertyType>(); // sets allPropertyType to a new List of PropertyType objects
            SqlCommand selectProcedure = new SqlCommand(); // SqlCommand object called selectProcedure set to a new SqlCommand object
            selectProcedure.CommandType = CommandType.StoredProcedure; // sets selectProceudre's CommandType to the StoredProcedure command type
            selectProcedure.CommandText = "SelectAllPropertyTypes"; // sets selectProceudre's CommandText to SelectAllPropertyTypes
            DataTable propertyTypeData = databaseHandler.GetDataSet(selectProcedure).Tables[0]; // DataTable object called propertyTypeData set to the first table of the returned value of GetDataSet function from the databaseHandler object with the selectProceudre as a parameter

            foreach (DataRow row in propertyTypeData.Rows) // foreach DataRow called row in propertyTypeData's rows do
            {
                allPropertyType.Add(new PropertyType((int)row["TypeID"], row["TypeName"].ToString())); // adds a new PropertyType object to allPropertyType list object with the row's TypeID column value converted to an int, row's TypeName column value converted to a string
            }
        }

        public List<PropertyType> GetPropertyTypes() // public GetPropertyTypes function that returns a list of PropertyType objects
        {
            return allPropertyType; // returns allPropertyType object
        }
    }
}
