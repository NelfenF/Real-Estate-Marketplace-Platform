using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RealEstateLibrary;

namespace FLOHR_ProjectThree
{
    public partial class frmMainDashboard : System.Web.UI.Page
    { 
        private AgentDashboardController agentHandler; // private AgentDashboardController object called agentHandler
        private Validate validater = new Validate(); // private Validate object called validater set to a new Validate obeject
        private Dictionary<string,string> newPropertyInformation; // private stringDictionary called newPropertyInformation
        private Dictionary<string, string> updatedPropertyInformation; // private string Dictionary called updatedPropertyInformation
        private List<int> newPropertyAmenities; // private List of ints object called newProeprtyAmenities
        private List<int> updatedPropertyAmenitites; // private List of ints object called updatedPropertyAmenitites
        private List<PropertyRoom> newPropertyRooms; // private List of PropertyRoom objects called newPropertyRooms
        private List<HttpPostedFile> uploadedImages = new List<HttpPostedFile>();  // private List of HttpPostedFile objects called uploadedImages set to a new List of HttpPostedFile objects
        private List<string> uploadedImagesCaptions = new List<string>(); // private List of strings object called uploadedImagesCaptions set to a new List of string object

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AgentHandler"] == null) // if Session key AgentHandler is null then
            {
                agentHandler = new AgentDashboardController(); // sets agentHandler to a new AgentDashboardController object
                Session["AgentHandler"] = agentHandler; // sets Session key AgentHandler to the agentHandler object
            } 
            else // else the AgentHandler object is not null
            {
                agentHandler = (AgentDashboardController)Session["AgentHandler"]; // sets agentHandler to the Session key AgentHandlers value converted to a AgentDashboardController object
            }

            if (Request.Cookies["Account"] != null) //  if Request has a cookie called Account and it is not null then
            {
                int accountID = int.Parse(Request.Cookies["Account"].Value); //int accountID set to the converted int value of the Account cookies value
                agentHandler.SetAgentAccount(accountID); // calls the SetAgentAccount function from the agentHandler object with accountID as the parameter
            }
            else // else the cookie does not exisit or it is null
            {
                Response.Redirect("frmLogin.aspx"); // Calls the redirect function from the REsponse object with frmLogin.aspx as a parameter
            }

            if (!IsPostBack) // if the response is not a postback then
            {
                BindAllInputs(); // calls the BindAllInputs function
            }
        }
        private void BindAllInputs()// private BindAllInputs function 
        {
            chklAmenities.DataSource = agentHandler.GetAmenititesList(); // sets chklAmenities datasource to the returned value from GetAmenititesList function from the agentHandler object
            chklAmenities.DataTextField = "AmenityName"; // sets chklAmenities DataTextField to AmenityName
            chklAmenities.DataValueField = "AmenityID"; // sets chklAmenities DataValueField to AmenityID
            chklAmenities.DataBind(); // calls the DataBind function from the chklAmenities checkboxlist

            chklstEditAmenities.DataSource = agentHandler.GetAmenititesList(); // sets chklstEditAmenities datasource to the returned value from GetAmenititesList function from the agentHandler object
            chklstEditAmenities.DataTextField = "AmenityName";
            chklstEditAmenities.DataValueField = "AmenityID";
            chklstEditAmenities.DataBind();

            drplCoolingType.DataSource = agentHandler.GetCoolingSystems(); // sets drplCoolingType datasource to the returned value from GetCoolingSystems function from the agentHandler object
            drplCoolingType.DataTextField = "CoolingSystemName";
            drplCoolingType.DataValueField = "CoolingSystemName";
            drplCoolingType.DataBind();

            drplEditCooling.DataSource = agentHandler.GetCoolingSystems(); // sets drplEditCooling datasource to the returned value from GetCoolingSystems function from the agentHandler object
            drplEditCooling.DataTextField = "CoolingSystemName";
            drplEditCooling.DataValueField = "CoolingSystemName";
            drplEditCooling.DataBind();

            drplHeatingType.DataSource = agentHandler.GetHeatingSystems(); // sets drplHeatingType datasource to the returned value from GetHeatingSystems function from the agentHandler object
            drplHeatingType.DataTextField = "HeatingSystemName";
            drplHeatingType.DataValueField = "HeatingSystemName";
            drplHeatingType.DataBind();

            drplEditHeating.DataSource = agentHandler.GetHeatingSystems(); // sets drplEditHeating datasource to the returned value from GetHeatingSystems function from the agentHandler object
            drplEditHeating.DataTextField = "HeatingSystemName";
            drplEditHeating.DataValueField = "HeatingSystemName";
            drplEditHeating.DataBind();

            drplWaterUtilities.DataSource = agentHandler.GetWaterUtilites(); // sets drplWaterUtilities datasource to the returned value from GetWaterUtilites function from the agentHandler object
            drplWaterUtilities.DataTextField = "WaterUtilityName";
            drplWaterUtilities.DataValueField = "WaterUtilityName";
            drplWaterUtilities.DataBind();

            drplEditWater.DataSource = agentHandler.GetWaterUtilites(); // sets drplEditWater datasource to the returned value from GetWaterUtilites function from the agentHandler object
            drplEditWater.DataTextField = "WaterUtilityName";
            drplEditWater.DataValueField = "WaterUtilityName";
            drplEditWater.DataBind();

            drplSewerUtilities.DataSource = agentHandler.GetSewerUtilities(); // sets drplSewerUtilities datasource to the returned value from GetSewerUtilities function from the agentHandler object
            drplSewerUtilities.DataTextField = "SewerUtilityName"; 
            drplSewerUtilities.DataValueField = "SewerUtilityName";
            drplSewerUtilities.DataBind();

            drplEditSewer.DataSource = agentHandler.GetSewerUtilities(); // sets drplEditSewer datasource to the returned value from GetSewerUtilities function from the agentHandler object
            drplEditSewer.DataTextField = "SewerUtilityName";
            drplEditSewer.DataValueField = "SewerUtilityName";
            drplEditSewer.DataBind();
             
            drplPropertyStatus.DataSource = agentHandler.GetStatuses(); // sets drplPropertyStatus datasource to the returned value from GetStatuses function from the agentHandler object
            drplPropertyStatus.DataTextField = "StatusName";
            drplPropertyStatus.DataValueField = "StatusName";
            drplPropertyStatus.DataBind();

            drplEditPropertyStatus.DataSource = agentHandler.GetStatuses(); // sets drplEditPropertyStatus datasource to the returned value from GetStatuses function from the agentHandler object
            drplEditPropertyStatus.DataTextField = "StatusName";
            drplEditPropertyStatus.DataValueField = "StatusName";
            drplEditPropertyStatus.DataBind();

            radlPropertyType.DataSource = agentHandler.GetPropertyTypes(); // sets radlPropertyType datasource to the returned value from GetPropertyTypes function from the agentHandler object
            radlPropertyType.DataTextField = "TypeName";
            radlPropertyType.DataValueField = "TypeName";
            radlPropertyType.DataBind();

            radlEditPropertyType.DataSource = agentHandler.GetPropertyTypes(); // sets radlEditPropertyType datasource to the returned value from GetPropertyTypes function from the agentHandler object
            radlEditPropertyType.DataTextField = "TypeName";
            radlEditPropertyType.DataValueField = "TypeName";
            radlEditPropertyType.DataBind();

            radlRoomType.DataSource = agentHandler.GetAllRoomTypes(); // sets radlRoomType datasource to the returned value from GetAllRoomTypes function from the agentHandler object
            radlRoomType.DataTextField = "RoomTypeName";
            radlRoomType.DataValueField = "RoomTypeName";
            radlRoomType.DataBind();

            radlEditNewRoomType.DataSource = agentHandler.GetAllRoomTypes(); // sets radlEditNewRoomType datasource to the returned value from GetAllRoomTypes function from the agentHandler object
            radlEditNewRoomType.DataTextField = "RoomTypeName";
            radlEditNewRoomType.DataValueField = "RoomTypeName";
            radlEditNewRoomType.DataBind();
            // sets the lblUserDispaly labels text to a welcome message and information about the program
            lblUserDisplay.Text = "Welcome, " + agentHandler.GetCurrentLoggedInAccount().FirstName.ToString() + "<br/>" +
                                    "This is the agent dashboard and it offers many features for you to complete your job!<br/>" +
                                    "Some of the features included are: <br/>" +
                                    "<li>Create a new listing - Click on the Create New Listing button and complete the form to add a new listing to the service</li>" +
                                    "<li>Modify your listings - Click on the View Your Listings button and view, edit, or delete your created listings</li>" +
                                    "<li>View your scheduled showings - Click on the View Your Scheduled Showings button to check your upcoming showings for your listings</li>" +
                                    "<li>View your offers - Click on the View Your Pending Offers button to check accept or deny offers made on your listings</li>" +
                                    "To get back to the main dashboard press the logout button!";

        }

        private void ShowNewRoomArea() // private ShowNewRoomArea function
        {
            newListingRooms.Visible = true; // sets newListingRooms to be visible
        }

        private void HideNewRoomArea() // private HideNewRoomArea function
        {
            newListingRooms.Visible = false; // sets newListingRooms to not be visible
        }

        private void ShowImageUploadArea() // private ShowImageUploadArea function
        {
            uploadArea.Visible = true; // sets uploadArea to be visible
        }

        public void HideImageUploadArea() // private HideImageUploadArea function
        {
            uploadArea.Visible = false; // sets uploadArea to not be visible
        }

        protected void btnStartAddingRooms_Click(object sender, EventArgs e) // button btnStartAddingRooms_Click event handler
        {
            if (newListingRooms.Visible == true) // if newListingRooms is visible then
            {
                HideNewRoomArea(); // calls HideNewRoomArea function
            }
            else // else newListingRooms is not visible 
            {
                ShowNewRoomArea(); // calls ShowNewRoomArea function
            }
        }

