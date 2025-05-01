using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using RealEstateLibrary;

namespace RealEstateLibrary
{
    public class AgentDashboardController
    {
        private Account currentLoggedInAccount; // private Account object called currentLoggedInAccount
        private Emailer emailer; // private Emailer object called emailer
        private AmenityList allAmenities = new AmenityList(); // private AmenityList object called allAmenitites set to a new AmenityList object
        private HeatingSystemList allHeatingSystems = new HeatingSystemList(); // private HeatingSystemList object called allHeatingSystems set to a new HeatingSystemList object
        private CoolingSystemList allCoolingSystems = new CoolingSystemList(); // private CoolingSystemList object called allCoolingSystems set to a new CoolingSystemList object
        private WaterUtilityList allWaterUtilites = new WaterUtilityList(); // private WaterUtilityList object called allWaterUtilites set to a new WaterUtilityList object
        private SewerUtilityList allSewerUtilites = new SewerUtilityList(); // private SewerUtilityList object called allSewerUtilites set to a new SewerUtilityList object
        private StatusesList allStatuses = new StatusesList(); // private StatusesList object called allStatuses set to a new StatusesList object
        private PropertyTypeList allPropertyTypes = new PropertyTypeList(); // private PropertyTypeList object called allPropertyTypes set to a new PropertyTypeList object
        private AccountList allAccountsList = new AccountList(); // private AccountList object called allAccountsList set to a new AccountList object
        private PropertyList allPropertyList = new PropertyList(); // private PropertyList object called allPropertyList set to a new PropertyList object
        private PropertyRoomList allRoomsList = new PropertyRoomList(); // private PropertyRoomList object called allRoomsList set to a new PropertyRoomList object
        private PropertyImageList allPropertyImages = new PropertyImageList(); // private PropertyImageList object called allPropertyImages set to a new PropertyImageList object
        private PropertyStatusList allPropertyStatuses = new PropertyStatusList(); // private PropertyStatusList object called allPropertyStatuses set to a new PropertyStatusList object
        private PropertyAmenityList allPropertyAmenitiesList = new PropertyAmenityList(); // private PropertyAmenityList object called allPropertyAmenitiesList set to a new PropertyAmenityList object
        private PropertyPriceHistoryList allPropertyPriceHistory = new PropertyPriceHistoryList(); // private PropertyPriceHistoryList object called allPropertyPriceHistory set to a new PropertyPriceHistoryList object
        private PropertyShowingRequestList agentShowingRequest = new PropertyShowingRequestList(); // private PropertyShowingRequestList object called agentShowingRequest set to a new PropertyShowingRequestList object
        private PropertyOfferList agentOfferList = new PropertyOfferList(); // private PropertyOfferList object called agentOfferList set to a new PropertyOfferList object
        private PropertyOfferStatusList agentOfferStatusList = new PropertyOfferStatusList(); // private PropertyOfferStatusList object called agentOfferStatusList set to a new PropertyOfferStatusList object
        private OfferContingencyList offerContingencyList = new OfferContingencyList(); // private OfferContingencyList object called offerContingencyList set to a new OfferContingencyList object
        private Property newProperty;  // private Property object called newProperty set to a new Property object
        private List<HttpPostedFile> newPropertyUploadedImages = new List<HttpPostedFile>(); // private List of HttpPostedFile object called newPropertyUploadedImages set to a new List of HttpPostedFile
        private List<string> newPropertyUploadedImagesCaptions = new List<string>(); // private List of string variables called newPropertyUploadedImageCaptions set to a new list of strings
        private List<PropertyRoom> newPropertyRooms = new List<PropertyRoom>(); // private List of PropertyRoom objects called newPropertyRooms set to a new list of PropertyRoom objects
        private RoomTypeList allRoomTypes = new RoomTypeList(); // private RoomTypeList object called allRoomTypes set to a new RoomTypeList object
        private int currentPropertyView = 0; // private int called currentPropertyView set to 0
        private List<int> roomsToRemove = new List<int>(); // private List of ints object called roomsToRemove set to a new list of ints
        private List<int> imagesToRemove = new List<int>(); // private List of ints object called imagesToRemove set to a new list of ints
        private decimal currentAskingPrice = 0; // private deciaml called currentAskingPrice set to 0

