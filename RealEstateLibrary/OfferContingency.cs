using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateLibrary;

namespace RealEstateLibrary
{
    public class OfferContingency
    {
        private int contingencyID; // private int variable called contingencyID
        private int offerID; // private int variable called offerID
        private string contingency; // private string variable called contingency

        public int ContingencyID // public int variable called ContingencyID
        {
            get { return contingencyID; } // returns the value of contingencyID variable
            set { contingencyID = value; } // sets the value of contingencyID variable to whatever is passed to it
        }

        public int OfferID // public int variable called OfferID
        {
            get { return offerID; } // returns the value of offerID variable
            set { offerID = value; } // sets the value of offerID variable to whatever is passed to it
        }

        public string Contingency // public string variable called Contingency
        {
            get { return contingency; } // returns the value of contingency variable
            set { contingency = value; } // sets the value of contingency variable to whatever is passed to it
        }

        public OfferContingency(int contingencyID, int offerID, string contingency) // public OfferContingency initalizer that accepts two ints and string parameter
        {
            ContingencyID = contingencyID; // sets ContingencyID variable to the contingencyID parameter
            OfferID = offerID; // sets OfferID variable to the offerID parameter
            Contingency = contingency; // sets Contingency variable to the contingency parameter
        }

        public OfferContingency(string contingency) // public OfferContingency initalizer that accepts a string parameter
        { 
            Contingency = contingency; // sets Contingency variable to the contingency parameter
        }
    }
}
