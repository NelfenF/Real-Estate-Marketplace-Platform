<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="FLOHR_ProjectThree.frmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FLOHR - Login - Project 3</title>
    <link rel="stylesheet" href="style/loginStyle.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
</head>
<body>


    <nav class="navbar navbar-expand-lg fixed-top bg-primary" data-bs-theme="dark" id="navMain">
        <div class="container-fluid">
            <a class="navbar-brand" href="../index.html">
                <img src="images/clogo.png" alt="Logo" width="30" height="24" class="d-inline-block align-text-top" />
                CIS 3342 Projects
            </a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav">
                    <li class="nav-item">
                        <a class="nav-link" href="../index.html">Home</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="../Project1/quizIndex.html">Project One</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="../Project2/frmCoffeeShop.aspx">Project Two</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link active" href="frmDashboard.aspx">Project Three</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">Project Four</a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>


    <form id="form1" runat="server">
        <div id="mainContent">

            <div id="loginContent" runat="server" class="container my-4">
                <asp:Label ID="lblLoginError" runat="server" CssClass="text-danger"></asp:Label>
                <div class="row">
                    <div class="col-md-6">
                        <asp:Label ID="lblUsername" runat="server" CssClass="form-label" Text="Username: "></asp:Label>
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="lblPassword" runat="server" CssClass="form-label" Text="Password: "></asp:Label>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <div class="col-12 mt-3">
                    <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary w-100" Text="Login" OnClick="btnLogin_Click" />
                </div>
                <div class="col-12 text-center mt-3">
                    <asp:Label ID="lblNoAccount" runat="server" CssClass="form-text" Text="If you don't have an account, please create one by clicking the button below."></asp:Label>
                </div>
                <div class="col-12 mt-2">
                    <asp:Button ID="btnNoAccount" runat="server" CssClass="btn btn-secondary w-100" Text="Create New Account" OnClick="btnNoAccount_Click" />
                </div>
            </div>

            <div id="newAccountArea" runat="server" visible="false" class="container my-4">

                <h3 class="mb-3">Personal Information</h3>
                <asp:Label ID="lblNewAccountError" runat="server" CssClass="label-warning"></asp:Label>
                <div class="row mb-3">
                    <div class="col-md-6">
                        <asp:Label ID="lblNewAccUsername" runat="server" Text="Username: " CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtNewAccUsername" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="lblNewAccPassword" runat="server" Text="Password: " CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtNewAccPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    </div>
                </div>

                <div class="row mb-3">
                    <div class="col-md-6">
                        <asp:Label ID="lblNewAccFirstName" runat="server" Text="First Name: " CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtNewAccFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="lblNewAccLastName" runat="server" Text="Last Name: " CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtNewAccLastName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="row mb-3">
                    <div class="col-md-6">
                        <asp:Label ID="lblNewAccPhoneNumber" runat="server" Text="Phone Number:" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtNewAccPhoneNumber" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="lblNewAccEmail" runat="server" Text="Email: " CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtNewAccEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                    </div>
                </div>

                <div class="row mb-3">
                    <div class="col-md-6">
                        <asp:Label ID="lblNewAccStreetAddress" runat="server" Text="Street Address: " CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtNewAccStreetAddress" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="lblNewAccCity" runat="server" Text="City: " CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtNewAccCity" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="lblNewAccState" runat="server" Text="State: " CssClass="form-label"></asp:Label>
                        <asp:DropDownList ID="drplNewAccState" runat="server" CssClass="form-select">
                            <asp:ListItem>Alabama</asp:ListItem>
                            <asp:ListItem>Alaska</asp:ListItem>
                            <asp:ListItem>Arizona</asp:ListItem>
                            <asp:ListItem>Arkansas</asp:ListItem>
                            <asp:ListItem>California</asp:ListItem>
                            <asp:ListItem>Colorado</asp:ListItem>
                            <asp:ListItem>Connecticut</asp:ListItem>
                            <asp:ListItem>Delaware</asp:ListItem>
                            <asp:ListItem>Florida</asp:ListItem>
                            <asp:ListItem>Georgia</asp:ListItem>
                            <asp:ListItem>Hawaii</asp:ListItem>
                            <asp:ListItem>Idaho</asp:ListItem>
                            <asp:ListItem>Illinois</asp:ListItem>
                            <asp:ListItem>Indiana</asp:ListItem>
                            <asp:ListItem>Iowa</asp:ListItem>
                            <asp:ListItem>Kansas</asp:ListItem>
                            <asp:ListItem>Kentucky</asp:ListItem>
                            <asp:ListItem>Louisiana</asp:ListItem>
                            <asp:ListItem>Maine</asp:ListItem>
                            <asp:ListItem>Maryland</asp:ListItem>
                            <asp:ListItem>Massachusetts</asp:ListItem>
                            <asp:ListItem>Michigan</asp:ListItem>
                            <asp:ListItem>Minnesota</asp:ListItem>
                            <asp:ListItem>Mississippi</asp:ListItem>
                            <asp:ListItem>Missouri</asp:ListItem>
                            <asp:ListItem>Montana</asp:ListItem>
                            <asp:ListItem>Nebraska</asp:ListItem>
                            <asp:ListItem>Nevada</asp:ListItem>
                            <asp:ListItem>New Hampshire</asp:ListItem>
                            <asp:ListItem>New Jersey</asp:ListItem>
                            <asp:ListItem>New Mexico</asp:ListItem>
                            <asp:ListItem>New York</asp:ListItem>
                            <asp:ListItem>North Carolina</asp:ListItem>
                            <asp:ListItem>North Dakota</asp:ListItem>
                            <asp:ListItem>Ohio</asp:ListItem>
                            <asp:ListItem>Oklahoma</asp:ListItem>
                            <asp:ListItem>Oregon</asp:ListItem>
                            <asp:ListItem>Pennsylvania</asp:ListItem>
                            <asp:ListItem>Rhode Island</asp:ListItem>
                            <asp:ListItem>South Carolina</asp:ListItem>
                            <asp:ListItem>South Dakota</asp:ListItem>
                            <asp:ListItem>Tennessee</asp:ListItem>
                            <asp:ListItem>Texas</asp:ListItem>
                            <asp:ListItem>Utah</asp:ListItem>
                            <asp:ListItem>Vermont</asp:ListItem>
                            <asp:ListItem>Virginia</asp:ListItem>
                            <asp:ListItem>Washington</asp:ListItem>
                            <asp:ListItem>West Virginia</asp:ListItem>
                            <asp:ListItem>Wisconsin</asp:ListItem>
                            <asp:ListItem>Wyoming</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="row mb-3">
                    <div class="col-md-6">
                        <asp:Label ID="lblNewAccZipCode" runat="server" Text="Zip Code: " CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtNewAccZipCode" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <h3 class="mt-4 mb-3">Work Information</h3>

                <div class="row mb-3">
                    <div class="col-md-6">
                        <asp:Label ID="lblNewAccWorkName" runat="server" Text="Company Name: " CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtNewAccWorkName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="lblNewAccWorkPhone" runat="server" Text="Company Phone Number: " CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtNewAccWorkPhone" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="row mb-3">
                    <div class="col-md-6">
                        <asp:Label ID="lblNewAccWorkEmail" runat="server" Text="Company Email: " CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtNewAccWorkEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="lblNewAccWorkStreetAddress" runat="server" Text="Company Address: " CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtNewAccWorkStreetAddress" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="row mb-3">
                    <div class="col-md-6">
                        <asp:Label ID="lblNewAccWorkCity" runat="server" Text="Company City: " CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtNewAccWorkCity" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="lblNewAccWorkState" runat="server" Text="Company State: " CssClass="form-label"></asp:Label>
                        <asp:DropDownList ID="drplNewAccWorkState" runat="server" CssClass="form-select">
                            <asp:ListItem>Alabama</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="lblNewAccWorkZipCode" runat="server" Text="Company Zip Code" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtNewAccWorkZipCode" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="row mb-3">
                    <asp:Button ID="btnCreateNewAccount" runat="server" Text="Create Account" CssClass="btn btn-primary mt-3" OnClick="btnCreateNewAccount_Click" />
                    <asp:Button ID="btnReturnToLogin" runat="server" Text="Return To Login" CssClass="btn btn-secondary mt-3" OnClick="btnReturnToLogin_Click" />
                </div>
            </div>

        </div>
    </form>

    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

    <footer class="bg-primary bottom py-3" id="footerBar" data-bs-theme="dark">
        <div class="container text-center">
            <p>&copy; 2024 Nathan Flohr. All Rights Reserved.</p>
        </div>
    </footer>


    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>
