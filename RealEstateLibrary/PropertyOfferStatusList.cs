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
    public class PropertyOfferStatusList
    {
        private DBConnect databaseHandler = new DBConnect(); // private DBConnect object called databaseHandler set to a new DBConnect object
        private List<PropertyOfferStatus> allpropertyOfferStatuses; // private List of PropertyOfferStatus objects called allpropertyOfferStatuses set to a new list of PropertyOfferStatus
        public PropertyOfferStatusList() 
        {
            allpropertyOfferStatuses = new List<PropertyOfferStatus>(); // sets allpropertyOfferStatuses to a new List of PropertyOfferStatus objects
            SqlCommand selectProcedure = new SqlCommand(); // SqlCommand object called selectProcedure set to a new SqlCommand object
            selectProcedure.CommandType = CommandType.StoredProcedure; // sets selectProceudre's CommandType to the StoredProcedure command type
            selectProcedure.CommandText = "SelectAllPropertiesOffersStatus"; // sets selectProceudre's CommandText to SelectAllPropertiesOffersStatus
            DataTable offerStatusData = databaseHandler.GetDataSet(selectProcedure).Tables[0]; // DataTable object called offerStatusData set to the first table of the returned value of GetDataSet function from the databaseHandler object with the selectProceudre as a parameter

            foreach (DataRow row in offerStatusData.Rows) // foreach DataRow called row in offerStatusData's rows do
            {
                allpropertyOfferStatuses.Add(new PropertyOfferStatus((int)row["StatusID"], (int)row["OfferID"], row["CurrentStatus"].ToString())); // adds a new PropertyOfferStatus object to allpropertyOfferStatuses list object with the row's StatusID column value converted to an int, the row's OfferID column value converted to an int, and the row's CurrentStatus column value converted to a string
            }
        }


        public List<PropertyOfferStatus> GetAllPropertyOffersStatuses() // public GetAllPropertyOffersStatuses function that returns a list of PropertyOfferStatus objects
        {
            return allpropertyOfferStatuses; // returns allpropertyOfferStatuses List object
        }

        public void MakePropertyOfferStatus(int offerID) // public MakePropertyOfferStatus funtion that accepts a int parameter
        {
 
            SqlCommand insertProcedure = new SqlCommand(); // SqlCommand object called insertProcedure set to a new SqlCommand object
            insertProcedure.CommandType = CommandType.StoredProcedure; // sets insertProcedure's CommandType to the StoredProcedure command type
            insertProcedure.CommandText = "InsertNewPropertyOfferStatus"; // sets insertProcedure's CommandText to InsertNewPropertyOfferStatus
            insertProcedure.Parameters.AddWithValue("@OfferID", offerID); // Adds a parameter with value to the insertProcedure object with @OfferID as the name and the offerID parameter as the value
            databaseHandler.DoUpdate(insertProcedure); // calls the DoUpdate function of the databaseHandler object with the insertProcedure object as a parameter
            
        }

        public void UpdatePropertyOfferStatus(int offerID, string newStatus) // public UpdatePropertyOfferStatus function that accepts a int and string parameter 
        {
            SqlCommand insertProcedure = new SqlCommand(); // SqlCommand object called insertProcedure set to a new SqlCommand object
            insertProcedure.CommandType = CommandType.StoredProcedure; // sets insertProcedure's CommandType to the StoredProcedure command type
            insertProcedure.CommandText = "UpdatePropertyOfferStatusByOfferID"; // sets insertProcedure's CommandText to UpdatePropertyOfferStatusByOfferID
            insertProcedure.Parameters.AddWithValue("@OfferID", offerID); // Adds a parameter with value to the insertProcedure object with @OfferID as the name and the offerID parameter as the value
            insertProcedure.Parameters.AddWithValue("@CurrentStatus", newStatus); // Adds a parameter with value to the insertProcedure object with @CurrentStatus as the name and the newStatus parameter as the value
            databaseHandler.DoUpdate(insertProcedure); // calls the DoUpdate function of the databaseHandler object with the insertProcedure object as a parameter
        }

        public void RemovePropertyOfferStatus(int offerID) // public RemovePropertyOfferStatus function that accepts a int parameter
        {
            SqlCommand deleteProcedure = new SqlCommand(); // SqlCommand object called deleteProcedure set to a new SqlCommand object
            deleteProcedure.CommandType = CommandType.StoredProcedure; // sets deleteProcedure's CommandType to the StoredProcedure command type
            deleteProcedure.CommandText = "DeletePropertiesOfferStatusByOfferID"; // sets deleteProcedure's CommandText to DeletePropertiesOfferStatusByOfferID
            deleteProcedure.Parameters.AddWithValue("@OfferID", offerID); // Adds a parameter with value to the deleteProcedure object with @OfferID as the name and the offerID parameter as the value
            databaseHandler.DoUpdate(deleteProcedure); // calls the DoUpdate function of the databaseHandler object with the deleteProcedure object as a parameter
        }

    }


}
