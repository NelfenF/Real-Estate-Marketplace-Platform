<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="frmDashboard.aspx.cs" Inherits="FLOHR_ProjectThree.frmAgentDashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Flohr - Main Dashboard - Project 3</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <link rel="stylesheet" href="style/mainDashboardStyle.css" />
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
                        <a class="nav-link active" href="frmCoffeeShop.aspx">Project Two</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">Project Three</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">Project Four</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">Project Five</a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>


    <form id="form1" runat="server">

        <div class="container-fluid" id="main" runat="server">
            <div class="row">
                <!-- Sidebar Section for Filters -->
                <div class="col-md-3 col-lg-2 sidebar bg-light p-3" id="sideBar">
                    <asp:Button ID="btnAgentDashboard" runat="server" Text="Agent Dashboard" OnClick="btnAgentDashboard_Click" CssClass="btn btn-primary w-100 mb-4" />

                    <h5 class="mb-3">Filter Options</h5>
                    <asp:Label ID="lblFilterOptionError" runat="server" CssClass="text-waring"></asp:Label>
                    <div class="filter-group mb-3">
                        <asp:Label ID="lblFilterCity" runat="server" Text="City" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtFilterCity" runat="server" CssClass="form-control mb-3"></asp:TextBox>

                        <asp:Label ID="lblFilterState" runat="server" Text="State" CssClass="form-label"></asp:Label>
                        <asp:DropDownList ID="drplFilterState" runat="server" CssClass="form-select mb-3">
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

                        <asp:Label ID="lblFilterPropertyType" runat="server" Text="Property Type" CssClass="form-label"></asp:Label>
                        <asp:RadioButtonList ID="radlFilterPropertyType" runat="server" CssClass="form-select mb-3" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:RadioButtonList>

                        <asp:Label ID="lblFilterPriceRange" runat="server" Text="Price Range" CssClass="form-label"></asp:Label>
                        <div class="input-group mb-3">
                            <span class="input-group-text">$</span>
                            <asp:TextBox ID="txtFilterMinPrice" runat="server" CssClass="form-control" placeholder="Min"></asp:TextBox>
                            <span class="input-group-text">-</span>
                            <asp:TextBox ID="txtFilterMaxPrice" runat="server" CssClass="form-control" placeholder="Max"></asp:TextBox>
                        </div>

                        <asp:Label ID="lblFilterPropertySize" runat="server" Text="Property Size (sqft)" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtFilterSize" runat="server" CssClass="form-control mb-3" placeholder="Size"></asp:TextBox>

                        <asp:Label ID="lblFilterMinBedroom" runat="server" Text="Minimum Bedrooms" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtFilterMinBedroom" runat="server" CssClass="form-control mb-3" placeholder="Bedrooms"></asp:TextBox>

                        <asp:Label ID="lblFilterMinBathroom" runat="server" Text="Minimum Bathrooms" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtFilterMinBathroom" runat="server" CssClass="form-control mb-3" placeholder="Bathrooms"></asp:TextBox>

                        <asp:Label ID="lblFilterAmenities" runat="server" Text="Amenities" CssClass="form-label"></asp:Label>
                        <asp:CheckBoxList ID="chklFilterAmenities" runat="server" CssClass="form-check" CellSpacing="2" RepeatDirection="Horizontal" RepeatLayout="Flow" CellPadding="2">
                        </asp:CheckBoxList>
                    </div>

                    <asp:Button ID="btnApplyFitler" runat="server" Text="Apply Filter" CssClass="btn btn-secondary w-100 mb-2" OnClick="btnApplyFitler_Click" />
                    <asp:Button ID="btnClearFilter" runat="server" Text="Clear Filter" CssClass="btn btn-secondary w-100 mb-2" OnClick="btnClearFilter_Click" />
                </div>


                <div class="col-md-9 col-lg-10 p-4" id="listingContent" runat="server">
                    <asp:ListView ID="lstvDashboardListing" runat="server" ItemPlaceholderID="plhldListing" OnItemCommand="lstvDashboardListing_ItemCommand" OnItemDataBound="lstvDashboardListing_ItemDataBound">

                        <LayoutTemplate>
                            <div id="listing" class="container">
                                <div class="row">
                                    <asp:PlaceHolder ID="plhldListing" runat="server"></asp:PlaceHolder>
                                </div>
                            </div>
                        </LayoutTemplate>

                        <ItemTemplate>
                            <div class="col-md-4 mb-4">
                                <div class="card">
                                    <asp:Image ID="lblListingImage" runat="server" />

                                    <div class="card-body">
                                        <h5 class="card-title">
                                            <asp:Label ID="lblListingAddress" runat="server"></asp:Label>
                                        </h5>
                                        <p class="card-text">
                                            <asp:Label ID="lblListingPropertyType" runat="server"></asp:Label><br />
                                            <asp:Label ID="lblListingSqFt" runat="server"></asp:Label><br />
                                            <asp:Label ID="lblListingBedrooms" runat="server"></asp:Label><br />
                                            <asp:Label ID="lblListingBathrooms" runat="server"></asp:Label><br />
                                            <asp:Label ID="lblListingAskingPrice" runat="server"></asp:Label><br />
                                            <asp:Label ID="lblListingDaysOnMarket" runat="server"></asp:Label>
                                        </p>
                                        <div class="container-flex justify-content-between">
                                            <asp:Button ID="btnViewListing" runat="server" CssClass="btn btn-primary btn-sm me-2" Text="View All Details" CommandName="viewListing" />
                                            <asp:Button ID="btnRequestShowing" runat="server" CssClass="btn btn-primary btn-sm me-2" Text="Request Showing" CommandName="requestShowing" />
                                            <asp:Button ID="btnMakeOffer" runat="server" CssClass="btn btn-primary btn-sm me-2" Text="Make Offer" CommandName="makeOffer" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>

                        <EmptyDataTemplate>
                            <asp:Label ID="lblNoAgentListings" runat="server" CssClass="text-center" Text="No Listings Found. Please change your filter inputs!" />
                        </EmptyDataTemplate>

                    </asp:ListView>

                    <div id="singleListing" runat="server">
                        <asp:ListView ID="lstvSingleListing" runat="server" ItemPlaceholderID="plhldLSingleListing" OnItemCommand="lstvSingleListing_ItemCommand" OnItemDataBound="lstvSingleListing_ItemDataBound">

                            <LayoutTemplate>
                                <div id="listing" class="container">
                                    <div class="row">
                                        <asp:PlaceHolder ID="plhldLSingleListing" runat="server"></asp:PlaceHolder>
                                    </div>
                                </div>
                            </LayoutTemplate>

                            <ItemTemplate>

                                <div class="row mb-4">
                                    <div id="carousel<%# Eval("PropertyID") %>" class="carousel slide" data-bs-ride="carousel">
                                        <div class="carousel-inner">
                                            <asp:ListView ID="lstvSingleListingImages" runat="server">
                                                <ItemTemplate>

                                                    <div class="carousel-item <%# Container.DisplayIndex == 0 ? "active" : "" %>">
                                                        <asp:Image ID="imgListingImage" runat="server" ImageUrl='<%# Eval("ImageURL") %>' CssClass="d-block w-100" Height="500" />
                                                    </div>

                                                </ItemTemplate>
                                            </asp:ListView>
                                        </div>
                                        <!-- Carousel controls -->
                                        <button class="carousel-control-prev" type="button" data-bs-target="#carousel<%# Eval("PropertyID") %>" data-bs-slide="prev">
                                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                            <span class="visually-hidden">Previous</span>
                                        </button>
                                        <button class="carousel-control-next" type="button" data-bs-target="#carousel<%# Eval("PropertyID") %>" data-bs-slide="next">
                                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                            <span class="visually-hidden">Next</span>
                                        </button>
                                    </div>
                                </div>

                                <div class="row mb-3">

                                    <div class="d-flex flex-column">
                                        <span class="fw-bold">
                                            <asp:Label ID="lblSingleListingAgentCompany" runat="server" ></asp:Label>
                                        </span>
                                        <span class="fw-bold">
                                            <asp:Label ID="lblSingleListingAgentName" runat="server" ></asp:Label>
                                        </span>
                                        <span class="text-muted">
                                            <asp:Label ID="lblSingleListingAgentEmail" runat="server" ></asp:Label>
                                        </span>
                                    </div>


                                </div>

                                <div class="row mb-3">
                                    <div class="col-12">
                                        <h3>
                                            <asp:Label ID="lblSingleListingAddress" runat="server" ></asp:Label>
                                        </h3>
                                        <p class="mb-1">
                                            <strong>Asking Price:</strong>
                                            <asp:Label ID="lblSingleListingAskingPrice" runat="server" ></asp:Label>
                                        </p>
                                        <p class="mb-1">
                                            <strong>Year Built:</strong>
                                            <asp:Label ID="lblSingleListingYearBuilt" runat="server" ></asp:Label>
                                        </p>
                                        <p class="mb-1">
                                            <strong>Total Square Feet:</strong>
                                            <asp:Label ID="lblSingleListingSqFt" runat="server" ></asp:Label>
                                        </p>
                                        <p class="mb-1">
                                            <strong>Bedrooms:</strong>
                                            <asp:Label ID="lblSingleListingBedrooms" runat="server" ></asp:Label>
                                        </p>
                                        <p class="mb-1">
                                            <strong>Bathrooms:</strong>
                                            <asp:Label ID="lblSingleListingBathrooms" runat="server" ></asp:Label>
                                        </p>
                                        <p class="mb-1">
                                            <strong>Garage:</strong>
                                            <asp:Label ID="lblSingleListingGarage" runat="server" ></asp:Label>
                                        </p>
                                        <p class="mb-1">
                                            <strong>Heating System:</strong>
                                            <asp:Label ID="lblSingleListingHeatingSystem" runat="server" ></asp:Label>
                                        </p>
                                        <p class="mb-1">
                                            <strong>Cooling System:</strong>
                                            <asp:Label ID="lblSingleListingCoolingSystem" runat="server" ></asp:Label>
                                        </p>
                                        <p class="mb-1">
                                            <strong>Water Utilities:</strong>
                                            <asp:Label ID="lblSingleListingWater" runat="server" ></asp:Label>
                                        </p>
                                        <p class="mb-1">
                                            <strong>Sewer Utilities:</strong>
                                            <asp:Label ID="lblSingleListingSewer" runat="server"></asp:Label>
                                        </p>
                                        <p class="mb-1">
                                            <strong>Listed on:</strong>
                                            <asp:Label ID="lblSingleListingListingDate" runat="server" ></asp:Label>
                                        </p>
                                        <p class="mb-1">
                                            <strong>Days on market:</strong>
                                            <asp:Label ID="lblSingleListingTotalMarketDays" runat="server" ></asp:Label>
                                        </p>
                                    </div>
                                </div>

                                <!-- Property Description -->
                                <div class="row mb-4">
                                    <div class="col-12">
                                        <h4>Property Description</h4>
                                        <p>
                                            <asp:Label ID="lblSingleListingDescription" runat="server" ></asp:Label>
                                        </p>
                                    </div>
                                </div>

                                <div class="row mb-4">
                                    <div class="col-12">
                                        <h4>Property Amenities</h4>
                                        <p>
                                            <asp:ListView ID="lstvSingleListingAmenities" runat="server">
                                                <ItemTemplate>
                                                    <span class="badge bg-primary me-2">
                                                        <asp:Label ID="lblSingleListingAmenity" runat="server" Text='<%# Eval("AmenityName") %>'></asp:Label>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:ListView>
                                        </p>
                                    </div>
                                </div>

                                <!-- Rooms Information -->
                                <div class="row mb-4">
                                    <div class="col-12">
                                        <h4>Rooms Information</h4>
                                        <asp:GridView ID="gvSingleListingRooms" runat="server" CssClass="table table-striped" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:BoundField DataField="RoomType" HeaderText="Room Type" />
                                                <asp:BoundField DataField="RoomLength" HeaderText="Room Length" />
                                                <asp:BoundField DataField="RoomWidth" HeaderText="Room Width" />
                                                <asp:BoundField DataField="TotalSqFt" HeaderText="Total Sq Ft" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>

                                <div class="row mb-4">
                                    <div class="col-12">
                                        <h4>PriceHistory</h4>
                                        <asp:Chart ID="crtPriceHistoryChart" runat="server" ImageStorageMode="UseHttpHandler" CssClass="chart">
                                            <Series>
                                                <asp:Series Name="PriceHistory"></asp:Series>
                                            </Series>
                                            <ChartAreas>
                                                <asp:ChartArea Name="PriceHistoryChart">
                                                </asp:ChartArea>
                                            </ChartAreas>
                                        </asp:Chart>
                                    </div>
                                </div>


                                <div class="row mb-4">
                                    <div class="col-12 d-flex gap-2">
                                        <asp:Button ID="btnSingleListingRequestShowing" runat="server" CssClass="btn btn-primary" Text="Request Showing" CommandName="requestShowing" />
                                        <asp:Button ID="btnSingleListingMakeOffer" runat="server" CssClass="btn btn-success" Text="Make Offer" CommandName="makeOffer"  />
                                        <asp:Button ID="btnSingleListingReturnToAllListing" runat="server" CssClass="btn btn-secondary" Text="Return To All Listings" CommandName="return" />
                                    </div>
                                </div>
                            </ItemTemplate>

                        </asp:ListView>



                    </div>

                    <!-- Bootstrap-styled Showing Request Section -->
                    <div id="requestShowingArea" runat="server" visible="false" class="container my-4">
                        <asp:Label ID="lblShowingRequestError" runat="server" CssClass="label-warning"></asp:Label>
                        <div class="row">
                            <div class="col-md-6 mb-3">
                                <asp:Label ID="lblShowingFirstName" runat="server" Text="First Name" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtShowingFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-6 mb-3">
                                <asp:Label ID="lblShowingLastName" runat="server" Text="Last Name" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtShowingLastName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 mb-3">
                                <asp:Label ID="lblShowingEmailAddress" runat="server" Text="Email Address" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtShowingEmailAddress" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-6 mb-3">
                                <asp:Label ID="lblShowingPhoneNumber" runat="server" Text="Phone Number" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtShowingPhoneNumber" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 mb-3">
                                <asp:Label ID="lblShowingDate" runat="server" Text="Best Date For Showing" CssClass="form-label"></asp:Label>

                                <asp:Calendar ID="calShowingDate" runat="server" CssClass="calendar"></asp:Calendar>

                            </div>
                            <div class="col-md-6 mb-3">
                                <asp:Label ID="lblShowingTime" runat="server" Text="Best Time For Showing" CssClass="form-label"></asp:Label>
                                <div class="input-group">
                                    <asp:TextBox ID="txtShowingTime" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:DropDownList ID="drplAmPm" runat="server" CssClass="form-select">
                                        <asp:ListItem>AM</asp:ListItem>
                                        <asp:ListItem>PM</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="d-flex justify-content-end">
                            <asp:Button ID="btnConfirmShowing" Text="Schedule Showing" runat="server" CssClass="btn btn-primary me-2" OnClick="btnConfirmShowing_Click" />
                            <asp:Button ID="btnCancelShowing" Text="Cancel" runat="server" CssClass="btn btn-secondary" OnClick="btnCancelShowing_Click" />
                        </div>
                    </div>


                    <div id="makeOfferArea" runat="server" visible="false" class="container my-4">
                        <asp:Label ID="lblOfferAreaError" runat="server" CssClass="label-warning"></asp:Label>
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <asp:Label ID="lblOfferFirstName" runat="server" Text="First Name" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtOfferFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="lblOfferLastName" runat="server" Text="Last Name" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtOfferLastName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-6">
                                <asp:Label ID="lblOfferEmail" runat="server" Text="Email Address" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtOfferEmail" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="lblOfferPhone" runat="server" Text="Phone Number" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtOfferPhone" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-6">
                                <asp:Label ID="lblOfferAmount" runat="server" Text="Offer Amount" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtOfferAmount" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="lblOfferType" runat="server" Text="Offer Type" CssClass="form-label"></asp:Label>
                                <asp:DropDownList ID="drplOfferType" runat="server" CssClass="form-select" AutoPostBack="True" OnSelectedIndexChanged="drplOfferType_SelectedIndexChanged">
                                    <asp:ListItem>Conventional Mortgage</asp:ListItem>
                                    <asp:ListItem>Cash</asp:ListItem>
                                    <asp:ListItem>As-Is</asp:ListItem>
                                    <asp:ListItem>As-Is With Contingencies</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="row mb-3" id="contingencySection">
                            <div class="col-12">
                                <asp:Label ID="lblContingencyInput" runat="server" Visible="false" CssClass="form-label" Text="Enter Contingency"></asp:Label>
                                <asp:TextBox ID="txtOfferContingency" runat="server" Visible="false" CssClass="form-control mb-2"></asp:TextBox>
                                <asp:Button ID="btnAddContingency" runat="server" Visilbe="false" Text="Add Contingency To Offer" CssClass="btn btn-primary" OnClick="btnAddContingency_Click" Visible="False" />
                                <asp:GridView ID="gvOfferContingencies" runat="server" AutoGenerateColumns="False" CssClass="table mt-3" OnRowDeleting="gvOfferContingencies_RowDeleting">
                                    <Columns>
                                        <asp:BoundField DataField="Contingency" HeaderText="Contingency" />
                                        <asp:CommandField ButtonType="Button" HeaderText="Remove Contingency" ShowDeleteButton="True" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-6">
                                <asp:Label ID="lblOfferSellHouse" runat="server" Text="Are you selling your current home?" CssClass="form-label"></asp:Label>
                                <asp:RadioButtonList ID="radlOfferSellHouse" runat="server" CssClass="form-check">
                                    <asp:ListItem CssClass="form-check-label">Yes</asp:ListItem>
                                    <asp:ListItem CssClass="form-check-label">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="lblOfferMoveInDate" runat="server" Text="Move-In By" CssClass="form-label"></asp:Label>

                                <asp:Calendar ID="calOfferMoveIn" runat="server"></asp:Calendar>

                            </div>
                        </div>

                        <div class="d-flex justify-content-end mt-4">
                            <asp:Button ID="btnOfferSubmit" runat="server" Text="Submit Offer" CssClass="btn btn-success me-2" OnClick="btnOfferSubmit_Click" />
                            <asp:Button ID="btnOfferCancel" runat="server" Text="Cancel Offer" CssClass="btn btn-secondary" OnClick="btnOfferCancel_Click" />
                        </div>
                    </div>



                </div>



            </div>


        </div>

        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>


    </form>



    <footer class="bg-primary bottom py-3" id="footerBar" data-bs-theme="dark">
        <div class="container text-center">
            <p>&copy; 2024 Nathan Flohr. All Rights Reserved.</p>
        </div>
    </footer>
</body>
</html>
