using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateLibrary;

namespace RealEstateLibrary
{
    public class MainDashboardController
    {
        private Emailer emailHandler; // private Emailer object called emailHandler
        private PropertyList allPropertyList; // private PropertyList object called allPropertyList
        private PropertyImageList allImageList; // private PropertyImageList object called allImageList
        private PropertyRoomList roomList; // private PropertyRoomList object called roomList
        private PropertyShowingRequest newShowingRequest; // private PropertyShowingRequest object called newShowingRequest
        private PropertyShowingRequestList allShowingRequests = new PropertyShowingRequestList(); // private PropertyShowingRequestList object called allShowingReuests set to a new PropertyShowingRequestList object
        private int showingPropertyID; // private int variable called showingPropertyID
        private int offerPropertyID; // private int variable caleld offerPropertyID
        private PropertyOffer newPropertyOffer; // private PropertyOffer object called newPropertyOffer
        private PropertyOfferList allPropertyOffers = new PropertyOfferList(); // private PropertyOfferList object called allPropertyOffers set to a new PropertyOfferList object
        private List<OfferContingency> newOfferContingencies = new List<OfferContingency>(); // private List of OfferContingency object called newOfferContingencies set to a new List of OfferContingency objects
        private OfferContingencyList allOfferContingencies = new OfferContingencyList(); // private OfferContingencyList object called allOfferContingencies set to a new OfferContingencyList object
        private int newOfferOfferID; // private int variable called newOfferOfferID
        private PropertyOfferStatusList allOfferStatuses = new PropertyOfferStatusList(); // private PropertyOfferStatusList object called allOfferStatuses set to a new PropertyOfferStatusList object

        private AccountList accountList = new AccountList(); // private AccountList object called accountList set to a new AccountList object
        private AmenityList allAmenities = new AmenityList(); // private AmenityList object called allAmenities set to a new AmenityList object
        private PropertyAmenityList propertyAmenities = new PropertyAmenityList(); // private PropertyAmenityList object called propertyAmenitites set to a new PropertyAmenityList object
        private PropertyPriceHistoryList priceHistoryList = new PropertyPriceHistoryList(); // private PropertyPriceHistoryList object called priceHistoryList set to a new PropertyPriceHistoryList object
        private PropertyStatusList propertyStatusList = new PropertyStatusList(); // private PropertyStatusList object called propertyStatusList set to a new PropertyStatusList object
        private PropertyTypeList allPropertyTypes = new PropertyTypeList(); // private PropertyTypeList object called allPropertyTpes set to a new PropertyTypeList 

        private bool[] filterOptionsSelected = new bool[8]; // private bool array called filterOptionsSelected set to a new bool array with eight slots 

        private List<PropertyImage> singleListingImages;
        private int singleListingImageCarouselCount = 0;

        public void SetSingleListingImages(List<PropertyImage> listingImages)
        {
            singleListingImageCarouselCount = 0;
            singleListingImages = new List<PropertyImage>();
            singleListingImages = listingImages;
        }

        public void NextSingleListingImage()
        {
            if (singleListingImageCarouselCount < (singleListingImages.Count - 1))
            {
                singleListingImageCarouselCount++;
            }
        }

        public void PreviousSingleListingImage()
        {
            if (singleListingImageCarouselCount >= 1)
            {
                singleListingImageCarouselCount--;
            }
        }

        public string GetSingleListingImageURL()
        {
            return singleListingImages[singleListingImageCarouselCount].ImageURL;
        }


        public void SendEmail(string toAddress, string fromAddress, string subject, string body) // public SendEmail function that accetps four string parameters
        {
            emailHandler = new Emailer(toAddress, fromAddress, subject, body); // sets the emailHandler object to a new object with toAddress, fromAddress, subject, and body as parameters
        }

        public int GetShowingPropertyID() // public GetShowingPropertyID function that returns an int
        {
            return showingPropertyID; // returns showingPropertyID variable
        }

        public void SetShowingPropertyID(int id) // public GetShowingPropertyID function that accepts an int
        {
            showingPropertyID = id; // sets showingPropertyID variable to the id parameter
        }
        public MainDashboardController() // public MainDashBoardController initalizer
        {
            allPropertyList = new PropertyList(); // sets allPropertyList to a new PropertyList object
            allImageList = new PropertyImageList(); // sets allImageList to a new PropertyImageList object
            
        }

