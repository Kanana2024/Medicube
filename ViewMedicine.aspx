<%@ Page Title="" Language="C#" MasterPageFile="~/Sidebar.Master" AutoEventWireup="true" CodeBehind="ViewMedicine.aspx.cs" Inherits="Medicube.ViewMedicine" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Medicine.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="medicine-content">

        <!-- Page Heading -->
        <div class="d-flex justify-content-between align-items-center mb-4">

            <div>
                <h2 class="fw-bold mb-1">Medicine Management</h2>
                <p class="text-muted mb-0">
                    Manage medicines, stock and expiry dates
                </p>
            </div>

            <i class="fas fa-pills medicine-icon"></i>

        </div>

        <!-- Search Medicine -->
        <div class="card border-0 shadow-sm mb-4">

            <div class="card-body p-4">

                <div class="row g-2">

                    <div class="col-md-8">

                        <asp:TextBox
                            ID="txtSearch"
                            runat="server"
                            CssClass="form-control"
                            placeholder="Search by medicine name or batch number...">
                        </asp:TextBox>

                    </div>


                    <div class="col-md-4">
                       <div class="d-flex gap-2">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-secondary flex-fill" OnClick="btnSearch_Click" CausesValidation="false" />                            
                            <asp:Button ID="btnShowAll" runat="server"  Text="Show All"
                                CssClass="btn btn-secondary flex-fill"
                                OnClick="btnShowAll_Click"
                                CausesValidation="false" />
                        </div>                     
                    </div>

                </div>

            </div>

        </div>


        <!-- Medicine List -->
        <div class="card border-0 shadow-sm">

            <div class="card-header bg-white border-0 pt-4 px-4">

                <h5 class="fw-bold mb-0">
                    Medicine List
                </h5>

            </div>


            <div class="card-body p-4">

                <div class="table-responsive">

                    <asp:GridView
                        ID="gvMedicines"
                        runat="server"
                        AutoGenerateColumns="False"
                        CssClass="table table-hover align-middle"
                        EmptyDataText="No medicines found.">

                        <Columns>

                            <asp:BoundField
                                DataField="MedicineID"
                                HeaderText="ID" />

                            <asp:BoundField
                                DataField="MedicineName"
                                HeaderText="Medicine" />

                            <asp:BoundField
                                DataField="BatchNumber"
                                HeaderText="Batch Number" />

                            <asp:BoundField
                                DataField="CategoryName"
                                HeaderText="Category" />

                            <asp:BoundField
                                DataField="SupplierName"
                                HeaderText="Supplier" />

                            <asp:BoundField
                                DataField="UnitPrice"
                                HeaderText="Price" />

                            <asp:BoundField
                                DataField="QuantityInStock"
                                HeaderText="Stock" />

                            <asp:BoundField
                                DataField="ReorderLevel"
                                HeaderText="Reorder Level" />

                            <asp:BoundField
                                DataField="ExpiryDate"
                                HeaderText="Expiry Date" />
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
</asp:Content>
