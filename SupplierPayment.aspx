<%@ Page Title="" Language="C#" MasterPageFile="~/Sidebar.Master" AutoEventWireup="true" CodeBehind="SupplierPayment.aspx.cs" Inherits="Medicube.SupplierPayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Medicine.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="medicine-content">

        <!-- Add Supplier Payment Form -->
        <div class="card border-0 shadow-sm mb-4">

            <div class="card-header bg-white border-0 pt-4 px-4">

                <h5 class="fw-bold mb-1">
                    <i class="fas fa-money-bill-wave me-2"></i>
                    Add Supplier Payment
                </h5>

                <p class="text-muted small mb-0">
                    Enter the supplier payment details below
                </p>

            </div>

            <div class="card-body p-4">

                <div class="row g-3">

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

                    <!-- Payment Date -->
                    <div class="col-md-6">

                        <label class="form-label">
                            Payment Date
                        </label>

                        <asp:TextBox
                            ID="txtPaymentDate"
                            runat="server"
                            CssClass="form-control"
                            TextMode="Date">
                        </asp:TextBox>

                    </div>

                    <!-- Amount Paid -->
                    <div class="col-md-6">

                        <label class="form-label">
                            Amount Paid (KSh)
                        </label>

                        <asp:TextBox
                            ID="txtAmountPaid"
                            runat="server"
                            CssClass="form-control"
                            TextMode="Number"
                            placeholder="0.00">
                        </asp:TextBox>

                    </div>

                    <!-- Payment Method -->
                    <div class="col-md-6">

                        <label class="form-label">
                            Payment Method
                        </label>

                        <asp:DropDownList
                            ID="ddlPaymentMethod"
                            runat="server"
                            CssClass="form-select">

                            <asp:ListItem
                                Text="Select Payment Method"
                                Value="">
                            </asp:ListItem>

                            <asp:ListItem
                                Text="Cash"
                                Value="Cash">
                            </asp:ListItem>

                            <asp:ListItem
                                Text="Bank Transfer"
                                Value="Bank Transfer">
                            </asp:ListItem>

                            <asp:ListItem
                                Text="M-Pesa"
                                Value="M-Pesa">
                            </asp:ListItem>

                            <asp:ListItem
                                Text="Cheque"
                                Value="Cheque">
                            </asp:ListItem>

                        </asp:DropDownList>

                    </div>

                    <!-- Transaction Reference -->
                    <div class="col-md-6">

                        <label class="form-label">
                            Transaction Reference
                        </label>

                        <asp:TextBox
                            ID="txtTransactionReference"
                            runat="server"
                            CssClass="form-control"
                            placeholder="e.g. QGH12345678">
                        </asp:TextBox>

                    </div>

                    <!-- Description -->
                    <div class="col-md-6">

                        <label class="form-label">
                            Description
                        </label>

                        <asp:TextBox
                            ID="txtDescription"
                            runat="server"
                            CssClass="form-control"
                            TextMode="MultiLine"
                            Rows="2"
                            placeholder="Enter payment description">
                        </asp:TextBox>

                    </div>

                </div>

                <!-- Message -->
                <asp:Label
                    ID="lblMessage"
                    runat="server"
                    CssClass="d-block mt-3">
                </asp:Label>

                <!-- Buttons -->
                <div class="mt-4">

                    <asp:Button
                        ID="btnSave"
                        runat="server"
                        Text="Save Payment"
                        CssClass="btn btn-primary px-4"
                        OnClick="btnSave_Click"
                        CausesValidation="false" />

                    <asp:Button
                        ID="btnClear"
                        runat="server"
                        Text="Clear"
                        CssClass="btn btn-outline-secondary px-4 ms-2"
                        OnClick="btnClear_Click"
                        CausesValidation="false" />

                </div>

            </div>
        </div>

    </div>

</asp:Content>
