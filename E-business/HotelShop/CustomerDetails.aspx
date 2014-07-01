<%@ Page Title="Хотелски услуги : Потребителски данни" Language="C#" 
MasterPageFile="~/HotelShop.master" AutoEventWireup="true" 
CodeFile="CustomerDetails.aspx.cs" Inherits="CustomerDetails" %>

<%@ Register TagPrefix="uc1" TagName="CustomerDetailsEdit" 
Src="UserControls/CustomerDetailsEdit.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <h1>
    <span class="CatalogTitle">Променете своите данни</span>
  </h1>
  <uc1:CustomerDetailsEdit ID="CustomerDetailsEdit1" runat="server" />
</asp:Content>
