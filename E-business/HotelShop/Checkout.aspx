<%@ Page Title="" Language="C#" MasterPageFile="~/HotelShop.master" AutoEventWireup="true"
  CodeFile="Checkout.aspx.cs" Inherits="Checkout" %>

<%@ Register TagPrefix="uc1" TagName="CustomerDetailsEdit" 
Src="UserControls/CustomerDetailsEdit.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <asp:Label ID="titleLabel" runat="server" 
    CssClass="CatalogTitle" Text="Потвърдете поръчката си" />
  <br /><br />
  <asp:GridView ID="grid" runat="server" Width="100%"
    AutoGenerateColumns="False" DataKeyNames="ProductID" 
    BorderWidth="1px" >
    <Columns>
      <asp:BoundField DataField="Name" HeaderText="Име на хотела"
       ReadOnly="True" SortExpression="Name" />
      <asp:BoundField DataField="Price" DataFormatString="{0:c}"
       HeaderText="Цена" ReadOnly="True"
        SortExpression="Price" />
      <asp:BoundField DataField="Quantity" HeaderText="Брой хора"
       ReadOnly="True" SortExpression="Quantity" />
      <asp:BoundField DataField="Subtotal" ReadOnly="True" 
        DataFormatString="{0:c}" HeaderText="Междинна сума"
        SortExpression="Subtotal" />
    </Columns>
  </asp:GridView>
  <asp:Label ID="Label2" runat="server" Text="Крайна сума: " 
    CssClass="ProductDescription" />
  <asp:Label ID="totalAmountLabel" runat="server" Text="Етикет" 
    CssClass="ProductPrice" />
  <br /><br />
  <uc1:CustomerDetailsEdit ID="CustomerDetailsEdit1" 
    runat="server" Editable="false" Title="Данни на потребителя" />
  <br />
  <asp:Label ID="InfoLabel" runat="server" />
  <br /><br />
  <asp:Label ID="Label1" runat="server" />
  <br /><br />
  Вид доставка:
  <asp:DropDownList ID="shippingSelection" runat="server" />
  <br /><br />
  <asp:Button ID="placeOrderButton" runat="server"
    Text="Резервиране" OnClick="placeOrderButton_Click" />
</asp:Content>
