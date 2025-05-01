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
    public class PropertyOfferList
    {
        private DBConnect databaseHandler = new DBConnect(); // private DBConnect object called databaseHandler set to a new DBConnect object
        private List<PropertyOffer> allPropertyOffers; // private List of PropertyOffer objects called allPropertyOffers
        private List<PropertyOffer> agentPropertyOffers; // private List of PropertyOffer objects called agentPropertyOffers

        public PropertyOfferList() // public PropertyOfferList object initializer
        {
            allPropertyOffers = new List<PropertyOffer>(); // sets allPropertyOffers to a new List of PropertyOffer objects
            SqlCommand selectProcedure = new SqlCommand(); // SqlCommand object called selectProcedure set to a new SqlCommand object
            selectProcedure.CommandType = CommandType.StoredProcedure; // sets selectProceudre's CommandType to the StoredProcedure command type
            selectProcedure.CommandText = "SelectAllPropertiesOffers"; // sets selectProceudre's CommandText to SelectAllPropertiesOffers
            DataTable propertyOfferData = databaseHandler.GetDataSet(selectProcedure).Tables[0]; // DataTable object called propertyOfferData set to the first table of the returned value of GetDataSet function from the databaseHandler object with the selectProceudre as a parameter

            foreach (DataRow row in propertyOfferData.Rows) // foreach DataRow called row in propertyOfferData's rows do
            {
                allPropertyOffers.Add(new PropertyOffer((int)row["OfferID"], (int)row["PropertyID"], row["BuyerFirstName"].ToString(), row["BuyerLastName"].ToString(), (decimal)row["OfferAmount"], row["OfferType"].ToString(), row["BuyerPhoneNumber"].ToString(), row["BuyerEmail"].ToString(), row["SellCurrentHouse"].ToString() ,(DateTime)row["MoveInDate"], (DateTime)row["OfferDate"])); // adds a new PropertyOffer object to allPropertyOffers list object with the row's OfferID column value converted to an int, the row's PropertyID column value converted to an int, the row's BuyerFirstName column value converted to a string, the row's BuyerLastName column value converted to a string, the row's OfferAmount column value converted to a decimal, the row's OfferType column value converted to a string, the row's BuyerPhoneNumber column value converted to a string, the row's BuyerEmail column value converted to a string, the row's SellCurrentHouse column value converted to a string, the row's MoveInDate column value converted to a DateTime, and the row's OfferDate column value converted to a DateTime
            }
        }

        public List<PropertyOffer> GetAllPropertyOffers() // public GetAllPropertyOffers function that returns a list of PropertyOffer object
        {
            return allPropertyOffers; // returns allPropertyOffers list object
        }

        public void NewPropertyOffer(PropertyOffer newOffer) // public NewPropertyOffer function that accepts a PropertyOffer object as a parameter
        {
            SqlCommand insertProcedure = new SqlCommand(); // // SqlCommand object called insertProcedure set to a new SqlCommand object
            insertProcedure.CommandType = CommandType.StoredProcedure; // sets insertProcedure's CommandType to the StoredProcedure command type
            insertProcedure.CommandText = "InsertNewPropertyOffer"; // sets insertProcedure's CommandText to SelectAllPropertiesOffers
            insertProcedure.Parameters.AddWithValue("@PropertyID", newOffer.PropertyID); // Adds a parameter with value to the insertProcedure object with @PropertyID as the name and the newOffer object parameters PropertyID as the value
            insertProcedure.Parameters.AddWithValue("@BuyerFirstName", newOffer.BuyerFirstName); // Adds a parameter with value to the insertProcedure object with @BuyerFirstName as the name and the newOffer object parameters BuyerFirstName as the value
            insertProcedure.Parameters.AddWithValue("@BuyerLastName", newOffer.BuyerLastName); // Adds a parameter with value to the insertProcedure object with @BuyerLastName as the name and the newOffer object parameters BuyerLastName as the value
            insertProcedure.Parameters.AddWithValue("@OfferAmount", newOffer.OfferAmount); // Adds a parameter with value to the insertProcedure object with @OfferAmount as the name and the newOffer object parameters OfferAmount as the value
            insertProcedure.Parameters.AddWithValue("@OfferType", newOffer.OfferType); // Adds a parameter with value to the insertProcedure object with @OfferType as the name and the newOffer object parameters OfferType as the value
            insertProcedure.Parameters.AddWithValue("@BuyerPhoneNumber", newOffer.BuyerPhoneNumber); // Adds a parameter with value to the insertProcedure object with @BuyerPhoneNumber as the name and the newOffer object parameters BuyerPhoneNumber as the value
            insertProcedure.Parameters.AddWithValue("@BuyerEmail", newOffer.BuyerEmail); // Adds a parameter with value to the insertProcedure object with @BuyerEmail as the name and the newOffer object parameters BuyerEmail as the value
            insertProcedure.Parameters.AddWithValue("@SellCurrentHouse", newOffer.SellCurrentHouse); // Adds a parameter with value to the insertProcedure object with @SellCurrentHouse as the name and the newOffer object parameters SellCurrentHouse as the value
            insertProcedure.Parameters.AddWithValue("@MoveInDate", newOffer.MoveInDate); // Adds a parameter with value to the insertProcedure object with @MoveInDate as the name and the newOffer object parameters MoveInDate as the value
            databaseHandler.DoUpdate(insertProcedure); // calls the DoUpdate function of the databaseHandler object with the insertProcedure as a parameter
        }

        public int GetPropertyOfferOfferID(int propertyID, string firstName, string lastName) // public GetPropertyOfferOfferID function that returns a int and accetps a int and two string parameter
        {
            List<PropertyOffer> propertyOffers = new List<PropertyOffer>(); // List of PropertyOffer object called propertyOffers set to a new list of PropertyOffer objects
            foreach (PropertyOffer offer in allPropertyOffers) // foreach PropertyOffer object called offer in allPropertyOffers list object do
            {
                if (offer.PropertyID == propertyID && offer.BuyerFirstName == firstName && offer.BuyerLastName == lastName) // the the current offer objects PropertyID is equal to the passed propertyID parameter and if the current offer BuyerFirstName is eqal to the passed firstName parameter and if the current offer objects BuyerLastName is equal to the passed lastName parameter then
                {
                    propertyOffers.Add(offer); // adds the current offer object to the propertyOffers list object
                }
            }
            return propertyOffers[0].OfferID; // returns the first objects OfferID in the propertyOffers list object
        }

        public List<PropertyOffer> GetAgentPropertyOffer(List<Property> agentListings) // public GetAgentPropertyOffer function tha returns a List of PropertyOffer object and accepts a List of Property object
        {
            agentPropertyOffers = new List<PropertyOffer>(); // sets agentPropertyOffers to a new List of PropertyOffer object 
            foreach (Property agentProperty in agentListings) // foreach Property object called agentProperty in the passed agentListing list object do
            {
                foreach (PropertyOffer offer in allPropertyOffers) // foreach PropertyOffer object called offer in the allPropertyOffers list object do
                {
                    if (agentProperty.PropertyID == offer.PropertyID) // if the current agentProperty objects PropertyID is equal to the current offer objects PropertyID then
                    {
                        agentPropertyOffers.Add(offer); // adds the current offer object to the agentPropertyOffers list object
                    }
                }
            }
            return agentPropertyOffers; // returns agentPropertyOffers list object
        }

        public PropertyOffer GetPropertyOfferByOfferID(int offerid) // public GetPropertyOfferByOfferId function that returns a PropertyOffer object and accetps a int parameter
        {
            int count = 0; // int varaible called count set to 0
            int validOffer = 0; // int variable called valid offer set to 0;
            foreach(PropertyOffer offer in allPropertyOffers) // foreach PropertyOffer object called offer in allPropertyOffers list object do
            {
                if(offer.OfferID == offerid) // if the current offer objects OfferId is equal to the passed offerid parameter then
                {
                    validOffer = count; // sets validOffer to the value of count variable
                }
                count++; // adds 1 to the count variable
            }
            return allPropertyOffers[validOffer]; // returns the PropertyOffer object at the validOffer index from the allPropertyOffers list object
        }

        public void RemovePropertyOffer(int propertyID) // public RemovePropertyOffer function that accepts a propertyID parameter
        {
            SqlCommand deleteProcedure = new SqlCommand(); // // SqlCommand object called deleteProcedure set to a new SqlCommand object
            deleteProcedure.CommandType = CommandType.StoredProcedure; // sets deleteProcedure's CommandType to the StoredProcedure command type
            deleteProcedure.CommandText = "DeletePropertiesOffersByPropertyID"; // sets deleteProcedure's CommandText to DeletePropertiesOffersByPropertyID
            deleteProcedure.Parameters.AddWithValue("@PropertyID", propertyID); // Adds a parameter with value to the deleteProcedure object with @PropertyID as the name and the passed propertyID parameter as the value
            databaseHandler.DoUpdate(deleteProcedure); // calls the DoUpdate function of the databaseHandler object with the deleteProcedure object as a parameter 
        }
    }
}
