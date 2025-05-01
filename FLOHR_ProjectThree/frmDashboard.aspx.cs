using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization;
using RealEstateLibrary;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.HtmlControls;
using static System.Net.Mime.MediaTypeNames;
using System.Data.Common;

namespace FLOHR_ProjectThree
{
    public partial class frmAgentDashboard : System.Web.UI.Page
    {
        private MainDashboardController dashboardHandler; // private MainDashboardController object called dashboardHandler
        private Validate validater = new Validate(); // private Validate object called validater set to a new Validate object
        private Dictionary<string, string> filterInputs = new Dictionary<string, string>(); // private string dictionary called filterInputs set to a new string dictionary
        private List<int> selectedAmenities = new List<int>(); // private list of ints valled selectedAmenites set to a new list of ints
        protected void Page_Load(object sender, EventArgs e) // Page load event handler
        {
            if (Session["DashboardHandler"] == null) // if the Session key DashboardHandler is null then
            {
                dashboardHandler = new MainDashboardController(); // sets dashboardHandler to a new MainDashboardController object
                Session["DashboardHandler"] = dashboardHandler; // sets the Session key DashboardHanlder to have the dashboardHandler object
            }
            else // else the session key was not null
            {
                dashboardHandler = (MainDashboardController)Session["DashboardHandler"]; // sets dashboardHandler to the Session key DashboardHandlers value converted to a MainDashboardController object
            }

            if (!IsPostBack) // if the current request is not a postback then
            {
                BindInputs(); // calls the BindInputs function
            }
        }

        private void BindInputs() // private BindInputs function
        {
            chklFilterAmenities.DataSource = dashboardHandler.GetAllAmenities(); // sets chklFilterAmenities checkboxlists datasoure to the returned value from GetAllAmenities function from the dashboardHandler object
            chklFilterAmenities.DataTextField = "AmenityName"; // sets chklFilterAmenities checkboxlists DataTextField to AmenityName
            chklFilterAmenities.DataValueField = "AmenityID"; // sets chklFilterAmenities checkboxlists DataValueField to AmenityID
            chklFilterAmenities.DataBind(); // calls the DataBind function from the chkFilterAmenities checkboxlist 

            radlFilterPropertyType.DataSource = dashboardHandler.GetAllPropertyTypes(); // sets radlFilterPropertyType RadioButtonList datasoure to the returned value from GetAllPropertyTypes function from the dashboardHandler object
            radlFilterPropertyType.DataTextField = "TypeName"; // sets chklFilterAmenities checkboxlists DataTextField to TypeName
            radlFilterPropertyType.DataValueField = "TypeName"; // sets chklFilterAmenities checkboxlists DataValueField to TypeName
            radlFilterPropertyType.DataBind(); // calls the DataBind function from the chkFilterAmenities checkboxlist 


            lstvDashboardListing.DataSource = dashboardHandler.GetAllActiveProperties(dashboardHandler.GetAllActivePropertySatuses()); // sets lstvDashboardListing ListViews datasource to the returned value of GetAllActiveProperties function from the dashboardHandler object with the returned value of GetAllActivePropertyStatuses function from the dashboardHandler object as a parameter
            lstvDashboardListing.DataBind(); // calls the DataBind function from the lstvDashboardListing listview 
        }

        protected void lstvDashboardListing_ItemCommand(object sender, ListViewCommandEventArgs e) //Listview lstvDashboardListing ItemCommand event handler
        {
            int propertyID = int.Parse(e.CommandArgument.ToString()); // int variable called propertyID set to the converted int value of a controls CommandArgument set to a string  

            switch (e.CommandName) // case switch function based on the events control CommandName
            {
                case "viewListing": // if the CommandName is equal to viewListing then
                    btnViewListing_Click(propertyID); // calls the btnViewListing_Click function with the propertyID as a parameter
                    break;
                case "requestShowing":  // if the CommandName is equal to requestShowing then
                    btnRequestShowing_Click(propertyID); // calls the btnRequestShowing_Click function with the propertyID as a parameter
                    break;
                case "makeOffer": // if the CommandName is equal to makeOffer then
                    btnMakeOffer_Click(propertyID); // calls the btnMakeOffer_Click function with the propertyID as a parameter
                    break;
            }
        }

        private void btnViewListing_Click(int propertyID) // private btnViewListing_Click function that accepts a int parameter
        {
            HideAllListings(); // calls HideAllListings function
            lstvSingleListing.DataSource = dashboardHandler.GetSingleProperty(propertyID); // sets lstvSingleListing listviews datasource to the returned value of GetSingleProperty function from the dashboardHandler with the propertyID as a parameter
            lstvSingleListing.DataBind(); // calls the DataBind function of the lstvSingleListing ListView
            ShowSingleListing(); // calls the ShowSingleListing function
        }

        private void btnRequestShowing_Click(int propertyID) // private btnRequestShowing_Click function that accepts a int parameter
        {
            dashboardHandler.SetShowingPropertyID(propertyID); // calls the SetShowingPropertyID function of the dashboardHandler object with propertyID as a parameter
            HideAllListings();  // calls HideAllListings function
            HideSingleListing(); // calls HideSingleListing function
            ShowRequestShowing(); // calls ShowRequestShowing function

        }

        private void ShowRequestShowing() // private ShowRequestShowing function
        {
            requestShowingArea.Visible = true; // sets requestShowingArea to be visible
        }

        private void HideRequestShowing() // private HideRequestShowing function
        {
            requestShowingArea.Visible = false; // sets requestShowingArea to not be visible
        }
        private void btnMakeOffer_Click(int propertyID) // private btnMakeOffer_Click function that accepts a int
        {
            dashboardHandler.SetShowingPropertyID(propertyID); // calls the SetShowingPropertyID function from the dashboardHanler object with propertyID parameter
            HideAllListings(); // calls HideAllListings function
            HideSingleListing(); // calls HideSingleListing function
            HideRequestShowing(); // calls HideRequestShowing function
            ShowOfferArea(); // calls ShowOfferArea function
        }

