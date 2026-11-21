<%@ Page Title="" Language="C#" MasterPageFile="~/Sidebar.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Medicube.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Medicine.css" rel="stylesheet" />
    <link href="Dashboard.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.2/css/all.min.css" />
     <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="medicine-content">
        <div class="container-fluid py-4">

    <!-- Header -->
    <div class="d-flex justify-content-between align-items-center mb-4 flex-wrap gap-3">
        <div>
            <h3 class="dashboard-title mb-1">Dashboard</h3>
            <p class="text-muted mb-0">Overview of your medical inventory</p>
        </div>

        <div class="d-flex gap-2">
            <span class="badge bg-white text-dark border p-2">
                <i class="fa-regular fa-calendar me-2"></i>
                <asp:Label ID="lblDate" runat="server"></asp:Label>
            </span>
        </div>
    </div>

    <!-- Welcome Banner -->
    <div class="welcome-banner mb-4">
        <div class="row align-items-center">
            <div class="col-md-8">
                <h3>Welcome back, <asp:Label ID="lblUserName" runat="server" Text="Admin"></asp:Label>!</h3>
                <p class="mb-3">Here's what's happening with your inventory today.</p>
                <a href="ViewMedicine.aspx" class="btn btn-light btn-sm px-3">
                    View Inventory <i class="fa-solid fa-arrow-right ms-2"></i>
                </a>
            </div>
            <div class="col-md-4 text-md-end mt-3 mt-md-0">
                <i class="fa-solid fa-capsules" style="font-size:75px;opacity:.8"></i>
            </div>
        </div>
    </div>

    <!-- Statistics -->
    <div class="row g-3 mb-4">

        <div class="col-xl-3 col-md-6">
            <div class="card stat-card h-100">
                <div class="d-flex justify-content-between">
                    <div>
                        <p class="text-muted mb-2">Total Medicines</p>
                        <div class="stat-number">
                            <asp:Label ID="lblTotalMedicines" runat="server" Text="0"></asp:Label>
                        </div>
                        <small class="text-success">Registered products</small>
                    </div>
                    <div class="stat-icon bg-primary-subtle text-primary">
                        <i class="fa-solid fa-pills"></i>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-xl-3 col-md-6">
            <div class="card stat-card h-100">
                <div class="d-flex justify-content-between">
                    <div>
                        <p class="text-muted mb-2">Total Categories</p>
                        <div class="stat-number">
                            <asp:Label ID="lblTotalCategories" runat="server" Text="0"></asp:Label>
                        </div>
                        <small class="text-muted">Medicine categories</small>
                    </div>
                    <div class="stat-icon bg-info-subtle text-info">
                        <i class="fa-solid fa-layer-group"></i>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-xl-3 col-md-6">
            <div class="card stat-card h-100">
                <div class="d-flex justify-content-between">
                    <div>
                        <p class="text-muted mb-2">Total Suppliers</p>
                        <div class="stat-number">
                            <asp:Label ID="lblTotalSuppliers" runat="server" Text="0"></asp:Label>
                        </div>
                        <small class="text-muted">Registered suppliers</small>
                    </div>
                    <div class="stat-icon bg-success-subtle text-success">
                        <i class="fa-solid fa-truck-field"></i>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-xl-3 col-md-6">
            <div class="card stat-card h-100">
                <div class="d-flex justify-content-between">
                    <div>
                        <p class="text-muted mb-2">Low Stock Items</p>
                        <div class="stat-number text-danger">
                            <asp:Label ID="lblLowStock" runat="server" Text="0"></asp:Label>
                        </div>
                        <small class="text-danger">Require attention</small>
                    </div>
                    <div class="stat-icon bg-danger-subtle text-danger">
                        <i class="fa-solid fa-triangle-exclamation"></i>
                    </div>
                </div>
            </div>
        </div>

    </div>

    <!-- Second Statistics Row -->
    <div class="row g-3 mb-4">

        <div class="col-md-4">
            <div class="card stat-card">
                <div class="d-flex justify-content-between">
                    <div>
                        <p class="text-muted mb-2">Total Units in Stock</p>
                        <div class="stat-number">
                            <asp:Label ID="lblTotalUnits" runat="server" Text="0"></asp:Label>
                        </div>
                    </div>
                    <div class="stat-icon bg-warning-subtle text-warning">
                        <i class="fa-solid fa-boxes-stacked"></i>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-md-4">
            <div class="card stat-card">
                <div class="d-flex justify-content-between">
                    <div>
                        <p class="text-muted mb-2">Expired Medicines</p>
                        <div class="stat-number text-danger">
                            <asp:Label ID="lblExpired" runat="server" Text="0"></asp:Label>
                        </div>
                    </div>
                    <div class="stat-icon bg-danger-subtle text-danger">
                        <i class="fa-solid fa-calendar-xmark"></i>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-md-4">
            <div class="card stat-card">
                <div class="d-flex justify-content-between">
                    <div>
                        <p class="text-muted mb-2">Expiring Soon</p>
                        <div class="stat-number text-warning">
                            <asp:Label ID="lblExpiringSoon" runat="server" Text="0"></asp:Label>
                        </div>
                    </div>
                    <div class="stat-icon bg-warning-subtle text-warning">
                        <i class="fa-solid fa-clock"></i>
                    </div>
                </div>
            </div>
        </div>

    </div>

    <!-- Quick Actions -->
    <div class="card section-card p-4 mb-4">
        <h5 class="section-title mb-3">Quick Actions</h5>

        <div class="row g-3">
            <div class="col-xl-3 col-md-6">
                <a href="AddMedicine.aspx" class="quick-action">
                    <i class="fa-solid fa-plus-circle d-block"></i>
                    <strong>Add Medicine</strong>
                    <p class="small text-muted mb-0">Register new products</p>
                </a>
            </div>

            <div class="col-xl-3 col-md-6">
                <a href="StockIn.aspx" class="quick-action">
                    <i class="fa-solid fa-arrow-down d-block"></i>
                    <strong>Stock In</strong>
                    <p class="small text-muted mb-0">Record incoming stock</p>
                </a>
            </div>

            <div class="col-xl-3 col-md-6">
                <a href="StockOut.aspx" class="quick-action">
                    <i class="fa-solid fa-arrow-up d-block"></i>
                    <strong>Stock Out</strong>
                    <p class="small text-muted mb-0">Record outgoing stock</p>
                </a>
            </div>

            <div class="col-xl-3 col-md-6">
                <a href="Reports.aspx" class="quick-action">
                    <i class="fa-solid fa-chart-pie d-block"></i>
                    <strong>View Reports</strong>
                    <p class="small text-muted mb-0">Analyze inventory data</p>
                </a>
            </div>
        </div>
    </div>

    <!-- Tables -->
    <div class="row g-4 mb-4">

        <!-- Low Stock -->
        <div class="col-lg-6">
            <div class="card section-card h-100">
                <div class="card-body">
                    <div class="d-flex justify-content-between align-items-center mb-3">
                        <h5 class="section-title mb-0">Low Stock Alerts</h5>
                        <a href="Reports.aspx" class="small text-success text-decoration-none">View all</a>
                    </div>

                    <div class="table-responsive">
                        <asp:GridView ID="gvLowStock" runat="server"
                            AutoGenerateColumns="False"
                            CssClass="table table-hover"
                            GridLines="None"
                            EmptyDataText="No low stock medicines found.">

                            <Columns>
                                <asp:BoundField DataField="MedicineName" HeaderText="Medicine" />
                                <asp:BoundField DataField="QuantityInStock" HeaderText="Available" />
                                <asp:BoundField DataField="ReorderLevel" HeaderText="Reorder Level" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>

        <!-- Recent Transactions -->
        <div class="col-lg-6">
            <div class="card section-card h-100">
                <div class="card-body">
                    <div class="d-flex justify-content-between align-items-center mb-3">
                        <h5 class="section-title mb-0">Recent Stock Transactions</h5>
                        <a href="Reports.aspx" class="small text-success text-decoration-none">View all</a>
                    </div>

                    <div class="table-responsive">
                        <asp:GridView ID="gvTransactions" runat="server"
                            AutoGenerateColumns="False"
                            CssClass="table table-hover"
                            GridLines="None"
                            EmptyDataText="No recent transactions.">

                            <Columns>
                                <asp:BoundField DataField="MedicineName" HeaderText="Medicine" />
                                <asp:BoundField DataField="TransactionType" HeaderText="Type" />
                                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                <asp:BoundField DataField="TransactionDate" HeaderText="Date"
                                    DataFormatString="{0:dd MMM yyyy}" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>

    </div>

    <!-- Footer -->
    <div class="text-center text-muted small py-3">
        Medicube Medical Inventory Management System
        <br />
        &copy; <%= DateTime.Now.Year %> All rights reserved.
    </div>

</div>
    </div>
</asp:Content>