        protected void btnStartUploadingImages_Click(object sender, EventArgs e) // button btnStartUploadingImages_Click event handler
        {
            if (uploadArea.Visible == true) // if uploadArea is visible then
            {
                HideImageUploadArea(); // calls HideImageUploadArea function
            }
            else // else uploadArea is not visible 
            {
                ShowImageUploadArea(); // calls ShowImageUploadArea function
            }
        }

        protected void btnSubmitVerifyListing_Click(object sender, EventArgs e) // button btnSubmitVerifyListing_Click event handler
        {
            ResetErrorMessage(); // calls ResetErrorMessage function
            if (ValidateNewListing() == true) // if ValidateNewListing function returns true then
            {
                GetNewPropertyInformation(); // calls GetNewPropertyInformation function
                GetNumberOfBathroomsForNewProperty(); // calls GetNumberOfBathroomsForNewProperty function
                GetNumberOfBedroomsForNewProperty(); // calls GetNumberOfBedroomsForNewProperty function
                agentHandler.MakeNewProperty(newPropertyInformation); // calls MakeNewProperty function from the agentHandler object with newPropertyInformation as a parameter
                agentHandler.AddNewProperty(); // calls AddNewProperty function from the agentHandler object
                int newPropertyZipCode = int.Parse(newPropertyInformation["ZipAddress"]);// int newPropertyZipCode set to the converted int value of the value from the newPropertyInformation key ZipAddress dictionary
                int newPropertyID = agentHandler.GetPropertyByStreetAddressAndZipCode(newPropertyInformation["StreetAddress"], newPropertyZipCode).PropertyID; // int newPropertyID set to the returned value from the GetPropertyByStreetAddressAndZipCode from the agentHandler object with the the value from the newPropertyInformation key StreetAddress dictionary and the newPropertyZipCode 
                agentHandler.AddNewImagesToProperty(newPropertyID); // calls AddNewImagesToProperty function from the agentHandler object with newPropertyID as a parameter
                agentHandler.FinalizeNewRooms(newPropertyID); // calls FinalizeNewRooms function from the agentHandler object with newPropertyID as a parameter
                agentHandler.AddNewPropertyAmenities(newPropertyAmenities, newPropertyID); // calls AddNewPropertyAmenities function from the agentHandler object with newPropertyAmenities and newPropertyID as a parameter
                agentHandler.AddNewPropertyStatus(newPropertyID, drplPropertyStatus.SelectedValue.ToString()); // calls AddNewPropertyStatus function from the agentHandler object with newPropertyID and the selected value from the drplPropertyStatus droplist as a parameter
                agentHandler.AddNewPriceHistory(newPropertyID, decimal.Parse(newPropertyInformation["AskingPrice"])); // calls AddNewPriceHistory function from the agentHandler object with newPropertyID and the  as a parameter
                ResetNewListingArea(); // calls ResetNewListingArea function
                lblNewListingConfirmation.Text = "Property has been added sucessfully added!"; // sets lblNewListingConfirmation text to a confirmation message
            }


        }

        private void GetNewPropertyInformation() // private GetNewPropertyInformation function
        {
            // Gets info from textboxes and puts it in a dictionary -- fingers hurrrrt
            newPropertyInformation = new Dictionary<string, string>();
            newPropertyAmenities = new List<int>();
            newPropertyInformation.Add("AgentID", agentHandler.GetCurrentLoggedInAccountID().ToString());
            newPropertyInformation.Add("StreetAddress", txtStreetAddress.Text);
            newPropertyInformation.Add("CityAddress", txtCityAddress.Text);
            newPropertyInformation.Add("StateAddress", drplStateAddress.SelectedItem.ToString());
            newPropertyInformation.Add("ZipAddress", txtZipAddress.Text);
            newPropertyInformation.Add("YearBuilt", txtYearBuilt.Text);
            newPropertyInformation.Add("Description", txtDescription.Text);
            newPropertyInformation.Add("AskingPrice", txtAskingPrice.Text);
            newPropertyInformation.Add("Type", radlPropertyType.SelectedItem.ToString());
            newPropertyInformation.Add("Garage", txtNumberGarage.Text);
            newPropertyInformation.Add("Heating", drplHeatingType.SelectedItem.ToString());
            newPropertyInformation.Add("Cooling", drplCoolingType.SelectedItem.ToString());
            newPropertyInformation.Add("Water", drplWaterUtilities.SelectedItem.ToString());
            newPropertyInformation.Add("Sewer", drplSewerUtilities.SelectedItem.ToString());

            foreach (ListItem option in chklAmenities.Items)
            {
                if (option.Selected == true)
                {
                    newPropertyAmenities.Add(int.Parse(option.Value));
                }
            }
        }

        private void GetNumberOfBathroomsForNewProperty() // private GetNumberOfBathroomsForNewProperty function
        {
            newPropertyInformation.Add("Bathrooms", agentHandler.GetNumberOfBathrooms().ToString());
        }

        private void GetNumberOfBedroomsForNewProperty() // private GetNumberOfBedroomsForNewProperty function
        {
            newPropertyInformation.Add("Bedrooms", agentHandler.GetNumberOfBedrooms().ToString());
        }

        protected void btnAddRoom_Click(object sender, EventArgs e) // button btnAddRoom_Click event handler
        {
            ResetRoomErrorMessage(); // calls ResetRoomErrorMessage function
            if (ValidateListingRoom() == true) // if ValidateListingRoom function returns true then 
            {
                agentHandler.AddNewPropertyRoom(radlRoomType.SelectedItem.ToString(), txtRoomLength.Text, txtRoomWidth.Text); // calls the AddNewPropertyRoom function of the agentHandler object with controls values as parameters
                newPropertyRooms = agentHandler.GetNewPropertyRooms(); // sets newPropertyRooms to the returned value of GetNewPropertyRooms function from the agentHandler oject
                // sets gvRooms datasource and binds the data
                gvRooms.DataSource = newPropertyRooms;
                gvRooms.DataBind();
                ResetRoomInput(); // calls ResetRoomInput function
            }
        }

        private void ResetRoomInput() // private ResetRoomInput function
        {
            radlRoomType.SelectedIndex = -1; // sets radlRoomType SelectedIndex to -1
            txtRoomLength.Text = string.Empty; // sets  txtRoomLength Text to a empty string
            txtRoomWidth.Text = string.Empty; // sets  txtRoomLength Text to a empty string
        }

        protected void btnCreateNewListing_Click(object sender, EventArgs e) // button  btnCreateNewListing_Click event handler
        {
            if (newListingFormArea.Visible == false) // if btnCancelNewListing is not visible then
            {
                newListingFormArea.Visible = true; // sets newListingFormArea to be visible
                imageUpload.Visible = true; // sets imageUpload to be visible
                btnStartAddingRooms.Visible = true; // sets btnStartAddingRooms to be visible
                btnStartUploadingImages.Visible = true; // sets btnStartUploadingImages to be visible
                btnSubmitVerifyListing.Visible = true; // sets btnSubmitVerifyListing to be visible
                btnCancelNewListing.Visible = true;// sets btnCancelNewListing to be visible

            }
            else // else btnCancelNewListing is visible then
            {
                newListingFormArea.Visible=false; // sets newListingFormArea to not be visible
                imageUpload.Visible = false; // sets imageUpload to not be visible
                btnSubmitVerifyListing.Visible = false; // sets btnSubmitVerifyListing to not be visible
                btnCancelNewListing.Visible = false; // sets btnCancelNewListing to not be visible
                btnStartAddingRooms.Visible = false; // sets btnStartAddingRooms to not be visible
                btnStartUploadingImages.Visible = false;// sets btnStartUploadingImages to not be visible
                HideNewRoomArea(); // calls HideNewRoomArea function
                ResetNewListingArea(); // calls ResetNewListingArea function
            }
        }

        protected void gvRooms_RowDeleting(object sender, GridViewDeleteEventArgs e) // gridview gvRooms_RowDeleting event handler
        {
            int rowIndex = e.RowIndex; // int rowIndex set to the events passed objects RowIndex
            agentHandler.RemoveNewPropertyRoom(rowIndex); // calls RemoveNewPropertyRoom function from the agentHandler object with rowIndex as parameter
            newPropertyRooms = agentHandler.GetNewPropertyRooms(); // sets newPropertyRooms to the returned value from GetNewPropertyRooms function from the agentHandler object
            // sets gvRooms datasource and binds data
            gvRooms.DataSource= newPropertyRooms;
            gvRooms.DataBind();
            ResetRoomInput(); // calls ResetRoomInput function
        }


        private void ResetNewListingArea() // private ResetNewListingArea function
        {
            lblNewListingError.Text = ""; // sets lblNewListingError Text to an empty string
            txtStreetAddress.Text = ""; // sets txtStreetAddress Text to an empty string
            txtCityAddress.Text = ""; // sets txtCityAddress Text to an empty string
            drplStateAddress.SelectedIndex = 0; // sets drplStateAddress selectedindex to 0
            txtZipAddress.Text = ""; // sets txtZipAddress Text to an empty string
            txtYearBuilt.Text = "";// sets txtYearBuilt Text to an empty string
            txtDescription.Text = "";// sets txtDescription Text to an empty string
            txtAskingPrice.Text = "";// sets txtAskingPrice Text to an empty string
            radlPropertyType.SelectedIndex = -1; // sets radlPropertyType selectedindex to -1
            txtNumberGarage.Text = ""; // sets txtNumberGarage Text to an empty string
            drplHeatingType.SelectedIndex = 0;// sets drplHeatingType selectedindex to 0
            drplCoolingType.SelectedIndex = 0;// sets drplCoolingType selectedindex to 0
            drplWaterUtilities.SelectedIndex = 0;// sets drplWaterUtilities selectedindex to 0
            drplSewerUtilities.SelectedIndex = 0;// sets drplSewerUtilities selectedindex to 0

            // resets chklAmnities
            foreach (ListItem option in chklAmenities.Items)
            {
                if (option.Selected == true)
                {
                    option.Selected = false;
                }
            }

            newPropertyAmenities = new List<int>(); // sets newPropertyAmenities to a new list of ints
            agentHandler.ResetNewPropertyRooms(); // calls ResetNewPropertyRooms from agentHandler object
            gvRooms.DataSource = null;
            gvRooms.DataBind();
            agentHandler.ResetNewPropertyImages();// calls ResetNewPropertyImages from agentHandler object
            gvImages.DataSource = null;
            gvImages.DataBind();
        }