        protected void lstvDashboardListing_ItemDataBound(object sender, ListViewItemEventArgs e) // ListView lstvDashboardListing ItemDataBound event handler
        {
            ListViewDataItem dataItem = (ListViewDataItem)e.Item; // ListViewDataItem object called dataItem set to the events passed objects Item converted to a ListViewDataItem
            System.Web.UI.WebControls.Image listingImage = (System.Web.UI.WebControls.Image)e.Item.FindControl("lblListingImage"); // Image object called listingImage set to the returned value of FindControl with lblListingImage as a parameter from the events passed Item object converted to a Image
            Label listingAddressLabel = (Label)e.Item.FindControl("lblListingAddress"); // Label object called listingAddressLabel set to the returned value of FindControl with lblListingAddress as a parameter from the events passed Item object converted to a Label
            Label listingTypeLabel = (Label)e.Item.FindControl("lblListingPropertyType"); // Label object called listingTypeLabel set to the returned value of FindControl with lblListingPropertyType as a parameter from the events passed Item object converted to a Label
            Label listingSqFtLabel = (Label)e.Item.FindControl("lblListingSqFt"); // Label object called listingSqFtLabel set to the returned value of FindControl with lblListingSqFt as a parameter from the events passed Item object converted to a Label
            Label listingBedroomsLabel = (Label)e.Item.FindControl("lblListingBedrooms"); // Label object called listingBedroomsLabel set to the returned value of FindControl with lblListingBedrooms as a parameter from the events passed Item object converted to a Label
            Label listingBathroomsLabel = (Label)e.Item.FindControl("lblListingBathrooms"); // Label object called listingBathroomsLabel set to the returned value of FindControl with lblListingBathrooms as a parameter from the events passed Item object converted to a Label
            Label listingAskingPriceLabel = (Label)e.Item.FindControl("lblListingAskingPrice"); // Label object called listingAskingPriceLabel set to the returned value of FindControl with lblListingAskingPrice as a parameter from the events passed Item object converted to a Label
            Label listingDaysListedLabel = (Label)e.Item.FindControl("lblListingDaysOnMarket"); // Label object called listingDaysListedLabel set to the returned value of FindControl with lblListingDaysOnMarket as a parameter from the events passed Item object converted to a Label
            Button btnViewListing = (Button)e.Item.FindControl("btnViewListing"); // Button object called btnViewListing set to the returned value of FindControl with btnViewListing as a parameter from the events passed Item object converted to a Button
            Button btnRequestShowing = (Button)e.Item.FindControl("btnRequestShowing"); // Button object called btnRequestShowing set to the returned value of FindControl with btnRequestShowing as a parameter from the events passed Item object converted to a Button
            Button btnMakeOffer = (Button)e.Item.FindControl("btnMakeOffer"); // Button object called btnMakeOffer set to the returned value of FindControl with btnMakeOffer as a parameter from the events passed Item object converted to a Button
            Property property = (Property)dataItem.DataItem; // Property object called property set to the dataItem objects DataItem converted to a Property object

            listingImage.ImageUrl = dashboardHandler.GetAllPropertyImages(property.PropertyID)[0].ImageURL; // sets the listingImage objects ImageUrl to the first items ImageURL in the returned value from the GetAllPropertyImages function from the dashboardHandler object with the property objects PropertyID as a paramater 
            listingAddressLabel.Text = property.AddressStreet + ", " + property.AddressCity + ", " + property.AddressState + ", " + property.AddressZipCode; // sets the listingAddressLabels objects Text to the property objects AddressStreet plus the property objects AddressState plus the property objects AddressZipCode
            listingTypeLabel.Text = property.PropertyType; // sets listingTypeLabel objects text to the property objects PropertyType
            listingSqFtLabel.Text = "Total Square Footage: " + property.PropertySize.ToString(); // sets listingSqFtLabel objects text to Total sq ft and the property objects PropertySize converted to a string
            listingBedroomsLabel.Text = "Bedrooms: " + property.NumberOfBedrooms.ToString(); // sets listingBedroomsLabel objects text bedrooms and the property objects NumberOfBedrooms converted to a string
            listingBathroomsLabel.Text = "Bathrooms: " + property.NumberOfBathrooms.ToString(); // sets listingBathroomsLabel objects text to bathrooms and the property objects NumberOfBathrooms converted to a string
            listingAskingPriceLabel.Text = "Asking Price: " + property.AskingPrice.ToString("C"); // sets listingAskingPriceLabel objects text to Total sq ft and the property objects AskingPrice converted to a string and formated as a currency 
            DateTime today = DateTime.Now.Date; // DateTime object called today set to the current Date
            listingDaysListedLabel.Text = (today - property.CreationDate.Date).Days.ToString() + " days listed"; // sets listingDaysListedLabel objects text to the number of days from today object - the property objects CreationDates date converted to a string

            btnViewListing.CommandArgument = property.PropertyID.ToString(); // sets the btnViewListing CommandArgument to the property objects PropertyID converted to a string
            btnRequestShowing.CommandArgument = property.PropertyID.ToString(); // sets the btnRequestShowing CommandArgument to the property objects PropertyID converted to a string
            btnMakeOffer.CommandArgument = property.PropertyID.ToString(); // sets the btnMakeOffer CommandArgument to the property objects PropertyID converted to a string

        }

        protected void btnAgentDashboard_Click(object sender, EventArgs e) // Button btnAgentDashboard_Click event handler
        {
            Server.Transfer("frmLogin.aspx"); // calls the Transfer function with frmLogin.aspx as a parameter from the Server object
        }

        protected void lstvSingleListing_ItemCommand(object sender, ListViewCommandEventArgs e) // Listview lstvSingleListing ItemCommand event handler
        {
            int propertyID = int.Parse(e.CommandArgument.ToString()); // int variable called propertyID set to the converted int value of a controls CommandArgument set to a string  
            switch (e.CommandName) // case switch function based on the events control CommandName
            {
                case "requestShowing": // if the CommandName is equal to requestShowing then
                    btnRequestShowing_Click(propertyID); // calls the btnRequestShowing_Click function with the propertyID as a parameter
                    break;
                case "makeOffer": // if the CommandName is equal to makeOffer then
                    btnMakeOffer_Click(propertyID); // calls the btnMakeOffer_Click function with the propertyID as a parameter
                    break;
                case "return": // if the CommandName is equal to return then
                    ShowAllListings(); // calls ShowAllListings function
                    HideSingleListing(); // calls HideSingleListing function
                    break;
                case "previousImage": // if the CommandName is equal to previousImage then
                    btnPreviousImage_Click(); // calls btnPreviousImage_Click function
                    break;
                case "nextImage": // if the CommandName is equal to nextImage then
                    btnNextImage_Click(); // calls btnNextImage_Click function
                    break;
            }
        }

        private void btnPreviousImage_Click() // private btnPreviousImage_Click function
        {
            dashboardHandler.PreviousSingleListingImage(); // calls the PreviousSingleListingImage function from the dashboardHandler object
            ListViewDataItem dataItem = (ListViewDataItem)lstvSingleListing.Items[0]; // ListViewDataItem called dataItem set to the lstvSingeListing listviews first item converted to a ListViewDataItem
            System.Web.UI.WebControls.Image listingImage = (System.Web.UI.WebControls.Image)dataItem.FindControl("imgListingCurrentImage"); // Image object called listingImage set to the returned value of FindControl with imgListingCurrentImage as a parameter from the dataItem object
            listingImage.ImageUrl = dashboardHandler.GetSingleListingImageURL(); // sets the listingImage objects ImageUrl to the returned value from GetSingleListingImageURL function from the dashboardHandler object
        }

        private void btnNextImage_Click() // private btnNextImage_Click function
        {
            dashboardHandler.NextSingleListingImage(); // calls the NextSingleListingImage function from the dashboardHandler object
            ListViewDataItem dataItem = (ListViewDataItem)lstvSingleListing.Items[0]; // ListViewDataItem called dataItem set to the lstvSingeListing listviews first item converted to a ListViewDataItem
            System.Web.UI.WebControls.Image listingImage = (System.Web.UI.WebControls.Image)dataItem.FindControl("imgListingCurrentImage"); // Image object called listingImage set to the returned value of FindControl with imgListingCurrentImage as a parameter from the dataItem object
            listingImage.ImageUrl = dashboardHandler.GetSingleListingImageURL(); // sets the listingImage objects ImageUrl to the returned value from GetSingleListingImageURL function from the dashboardHandler object
        }

