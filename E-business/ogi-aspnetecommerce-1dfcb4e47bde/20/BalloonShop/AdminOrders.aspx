<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
  CodeFile="AdminOrders.aspx.cs" Inherits="AdminOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titlePlaceHolder" runat="Server">
  <span class="AdminTitle">BalloonShop Admin
    <br />
    Orders </span>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="adminPlaceHolder" runat="Server">
  Show orders by customer
  <asp:DropDownList ID="userDropDown" runat="server" DataSourceID="CustomerNameDS"
    DataTextField="UserName" DataValueField="UserId" />
  <asp:Button ID="byCustomerGo" runat="server" Text="Go" OnClick="byCustomerGo_Click" />
  <br />
  Get order by ID
  <asp:TextBox ID="orderIDBox" runat="server" Width="77px" />
  <asp:Button ID="byIDGo" runat="server" Text="Go" OnClick="byIDGo_Click" />
  <br />
  Show the most recent
  <asp:TextBox ID="recentCountTextBox" runat="server" MaxLength="4" Width="40px">20</asp:TextBox>
  orders
  <asp:Button ID="byRecentGo" runat="server" Text="Go" OnClick="byRecentGo_Click" />
  <br />
  Show all orders created between
  <asp:TextBox ID="startDateTextBox" runat="server" Width="72px" />
  and
  <asp:TextBox ID="endDateTextBox" runat="server" Width="72px" />
  <asp:Button ID="byDateGo" runat="server" Text="Go" OnClick="byDateGo_Click" />
  <br />
  Show all orders awaiting stock check
  <asp:Button ID="awaitingStockGo" runat="server" Text="Go" OnClick="awaitingStockGo_Click" />
  <br />
  Show all orders awaiting shipment
  <asp:Button ID="awaitingShippingGo" runat="server" Text="Go" OnClick="awaitingShippingGo_Click" />
  <br />
  <br />
  <asp:Label ID="errorLabel" runat="server" CssClass="AdminError" EnableViewState="False"></asp:Label>
  &nbsp;<asp:RangeValidator ID="startDateValidator" runat="server" ControlToValidate="startDateTextBox"
    Display="None" ErrorMessage="Invalid start date" MaximumValue="1/1/2015" MinimumValue="1/1/2009"
    Type="Date"></asp:RangeValidator>
  &nbsp;<asp:RangeValidator ID="endDateValidator" runat="server" ControlToValidate="endDateTextBox"
    Display="None" ErrorMessage="Invalid end date" MaximumValue="1/1/2015" MinimumValue="1/1/1999"
    Type="Date"></asp:RangeValidator>
  &nbsp;<asp:CompareValidator ID="compareDatesValidator" runat="server" ControlToCompare="endDateTextBox"
    ControlToValidate="startDateTextBox" Display="None" ErrorMessage="Start date should be more recent than end date"
    Operator="LessThan" Type="Date"></asp:CompareValidator>
  <asp:ValidationSummary ID="validationSummary" runat="server" CssClass="AdminError"
    HeaderText="Data validation errors:" />
  <br />
  <asp:GridView ID="grid" runat="server" AutoGenerateColumns="False" DataKeyNames="OrderID"
    OnSelectedIndexChanged="grid_SelectedIndexChanged">
    <Columns>
      <asp:BoundField DataField="OrderID" HeaderText="Order ID" ReadOnly="True" SortExpression="OrderID" />
      <asp:BoundField DataField="DateCreated" HeaderText="Date Created" ReadOnly="True"
        SortExpression="DateCreated" />
      <asp:BoundField DataField="DateShipped" HeaderText="Date Shipped" ReadOnly="True"
        SortExpression="DateShipped" />
      <asp:BoundField DataField="StatusAsString" HeaderText="Status" ReadOnly="True" SortExpression="StatusAsString" />
      <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" ReadOnly="True"
        SortExpression="CustomerName" />
      <asp:ButtonField CommandName="Select" Text="Select" />
    </Columns>
  </asp:GridView>
  <asp:SqlDataSource ID="CustomerNameDS" runat="server" ConnectionString="<%$ ConnectionStrings:BalloonShopConnection %>"
    SelectCommand="SELECT vw_aspnet_Users.UserName,
      vw_aspnet_Users.UserId FROM vw_aspnet_Users INNER JOIN
      aspnet_UsersInRoles ON vw_aspnet_Users.UserId =
      aspnet_UsersInRoles.UserId INNER JOIN aspnet_Roles ON
      aspnet_UsersInRoles.RoleId = aspnet_Roles.RoleId WHERE
      (aspnet_Roles.RoleName = 'Customers')" />
</asp:Content>
