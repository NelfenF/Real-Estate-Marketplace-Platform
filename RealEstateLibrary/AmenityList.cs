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
    public class AmenityList
    {
        private DBConnect databaseHandler = new DBConnect(); // private DBConnect object called databaseHandler set to a new DBConnect object
        private List<Amenity> amenities = new List<Amenity>(); // private List of Amenity objects called amenities
        public AmenityList()  // public AmenityList object initializer
        {
            amenities = new List<Amenity>(); // sets amenities to a new List of Amenity objects
            SqlCommand selectProcedure = new SqlCommand(); // SqlCommand object called selectProcedure set to a new SqlCommand object
            selectProcedure.CommandType = CommandType.StoredProcedure; // sets selectProceudre's CommandType to the StoredProcedure command type
            selectProcedure.CommandText = "SelectAllAmenities"; // sets selectProceudre's CommandText to SelectAllAmenities
            DataTable amenitiesData = databaseHandler.GetDataSet(selectProcedure).Tables[0]; // DataTable object called amenitiesData set to the first table of the returned value of GetDataSet function from the databaseHandler object with the selectProceudre as a parameter

            foreach (DataRow row in amenitiesData.Rows) // foreach DataRow called row in amenitiesData's rows do
            { 
                amenities.Add(new Amenity((int)row["AmenityID"], row["AmenityName"].ToString())); // adds a new Amenity object to amenities list object with the row's AmenityID column value converted to an int, row's AmenityName column value converted to a string
            }
        }

        public List<Amenity> GetAllAmenities() // public GetAllAmenities function that returns a list of Amenity objects
        {
            return amenities; // returns amenities List object
        } 
    }
}