        protected void lstvSingleListing_ItemDataBound(object sender, ListViewItemEventArgs e) // ListView lstvSingleListing ItemDataBound event handler
        {
            ListViewDataItem dataItem = (ListViewDataItem)e.Item; // ListViewDataItem object called dataItem set to the events passed objects Item converted to a ListViewDataItem
            // its firday 11/8 and today I get the error that Image is not qualified name, literally worked fine as just Image for 3 weeks... another reason to hate ASP.NET
            System.Web.UI.WebControls.Image listingImage = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgListingCurrentImage"); // Image object called listingImage set to the returned value of FindControl with imgListingCurrentImage as a parameter from the events passed Item object converted to a Image
            GridView listingRooms = (GridView)e.Item.FindControl("gvSingleListingRooms"); // GridView object called listingRooms set to the returned value of FindControl with gvSingleListingRooms as a parameter from the events passed Item object converted to a GridView
            PlaceHolder listingAmenities = (PlaceHolder)e.Item.FindControl("plhldListingAmenities"); // PlaceHolder object called listingAmenities set to the returned value of FindControl with plhldListingAmenities as a parameter from the events passed Item object converted to a PlaceHolder
            Label listingCompanyLabel = (Label)e.Item.FindControl("lblSingleListingAgentCompany"); // Label object called listingCompanyLabel set to the returned value of FindControl with lblSingleListingAgentCompany as a parameter from the events passed Item object converted to a Label
            Label listingAgentLabel = (Label)e.Item.FindControl("lblSingleListingAgentName"); // Label object called listingAgentLabel set to the returned value of FindControl with lblSingleListingAgentName as a parameter from the events passed Item object converted to a Label
            Label listingAgentEmailLabel = (Label)e.Item.FindControl("lblSingleListingAgentEmail"); // Label object called listingAgentEmailLabel set to the returned value of FindControl with lblSingleListingAgentEmail as a parameter from the events passed Item object converted to a Label
            Label listingAddressLabel = (Label)e.Item.FindControl("lblSingleListingAddress"); // Label object called listingAddressLabel set to the returned value of FindControl with lblSingleListingAddress as a parameter from the events passed Item object converted to a Label
            Label listingAskingPriceLabel = (Label)e.Item.FindControl("lblSingleListingAskingPrice"); // Label object called listingAskingPriceLabel set to the returned value of FindControl with lblSingleListingAskingPrice as a parameter from the events passed Item object converted to a Label
            Label listingYearBuiltLabel = (Label)e.Item.FindControl("lblSingleListingYearBuilt"); // Label object called listingYearBuiltLabel set to the returned value of FindControl with lblSingleListingYearBuilt as a parameter from the events passed Item object converted to a Label
            Label listingSqFtLabel = (Label)e.Item.FindControl("lblSingleListingSqFt"); // Label object called listingSqFtLabel set to the returned value of FindControl with lblSingleListingSqFt as a parameter from the events passed Item object converted to a Label
            Label listingBedroomsLabel = (Label)e.Item.FindControl("lblSingleListingBedrooms"); // Label object called listingBedroomsLabel set to the returned value of FindControl with lblSingleListingBedrooms as a parameter from the events passed Item object converted to a Label
            Label listingBathroomsLabel = (Label)e.Item.FindControl("lblSingleListingBathrooms"); // Label object called listingBathroomsLabel set to the returned value of FindControl with lblSingleListingBathrooms as a parameter from the events passed Item object converted to a Label
            Label listingGarageLabel = (Label)e.Item.FindControl("lblSingleListingGarage"); // Label object called listingGarageLabel set to the returned value of FindControl with lblSingleListingGarage as a parameter from the events passed Item object converted to a Label
            Label listingHeatingLabel = (Label)e.Item.FindControl("lblSingleListingHeatingSystem"); // Label object called listingHeatingLabel set to the returned value of FindControl with lblSingleListingHeatingSystem as a parameter from the events passed Item object converted to a Label
            Label listingCoolingLabel = (Label)e.Item.FindControl("lblSingleListingCoolingSystem"); // Label object called listingCoolingLabel set to the returned value of FindControl with lblSingleListingCoolingSystem as a parameter from the events passed Item object converted to a Label
            Label listingWaterLabel = (Label)e.Item.FindControl("lblSingleListingWater"); // Label object called listingWaterLabel set to the returned value of FindControl with lblSingleListingWater as a parameter from the events passed Item object converted to a Label
            Label listingSewerLabel = (Label)e.Item.FindControl("lblSingleListingSewer"); // Label object called listingSewerLabel set to the returned value of FindControl with lblSingleListingSewer as a parameter from the events passed Item object converted to a Label
            Label listingDateLabel = (Label)e.Item.FindControl("lblSingleListingListingDate"); // Label object called listingDateLabel set to the returned value of FindControl with lblSingleListingListingDate as a parameter from the events passed Item object converted to a Label
            Label listingDaysOnMarketLabel = (Label)e.Item.FindControl("lblSingleListingTotalMarketDays"); // Label object called listingDaysOnMarketLabel set to the returned value of FindControl with lblSingleListingTotalMarketDays as a parameter from the events passed Item object converted to a Label
            Label listingDescriptionLabel = (Label)e.Item.FindControl("lblSingleListingDescription"); // Label object called listingDescriptionLabel set to the returned value of FindControl with lblSingleListingDescription as a parameter from the events passed Item object converted to a Label
            Button btnSingleListingRequestShowing = (Button)e.Item.FindControl("btnSingleListingRequestShowing"); // Button object called btnSingleListingRequestShowing set to the returned value of FindControl with btnSingleListingRequestShowing as a parameter from the events passed Item object converted to a Button
            Button btnSingleListingMakeOffer = (Button)e.Item.FindControl("btnSingleListingMakeOffer"); // Button object called btnSingleListingMakeOffer set to the returned value of FindControl with btnSingleListingMakeOffer as a parameter from the events passed Item object converted to a Button
            Button btnSingleListingReturnToAllListing = (Button)e.Item.FindControl("btnSingleListingReturnToAllListing");// Button object called btnSingleListingReturnToAllListing set to the returned value of FindControl with btnSingleListingReturnToAllListing as a parameter from the events passed Item object converted to a Button
            Button btnPreviousSingleListingImage = (Button)e.Item.FindControl("btnPreviousImage"); // Button object called btnPreviousSingleListingImage set to the returned value of FindControl with btnPreviousImage as a parameter from the events passed Item object converted to a Button
            Button btnNextSingleListingImage = (Button)e.Item.FindControl("btnNextImage"); // Button object called btnNextSingleListingImage set to the returned value of FindControl with btnNextImage as a parameter from the events passed Item object converted to a Button
            Chart historyChart = (Chart)e.Item.FindControl("crtPriceHistoryChart"); // Chart object called historyChart set to the returned value of FindControl with crtPriceHistoryChart as a parameter from the events passed Item object converted to a Chart
            Property property = (Property)dataItem.DataItem; // Property object called property set to the dataItem objects DataItem converted to a Property object
            Account agent = dashboardHandler.GetAccountInfo(property.AccountID)[0]; // Accout object called agent set to the first item in returned value from GetAccountInfo function from dashboardHanlder object with the property objects AccountID as a parameter

            historyChart.Titles.Add("Price History"); // sets the historyChart objects title to price history
            historyChart.Series["PriceHistory"].ChartType = SeriesChartType.Line; // sets the historyChart objects pricehistory series charttype to a line chart
            historyChart.Series["PriceHistory"].MarkerStyle = MarkerStyle.Circle; // sets the historyChart objects pricehistory series markerStyle to a cirlce
            historyChart.Series["PriceHistory"].MarkerSize = 8; // sets the historyChart objects pricehistory series markersize to be 8
            historyChart.Series["PriceHistory"].MarkerColor = System.Drawing.Color.Red; // sets the historyChart objects pricehistory series marker color to be red
            historyChart.ChartAreas["PriceHistoryChart"].AxisX.Title = "Date"; // sets the historyChart objects PriceHistoryChart chart areas x axis title to date
            historyChart.ChartAreas["PriceHistoryChart"].AxisY.Title = "Price"; // sets the historyChart objects PriceHistoryChart chart areas y axis title to price
            historyChart.ChartAreas["PriceHistoryChart"].AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray; // sets the historyChart objects PriceHistoryChart chart areas x axis grid line color to light gray
            historyChart.ChartAreas["PriceHistoryChart"].AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray; // sets the historyChart objects PriceHistoryChart chart areas y axis grid line color to light gray
            historyChart.ChartAreas["PriceHistoryChart"].AxisY.LabelStyle.Format = "C"; // sets the historyChart objects PriceHistoryChart chart areas x axis label format to a currency format
            foreach (PropertyPriceHistory priceHistory in dashboardHandler.GetPropertyPriceHistory(property.PropertyID)) // foreach PropertyPriceHistory object called priceHistory in the returned value of GetPropertyPriceHistory function from the object dashboardHandler with the property objects PropertyID as a parameter do
            {
                historyChart.Series["PriceHistory"].Points.AddXY(priceHistory.PriceUpdateDate, priceHistory.NewPrice); // adds a new plot on the historyChart objects priceHistory series with the current priceHistory objects PriceUpdateDate as the x value and the current priceHistory objects NewPrice as the y value
            }

            List<Amenity> amenities = new List<Amenity>(); // List object of Amenity objects called amenities set to a new list of Amenity objects
            foreach (Amenity amenity in dashboardHandler.GetAllAmenities()) // foreach Amenity object called amenity in the returned value of GetAllAmenitites from the dashboardHandler object do 
            {
                foreach (PropertyAmenity allPropertyAmenites in dashboardHandler.GetPropertyAmenities(property.PropertyID)) // foreach PropertyAmenity object called allPropertyAmenites in the returned value of GetPropertyAmenities from the dashboardHandler object with the property objects PropertyId as a parameter do
                {
                    if (amenity.AmenityID == allPropertyAmenites.AmenityID) // if the current amenity objects AmenityID is equal to the current allPropertyAmenites objects AmenityID then
                    {
                        amenities.Add(amenity); // adds the current amenity to the amenities list object
                    }
                }
            }

            // Sets all the label objects text to information from the agent or property object - my fingers hurt
            listingCompanyLabel.Text = "Real Estate Company: " + agent.WorkName;
            listingAgentLabel.Text = "Company Agent: " + agent.FirstName + agent.LastName;
            listingAgentEmailLabel.Text = "Agent Email: " + agent.PersonalEmail;
            listingAddressLabel.Text = property.AddressStreet + ", " + property.AddressCity + ", " + property.AddressState + ", " + property.AddressZipCode;
            listingAskingPriceLabel.Text = property.AskingPrice.ToString("C");
            listingYearBuiltLabel.Text = property.YearBuilt.ToString();
            listingSqFtLabel.Text = property.PropertySize.ToString();
            listingBedroomsLabel.Text = property.NumberOfBedrooms.ToString();
            listingBathroomsLabel.Text = property.NumberOfBathrooms.ToString();
            listingGarageLabel.Text = property.GarageType.ToString();
            listingHeatingLabel.Text = property.HeatingSystem;
            listingCoolingLabel.Text = property.CoolingSystem;
            listingWaterLabel.Text = property.UtilitiesWater;
            listingSewerLabel.Text = property.UtilitiesSewer;
            listingDateLabel.Text = property.CreationDate.ToString();
            DateTime today = DateTime.Now.Date; // DateTime object called today set to the current Date
            listingDaysOnMarketLabel.Text = (today - property.CreationDate.Date).Days.ToString() + " days listed"; // sets listingDaysOnMarketLabel objects text to the number of days from today object - the property objects CreationDates date converted to a string
            listingDescriptionLabel.Text = property.PropertyDescription;

            dashboardHandler.SetSingleListingImages(dashboardHandler.GetAllPropertyImages(property.PropertyID)); // calls the SetSingleListingImages function from the dashboardHandler object with the returned value from GetAllPropertyImages function from the dashboard handler as a parameter
            listingImage.ImageUrl = dashboardHandler.GetSingleListingImageURL(); // sets the listing images imageurl to the returned value of GetSingleListingImageUrl function from the dashboardHnadler object

            foreach (Amenity listingAmenity in amenities) // foreach Amenity object called listingAmenity in the amenities list object do 
            {
                Label amenityLabel = new Label(); // Label object called amenityLabel set to a new Label
                amenityLabel.Text = listingAmenity.AmenityName; // sets the amnityLabels text to the current listingAmenity objects AmenityName
                amenityLabel.CssClass = "badge bg-primary me-2"; // sets the amenityLabels CssClass to badge bg-primary me-2
                listingAmenities.Controls.Add(amenityLabel); // adds the amenityLabel to the listingAmenitites placeholder object
            }

            listingRooms.DataSource = dashboardHandler.GetAllPropertyRooms(property.PropertyID); // sets the listingRooms objects datasource to the returned value of GetAllPropertyRooms function from the dashboardHandler with the current property objects PropertyID as a parameter
            listingRooms.DataBind(); // calls the DataBind function on the listingRooms object
             
            btnSingleListingRequestShowing.CommandArgument = property.PropertyID.ToString(); // sets the btnSingleListingRequestShowing CommandArgument to the property objects PropertyID converted to a string
            btnSingleListingMakeOffer.CommandArgument = property.PropertyID.ToString(); // sets the btnSingleListingMakeOffer CommandArgument to the property objects PropertyID converted to a string
            btnSingleListingReturnToAllListing.CommandArgument = property.PropertyID.ToString(); // sets the btnSingleListingReturnToAllListing CommandArgument to the property objects PropertyID converted to a string
            btnPreviousSingleListingImage.CommandArgument = property.PropertyID.ToString(); // sets the btnPreviousSingleListingImage CommandArgument to the property objects PropertyID converted to a string
            btnNextSingleListingImage.CommandArgument= property.PropertyID.ToString(); // sets the btnNextSingleListingImage CommandArgument to the property objects PropertyID converted to a string

        }

