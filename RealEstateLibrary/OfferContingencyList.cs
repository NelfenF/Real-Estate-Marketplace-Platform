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
    public class OfferContingencyList
    {
        private DBConnect databaseHandler = new DBConnect(); // private DBConnect object called databaseHandler set to a new DBConnect object
        private List<OfferContingency> offerContingenciesList; // private List of OfferContingency objects called offerContingenciesList 

        public OfferContingencyList() // public OfferContingencyList object initializer
        {
            offerContingenciesList = new List<OfferContingency>(); // sets offerContingenciesList to a new List of OfferContingency objects
            SqlCommand selectProcedure = new SqlCommand(); // SqlCommand object called selectProcedure set to a new SqlCommand object
            selectProcedure.CommandType = CommandType.StoredProcedure; // sets selectProceudre's CommandType to the StoredProcedure command type
            selectProcedure.CommandText = "SelectAllPropertyOfferContingencies"; // sets selectProceudre's CommandText to SelectAllPropertyOfferContingencies
            DataTable offerContingencyData = databaseHandler.GetDataSet(selectProcedure).Tables[0]; // DataTable object called offerContingencyData set to the first table of the returned value of GetDataSet function from the databaseHandler object with the selectProceudre as a parameter

            foreach (DataRow row in offerContingencyData.Rows) // foreach DataRow called row in offerContingencyData's rows do
            { 
                offerContingenciesList.Add(new OfferContingency((int)row["ContingencyID"], (int)row["OfferID"], row["Contingency"].ToString())); // adds a new OfferContingency object to offerContingenciesList list object with the row's ContingencyID column value converted to an int, the row's OfferID column value converted to an int, and row's Contingency column value converted to a string
            }
        }

        public List<OfferContingency> GetOfferContingencies() // public GetOfferContingencies function that returns a List of OfferContingency objects
        {
            return offerContingenciesList; // returns the offerContingenciesList List object
        }

        public void MakeNewOfferContingencies(int offerId, List<OfferContingency> offerContingencies) // public MakeNewOfferContingencies function that accets a int and a List of OfferContingency object as parameter
        {
            foreach (OfferContingency offer in offerContingencies) // foreach OfferContingecny object called offer in offerContingecnies list object do
            {
                offer.OfferID = offerId; // sets the current offer objects OfferID to the passed offerId parameter
            }

            foreach (OfferContingency offer in offerContingencies) // foreach OfferContingecny object called offer in offerContingecncies list object do
            {
                SqlCommand insertProcedure = new SqlCommand();  // SqlCommand object called insertProcedure set to a new SqlCommand object
                insertProcedure.CommandType = CommandType.StoredProcedure; // sets insertProcedure's CommandType to the StoredProcedure command type
                insertProcedure.CommandText = "InsertNewPropertyOfferContingency"; // sets insertProcedure's CommandText to InsertNewPropertyOfferContingency
                insertProcedure.Parameters.AddWithValue("@OfferID", offer.OfferID);  // Adds a parameter with value to the insertProcedure object with @OfferID as the name and the current offer objects OfferID as the value
                insertProcedure.Parameters.AddWithValue("@Contingency", offer.Contingency); // Adds a parameter with value to the insertProcedure object with @Contingency as the name and the current offer objects Contingency as the value
                databaseHandler.DoUpdate(insertProcedure); // calls the DoUpdate function of the databaseHandler object with the insertProcedure object as a parameter
            }
        }

        public void RemoveOfferContingencies(int offerID) // public RemoveOfferContingencies function that accepts a int parameter
        {
            SqlCommand deleteProcedure = new SqlCommand(); // SqlCommand object called deleteProcedure set to a new SqlCommand object
            deleteProcedure.CommandType = CommandType.StoredProcedure; // sets deleteProcedure's CommandType to the StoredProcedure command type
            deleteProcedure.CommandText = "DeletePropertiesOfferContingenciesByOfferID"; // sets deleteProcedure's CommandText to DeletePropertiesOfferContingenciesByOfferID
            deleteProcedure.Parameters.AddWithValue("@OfferID", offerID); // Adds a parameter with value to the deleteProcedure object with @OfferID as the name and the passed offerId parameter as the value
            databaseHandler.DoUpdate(deleteProcedure); // calls the DoUpdate function of the databaseHandler object with the deleteProcedure object as a parameter
        }
    }
}
