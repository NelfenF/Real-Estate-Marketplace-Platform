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
    public class SewerUtilityList
    {
        private DBConnect databaseHandler = new DBConnect(); // private DBConnect object called databaseHandler set to a new DBConnect object
        private List<SewerUtility> allSewerUtilities; // private List of SewerUtility objects called allSewerUtilities
        public SewerUtilityList()
        {
            allSewerUtilities = new List<SewerUtility>(); // sets statuses to a new List of Statuses objects
            SqlCommand selectProcedure = new SqlCommand(); // SqlCommand object called selectProcedure set to a new SqlCommand object
            selectProcedure.CommandType = CommandType.StoredProcedure; // sets selectProceudre's CommandType to the StoredProcedure command type
            selectProcedure.CommandText = "SelectAllSewerUtilities"; // sets selectProceudre's CommandText to SelectAllStatuses
            DataTable sewerUtilityData = databaseHandler.GetDataSet(selectProcedure).Tables[0]; // DataTable object called sewerUtilityData set to the first table of the returned value of GetDataSet function from the databaseHandler object with the selectProceudre as a parameter

            foreach (DataRow row in sewerUtilityData.Rows) // foreach DataRow called row in waterUtilityData's rows do
            {
                allSewerUtilities.Add(new SewerUtility((int)row["SewerUtilityID"], row["SewerUtilityName"].ToString())); // adds a new SewerUtility object to allSewerUtilities list object with the row's SewerUtilityID column value converted to an int, row's SewerUtilityName column value converted to a string
            }
        }

        public List<SewerUtility> GetAllSewerUtilites() // public GetAllSewerUtilites function that returns a list of SewerUtility objects
        {
            return allSewerUtilities; // returns allSewerUtilities object
        }
    }
}