        public AgentDashboardController() // public AgentDashboardController initalizer function
        {
            // used to have stuff start on new controller start but moved it out
        }

        public void SetCurrentPropertyView(int propertyID) // public SetCurrentPropertyView function that accepts a int parameter
        {
            currentPropertyView = propertyID; // sets currentPropertyView to the passed parameters value
        }

        public int GetCurrentPropertyView() // public GetCurrentPropertyView function that returns a int 
        {
            return currentPropertyView; // returns the curreentPropertyView variable
        }

        public void AddRoomToBeRemoved(int roomId) // public AddRoomToBeRemoved function that accepts a int parameter
        {
            roomsToRemove.Add(roomId); // adds the passed parameters value to the roomsToRemove int list
        }

        public void ResetRoomsToBeRemoved() // public ResetRoomsToBeRemoved function
        {
            roomsToRemove = new List<int>(); // sets roomsToRemove to a new List of ints
        }

        public List<int> GetRoomsToBeRemoved() // public GetRoomsToBeRemoved function that returns a List of ints object
        {
            return roomsToRemove; // returns the roomsToRemove List object
        }

        public void AddImageToBeRemoved(int imageId) // public AddImageToBeRemoved function that accepts a int parameter
        {
            imagesToRemove.Add(imageId); // adds the passed parameters value to the imagesToRemove int list
        }

        public void ResetImagesToBeRemoved() // public ResetImagesToBeRemoved function
        {
            imagesToRemove = new List<int>(); // sets imagesToRemove to a new List of ints
        }

        public List<int> GetImagesToBeRemoved() // public GetImagesToBeRemoved function that returns a List of ints object
        {
            return imagesToRemove; // returns imagesToRemove list object
        }

        public void SetCurrentAskingPrice(decimal askingPrice) // public SetCurrentAskingPrice function that accepts a decimal parameter
        { 
            currentAskingPrice = askingPrice; // sets currentAskingPrice to the passed parameters value
        }

        public decimal GetCurrentAskingPrice() // public GetCurrentAskingPrice function that returns a decimal variable
        {
            return currentAskingPrice; // returns currentAskingPrice variable
        }

        public List<Amenity> GetAmenititesList() // public GetAmenititesList function that returns a List of Amenity object
        {
            allAmenities = new AmenityList(); // sets allAmmenities to a new AmenityList object
            return allAmenities.GetAllAmenities(); // returns the returned value from the GetAllAmenities function from the allAmenities object
        }

        public List<CoolingSystem> GetCoolingSystems() // public GetCoolingSystems function that returns a List of CoolingSystem object
        {
            return allCoolingSystems.GetCoolingSystems(); // returns the returned value from the GetCoolingSystems function from the allCoolingSystems object
        }

        public List<HeatingSystem> GetHeatingSystems() // public GetHeatingSystems function that returns a List of HeatingSystem object
        {
            return allHeatingSystems.GetHeatingSystems(); // returns the returned value from the GetHeatingSystems function from the allHeatingSystems object
        }

        public List<WaterUtility> GetWaterUtilites() // public GetWaterUtilites function that returns a List of WaterUtility object
        {
            return allWaterUtilites.GetWaterUtilities(); // returns the returned value from the GetWaterUtilities function from the allWaterUtilites object
        }

        public List<SewerUtility> GetSewerUtilities() // public GetSewerUtilities function that returns a List of SewerUtility object
        {
            return allSewerUtilites.GetAllSewerUtilites(); // returns the returned value from the GetAllSewerUtilites function from the allSewerUtilites object
        }

        public List<Statuses> GetStatuses() // public GetStatuses function that returns a List of Statuses object
        {
            return allStatuses.GetAllStatuses(); // returns the returned value from the GetAllStatuses function from the allStatuses object
        }