        private void HideAllListings() // private HideAllListings function
        {
            lstvDashboardListing.Visible = false; // sets lstvDashboardListing to not be visible
        }

        private void ShowAllListings() // private ShowAllListings function
        {
            lstvDashboardListing.Visible = true; // sets lstvDashboardListing to be visible
        }

        private void ShowSingleListing() // private ShowSingleListing function
        {
            lstvSingleListing.Visible = true; // sets lstvSingleListing to be visible
        }

        private void HideSingleListing() // private HideSingleListing function
        {
            lstvSingleListing.Visible = false; // sets lstvSingleListing to not be visible
        }

        protected void btnConfirmShowing_Click(object sender, EventArgs e) // Button btnConfirmShowing click event handler
        {
            ResetShowingErrorMessage(); // calls the ResetShowingErrorMessage function
            if (ValidateShowing() == true) // if the returned value from ValidateShowing function is true then
            {
                DateTime showingDate = calShowingDate.SelectedDate.Date; // DateTime object called showingDate set to the calShowingDate calendars selectedDate's date
                string showingTime = txtShowingTime.Text.ToString() + " " + drplAmPm.SelectedValue.ToString(); // string variable called showingTime set to the txtShowingTime textboxs text plus a space plus the drplAmPm droplists selected value 
                showingDate = showingDate.Add(DateTime.Parse(showingTime).TimeOfDay); // adds the showingTime converted to a DateTime obejct to the showingDate object
                dashboardHandler.MakeNewShowingRequest(dashboardHandler.GetShowingPropertyID(), txtShowingFirstName.Text, txtShowingLastName.Text, txtShowingEmailAddress.Text, txtShowingPhoneNumber.Text, showingDate); // calls the MakeNewShowingRequest function from the dashboardHandler object with the returned value of GetShowingPropertyId function, txtShowingFirstName text, txtShowingLastName text, txtShowingEmailAddress text, txtShowingPhoneNumber text, and the showingDate object

                Property showingProperty = dashboardHandler.GetSingleProperty(dashboardHandler.GetShowingPropertyID())[0]; // property objecct called showingProperty set to the first item from the returned value from GetSingleProperty function from the dashboardHandler object with the returned value from GetshowingPropertyID function from the dashboardHandler as a parameter
                Account agentAccount = dashboardHandler.GetAccountInfo(showingProperty.AccountID)[0]; // account object called agentAccount set to the first item from the returned value from GetAccountInfo function form dashboardHandler object with the showingPropertys accountId as a parameter
                string toAddress = agentAccount.PersonalEmail; // string toAddress set to the agentAccounts peronsal email
                string fromAddress = agentAccount.WorkEmail; // string fromAddress set to the agentAccounts WorkEmail
                string subject = "New Showing Scheduled For One Of Your Property Listings!"; // string subject set to this string
                string body = "A new showing has been scheduled for the property " + showingProperty.AddressStreet + ", " + showingProperty.AddressCity + ", " + showingProperty.AddressState + ", " + showingProperty.AddressZipCode + " for the date and time of " + showingDate.ToString() +
                                ". Sign into your agent account dashboard to see all your upcoming showings!";

                dashboardHandler.SendEmail(toAddress, fromAddress, subject, body); // calls the SendEmail function of the dashboardHandler object with toAddress, fromAddress, subject, and body
                HideRequestShowing();
                ShowAllListings();
            }
        }