        private void btnViewEditListing_Click(int propertyID) // private btnViewEditListing_Click function that accepts a int
        {
            FillPropertyViewEditArea(agentHandler.GetPropertyByPropertyID(propertyID)); // calls FillPropertyViewEditArea function with the returend value GetPropertyByPropertyID funtion from agentHandler object with propertyID as a parameter
            FillPropertyViewEditRooms(agentHandler.GetRoomListByPropertyID(propertyID)); // calls FillPropertyViewEditRooms function with the returend value GetRoomListByPropertyID funtion from agentHandler object with propertyID as a parameter
            FillPropertyViewEditImages(agentHandler.GetPropertyImages(propertyID)); // calls FillPropertyViewEditImages function with the returend value GetPropertyImages funtion from agentHandler object with propertyID as a parameter
            FillPropertyViewEditStatus(agentHandler.GetPropertyStatusByPropertyID(propertyID)); // calls FillPropertyViewEditStatus function with the returend value GetPropertyStatusByPropertyID funtion from agentHandler object with propertyID as a parameter
            DisableEditListingControls(); // calls DisableEditListingControls function
            ShowViewEditListingArea(); // calls ShowViewEditListingArea function
            lstvAgentListing.Visible = false; // sets lstvAgentListing to not be visible
        }

        private void FillPropertyViewEditStatus(PropertyStatus propertyStatus) // private FillPropertyViewEditStatus function that accepts a PropertyStatus object
        {
            drplEditPropertyStatus.SelectedValue = propertyStatus.CurrentStatus; // sets drplEditPropertyStatus selectValue to the propertyStatus objects current status
        }

        private void FillPropertyViewEditArea(Property property) // private FillPropertyViewEditArea function that accepts a Property object
        {
            // assigns all of these controls text from info from the property object
            txtEditCity.Text = property.AddressCity;
            txtEditStreetAddress.Text = property.AddressStreet;
            txtEditZipCode.Text = property.AddressZipCode.ToString();
            txtEditAskingPrice.Text = property.AskingPrice.ToString();
            agentHandler.SetCurrentAskingPrice(property.AskingPrice);
            txtEditDescription.Text = property.PropertyDescription;
            txtEditNumberGarage.Text = property.GarageType.ToString();
            txtEditYearBuilt.Text = property.YearBuilt.ToString();
            radlEditPropertyType.SelectedValue = property.PropertyType;
            drplEditHeating.SelectedValue = property.HeatingSystem;
            drplEditCooling.SelectedValue = property.CoolingSystem;
            drplEditWater.SelectedValue = property.UtilitiesWater;
            drplEditSewer.SelectedValue = property.UtilitiesSewer;
            drplStateAddress.SelectedValue = property.AddressState;
            foreach (PropertyAmenity amentity in agentHandler.GetSinglePropertyAmenities(property.PropertyID))
            {
                foreach (ListItem option in chklstEditAmenities.Items)
                {
                    if (int.Parse(option.Value) == amentity.AmenityID)
                    {
                        option.Selected = true;
                    }
                }
            }
            
        }

        private void FillPropertyViewEditRooms(List<PropertyRoom> propertyRooms) // private FillPropertyViewEditRooms function that accepts a List of PropertyRoom objects
        {
            // sets gvEditPropertyRooms datasource and binds data
            gvEditPropertyRooms.DataSource = propertyRooms; 
            gvEditPropertyRooms.DataBind();
        }

        private void FillPropertyViewEditImages(List<PropertyImage> propertyImages)// private FillPropertyViewEditImages function that accepts a List of PropertyImage objects
        {
            // sets gvEditPropertyImages datasource and binds data
            gvEditPropertyImages.DataSource = propertyImages;
            gvEditPropertyImages.DataBind();
        }

        private void ShowViewEditListingArea() // private ShowViewEditListingArea function
        {
            viewEditListing.Visible = true; // sets viewEditListing to be visible
        }

        private void HideViewEditListingArea() // private HideViewEditListingArea function
        {
            viewEditListing.Visible = false; // sets viewEditListing to not be visible
        }

        private void btnDeleteListing_Click(int propertyID) // private btnDeleteListing_Click function that accepts a int as a parameter
        {
            agentHandler.RemovePropertyOffers(propertyID); // handles offer contingencies, offer statuses, and offers
            agentHandler.RemovePropertyShowings(propertyID); // handles showing requests
            agentHandler.RemoveAgentListing(propertyID); // handles images, rooms, contingencyies, and the proeprty itself
            lstvAgentListing.DataSource = agentHandler.GetAgentPropertyListings();
            lstvAgentListing.DataBind();

        }

        protected void btnViewListings_Click(object sender, EventArgs e) //btnViewListings_Click event handler
        {
            // sets lstvAgentListing datasource and binds data
            lstvAgentListing.DataSource = agentHandler.GetAgentPropertyListings();
            lstvAgentListing.DataBind();
            if (agentListingArea.Visible == false) // if agentListingArea is not visible then
            {
                ShowAgentListingArea(); // calls ShowAgentListingArea function
            }
            else // else agentListingArea is visible 
            {
                HideAgentListingArea(); // calls HideAgentListingArea function
            }
        }

        private void ShowAgentListingArea() // private ShowAgentListingArea function
        {
            agentListingArea.Visible = true; // sets agentListingArea to be visible
        }

        private void HideAgentListingArea() // private HideAgentListingArea function
        {
            agentListingArea.Visible = false; // sets agentListingArea to not be visible
            HideViewEditListingArea(); // calls HideViewEditListingArea function
        }

        protected void lstvAgentListing_ItemCommand(object sender, ListViewCommandEventArgs e) // lstvAgentListing_ItemCommand event handler
        {
            int propertyID = int.Parse(e.CommandArgument.ToString());  // int variable called propertyID set to the converted int value of a controls CommandArgument set to a string  

            switch (e.CommandName) // case switch function based on the events control CommandName
            {
                case "viewEditListing": // if the CommandName is equal to viewEditListing then
                    btnViewEditListing_Click(propertyID); // calls btnViewEditListing_Click function with the propertyId as a parameter
                    agentHandler.SetCurrentPropertyView(propertyID); // calls the SetCurrentPropertyView function from the agentHandler object with propertyID as a parameter
                    break;
                case "DeleteListing": // if the CommandName is equal to DeleteListing then
                    btnDeleteListing_Click(propertyID); // calls btnDeleteListing_Click function with the propertyId as a parameter
                    break;
            }
        }

        protected void EditListing_Click(object sender, EventArgs e) // EditListing_Click event handler
        {
            EnableEditListingControls(); // calls EnableEditListingControls function
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            ResetEditListingError(); // calls ResetEditListingError function
            if (ValidateEditListing() == true) // if ValidateEditListing function returns true then
            {
                DisableEditListingControls(); // calls DisableEditListingControls function
                // gets updated property information
                updatedPropertyInformation = new Dictionary<string, string>();
                updatedPropertyInformation.Add("AgentID", agentHandler.GetCurrentLoggedInAccountID().ToString());
                updatedPropertyInformation.Add("StreetAddress", txtEditStreetAddress.Text);
                updatedPropertyInformation.Add("CityAddress", txtEditCity.Text);
                updatedPropertyInformation.Add("StateAddress", drplEditState.SelectedItem.ToString());
                updatedPropertyInformation.Add("ZipAddress", txtEditZipCode.Text);
                updatedPropertyInformation.Add("YearBuilt", txtEditYearBuilt.Text);
                updatedPropertyInformation.Add("Description", txtEditDescription.Text);
                updatedPropertyInformation.Add("AskingPrice", txtEditAskingPrice.Text);
                updatedPropertyInformation.Add("Type", radlEditPropertyType.SelectedItem.ToString());
                updatedPropertyInformation.Add("Garage", txtEditNumberGarage.Text);
                updatedPropertyInformation.Add("Heating", drplEditHeating.SelectedItem.ToString());
                updatedPropertyInformation.Add("Cooling", drplEditCooling.SelectedItem.ToString());
                updatedPropertyInformation.Add("Water", drplEditWater.SelectedItem.ToString());
                updatedPropertyInformation.Add("Sewer", drplEditSewer.SelectedItem.ToString());
                updatedPropertyAmenitites = new List<int>();
                foreach (ListItem option in chklstEditAmenities.Items)
                {
                    if (option.Selected == true)
                    {
                        updatedPropertyAmenitites.Add(int.Parse(option.Value));
                    }
                }
                updatedPropertyInformation.Add("Bedrooms", agentHandler.GetNumberOfBedrooms(agentHandler.GetRoomListByPropertyID(agentHandler.GetCurrentPropertyView())).ToString()); // gets bedrooms
                updatedPropertyInformation.Add("Bathrooms", agentHandler.GetNumberOfBathrooms(agentHandler.GetRoomListByPropertyID(agentHandler.GetCurrentPropertyView())).ToString()); // gets bathrooms
                if (decimal.Parse(txtEditAskingPrice.Text) != agentHandler.GetCurrentAskingPrice()) // checks if there is a new asking price
                {
                    agentHandler.AddNewPriceHistory(agentHandler.GetCurrentPropertyView(), decimal.Parse(txtEditAskingPrice.Text)); // if there is make a new price history
                }
                agentHandler.UpdateAgentListing(agentHandler.GetCurrentPropertyView(), updatedPropertyInformation); // does main agent liting update
                agentHandler.UpdatePropertyStatus(agentHandler.GetCurrentPropertyView(), drplEditPropertyStatus.SelectedValue.ToString()); // does property status update
                agentHandler.UpdatePropertyAmenities(agentHandler.GetCurrentPropertyView(), updatedPropertyAmenitites); // does propertyAmenitites update
                agentHandler.RemoveSingleRoom(agentHandler.GetRoomsToBeRemoved()); // Removes any rooms the user deleted
                agentHandler.RemovePropertyImages(agentHandler.GetImagesToBeRemoved()); // removes any images the user deleted
                // sets gvEditPropertyImages datasource and binds data
                gvEditPropertyImages.DataSource = agentHandler.GetPropertyImages(agentHandler.GetCurrentPropertyView());
                gvEditPropertyImages.DataBind();
                // sets gvEditPropertyRooms datasource and binds data
                gvEditPropertyRooms.DataSource = agentHandler.GetRoomListByPropertyID(agentHandler.GetCurrentPropertyView());
                gvEditPropertyRooms.DataBind();
                agentHandler.ResetRoomsToBeRemoved(); // calls ResetRoomsToBeRemoved function from agentHandler object
                agentHandler.ResetImagesToBeRemoved(); // calls ResetImagesToBeRemoved function from agentHandler object
            }

        }

