using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RealEstateLibrary;

namespace FLOHR_ProjectThree
{
    public partial class frmLogin : System.Web.UI.Page
    {
        private AccountLoginController loginHandler; // private AccountLoginController object called loginHandler
        private Dictionary<string, string> newAccountInfo = new Dictionary<string, string>(); // private string dictionary called newAccountInfo set to a new string Dictionary
        private Validate validater = new Validate(); // private Validate object called validater set to a new Validate object
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (Session["LoginHandler"] == null) // if the Session key LoginHandler is null then
            {
                loginHandler = new AccountLoginController(); // sets logingHandler to a new AccountLoginController object
                Session["LoginHandler"] = loginHandler; // sets the Session key LoginHandler to the loginHandler object
            }
            else // else the session key loginhandler was not null
            {
                loginHandler = (AccountLoginController)Session["LoginHandler"]; // sets the loginHandler object to the Session Key LoginHandler value converted to a AccountLoginController object
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e) // Button btnLogin Click event handler
        {
            loginHandler.AccountLogin(txtUsername.Text, txtPassword.Text); // calls the AccountLogin function from the loginHandler object with txtUsername and txtPassword textboxes text as parameters

            if (loginHandler.IsLoginValid() == false) // if the returned value from IsLoginValid from loginHandler object is false then
            {
                lblLoginError.Text = "Login Error: Please check your account username and password! <br/>If you don't have an account please register one using the creat account button!"; // sets lblLoginError labels text to say check your username/password or create an account
            }
            else // else the function returned true
            {
                HttpCookie accountIDCookie = new HttpCookie("Account", loginHandler.GetCurrentLoggedInAccount().AccountID.ToString()); // HttpCookie object called accountIDCookie set to a new HttpCookie called Account with the returned values AccountID converted to a string from GetCurrentLoggedInAccount function from the loginHandler object
                Response.Cookies.Add(accountIDCookie); // Adds a new cookie to the page response with the accountIDCookie as a parameter
                Response.Redirect("frmAgentDashboard.aspx"); // Calls the Redirect function from the Response object with the agentdashboard aspx page as the parameter
            }
        }
        private void HideLoginArea() // private HideLoginArea function
        {
            loginContent.Visible = false; // sets loginContent to not be visible
        }

        private void ShowLoginArea() // private ShowLoginArea function
        {
            loginContent.Visible = true; // sets loginContent to be visible
        }

        private void ShowCreateAccountArea() // private ShowCreateAccountArea function
        {
            newAccountArea.Visible = true; // sets newAccountArea to be visible
        }

        private void HideNewAccountArea() // private HideNewAccountArea function
        {
            newAccountArea.Visible = false; // sets newAccountArea to not be visible
        }

        protected void btnNoAccount_Click(object sender, EventArgs e) // Button btnNoAccount click event handler
        {
            HideLoginArea(); // calls the HideLoginArea function
            ShowCreateAccountArea(); // calls the ShowCreateAccountArea function
        }