        protected void btnCancelShowing_Click(object sender, EventArgs e) // Button btnCancelShowing click event handler
        {
            HideRequestShowing(); // calls HideRequestShowing function
            ShowAllListings(); // calls ShowAllListings function
        }

        private void ShowOfferArea() // private ShowOfferArea function
        {
            makeOfferArea.Visible = true; // sets makeOfferArea to be visible
        }

        private void HideOfferArea() // private HideOfferArea function
        { 
            makeOfferArea.Visible = false; // sets makeOfferArea to not be visible
        }

        protected void btnOfferSubmit_Click(object sender, EventArgs e) // Button btnOfferSubmit_Click click event handler
        {
            ResetOfferRequestErrorMessage();// calls the ResetOfferRequestErrorMessage function

            if (ValidateOfferRequest() == true) // if the returned value from ValidateOfferRequest function is true then
            {
                DateTime moveInDate = calOfferMoveIn.SelectedDate.Date; // DateTime object called moveInDate set to the calOfferMoveIn calendars selectedDate's date
                decimal offerAmount = decimal.Parse(txtOfferAmount.Text); // decimal offerAmount set to the converted decimal value of txtOfferAmount textboxs text
                dashboardHandler.MakeNewOffer(dashboardHandler.GetShowingPropertyID(), txtOfferFirstName.Text, txtOfferLastName.Text, offerAmount, drplOfferType.SelectedValue.ToString(), txtOfferPhone.Text, txtOfferEmail.Text, radlOfferSellHouse.SelectedValue.ToString(), moveInDate); // makes the new offer
                dashboardHandler.MakeNewOfferContingencies(dashboardHandler.GetPropertyOfferOfferID(dashboardHandler.GetShowingPropertyID(), txtOfferFirstName.Text, txtOfferLastName.Text), dashboardHandler.GetNewOfferContingencies()); // makes the offer contingencies 
                dashboardHandler.MakeNewOfferStatus(dashboardHandler.GetPropertyOfferOfferID(dashboardHandler.GetShowingPropertyID(), txtOfferFirstName.Text, txtOfferLastName.Text)); // makes the offer status

                Property offerProperty = dashboardHandler.GetSingleProperty(dashboardHandler.GetShowingPropertyID())[0]; // property objecct called offerProperty set to the first item from the returned value from GetSingleProperty function from the dashboardHandler object with the returned value from GetshowingPropertyID function from the dashboardHandler as a parameter
                Account agentAccount = dashboardHandler.GetAccountInfo(offerProperty.AccountID)[0]; // account object called agentAccount set to the first item from the returned value from GetAccountInfo function form dashboardHandler object with the showingPropertys accountId as a parameter
                string toAddress = agentAccount.PersonalEmail; // string toAddress set to the agentAccounts peronsal email
                string fromAddress = agentAccount.WorkEmail; // string fromAddress set to the agentAccounts WorkEmail
                string subject = "New Offer Made For One Of Your Property Listings!"; // string subject set to this string
                string body = "A new offer has been made for the property " + offerProperty.AddressStreet + ", " + offerProperty.AddressCity + ", " + offerProperty.AddressState + ", " + offerProperty.AddressZipCode + " for the amount of " + txtOfferAmount.Text +
                                ". Sign into your agent account dashboard to accept or reject the offer!";

                dashboardHandler.SendEmail(toAddress, fromAddress, subject, body); // calls the SendEmail function of the dashboardHandler object with toAddress, fromAddress, subject, and body
                HideOfferArea();
                ShowAllListings();
            }
        }

        protected void btnOfferCancel_Click(object sender, EventArgs e) // Button btnOfferCancel click event handler
        {
            HideOfferArea(); // calls HideOfferArea function
            ShowAllListings(); // calls HideOfferArea function
        }

