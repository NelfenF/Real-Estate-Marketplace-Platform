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
    public class PropertyPriceHistoryList
    {
        private DBConnect databaseHandler = new DBConnect(); // private DBConnect object called databaseHandler set to a new DBConnect object
        private List<PropertyPriceHistory> allPropertyPriceHistory = new List<PropertyPriceHistory>(); // private List of PropertyPriceHistory objects called allPropertyPriceHistory set to a new list of PropertyPriceHistory
        private List<PropertyPriceHistory> propertyPriceHistories = new List<PropertyPriceHistory>(); // private List of PropertyPriceHistory objects called propertyPriceHistories set to a new list of PropertyPriceHistory

        public PropertyPriceHistoryList() // public StatusesList object initializer
        {
            allPropertyPriceHistory = new List<PropertyPriceHistory>(); // sets allPropertyPriceHistory to a new List of PropertyPriceHistory objects
            SqlCommand selectProcedure = new SqlCommand(); // SqlCommand object called selectProcedure set to a new SqlCommand object
            selectProcedure.CommandType = CommandType.StoredProcedure; // sets selectProceudre's CommandType to the StoredProcedure command type
            selectProcedure.CommandText = "SelectAllPropertiesPriceHistory"; // sets selectProceudre's CommandText to SelectAllPropertiesPriceHistory
            DataTable priceHistoryData = databaseHandler.GetDataSet(selectProcedure).Tables[0]; // DataTable object called priceHistoryData set to the first table of the returned value of GetDataSet function from the databaseHandler object with the selectProceudre as a parameter

            foreach (DataRow row in priceHistoryData.Rows) // foreach DataRow called row in priceHistoryData's rows do
            {
                allPropertyPriceHistory.Add(new PropertyPriceHistory((int)row["PriceHistoryID"], (int)row["PropertyID"], (decimal)row["NewPrice"], (DateTime)row["PriceUpdateDate"])); // adds a new PropertyPriceHistory object to allPropertyPriceHistory list object with the row's PriceHistoryID column value converted to an int, the row's PropertyID column value converted to an int, the row's NewPrice column value converted to a decimal, and the row's PriceUpdateDate column converted to a DateTime
            }
        }

        public void AddNewPropertyPriceHistory(int propertyID, decimal newPrice) // public AddNewPropertyPriceHistory function that accepts a int and decimal parameter
        {
            DateTime currentDate = DateTime.Now; // DateTime object called currentDate set to the current date and time now 
            SqlCommand insertProcedure = new SqlCommand(); // SqlCommand object called insertProcedure set to a new SqlCommand object
            insertProcedure.CommandType = CommandType.StoredProcedure; // sets insertProcedure's CommandType to the StoredProcedure command type
            insertProcedure.CommandText = "InsertNewPropertyPriceHistory"; // sets insertProcedure's CommandText to InsertNewPropertyPriceHistory
            insertProcedure.Parameters.AddWithValue("@PropertyID", propertyID); // Adds a parameter with value to the insertProcedure object with @PropertyID as the name and the propertyID parameter as the value
            insertProcedure.Parameters.AddWithValue("@NewPrice", newPrice); // Adds a parameter with value to the insertProcedure object with @NewPrice as the name and the newPrice parameter as the value
            insertProcedure.Parameters.AddWithValue("@PriceUpdateDate", currentDate.Date); // Adds a parameter with value to the insertProcedure object with @PriceUpdateDate as the name and the currentData objects Date as the value
            databaseHandler.DoUpdate(insertProcedure); // calls the DoUpdate function of the databaseHandler object with the insertProcedure object as a parameter
        }

        public List<PropertyPriceHistory> GetPropertyPriceHistory(int propertyID) // public GetPropertyPriceHistory function that returns a List of PropertyPriceHistory objects and accepts a int as a parameter
        {
            propertyPriceHistories= new List<PropertyPriceHistory>(); // sets propertyPriceHistories to a new List of PropertyPriceHistory objects
            foreach (PropertyPriceHistory history in allPropertyPriceHistory) // foreach PropertyPriceHistory object called history in the allPropertyPriceHistory list object do
            {
                if (history.PropertyID == propertyID) // if the current history objects PropertyID is equal to the propertyID parameter then
                {
                    propertyPriceHistories.Add(history); // adds the current history object to the propertyPriceHistories list object
                }
            }
            return propertyPriceHistories; // returns propertyPriceHistories list object
        }
        
    }
}
