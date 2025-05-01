using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateLibrary;

namespace RealEstateLibrary
{
    public class PropertyRoomList
    {
        DBConnect databaseHandler = new DBConnect(); // private DBConnect object called databaseHandler set to a new DBConnect object
        private List<PropertyRoom> roomList; // private List of PropertyRoom objects called roomList set to a new list of PropertyRoom

        public PropertyRoomList() // public PropertyRoomList object initializer
        {

        }
        public PropertyRoomList(int propertyID) // public PropertyRoomList object initializer that accepts a int parameter
        {
            roomList = new List<PropertyRoom>(); // sets roomList to a new List of PropertyRoom objects
            SqlCommand selectProcedure = new SqlCommand(); // SqlCommand object called selectProcedure set to a new SqlCommand object
            selectProcedure.CommandType = CommandType.StoredProcedure; // sets selectProceudre's CommandType to the StoredProcedure command type
            selectProcedure.CommandText = "SelectAllRoomsByPropertyID"; // sets selectProceudre's CommandText to SelectAllRoomsByPropertyID
            selectProcedure.Parameters.AddWithValue("@PropertyID", propertyID); // Adds a parameter with value to the selectProcedure object with @PropertyID as the name and the propertyID parameter as the value
            DataTable roomData = databaseHandler.GetDataSet(selectProcedure).Tables[0]; // DataTable object called roomData set to the first table of the returned value of GetDataSet function from the databaseHandler object with the selectProceudre as a parameter

            foreach (DataRow row in roomData.Rows) // foreach DataRow called row in roomData's rows do
            {
                roomList.Add(new PropertyRoom((int)row["RoomID"], (int)row["PropertyID"], row["RoomType"].ToString(), (decimal)row["RoomLength"], (decimal)row["RoomWidth"], (decimal)row["TotalSqFt"])); // adds a new PropertyRoom object to roomList list object with the row's RoomID column value converted to an int, the row's PropertyID column value converted to an int, the row's RoomType column value converted to a string the row's RoomLength column value converted to an decimal, the row's RoomWidth column value converted to an decimal, and the row's TotalSqFt column value converted to an decimal
            }
        }

        public decimal GetAllRoomsTotalSqFt() // public GetAllRoomsTotalSqFt function that returns a decimal
        {
            decimal totalSqFt = 0; // decimal variable called totalSqFt set to 0
            foreach (PropertyRoom propertyRoom in roomList) // foreach PropertyRoom object called propertyRoom in the roomList List object do
            {
                totalSqFt += propertyRoom.TotalSqFt; // sets totalSqFt to itself plus the current propertyRoom's totalSqFt
            }
            return totalSqFt; // returns totalSqFt variable

        }

        public List<PropertyRoom> GetRoomList() // public GetRoomList function that returns a List of PropertyRoom objects
        {
            return roomList; // returns roomList object
        }

        public void RemoveAllRooms(int propertyID) // public RemoveAllRooms function that accepts a int parameter
        {
            SqlCommand deleteProcedure = new SqlCommand(); // SqlCommand object called deleteProcedure set to a new SqlCommand object
            deleteProcedure.CommandType = CommandType.StoredProcedure; // sets deleteProcedure's CommandType to the StoredProcedure command type
            deleteProcedure.CommandText = "DeleteRoomsByPropertyID"; // sets deleteProcedure's CommandText to DeleteRoomsByPropertyID
            deleteProcedure.Parameters.AddWithValue("@PropertyID", propertyID); // Adds a parameter with value to the deleteProcedure object with @PropertyID as the name and the propertyID parameter as the value
            databaseHandler.DoUpdate(deleteProcedure); // calls the DoUpdate function of the databaseHandler object with the deleteProcedure object as a parameter
        }

        public void RemoveSingleRoom(int roomID) // public RemoveSingleRoom function that accepts a int parameter
        {
            SqlCommand deleteProcedure = new SqlCommand(); // SqlCommand object called deleteProcedure set to a new SqlCommand object
            deleteProcedure.CommandType = CommandType.StoredProcedure; // sets deleteProcedure's CommandType to the StoredProcedure command type
            deleteProcedure.CommandText = "DeleteRoomByRoomID"; // sets deleteProcedure's CommandText to DeleteRoomByRoomID
            deleteProcedure.Parameters.AddWithValue("@RoomID", roomID); // Adds a parameter with value to the deleteProcedure object with @RoomID as the name and the roomID parameter as the value
            databaseHandler.DoUpdate(deleteProcedure); // calls the DoUpdate function of the databaseHandler object with the deleteProcedure object as a parameter
        }

