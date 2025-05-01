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
    public class PropertyAmenityList
    {
        private DBConnect databaseHandler = new DBConnect(); // private DBConnect object called databaseHandler set to a new DBConnect object
        private List<PropertyAmenity> allPropertyAmenities; // private List of PropertyAmenity objects called allPropertAmenities
        private List<PropertyAmenity> singlePropertyAmenities; // private List of PropertyAmenity objects called singlePropertyAmenities

        public PropertyAmenityList() // public PropertyAmenityList object initializer
        {
            allPropertyAmenities = new List<PropertyAmenity>();  // sets allPropertyAmenities to a new List of PropertyAmenity objects
            SqlCommand selectProcedure = new SqlCommand(); // SqlCommand object called selectProcedure set to a new SqlCommand object
            selectProcedure.CommandType = CommandType.StoredProcedure; // sets selectProceudre's CommandType to the StoredProcedure command type
            selectProcedure.CommandText = "SelectAllPropertiesAmenities"; // sets selectProceudre's CommandText to SelectAllPropertiesAmenities
            DataTable propertyAmenityData = databaseHandler.GetDataSet(selectProcedure).Tables[0]; // DataTable object called propertyAmenityData set to the first table of the returned value of GetDataSet function from the databaseHandler object with the selectProceudre as a parameter

            foreach (DataRow row in propertyAmenityData.Rows) // foreach DataRow called row in propertyAmenityData's rows do
            {
                allPropertyAmenities.Add(new PropertyAmenity((int)row["AmenityPropertyID"], (int)row["AmenityID"], (int)row["PropertyID"]));// adds a new PropertyAmenity object to allPropertyAmenities list object with the row's AmenityPropertyID column value converted to an int, the row's AmenityID column value converted to an int, and the row's PropertyID column value converted to a int
            }
        }

        public void AddNewPropertyAmenities(List<int> amenitiesID, int propertyID) // public AddNewPropertyAmenitites function that accepts a List of ints, and a int parameter
        {
            foreach (int amenityID in amenitiesID) // foreach int called amenityID in amenitiesID list object do
            {
                SqlCommand insertProcedure = new SqlCommand(); // SqlCommand object called insertProcedure set to a new SqlCommand object
                insertProcedure.CommandType = CommandType.StoredProcedure; // sets insertProcedure's CommandType to the StoredProcedure command type
                insertProcedure.CommandText = "InsertNewPropertyAmenities"; // sets insertProcedure's CommandText to InsertNewPropertyAmenities
                insertProcedure.Parameters.AddWithValue("@AmenityID", amenityID); // Adds a parameter with value to the insertProcedure object with @AmenityID as the name and the current amenityID int as the value
                insertProcedure.Parameters.AddWithValue("@PropertyID", propertyID); // Adds a parameter with value to the insertProcedure object with @PropertyID as the name and the passed propertyID parameter as the value
                databaseHandler.DoUpdate(insertProcedure); // calls the DoUpdate function of the databaseHandler object with the insertProcedure object as a parameter
            }
        }

        public List<PropertyAmenity> GetAllPropertyAmenities() // public GetAllPropertyAmenities function that returns a List of PropertyAmenity object
        {
            return allPropertyAmenities; // returns allPropertyAmenities List Object
        }

        public List<PropertyAmenity> GetSinglePropertyAmenityList(int propertyID) // public GetSinglePropertyAmenityList function that returns a List of PropertyAmenity objects and accepts a int parameter
        {
            singlePropertyAmenities = new List<PropertyAmenity>(); // sets singlePropertyAmenities to a new List of PropertyAmenity objects
            foreach (PropertyAmenity amenity in allPropertyAmenities) // foreach PropertyAmenity object called amenity in allPropertyAmenites list object do
            {
                if (amenity.PropertyID == propertyID) // if the current amenity objects PropertyID is equal to the passed propertyID parameter then
                {
                    singlePropertyAmenities.Add(amenity); // adds the current amenity object to the singleProeprtyAmenitiees list object
                }
            }
            return singlePropertyAmenities; // returns the singlePropertyAmenities list object
        }

        public void UpdatePropertyAmenities(int propertyId, List<int> newAmenities) // public UpdatePropertyAmenities function that accepts a int and a list object of ints as parameters
        {
            foreach (int amenityID in newAmenities) // foreach int called amenityID in the newAmenities list object do
            {
                SqlCommand deleteProcedure = new SqlCommand(); // SqlCommand object called deleteProcedure set to a new SqlCommand object
                deleteProcedure.CommandType = CommandType.StoredProcedure; // sets deleteProcedure's CommandType to the StoredProcedure command type
                deleteProcedure.CommandText = "DeletePropertyAmenitiesByPropertyId"; // sets deleteProcedure's CommandText to DeletePropertyAmenitiesByPropertyId
                deleteProcedure.Parameters.AddWithValue("@PropertyID", propertyId); // Adds a parameter with value to the deleteProcedure object with @PropertyID as the name and the passed propertyID parameter as the value
                databaseHandler.DoUpdate(deleteProcedure); // calls the DoUpdate function of the databaseHandler object with the deleteProcedure object as a parameter
            }
            AddNewPropertyAmenities(newAmenities, propertyId); // calls the AddNewPropertyAmenities with newAmenities list of ints object and propertyID int variable as parameters
        }
    }
}
