<%@ Page Title="" Language="C#" MasterPageFile="~/Sidebar.Master" AutoEventWireup="true" CodeBehind="AddSupplier.aspx.cs" Inherits="Medicube.AddSupplier" %>
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


    <!-- Add Medicine Form -->
    <div class="card border-0 shadow-sm mb-4">

        <div class="card-header bg-white border-0 pt-4 px-4">
            <h5 class="fw-bold mb-1">
                <i class="fas fa-plus-circle me-2"></i>
                Add Supplier
            </h5>

            <p class="text-muted small mb-0">
                Enter the supplier details below
            </p>
        </div>


        <div class="card-body p-4">

            <div class="row g-3">

                <!-- Supplier Name -->
                <div class="col-md-6">

                    <label class="form-label">
                        Supplier Name
                    </label>

                    <asp:TextBox
                        ID="txtSupplierName"
                        runat="server"
                        CssClass="form-control"
                        placeholder="e.g. Medicine Limited">
                    </asp:TextBox>

                </div>


                <!-- Contact Person -->
                <div class="col-md-6">
                    <label class="form-label">
                        Contact Person
                    </label>
                    <asp:TextBox
                        ID="txtContactPerson"
                        runat="server"
                        CssClass="form-control"
                        placeholder="e.g. Luke Omondi">
                    </asp:TextBox>
                </div>


                <!-- Phone -->
                <div class="col-md-6">
                    <label class="form-label">
                       Phone
                    </label>
                   <asp:TextBox
                        ID="txtPhone"
                        runat="server"
                        CssClass="form-control"
                        placeholder="e.g. 0745272878">
                    </asp:TextBox>
                </div>


                <!-- Email -->
                <div class="col-md-6">

                    <label class="form-label">
                        Email
                    </label>

                    <asp:TextBox
                        ID="txtEmail"
                        runat="server"
                        CssClass="form-control"
                        placeholder="e.g. amondi@gmail.com">
                    </asp:TextBox>
                </div>


                <!-- Unit Price -->
                <div class="col-md-4">

                    <label class="form-label">
                        Address
                    </label>
                    <asp:TextBox
                        ID="txtAddress"
                        runat="server"
                        CssClass="form-control"
                        placeholder="e.g. Kilimanjaro Road">
                    </asp:TextBox>                 
                </div>
            </div>


            <!-- Message -->
            <asp:Label
                ID="lblMessage"
                runat="server"
                CssClass="d-block mt-3">
            </asp:Label>


            <!-- Save Button -->
            <div class="mt-4">

                <asp:Button
                    ID="btnSave"
                    runat="server"
                    Text="Save Supplier"
                    CssClass="btn btn-primary px-4"
                    OnClick="btnSave_Click"
                    CausesValidation="false" />
            </div>
        </div>
    </div>    
</div>
</asp:Content>
