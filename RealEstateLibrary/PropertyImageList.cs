using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateLibrary;
using System.IO;
using System.Web;

namespace RealEstateLibrary
{
    public class PropertyImageList
    {
        private List<PropertyImage> imageList; // private List of PropertyImage object called imageList
        private DBConnect databaseHandler = new DBConnect(); // private DBConnect object called databaseHandler set to a new DBConenct object

        public PropertyImageList() // public PropertyImageList initializer
        {
            imageList = new List<PropertyImage>(); // sets imageList to a new List of PropertyImage 
        }

        public List<PropertyImage> GetPropertyImages(int propertyID) // public GetPropertyImages function that returns a List of PropertyImage and accepts a int parameter
        {
            imageList = new List<PropertyImage>(); // sets imageList to a new List of PropertyImage objects
            SqlCommand selectProcedure = new SqlCommand(); // SqlCommand object called selectProcedure set to a new SqlCommand object
            selectProcedure.CommandType = CommandType.StoredProcedure; // sets selectProceudre's CommandType to the StoredProcedure command type
            selectProcedure.CommandText = "SelectAllPropertiesImagesByPropertyID"; // sets selectProceudre's CommandText to SelectAllPropertiesImagesByPropertyID
            selectProcedure.Parameters.AddWithValue("@PropertyID", propertyID); // Adds a parameter with value to the selectProceudre object with @PropertyID as the name and the agentID parameter as the value
            DataTable imageData = databaseHandler.GetDataSet(selectProcedure).Tables[0]; // DataTable object called imageData set to the first table of the returned value of GetDataSet function from the databaseHandler object with the selectProceudre as a parameter

            foreach (DataRow row in imageData.Rows) // foreach DataRow called row in imageData's rows do
            {
                imageList.Add(new PropertyImage((int)row["ImageID"], (int)row["PropertyID"], row["ImageURL"].ToString(), row["ImageDescription"].ToString())); // adds a new PropertyImage object to imageList list object with the row's ImageID column value converted to an int, the row's PropertyID column value converted to an int, the row's ImageURL column value converted to an string, and the row's ImageDescription column value converted to an string
            }

            return imageList; // returns imageList List object
        }

        public void RemovePropertyImages(List<int> imageIds) // public RemovePropertyImages function that accepts a List of ints as a parameter
        {
            foreach (int id in imageIds) // foreach int called id in imageIds list do
            {
                foreach (PropertyImage image in imageList) // foreach PropertyImage object called image in imageList list do
                {
                    if (image.ImageID == id) // if the current image objects ImageID is equal to the current int id then
                    {
                        SqlCommand deleteProcedure = new SqlCommand(); // SqlCommand object called deleteProcedure set to a new SqlCommand object
                        deleteProcedure.CommandType = CommandType.StoredProcedure; // sets deleteProcedure's CommandType to the StoredProcedure command type
                        deleteProcedure.CommandText = "DeleteImageByImageID"; // sets deleteProcedure's CommandText to SelectAllPropertiesImagesByPropertyID
                        deleteProcedure.Parameters.AddWithValue("@ImageID", id); // Adds a parameter with value to the deleteProcedure object with @ImageID as the name and the current int id as the value
                        databaseHandler.DoUpdate(deleteProcedure); // calls the DoUpdate function from the databaseHandler object with the deleteProcedure object as a parameter

                        //string path = image.ImageURL; // relative path
                        string folderPath = $"~/FileStorage/{image.PropertyID}"; // string variable called folderPath set to a string interpolation of ~/FileStorage/ and the current image objects PropertyID
                        string absoluteFolderPath = HttpContext.Current.Server.MapPath(folderPath); // string variable called absoluteFolderPath set to the returned value of the MapPath function with the folderPath string variable passed as a parameter, since my folderPath uses ~ as a way to get out of the main folder the application resides in, the path needs to be made into a real path because File and Directory can only understand absoulte paths
                        string path = HttpContext.Current.Server.MapPath(image.ImageURL); // string variable called path set to the returned value of the MapPath function with the current image objects ImageURL as a parameter, since my imageURL uses ~ as a way to get out of the main folder the application resides in, the path needs to be a real path because File and Directory can only understand real file paths

                        if (File.Exists(path)) // if the returned value of the Exists function with the path string as a parameter from the File object is true then
                        {
                            File.Delete(path); // calls the Delete function of the File object with the path string as a parameter
                        }

                        if (Directory.Exists(absoluteFolderPath)) // if the returned value of the Exists function with the path string as a parameter from the Directory object is true then
                        {
                            if (Directory.GetFiles(absoluteFolderPath).Length == 0) // if the length of the returned value of the GetFiles function with the absoulteFolderPath as a parameter is equal to 0 then
                            {
                                Directory.Delete(absoluteFolderPath); // calls the Delete function of the Directory object with the absoluteFolderPath string as a parameter
                            }
                        }

                    }
                }
            }
        }