        protected void drplOfferType_SelectedIndexChanged(object sender, EventArgs e) // DropList drplOfferType selected index changed event handler
        {
            if (drplOfferType.SelectedIndex == 3) // if drplOfferType selected index is equal to 3 then 
            {
                txtOfferContingency.Visible = true; // sets txtOfferContingency to be visible
                btnAddContingency.Visible = true; // sets btnAddContingency to be visible
                gvOfferContingencies.Visible = true; // sets gvOfferContingencies to be visible
                lblContingencyInput.Visible = true; // sets lblContingencyInput to be visible
                dashboardHandler.ResetNewOfferContingencies(); // calls the ResetNewOfferContingencies function from the dashboardHandler object
                gvOfferContingencies.DataSource = null; // sets gvOfferContingencies datasource to be null
                gvOfferContingencies.DataBind(); // calls the databind function of gvOfferContingencies
            }
            else // else the selected index is not 3
            {
                lblContingencyInput.Visible = false; // sets lblContingencyInput to not be visible
                txtOfferContingency.Visible = false; // sets txtOfferContingency to not be visible
                btnAddContingency.Visible = false; // sets btnAddContingency to not be visible
                gvOfferContingencies.Visible = false; // sets gvOfferContingencies to not be visible
            }
        }

        protected void btnAddContingency_Click(object sender, EventArgs e) // Button btnAddContingency click event handler
        {
            dashboardHandler.AddNewOfferContingency(txtOfferContingency.Text); // calls the AddNewOfferContingency function from dashboardHandler object with txtOfferContingency textboxs text as a parameter
            gvOfferContingencies.DataSource = dashboardHandler.GetNewOfferContingencies(); // sets gvOfferContingencies datasource to the returned value of GetNewOfferContingencies function from dashboardHandler
            gvOfferContingencies.DataBind(); // calls the DataBind function from gvOfferContingencies gridview
        }

        protected void gvOfferContingencies_RowDeleting(object sender, GridViewDeleteEventArgs e) //Gridview gvOfferContingcies RowDeleting event handler
        {
            int rowIndex = e.RowIndex; // int rowIndex set to the events passed objects RowIndex

            foreach (GridViewRow row in gvOfferContingencies.Rows) // foreach GridViewRow object in gvOfferContingencies rows do
            {
                if (row.RowIndex == rowIndex) // if the current rows RowIndex is equal to the rowIndex then
                {
                    dashboardHandler.RemoveNewOfferContingency(rowIndex); // calls the RemoveNewOfferContingency function from the dashboardHanlder object with rowIndex as a parameter
                }
            }

            gvOfferContingencies.DataSource = dashboardHandler.GetNewOfferContingencies();// sets  gvOfferContingencies datasource to the returned value from GetNewOfferContingencies from the dashboardHandler object
            gvOfferContingencies.DataBind(); // calls the DataBind function from gvOfferContingencies
        }

        protected void btnApplyFitler_Click(object sender, EventArgs e) // Button btnApplyFilter click event handler
        {
            ResetFilterErrorMessage(); // calls the ResetFilterErrorMessage function
            GetFilterOptions(); // calls the GetFilterOptions function

            if (ValidateFilterInput(dashboardHandler.GetFilterOptions()) == true) // if the returned value from ValidateFilterInput function with the returned value from GetFilterOptions function from the dashboardHandler as a parameter is equal to true then
            {
                lstvDashboardListing.DataSource = dashboardHandler.ApplyFilter(filterInputs, selectedAmenities); // sets lstvDashboardListing datasource to the returned value from ApplyFilter function from dashboardHandler object with filterInputs and selectedAmenities as a parameter
                lstvDashboardListing.DataBind(); // calls the DataBind function of lstvDashboardListing
            }
        }

        private void GetFilterOptions() // private GetFilterOptions function
        {
            filterInputs = new Dictionary<string, string>(); // filterInput set to a new string dictionary
            selectedAmenities = new List<int>(); // selectedAmenities set to a new List of ints 
            if (txtFilterCity.Text != "" || txtFilterCity.Text != string.Empty) // if txtFilterCitys text is not empty then
            {
                dashboardHandler.SetFilterOption(true, 0); // calls the SetFilterOption function from the dashboardHandler object with true and 0 as a paramter
                filterInputs["FilterCity"] = txtFilterCity.Text; // sets filterInputs FilterCity keys value to the txtFilterCity textboxs text
            }
            else // else txtFilterCity text is empty
            {
                dashboardHandler.SetFilterOption(false, 0); // calls the SetFilterOption function from the dashboardHandler object with false and 0 as a paramter
                filterInputs["FilterCity"] = ""; // sets filterInputs FilterCity keys value to the a empty string
            }

            if (drplFilterState.SelectedIndex != -1) // if drplFitlerStates selected index is not -1 then
            {
                dashboardHandler.SetFilterOption(true, 1); // calls the SetFilterOption function from the dashboardHandler object with true and 1 as a paramter
                filterInputs["FilterState"] = drplFilterState.SelectedValue; // sets filterInputs FilterState keys value to the drplFilterState droplists selected value
            }
            else // else drplFilterState is -1
            {
                dashboardHandler.SetFilterOption(false, 1); // calls the SetFilterOption function from the dashboardHandler object with false and 1 as a paramter
                filterInputs["FilterState"] = ""; // sets filterInputs FilterState keys value to the a empty string
            }

            bool selectedPropertyType = false; // bool selectedPropertyType set to fales
            foreach (ListItem option in radlFilterPropertyType.Items) // foreach ListItem called option in radlFilterPropertyType radio button lists items do
            {
                if (option.Selected == true) // if option is seleced then
                {
                    dashboardHandler.SetFilterOption(true, 2); // calls the SetFilterOption function from the dashboardHandler object with true and 2 as a paramter
                    filterInputs["FilterPropertyType"] = radlFilterPropertyType.SelectedValue; // sets filterInputs FilterPropertyType keys value to the radlFilterPropertyType radiobuttonlists selected value
                    selectedPropertyType = true; // sets selectedPropertyType to be true
                }
            }

            if (selectedPropertyType == false) // if selectedPropertyType is equal to false then
            {
                dashboardHandler.SetFilterOption(false, 2); // calls the SetFilterOption function from the dashboardHandler object with false and 2 as a paramter
                filterInputs["FilterPropertyType"] = ""; // sets filterInputs FilterPropertyType keys value to the a empty string
            }

            if ((txtFilterMaxPrice.Text != "" || txtFilterMaxPrice.Text != string.Empty) && (txtFilterMinPrice.Text != "" || txtFilterMinPrice.Text != string.Empty)) // if txtFilterMaxPrice and txtFilterMinPrice is not empty then
            {
                dashboardHandler.SetFilterOption(true, 3); // calls the SetFilterOption function from the dashboardHandler object with true and 3 as a paramter
                filterInputs["FilterMaxPrice"] = txtFilterMaxPrice.Text; // sets filterInputs FilterMaxPrice keys value to the txtFilterMaxPrice textboxs text
                filterInputs["FilterMinPrice"] = txtFilterMinPrice.Text; // sets filterInputs FilterMinPrice keys value to the txtFilterMinPrice textboxs text
            }
            else // else txtFilterMaxPrice and txtFilterMinPrice is empty 
            {
                dashboardHandler.SetFilterOption(false, 3); // calls the SetFilterOption function from the dashboardHandler object with false and 3 as a paramter
                filterInputs["FilterMaxPrice"] = ""; // sets filterInputs FilterMaxPrice keys value to a empty string
                filterInputs["FilterMinPrice"] = ""; // sets filterInputs FilterMinPrice keys value to a empty string
            }

            if (txtFilterSize.Text != "" || txtFilterSize.Text != string.Empty) // if txtFilterSize text is not empty then
            {
                dashboardHandler.SetFilterOption(true, 4); // calls the SetFilterOption function from the dashboardHandler object with true and 4 as a paramter
                filterInputs["FilterSize"] = txtFilterSize.Text; // sets filterInputs FilterSize keys value to the txtFilterSize textboxs text
            }
            else // else txtFilterSize is empty
            {
                dashboardHandler.SetFilterOption(false, 4); // calls the SetFilterOption function from the dashboardHandler object with false and 4 as a paramter
                filterInputs["FilterMinSize"] = ""; // sets filterInputs FilterMinSize keys value to the a empty string
            }

            if (txtFilterMinBedroom.Text != "" || txtFilterMinBedroom.Text != string.Empty) // if txtFilterMinBedroom is not empty then
            {
                dashboardHandler.SetFilterOption(true, 5); // calls the SetFilterOption function from the dashboardHandler object with true and 5 as a paramter
                filterInputs["FilterMinBedroom"] = txtFilterMinBedroom.Text; // sets filterInputs FilterMinBedroom keys value to the txtFilterMinBedroom textboxs text
            }
            else // else txtFilterMinBedroom is empty
            { 
                dashboardHandler.SetFilterOption(false, 5); // calls the SetFilterOption function from the dashboardHandler object with false and 5 as a paramter
                filterInputs["FilterMinBedroom"] = ""; // sets filterInputs FilterMinBedroom keys value to the a empty string
            }

            if (txtFilterMinBathroom.Text != "" || txtFilterMinBathroom.Text != string.Empty) // if txtFilterMinBathroom is not empty then
            {
                dashboardHandler.SetFilterOption(true, 6); // calls the SetFilterOption function from the dashboardHandler object with true and 6 as a paramter
                filterInputs["FilterMinBathroom"] = txtFilterMinBathroom.Text; // sets filterInputs FilterMinBathroom keys value to the txtFilterMinBathroom textboxs text
            }
            else // else txtFilterMinBathroom is empty
            {
                dashboardHandler.SetFilterOption(false, 6); // calls the SetFilterOption function from the dashboardHandler object with false and 6 as a paramter
                filterInputs["FilterMinBathroom"] = ""; // sets filterInputs FilterMinBathroom keys value to the a empty string
            }

            if (chklFilterAmenities.SelectedIndex != -1) // if chklFilterAmenities selected index is not equal to -1 then
            {
                dashboardHandler.SetFilterOption(true, 7); // calls the SetFilterOption function from the dashboardHandler object with true and 7 as a paramter
            }
            else // else selectedIndex is -1
            {
                dashboardHandler.SetFilterOption(false, 7); // calls the SetFilterOption function from the dashboardHandler object with false and 7 as a paramter
            }

            foreach (ListItem option in chklFilterAmenities.Items) // foreach ListItem called option in chklFilterAmenities checkbox lists items do
            {
                if (option.Selected) // if option is selected then
                {
                    selectedAmenities.Add(int.Parse(option.Value)); // adds the current options value converted to a int to the selectedAmenities list 
                }
            }

        }