        protected void btnCreateNewAccount_Click(object sender, EventArgs e) // Button btnCreateNewAccount click event handler
        {
            ResetNewAccountErrorMessage(); // calls the ResetNewAccountErrorMessage function
            if (ValidateNewAccount() == true) // if the returned value from ValidateNewAccount function is true then
            {
                newAccountInfo = new Dictionary<string, string>(); // sets newAccountInfo dictionary to a new string dictionary
                newAccountInfo["Username"] = txtNewAccUsername.Text; // sets newAccountInfos Username key to the value of txtNewAccountUsername textboxs text
                newAccountInfo["Password"] = txtNewAccPassword.Text; // sets newAccountInfos Password key to the value of txtNewAccPassword textboxs text
                newAccountInfo["Firstname"] = txtNewAccFirstName.Text; // sets newAccountInfos Firstname key to the value of txtNewAccFirstName textboxs text
                newAccountInfo["Lastname"] = txtNewAccLastName.Text; // sets newAccountInfos Lastname key to the value of txtNewAccLastName textboxs text
                newAccountInfo["PeronsalPhone"] = txtNewAccPhoneNumber.Text; // sets newAccountInfos PeronsalPhone key to the value of txtNewAccPhoneNumber textboxs text
                newAccountInfo["PeronsalEmail"] = txtNewAccEmail.Text; // sets newAccountInfos PeronsalEmail key to the value of txtNewAccEmail textboxs text
                newAccountInfo["PeronsalZip"] = txtNewAccZipCode.Text; // sets newAccountInfos PeronsalZip key to the value of txtNewAccZipCode textboxs text
                newAccountInfo["PersonalState"] = drplNewAccState.SelectedValue.ToString(); // sets newAccountInfos PersonalState key to the value of drplNewAccState DropList's selected value converted to a string
                newAccountInfo["PeronsalCity"] = txtNewAccCity.Text; // sets newAccountInfos PeronsalCity key to the value of txtNewAccCity textboxs text
                newAccountInfo["PeronsalAddress"] = txtNewAccStreetAddress.Text; // sets newAccountInfos PeronsalAddress key to the value of txtNewAccStreetAddress textboxs text
                newAccountInfo["WorkZip"] = txtNewAccWorkZipCode.Text; // sets newAccountInfos WorkZip key to the value of txtNewAccWorkZipCode textboxs text
                newAccountInfo["WorkState"] = drplNewAccWorkState.SelectedValue.ToString(); // sets newAccountInfos WorkState key to the value of drplNewAccWorkState DropList's selected value converted to a string
                newAccountInfo["WorkCity"] = txtNewAccWorkCity.Text; // sets newAccountInfos WorkCity key to the value of txtNewAccWorkCity textboxs text
                newAccountInfo["WorkAddress"] = txtNewAccWorkStreetAddress.Text; // sets newAccountInfos WorkAddress key to the value of txtNewAccWorkStreetAddress textboxs text
                newAccountInfo["WorkPhone"] = txtNewAccWorkPhone.Text; // sets newAccountInfos WorkPhone key to the value of txtNewAccWorkPhone textboxs text
                newAccountInfo["WorkEmail"] = txtNewAccWorkEmail.Text; // sets newAccountInfos WorkEmail key to the value of txtNewAccWorkEmail textboxs text
                newAccountInfo["WorkName"] = txtNewAccWorkName.Text; // sets newAccountInfos WorkName key to the value of txtNewAccWorkName textboxs text
                loginHandler.MakeNewAccount(newAccountInfo); // calls the MakeNewAccount function from the loginHandler object with newAccountInfo as a parameter
                loginHandler.ResetAllAccounts(); // calls the ResetAllAccounts fnction from the loginHandler object
                HideNewAccountArea(); // calls the HideNewAccountArea function
                ShowLoginArea(); // calls the ShowLoginArea function
                ResetNewAccount(); // calls the ResetNewAccountFunction
            }

        }

        private void ResetNewAccount() // private ResetNewAccount function
        {
            txtNewAccUsername.Text = ""; // sets txtNewAccUsername textboxs text to a empty string
            txtNewAccPassword.Text = ""; // sets txtNewAccPassword textboxs text to a empty string
            txtNewAccFirstName.Text = ""; // sets txtNewAccFirstName textboxs text to a empty string
            txtNewAccLastName.Text = ""; // sets txtNewAccLastName textboxs text to a empty string
            txtNewAccPhoneNumber.Text = ""; // sets txtNewAccPhoneNumber textboxs text to a empty string
            txtNewAccEmail.Text = ""; // sets txtNewAccEmail textboxs text to a empty string
            txtNewAccZipCode.Text = ""; // sets txtNewAccZipCode textboxs text to a empty string
            drplNewAccState.SelectedIndex = 0; // sets drplNewAccState droplists selectedindex to 0
            txtNewAccCity.Text = ""; // sets txtNewAccCity textboxs text to a empty string
            txtNewAccStreetAddress.Text = ""; // sets txtNewAccStreetAddress textboxs text to a empty string
            txtNewAccWorkZipCode.Text = ""; // sets txtNewAccWorkZipCode textboxs text to a empty string
            drplNewAccWorkState.SelectedIndex = 0; // sets drplNewAccWorkState droplists selectedindex to 0
            txtNewAccWorkCity.Text = ""; // sets txtNewAccWorkCity textboxs text to a empty string
            txtNewAccWorkStreetAddress.Text = ""; // sets txtNewAccWorkStreetAddress textboxs text to a empty string
            txtNewAccWorkPhone.Text = "";// sets txtNewAccWorkPhone textboxs text to a empty string
            txtNewAccWorkEmail.Text = ""; // sets txtNewAccWorkEmail textboxs text to a empty string
            txtNewAccWorkName.Text = ""; // sets txtNewAccWorkName textboxs text to a empty string
        }