        public List<PropertyType> GetPropertyTypes() // public GetPropertyTypes function that returns a List of PropertyType object
        {
            return allPropertyTypes.GetPropertyTypes(); // returns the returned value from the GetPropertyTypes function from the allPropertyTypes object
        }

        public List<RoomType> GetAllRoomTypes() // public GetAllRoomTypes function that returns a List of RoomType object
        {
            return allRoomTypes.GetAllRoomTypes(); // returns the returned value from the GetAllRoomTypes function from the allRoomTypes object
        }

        public void SetAgentAccount(int id) // public SetAgentAccount function that accepts a int parameter
        {
            currentLoggedInAccount = allAccountsList.GetAccountByAccountID(id); // sets currentLoggedInAccount to the returned value of the GetAccountByAccountID function with the id as a parameter from the allAccountList object
            currentLoggedInAccount.AccountUsername = ""; // sets currentLoggedInAccount objects AccountUsername to a empty string
            currentLoggedInAccount.AccountPassword = ""; // sets currentLoggedInAccount objects AccountPassword to a empty string
        }

        public Account GetCurrentLoggedInAccount() // public GetCurrentLoggedInAccount function that returns a account object
        {
            return currentLoggedInAccount; // returns the currentLoggedInAccount object
        }

        public int GetCurrentLoggedInAccountID() // public GetCurrentLoggedInAccountID function that returns a int variable
        {
            return currentLoggedInAccount.AccountID; // returns the currentLoggedInAccount objects AccountID
        }

        public void AddNewPropertyStatus(int propertyID, string status) // public AddNewPropertyStatus function that accepts a int and string parameter
        {
            allPropertyStatuses.AddNewPropertyStatus(propertyID, status); // calls the AddNewPropertyStatus function of the allPropertyStatuses object with the propertyID and status as parameters
        }

        public PropertyStatus GetPropertyStatusByPropertyID(int propertyID) // public GetPropertyStatusByPropertyID function that returns a PropertyStatus object and accepts a int parameter
        {
            allPropertyStatuses = new PropertyStatusList(propertyID); // sets allPropertyStatuses to a new PropertyStatusList object with propertyID as a parameter
            return allPropertyStatuses.GetPropertyStatusByPropertyID(propertyID); // returns the returned value of GetPropertyStatusByPropertyID function from the allPropertyStatuses object with the propertyID as a parameter
        }

        public void UpdatePropertyStatus(int propertyID, string newStatus) // public UpdatePropertyStatus function that accepts a int and string parameter
        {
            allPropertyStatuses.UpdatePropertyStatus(propertyID, newStatus); // calls the UpadatePropertyStatus function of the allPropertyStatuses object with propertyID and newStatus as parameters
        }

        public void ResetNewPropertyRooms() // public ResetNewPropertyRooms function
        {
            newPropertyRooms = new List<PropertyRoom>(); // sets newPropertyRooms to a new List of propertyRoom objects
        }
        public void AddNewPropertyRoom(string type, string length, string width) // public AddNewPropertyRoom function that accepts a three string parameters
        {
            newPropertyRooms.Add(new PropertyRoom(type, length, width)); // Adds a new PropertyRoom object with type, length, width as PropertyRoom parameters to the newPropertyRooms list object
        }

        public void RemoveNewPropertyRoom(int index) // public RemoveNewPropertyRoom function that accepts a int parameter
        {
            newPropertyRooms.RemoveAt(index); // Removes a PropertyRoom object from the newPropertyRooms list object at the passed parameters index
        }

        public List<PropertyRoom> GetNewPropertyRooms() // public GetNewPropertyRooms function that returns a List of PropertyRoom objects
        {
            return newPropertyRooms; // returns the newPropertyRooms list object
        }

        public int GetNumberOfBedrooms() // public GetNumberOfBedrooms function that returns a int
        {
            return allRoomsList.GetNumberOfBedrooms(newPropertyRooms); // returns the returned value from the GetNumberOfBedrooms function from the allRoomsList object with newPropertyRooms as a parameter
        }