        protected void btnClearFilter_Click(object sender, EventArgs e) // btnClearFilter click event handler
        {
            ClearFilterInput(); // calls ClearFilterInput function
            lstvDashboardListing.DataSource = dashboardHandler.GetAllActiveProperties(dashboardHandler.GetAllActivePropertySatuses()); // sets lstvDashboardListing DataSource to the returned value of GetAllActiveProperties from the dashboardHandler with the returned value of GetAllActivePropertySatuses from dashboardHandler as a parameter
            lstvDashboardListing.DataBind(); // calls the databind function from lstvDashboardListing

        }

        private void ClearFilterInput() // private ClearFilterInput function
        {
            txtFilterCity.Text = ""; // sets txtFilterCity text to a empty string
            txtFilterMaxPrice.Text = ""; // sets txtFilterMaxPrice text to a empty string
            txtFilterMinBathroom.Text = ""; // sets txtFilterMinBathroom text to a empty string
            txtFilterMinBedroom.Text = ""; // sets txtFilterMinBedroom text to a empty string
            txtFilterMinPrice.Text = ""; // sets txtFilterMinPrice text to a empty string
            txtFilterSize.Text = "";// sets txtFilterSize text to a empty string

            // unselects all chklFilterAmenities options
            foreach (ListItem option in chklFilterAmenities.Items)
            {
                if (option.Selected)
                {
                    option.Selected = false;
                }
            }

            radlFilterPropertyType.SelectedIndex = -1; // sets radlFilterPropertyType radio button list selected index to -1
        }

        private bool ValidateFilterInput(bool[] selectedFilters) // private ValidateFilterInput that returns a bool and accepts a bool array
        {
            bool isFiltersValid = true; // bool isFiltersValid set to true
            if (selectedFilters[0] == true) // if the first bool in selectedFilters is true then
            {
                if (validater.ValidateString(txtFilterCity.Text) == false) // if the ValidateString function from the validater object with txtFilterCitys text as a parameter is false then
                {
                    isFiltersValid = false; // sets isFiltersValid to false
                    lblFilterOptionError.Text += "Error - Filter City Is Invalid - Please enter a proper city!<br/>"; // adds a error message to lblFilterOptionError label
                }
            }

            if (selectedFilters[3] == true) // if the fourth bool in selectedFilters is true then
            {
                if (validater.ValidateDecimal(txtFilterMaxPrice.Text) == false || validater.ValidateDecimal(txtFilterMinPrice.Text) == false) // if the ValidateDecimal function from the validater object with txtFilterMaxPrice text as a parameter is false or if the ValidateDecimal function from the validater object with txtFilterMinPrice text as a parameter is false then
                {
                    isFiltersValid = false; // sets isFiltersValid to false
                    lblFilterOptionError.Text += "Error - Filter Min/Max Price Is Invalid - Please enter a proper number for each!<br/>"; // adds a error message to lblFilterOptionError label
                }
            }

            if (selectedFilters[4] == true) // if the fifth bool in selectedFilters is true then
            {
                if (validater.ValidateDecimal(txtFilterSize.Text) == false) // if the ValidateDecimal function from the validater object with txtFilterSize text as a parameter is false then
                {
                    isFiltersValid = false; // sets isFiltersValid to false
                    lblFilterOptionError.Text += "Error - Filter Size Is Invalid - Please enter a proper number!<br/>"; // adds a error message to lblFilterOptionError label
                }
            }

            if (selectedFilters[5] == true) // if the sixth bool in selectedFilters is true then
            {
                if (validater.ValidateInt(txtFilterMinBedroom.Text) == false) // if the ValidateInt function from the validater object with txtFilterMinBedroom text as a parameter is false then
                {
                    isFiltersValid = false; // sets isFiltersValid to false
                    lblFilterOptionError.Text += "Error - Filter Min Bedroom Is Invalid - Please enter a proper number!<br/>"; // adds a error message to lblFilterOptionError label
                }
            }

            if (selectedFilters[6] == true) // if the seventh bool in selectedFilters is true then
            {
                if (validater.ValidateDecimal(txtFilterMinBathroom.Text) == false) // if the ValidateDecimal function from the validater object with txtFilterMinBathroom text as a parameter is false then
                {
                    isFiltersValid = false; // sets isFiltersValid to false
                    lblFilterOptionError.Text += "Error - Filter Min Bathroom Is Invalid - Please enter a proper number!<br/>"; // adds a error message to lblFilterOptionError label
                }
            }

            return isFiltersValid; // returns isFiltersValid 
        }