        public List<Property> GetAllProperties() // public GetAllProperties function that returns a List of Property objects
        {
            return allPropertyList.GetAllProperties(); // returns the returned value from the GetAllProperties function from the allPropertyList object
        }

        public List<Property> GetSingleProperty(int propertyID) // public GetSingleProperty function that returns a List of Property objects and accepts an int as a parameter
        {
            return allPropertyList.GetPropertyListByPropertyID(propertyID); // returns the returned value from the GetPropertyListByPropertyID function from the allPropertyList object with the propertyID parameter passed 
        }

        public List<PropertyImage> GetAllPropertyImages(int propertyID) // public GetAllPropertyImages function that returns a List of PropertyImage objects and accepts an int as a parameter
        {
            return allImageList.GetPropertyImages(propertyID); // returns the returned value from the GetPropertyImages function from the allImageList object with the propertyID parameter passed 
        }

        public List<PropertyRoom> GetAllPropertyRooms(int propertyID) // public GetAllPropertyRooms function that returns a List of PropertyRoom objects and accepts an int as a parameter
        {
            roomList = new PropertyRoomList(propertyID); // sets roomList to a new PropertyRoomList object with propertyID as a parameter
            return roomList.GetRoomList(); // returns the returned value from the GetRoomList function from the roomList object
        }


        public void MakeNewShowingRequest(int propertyID, string firstName, string lastName, string email, string phoneNumber, DateTime showingDay) // public MakeNewShowingRequest function that accepts an int, four strings, and a DateTime object as parameters
        {
            newShowingRequest = new PropertyShowingRequest(propertyID, firstName, lastName, email, phoneNumber, showingDay); // sets newShowingRequest to a new PropertyShowingRequest object with propertyID, firstName, lastName, email, phoneNumber, and showingDay as parameters
            allShowingRequests.NewShowingRequest(newShowingRequest); // calls the NewShowingRequest function of the allShowingRequests object with the newShowingRequest object as a parameter
        }

        public void MakeNewOffer(int propertyID, string firstName, string lastName, decimal offerAmount, string offerType, string phoneNumber, string email, string sellHouse, DateTime moveInDate) // public MakeNewOffer function that accepts an int, six strings, a decimal, and a datetime object as parameters
        {
            newPropertyOffer = new PropertyOffer(propertyID, firstName, lastName, offerAmount, offerType, phoneNumber, email, sellHouse, moveInDate); // sets newPropertyOffer to a new PropertyOffer object with propertyID, firstName, lastName, offerAmount, offerType, phoneNumber, email, sellHouse, and moveInDate as parameters
            allPropertyOffers.NewPropertyOffer(newPropertyOffer); // calls the NewPropertyOffer function of the allPropertyOffers object with the newPropertyOffer object as a parameter
        }

        public void ResetNewOfferContingencies() // public ResetNewOfferContingencies function
        {
            newOfferContingencies = new List<OfferContingency>(); // sets newOfferContingencies to a new List of OfferContingecny objects
        }

        public void AddNewOfferContingency(string contingency) // public AddNewOfferContingency function that accepts a string as a parameter
        {
            newOfferContingencies.Add(new OfferContingency(contingency)); // adds a new OfferContingecy object with the contingecy as a parameter to the newOfferContingencies list object
        }

        public void RemoveNewOfferContingency(int index) // public RemoveNewOfferContingency function that accepts a int as a parameter
        {
            newOfferContingencies.RemoveAt(index); // removes the OfferContingency object in the newOfferContingecnies list at the index parameter 
        }

        public List<OfferContingency> GetNewOfferContingencies() // public GetNewOfferContingencies function that returns a List of OfferContingency objects
        {
            return newOfferContingencies; // returns newOfferContingencies list object
        }

        public int GetPropertyOfferOfferID(int propertyID, string firstName, string lastName) // public GetPropertyOfferOfferID function that accepts a int and two strings as parameters and returns a int variable
        {
            allPropertyOffers = new PropertyOfferList(); // sets allPropertyOffers to a new PropertyOfferList object
            return allPropertyOffers.GetPropertyOfferOfferID(propertyID, firstName, lastName); // returns the returned value from the GetPropertyOfferOfferID function from the allPropertyOFfers object with propertyID, firstName, lastName as parameters

        }

