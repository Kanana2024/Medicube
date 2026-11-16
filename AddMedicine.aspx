<%@ Page Title="" Language="C#" MasterPageFile="~/Sidebar.Master" AutoEventWireup="true" CodeBehind="AddMedicine.aspx.cs" Inherits="Medicube.AddMedicine" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Medicine.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="medicine-content">
        <!-- Add Medicine Form -->
        <div class="card border-0 shadow-sm mb-4">

            <div class="card-header bg-white border-0 pt-4 px-4">
                <h5 class="fw-bold mb-1">
                    <i class="fas fa-plus-circle me-2"></i>
                    Add Medicine
                </h5>

                <p class="text-muted small mb-0">
                    Enter the medicine details below
                </p>
            </div>

            <div class="card-body p-4">

                <div class="row g-3">

                    <!-- Medicine Name -->
                    <div class="col-md-6">

                        <label class="form-label">
                            Medicine Name
                        </label>

                        <asp:TextBox
                            ID="txtMedicineName"
                            runat="server"
                            CssClass="form-control"
                            placeholder="e.g. Panadol">
                        </asp:TextBox>

                    </div>
                    <!-- Batch Number -->
                    <div class="col-md-6">

                        <label class="form-label">
                            Batch Number
                        </label>

                        <asp:TextBox
                            ID="txtBatchNumber"
                            runat="server"
                            CssClass="form-control"
                            placeholder="e.g. BTH001">
                        </asp:TextBox>

                    </div>
                    <!-- Category -->
                    <div class="col-md-6">

                        <label class="form-label">
                            Category
                        </label>

                        <asp:DropDownList
                            ID="ddlCategory"
                            runat="server"
                            CssClass="form-select">

                            <asp:ListItem
                                Text="Select Category"
                                Value="">
                            </asp:ListItem>

                        </asp:DropDownList>
                    </div>
                    <!-- Supplier -->
                    <div class="col-md-6">

                        <label class="form-label">
                            Supplier
                        </label>

                        <asp:DropDownList
                            ID="ddlSupplier"
                            runat="server"
                            CssClass="form-select">

                            <asp:ListItem
                                Text="Select Supplier"
                                Value="">
                            </asp:ListItem>

                        </asp:DropDownList>
                    </div>
                    <!-- Unit Price -->
                    <div class="col-md-4">

                        <label class="form-label">
                            Unit Price
                        </label>

                        <asp:TextBox
                            ID="txtUnitPrice"
                            runat="server"
                            CssClass="form-control"
                            TextMode="Number"
                            placeholder="0.00">
                        </asp:TextBox>

                    </div>


                    <!-- Quantity -->
                    <div class="col-md-4">

                        <label class="form-label">
                            Quantity in Stock
                        </label>

                        <asp:TextBox
                            ID="txtQuantity"
                            runat="server"
                            CssClass="form-control"
                            TextMode="Number"
                            placeholder="0">
                        </asp:TextBox>

                    </div>


                    <!-- Reorder Level -->
                    <div class="col-md-4">

                        <label class="form-label">
                            Reorder Level
                        </label>

                        <asp:TextBox
                            ID="txtReorderLevel"
                            runat="server"
                            CssClass="form-control"
                            TextMode="Number"
                            placeholder="10">
                        </asp:TextBox>

                    </div>


                    <!-- Manufacture Date -->
                    <div class="col-md-6">

                        <label class="form-label">
                            Manufacture Date
                        </label>

                        <asp:TextBox
                            ID="txtManufactureDate"
                            runat="server"
                            CssClass="form-control"
                            TextMode="Date">
                        </asp:TextBox>

                    </div>
                    <!-- Expiry Date -->
                    <div class="col-md-6">

                        <label class="form-label">
                            Expiry Date
                        </label>

                        <asp:TextBox
                            ID="txtExpiryDate"
                            runat="server"
                            CssClass="form-control"
                            TextMode="Date">
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
                        Text="Save Medicine"
                        CssClass="btn btn-primary px-4"
                        OnClick="btnSave_Click"
                        CausesValidation="false" />
               </div>
            </div>
        </div>
 </div>
</asp:Content>
