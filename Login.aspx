<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Medicube.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Signup.css" rel="stylesheet"/>
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid bg-light min-vh-100 d-flex align-items-center justify-content-center p-4">

            <!-- CARD -->
            <div class="card shadow-sm border rounded-4 overflow-hidden"
                 style="max-width: 1100px; width: 100%; min-height: 700px;">

                <div class="row g-0 h-100">

                    <!-- LEFT: FORM -->
                    <div class="col-lg-6 p-5">

                        <div class="px-lg-4">

                            <h1 class="fw-bold mb-5">Sign up</h1>

                            <!-- Full names -->
                            <div class="mb-5" style="max-width: 285px;">
                                <asp:Label ID="Label7" runat="server" Text="Email"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Full names is required" ForeColor="Red" ValidationGroup="vgRegistration" ControlToValidate="txtEmail">*</asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>                                                                
                            </div>

                            <!-- Password -->
                            <div class="mb-5" style="max-width: 285px;">
                                <asp:Label ID="Label2" runat="server" Text="Password" CssClass="form-label"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password is required." ForeColor="Red" ValidationGroup="vgRegistration" ControlToValidate="txtPassword">*</asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" ValidationGroup="vgLogin"></asp:TextBox> 
                            </div>

                            <!-- Sign in -->
                            <div class="mb-4"> Don't have an account? <a href="Registration.aspx">Sign up</a> </div>
                
                            <!-- Register -->
                            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-info text-white fw-semibold px-4 py-3" Style="margin-left: 85px;" ValidationGroup="vgLogin" OnClick="btnLogin_Click" />
                            <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
                            <br />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" ValidationGroup="vgLogin" CssClass="alert alert-danger mt-4"
                                HeaderText="Please correct the following errors:" ShowSummary="true" ShowMessageBox="false" ForeColor="Red" />
                        </div>

                    </div>


                    <!-- RIGHT: IMAGE -->
                    <div class="col-lg-6 d-flex align-items-center justify-content-center p-4">
                        <asp:Image ID="Image1" runat="server" src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-registration/draw1.webp" CssClass="img-fluid" Style="max-width: 500px;" />                       
                    </div>
                </div>
            </div>
</div>
      
    </form>
</body>
</html>