        protected void Cancel_Click(object sender, EventArgs e) // Cancel_Click event handler
        {
            DisableEditListingControls(); // calls DisableEditListingControls function
            HideViewEditListingArea(); // calls HideViewEditListingArea function
            lstvAgentListing.Visible = true; // sets lstvAgentListing to not be visible
        }

        private void EnableEditListingControls() // private EnableEditListingControls function
        {
            // enables the edit listing controls
            txtEditCity.Enabled = true;
            txtEditStreetAddress.Enabled = true;
            txtEditZipCode.Enabled = true;
            txtEditAskingPrice.Enabled = true;
            txtEditDescription.Enabled = true;
            txtEditNumberGarage.Enabled = true;
            txtEditYearBuilt.Enabled = true;
            radlEditPropertyType.Enabled = true;
            drplEditHeating.Enabled = true;
            drplEditCooling.Enabled = true;
            drplEditWater.Enabled = true;
            drplEditSewer.Enabled = true;
            drplEditState.Enabled = true;
            chklstEditAmenities.Enabled = true;
            gvEditPropertyRooms.Enabled = true;
            gvEditPropertyImages.Enabled = true;
            txtEditRoomLength.Enabled = true;
            txtEditRoomWidth.Enabled = true;
            btnEditAddNewRoom.Enabled = true;
            btnEditAddImage.Enabled = true;
            drplEditPropertyStatus.Enabled = true;
            radlEditNewRoomType.Enabled = true;
            fluplEditImages.Enabled = true;
            txtEditImageCaption.Enabled = true;
            btnEditAddNewRoom.Enabled = true;
            btnEditAddImage.Enabled = true;
        }

        private void DisableEditListingControls() // private DisableEditListingControls function
        {
            // disables the edit listing controls
            txtEditCity.Enabled = false;
            txtEditStreetAddress.Enabled = false;
            txtEditZipCode.Enabled = false;
            txtEditAskingPrice.Enabled = false;
            txtEditDescription.Enabled = false;
            txtEditNumberGarage.Enabled = false;
            txtEditYearBuilt.Enabled = false;
            radlEditPropertyType.Enabled = false;
            drplEditHeating.Enabled = false;
            drplEditCooling.Enabled = false;
            drplEditWater.Enabled = false;
            drplEditSewer.Enabled = false;
            drplEditState.Enabled = false;
            chklstEditAmenities.Enabled = false;
            gvEditPropertyRooms.Enabled = false;
            gvEditPropertyImages.Enabled = false;
            txtEditRoomLength.Enabled = false;
            txtEditRoomWidth.Enabled = false;
            btnEditAddNewRoom.Enabled = false;
            btnEditAddImage.Enabled = false;
            drplEditPropertyStatus.Enabled = false;
            radlEditNewRoomType.Enabled = false;
            fluplEditImages.Enabled = false;
            txtEditImageCaption.Enabled = false;
            btnEditAddNewRoom.Enabled = false;
            btnEditAddImage.Enabled = false;
        }

        protected void btnAddImage_Click(object sender, EventArgs e) // btnAddImage_Click event handler
        {
            ResetImageErrorMessage(); // calls ResetImageErrorMessage function

            if (ValidateListingImage() == true) // if ValidateListingImage function returns true
            {
                if (fuplImgUpload.HasFile) // if fuplImgUpload fileUpload has a file then
                {
                    string fileExtension = System.IO.Path.GetExtension(fuplImgUpload.FileName); // string fileExtension set to the returned value of GetExtnsion from the Path object with the fuplImgUpload fileupload uploaded filename as a parameter
                    if (fileExtension == ".jpg" || fileExtension == ".png" || fileExtension == ".jpeg" || fileExtension == ".gif") // if the fileExtension is equal to any of these extenstions then
                    {
                        agentHandler.AddNewImage(fuplImgUpload.PostedFile); // calls the AddNewImage function from the agentHandler object with the fuplImgUpload fileupload uploaded file as a parameter
                        agentHandler.AddNewImageCaption(txtImageCaption.Text); // calls the AddNewImageCaption function from the agentHandler object with the txtImageCaption text as a parameter
                    }
                }
                // sets gvImages datasource and binds data
                gvImages.DataSource = agentHandler.GetNewPropertyImageFiles();
                gvImages.DataBind();
                txtImageCaption.Text = ""; // resets txtImageCaptions text
            }

        }

        protected void gvImages_RowDeleting(object sender, GridViewDeleteEventArgs e)// gvImages_RowDeleting event handler
        {
            int rowIndex = e.RowIndex; // int rowIndex set to the events passed objects RowIndex
            agentHandler.RemoveImageCaption(rowIndex); // calls  RemoveImageCaption function from agentHandler object with rowIndex as a parameter
            agentHandler.RemoveNewImage(rowIndex); // calls RemoveNewImage function from agentHandler object with rowIndes as a parameter
            // sets gvImages datasource and binds data
            gvImages.DataSource = agentHandler.GetNewPropertyImageFiles();
            gvImages.DataBind();
        }

        protected void lstvAgentListing_ItemDataBound(object sender, ListViewItemEventArgs e)// lstvAgentListing_ItemDataBound event handler
        {
            ListViewDataItem dataItem = (ListViewDataItem)e.Item; // ListViewDataItem object called dataItem set to the events passed objects Item converted to a ListViewDataItem
            Image listingImage = (Image)e.Item.FindControl("imgListingImage"); // Image object called listingImage set to the returned value of FindControl with imgListingImage as a parameter from the events passed Item object converted to a Image
            Label listingAddressLabel = (Label)e.Item.FindControl("lblListingAddress"); // Label object called listingAddressLabel set to the returned value of FindControl with lblListingAddress as a parameter from the events passed Item object converted to a Label
            Label listingSqFtLabel = (Label)e.Item.FindControl("lblListingSqFt"); // Label object called listingSqFtLabel set to the returned value of FindControl with lblListingSqFt as a parameter from the events passed Item object converted to a Label
            Label listingBedroomLabel = (Label)e.Item.FindControl("lblListingBedrooms"); // Label object called listingBedroomLabel set to the returned value of FindControl with lblListingBedrooms as a parameter from the events passed Item object converted to a Label
            Label listingBathroomLabel = (Label)e.Item.FindControl("lblListingBathrooms"); // Label object called listingBathroomLabel set to the returned value of FindControl with lblListingBathrooms as a parameter from the events passed Item object converted to a Label
            Label listingAskingPriceLabel = (Label)e.Item.FindControl("lblListingAskingPrice"); // Label object called listingAskingPriceLabel set to the returned value of FindControl with lblListingAskingPrice as a parameter from the events passed Item object converted to a Label
            Button btnEditListing = (Button)e.Item.FindControl("btnEditListing");  // Button object called btnEditListing set to the returned value of FindControl with btnEditListing as a parameter from the events passed Item object converted to a Button
            Button btnDeleteListing = (Button)e.Item.FindControl("btnDeleteListing");  // Button object called btnDeleteListing set to the returned value of FindControl with btnDeleteListing as a parameter from the events passed Item object converted to a Button
            Property agentProperty = (Property)dataItem.DataItem; // Property object called agentProperty set to the dataItem objects DataItem converted to a Property object
            // assigns labels text from info from the agentProperty object
            listingImage.ImageUrl = agentHandler.GetOnePropertyImage(agentProperty.PropertyID)[0].ImageURL;
            listingAddressLabel.Text = agentProperty.AddressStreet + ", " + agentProperty.AddressCity + ", " + agentProperty.AddressState + ", " + agentProperty.AddressZipCode;
            listingSqFtLabel.Text = "Total Square Feet:" + agentProperty.PropertySize;
            listingBedroomLabel.Text = "# Of Bedrooms:" + agentProperty.NumberOfBedrooms;
            listingBathroomLabel.Text = "# Of Bathrooms: " + agentProperty.NumberOfBathrooms;
            listingAskingPriceLabel.Text = "Asking Price: " + agentProperty.AskingPrice.ToString("C");

            btnEditListing.CommandArgument = agentProperty.PropertyID.ToString(); // sets the btnEditListing CommandArgument to the agentProperty objects PropertyID converted to a string
            btnDeleteListing.CommandArgument= agentProperty.PropertyID.ToString(); // sets the btnDeleteListing CommandArgument to the agentProperty objects PropertyID converted to a string
        }

        protected void gvEditPropertyImages_RowDeleting(object sender, GridViewDeleteEventArgs e)// gvEditPropertyImages_RowDeleting event handler
        {
            int rowIndex = e.RowIndex; // int rowIndex set to the events passed objects RowIndex
            string imageIdString = gvEditPropertyImages.DataKeys[rowIndex].Value.ToString(); // stirng imageIdString set to the rowIndex datakey value from the gvEditPropertyImages gridview converted to a string
            int imageID = int.Parse(imageIdString); // int imageId set to the converted int value from the imageIdString
            agentHandler.AddImageToBeRemoved(imageID); // calls  AddImageToBeRemoved function from agentHandler object with imageID as a parameter
            gvEditPropertyImages.Rows[rowIndex].BackColor = System.Drawing.Color.Red; // sets the rowIndexs row in the gvEditPropertyImages gridview backcolor to the color of red

        }