        public void AddNewImagesToProperty(int propertyID, List<HttpPostedFile> newImagesToUpload, List<string> newImagesToUploadCaptions) // public AddNewImagesToProperty function that accepts a int, List of HttpPostedFile, and a list of string as parameters
        {
            int count = 0; // int variable called count set to 0
            string path = $"~/FileStorage/{propertyID}"; // string variable called path set to a string interpolation of ~/FileStorage/ and the propertyID parameter value
            string actualPath = HttpContext.Current.Server.MapPath(path); // string variable called actualPath set to the returned value of the MapPath function with the path string variable passed as a parameter, since my path uses ~ as a way to get out of the main folder the application resides in, the path needs to be made into a real path because File and Directory can only understand absoulte paths


            if (!Directory.Exists(actualPath)) // if the returned value of the Exisits function with actualPath string as a parameter from the Directory object is false then
            {
                Directory.CreateDirectory(actualPath); // calls the CreateDirectory function of the Directory object with the actualPath string as a parameter
            }
            foreach (HttpPostedFile image in newImagesToUpload) // foreach HttpPostedFile called imaged in newImagesToUplaod list object do
            {

                string fileExtenstion = Path.GetExtension(image.FileName); // string variable called fileExtenstion set to the returned value of the GetExtension function of the Path object with the current image objects FileName as a parameter
                string newFileName = $"{propertyID}_{count}{fileExtenstion}"; // string variable called newFileName set to a string interpolation of the passed PropertyID parameter plus _ plus the count variable plus the fileExtension string 
                string fullPath = Path.Combine(actualPath, newFileName); // string variable called fullPath set to the returned value of the Combine function of the Path object with the actualPath and newFileName strings as parameters
                image.SaveAs(fullPath); // calls the SaveAs function on the current image object with the fullPath as a parameter
                SqlCommand insertProcedure = new SqlCommand(); // SqlCommand object called insertProcedure set to a new SqlCommand object
                insertProcedure.CommandType = CommandType.StoredProcedure; // sets insertProcedure's CommandType to the StoredProcedure command type
                insertProcedure.CommandText = "InsertNewPropertyImage"; // sets insertProcedure's CommandText to InsertNewPropertyImage
                insertProcedure.Parameters.AddWithValue("@PropertyID", propertyID); // Adds a parameter with value to the insertProcedure object with @PropertyID as the name and the passed propertyID parameter as the value
                insertProcedure.Parameters.AddWithValue("@ImageURL", "~/FileStorage/" + propertyID + "/" + propertyID + "_" + count + fileExtenstion); // Adds a parameter with value to the insertProcedure object with @ImageURL as the name and a string interpolation with ~/FileStorage/ plus the propertyID parameter plus / plus the propertyID parameter plus _ plus the count variable plus the fileExtenstion variable as the value
                insertProcedure.Parameters.AddWithValue("@ImageDescription", newImagesToUploadCaptions[count]);  // Adds a parameter with value to the insertProcedure object with @ImageDescription as the name and string at the newImagesToUploadCaptions count index as the value
                databaseHandler.DoUpdate(insertProcedure); // calls the DoUpdate function of the databaseHandler object with the insertProcedure object as a parameter
                count++; // adds 1 to the current value of the count variable
            }
        }

