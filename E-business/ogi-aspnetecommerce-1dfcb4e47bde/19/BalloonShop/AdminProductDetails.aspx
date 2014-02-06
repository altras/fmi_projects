<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminProductDetails.aspx.cs" Inherits="AdminProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titlePlaceHolder" runat="Server">
  <span class="AdminTitle">
    BalloonShop Admin
    <br />
    Products in 
    <asp:HyperLink ID="catLink" runat="server" />
  </span>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="adminPlaceHolder" runat="Server">
  <asp:Label CssClass="AdminTitle" ID="productNameLabel" runat="server" />  
  <p>
    <asp:Label ID="statusLabel" CssClass="AdminError" runat="server" />
  </p>
  <p>
    Product belongs to these categories:
    <asp:Label ID="categoriesLabel" runat="server" />
  </p>
  <p>
    Remove product from this category:
    <asp:DropDownList ID="categoriesListRemove" runat="server" />  
    <asp:Button ID="removeButton" runat="server" Text="Remove" OnClick="removeButton_Click" />
    <asp:Button ID="deleteButton" runat="server" Text="DELETE FROM CATALOG" OnClick="deleteButton_Click" />
  </p>
  <p>
    Assign product to this category:
    <asp:DropDownList ID="categoriesListAssign" runat="server" />  
    <asp:Button ID="assignButton" runat="server" Text="Assign" OnClick="assignButton_Click" />
  <p>
    Move product to this category:
    <asp:DropDownList ID="categoriesListMove" runat="server" />
    <asp:Button ID="moveButton" runat="server" Text="Move" OnClick="moveButton_Click" />
  </p>
  <p>
    Image1 file name:
    <asp:Label ID="Image1Label" runat="server" />
    <asp:FileUpload ID="image1FileUpload" runat="server" />
    <asp:Button ID="upload1Button" runat="server" Text="Upload" 
      onclick="upload1Button_Click" /><br />
    <asp:Image ID="image1" runat="server" />
  </p>
  <p>
    Image2 file name:
    <asp:Label ID="Image2Label" runat="server" />
    <asp:FileUpload ID="image2FileUpload" runat="server" />
    <asp:Button ID="upload2Button" runat="server" Text="Upload" 
      onclick="upload2Button_Click" /><br />
    <asp:Image ID="image2" runat="server" />
  </p>
</asp:Content>