        protected void gvEditPropertyRooms_RowDeleting(object sender, GridViewDeleteEventArgs e) // gvEditPropertyRooms_RowDeleting event handler
        {
            int rowIndex = e.RowIndex; // int rowIndex set to the events passed objects RowIndex
            string roomIdString = gvEditPropertyRooms.DataKeys[rowIndex].Value.ToString(); // stirng roomIdString set to the rowIndex datakey value from the gvEditPropertyImages gridview converted to a string
            int roomID = int.Parse(roomIdString); // int roomID set to the converted int value from the imageIdString
            agentHandler.AddRoomToBeRemoved(roomID); // calls  AddRoomToBeRemoved function from agentHandler object with roomID as a parameter
            gvEditPropertyRooms.Rows[rowIndex].BackColor = System.Drawing.Color.Red; // sets the rowIndexs row in the gvEditPropertyRooms gridview backcolor to the color of red

        }

        protected void btnEditAddNewRoom_Click(object sender, EventArgs e) // btnEditAddNewRoom_Click event handler
        {
            ResetEditRoomError(); // calls ResetEditRoomError function
            if (ValidateEditListingRoom() == true) // if ValidateEditListingRoom function returns true 
            {
                string length = txtEditRoomLength.Text; // string length set to txtEditRoomLength's text
                string width = txtEditRoomWidth.Text; // string width set to txtEditRoomWidth's text
                string propertyType = radlEditNewRoomType.SelectedValue.ToString(); // string propertyType set to radlEditNewRoomType selected value converted to a string
                agentHandler.ResetNewPropertyRooms(); // calls ResetNewPropertyRooms function from the agentHandler object
                agentHandler.AddNewPropertyRoom(propertyType, length, width); // calls AddNewPropertyRoom function from the agentHandler object with propertyType, length, and width as parameters
                agentHandler.GetAllNewRoomTotalSqFt(); // calls GetAllNewRoomTotalSqFt function from the agentHandler object
                agentHandler.FinalizeNewRooms(agentHandler.GetCurrentPropertyView()); // calls FinalizeNewRooms function from the agentHandler object with the returned value from GetCurrentPropertyView function from the agentHandler object as a parameter
                // sets gvEditPropertyRooms datasource and binds data
                gvEditPropertyRooms.DataSource = agentHandler.GetRoomListByPropertyID(agentHandler.GetCurrentPropertyView());
                gvEditPropertyRooms.DataBind();
                MarkEditRowsToBeDeletedRoom(); // calls MarkEditRowsToBeDeletedRoom function
            }

        }

        private void MarkEditRowsToBeDeletedRoom() // private MarkEditRowsToBeDeletedRoom function
        {
            foreach (GridViewRow row in gvEditPropertyRooms.Rows) // foreach GridViewRow called row in gvEditPropertyRooms rows do
            {
                foreach (int id in agentHandler.GetRoomsToBeRemoved()) // foreach int called if in the returned value from GetRoomsToBeRemoved function from the agentHandler object do
                {
                    string rowRoomID = gvEditPropertyRooms.DataKeys[row.RowIndex].Value.ToString(); // sets rowRoomID to the current rows DataKey value converted to a string from the gvEditPropertyRooms gridview
                    int roomID = int.Parse(rowRoomID); // int imageId set to the conerted int value of rowRoomID
                    if (roomID == id) // if roomID is equal to the current id then
                    {
                        gvEditPropertyRooms.Rows[row.RowIndex].BackColor = System.Drawing.Color.Red; // sets the current rows backcolor in the gvEditPropertyRooms gridview to be red 
                    }
                }
            }
        }

        protected void btnAddEditImage_Click(object sender, EventArgs e)// button btnAddEditImage_Click event handler
        {
            if (ValidateEditListingImage() == true) // if ValidateEditListingImage function returns true then
            {
                if (fluplEditImages.HasFile) // if fluplEditImages fileUpload has a file then
                {
                    string fileExtension = System.IO.Path.GetExtension(fluplEditImages.FileName); // string fileExtension set to the returned value of GetExtnsion from the Path object with the fluplEditImages fileupload uploaded filename as a parameter
                    if (fileExtension == ".jpg" || fileExtension == ".png" || fileExtension == ".jpeg" || fileExtension == ".gif") // if the fileExtension is equal to any of these extenstions then
                    {
                        agentHandler.ResetNewPropertyImages(); // calls the ResetNewPropertyImages function from the agentHandler object
                        agentHandler.AddNewImage(fluplEditImages.PostedFile); // calls the AddNewImage function from the agentHandler object with the  fluplEditImages fileUpload uploaded file as a parameter
                        agentHandler.AddNewImageCaption(txtEditImageCaption.Text); // calls the AddNewImageCaption function from the agentHandler object with the  txtEditImageCaption textboxs text a parameter
                        agentHandler.AddNewImagesToProperty(agentHandler.GetCurrentPropertyView(), agentHandler.GetPropertyImages(agentHandler.GetCurrentPropertyView()).Count, agentHandler.GetPropertyImages(agentHandler.GetCurrentPropertyView()));
                        // calls the AddNewImagesToProperty function from the agentHandler object with multiple returned functions values from the agentHandler as parameters
                    }

                }
                FillPropertyViewEditImages(agentHandler.GetPropertyImages(agentHandler.GetCurrentPropertyView())); // calls the FillPropertyViewEditImages function with the returned value of the GetPropertyImages function from the agentHandler object with GetCurrentPropertyView function from the agentHandler object as a parameter as a parameter 
                MarkEditRowsToBeDeletedImage(); // calls MarkEditRowsToBeDeletedImage function 
                txtEditImageCaption.Text = ""; // sets txtEditImageCaption text to a empty string
            }
        }

        private void MarkEditRowsToBeDeletedImage() // private MarkEditRowsToBeDeletedImage function
        {
            foreach (GridViewRow row in gvEditPropertyImages.Rows) // foreach GridViewRow called row in gvEditPropertyImages rows do
            {
                foreach (int id in agentHandler.GetImagesToBeRemoved()) // foreach int called if in the returned value from GetImagesToBeRemoved function from the agentHandler object do
                {
                    string rowImageID = gvEditPropertyImages.DataKeys[row.RowIndex].Value.ToString(); // sets rowImageID to the current rows DataKey value converted to a string from the gvEditPropertyImages gridview
                    int imageID = int.Parse(rowImageID); // int imageId set to the conerted int value of rowImageID
                    if (imageID == id) // if imageID is equal to the current id then
                    {
                        gvEditPropertyImages.Rows[row.RowIndex].BackColor = System.Drawing.Color.Red; // sets the current rows backcolor in the gvEditPropertyImages gridview to be red 
                    }
                }
            }
        }

        protected void btnCancelNewListing_Click(object sender, EventArgs e) // button btnCancelNewListing_Click event handler
        {
            newListing.Visible = false; // sets newListing to not be visible
        }

        protected void btnViewShowings_Click(object sender, EventArgs e)// button btnViewShowings click event handler
        {
            if (viewShowingsArea.Visible == false) // if viewShowingsArea is not visible then
            {
                ShowAgentShowingRequests(); // calls ShowAgentShowingRequests function
                lstvAgentShowings.DataSource = agentHandler.GetAgentShowingRequest(agentHandler.GetAgentPropertyListings()); // sets lstvAgentShowings DataSource to the returned value from GetAgentShowingRequest function from agentHandler object with the returned value from GetAgentPropertyListings from the agentHandler object as a parameter
                lstvAgentShowings.DataBind(); // calls the DataBind function of lstvAgentShowings
            }
            else// else viewShowingsArea is visible then
            {
                HideAgentShowingRequests(); // calls HideAgentShowingRequests function
            }
        }

        private void ShowAgentShowingRequests() // private ShowAgentShowingRequests function
        {
            viewShowingsArea.Visible = true; // sets viewShowingsArea to be visible
        }

        private void HideAgentShowingRequests() // private HideAgentShowingRequests function
        {
            viewShowingsArea.Visible = false; // sets viewShowingsArea to not be visible
        }

        protected void btnViewOffers_Click(object sender, EventArgs e) // button btnViewOffers click event handler
        {
            if (viewOffersArea.Visible == false) // if viewOffersAreas is not visible then
            {
                ShowAgentOffers(); // calls ShowAgentOffers function
            }
            else // else viewOffersAreas is visible
            {
                HideAgentOffers(); // calls HideAgentOffers function
            }
        }

        private void ShowAgentOffers() // private ShowAgentOffers function
        {
            List<PropertyOffer> agentPendingOffers = new List<PropertyOffer>(); // List of PropertyOffer objects called agentPendingOffers set to a new List of propertyOffer
            foreach (PropertyOffer offer in agentHandler.GetAgentPropertyOffers(agentHandler.GetAgentPropertyListings())) // foreach propertyOffer object called offer in the returned value of GetAgentPropertyOffers from the agentHandler object with the returned value from GetAgentPropertyListings function from agentHandler as a parameter do
            {
                foreach (PropertyOfferStatus offerStatus in agentHandler.GetAllOfferStatuses()) // foreach PropertyOfferStatus called offerStatus object in the returned value from GetAllOfferStatuses function from the agentHandler object
                {
                    if ((offer.OfferID == offerStatus.OfferID) && (offerStatus.CurrentStatus == "Pending")) // if the current offer objects offerID is equal to the current offerSatus objects offerID and if the current offerStatus objects currentStatus is equal to pending
                    {
                        agentPendingOffers.Add(offer); // adds the current offer obeject to the agentPendingOffers list
                    }
                }
            }
            lstvAgentOffers.DataSource = agentPendingOffers; // sets lstvAgentOffers DataSource to agentPendingOffers
            lstvAgentOffers.DataBind(); // calls DataBind function from lstvAgentOFfers
            viewOffersArea.Visible = true; // sets viewOffersAreas to be visible
        }

