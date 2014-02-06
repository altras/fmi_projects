<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductsList.ascx.cs" Inherits="UserControls_ProductsList" %>
<%@ Register src="Pager.ascx" tagname="Pager" tagprefix="uc1" %>
<uc1:Pager ID="topPager" runat="server" Visible="False" />
<asp:DataList ID="list" runat="server" RepeatColumns="2" CssClass="ProductList" 
    onitemdatabound="list_ItemDataBound" EnableViewState="False">
  <ItemTemplate>
    <h3 class="ProductTitle">
      <a href="<%# Link.ToProduct(Eval("ProductID").ToString()) %>">
        <%# HttpUtility.HtmlEncode(Eval("Name").ToString()) %>
      </a>
    </h3>
    <a href="<%# Link.ToProduct(Eval("ProductID").ToString()) %>">
      <img width="100" src="<%# Link.ToProductImage(Eval("Thumbnail").ToString()) %>" border="0" alt='<%# HttpUtility.HtmlEncode(Eval("Name").ToString())%>' />
    </a>
    <%# HttpUtility.HtmlEncode(Eval("Description").ToString()) %>
    <p class="DetailSection">
      Price:
      <%# Eval("Price", "{0:c}") %>
    </p>
    <asp:PlaceHolder ID="attrPlaceHolder" runat="server"></asp:PlaceHolder>
  </ItemTemplate>
</asp:DataList>
<uc1:Pager ID="bottomPager" runat="server" Visible="False" />
