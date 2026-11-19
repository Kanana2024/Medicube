<%@ Page Title="" Language="C#" MasterPageFile="~/Sidebar.Master" AutoEventWireup="true" CodeBehind="PaymentHistory.aspx.cs" Inherits="Medicube.PaymentHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Medicine.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="medicine-content">

        <!-- Payment History -->
        <div class="card border-0 shadow-sm mb-4">

            <div class="card-header bg-white border-0 pt-4 px-4">

                <h5 class="fw-bold mb-1">
                    <i class="fas fa-receipt me-2"></i>
                    Supplier Payment History
                </h5>

                <p class="text-muted small mb-0">
                    View and manage payments made to suppliers
                </p>

            </div>

            <div class="card-body p-4">

                <!-- Search Section -->
                <div class="row g-3 mb-4">

                    <div class="col-md-6">

                        <asp:TextBox
                            ID="txtSearch"
                            runat="server"
                            CssClass="form-control"
                            placeholder="Search by supplier name...">
                        </asp:TextBox>

                    </div>

                    <div class="col-md-6">

                        <asp:Button
                            ID="btnSearch"
                            runat="server"
                            Text="Search"
                            CssClass="btn btn-primary px-4 me-2"
                            OnClick="btnSearch_Click"
                            CausesValidation="false" />

                        <asp:Button
                            ID="btnShowAll"
                            runat="server"
                            Text="Show All"
                            CssClass="btn btn-outline-secondary px-4"
                            OnClick="btnShowAll_Click"
                            CausesValidation="false" />

                    </div>

                </div>

                <!-- Message -->
                <asp:Label
                    ID="lblMessage"
                    runat="server"
                    CssClass="d-block mb-3">
                </asp:Label>

                <!-- Payment History GridView -->
                <div class="table-responsive">

                    <asp:GridView
                        ID="gvPaymentHistory"
                        runat="server"
                        AutoGenerateColumns="False"
                        DataKeyNames="PaymentID"
                        CssClass="table table-hover align-middle"
                        GridLines="None"
                        EmptyDataText="No payment records found."
                        OnRowEditing="gvPaymentHistory_RowEditing"
                        OnRowCancelingEdit="gvPaymentHistory_RowCancelingEdit"
                        OnRowUpdating="gvPaymentHistory_RowUpdating"
                        OnRowDeleting="gvPaymentHistory_RowDeleting">

                        <Columns>

                            <asp:BoundField
                                DataField="PaymentID"
                                HeaderText="Payment ID"
                                ReadOnly="True" />

                            <asp:BoundField
                                DataField="SupplierName"
                                HeaderText="Supplier"
                                ReadOnly="True" />

                            <asp:BoundField
                                DataField="PaymentDate"
                                HeaderText="Payment Date"
                                DataFormatString="{0:dd/MM/yyyy}" />

                            <asp:BoundField
                                DataField="AmountPaid"
                                HeaderText="Amount Paid (KSh)"
                                DataFormatString="{0:N2}" />

                            <asp:BoundField
                                DataField="PaymentMethod"
                                HeaderText="Payment Method" />

                            <asp:BoundField
                                DataField="TransactionReference"
                                HeaderText="Transaction Reference" />

                            <asp:BoundField
                                DataField="Description"
                                HeaderText="Description" />

                            <asp:CommandField
                                ShowEditButton="True"
                                ShowDeleteButton="True"
                                HeaderText="Actions"
                                ButtonType="Link" />

                        </Columns>

                        <HeaderStyle CssClass="table-light" />

                    </asp:GridView>

                </div>

            </div>
        </div>

    </div>
</asp:Content>