        private void ResetFilterErrorMessage() // private ResetFilterErrorMessage function
        {
            lblFilterOptionError.Text = ""; // sets  lblFilterOptionError text to a empty string
        }

        private bool ValidateShowing() // private ValidateShowing function that returns a bool
        {
            bool isShowingValid = true; // bool isShowingValid set to true 

            if (validater.ValidateWord(txtShowingFirstName.Text) == false) // if the returned value from ValidateWord function from validater object with txtShowingFirstName texts as a parameter is equal to false then
            {
                isShowingValid = false; // sets isShowingValid to false
                lblShowingRequestError.Text += "Error - Fisrt Name Missing Or Invalid - Please enter a first name!<br/>"; // adds error message to lblShowingRequestError labels text
            }

            if (validater.ValidateWord(txtShowingLastName.Text) == false) // if the returned value from ValidateWord function from validater object with txtShowingLastName texts as a parameter is equal to false then
            {
                isShowingValid = false; // sets isShowingValid to false
                lblShowingRequestError.Text += "Error - Last Name Missing Or Invalid - Please enter a last name<br/>"; // adds error message to lblShowingRequestError labels text
            }

            if (validater.ValidateString(txtShowingEmailAddress.Text) == false) // if the returned value from ValidateString function from validater object with txtShowingEmailAddress texts as a parameter is equal to false then
            {
                isShowingValid = false; // sets isShowingValid to false
                lblShowingRequestError.Text += "Error - Email Missing Or Invalid - Please enter a email! <br/>"; // adds error message to lblShowingRequestError labels text
            }

            if (validater.ValidatePhoneNumber(txtShowingPhoneNumber.Text) == false) // if the returned value from ValidatePhoneNumber function from validater object with txtShowingPhoneNumber texts as a parameter is equal to false then
            {
                isShowingValid = false; // sets isShowingValid to false
                lblShowingRequestError.Text += "Error - Phone Number Missing Or Invalid  - Please enter a valid phone number! <br/>"; // adds error message to lblShowingRequestError labels text
            }

            if (calShowingDate.SelectedDate == null) // if calShowingDate calendars selected date is null then
            {
                isShowingValid = false; // sets isShowingValid to false
                lblShowingRequestError.Text += "Error - No Showing Date Selected - Please select date for the showing!<br/>"; // adds error message to lblShowingRequestError labels text
            }

            if (validater.ValidateTime(txtShowingTime.Text) == false) // if the returned value from ValidateTime function from validater object with txtShowingTime texts as a parameter is equal to false then
            {
                isShowingValid = false; // sets isShowingValid to false
                lblShowingRequestError.Text += "Error - Showing Time Is Missing/Invalid - Please enter a valid time showing! Ex: 9:00 or 12:30 <br/>"; // adds error message to lblShowingRequestError labels text
            }


            return isShowingValid; // returns isShowingValid
        }

        private void ResetShowingErrorMessage() // private ResetShowingErrorMessage function
        {
            lblShowingRequestError.Text = ""; // sets lblShowingRequestError text to a empty string
        }

        private bool ValidateOfferRequest() // private ValidateOfferRequest function
        {
            bool isOfferValid = true; // sets isOfferValid to true 

            if (validater.ValidateWord(txtOfferFirstName.Text) == false) // if the returned value from ValidateWord function from validater object with txtOfferFirstName texts as a parameter is equal to false then
            {
                isOfferValid = false; // sets isOfferValid to false
                lblOfferAreaError.Text += "Error - Fisrt Name Missing Or Invalid - Please enter a first name!<br/>"; // adds error message to lblOfferAreaError labels text
            }

            if (validater.ValidateWord(txtOfferLastName.Text) == false) // if the returned value from ValidateWord function from validater object with txtOfferLastName texts as a parameter is equal to false then
            { 
                isOfferValid = false; // sets isOfferValid to false
                lblOfferAreaError.Text += "Error - Last Name Missing Or Invalid - Please enter a last name<br/>"; // adds error message to lblOfferAreaError labels text
            }

            if (validater.ValidateString(txtOfferEmail.Text) == false) // if the returned value from ValidateString function from validater object with txtOfferEmail texts as a parameter is equal to false then
            {
                isOfferValid = false; // sets isOfferValid to false
                lblOfferAreaError.Text += "Error - Email Missing Or Invalid - Please enter a email! <br/>"; // adds error message to lblOfferAreaError labels text
            }

            if (validater.ValidatePhoneNumber(txtOfferPhone.Text) == false) // if the returned value from ValidatePhoneNumber function from validater object with txtOfferPhone texts as a parameter is equal to false then
            {
                isOfferValid = false; // sets isOfferValid to false
                lblOfferAreaError.Text += "Error - Phone Number Missing Or Invalid  - Please enter a valid phone number! <br/>"; // adds error message to lblOfferAreaError labels text
            }

            if (calOfferMoveIn.SelectedDate == null) // if calOfferMoveIn calendars selected date is null then
            {
                isOfferValid = false; // sets isOfferValid to false
                lblOfferAreaError.Text += "Error - No Move-In Date Selected - Please select date for to move-in!<br/>"; // adds error message to lblOfferAreaError labels text
            }

            if (validater.ValidateDecimal(txtOfferAmount.Text) == false) // if the returned value from ValidateDecimal function from validater object with txtOfferAmount texts as a parameter is equal to false then
            {
                isOfferValid = false; // sets isOfferValid to false
                lblOfferAreaError.Text += "Error - Offer Amount Missing Or invalid - Please enter a valid offer amount!<br/>"; // adds error message to lblOfferAreaError labels text
            }

            bool sellingHouseSelected = false; // bool sellingHouseSelected set to false
            // loops through radlOfferSellHouse items to see if an option is selected
            foreach (ListItem option in radlOfferSellHouse.Items)
            {
                if (option.Selected)
                {
                    sellingHouseSelected = true;
                }
            }
            if (sellingHouseSelected == false) // if sellingHouseSelected is false then
            {
                isOfferValid = false; // sets isOfferValid to false
                lblOfferAreaError.Text += "Error - No Selling House Option Selected - Plese select if your selling your current house!<br/>"; // adds error message to lblOfferAreaError labels text

            }


            return isOfferValid; // returns isOfferValid
        }

        private void ResetOfferRequestErrorMessage() // private ResetOfferRequestErrorMessage function
        {
            lblOfferAreaError.Text = ""; // sets lblOfferAreaError text to an empty string
        }
    }
}