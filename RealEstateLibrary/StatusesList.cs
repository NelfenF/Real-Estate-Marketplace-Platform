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
    public class StatusesList
    {
        private DBConnect databaseHandler = new DBConnect(); // private DBConnect object called databaseHandler set to a new DBConnect object
        private List<Statuses> statuses = new List<Statuses>(); // private List of Statuses objects called statuses set to a new list of Statuses
        public StatusesList() // public StatusesList object initializer
        { 
            statuses = new List<Statuses>(); // sets statuses to a new List of Statuses objects
            SqlCommand selectProcedure = new SqlCommand(); // SqlCommand object called selectProcedure set to a new SqlCommand object
            selectProcedure.CommandType = CommandType.StoredProcedure; // sets selectProceudre's CommandType to the StoredProcedure command type
            selectProcedure.CommandText = "SelectAllStatuses"; // sets selectProceudre's CommandText to SelectAllStatuses
            DataTable statusData = databaseHandler.GetDataSet(selectProcedure).Tables[0]; // DataTable object called statusData set to the first table of the returned value of GetDataSet function from the databaseHandler object with the selectProceudre as a parameter

            foreach (DataRow row in statusData.Rows) // foreach DataRow called row in waterUtilityData's rows do
            {
                statuses.Add(new Statuses((int)row["StatusID"], row["StatusName"].ToString())); // adds a new Statuses object to statuses list object with the row's StatusID column value converted to an int, row's StatusName column value converted to a string
            }
        }

        public List<Statuses> GetAllStatuses() // public GetAllStatuses function that returns a list of Statuses objects
        {
            return statuses; // returns statuses List object
        }
    }
}
