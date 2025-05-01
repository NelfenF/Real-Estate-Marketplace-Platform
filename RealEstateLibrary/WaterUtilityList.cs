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
    public class WaterUtilityList
    {
        private DBConnect databaseHandler = new DBConnect(); // private DBConnect object called databaseHandler set to a new DBConnect object
        private List<WaterUtility> allWaterUtilities; // private List of WaterUtility objects called allWaterUtilites
        public WaterUtilityList()  // public WaterUtilityList object initializer
        {
            allWaterUtilities = new List<WaterUtility>(); // sets allWaterUtilites to a new List of WaterUtility objects
            SqlCommand selectProcedure = new SqlCommand(); // SqlCommand object called selectProcedure set to a new SqlCommand object
            selectProcedure.CommandType = CommandType.StoredProcedure; // sets selectProceudre's CommandType to the StoredProcedure command type
            selectProcedure.CommandText = "SelectAllWaterUtilities"; // sets selectProceudre's CommandText to SelectAllWaterUtilites
            DataTable waterUtilityData = databaseHandler.GetDataSet(selectProcedure).Tables[0]; // DataTable object called waterUtilityData set to the first table of the returned value of GetDataSet function from the databaseHandler object with the selectProceudre as a parameter

            foreach (DataRow row in waterUtilityData.Rows) // foreach DataRow called row in waterUtilityData's rows do
            {
                allWaterUtilities.Add(new WaterUtility((int)row["WaterUtilityID"], row["WaterUtilityName"].ToString())); // adds a new WaterUtility object to allWaterUtilites WaterUtility list object with the row's WaterUtilityID column value converted to an int, row's WaterUtilityName column value converted to a string
            }
        }

        public List<WaterUtility> GetWaterUtilities() // public GetWaterUtilites function that returns a list of WaterUtility objects
        {
            return allWaterUtilities; // returns allWaterUtilites object
        }
    }
}
