<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="FrmAgentDashboard.aspx.cs" Inherits="FLOHR_ProjectThree.frmMainDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <link rel="stylesheet" href="style/agentDashboardStyle.css" />
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
        <div id="mainContent">
            <div class="d-flex justify-content-between align-items-center mb-3">
                <asp:Label ID="lblUserDisplay" runat="server" CssClass="fw-bold"></asp:Label>
            </div>

            <div id="newListing" runat="server">

                <asp:Button ID="btnCreateNewListing" runat="server" CssClass="btn btn-primary mt-3 mb-3" Text="Create New Listing" OnClick="btnCreateNewListing_Click" />

                <div id="newListingFormArea" runat="server" visible="false">
                    <asp:Label ID="lblNewListingError" runat="server" CssClass="text-danger"></asp:Label>
                    <div class="col-md-4">
                        <asp:Label ID="lblPropertyStatus" runat="server" CssClass="form-label" Text="Property Listing Status"></asp:Label>
                        <asp:DropDownList ID="drplPropertyStatus" runat="server" CssClass="form-select">
                        </asp:DropDownList>
                    </div>
                    <div class="row g-3">
                        <div class="col-md-4">
                            <asp:Label ID="lblStreetAddress" runat="server" CssClass="form-label" Text="Property Street Address"></asp:Label>
                            <asp:TextBox ID="txtStreetAddress" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="lblCityAddress" runat="server" CssClass="form-label" Text="City"></asp:Label>
                            <asp:TextBox ID="txtCityAddress" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="lblStateAddress" runat="server" CssClass="form-label" Text="State"></asp:Label>
                            <asp:DropDownList ID="drplStateAddress" runat="server" CssClass="form-select">
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


                    <div class="row g-3 mt-3">
                        <div class="col-md-4">
                            <asp:Label ID="lblZipAddress" runat="server" CssClass="form-label" Text="Zip Code"></asp:Label>
                            <asp:TextBox ID="txtZipAddress" runat="server" CssClass="form-control" MaxLength="5"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="lblYearBuilt" runat="server" CssClass="form-label" Text="Year Built"></asp:Label>
                            <asp:TextBox ID="txtYearBuilt" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="lblAskingPrice" runat="server" CssClass="form-label" Text="Asking Price"></asp:Label>
                            <asp:TextBox ID="txtAskingPrice" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-12">
                        <asp:Label ID="lblDescription" runat="server" CssClass="form-label" Text="Property Description"></asp:Label>
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="row g-3 mt-3">
                        <div class="col-md-6">
                            <asp:Label ID="lblPropertyType" runat="server" CssClass="form-label" Text="Property Type"></asp:Label>
                            <asp:RadioButtonList ID="radlPropertyType" runat="server" CssClass="form-check" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            </asp:RadioButtonList>
                        </div>
                        <div class="col-md-12">
                            <asp:Label ID="lblNumberGarage" runat="server" CssClass="form-label" Text="Enter Number Garage"></asp:Label>
                            <asp:TextBox ID="txtNumberGarage" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row g-3">
                        <div class="col-md-6">
                            <asp:Label ID="lblHeatingType" runat="server" CssClass="form-label" Text="Heating Type"></asp:Label>
                            <asp:DropDownList ID="drplHeatingType" runat="server" CssClass="form-select">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-6">
                            <asp:Label ID="lblCoolingType" runat="server" CssClass="form-label" Text="Cooling Type"></asp:Label>
                            <asp:DropDownList ID="drplCoolingType" runat="server" CssClass="form-select">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row g-3 mt-3">
                        <div class="col-md-6">
                            <asp:Label ID="lblWaterUtilities" runat="server" CssClass="form-label" Text="Water Utilities"></asp:Label>
                            <asp:DropDownList ID="drplWaterUtilities" runat="server" CssClass="form-select">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-6">
                            <asp:Label ID="lblSewerUtilities" runat="server" CssClass="form-label" Text="Sewer Utilities"></asp:Label>
                            <asp:DropDownList ID="drplSewerUtilities" runat="server" CssClass="form-select">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-12">
                        <asp:Label ID="lblAmenities" runat="server" CssClass="form-label" Text="Amenities"></asp:Label>
                        <asp:CheckBoxList ID="chklAmenities" runat="server" CssClass="form-check" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        </asp:CheckBoxList>
                    </div>

                </div>
                <!-- Button Row for "Start Adding Rooms" and "Start Uploading Property Images" -->
                <div class="row">
                    <div class="col-md-6 d-flex flex-column">
                        <asp:Button ID="btnStartAddingRooms" runat="server" Visible="false" CssClass="btn btn-warning mb-3 w-100" Text="Start Adding Rooms" OnClick="btnStartAddingRooms_Click" />
                        <div id="newListingRooms" runat="server" class="mt-3" visible="false">
                            <div class="row g-3">
                                <div class="col-12">
                                    <asp:Label ID="lblRoomError" runat="server" CssClass="text-danger"></asp:Label>
                                    <asp:Label ID="lblRoomType" runat="server" CssClass="form-label" Text="Select Room Type"></asp:Label>
                                    <asp:RadioButtonList ID="radlRoomType" runat="server" CssClass="form-check" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    </asp:RadioButtonList>
                                </div>

                                <div class="col-md-6">
                                    <asp:Label ID="lblRoomLength" runat="server" CssClass="form-label" Text="Room Length"></asp:Label>
                                    <asp:TextBox ID="txtRoomLength" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="lblRoomWidth" runat="server" CssClass="form-label" Text="Room Width"></asp:Label>
                                    <asp:TextBox ID="txtRoomWidth" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                <div class="col-12 text-end">
                                    <asp:Button ID="btnAddRoom" runat="server" CssClass="btn btn-info w-100 mt-3" Text="Add Room To Property Listing" OnClick="btnAddRoom_Click" />
                                </div>
                            </div>

                            <asp:GridView ID="gvRooms" runat="server" AutoGenerateColumns="False" CssClass="table table-striped mt-3" OnRowDeleting="gvRooms_RowDeleting">
                                <Columns>
                                    <asp:BoundField DataField="RoomType" HeaderText="Room Type" />
                                    <asp:BoundField DataField="RoomLength" HeaderText="Room Length" />
                                    <asp:BoundField DataField="RoomWidth" HeaderText="Room Width" />
                                    <asp:BoundField DataField="TotalSqFt" HeaderText="Total Sq Ft" />
                                    <asp:CommandField ButtonType="Button" HeaderText="Remove Room" ShowDeleteButton="True" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>

                    <div class="col-md-6 d-flex flex-column">
                        <asp:Button ID="btnStartUploadingImages" runat="server" Visible="false" CssClass="btn btn-warning mb-3 w-100" Text="Start Uploading Property Images" OnClick="btnStartUploadingImages_Click" />
                        <div id="imageUpload" runat="server" class="mt-3" visible="false">
                            <div id="uploadArea" runat="server" visible="false" class="row g-3">
                                <asp:Label ID="lblImageError" runat="server" CssClass="text-danger"></asp:Label>
                                <div class="col-md-6">
                                    <br />
                                    <br />
                                    <asp:Label ID="lblUploadImage" runat="server" CssClass="form-label" Text="Upload Property Image"></asp:Label>
                                    <asp:FileUpload ID="fuplImgUpload" runat="server" CssClass="form-control" />
                                </div>
                                <div class="col-md-6">
                                    <br />
                                    <br />
                                    <asp:Label ID="lblImgCaption" runat="server" CssClass="form-label" Text="Image Caption"></asp:Label>
                                    <asp:TextBox ID="txtImageCaption" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-12 text-end">
                                    <asp:Button ID="btnAddImage" runat="server" CssClass="btn btn-info w-100 mt-3" Text="Add Image To Property Listing" OnClick="btnAddImage_Click" />
                                </div>
                                <asp:GridView ID="gvImages" runat="server" CssClass="table table-bordered mt-3" OnRowDeleting="gvImages_RowDeleting" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="FileName" />
                                        <asp:CommandField ButtonType="Button" HeaderText="Remove Image" ShowDeleteButton="True" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-12 d-flex justify-content-between">
                    <asp:Button ID="btnSubmitVerifyListing" runat="server" CssClass="btn btn-success w-100 mt-3 me-3 mb-2" Visible="false" Text="Submit Listing" OnClick="btnSubmitVerifyListing_Click" />
                    <asp:Button ID="btnCancelNewListing" runat="server" CssClass="btn btn-secondary w-100 mt-3 me-3 mb-2" Visible="false" Text="Cancel" OnClick="btnCancelNewListing_Click" />
                </div>


            </div>


            <div id="viewListings" runat="server">
                <asp:Button ID="btnViewListings" runat="server" CssClass="btn btn-primary mt-3 mb-3" Text="View Your Listings" OnClick="btnViewListings_Click" />
                <div id="agentListingArea" runat="server" visible="false">
                    <asp:ListView ID="lstvAgentListing" runat="server" ItemPlaceholderID="plhldAgentListing" OnItemCommand="lstvAgentListing_ItemCommand" OnItemDataBound="lstvAgentListing_ItemDataBound">

                        <LayoutTemplate>
                            <div id="listing" class="container">
                                <div class="row">
                                    <asp:PlaceHolder ID="plhldAgentListing" runat="server"></asp:PlaceHolder>
                                </div>
                            </div>
                        </LayoutTemplate>

                        <ItemTemplate>
                            <div class="col-md-4 mb-4">
                                <div class="card">
                                            <asp:Image ID="imgListingImage" runat="server" Height="300" class="card-img-top" />
                                    <div class="card-body">
                                        <h5 class="card-title">
                                            <asp:Label ID="lblListingAddress" runat="server" ></asp:Label>
                                        </h5>
                                        <p class="card-text">
                                            <asp:Label ID="lblListingSqFt" runat="server"  ></asp:Label><br />
                                            <asp:Label ID="lblListingBedrooms" runat="server"  ></asp:Label><br />
                                            <asp:Label ID="lblListingBathrooms" runat="server"  ></asp:Label><br />
                                            <asp:Label ID="lblListingAskingPrice" runat="server"  ></asp:Label>
                                        </p>
                                        <div class="d-flex justify-content-between">
                                            <asp:Button ID="btnEditListing" runat="server" CssClass="btn btn-primary" Text="View or Edit Listing" CommandName="viewEditListing" />
                                            <asp:Button ID="btnDeleteListing" runat="server" CssClass="btn btn-danger" Text="Delete Listing" CommandName="DeleteListing" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>

                        <EmptyDataTemplate>
                            <asp:Label ID="lblNoAgentListings" runat="server" CssClass="text-center" Text="No Agent Listings Found." />
                        </EmptyDataTemplate>

                    </asp:ListView>
                </div>
            </div>


            <div id="viewEditListing" runat="server" visible="false">
                <div class="d-flex justify-content-between mb-3">
                    <asp:Button ID="btnEditListing" runat="server" CssClass="btn btn-primary ms-1 me-1" OnClick="EditListing_Click" Text="Edit Listing" />
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success ms-1 me-1" OnClick="Save_Click" Text="Save Changes" />
                    <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger ms-1 me-1" OnClick="Cancel_Click" Text="Close/Cancel Listing" />
                </div>
                <div class="row g-3">
                    <div class="col-md-6">
                        <asp:Label ID="lblEditListingInfo" runat="server" CssClass="text-warning" Text="Select the edit button to start editing the listing. When finished click the save button!"></asp:Label>
                        <asp:Label ID="lblEditListingError" runat="server" CssClass="text-danger"></asp:Label>
                        <asp:Label ID="lblEditPropertyStatus" runat="server" CssClass="form-label" Text="Property Status: "></asp:Label>
                        <asp:DropDownList ID="drplEditPropertyStatus" runat="server" CssClass="form-select">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row g-3">
                    <div class="col-md-6">
                        <asp:Label ID="lblEditStreetAddress" runat="server" CssClass="form-label" Text="Street Address: "></asp:Label>
                        <asp:TextBox ID="txtEditStreetAddress" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="lblEditCity" runat="server" CssClass="form-label" Text="City: "></asp:Label>
                        <asp:TextBox ID="txtEditCity" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                    </div>
                </div>
                <div class="row g-3 mt-3">
                    <div class="col-md-4">
                        <asp:Label ID="lblEditState" runat="server" CssClass="form-label" Text="State: "></asp:Label>
                        <asp:DropDownList ID="drplEditState" runat="server" CssClass="form-select" Enabled="False">
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
                    <div class="col-md-4">
                        <asp:Label ID="lblEditZipCode" runat="server" CssClass="form-label" Text="Zip Code: "></asp:Label>
                        <asp:TextBox ID="txtEditZipCode" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="lblEditYearBuilt" runat="server" CssClass="form-label" Text="Year Built: "></asp:Label>
                        <asp:TextBox ID="txtEditYearBuilt" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                    </div>
                </div>
                <div class="col-12">
                    <asp:Label ID="lblEditDescription" runat="server" CssClass="form-label" Text="Description: "></asp:Label>
                    <asp:TextBox ID="txtEditDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Enabled="False"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="lblEditAskingPrice" runat="server" CssClass="form-label" Text="Asking Price: "></asp:Label>
                    <asp:TextBox ID="txtEditAskingPrice" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                </div>
                <div class="row g-3">
                    <div class="col-md-6">
                        <asp:Label ID="lblEditPropertyType" runat="server" CssClass="form-label" Text="Property Type: "></asp:Label>
                        <asp:RadioButtonList ID="radlEditPropertyType" runat="server" CssClass="form-check" Enabled="False" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="col-12">
                    <asp:Label ID="lblEditNumberGarage" runat="server" Text="Number Car Garage"></asp:Label>
                    <asp:TextBox ID="txtEditNumberGarage" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                </div>
                <div class="row g-3">
                    <div class="col-md-6">
                        <asp:Label ID="lblEditHeating" runat="server" CssClass="form-label" Text="Heating Type"></asp:Label>
                        <asp:DropDownList ID="drplEditHeating" runat="server" CssClass="form-select" Enabled="False">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="lblEditCooling" runat="server" CssClass="form-label" Text="Cooling Type"></asp:Label>
                        <asp:DropDownList ID="drplEditCooling" runat="server" CssClass="form-select" Enabled="False">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row g-3">
                    <div class="col-md-6">
                        <asp:Label ID="lblEditWater" runat="server" CssClass="form-label" Text="Water Utilities"></asp:Label>
                        <asp:DropDownList ID="drplEditWater" runat="server" CssClass="form-select" Enabled="False">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="lblEditSewer" runat="server" CssClass="form-label" Text="Sewer Utilities"></asp:Label>
                        <asp:DropDownList ID="drplEditSewer" runat="server" CssClass="form-select" Enabled="False">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-12">
                    <asp:Label ID="lblEditAmenities" runat="server" CssClass="form-label" Text="Amenities"></asp:Label>
                    <asp:CheckBoxList ID="chklstEditAmenities" runat="server" CssClass="form-check" Enabled="False" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    </asp:CheckBoxList>
                </div>
                <!-- GridViews Row -->
                <div class="row g-3 mt-3">
                    <asp:Label ID="lblEditListingImageRoomInfo" runat="server" CssClass="text-warning" Text="Adding a new room or image is automatically saved but deleteing a room or image is not! To save a delation make sure to hit the save button!"></asp:Label>
                    <!-- Edit Rooms GridView -->
                    <div class="col-md-6">
                        <asp:Label ID="lblEditRoomError" runat="server" CssClass="text-danger"></asp:Label>
                        <asp:GridView ID="gvEditPropertyRooms" runat="server" CssClass="custom-table mt-3" AutoGenerateColumns="False" DataKeyNames="RoomID" OnRowDeleting="gvEditPropertyRooms_RowDeleting">
                            <Columns>
                                <asp:BoundField DataField="RoomType" HeaderText="Room Type" />
                                <asp:BoundField DataField="RoomLength" HeaderText="Room Length" />
                                <asp:BoundField DataField="RoomWidth" HeaderText="Room Width" />
                                <asp:BoundField DataField="TotalSqFt" HeaderText="Total Sq Ft" />
                                <asp:CommandField ButtonType="Button" HeaderText="Remove Room" ShowDeleteButton="True" />
                            </Columns>
                        </asp:GridView>
                    </div>

                    <!-- Edit Images GridView -->
                    <div class="col-md-6">
                        <asp:Label ID="lblEditImageError" runat="server" CssClass="text-danger"></asp:Label>
                        <asp:GridView ID="gvEditPropertyImages" runat="server" CssClass="custom-table mt-3" AutoGenerateColumns="False" OnRowDeleting="gvEditPropertyImages_RowDeleting" DataKeyNames="ImageID">
                            <Columns>
                                <asp:BoundField DataField="ImageURL" HeaderText="Image Path" />
                                <asp:BoundField DataField="ImageDescription" HeaderText="Image Caption" />
                                <asp:CommandField ButtonType="Button" HeaderText="Remove Image" ShowDeleteButton="True" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>

                <!-- Buttons for starting to add new rooms and images -->
                <div class="row mb-3">
                    <div class="col-md-6 d-flex flex-column">
                        <asp:Button ID="btnStartAddingNewRooms" runat="server" CssClass="btn btn-warning w-100 mt-3 mb-3" Text="Start Adding New Rooms" OnClick="btnStartAddingNewRooms_Click" />
                        <div id="editRoomsArea" runat="server" visible="false">
                            <asp:Label ID="lblEditNewRoomType" runat="server" CssClass="form-label" Text="Select Room Type"></asp:Label>
                            <asp:RadioButtonList ID="radlEditNewRoomType" runat="server" CssClass="form-check" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            </asp:RadioButtonList>

                            <div class="row g-3 mt-2">
                                <div class="col-md-6">
                                    <asp:Label ID="lblEditRoomLength" runat="server" CssClass="form-label" Text="Enter New Room Length"></asp:Label>
                                    <asp:TextBox ID="txtEditRoomLength" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="lblEditRoomWidth" runat="server" CssClass="form-label" Text="Enter New Room Width"></asp:Label>
                                    <asp:TextBox ID="txtEditRoomWidth" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-12">
                                <asp:Button ID="btnEditAddNewRoom" runat="server" CssClass="btn btn-info w-100 mt-3" Text="Add Room To Property Listing" OnClick="btnEditAddNewRoom_Click" />
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6 d-flex flex-column">
                        <asp:Button ID="btnStartAddingNewImages" runat="server" CssClass="btn btn-warning w-100 mt-3 mb-3" Text="Start Adding New Images" OnClick="btnStartAddingNewImages_Click" />
                        <div id="editImagesArea" runat="server" visible="false">
                            <div class="row g-3">
                                <div class="col-md-6">
                                    <asp:Label ID="lblEditImages" runat="server" CssClass="form-label" Text="Add New Image"></asp:Label>
                                    <asp:FileUpload ID="fluplEditImages" runat="server" CssClass="form-control" />
                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="lblEditImagesCaption" runat="server" CssClass="form-label" Text="Image Caption"></asp:Label>
                                    <asp:TextBox ID="txtEditImageCaption" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-12">
                                <asp:Button ID="btnEditAddImage" runat="server" CssClass="btn btn-info w-100 mt-3" Text="Add Image To Property Listing" OnClick="btnAddEditImage_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <div id="viewShowings" runat="server">
                <asp:Button ID="btnViewShowings" CssClass="btn btn-primary mb-3" runat="server" Text="View Your Scheduled Showings" OnClick="btnViewShowings_Click" />
                <div id="viewShowingsArea" runat="server" visible="false">
                    <asp:ListView ID="lstvAgentShowings" runat="server" ItemPlaceholderID="plhldAgentShowing" OnItemDataBound="lstvAgentShowings_ItemDataBound">
                        <LayoutTemplate>
                            <div id="showing" class="container">
                                <div class="row">
                                    <asp:PlaceHolder ID="plhldAgentShowing" runat="server"></asp:PlaceHolder>
                                </div>
                            </div>
                        </LayoutTemplate>

                        <ItemTemplate>
                            <div class="col-md-4 mb-4">
                                <div class="card">
                                    <div class="card-body">
                                        <h5 class="card-title">
                                            <asp:Label ID="lblShowingAddress" runat="server" Text=""></asp:Label>
                                        </h5>
                                        <p class="card-text">
                                            <asp:Label ID="lblShowingName" runat="server"></asp:Label><br />
                                            <asp:Label ID="lblShowingEmail" runat="server"></asp:Label><br />
                                            <asp:Label ID="lblShowingPhone" runat="server"></asp:Label><br />
                                            <asp:Label ID="lblShowingDateTime" runat="server"></asp:Label>
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>

                        <EmptyDataTemplate>
                            <asp:Label ID="lblNoAgentShowings" runat="server" CssClass="text-center" Text="No Agent Showings Found." />
                        </EmptyDataTemplate>

                    </asp:ListView>
                </div>
            </div>

            <div id="viewOffers" runat="server">
                <asp:Button ID="btnViewOffers" CssClass="btn btn-primary mb-3" runat="server" Text="View Your Pending Offers" OnClick="btnViewOffers_Click" />
                <div id="viewOffersArea" runat="server" visible="false">
                    <asp:ListView ID="lstvAgentOffers" runat="server" ItemPlaceholderID="plhldAgentOffer" OnItemCommand="lstvAgentOffers_ItemCommand" OnItemDataBound="lstvAgentOffers_ItemDataBound">
                        <LayoutTemplate>
                            <div id="offer" class="container">
                                <div class="row">
                                    <asp:PlaceHolder ID="plhldAgentOffer" runat="server"></asp:PlaceHolder>
                                </div>
                            </div>
                        </LayoutTemplate>

                        <ItemTemplate>
                            <div class="col-md-4 mb-4">
                                <div class="card">
                                    <div class="card-body">
                                        <h5 class="card-title">
                                            <asp:Label ID="lblOfferAddress" runat="server" Text=""></asp:Label>
                                        </h5>
                                        <p class="card-text">
                                            <asp:Label ID="lblOfferName" runat="server"></asp:Label><br />
                                            <asp:Label ID="lblOfferEmail" runat="server"></asp:Label><br />
                                            <asp:Label ID="lblOfferPhone" runat="server" /><br />
                                            <asp:Label ID="lblOfferType" runat="server"></asp:Label><br />
                                            <asp:Label ID="lblOfferAmount" runat="server"></asp:Label><br />
                                            <asp:Label ID="lblOfferSellHouse" runat="server"></asp:Label><br />
                                            <asp:Label ID="lblOfferMoveInDate" runat="server"></asp:Label>
                                        </p>
                                        <h7>Contingencies</h7>
                                        <asp:Label ID="lblOfferContingency" runat="server" Text=""></asp:Label>
                                        <div class="d-flex justify-content-between">
                                            <asp:Button ID="btnAcceptOffer" runat="server" CssClass="btn btn-primary" Text="Accept Offer" CommandName="acceptOffer" />
                                            <asp:Button ID="btnRejectOffer" runat="server" CssClass="btn btn-danger" Text="Reject Offer" CommandName="rejectOffer" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>

                        <EmptyDataTemplate>
                            <asp:Label ID="lblNoAgentOffers" runat="server" CssClass="text-center" Text="No Agent Offers Found." />
                        </EmptyDataTemplate>

                    </asp:ListView>
                </div>
            </div>

            <div id="extraTools">
                <asp:Button ID="btnAgentExtraTools" runat="server" Text="Extra Tools" CssClass="btn btn-primary mb-3" />
            </div>

            <div id="logout">
                <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-primary mb-3" OnClick="btnLogout_Click" />
            </div>


        </div>
    </form>

    <footer class="bg-primary bottom py-3" id="footerBar" data-bs-theme="dark">
        <div class="container text-center">
            <p>&copy; 2024 Nathan Flohr. All Rights Reserved.</p>
        </div>
    </footer>


    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>
