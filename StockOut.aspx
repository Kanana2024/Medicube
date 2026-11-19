<%@ Page Title="" Language="C#" MasterPageFile="~/Sidebar.Master" AutoEventWireup="true" CodeBehind="StockOut.aspx.cs" Inherits="Medicube.StockOut" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="StockIn.css" rel="stylesheet" />
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Medicine.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="medicine-content">
    <div class="container-fluid py-4">

    <!-- TOP NAVIGATION -->
    <nav class="navbar bg-white border-bottom mb-4 px-3">
        <span class="navbar-brand fw-bold">MEDICUBE</span>
    </nav>

    <div class="container">

        <!-- PAGE HEADER -->
        <div class="d-flex justify-content-between align-items-center mb-4">
            <div>
                <h2>Stock Out</h2>
                <p class="text-muted mb-0"> Record incoming medicine stock and update inventory quantities. </p>
           </div>
            <asp:HyperLink ID="HyperLink4" runat="server"  CssClass="btn btn-outline-secondary"  NavigateUrl="~/Stock.aspx"> View Stock </asp:HyperLink>      
        </div>

       <!-- TABS -->
        <div class="inventory-tabs">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Stock.aspx">Stock Overview</asp:HyperLink>
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/StockIn.aspx">Stock In</asp:HyperLink>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/StockOut.aspx" CssClass="active">Stock Out</asp:HyperLink>               
        </div>

        <!-- STOCK IN FORM -->
        <div class="card shadow-sm mb-4">
            <div class="card-body p-4">

                <h4>Issue Medicine</h4>
                <p class="text-muted">Enter the details of the outgoing medicine. </p>

                <hr />

                <div class="row g-3">

                    <div class="col-md-6">
                        <asp:Label ID="Label1" runat="server" Text="Select Medicine" CssClass="form-label" />
                         <asp:RequiredFieldValidator
                         ID="rfvMedicine"
                         runat="server"
                         ControlToValidate="ddlMedicine"
                         InitialValue=""
                         ErrorMessage="Please select a medicine."
                         ForeColor="Red"
                         Display="Dynamic" CssClass="form-label" ValidationGroup="vgStockIn"
                             />

                        <asp:DropDownList ID="ddlMedicine" runat="server" CssClass="form-select" AutoPostBack="True"></asp:DropDownList>
                       
 
                    </div>

                    <div class="col-md-6">
                        <asp:Label ID="Label2" runat="server" Text="Quantity Issued" CssClass="form-label" />
                        <asp:RangeValidator ID="rvQuantity" runat="server" ControlToValidate="txtQuantity" MinimumValue="1" MaximumValue="2147483647" Type="Integer" ErrorMessage="Enter a quantity greater than zero." 
                            ForeColor="Red"
                            Display="Dynamic" CssClass="form-label" ValidationGroup="vgStockIn" />
                        &nbsp;<asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" TextMode="Number" placeholder="Enter quantity received" />   
                    </div>

                    <div class="col-md-6">
                        <asp:Label ID="Label3" runat="server" Text="Date Issued" CssClass="form-label" />  
                        <asp:RequiredFieldValidator
                        ID="rfvDate"
                        runat="server"
                        ControlToValidate="txtDateIssued"
                        ErrorMessage="Please select a date."
                        ForeColor="Red"
                        Display="Dynamic" CssClass="form-label" ValidationGroup="vgStockIn" />
                        <asp:TextBox ID="txtDateIssued" runat="server"  CssClass="form-control" TextMode="Date" />       
                    </div>

                    <div class="col-md-6">
                        <label class="form-label">Notes</label>
                        <asp:TextBox ID="txtNotes" runat="server" CssClass="form-control" placeholder="Enter supplier or delivery details" />        
                    </div>

                </div>

                <!-- BUTTONS -->
                <div class="d-flex justify-content-end gap-2 mt-4">

                    <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-outline-secondary" CausesValidation="false" OnClick="btnClear_Click" />
                    <asp:Button ID="btnSave" runat="server" Text="Record Stock Out" CssClass="btn btn-primary" OnClick="btnSave_Click" ValidationGroup="vgStockIn" />

                </div>
                <asp:Label ID="lblMessage" runat="server" CssClass="d-block mt-3" />
            </div>
        </div>

        <!-- STOCK IN HISTORY -->
        <div class="card shadow-sm">

            <div class="card-body p-4">

                <h4>Stock In History</h4>
                <p class="text-muted"> Previously recorded outgoing stock transactions. </p>

                <div class="table-responsive">

                    <asp:GridView ID="gvStockOut" runat="server"
                        AutoGenerateColumns="False"
                        CssClass="table table-hover align-middle"
                        GridLines="None"
                        EmptyDataText="No stock-out transactions recorded yet.">

                        <Columns>

                            <asp:BoundField DataField="TransactionID"
                                HeaderText="Transaction ID" />

                            <asp:BoundField DataField="MedicineName"
                                HeaderText="Medicine Name" />

                            <asp:BoundField DataField="BatchNumber"
                                HeaderText="Batch Number" />

                            <asp:BoundField DataField="Quantity"
                                HeaderText="Quantity Issued" />

                            <asp:BoundField DataField="TransactionDate"
                                HeaderText="Date Issued"
                                DataFormatString="{0:dd MMM yyyy}" />

                            <asp:BoundField DataField="Notes"
                                HeaderText="Notes" />
                             <asp:CommandField
                             ShowEditButton="True"
                             ShowDeleteButton="True"
                             HeaderText="Actions"
                             ButtonType="Link" />

                        </Columns>

                    </asp:GridView>

                </div>

            </div>
        </div>

    </div>
</div>
</div> 
</asp:Content>
