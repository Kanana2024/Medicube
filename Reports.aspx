<%@ Page Title="" Language="C#" MasterPageFile="~/Sidebar.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="Medicube.Reports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Medicine.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="medicine-content">
         <div class="container-fluid p-4">

    <h2 class="mb-2">Reports</h2>
    <p class="text-muted mb-4">View and monitor your inventory activities.</p>

    <!-- Report Selection -->
    <div class="card shadow-sm border-0 mb-4">
        <div class="card-body">

            <h5 class="mb-3">Generate Report</h5>

            <div class="row g-3">

                <div class="col-md-4">
                    <label class="form-label">Select Report</label>

                    <asp:DropDownList ID="ddlReportType" runat="server"
                        CssClass="form-select">

                        <asp:ListItem Text="Inventory Report" Value="Inventory" />
                        <asp:ListItem Text="Low Stock Report" Value="LowStock" />
                        <asp:ListItem Text="Expiring Medicines Report" Value="Expiring" />
                        <asp:ListItem Text="Stock In Report" Value="StockIn" />
                        <asp:ListItem Text="Stock Out Report" Value="StockOut" />

                    </asp:DropDownList>
                </div>

                <div class="col-md-3">
                    <label class="form-label">Start Date</label>

                    <asp:TextBox ID="txtStartDate" runat="server"
                        TextMode="Date" CssClass="form-control">
                    </asp:TextBox>
                </div>

                <div class="col-md-3">
                    <label class="form-label">End Date</label>

                    <asp:TextBox ID="txtEndDate" runat="server"
                        TextMode="Date" CssClass="form-control">
                    </asp:TextBox>
                </div>

                <div class="col-md-2 d-flex align-items-end">
                    <asp:Button ID="btnGenerate" runat="server"
                        Text="Generate"
                        CssClass="btn btn-primary w-100"
                        OnClick="btnGenerate_Click" />
                </div>

            </div>

            <asp:Label ID="lblMessage" runat="server"
                CssClass="d-block mt-3">
            </asp:Label>

        </div>
    </div>

    <!-- Report Results -->
    <div class="card shadow-sm border-0">

        <div class="card-body">

            <div class="d-flex justify-content-between align-items-center mb-3">

                <div>
                    <h5 class="mb-1">
                        <asp:Label ID="lblReportTitle" runat="server"
                            Text="Inventory Report">
                        </asp:Label>
                    </h5>

                    <small class="text-muted">
                        Records found:
                        <asp:Label ID="lblRecordCount" runat="server"
                            Text="0">
                        </asp:Label>
                    </small>
                </div>

            </div>

            <div class="table-responsive">

                <asp:GridView ID="gvReports" runat="server"
                    AutoGenerateColumns="True"
                    CssClass="table table-hover table-bordered align-middle"
                    GridLines="None"
                    EmptyDataText="No records found."
                    HeaderStyle-CssClass="table-light"
                    EmptyDataRowStyle-CssClass="text-center text-muted">

                </asp:GridView>

            </div>

        </div>

    </div>

</div>
    </div>
    
</asp:Content>
