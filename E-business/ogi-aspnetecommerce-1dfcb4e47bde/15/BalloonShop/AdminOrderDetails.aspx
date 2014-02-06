<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
  CodeFile="AdminOrderDetails.aspx.cs" Inherits="AdminOrderDetails" EnableViewState="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titlePlaceHolder" runat="Server">
  <span class="AdminTitle">BalloonShop Admin
    <br />
    Order Details </span>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="adminPlaceHolder" runat="Server">
  <h2>
    <asp:Label ID="orderIdLabel" runat="server" CssClass="AdminTitle" Text="Order #000" />
  </h2>
  <span class="WideLabel">Total Amount:</span>
  <asp:Label ID="totalAmountLabel" runat="server" CssClass="ProductPrice" />
  <br />
  <span class="WideLabel">Date Created:</span>
  <asp:TextBox ID="dateCreatedTextBox" runat="server" Width="400px" />
  <br />
  <span class="WideLabel">Date Shipped:</span>
  <asp:TextBox ID="dateShippedTextBox" runat="server" Width="400px" />
  <br />
  <span class="WideLabel">Status:</span>
  Verified
  <asp:CheckBox ID="verifiedCheck" runat="server" />
  Completed
  <asp:CheckBox ID="completedCheck" runat="server" />
  Canceled
  <asp:CheckBox ID="canceledCheck" runat="server" />
  <br />
  <span class="WideLabel">Comments:</span>
  <asp:TextBox ID="commentsTextBox" runat="server" Width="400px" />
  <br />
  <span class="WideLabel">Customer Name:</span>
  <asp:TextBox ID="customerNameTextBox" runat="server" Width="400px" />
  <br />
  <span class="WideLabel">Address:</span>
  <asp:TextBox ID="shippingAddressTextBox" runat="server" Width="400px" />
  <br />
  <span class="WideLabel">Customer Email:</span>
  <asp:TextBox ID="customerEmailTextBox" runat="server" Width="400px" />
  <br />
  <asp:Button ID="editButton" runat="server" Text="Edit" Width="100px" 
    onclick="editButton_Click" />
  <asp:Button ID="updateButton" runat="server" Text="Update" Width="100px" 
    onclick="updateButton_Click" />
  <asp:Button ID="cancelButton" runat="server" Text="Cancel" Width="100px" 
    onclick="cancelButton_Click" /><br />
  <asp:Button ID="markVerifiedButton" runat="server" 
    Text="Mark Order as Verified" Width="310px" 
    onclick="markVerifiedButton_Click" /><br />
  <asp:Button ID="markCompletedButton" runat="server" 
    Text="Mark Order as Completed" Width="310px" 
    onclick="markCompletedButton_Click" /><br />
  <asp:Button ID="markCanceledButton" runat="server" 
    Text="Mark Order as Canceled" Width="310px" 
    onclick="markCanceledButton_Click" /><br />
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
</asp:Content>