        public decimal GetNumberOfBathrooms() // public GetNumberOfBathrooms function that returns a decimal
        {
            return allRoomsList.GetNumberOfBathrooms(newPropertyRooms); // returns the returned value from the GetNumberOfBathrooms function from the allRoomsList object with newPropertyRooms as a parameter
        }

        public decimal GetAllNewRoomTotalSqFt() // public GetAllNewRoomTotalSqFt function that returns a decimal
        {
            return allRoomsList.GetTotalRoomSqFt(newPropertyRooms); // returns the returned value from the GetTotalRoomSqFt function from the allRoomsList object with newPropertyRooms as a parameter
        }

        public void FinalizeNewRooms(int propID) // public FinalizeNewRooms function that accepts a int parameter
        {
            allRoomsList.AddNewRoomToProperty(propID, newPropertyRooms); // calls the AddNewroomToProperty function of the allRoomsList object with propID and newPropertyRooms as parameters
        }

        public void MakeNewProperty(Dictionary<string,string> propertyInfo) // public MakeNewProperty function that accepts a string dictionary
        {
            newProperty = new Property(propertyInfo, GetAllNewRoomTotalSqFt()); // sets newProperty to a new Property object with propertyInfo and the returned value of GetAllNewRoomTotalSqFt function as parameters
        }

        public void AddNewProperty() // public AddNewProperty function
        {
            allPropertyList = new PropertyList(); // sets allPropertyList to a new PropertyList object
            allPropertyList.AddNewProperty(newProperty); // calls the AddNewProperty function of the allPropertyList object with newProperty as an object
        }

        public Property GetPropertyByStreetAddressAndZipCode(string address, int zip) // public GetPropertyByStreetAddressAndZipCode function that accepts a string and int parameter
        {
            allPropertyList = new PropertyList(); // sets allPropertyList to a new PropertyList object
            return allPropertyList.GetPropertyByStreetAddressAndZipCode(address,zip); // returns the returned value of the GetPropertyByStreetAddressAndZipCode function from the allPropertyList object with address and zip as parameters
        }

        public void ResetNewPropertyImages() // public ResetNewPropertyImages function
        {
            newPropertyUploadedImages = new List<HttpPostedFile>(); // sets newPropertyUploadedImages to a new List of HttpPostedFile objects
            newPropertyUploadedImagesCaptions = new List<string>(); // sets newPropertyUploadedImagesCaptions to a new List of string variables
        }

        public void AddNewImage(HttpPostedFile image) // public AddNewImage function that accetps a HttpPostedFile object parameter
        {
            newPropertyUploadedImages.Add(image); // adds the image object parameter to the newPropertyUploadedImages list object
        }

        public void AddNewImageCaption(string caption) // public AddNewImageCaption function that accepts a string parameter
        {
            newPropertyUploadedImagesCaptions.Add(caption); // adds the caption parameter to the newPropertyUploadedImagesCaptions list object
        }

        public void RemoveNewImage(int index) // public RemoveNewImage function that accepts a int parameter
        {
            newPropertyUploadedImages.RemoveAt(index); // removes the HttpPostedFile from the newPropertyUploadedImages at the index parameter
        }

        public void RemoveImageCaption(int index) // public RemoveImageCaption function that accepts a int parameter
        {
            newPropertyUploadedImagesCaptions.RemoveAt(index); // removes the string from the newPropertyUploadedImagesCaptions at the index parameter
        }

        public List<HttpPostedFile> GetNewPropertyImageFiles() // public GetNewPropertyImageFiles function that returns a List of HttpPostedFile objects
        {
            return newPropertyUploadedImages; // returns newPropertyUploadedImages list object
        }

        public void AddNewImagesToProperty(int propertyID) // public AddNewImagesToProperty function that accepts a int parameter
        {
            allPropertyImages.AddNewImagesToProperty(propertyID, newPropertyUploadedImages, newPropertyUploadedImagesCaptions); // calls the AddNewImagesToProperty function of the allPropertyImages object with propertyID, newPropertyUploadedImages, newPropertyUploadedImagesCaptions as parameters
        }

