<%@ Page Title="" Language="C#" MasterPageFile="~/Sidebar.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Medicube.Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Medicine.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="medicine-content">
        <div class="container-fluid p-4">

    <h2 class="mb-2">User Management</h2>
    <p class="text-muted mb-4">
        Manage system users, roles and account access.
    </p>

    <div class="card border-0 shadow-sm">

        <div class="card-body">

            <div class="d-flex justify-content-between align-items-center mb-3">
                <h5>Registered Users</h5>

                <asp:Button ID="btnRefresh" runat="server"
                    Text="Refresh"
                    CssClass="btn btn-outline-primary"
                    OnClick="btnRefresh_Click" />
            </div>

            <asp:Label ID="lblMessage" runat="server"
                CssClass="d-block mb-3">
            </asp:Label>

            <div class="table-responsive">

                <asp:GridView ID="gvUsers" runat="server"
                    AutoGenerateColumns="False"
                    DataKeyNames="UserID"
                    CssClass="table table-hover table-bordered align-middle"
                    GridLines="None"
                    EmptyDataText="No users found."
                    OnRowEditing="gvUsers_RowEditing"
                    OnRowCancelingEdit="gvUsers_RowCancelingEdit"
                    OnRowUpdating="gvUsers_RowUpdating"
                    OnRowCommand="gvUsers_RowCommand"
                   >

                    <Columns>

                        <asp:BoundField DataField="UserID"
                            HeaderText="ID"
                            ReadOnly="True" />

                        <asp:BoundField DataField="FullName"
                            HeaderText="Full Name"
                            ReadOnly="True" />

                        <asp:BoundField DataField="Email"
                            HeaderText="Email"
                            ReadOnly="True" />

                        <asp:TemplateField HeaderText="Role">

                            <ItemTemplate>
                                <%# Eval("Role") %>
                            </ItemTemplate>

                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlRole" runat="server"
                                    CssClass="form-select"
                                    SelectedValue='<%# Bind("Role") %>'>

                                    <asp:ListItem Text="Admin" Value="Admin" />
                                    <asp:ListItem Text="Staff" Value="Staff" />

                                </asp:DropDownList>
                            </EditItemTemplate>

                        </asp:TemplateField>

                        <asp:CommandField ShowEditButton="True"
                            EditText="Edit Role"
                            UpdateText="Save"
                            CancelText="Cancel"
                            HeaderText="Manage Role" />

                        <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnDelete" runat="server"
                                Text="Delete"
                                CssClass="btn btn-sm btn-outline-danger"
                                CommandName="DeleteUser"
                                CommandArgument='<%# Container.DataItemIndex %>'
                                OnClientClick="return confirm('Are you sure you want to delete this user?');">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    </Columns>

                </asp:GridView>

            </div>

        </div>

    </div>

</div>
    </div>
    
</asp:Content>
