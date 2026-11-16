<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Medicube.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Signup.css" rel="stylesheet" />
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
                        <div class="mb-4" style="max-width: 285px;">
                            <asp:Label ID="Label7" runat="server" Text="Full names"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Full names is required" ForeColor="Red" ValidationGroup="vgRegistration" ControlToValidate="txtFullName">*</asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" ValidationGroup="vgRegistration"></asp:TextBox>                                                                
                        </div>

                        <!-- Email -->
                        <div class="mb-4" style="max-width: 285px;">
                            <asp:Label ID="Label2" runat="server" Text="Email" CssClass="form-label"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Email is required." ForeColor="Red" ValidationGroup="vgRegistration" ControlToValidate="txtEmail">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="vgRegistration">*</asp:RegularExpressionValidator>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" ValidationGroup="vgRegistration"></asp:TextBox> 
                        </div>

                        <!-- Phone -->
                        <div class="mb-4" style="max-width: 285px;">
                            <asp:Label ID="Label3" runat="server" Text="Phone number" CssClass="form-label"></asp:Label>  
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Phone number is required" ForeColor="Red" ValidationGroup="vgRegistration" ControlToValidate="txtPhone">*</asp:RequiredFieldValidator> &nbsp;
                            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" ValidationGroup="vgRegistration"></asp:TextBox>   
                        </div>

                        <!-- Date of birth -->
                        <div class="mb-3" style="max-width: 285px;">
                            <asp:Label ID="Label4" runat="server" Text="Date of birth" CssClass="form-label"> </asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Date of birth is required." ForeColor="Red" ValidationGroup="vgRegistration" ControlToValidate="txtDOB">*</asp:RequiredFieldValidator> &nbsp;
                            <asp:TextBox ID="txtDOB" runat="server" TextMode="Date" CssClass="form-control" ValidationGroup="vgRegistration"></asp:TextBox>                                   
                        </div>

                        <!-- Gender -->
                        <div class="mb-3">  
                            <asp:Label ID="Label1" runat="server" Text="Gender"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Gender is required" ForeColor="Red" ValidationGroup="vgRegistration" ControlToValidate="txtGender">*</asp:RequiredFieldValidator>
                        
                             <asp:RadioButtonList ID="txtGender" runat="server" RepeatDirection="Horizontal" CssClass="gender-list" ValidationGroup="vgRegistration">
                               <asp:ListItem>Female</asp:ListItem> 
                               <asp:ListItem>Male</asp:ListItem>
                             </asp:RadioButtonList>

                        </div>

                        <!-- Address -->
                        <div class="mb-3" style="max-width: 285px;">
                            <asp:Label ID="Label6" runat="server" Text="Address" CssClass="form-label"> </asp:Label>                           
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Address is required" ForeColor="Red" ValidationGroup="vgRegistration" ControlToValidate="txtAddress">*</asp:RequiredFieldValidator>
    &nbsp;
                            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" ValidationGroup="vgRegistration"></asp:TextBox>                         
                        </div>
                        
                        <!-- Password -->
                        <div class="mb-3" style="max-width: 285px;">
                            <asp:Label ID="Label5" runat="server" Text="Password" CssClass="form-label"> </asp:Label>                           
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Password is required" ForeColor="Red" ValidationGroup="vgRegistration" ControlToValidate="txtPassword">*</asp:RequiredFieldValidator>
    &nbsp;
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control form-control-sm" ValidationGroup="vgRegistration"></asp:TextBox>                         
                        </div>
                       <!-- Confirm password -->
                        <div class="mb-3" style="max-width: 285px;">
                            <asp:Label ID="Label8" runat="server" Text="Confirm password" CssClass="form-label"> </asp:Label>                           
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Passwords do not match" ForeColor="Red" ValidationGroup="vgRegistration" ControlToValidate="txtConfirmPassword">*</asp:RequiredFieldValidator>
                            &nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ErrorMessage="Passwords do not match" ForeColor="Red" ValidationGroup="vgRegistration">*</asp:CompareValidator>
                            &nbsp;<asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" ValidationGroup="vgRegistration"></asp:TextBox>                         
                        </div>
                        <!-- Sign in -->
                        <div class="mb-4"> Already have an account?  <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx">Sign in</asp:HyperLink>
                        </div>
                
                        <!-- Register -->
                        <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-info text-white fw-semibold px-4 py-2" Style="margin-left: 85px;" ValidationGroup="vgRegistration" OnClick="btnRegister_Click" />
                        <br />
                        <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
                        <br />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" ValidationGroup="vgRegistration" CssClass="alert alert-danger mt-4"
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