        public void AddNewImagesToProperty(int propertyID, int existingCountImages, List<PropertyImage> propertyImages) // public AddNewImagesToProperty function that accepts two ints and a List of PropertyImage object as parameter
        {
            allPropertyImages.AddNewImagesToProperty(propertyID, newPropertyUploadedImages, newPropertyUploadedImagesCaptions, existingCountImages,propertyImages); // calls the AddNewImagesToProperty function of the allPropertyImages object with propertyID, newPropertyUploadedImages, newPropertyUploadedImagesCaptions, existingCountImages, and propertyImages as parameters
        }

        public List<Property> GetAgentPropertyListings() // public GetAgentPropertyListings function that returns a List of property objects
        {
            allPropertyList = new PropertyList(currentLoggedInAccount.AccountID); // sets allPropertyList to a new PropertyList object with the currentLoggedInAccount objects accountID as a parameter
            return allPropertyList.GetAllProperties(); // returns the returned value of the GetAllProperties function from the allPropertyList object
        }

        public void RemoveAgentListing(int propertyID) // public RemoveAgentListing function that accetpts a int variable
        {
            List<int> imageIdsToRemove = new List<int>(); // List of int object called imageIdsToRemove set to a new List of int objects
            foreach (PropertyImage listingImage in allPropertyImages.GetPropertyImages(propertyID)) // foreach PropertyImage object called listingImage in the returned value from the GetPropertyImages function from the allpropertyImages object with the propertyID as a parameter do
            {
                imageIdsToRemove.Add(listingImage.ImageID); // adds the current listingImage objects imageId to the imageIdsToRemove list object
            }
            allPropertyImages.RemovePropertyImages(imageIdsToRemove); // calls the RemovePropertyImages function from the allPropertyImages object with imageIdsToRemove as a parameter
            allPropertyList.RemoveProperty(propertyID); // calls the RemoveProperty function from the allPropertyList object with propertyId as a parameter
        }

        public void UpdateAgentListing(int propertyID, Dictionary<string, string> updatedInfo) // public UpdateAgentListing function that accepts a int, string dictionary as parameters
        {
            allPropertyList.UpdateProperty(propertyID, updatedInfo, GetPropertyTotalSqFt(propertyID)); // calls the UpdateProperty function of the allPropertyList object with propertyID, updatedInfo, and the retuedn value of GetPropertyTotalSqFt function with propertyID as a parameter as parameters
        }

        private void StartAllPropertyListing() // private StartAllPropertyListing function
        {
            allPropertyList = new PropertyList(); // sets allPropertyList to a new PropertyList obejct
        }

        public List<Property> GetAllPropertyListing() // public GetAllPropertyListings function that returns a list of Property objects
        {
            StartAllPropertyListing(); // calls the StartAllPropertyListing function
            return allPropertyList.GetAllProperties(); // returns the returned value from the GetAllProperties function from the allPropertyList object
        }

        public Property GetPropertyByPropertyID(int id) // public GetPropertyByPropertyID function that accepts a int and returns a Property object
        {
            StartAllPropertyListing(); // calls the StartAllPropertyListing function
            return allPropertyList.GetPropertyByPropertyID(id); // returns the returned value from the GetPropertyByPropertyID function from the allPropertyList object with id as a parameter
        }

        private decimal GetPropertyTotalSqFt(int propertyID) // private GetPropertyTotalSqFt function that returns a decimal and accepts a propertyID
        {
            allRoomsList = new PropertyRoomList(propertyID); // sets allRoomsList to a new PropertyRoomList object with propertyID as a parameter
            return allRoomsList.GetAllRoomsTotalSqFt(); // returns the returned value of GetAllRoomsTotalSqFt function from the allRoomsList object
        }

