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
    public class RoomTypeList
    {
        private DBConnect databaseHandler = new DBConnect(); // private DBConnect object called databaseHandler set to a new DBConnect object
        private List<RoomType> roomTypes = new List<RoomType>(); // private List of RoomType objects called roomTypes set to a new list of RoomType

        public RoomTypeList() // public RoomTypeList object initializer
        { 
            roomTypes = new List<RoomType>(); // sets roomTypes to a new List of RoomType objects
            SqlCommand selectProcedure = new SqlCommand(); // SqlCommand object called selectProcedure set to a new SqlCommand object
            selectProcedure.CommandType = CommandType.StoredProcedure; // sets selectProceudre's CommandType to the StoredProcedure command type
            selectProcedure.CommandText = "SelectAllRoomTypes"; // sets selectProceudre's CommandText to SelectAllRoomTypes
            DataTable roomTypesData = databaseHandler.GetDataSet(selectProcedure).Tables[0]; // DataTable object called roomTypesData set to the first table of the returned value of GetDataSet function from the databaseHandler object with the selectProceudre as a parameter

            foreach (DataRow row in roomTypesData.Rows) // foreach DataRow called row in roomTypesData's rows do
            {
                roomTypes.Add(new RoomType((int)row["RoomTypeID"], row["RoomTypeName"].ToString())); // adds a new RoomType object to roomTypes list object with the row's RoomTypeID column value converted to an int, row's RoomTypeName column value converted to a string
            }
        }

        public List<RoomType> GetAllRoomTypes() // public GetAllRoomTypes function that returns a list of RoomType objects
        {
            return roomTypes; // returns roomTypes object
        } 
    }
}