        public void AddNewImagesToProperty(int propertyID, List<HttpPostedFile> newImagseToUpload, List<string> newImagesToUploadCaptions, int exisitingCount, List<PropertyImage> propertyImages) // public AddNewImagesToProperty function that accepts a int, List of HttpPostedFile, a int, and a list of string as parameters
        {
            int imageCount = 0; // int variable called imageCount set to 0
            int fileCount = 0; // int variable called fileCount set to 0
            int count = 0; // int variable called count set to 0
            if (exisitingCount != 0) // if the passed existingCount parameter is not equal to zero then
            {
                imageCount = propertyImages.Count - 1; // sets imageCount to the count of the passed propertyImages list count
                string lastImagePath = propertyImages[imageCount].ImageURL; // string variable called lastImagePath set to the imageCount index of propertyImages list object's ImageUrl
                string fileName = lastImagePath.Split('/')[3]; // string variable called fileName set to the fourth index of the returned value of the Split function of the lastImagePath variable set to split the string whenever there is a /
                string extension = fileName.Split('_')[1]; // string variable called extension set to the second index of the returned value of the Split function of the fileName variable set to split the string whenever there is a _
                string lastImageNumber = extension.Split('.')[0]; // string variable called lastImageNumber set to the first index of the returned value of the Split function of the extension variable set to split the string whenever there is a .
                fileCount = int.Parse(lastImageNumber) + 1; // sets fileCount variable to the converted int value of the lastImageNumber variable plus 1
            }
            string path = $"~/FileStorage/{propertyID}"; // string variable called path set to a string interpolation of ~/FileStorage/ and the propertyID parameter value
            string actualPath = HttpContext.Current.Server.MapPath(path); // string variable called actualPath set to the returned value of the MapPath function with the path string variable passed as a parameter, since my path uses ~ as a way to get out of the main folder the application resides in, the path needs to be made into a real path because File and Directory can only understand absoulte paths
            if (!Directory.Exists(actualPath)) // if the returned value of the Exisits function with actualPath string as a parameter from the Directory object is false then
            {
                Directory.CreateDirectory(actualPath); // calls the CreateDirectory function of the Directory object with the actualPath string as a parameter
            }
            foreach (HttpPostedFile image in newImagseToUpload) // foreach HttpPostedFile called imaged in newImagesToUplaod list object do
            {

                string fileExtenstion = Path.GetExtension(image.FileName); // string variable called fileExtenstion set to the returned value of the GetExtension function of the Path object with the current image objects FileName as a parameter
                string newFileName = $"{propertyID}_{fileCount}{fileExtenstion}"; // string variable called newFileName set to a string interpolation of the passed PropertyID parameter plus _ plus the count variable plus the fileExtension string
                string fullPath = Path.Combine(actualPath, newFileName); // string variable called fullPath set to the returned value of the Combine function of the Path object with the actualPath and newFileName strings as parameters


                image.SaveAs(fullPath); // calls the SaveAs function on the current image object with the fullPath as a parameter

                SqlCommand insertProcedure = new SqlCommand(); // SqlCommand object called insertProcedure set to a new SqlCommand object
                insertProcedure.CommandType = CommandType.StoredProcedure; // sets insertProcedure's CommandType to the StoredProcedure command type
                insertProcedure.CommandText = "InsertNewPropertyImage"; // sets insertProcedure's CommandText to InsertNewPropertyImage
                insertProcedure.Parameters.AddWithValue("@PropertyID", propertyID); // Adds a parameter with value to the insertProcedure object with @PropertyID as the name and the passed propertyID parameter as the value
                insertProcedure.Parameters.AddWithValue("@ImageURL", "~/FileStorage/" + propertyID + "/" + propertyID + "_" + fileCount + fileExtenstion); // Adds a parameter with value to the insertProcedure object with @ImageURL as the name and a string interpolation with ~/FileStorage/ plus the propertyID parameter plus / plus the propertyID parameter plus _ plus the count variable plus the fileExtenstion variable as the value
                insertProcedure.Parameters.AddWithValue("@ImageDescription", newImagesToUploadCaptions[count]); // Adds a parameter with value to the insertProcedure object with @ImageDescription as the name and string at the newImagesToUploadCaptions count index as the value
                databaseHandler.DoUpdate(insertProcedure); // calls the DoUpdate function of the databaseHandler object with the insertProcedure object as a parameter

                count++; // adds one to the count variable
                fileCount++; // adds one to the fileCount variable
            }
        }
    }
}