        public List<PropertyRoom> GetRoomListByPropertyID(int propertyID) // public GetRoomListByPropertyID function that accepts a int parameter and returns a List of PropertyRoom objects
        {
            allRoomsList = new PropertyRoomList(propertyID); // sets allRoomsList to a new PropertyRoomList object with propertyID as a parameter
            return allRoomsList.GetRoomList(); // returns the returned value of GetRoomList function from the allRoomsList object
        }

        public void RemoveSingleRoom(List<int> roomID) // public RemoveSingleRoom function that accepts a List of int as parameter
        {
            allRoomsList.RemoveSingleRoom(roomID); // calls the RemoveSingleRoom function from the allRoomsList object with roomID as a parameter
        }

        public int GetNumberOfBedrooms(List<PropertyRoom> propertyRooms) // public GetNumberOfBedrooms function that returns a int and accepts a List of PropertyRoom objects
        {
            return allRoomsList.GetNumberOfBedrooms(propertyRooms); // returns the returned value of GetNumberOfBedrooms function from the allRoomsList object with propertyRooms as a parameter
        }

        public decimal GetNumberOfBathrooms(List<PropertyRoom> propertyRooms) // public GetNumberOfBathrooms function that returns a decimal and accepts a List of PropertyRoom objects
        {
            return allRoomsList.GetNumberOfBathrooms(propertyRooms); // returns the returned value of GetNumberOfBathrooms function from the allRoomsList object with propertyRooms as a parameter
        }

        public List<PropertyImage> GetPropertyImages(int propertyID) // public GetPropertyImages function that returns a List of PropertyImage objects and accepts a int as a parameter
        {
            return allPropertyImages.GetPropertyImages(propertyID); // returns the returned value of GetPropertyImages function from the allPropertyImages obejct with propertyID as a parameter
        }

        public List<PropertyImage> GetOnePropertyImage(int propertyID) // public GetOnePropertyImage function that returns a List of PropertyImage objects and accepts a int as a parameter
        {
            return allPropertyImages.GetPropertyImages(propertyID); // returns the returned value of GetPropertyImages function from the allPropertyImages obejct with propertyID as a parameter
        }

        public void RemovePropertyImages(List<int> ids) // public RemovePropertyImages function that accepts a List of ints as a parameter
        {
            allPropertyImages.RemovePropertyImages(ids); // calls the RemovePropertyImages function from the allPropertyImages object with ids as a parameter
        }

        public List<PropertyShowingRequest> GetAgentShowingRequest(List<Property> agentProperty) // public GetAgentShowingRequest function that returns a List of PropertyShowingRequest obejcts and accpets a List of property obejcts
        {
            agentShowingRequest = new PropertyShowingRequestList(); // sets agentShowingRequest to a new PropertyShwoingRequestList object
            return agentShowingRequest.GetAgentShowingRequests(agentProperty); // returns the returned value of GetAgentShowingRequests function frmo the agentShowingRequest object with agentProperty as a parameter
        }

        public List<PropertyOffer> GetAgentPropertyOffers(List<Property> agentProperty) // public GetAgentPropertyOffers function that returns a List of PropertyOffer obejcts and accpets a List of property obejcts
        {
            agentOfferList = new PropertyOfferList(); // sets agentOfferList to a new PropertyOfferList object
            return agentOfferList.GetAgentPropertyOffer(agentProperty); // returns the returned value of GetAgentPropertyOffer function frmo the agentOfferList object with agentProperty as a parameter
        }

        public PropertyOffer GetPropertyOfferByOfferID(int ID) // public GetPropertyOfferByOfferID function that returns a PropertyOffer obejct and accepts a int parameter 
        {
            return agentOfferList.GetPropertyOfferByOfferID(ID);   // returns the returned value of GetPropertyOfferByOfferID function frmo the agentOfferList object with ID as a parameter
        }

        public void UpdatePropertyOfferStatus(int offerID, string newStatus) // public UpdatePropertyOfferStatus function that accepts a int and string as parameters
        {
            agentOfferStatusList.UpdatePropertyOfferStatus(offerID, newStatus); // calls the UpdatePropertyOfferStatus function from the agentOfferStatusList object with offerID and newSatus as parameters
        }

