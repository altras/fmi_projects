<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
  CodeFile="AdminOrderDetails.aspx.cs" Inherits="AdminOrderDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titlePlaceHolder" runat="Server">
  <span class="AdminTitle">BalloonShop Admin
    <br />
    Order Details </span>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="adminPlaceHolder" runat="Server">
  <h2>
    <asp:Label ID="orderIdLabel" runat="server" CssClass="AdminTitle" 
    Text="Order #000" />
  </h2>
  <span class="WideLabel">Total Amount:</span>
  <asp:Label ID="totalAmountLabel" runat="server" />
  <br />
  <span class="WideLabel">Date Created:</span>
  <asp:TextBox ID="dateCreatedTextBox" runat="server" Width="400px" 
    enabled="false" />
  <br />
  <span class="WideLabel">Date Shipped:</span>
  <asp:TextBox ID="dateShippedTextBox" runat="server" Width="400px" />
  <br />
  <span class="WideLabel">Status:</span>
  <asp:DropDownList ID="statusDropDown" runat="server" />
  <br />
  <span class="WideLabel">Auth Code:</span>
  <asp:TextBox ID="authCodeTextBox" runat="server" Width="400px" />
  <br />  
  <span class="WideLabel">Reference No:</span>
  <asp:TextBox ID="referenceTextBox" runat="server" Width="400px" />
  <br />
  <span class="WideLabel">Comments:</span>
  <asp:TextBox ID="commentsTextBox" runat="server" Width="400px" />
  <br />
  <span class="WideLabel">Customer Name:</span>
  <asp:TextBox ID="customerNameTextBox" runat="server" Width="400px" 
    enabled="false"  />
  <br />
  <span class="WideLabel">Shipping Address:</span>
  <asp:TextBox ID="shippingAddressTextBox" runat="server" Width="400px" 
    Height="200px" TextMode="MultiLine" enabled="false"  />
  <br />
  <span class="WideLabel">Shipping Type:</span>
  <asp:TextBox ID="shippingTypeTextBox" runat="server" Width="400px" 
    enabled="false" />
  <br />
  <span class="WideLabel">Customer Email:</span>
  <asp:TextBox ID="customerEmailTextBox" runat="server" Width="400px" 
    enabled="false" />
  <br />
  
  <asp:Button ID="editButton" runat="server" 
    Text="Edit" Width="100px" OnClick="editButton_Click" />
  <asp:Button ID="updateButton" runat="server"
    Text="Update" Width="100px" OnClick="updateButton_Click" />
  <asp:Button ID="cancelButton" runat="server"
    Text="Cancel" Width="100px" OnClick="cancelButton_Click" />
  <br />
  <asp:Button ID="processOrderButton" runat="server"
    Text="Process Order" Width="310px" 
    OnClick="processOrderButton_Click" />
  <br />
  <asp:Button ID="cancelOrderButton" runat="server"
    Text="Cancel Order" Width="310px" 
    OnClick="cancelOrderButton_Click" />
    
  <p>
    The order contains these items:
  </p>
  <asp:GridView ID="grid" runat="server" AutoGenerateColumns="False" BackColor="White" Width="100%">
    <Columns>
      <asp:BoundField DataField="ProductID" HeaderText="Product ID" ReadOnly="True" SortExpression="ProductID" />
      <asp:BoundField DataField="ProductName" HeaderText="Product Name" ReadOnly="True" SortExpression="ProductName" />
      <asp:BoundField DataField="Quantity" HeaderText="Quantity" ReadOnly="True" SortExpression="Quantity" />
      <asp:BoundField DataField="UnitCost" HeaderText="Unit Cost" ReadOnly="True" SortExpression="UnitCost" />
      <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" ReadOnly="True" SortExpression="Subtotal" />
    </Columns>
  </asp:GridView>
  
  <p>Order Audit Trail:</p>
  <asp:GridView ID="auditGrid" runat="server"
  AutoGenerateColumns="False" BackColor="White"
  BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px"
  CellPadding="3" GridLines="Horizontal" Width="100%">
  <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
  <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
  <Columns>
    <asp:BoundField DataField="AuditID" HeaderText="Audit ID"
      ReadOnly="True" SortExpression="AuditID" />
    <asp:BoundField DataField="DateStamp" HeaderText="Date Stamp"
      ReadOnly="True" SortExpression="DateStamp" />
    <asp:BoundField DataField="MessageNumber"
      HeaderText="Message Number" ReadOnly="True"
      SortExpression="MessageNumber" />
    <asp:BoundField DataField="Message" HeaderText="Message"
      ReadOnly="True" SortExpression="Message" />
  </Columns>
  <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C"
    HorizontalAlign="Right" />
  <SelectedRowStyle BackColor="#738A9C" Font-Bold="True"
    ForeColor="#F7F7F7" />
  <HeaderStyle BackColor="#4A3C8C" Font-Bold="True"
    ForeColor="#F7F7F7" />
  <AlternatingRowStyle BackColor="#F7F7F7" />
</asp:GridView>

  
</asp:Content>
