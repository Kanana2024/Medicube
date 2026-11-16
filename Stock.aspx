<%@ Page Title="" Language="C#" MasterPageFile="~/Sidebar.Master" AutoEventWireup="true" CodeBehind="Stock.aspx.cs" Inherits="Medicube.Stock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Medicine.css" rel="stylesheet" />
    <link href="Stock.css" rel="stylesheet" />
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="medicine-content">
         <!-- TOP NAVIGATION -->
    <nav class="topbar">
        <div class="brand">          
            <p>MEDICUBE</p>
        </div>
    </nav>
     <div class="inventory-container">

        <!-- PAGE HEADER -->
        <div class="page-header">
            <div>
                <h2>Inventory</h2>
                <p>Manage and monitor your medicine stock.</p>
            </div>

            <div class="header-actions">
                <asp:Button ID="btnRefresh" runat="server" Text="Refresh" CssClass="btn btn-outline-secondary"  OnClick="btnRefresh_Click" CausesValidation="false" />                         
            </div>
        </div>

        <!-- INVENTORY TABS -->
        <div class="inventory-tabs">
            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="active" NavigateUrl="Stock.aspx">Stock Overview</asp:HyperLink>
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/StockIn.aspx" Text="In Stock">Stock In</asp:HyperLink>
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/StockOut.aspx">Stock Out</asp:HyperLink>        
        </div>

        <!-- SUMMARY CARDS -->
        <div class="summary-cards">

            <div class="summary-card">
                <div class="summary-icon blue">&#9638;</div>
                <div>
                    <p>Total Medicines</p>
                    <h3><asp:Label ID="lblTotalMedicines" runat="server" Text="0" /></h3>
                </div>
            </div>

            <div class="summary-card">
                <div class="summary-icon green">&#10003;</div>
                <div>
                    <p>In Stock</p>
                    <h3><asp:Label ID="lblInStock" runat="server" Text="0" /></h3>
                </div>
            </div>

            <div class="summary-card">
                <div class="summary-icon orange">&#9888;</div>
                <div>
                    <p>Low Stock</p>
                    <h3><asp:Label ID="lblLowStock" runat="server" Text="0" /></h3>
                </div>
            </div>

            <div class="summary-card">
                <div class="summary-icon red">&#10005;</div>
                <div>
                    <p>Out of Stock</p>
                    <h3><asp:Label ID="lblOutOfStock" runat="server" Text="0" /></h3>
                </div>
            </div>

        </div>

        <!-- SEARCH AND FILTERS -->
        <div class="filter-section">

            <div class="search-box">
                <asp:TextBox ID="txtSearch" runat="server"
                    CssClass="form-control"
                    placeholder="Search medicine name or batch number">
                </asp:TextBox>

                <asp:Button ID="btnSearch" runat="server"
                    Text="Search"
                    CssClass="btn btn-dark"
                    OnClick="btnSearch_Click"
                    CausesValidation="false" />

                <asp:Button ID="btnShowAll" runat="server"
                    Text="Show All"
                    CssClass="btn btn-outline-secondary"
                    OnClick="btnShowAll_Click"
                    CausesValidation="false" />
            </div>

            <div class="status-filter">
                <label>Stock Status</label>

                <asp:DropDownList ID="ddlStatus" runat="server"
                    CssClass="form-select">
                    <asp:ListItem Text="All Statuses" Value="All" />
                    <asp:ListItem Text="In Stock" Value="In Stock" />
                    <asp:ListItem Text="Low Stock" Value="Low Stock" />
                    <asp:ListItem Text="Out of Stock" Value="Out of Stock" />
                </asp:DropDownList>

                <asp:Button ID="btnFilter" runat="server"
                    Text="Apply"
                    CssClass="btn btn-outline-secondary"
                    OnClick="btnFilter_Click"
                    CausesValidation="false" />
            </div>

        </div>

        <asp:Label ID="lblMessage" runat="server"
            CssClass="message-label"> </asp:Label>

        <!-- INVENTORY TABLE -->
        <div class="table-container">

            <div class="table-heading">
                <div>
                    <h4>Stock Details</h4>
                    <p>Current inventory and stock availability</p>
                </div>
            </div>

            <div class="table-responsive">

                <asp:GridView ID="gvStock" runat="server"
                    AutoGenerateColumns="False"
                    CssClass="table inventory-table"
                    GridLines="None"
                    EmptyDataText="No medicine records found.">

                    <Columns>

                        <asp:BoundField DataField="MedicineID"
                            HeaderText="ID" />

                        <asp:BoundField DataField="MedicineName"
                            HeaderText="Medicine Name" />

                        <asp:BoundField DataField="BatchNumber"
                            HeaderText="Batch Number" />

                        <asp:BoundField DataField="CategoryName"
                            HeaderText="Category" />

                        <asp:BoundField DataField="SupplierName"
                            HeaderText="Supplier" />

                        <asp:BoundField DataField="QuantityInStock"
                            HeaderText="Current Qty" />

                        <asp:BoundField DataField="ReorderLevel"
                            HeaderText="Reorder Level" />

                        <asp:BoundField DataField="ExpiryDate"
                            HeaderText="Expiry Date"
                            DataFormatString="{0:dd MMM yyyy}" />

                        <asp:BoundField DataField="StockStatus"
                            HeaderText="Status" />

                    </Columns>

                </asp:GridView>

            </div>
        </div>

    </div>

    </div>
</asp:Content>
