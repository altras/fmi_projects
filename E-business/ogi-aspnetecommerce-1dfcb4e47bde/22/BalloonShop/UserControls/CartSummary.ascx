<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CartSummary.ascx.cs" Inherits="UserControls_CartSummary" %>
<table class="CartSummary" border="0" cellpadding="0" cellspacing="1" width="200">
  <tr>
    <td>
      <b>
        <asp:Label ID="cartSummaryLabel" runat="server" /></b>
      <asp:HyperLink ID="viewCartLink" runat="server" NavigateUrl="../ShoppingCart.aspx"
        CssClass="CartLink" Text="(view details)" />
      <asp:DataList ID="list" runat="server">
        <ItemTemplate>
          <%# Eval("Quantity") %>
          x
          <%# Eval("Name") %>
        </ItemTemplate>
      </asp:DataList>
      <img src="Images/line.gif" border="0" width="99%" height="1" />
      Total: <span class="ProductPrice">
        <asp:Label ID="totalAmountLabel" runat="server" />
      </span>
    </td>
  </tr>
</table>
