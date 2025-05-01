using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateLibrary
{
    internal class PropertyShowingRequestList
    {
        private DBConnect databaseHandler = new DBConnect(); // private DBConnect object called databaseHandler set to a new DBConnect object
        private List<PropertyShowingRequest> allShowingRequests; // private List of PropertyShowingRequest objects called allShowingRequests set to a new list of PropertyShowingRequest
        private List<PropertyShowingRequest> agentShowingRequests; // private List of PropertyShowingRequest objects called allShowingRequests set to a new list of PropertyShowingRequest


        public PropertyShowingRequestList() // public PropertyShowingRequestList object initializer
        {
            allShowingRequests = new List<PropertyShowingRequest>(); // sets allShowingRequests to a new List of PropertyShowingRequest objects
            SqlCommand selectProcedure = new SqlCommand(); // SqlCommand object called selectProcedure set to a new SqlCommand object
            selectProcedure.CommandType = CommandType.StoredProcedure; // sets selectProceudre's CommandType to the StoredProcedure command type
            selectProcedure.CommandText = "SelectAllShowingRequests"; // sets selectProceudre's CommandText to SelectAllShowingRequests
            DataTable showingRequestsData = databaseHandler.GetDataSet(selectProcedure).Tables[0]; // DataTable object called showingRequestsData set to the first table of the returned value of GetDataSet function from the databaseHandler object with the selectProceudre as a parameter

            foreach (DataRow row in showingRequestsData.Rows) // foreach DataRow called row in showingRequestsData's rows do
            {
                allShowingRequests.Add(new PropertyShowingRequest((int)row["ShowingID"], (int)row["PropertyID"], row["BuyerFirstName"].ToString(), row["BuyerLastName"].ToString(), row["BuyerEmail"].ToString(), row["BuyerPhoneNumber"].ToString(), (DateTime)row["PreferredDayTime"])); // adds a new PropertyShowingRequest object to allShowingRequests list object with the row's ShowingID column value converted to an int, the row's PropertyID column value converted to an int, the row's BuyerFirstName column value converted to a string, the row's BuyerLastName column value converted to a string, the row's BuyerEmail column value converted to a string, the row's BuyerPhoneNumber column value converted to a string, and the row's PreferredDayTime column value converted to a DateTime 
            }
        }

        public List<PropertyShowingRequest> GetAgentShowingRequests(List<Property> agentListings) // public GetAgentShowingRequests function that returns a List of PropertyShowingRequests object and accepts a List of Property objects as a parameter
        {
            agentShowingRequests = new List<PropertyShowingRequest>(); // sets agentShowingRequests to a new List of PropertyShowingRequest objects
            DateTime currentDateTime = DateTime.Now; // DateTime object called currentDateTime set to the current Date & Time
            foreach (Property agentProperty in agentListings) // foreach Property object called agentProperty in agentListings List object do
            {
                foreach (PropertyShowingRequest showing in allShowingRequests) // foreach PropertyShowingRequest object called showing in allShowingRequests List object do
                {
                    if (showing.PropertyID == agentProperty.PropertyID) // if the current showing objects PropertyID is equal to the current agentProperty PropertyID then
                    {
                        if (showing.PreferredDayTime >= currentDateTime) // if the current showing objects PreferredDayTime is greater than or equal to todays date & time then
                        {
                            agentShowingRequests.Add(showing); // adds the current showing to the agentShowingRequests list obect
                        }
                    }
                }
            }
            return agentShowingRequests; // returns agentShowingRequests list object
        }

        public void NewShowingRequest(PropertyShowingRequest newShowing) // public NewShowingRequest function that accepts a PropertyShowingRequest object as a parameter
        {
            SqlCommand insertProcedure = new SqlCommand();  // SqlCommand object called insertProcedure set to a new SqlCommand object
            insertProcedure.CommandType = CommandType.StoredProcedure; // sets insertProcedure's CommandType to the StoredProcedure command type
            insertProcedure.CommandText = "InsertNewPropertyShowingRequest"; // sets selectProceudre's CommandText to InsertNewPropertyShowingRequest
            insertProcedure.Parameters.AddWithValue("@PropertyID", newShowing.PropertyID); // Adds a parameter with value to the insertProcedure object with @PropertyID as the name and the newShowing parameter objects PropertyID as the value
            insertProcedure.Parameters.AddWithValue("@BuyerFirstName", newShowing.BuyerFirstName); // Adds a parameter with value to the insertProcedure object with @BuyerFirstName as the name and the newShowing parameter objects BuyerFirstName as the value
            insertProcedure.Parameters.AddWithValue("@BuyerLastName", newShowing.BuyerLastName); // Adds a parameter with value to the insertProcedure object with @BuyerLastName as the name and the newShowing parameter objects BuyerLastName as the value
            insertProcedure.Parameters.AddWithValue("@BuyerEmail", newShowing.BuyerEmail); // Adds a parameter with value to the insertProcedure object with @BuyerEmail as the name and the newShowing parameter objects BuyerEmail as the value
            insertProcedure.Parameters.AddWithValue("@BuyerPhoneNumber", newShowing.BuyerPhoneNumber); // Adds a parameter with value to the insertProcedure object with @BuyerPhoneNumber as the name and the newShowing parameter objects BuyerPhoneNumber as the value
            insertProcedure.Parameters.AddWithValue("@PreferredDayTime", newShowing.PreferredDayTime); // Adds a parameter with value to the insertProcedure object with @PreferredDayTime as the name and the newShowing parameter objects PreferredDayTime as the value
            databaseHandler.DoUpdate(insertProcedure); // calls the DoUpdate function of the databaseHandler object with the inserProcedure object as a parameter

        }

        public void RemoveShowingRequest(int propertyID) // public RemoveShowingRequest function that accepts a int parameter
        {
            SqlCommand deleteProcedure = new SqlCommand(); // SqlCommand object called deleteProcedure set to a new SqlCommand object
            deleteProcedure.CommandType = CommandType.StoredProcedure; // sets deleteProcedure's CommandType to the StoredProcedure command type
            deleteProcedure.CommandText = "DeletePropertiesShowingRequestByPropertyID"; // sets deleteProcedure's CommandText to DeletePropertiesShowingRequestByPropertyID
            deleteProcedure.Parameters.AddWithValue("@PropertyID", propertyID); // Adds a parameter with value to the deleteProcedure object with @PropertyID as the name and the propertyID parameter variable as the value
            databaseHandler.DoUpdate(deleteProcedure); // calls the DoUpdate function of the databaseHandler object with the deleteProcedure object as a parameter
        }
    }
}
