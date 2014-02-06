<%@ Page Title="BalloonShop: Online Store Demo" Language="C#" MasterPageFile="~/BalloonShop.master" %>

<%@ Register src="UserControls/ProductsList.ascx" tagname="ProductsList" tagprefix="uc1" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>
    <span class="CatalogTitle">Welcome to BalloonShop!</span>
  </h1>
  <h2>
    <span class="CatalogDescription">This week we have a special price
for these fantastic products: </span>
  </h2>
  <uc1:ProductsList ID="ProductsList1" runat="server" />
</asp:Content>


