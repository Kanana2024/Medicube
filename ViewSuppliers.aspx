<%@ Page Title="" Language="C#" MasterPageFile="~/Sidebar.Master" AutoEventWireup="true" CodeBehind="ViewSuppliers.aspx.cs" Inherits="Medicube.ViewSupplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Medicine.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="medicine-content">  
        <!-- Page Heading -->
            <div class="d-flex justify-content-between align-items-center mb-4">

                <div>
                    <h2 class="fw-bold mb-1">Suppliers Management</h2>
                    <p class="text-muted mb-0"> Manage suppliers </p>
      
                </div>

           </div>
            <!-- Search Medicine -->
    <div class="card border-0 shadow-sm mb-4">&nbsp;<div class="card-body p-4">

            <div class="row g-2">

                <div class="col-md-8">

                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control"  placeholder="Search by supplier name or email..."></asp:TextBox>
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
                Supplier List
            </h5>

        </div>


        <div class="card-body p-4">

            <div class="table-responsive">

                <asp:GridView ID="gvSuppliers" runat="server" AutoGenerateColumns="False"    
                    CssClass="table table-hover align-middle"
                    EmptyDataText="No suppliers found.">

                    <Columns>

                        <asp:BoundField
                            DataField="SupplierID"
                            HeaderText="ID" />

                        <asp:BoundField
                            DataField="SupplierName"
                            HeaderText="Supplier name" />

                        <asp:BoundField
                            DataField="ContactPerson"
                            HeaderText="Contact Person" />

                        <asp:BoundField
                            DataField="Phone"
                            HeaderText="Phone" />

                        <asp:BoundField
                            DataField="Email"
                            HeaderText="Email" />

                        <asp:BoundField
                            DataField="Address"
                            HeaderText="Address" />  
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