        public void MakeNewOfferContingencies(int offerId, List<OfferContingency> contingencies) // public MakeNewOfferContingencies function that accepts a int and a List of OfferContingency object as parameters
        {
            allOfferContingencies.MakeNewOfferContingencies(offerId, contingencies); // calls the MakeNewOfferContingencies function from the allOfferContingecnies object with offerID and contingencies as parameters
        }

        public void MakeNewOfferStatus(int offerID) // public MakeNewOfferStatus function that accepts a int parameter
        {
            allOfferStatuses.MakePropertyOfferStatus(offerID); // calls the MakePropertyOfferStatus function from the allOfferStatuses object with the offerID as a parameter
        }

        public List<Account> GetAccountInfo(int propertyID) // public GetAccountInfo function that accepts a int parameter and returns a List of Account objects
        {
            List<Account> newAccountList = new List<Account>(); // List of Account objects called newAccountList set to a new List of Account objects
            newAccountList.Add(accountList.GetAccountByAccountID(propertyID)); // adds the returned value of GetAcountByAccountID function of the accountList object with propertyID as a parameter to the newAccountList object
            return newAccountList; // returns the newAccountList list object
        }

        public List<Amenity> GetAllAmenities() // public GetAllAmenitites function that returns a List of Amenity objects
        {
            return allAmenities.GetAllAmenities(); // returns the returned value of GetAllAmenities function from the allAmenities object
        }

        public List<PropertyAmenity> GetPropertyAmenities(int propertyID) // public GetPropertyAmenities function that returns a List of PropertyAmenity objects and accepts a int as a parameter
        {
            propertyAmenities = new PropertyAmenityList();
            return propertyAmenities.GetSinglePropertyAmenityList(propertyID); // returns the returned value of GetSinglePropertyAmenityList function from the propertyAmenities object with propertyID as a parameter
        }

        public List<PropertyPriceHistory> GetPropertyPriceHistory(int propertyID) // public GetPropertyPriceHistory function that returns a List of PropertyPriceHistory objects and accepts a int as a parameter
        {
            priceHistoryList = new PropertyPriceHistoryList();
            return priceHistoryList.GetPropertyPriceHistory(propertyID); // returns the returned value of GetPropertyPriceHistory function from the priceHistoryList object with propertyID as a parameter
        }

        public void SetFilterOption(bool optionValue, int optionIndex) // public SetFilterOption function that accetps a bool and a int as parameters
        {
            filterOptionsSelected[optionIndex] = optionValue; // sets the filterOptionsSelected at optionIndex parameter to the optionValue parameter
        }

        public bool[] GetFilterOptions() // public GetFilterOptions that returns a bool array
        {
            return filterOptionsSelected; // returns filterOptionsSelected
        }

        public List<Property> ApplyFilter(Dictionary<string, string> filterInputs, List<int> selectedAmenities) // public ApplyFilter function that returns a List of Property objects and accepts a string dictionary, and a list of ints
        {
            return allPropertyList.GetFilteredPropertyList(propertyAmenities.GetAllPropertyAmenities(), filterInputs, selectedAmenities, filterOptionsSelected); // returns the returned value of GetFilteredPropertyList of the allPropertyList object with the returned value from the GetAllPropertyAmenities function from the propertyAmenities object, filertInputs, selectedAmenites, and filterOptionsSelected as parameters
        }

        public List<PropertyStatus> GetAllActivePropertySatuses() // public GetAllActivePropertyStatuses function that returns a List of PropertyStatus object
        {
            return propertyStatusList.GetAllActivePropertySatuses(); // returns the returned value from the GetAllActivePropertyStatuses function from the propertyStatusList object
        }

        public List<Property> GetAllActiveProperties(List<PropertyStatus> allActiveStatusProperties) // public GetAllActiveProperties function that returns a List of Property objects and accepts a List of PropertyStatus objects
        {
            return allPropertyList.GetAllActiveProperties(allActiveStatusProperties); // returns the returned value from the GetAllActiveProperties function from the allPropertyList object with the allActiveStatusProperties as a parameter
        }

        public List<PropertyType> GetAllPropertyTypes() // public GetAllPropertyTypes function that returns a List of PropertyType objects
        {
            return allPropertyTypes.GetPropertyTypes(); // returns the returned value from the GetPropertyTypes function from the allPropertyTypes object 
        }


    }
}
