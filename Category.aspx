<%@ Page Title="" Language="C#" MasterPageFile="~/Sidebar.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="Medicube.AddCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Medicine.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="medicine-content">
          <div class="category-content">

      <!-- Page Heading -->
      <div class="d-flex justify-content-between align-items-center mb-4">
          <div>
              <h2 class="fw-bold mb-1">Category Management</h2>
              <p class="text-muted mb-0">
                  Manage and organize medicine categories
              </p>
          </div>

          <i class="bi bi-tags category-icon"></i>
      </div>

      <!-- Message -->
      <asp:Label ID="lblMessage" runat="server"
          CssClass="d-block mb-3">
      </asp:Label>

      <!-- Add Category -->
      <div class="card border-0 shadow-sm mb-4">
          <div class="card-body p-4">

              <h5 class="fw-bold mb-3">Add New Category</h5>

              <div class="row g-3 align-items-end">

                  <div class="col-md-8">
                      <label class="form-label">Category Name</label>

                      <asp:TextBox
                          ID="txtCategoryName"
                          runat="server"
                          CssClass="form-control"
                          placeholder="Enter category name">
                      </asp:TextBox>

                      <asp:RequiredFieldValidator
                          ID="rfvCategory"
                          runat="server"
                          ControlToValidate="txtCategoryName"
                          ErrorMessage="Category name is required."
                          ForeColor="Red"
                          Display="Dynamic"
                          ValidationGroup="AddCategory">
                      </asp:RequiredFieldValidator>
                  </div>
                     <div class="col-md-8">
                       <label class="form-label">Category Name</label>

                       <asp:TextBox
                           ID="txtDescription"
                           runat="server"
                           CssClass="form-control"
                           placeholder="Enter description">
                       </asp:TextBox>

                    
                   </div>

                  <div class="col-md-4">
                      <asp:Button
                          ID="btnAddCategory"
                          runat="server"
                          Text="Add Category"
                          CssClass="btn btn-success w-100"
                          OnClick="btnAddCategory_Click"
                          ValidationGroup="AddCategory" />
                  </div>

              </div>
          </div>
      </div>

     
  </div>
    </div>
</asp:Content>
