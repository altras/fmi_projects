<%@ Page Title="Хотелски услуги" Language="C#" MasterPageFile="~/HotelShop.master" %>

<%@ Register src="UserControls/ProductsList.ascx" tagname="ProductsList" tagprefix="uc1" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>
    <span class="CatalogTitle">Добре дошли в хотелски услуги!</span>
  </h1>
  <h2>
    <span class="CatalogDescription">Тази седмица имаме специални оферти за тези хотели: </span>
  </h2>
  <uc1:ProductsList ID="ProductsList1" runat="server" />
</asp:Content>