        protected void btnReturnToLogin_Click(object sender, EventArgs e) // Button btnReturnToLogin click event handler
        {
            HideNewAccountArea(); // calls HideNewAccountArea function
            ShowLoginArea(); // calls ShowLoginArea function
            ResetNewAccount(); // calls ResetNewAccount function
        }

        private bool ValidateNewAccount() // private ValidateNewAccount function that returns a bool
        {
            bool isAccountValid = true; // bool variable called isAccountValid set to true

            if (validater.ValidateString(txtNewAccUsername.Text) == false) // if the returned value from the ValidateString function from the validater object with the txtNewAccUnsername textboxs text as a parameter is equal to false then
            {
                isAccountValid = false; // sets isAccountValid to false
                lblNewAccountError.Text += "Error - Username Is Missing - Please enter a username! <br/>"; // sets lblNewAccountError labels text to itself plus an error message about the username and a new line
            }

            if (validater.ValidateString(txtNewAccPassword.Text) == false) // if the returned value from the ValidateString function from the validater object with the txtNewAccPassword textboxs text as a parameter is equal to false then
            {
                isAccountValid = false; // sets isAccountValid to false
                lblNewAccountError.Text += "Error - Password Is Missing - Please enter a password! <br/>"; // sets lblNewAccountError labels text to itself plus an error message about the Password and a new line
            }

            if (validater.ValidateString(txtNewAccFirstName.Text) == false) // if the returned value from the ValidateString function from the validater object with the txtNewAccFirstName textboxs text as a parameter is equal to false then
            {
                isAccountValid = false; // sets isAccountValid to false
                lblNewAccountError.Text += "Error - First Name Is Missing - Please enter a first name! <br/>"; // sets lblNewAccountError labels text to itself plus an error message about the First name and a new line
            }

            if (validater.ValidateString(txtNewAccLastName.Text) == false) // if the returned value from the ValidateString function from the validater object with the txtNewAccLastName textboxs text as a parameter is equal to false then
            {
                isAccountValid = false; // sets isAccountValid to false
                lblNewAccountError.Text += "Error - Last Name Is Missing - Please enter a last name! <br/>"; // sets lblNewAccountError labels text to itself plus an error message about the last name and a new line
            }
             
            if (validater.ValidateString(txtNewAccCity.Text) == false) // if the returned value from the ValidateString function from the validater object with the txtNewAccCity textboxs text as a parameter is equal to false then
            {
                isAccountValid = false; // sets isAccountValid to false
                lblNewAccountError.Text += "Error - Personal Address City Is Missing - Please enter a city! <br/>"; // sets lblNewAccountError labels text to itself plus an error message about the personal address city and a new line
            }

            if (validater.ValidateString(txtNewAccStreetAddress.Text) == false) // if the returned value from the ValidateString function from the validater object with the txtNewAccStreetAddress textboxs text as a parameter is equal to false then
            {
                isAccountValid = false; // sets isAccountValid to false
                lblNewAccountError.Text += "Error - Peronsal Address Street Is Missing - Please enter a street! <br/>"; // sets lblNewAccountError labels text to itself plus an error message about the personal address and a new line
            }

            if (validater.ValidateInt(txtNewAccZipCode.Text) == false) // if the returned value from the ValidateInt function from the validater object with the txtNewAccZipCode textboxs text as a parameter is equal to false then
            {
                isAccountValid = false; // sets isAccountValid to false
                lblNewAccountError.Text += "Error - Personal Zip Code Is Missing Or Invalid - Please enter a valid zip code! <br/>"; // sets lblNewAccountError labels text to itself plus an error message about the personal address zipcode and a new line
            }

            if (validater.ValidateString(txtNewAccEmail.Text) == false) // if the returned value from the ValidateString function from the validater object with the txtNewAccEmail textboxs text as a parameter is equal to false then
            {
                isAccountValid = false; // sets isAccountValid to false
                lblNewAccountError.Text += "Error - Personal Email Is Missing - Please enter a email! <br/>"; // sets lblNewAccountError labels text to itself plus an error message about the personal email address and a new line
            }

            if (validater.ValidatePhoneNumber(txtNewAccPhoneNumber.Text) == false) // if the returned value from the ValidatePhoneNumber function from the validater object with the txtNewAccPhoneNumber textboxs text as a parameter is equal to false then
            {
                isAccountValid = false; // sets isAccountValid to false
                lblNewAccountError.Text += "Error - Peronsal Phone Number Is Missing Or Invalid - Please enter a valid phone number! <br/>"; // sets lblNewAccountError labels text to itself plus an error message about the personal phone number and a new line
            }

            if (validater.ValidateString(txtNewAccWorkName.Text) == false) // if the returned value from the ValidateString function from the validater object with the txtNewAccWorkName textboxs text as a parameter is equal to false then
            {
                isAccountValid = false; // sets isAccountValid to false
                lblNewAccountError.Text += "Error - Company Name Is Missing - Please enter a company name! <br/>"; // sets lblNewAccountError labels text to itself plus an error message about the company name and a new line
            }

            if (validater.ValidateString(txtNewAccWorkCity.Text) == false) // if the returned value from the ValidateString function from the validater object with the txtNewAccWorkCity textboxs text as a parameter is equal to false then
            {
                isAccountValid = false; // sets isAccountValid to false
                lblNewAccountError.Text  += "Error - Company Address City Is Missing - Please enter a company address city! <br/>"; // sets lblNewAccountError labels text to itself plus an error message about the work address city and a new line
            }

            if (validater.ValidateString(txtNewAccWorkEmail.Text) == false) // if the returned value from the ValidateString function from the validater object with the txtNewAccWorkEmail textboxs text as a parameter is equal to false then
            {
                isAccountValid = false; // sets isAccountValid to false
                lblNewAccountError.Text += "Error - Company Email Address Is Missing - Please enter a company email address! <br/>"; // sets lblNewAccountError labels text to itself plus an error message about the work email and a new line
            }

            if (validater.ValidateString(txtNewAccWorkStreetAddress.Text) == false) // if the returned value from the ValidateString function from the validater object with the txtNewAccWorkStreetAddress textboxs text as a parameter is equal to false then
            {
                isAccountValid = false; // sets isAccountValid to false
                lblNewAccountError.Text += "Error - Comapny Address Street Is Missing - Please enter a company street address! <br/>"; // sets lblNewAccountError labels text to itself plus an error message about the work address and a new line
            }

            if (validater.ValidatePhoneNumber(txtNewAccWorkPhone.Text) == false) // if the returned value from the ValidatePhoneNumber function from the validater object with the txtNewAccWorkPhone textboxs text as a parameter is equal to false then
            {
                isAccountValid = false; // sets isAccountValid to false
                lblNewAccountError.Text += "Error - Company Phone Number Is Missing Or Invalid - Please enter a valid company phone number! <br/>"; // sets lblNewAccountError labels text to itself plus an error message about the work phone number and a new line
            }

            if (validater.ValidateInt(txtNewAccWorkZipCode.Text) == false) // if the returned value from the ValidateInt function from the validater object with the txtNewAccWorkZipCode textboxs text as a parameter is equal to false then
            {
                isAccountValid = false; // sets isAccountValid to false
                lblNewAccountError.Text += "Error - Company Zip Code Is Missing Or Invalid - Please enter a valid company zip code! <br/>"; // sets lblNewAccountError labels text to itself plus an error message about the work address zipcode and a new line
            }

            return isAccountValid; // returns isAccountValid
        }

        private void ResetNewAccountErrorMessage() // private ResetNewAccountErrorMessage function
        {
            lblNewAccountError.Text = ""; // sets lblNewAccountError labels text to an empty string
        }
    }
}