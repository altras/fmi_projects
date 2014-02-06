<%@ Page Title="BalloonShop: Shopping Cart" Language="C#" MasterPageFile="~/BalloonShop.master"
  AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="ShoppingCart" %>

<%@ Register src="UserControls/ProductRecommendations.ascx" tagname="ProductRecommendations" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <p>
    <asp:Label ID="titleLabel" runat="server" Text="Your Shopping Cart" CssClass="CatalogTitle" />
  </p>
  <p>
    <asp:Label ID="statusLabel" runat="server" />
  </p>
  <asp:GridView ID="grid" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID"
    Width="100%" BorderWidth="0px" OnRowDeleting="grid_RowDeleting">
    <Columns>
      <asp:BoundField DataField="Name" HeaderText="Product Name" ReadOnly="True" SortExpression="Name">
        <ControlStyle Width="100%" />
      </asp:BoundField>
      <asp:BoundField DataField="Price" DataFormatString="{0:c}" HeaderText="Price" ReadOnly="True"
        SortExpression="Price" />
      <asp:BoundField DataField="Attributes" HeaderText="Options" ReadOnly="True" />
      <asp:TemplateField HeaderText="Quantity">
        <ItemTemplate>
          <asp:TextBox ID="editQuantity" runat="server" CssClass="GridEditingRow" Width="24px"
            MaxLength="2" Text='<%#Eval("Quantity")%>' />
        </ItemTemplate>
      </asp:TemplateField>
      <asp:BoundField DataField="Subtotal" DataFormatString="{0:c}" HeaderText="Subtotal"
        ReadOnly="True" SortExpression="Subtotal" />
      <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Delete"></asp:ButtonField>
    </Columns>
  </asp:GridView>
  <p align="right">
    <span>Total amount: </span>
    <asp:Label ID="totalAmountLabel" runat="server" Text="Label" />
  </p>
  <p align="right">
    <asp:Button ID="updateButton" runat="server" Text="Update Quantities" 
      onclick="updateButton_Click" />
    <asp:Button ID="checkoutButton" runat="server" 
      Text="Proceed to Checkout" onclick="checkoutButton_Click" />  
  </p>
  <uc1:ProductRecommendations ID="recommendations" runat="server" />
</asp:Content>