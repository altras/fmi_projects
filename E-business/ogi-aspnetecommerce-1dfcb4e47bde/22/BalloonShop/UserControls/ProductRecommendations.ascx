<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductRecommendations.ascx.cs" Inherits="UserControls_ProductRecommendations" %>
<asp:DataList ID="list" runat="server" ShowHeader="false">
  <HeaderStyle CssClass="RecommendationsHead" />
  <HeaderTemplate>
    We also recommend:
  </HeaderTemplate>  
  <ItemTemplate>
    <a class="RecommendationLabel" href='<%# Link.ToProduct(Eval("ProductID").ToString())%>'>
      <%# Eval("Name") %>
    </a> 
    <%# Eval("Description") %>
  </ItemTemplate>
</asp:DataList>
