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
    public class HeatingSystemList
    {
        private DBConnect databaseHandler = new DBConnect(); // private DBConnect object called databaseHandler set to a new DBConnect object
        private List<HeatingSystem> allHeatingSystems; // private List of HeatingSystem objects called allHeatingSystems
        public HeatingSystemList() // public HeatingSystemList object initializer
        {
            allHeatingSystems = new List<HeatingSystem>(); // sets allHeatingSystems to a new List of HeatingSystem objects
            SqlCommand selectProcedure = new SqlCommand(); // SqlCommand object called selectProcedure set to a new SqlCommand object
            selectProcedure.CommandType = CommandType.StoredProcedure; // sets selectProceudre's CommandType to the StoredProcedure command type
            selectProcedure.CommandText = "SelectAllHeatingSystems"; // sets selectProceudre's CommandText to SelectAllHeatingSystems
            DataTable heatingSystemData = databaseHandler.GetDataSet(selectProcedure).Tables[0]; // DataTable object called heatingSystemData set to the first table of the returned value of GetDataSet function from the databaseHandler object with the selectProceudre as a parameter

            foreach (DataRow row in heatingSystemData.Rows) // foreach DataRow called row in waterUtilityData's rows do
            {
                allHeatingSystems.Add(new HeatingSystem((int)row["HeatingSystemID"], row["HeatingSystemName"].ToString())); // adds a new HeatingSystem object to heatingSystemData list object with the row's HeatingSystemID column value converted to an int, row's HeatingSystemName column value converted to a string
            }
        }

        public List<HeatingSystem> GetHeatingSystems() // public GetHeatingSystems function that returns a list of HeatingSystem objects
        {
            return allHeatingSystems; // returns allHeatingSystems List object
        }
    }
}
