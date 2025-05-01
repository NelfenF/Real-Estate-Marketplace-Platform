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
    public class CoolingSystemList
    {
        private DBConnect databaseHandler = new DBConnect(); // private DBConnect object called databaseHandler set to a new DBConnect object
        private List<CoolingSystem> allCoolingSystems; // private List of CoolingSystem objects called allCoolingSystems
        public CoolingSystemList()  // public CoolingSystemList object initializer
        {
            allCoolingSystems = new List<CoolingSystem>(); // sets allCoolingSystems to a new List of CoolingSystem objects
            SqlCommand selectProcedure = new SqlCommand(); // SqlCommand object called selectProcedure set to a new SqlCommand object
            selectProcedure.CommandType = CommandType.StoredProcedure; // sets selectProceudre's CommandType to the StoredProcedure command type
            selectProcedure.CommandText = "SelectAllCoolingSystems"; // sets selectProceudre's CommandText to SelectAllCoolingSystems
            DataTable coolingSystemData = databaseHandler.GetDataSet(selectProcedure).Tables[0]; // DataTable object called coolingSystemData set to the first table of the returned value of GetDataSet function from the databaseHandler object with the selectProceudre as a parameter

            foreach (DataRow row in coolingSystemData.Rows) // foreach DataRow called row in coolingSystemData's rows do
            {
                allCoolingSystems.Add(new CoolingSystem((int)row["CoolingSystemID"], row["CoolingSystemName"].ToString())); // adds a new CoolingSystem object to allCoolingSystems list object with the row's CoolingSystemID column value converted to an int, row's CoolingSystemName column value converted to a string
            }
        }

        public List<CoolingSystem> GetCoolingSystems() // public GetCoolingSystems function that returns a list of CoolingSystem objects
        {
            return allCoolingSystems; // returns allCoolingSystems List object
        }
    }
}
