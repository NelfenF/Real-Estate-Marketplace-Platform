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
    public class PropertyStatusList
    {
        private DBConnect databaseHandler = new DBConnect(); // private DBConnect object called databaseHandler set to a new DBConnect object
        private List<PropertyStatus> allPropertyStatuses; // private List of PropertyStatus objects called allPropertyStatuses set to a new list of PropertyStatus

        public PropertyStatusList() // public PropertyStatusList object initializer
        {

            allPropertyStatuses = new List<PropertyStatus>(); // sets allPropertyStatuses to a new List of PropertyStatus objects
            SqlCommand selectProcedure = new SqlCommand(); // SqlCommand object called selectProcedure set to a new SqlCommand object
            selectProcedure.CommandType = CommandType.StoredProcedure; // sets selectProceudre's CommandType to the StoredProcedure command type
            selectProcedure.CommandText = "SelectAllPropertiesStatus"; // sets selectProceudre's CommandText to SelectAllPropertiesStatus
            DataTable propertyStatusesData = databaseHandler.GetDataSet(selectProcedure).Tables[0]; // DataTable object called propertyStatusesData set to the first table of the returned value of GetDataSet function from the databaseHandler object with the selectProceudre as a parameter

            foreach (DataRow row in propertyStatusesData.Rows) // foreach DataRow called row in propertyStatusesData's rows do
            {
                allPropertyStatuses.Add(new PropertyStatus((int)row["StatusID"], (int)row["PropertyID"], row["CurrentStatus"].ToString(), (DateTime)row["LastUpdate"])); // adds a new PropertyStatus object to allPropertyStatuses list object with the row's StatusID column value converted to an int, the row's PropertyID column value converted to an int, the row's CurrentStatus column value converted to a string, and the row's LastUpdate column value converted to a DateTime object
            }
        }

        public PropertyStatusList(int propertyID) // public PropertyStatusList object initializer that accepts a int as a parameter
        {
            allPropertyStatuses = new List<PropertyStatus>(); // sets allPropertyStatuses to a new List of PropertyStatus objects
            SqlCommand selectProcedure = new SqlCommand(); // SqlCommand object called selectProcedure set to a new SqlCommand object
            selectProcedure.CommandType = CommandType.StoredProcedure; // sets selectProceudre's CommandType to the StoredProcedure command type
            selectProcedure.CommandText = "SelectAllPropertiesStatus"; // sets selectProceudre's CommandText to SelectAllPropertiesStatus
            DataTable propertyStatusesData = databaseHandler.GetDataSet(selectProcedure).Tables[0]; // DataTable object called propertyStatusesData set to the first table of the returned value of GetDataSet function from the databaseHandler object with the selectProceudre as a parameter

            foreach (DataRow row in propertyStatusesData.Rows) // foreach DataRow called row in propertyStatusesData's rows do
            {
                if ((int)row["PropertyID"] == propertyID) // if the current rows PropertyID column converted to an int is equal to the propertyID parameter then
                {
                    allPropertyStatuses.Add(new PropertyStatus((int)row["StatusID"], (int)row["PropertyID"], row["CurrentStatus"].ToString(), (DateTime)row["LastUpdate"])); // adds a new PropertyStatus object to allPropertyStatuses list object with the row's StatusID column value converted to an int, the row's PropertyID column value converted to an int, the row's CurrentStatus column value converted to a string, and the row's LastUpdate column value converted to a DateTime object
                }
            }
        }

        public List<PropertyStatus> GetPropertyStatuses() // public GetPropertyStatuses function that returns a list of PropertyStatus objects
        {
            return allPropertyStatuses; // returns statuses object
        }

        public List<PropertyStatus> GetAllActivePropertySatuses() // public GetAllActivePropertySatuses function that returns a List of PropertyStatus object
        {
            List<PropertyStatus> allActiveStatuses = new List<PropertyStatus>(); // List object of PropertyStatus called allActiveSatuses new to a new List of PropertyStatus
            SqlCommand selectProcedure = new SqlCommand(); // SqlCommand object called selectProcedure set to a new SqlCommand object
            selectProcedure.CommandType = CommandType.StoredProcedure; // sets selectProceudre's CommandType to the StoredProcedure command type
            selectProcedure.CommandText = "SelectAllPropertiesStatus"; // sets selectProceudre's CommandText to SelectAllPropertiesStatus
            DataTable propertyStatusesData = databaseHandler.GetDataSet(selectProcedure).Tables[0]; // DataTable object called propertyStatusesData set to the first table of the returned value of GetDataSet function from the databaseHandler object with the selectProceudre as a parameter

            foreach (DataRow row in propertyStatusesData.Rows) // foreach DataRow called row in propertyStatusesData's rows do
            {
                if (row["CurrentStatus"].ToString() == "Active") // if the current rows CurrentStatus column is equal to Active then
                {
                    allActiveStatuses.Add(new PropertyStatus((int)row["StatusID"], (int)row["PropertyID"], row["CurrentStatus"].ToString(), (DateTime)row["LastUpdate"])); // adds a new PropertyStatus object to allPropertyStatuses list object with the row's StatusID column value converted to an int, the row's PropertyID column value converted to an int, the row's CurrentStatus column value converted to a string, and the row's LastUpdate column value converted to a DateTime object
                }
            }

            return allActiveStatuses; // returns allActiveStatuses object
        }

        public PropertyStatus GetPropertyStatusByPropertyID(int propertyID) // public GetPropertyStatusByPropertyID function that returns a PropertyStatus object and accpets a int variable parameter
        {
            List<PropertyStatus> propertyStatuses = new List<PropertyStatus>(); // List object of PropertyStatus called propertyStatuses new to a new List of PropertyStatus
            foreach (PropertyStatus propertyStatus in allPropertyStatuses) // foreach PropertyStatus object called propertyStatus in allPropertyStatuses do
            {
                if (propertyStatus.PropertyID == propertyID) // if the current rows PropertyID property is eqal to the passed parameter then
                {
                    propertyStatuses.Add(propertyStatus); //
                    
                }

            }
            return propertyStatuses[0]; // returns the first object in the propertyStatuses List object
        }

        public void AddNewPropertyStatus(int propertyID, string status) // public void AddNewPropertyStatus function that accepts a int and string parameter
        {
            DateTime lastUpdate = DateTime.Now; // DateTime object called lastUpdate set to the current DateTime
            SqlCommand insertProcedure = new SqlCommand(); // SqlCommand object called insertProcedure set to a new SqlCommand object
            insertProcedure.CommandType = CommandType.StoredProcedure; // sets insertProcedure's CommandType to the StoredProcedure command type
            insertProcedure.CommandText = "InsertNewPropertyStatus"; // sets insertProcedure's CommandText to SelectAllPropertiesStatus
            insertProcedure.Parameters.AddWithValue("@PropertyID", propertyID); // Adds a parameter with value to the insertProcedure object with @PropertyID as the name and the propertyID passed parameter as the value
            insertProcedure.Parameters.AddWithValue("@CurrentStatus", status); // Adds a parameter with value to the insertProcedure object with @CurrentStatus as the name and the status passed parameter as the value
            insertProcedure.Parameters.AddWithValue("@LastUpdate", lastUpdate); // Adds a parameter with value to the insertProcedure object with @LastUpdate as the name and the lastUpdate DateTime object as the value
            databaseHandler.DoUpdate(insertProcedure); // calls the DoUpdate function of the databaseHandler object with the inserProcedure object as a parameter
        }

        public void UpdatePropertyStatus(int propertyID, string newStatus) // public void UpdatePropertyStatus function that accepts a int and string parameter
        {
            DateTime lastUpdate = DateTime.Now; // DateTime object called lastUpdate set to the current DateTime
            SqlCommand updateProcedure = new SqlCommand(); // SqlCommand object called updateProcedure set to a new SqlCommand object
            updateProcedure.CommandType = CommandType.StoredProcedure; // sets updateProcedure's CommandType to the StoredProcedure command type
            updateProcedure.CommandText = "UpdatePropertyStatusByPropertyID"; // sets updateProcedure's CommandText to UpdatePropertyStatusByPropertyID
            updateProcedure.Parameters.AddWithValue("@PropertyID", propertyID); // Adds a parameter with value to the updateProcedure object with @PropertyID as the name and the propertyID passed parameter as the value
            updateProcedure.Parameters.AddWithValue("@CurrentStatus", newStatus); // Adds a parameter with value to the updateProcedure object with @CurrentStatus as the name and the status passed parameter as the value
            updateProcedure.Parameters.AddWithValue("@LastUpdate", lastUpdate); // Adds a parameter with value to the updateProcedure object with @LastUpdate as the name and the lastUpdate DateTime object as the value
            databaseHandler.DoUpdate(updateProcedure); // calls the DoUpdate function of the databaseHandler object with the updateProcedure object as a parameter
        }

        

    }
}