        public void SendEmail(string to, string from, string subject, string body) // public SendEmail function that accepts four string parameters
        {
            emailer = new Emailer(to, from, subject, body); // sets emailer to a new Emailer object with to, from, subject, and body as parameters
        }

        public void AddNewPropertyAmenities(List<int> amenititesID, int propertyID) // public AddNewPropertyAmenities function that accepts a int and List of ints as parameters
        {
            allPropertyAmenitiesList.AddNewPropertyAmenities(amenititesID, propertyID); // calls the AddNewPropertyAmenities function from the allPropertyAmenitiesList object with amenitiesID and propertyID as parameters
        }

        public List<PropertyAmenity> GetSinglePropertyAmenities (int propertyID) // public GetSinglePropertyAmenitites function that accepts a int as a parameter
        {
            allPropertyAmenitiesList = new PropertyAmenityList(); // sets allPropertyAmenitiesList to a new PropertyAmenitiyList object
            return allPropertyAmenitiesList.GetSinglePropertyAmenityList(propertyID); // returns the returned value of GetSinglePropertyAmenityList function from the allPropertyAmenitiesList object with propertyID as a parameter
        }

        public void UpdatePropertyAmenities(int propertyID, List<int> newAmenities) // public UpdatePropertyAmenities function that accepts a int and list of ints as parameters
        {
            allPropertyAmenitiesList.UpdatePropertyAmenities(propertyID, newAmenities); // calls the UpdatePropertyAmenities function from the allPropertyAmenitiesList object with propertyId and newAmenities as parameters
        }

        public void AddNewPriceHistory(int propertyID, decimal newPrice) // public AddNewPriceHistory function that accepts a int and decimal
        {
            allPropertyPriceHistory.AddNewPropertyPriceHistory(propertyID, newPrice); // calls the AddNewPropertyPriceHistory function from the allPropertyPriceHistory object with propertyID and newPrice as parameters
        }

        public void RemovePropertyOffers(int propertyID) // public RemovePropertyOffers function that accepts a int
        {
            foreach (PropertyOffer offer in agentOfferList.GetAllPropertyOffers()) // foreach PropertyOffer object called offer in the returned value from the GetAllPropertyOffers function form the agentOfferList obejct do 
            {
                if (offer.PropertyID == propertyID) // if the current offer objects PropertyID is equal too the passed propertyID then
                {
                    offerContingencyList.RemoveOfferContingencies(offer.OfferID); // calls the RemoveOfferContingencies function from the offerContingecyList object with the current offer objects offerID
                    agentOfferStatusList.RemovePropertyOfferStatus(offer.OfferID);  // calls the RemovePropertyOfferStatus function from the agentOfferStatusList object with the current offer objects offerID
                }
            }
            agentOfferList.RemovePropertyOffer(propertyID); // calls the RemovePropertyOffer function from the agentOfferList object with propertyID as a parameter
        }

        public void RemovePropertyShowings(int propertyID) // public RemovePropertyShowings function that accepts a int
        {
            agentShowingRequest.RemoveShowingRequest(propertyID); // calls the RemoveShowingRequest function from the agentShowingRequest object with propertyId as a parameter
        }

        public List<OfferContingency> GetOfferContingencies() // public GetOfferContingencies function that returns a List of OfferContingecy objects
        {
            offerContingencyList = new OfferContingencyList(); // sets offerContingencyList to a new OfferContingecyList object
            return offerContingencyList.GetOfferContingencies(); // returns the returned value of GetOfferContingencies function from the offerContingecnyList object
        }

        public List<PropertyOfferStatus> GetAllOfferStatuses() // public GetAllOfferStatuses function that returns a List of PropertyOfferStatus objects
        {
            agentOfferStatusList = new PropertyOfferStatusList(); // sets agentOfferStatusList to a new PropertyOfferStatusList object
            return agentOfferStatusList.GetAllPropertyOffersStatuses(); // returns the returned value of GetAllPropertyOffersStatuses function from the agentOfferStatusList object
        }
    }
}