        private void HideAgentOffers() // private HideAgentOffers function
        {
            viewOffersArea.Visible = false; // sets viewOffersAreas to not be visible
        }

        protected void lstvAgentOffers_ItemCommand(object sender, ListViewCommandEventArgs e) // ListView lstvAgentOffers ItemCommand event handler
        {
            int offerID = int.Parse(e.CommandArgument.ToString()); // int variable called offerID set to the converted int value of a controls CommandArgument set to a string  

            switch (e.CommandName) // case switch function based on the events control CommandName
            {
                case "acceptOffer": // if the CommandName is equal to acceptOffer then
                    btnAcceptOffer_Click(offerID); // calls the btnAcceptOffer_Click function with offerID as a parameter
                    break;
                case "rejectOffer": // if the CommandName is equal to rejectOffer then
                    btnRejectOffer_Click(offerID); // calls the btnRejectOffer_Click function with offerID as a parameter
                    break;
            }
        }

        private void btnAcceptOffer_Click(int offerID) // private btnAcceptOffer_Click function that accepts a int
        {
            PropertyOffer offer = agentHandler.GetPropertyOfferByOfferID(offerID); // PropertyOffer object called offer set to the returned GetPropertyOfferByOfferID function from the agentHandler object with offerID as a parameter
            Property offerProperty = agentHandler.GetPropertyByPropertyID(offer.PropertyID);  // Property object called offerProperty set to the returned GetPropertyByPropertyID function from the agentHandler object with propertyID from the offer object as a parameter
            Account agent = agentHandler.GetCurrentLoggedInAccount(); // Account object called agent set to the returned GetCurrentLoggedInAccount function from the agentHandler object
            string toAddress = offer.BuyerEmail;  // string toAddress set to the offers buyeremail
            string fromAddress = agent.WorkEmail; // string fromAddress set to the agents work email
            string subject = offer.BuyerFirstName + ", Your Offer Has Been Accepted"; // string subject set to a subject of a email
            string body = "Your offer for the property " + offerProperty.AddressStreet + ", " + offerProperty.AddressCity + ", " + offerProperty.AddressState + ", " + offerProperty.AddressZipCode + " for the amount of " + offer.OfferAmount + 
                            " has been accepted! Congratualtions on your new home! Your expected move in date is " + offer.MoveInDate + "! You will recieve a follow up email soon with the next steps to take! " +
                            "Thank you for your business, " + agent.FirstName + " " + agent.LastName + " - " + agent.WorkName;
            agentHandler.UpdatePropertyOfferStatus(offerID, "Accepted"); // calls the UpdatePropertyOfferStatus function from the agentHandler object with offerId and Accepted as parameters
            agentHandler.UpdatePropertyStatus(agentHandler.GetPropertyOfferByOfferID(offerID).PropertyID, "Pending"); // calls the UpdatePropertyStatus function from the agentHandler object with the PropertyID from the returned value of GetPropertyOfferByOfferID with offerID as a parameter and pending parameters
            agentHandler.SendEmail(toAddress, fromAddress, subject, body); // calls the SendEmail function of the agentHandler object with toAddress, fromAddress, subject, and body
            ShowAgentOffers();
        }

        private void btnRejectOffer_Click(int offerID) // private btnRejectOffer_Click function that accepts a int
        {
            PropertyOffer offer = agentHandler.GetPropertyOfferByOfferID(offerID); // PropertyOffer object called offer set to the returned GetPropertyOfferByOfferID function from the agentHandler object with offerID as a parameter
            Property offerProperty = agentHandler.GetPropertyByPropertyID(offer.PropertyID); // Property object called offerProperty set to the returned GetPropertyByPropertyID function from the agentHandler object with propertyID from the offer object as a parameter
            Account agent = agentHandler.GetCurrentLoggedInAccount(); // Account object called agent set to the returned GetCurrentLoggedInAccount function from the agentHandler object
            string toAddress = offer.BuyerEmail; // string toAddress set to the offers buyeremail
            string fromAddress = agent.WorkEmail; // string fromAddress set to the agents work email
            string subject = offer.BuyerFirstName + ", Your Offer Has Been Rejected"; // string subject set to a subject of a email
            string body = "Your offer for the property " + offerProperty.AddressStreet + ", " + offerProperty.AddressCity + ", " + offerProperty.AddressState + ", " + offerProperty.AddressZipCode + " for the amount of " + offer.OfferAmount +
                            " has been Rejected! You are more than welcome to make a new offer if the property is still avaliable! " +
                            "Thank you for your offer, " + agent.FirstName + " " + agent.LastName + " - " + agent.WorkName;

            agentHandler.UpdatePropertyOfferStatus(offerID, "Rejected"); // calls the UpdatePropertyOfferStatus function from the agentHandler object with offerId and Rejected as parameters
            agentHandler.SendEmail(toAddress, fromAddress, subject, body); // calls the SendEmail function of the agentHandler object with toAddress, fromAddress, subject, and body
            ShowAgentOffers();
        }

        protected void lstvAgentOffers_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            ListViewDataItem dataItem = (ListViewDataItem)e.Item; // ListViewDataItem object called dataItem set to the events passed objects Item converted to a ListViewDataItem
            Label offerAddressLabel = (Label)e.Item.FindControl("lblOfferAddress"); // Label object called offerAddressLabel set to the returned value of FindControl with lblOfferAddress as a parameter from the events passed Item object converted to a Label
            Label offerBuyerNameLabel = (Label)e.Item.FindControl("lblOfferName"); // Label object called offerBuyerNameLabel set to the returned value of FindControl with lblOfferName as a parameter from the events passed Item object converted to a Label
            Label offerEmailLabel = (Label)e.Item.FindControl("lblOfferEmail"); // Label object called offerEmailLabel set to the returned value of FindControl with lblOfferEmail as a parameter from the events passed Item object converted to a Label
            Label offerPhoneLabel = (Label)e.Item.FindControl("lblOfferPhone"); // Label object called offerPhoneLabel set to the returned value of FindControl with lblOfferPhone as a parameter from the events passed Item object converted to a Label
            Label offerTypeLabel = (Label)e.Item.FindControl("lblOfferType"); // Label object called offerTypeLabel set to the returned value of FindControl with lblOfferType as a parameter from the events passed Item object converted to a Label
            Label offerAmountLabel = (Label)e.Item.FindControl("lblOfferAmount"); // Label object called offerAmountLabel set to the returned value of FindControl with lblOfferAmount as a parameter from the events passed Item object converted to a Label
            Label offerSellHouseLabel = (Label)e.Item.FindControl("lblOfferSellHouse"); // Label object called offerSellHouseLabel set to the returned value of FindControl with lblOfferSellHouse as a parameter from the events passed Item object converted to a Label
            Label offerMoveInDateLabel = (Label)e.Item.FindControl("lblOfferMoveInDate"); // Label object called offerMoveInDateLabel set to the returned value of FindControl with lblOfferMoveInDate as a parameter from the events passed Item object converted to a Label
            Label offerContingencyLabel = (Label)e.Item.FindControl("lblOfferContingency"); // Label object called offerContingencyLabel set to the returned value of FindControl with lblOfferContingency as a parameter from the events passed Item object converted to a Label
            Button btnAcceptOffer = (Button)e.Item.FindControl("btnAcceptOffer"); // Button object called btnAcceptOffer set to the returned value of FindControl with btnAcceptOffer as a parameter from the events passed Item object converted to a Button
            Button btnRejectOffer = (Button)e.Item.FindControl("btnRejectOffer"); // Button object called btnRejectOffer set to the returned value of FindControl with btnRejectOffer as a parameter from the events passed Item object converted to a Button
            PropertyOffer propertyOffer = (PropertyOffer)dataItem.DataItem; // PropertyOffer obeject called propertyOffer set to the dataItem objects DataItem converted to a PropertyOffer object
            List<Property> agentPropertyWithOffer = new List<Property>(); // list of Property objects called agentPropertyWithOffer set to a new List of Property objects
            List<OfferContingency> offerContingencies = new List<OfferContingency>(); // list of OfferContingency objects called offerContingencies set to a new List of OfferContingency objects
            // Sets labels text with propertyOffer object information
            offerBuyerNameLabel.Text = "Name: " + propertyOffer.BuyerFirstName + " " + propertyOffer.BuyerLastName;
            offerEmailLabel.Text = "Email: " + propertyOffer.BuyerEmail;
            offerPhoneLabel.Text = "Phone Number: " + propertyOffer.BuyerPhoneNumber;
            offerTypeLabel.Text = "Offer Type: " +propertyOffer.OfferType;
            offerAmountLabel.Text = "Offer Amount: " + propertyOffer.OfferAmount.ToString("C");
            offerSellHouseLabel.Text = "Selling House: " + propertyOffer.SellCurrentHouse;
            offerMoveInDateLabel.Text = "Move In Date: " + propertyOffer.MoveInDate.ToString();

            foreach (Property property in agentHandler.GetAgentPropertyListings()) // foreach Property object called property in the returned value from GetAgentPropertyListings function from agentHandler object do
            {
                if (property.PropertyID == propertyOffer.PropertyID) // if the current property objects propertyID is equal to the propertyShowing objects propertyID then
                {
                    offerAddressLabel.Text += property.AddressStreet + ", " + property.AddressCity + ", " + property.AddressState + ", " + property.AddressZipCode; // sets the showingAddress labels text to display the address of the property
                }
            }


            foreach (OfferContingency contingency in agentHandler.GetOfferContingencies()) // foreach OfferContingency object called contingency in the returned value from GetOfferContingencies function from agentHandler object do
            {
                if (contingency.OfferID == propertyOffer.OfferID) // if the current contingency objects OfferID is equal to the propertyOffer objects OfferID then
                {
                    offerContingencyLabel.Text += "<li>" + contingency.Contingency + "</li>"; // adds the contingecny to the label
                }
            }

