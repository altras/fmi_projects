<%@ Page Title="Balloonshop : Balloons from Amazon" Language="C#" 
MasterPageFile="~/BalloonShop.master" AutoEventWireup="true" 
CodeFile="AmazonProducts.aspx.cs" Inherits="AmazonProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <h1 class="CatalogTitle">
    Balloons From Amazon
  </h1>
  <h2 class="CatalogDescription">
    Browse these wonderful balloons from Amazon.com:
  </h2>
  <asp:DataList ID="list" runat="server" RepeatColumns="2">
    <ItemTemplate>
      <img src='<%# Eval("ProductImageUrl") %>' border="0" />
      <h3 class="ProductTitle">
        <%# Eval("ProductName") %>
      </h3>
      <p class="DetailSection">
        Price: </span><span class="ProductPrice">
          <%# Eval("ProductPrice") %>
          (<a target="_blank" href="http://www.amazon.com/exec/obidos/ASIN/<%# Eval("ASIN") %>/ref=nosim/<%# BalloonShopConfiguration.AssociateId %>">Buy From Amazon</a>)
      </p>
      <br />
    </ItemTemplate>
  </asp:DataList>
</asp:Content>