        public void RemoveSingleRoom(List<int> roomID) // public RemoveSingleRoom function that accepts a List of int variables as a parameter
        {
            foreach(int id in roomID) // foreach int called id in roomID List object do
            {
                SqlCommand deleteProcedure = new SqlCommand(); // SqlCommand object called deleteProcedure set to a new SqlCommand object
                deleteProcedure.CommandType = CommandType.StoredProcedure; // sets deleteProcedure's CommandType to the StoredProcedure command type
                deleteProcedure.CommandText = "DeleteRoomByRoomID"; // sets deleteProcedure's CommandText to DeleteRoomByRoomID
                deleteProcedure.Parameters.AddWithValue("@RoomID", id); // Adds a parameter with value to the deleteProcedure object with @RoomID as the name and the curreent id int variable in the loop as the value
                databaseHandler.DoUpdate(deleteProcedure); // calls the DoUpdate function of the databaseHandler object with the deleteProcedure object as a parameter
            }
        }

        public int GetNumberOfBedrooms(List<PropertyRoom> roomList) // public GetNumberOfBedrooms function that returns an int and accepts a List of PropertyRoom object as a parameter
        {
            int bedroomCount = 0; // int variable called bedroomCount set to 0
            foreach (PropertyRoom room in roomList) // foreach PropertyRoom object called room in the roomList list object do
            {
                if (room.RoomType == "Bedroom") // if the current room objects RoomType is equal to Bedroom then
                {
                    bedroomCount++; // adds one to the current value of bedroomCount
                }
            }
            return bedroomCount; // returns bedroomCount variable
        }

        public decimal GetNumberOfBathrooms(List<PropertyRoom> roomList) // public GetNumberOfBathrooms function that returns a decimal and accepts a List of PropertyRoom object as a parameter
        {
            decimal bathroomCount = 0; // decimal variable called bathroomCount set to 0
            foreach (PropertyRoom room in roomList) // foreach PropertyRoom object called room in the roomList list object do
            {
                if ( room.RoomType == "Bathroom") // if the current room object RoomType is equal to Bathroom then
                {
                    bathroomCount = bathroomCount + 1; // sets bathroomCount to itself plus 1
                }
                
                if (room.RoomType == "Half-Bathroom") // if the current room object RoomType is equal to Half-Bathroom then
                {
                    bathroomCount = bathroomCount + (decimal)0.5; // sets bathroomCount to itself plus 0.5
                }
            }

            return bathroomCount; // returns bathroomCount variable
        }

        public decimal GetTotalRoomSqFt(List<PropertyRoom> roomList) // public GetTotalRoomSqFt function that returns a decimal and accepts a List of PropertyRoom object as a parameter
        {
            decimal totalRoomSqFt = 0; // decimal variable called totalRoomSqFt set to 0
            foreach(PropertyRoom room in roomList) // foreach PropertyRoom object called room in the roomList list object do
            {
                totalRoomSqFt += room.TotalSqFt; // sets totalRoomSqFt to itself plus the current room objects TotalSqFt 
            }
             
            return totalRoomSqFt; // returns totalRoomSqFt variable
        }

        public void AddNewRoomToProperty(int propertyID, List<PropertyRoom> roomList) // public AddNewRoomToProperty function that accepts a int and List of Property Room object as a parameter
        {
            foreach (PropertyRoom room in roomList) // foreach PropertyRoom object called room in the roomList list object do
            {
                SqlCommand insertProcedure = new SqlCommand(); // SqlCommand object called insertProcedure set to a new SqlCommand object
                insertProcedure.CommandType = CommandType.StoredProcedure; // sets insertProcedure's CommandType to the StoredProcedure command type
                insertProcedure.CommandText = "InsertNewRoom"; // sets insertProcedure's CommandText to InsertNewRoom
                insertProcedure.Parameters.AddWithValue("@PropertyID", propertyID); // Adds a parameter with value to the insertProcedure object with @PropertyID as the name and the propertyID int passed parameter as the value
                insertProcedure.Parameters.AddWithValue("@RoomType", room.RoomType); // Adds a parameter with value to the insertProcedure object with @PropertyID as the name and the current room objects RoomType as the value
                insertProcedure.Parameters.AddWithValue("@RoomLength", room.RoomLength); // Adds a parameter with value to the insertProcedure object with @RoomLength as the name and the current room objects RoomLength as the value
                insertProcedure.Parameters.AddWithValue("@RoomWidth", room.RoomWidth); // Adds a parameter with value to the insertProcedure object with @RoomWidth as the name and the current room objects RoomWidth as the value
                insertProcedure.Parameters.AddWithValue("@TotalSqFt", room.TotalSqFt); // Adds a parameter with value to the insertProcedure object with @TotalSqFt as the name and the current room objects TotalSqFt as the value
                databaseHandler.DoUpdate(insertProcedure); // calls the DoUpdate function of the databaseHandler object with the insertProcedure object as a parameter
            }
        }

    }
}