            btnAcceptOffer.CommandArgument = propertyOffer.OfferID.ToString(); // sets the btnAcceptOffer CommandArgument to the propertyOffer objects OfferID converted to a string
            btnRejectOffer.CommandArgument= propertyOffer.OfferID.ToString(); // sets the btnRejectOffer CommandArgument to the propertyOffer objects OfferID converted to a string


        }

        protected void lstvAgentShowings_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            ListViewDataItem dataItem = (ListViewDataItem)e.Item; // ListViewDataItem object called dataItem set to the events passed objects Item converted to a ListViewDataItem
            ListView listingAddress = (ListView)e.Item.FindControl("lstvAgentShowingAddress"); // ListView object called listingAddress set to the returned value of FindControl with lstvAgentShowingAddress as a parameter from the events passed Item object converted to a ListView
            Label showingAddressLabel = (Label)e.Item.FindControl("lblShowingAddress"); // Label object called showingAddressLabel set to the returned value of FindControl with lblShowingAddress as a parameter from the events passed Item object converted to a Label
            Label showingNameLabel = (Label)e.Item.FindControl("lblShowingName"); // Label object called showingNameLabel set to the returned value of FindControl with lblShowingName as a parameter from the events passed Item object converted to a Label
            Label showingEmailLabel = (Label)e.Item.FindControl("lblShowingEmail"); // Label object called showingEmailLabel set to the returned value of FindControl with lblShowingEmail as a parameter from the events passed Item object converted to a Label
            Label showingPhoneLabel = (Label)e.Item.FindControl("lblShowingPhone"); // Label object called showingPhoneLabel set to the returned value of FindControl with lblShowingPhone as a parameter from the events passed Item object converted to a Label
            Label showingDateLabel = (Label)e.Item.FindControl("lblShowingDateTime"); // Label object called showingDateLabel set to the returned value of FindControl with lblShowingDateTime as a parameter from the events passed Item object converted to a Label
            PropertyShowingRequest propertyShowing = (PropertyShowingRequest)dataItem.DataItem; // PropertyShowingRequest obeject called propertyShowing set to the dataItem objects DataItem converted to a PropertyShowingRequest object
            List<Property> agentPropertyWithOffer = new List<Property>(); // list of Property objects called agentPropertyWithOffer set to a new List of Property objects

            foreach (Property property in agentHandler.GetAgentPropertyListings()) // foreach Property object called property in the returned value from GetAgentPropertyListings function from agentHandler object do
            {
                if (property.PropertyID == propertyShowing.PropertyID) // if the current property objects propertyID is equal to the propertyShowing objects propertyID then
                {
                    showingAddressLabel.Text += property.AddressStreet + ", " + property.AddressCity + ", " + property.AddressState + ", " + property.AddressZipCode; // sets the showingAddress labels text to display the address of the property
                }
            }
            // sets display labels with information from the propertyShowing object
            showingNameLabel.Text = "Name: " + propertyShowing.BuyerFirstName + " " + propertyShowing.BuyerLastName; 
            showingEmailLabel.Text = "Email: " + propertyShowing.BuyerEmail;
            showingPhoneLabel.Text = "Phone Number: " + propertyShowing.BuyerPhoneNumber;
            showingDateLabel.Text = "Move In Date: " + propertyShowing.PreferredDayTime.ToString();
        }

        protected void btnStartAddingNewRooms_Click(object sender, EventArgs e) // Button btnStartAddingNewRooms click event handler
        {
            if (editRoomsArea.Visible == true)  // if editRoomsArea is visible then
            {
                editRoomsArea.Visible = false; // sets editRoomsArea to not be visible
            }
            else // else editRoomsArea is not visible
            {
                editRoomsArea.Visible= true; // sets editRoomsArea to be visible
            }
        }

        protected void btnStartAddingNewImages_Click(object sender, EventArgs e) // Button btnStartAddingNewImages event handler
        {
            if (editImagesArea.Visible == true) // if editImagesAreas is visible then
            {
                editImagesArea.Visible = false; // sets editImagesArea to not be visible
            }
            else // else editImagesArea is not visible
            {
                editImagesArea.Visible= true; // sets editImagesArea to be visible
            }
        }

        private void ResetErrorMessage() // private ResetErrorMessage function
        {
            lblNewListingError.Text = ""; // sets lblNewListingErrors text to an empty string
            lblNewListingConfirmation.Text = ""; // sets lblNewListingConfirmation text to an empty string
        }

        private bool ValidateNewListing() // private ValidateNewListing function that returns a bool
        {
            bool isListingValid = true; // bool isListingValid set to true

            if (validater.ValidateString(txtStreetAddress.Text) == false) // if the returned value from ValidateString function from the validater object with txtStreetAddress text as a parameter is equal to false then
            {
                isListingValid = false; // sets isListingValid to false
                lblNewListingError.Text += "Error - Property Street Address Is Missing - Please enter a property street address! <br />"; // adds error message to lblNewListingError labels text
            }

            if (validater.ValidateString(txtCityAddress.Text) == false) // if the returned value from ValidateString function from the validater object with txtCityAddress text as a parameter is equal to false then
            {
                isListingValid = false; // sets isListingValid to false
                lblNewListingError.Text += "Error - Property City Is Missing - Please enter a property city! <br />"; // adds error message to lblNewListingError labels text
            }

            if (validater.ValidateInt(txtZipAddress.Text) == false) // if the returned value from ValidateInt function from the validater object with txtZipAddress text as a parameter is equal to false then
            {
                isListingValid = false; // sets isListingValid to false
                lblNewListingError.Text += "Error - Property Zip Code Is Invalid Or Missing - Please enter a proper number for the zip code!<br/>"; // adds error message to lblNewListingError labels text
            }

            if (validater.ValidateInt(txtYearBuilt.Text) == false) // if the returned value from ValidateInt function from the validater object with txtYearBuilt text as a parameter is equal to false then
            {
                isListingValid = false; // sets isListingValid to false
                lblNewListingError.Text += "Error - Property Year Built Is Invalid Or Missing - Please enter a proper number for the year built!<br/>";// adds error message to lblNewListingError labels text
            }

            if (validater.ValidateDecimal(txtAskingPrice.Text) == false)// if the returned value from ValidateDecimal function from the validater object with txtAskingPrice text as a parameter is equal to false then
            {
                isListingValid = false; // sets isListingValid to false
                lblNewListingError.Text += "Error - Property Asking Price Is Invalid Or Misisng - Please enter a proper amount for the asking price! <br/>"; // adds error message to lblNewListingError labels text
            }
            
            if (validater.ValidateString(txtDescription.Text) == false) // if the returned value from ValidateString function from the validater object with txtDescription text as a parameter is equal to false then
            {
                isListingValid = false; // sets isListingValid to false
                lblNewListingError.Text += "Error - Propery Description Is Missing - Please enter a property description!<br/>"; // adds error message to lblNewListingError labels text
            }

            bool selectedPropertyType = false; // bool selectedPropertyType set to false
            // loops radlPropertyType items to see if anything is selected
            foreach (ListItem option in radlPropertyType.Items)
            {
                if (option.Selected == true)
                {
                    selectedPropertyType = true;
                }
            }

            if (selectedPropertyType == false) // if selectedPropertyType is equal to false then
            {
                isListingValid = false; // sets isListingValid to false
                lblNewListingError.Text += "Error - Property Type Is Missing - Please select a property type<br/>"; // adds error message to lblNewListingError labels text
            }

            if (validater.ValidateNumber(txtNumberGarage.Text) == false) // if the returned value from ValidateString function from the validater object with txtStreetAddress text as a parameter is equal to false then
            {
                isListingValid = false; // sets isListingValid to false
                lblNewListingError.Text += "Error - Property Numger Of Garage Is Missing - Please enter a proper number or zero for number of garage!<br/>"; // adds error message to lblNewListingError labels text
            }

            bool selectedAmenity = false; // bool selectedAmenity set to false
            // loops chklAmenities items to see if anything is selected
            foreach (ListItem option in chklAmenities.Items)
            {
                if (option.Selected == true)
                {
                    selectedAmenity = true;
                }
            }

            if (selectedAmenity == false) // if selectedAmenity is equal to false then
            {
                isListingValid = false; // sets isListingValid to false
                lblNewListingError.Text += "Error - Property Amenities Is Missing - Please select at least one property amenity!<br/>"; // adds error message to lblNewListingError labels text
            }

            if (gvRooms.Rows.Count == 0) // if gvRooms rows count is equal to zero
            {
                isListingValid = false; // sets isListingValid to false 
                lblNewListingError.Text += "Error - Property Is Missing Rooms - Please add at least one room to the property! <br/>"; // adds error message to lblNewListingError labels text
            }

            if (gvImages.Rows.Count == 0) // if gvImages rows count is equal to zero
            {
                isListingValid = false; // sets isListingValid to false
                lblNewListingError.Text += "Error - Property Is Missing Images - Please add at least one image to the property! <br/>"; // adds error message to lblNewListingError labels text
            }
            return isListingValid; // returns isListingValid
        }

        private bool ValidateListingRoom() // private ValidateListingRoom function that returns a bool
        {
            bool isRoomValid = true; // bool isRoomValid set to true

            if (validater.ValidateDecimal(txtRoomLength.Text) == false) // if the returned value from ValidateDecimal function from the validater object with txtRoomLength text as a parameter is equal to false then
            { 
                isRoomValid = false; // sets isRoomValid to false
                lblRoomError.Text += "Error - Room Length Is Invalid Or Missing - Please enter a whole number for the room lengh! <br/>"; // adds error message to lblRoomError text
            }

            if (validater.ValidateDecimal(txtRoomWidth.Text) == false) // if the returned value from ValidateDecimal function from the validater object with txtRoomWidth text as a parameter is equal to false then
            {
                isRoomValid = false; // sets isRoomValid to false
                lblRoomError.Text += "Error - Room Width Is Invalid Or Missing - Please enter a whole number for the room width! <br/>"; // adds error message to lblRoomError text
            }

            bool roomTypeSelected = false; // bool roomTypeSelected set to false
            //loops radlroomType to see if an option is selected
            foreach (ListItem option in radlRoomType.Items)
            {
                if (option.Selected == true)
                {
                    roomTypeSelected = true;
                }
            }

            if (roomTypeSelected == false) // if roomTypeSelected is false then
            {
                isRoomValid = false; // sets isRoomValid to false 
                lblRoomError.Text += "Error - Room Type Is Missing - Please select a room type! <br/>"; // adds error message to lblRoomError text
            }
            return isRoomValid; // returns isRoomValid
        }

        private bool ValidateListingImage() // private ValidateListingImage function that returns a bool
        { 
            bool isImageValid = true; // bool isImageValid set to true

            if (!fuplImgUpload.HasFile) // if fuplImgUpload fileUpload does not have a file then
            {
                isImageValid = false; // sets isImageValid to false
                lblImageError.Text += "Error - No Uploaded Image - Please select a image to be uploaded! <br/>"; // adds error message to lblImageError text
            }

            if (validater.ValidateString(txtImageCaption.Text) == false) // if the returned value from ValidateString function from the validater object with txtImageCaption text as a parameter is equal to false then
            {
                isImageValid = false; // sets isImageValid to false
                lblImageError.Text += "Error - Image Caption Is Missing - Pleaes enter a image caption!  <br/>"; // adds error message to lblImageError text
            }

            return isImageValid; // returns isImageValid
        }

        private void ResetRoomErrorMessage() // private ResetRoomErrorMessage function
        {
            lblRoomError.Text = ""; // sets lblRoomError text to an empty string
        }

        private void ResetImageErrorMessage() // private ResetImageErrorMessage function
        {
            lblImageError.Text = ""; // sets lblImageError text to an empty string
        }

        private bool ValidateEditListing() // private ValidateEditListing function that returns a bool
        {
            bool isEditValid = true; // bool isEditValid set to true

            if (validater.ValidateString(txtEditStreetAddress.Text) == false) // if the returned value from ValidateString function from the validater object with txtEditStreetAddress text as a parameter is equal to false then
            {
                isEditValid = false; // sets isEditValid to false
                lblEditListingError.Text += "Error - Property Street Address Is Missing - Please enter a property street address! <br />"; // adds error message to lblEditListingError labels text
            }

            if (validater.ValidateString(txtEditCity.Text) == false) // if the returned value from ValidateString function from the validater object with txtEditCity text as a parameter is equal to false then
            {
                isEditValid = false; // sets isEditValid to false
                lblEditListingError.Text += "Error - Property City Is Missing - Please enter a property city! <br />"; // adds error message to lblEditListingError labels text
            }

            if (validater.ValidateInt(txtEditZipCode.Text) == false) // if the returned value from ValidateInt function from the validater object with txtEditZipCode text as a parameter is equal to false then
            {
                isEditValid = false; // sets isEditValid to false
                lblEditListingError.Text += "Error - Property Zip Code Is Invalid Or Missing - Please enter a proper number for the zip code!<br/>"; // adds error message to lblEditListingError labels text
            }

            if (validater.ValidateInt(txtEditYearBuilt.Text) == false) // if the returned value from ValidateInt function from the validater object with txtEditYearBuilt text as a parameter is equal to false then
            {
                isEditValid = false; // sets isEditValid to false
                lblEditListingError.Text += "Error - Property Year Built Is Invalid Or Missing - Please enter a proper number for the year built!<br/>"; // adds error message to lblEditListingError labels text
            }

            if (validater.ValidateDecimal(txtEditAskingPrice.Text) == false) // if the returned value from ValidateDecimal function from the validater object with txtEditAskingPrice text as a parameter is equal to false then
            {
                isEditValid = false; // sets isEditValid to false
                lblEditListingError.Text += "Error - Property Asking Price Is Invalid Or Misisng - Please enter a proper amount for the asking price! <br/>"; // adds error message to lblEditListingError labels text
            }

            if (validater.ValidateString(txtEditDescription.Text) == false) // if the returned value from ValidateString function from the validater object with txtEditDescription text as a parameter is equal to false then
            { 
                isEditValid = false; // sets isEditValid to false
                lblEditListingError.Text += "Error - Propery Description Is Missing - Please enter a property description!<br/>"; // adds error message to lblEditListingError labels text
            }

            bool selectedPropertyType = false; // bool selectedPropertyType set to false
            // loops through radlEditPropertyType items to make sure something is selected
            foreach (ListItem option in radlEditPropertyType.Items)
            {
                if (option.Selected == true)
                {
                    selectedPropertyType = true;
                }
            }

            if (selectedPropertyType == false) // if selectedPropertyType is false then
            {
                isEditValid = false; // sets isEditValid to false
                lblEditListingError.Text += "Error - Property Type Is Missing - Please select a property type<br/>";// adds error message to lblEditListingError labels text
            }

            if (validater.ValidateNumber(txtEditNumberGarage.Text) == false) // if the returned value from ValidateString function from the validater object with txtEditStreetAddress text as a parameter is equal to false then
            {
                isEditValid = false; // sets isEditValid to false
                lblEditListingError.Text += "Error - Property Numger Of Garage Is Missing - Please enter a proper number or zero for number of garage!<br/>"; // adds error message to lblEditListingError labels text
            }

            bool selectedAmenity = false; // bool selectedAmenity
            // loops chklstEditAmenities itesm to see if an option is selected 
            foreach (ListItem option in chklstEditAmenities.Items)
            {
                if (option.Selected == true)
                {
                    selectedAmenity = true;
                }
            }

            if (selectedAmenity == false) // if selectedAmenity is false then
            {
                isEditValid = false; // sets isEditValid to false
                lblEditListingError.Text += "Error - Property Amenities Is Missing - Please select at least one property amenity!<br/>"; // adds error message to lblEditListingError labels text
            }

            if (gvEditPropertyRooms.Rows.Count == 0) // if gvEditPropertyRooms rows count is equal to zero
            {
                isEditValid = false; // sets isEditValid to false
                lblEditListingError.Text += "Error - Property Is Missing Rooms - Please add at least one room to the property! <br/>"; // adds error message to lblEditListingError labels text
            }

            if (gvEditPropertyImages.Rows.Count == 0) // if gvEditPropertyImages rows count is equal to zero
            {
                isEditValid = false; // sets isEditValid to false 
                lblEditListingError.Text += "Error - Property Is Missing Images - Please add at least one image to the property! <br/>"; // adds error message to lblEditListingError labels text
            }
            return isEditValid; // returns isEditValid
        }

        private void ResetEditListingError() // private ResetEditListingError function
        {
            lblEditListingError.Text = ""; // sets lblEditListingError labels text to an empty string
        }

        private bool ValidateEditListingRoom() // private ValidateEditListingRoom function that returns a bool
        {
            bool isRoomValid = true; // bool isRoomValid set to true

            if (validater.ValidateDecimal(txtEditRoomLength.Text) == false) // if the returned value from ValidateString function from the validater object with txtEditRoomLength text as a parameter is equal to false then
            {
                isRoomValid = false; // sets isRoomValid to false
                lblEditRoomError.Text += "Error - Room Length Is Invalid Or Missing - Please enter a valid number for the room lengh! <br/>"; // adds error message to lblEditRoomError labels text
            }

            if (validater.ValidateDecimal(txtEditRoomWidth.Text) == false) // if the returned value from ValidateString function from the validater object with txtEditRoomWidth text as a parameter is equal to false then
            {
                isRoomValid = false; // sets isRoomValid to false
                lblEditRoomError.Text += "Error - Room Width Is Invalid Or Missing - Please enter a valid number for the room width! <br/>"; // adds error message to lblEditRoomError labels text
            }

            bool roomTypeSelected = false; // bool roomTypeSelected set to false
            // loops all the radleditNewRoom options to see if one is selected
            foreach (ListItem option in radlEditNewRoomType.Items)
            {
                if (option.Selected == true)
                {
                    roomTypeSelected = true;
                }
            }
             
            if (roomTypeSelected == false) // if roomTypeSelected is false then
            {
                isRoomValid = false; // sets isRoomValid to false
                lblEditRoomError.Text += "Error - Room Type Is Missing - Please select a room type! <br/>"; // adds error message to lblEditRoomError labels text
            }
            return isRoomValid; // returns isRoomValid
        }

        private bool ValidateEditListingImage() // private ValidateEditListing function that returns a bool
        {
            bool isImageValid = true; // bool isImageValid set to true

            if (!fluplEditImages.HasFile) // if fluplEditImages fileUpload does not have a file then
            {
                isImageValid = false; // sets isImageValid to false
                lblEditImageError.Text += "Error - No Uploaded Image - Please select a image to be uploaded! <br/>"; // adds error message to lblEditImageError labels text
            }

            if (validater.ValidateString(txtEditImageCaption.Text) == false) // if the returned value from ValidateString function from the validater object with txtEditImageCaptions text as a parameter is equal to false then
            {
                isImageValid = false; // sets isImageValid to false
                lblEditImageError.Text += "Error - Image Caption Is Missing - Pleaes enter a image caption!  <br/>"; // adds error message to lblEditImageError labels text
            }

            return isImageValid; // returns isImageValid
        }

        private void ResetEditImageError() // private ResetEditImageError function
        {
            lblEditImageError.Text = ""; // sets lblEditImageError text to an empty string
        }

        private void ResetEditRoomError() // private ResetEditRoomError function
        {
            lblEditRoomError.Text = ""; // sets lblEditRoomError text to an empty string
        }

        protected void btnLogout_Click(object sender, EventArgs e) // button btnLogout click event handler
        {
            Server.Transfer("frmDashboard.aspx"); // calls the Transfer function from the server object with frmDashboard.aspx
        }
    }
}