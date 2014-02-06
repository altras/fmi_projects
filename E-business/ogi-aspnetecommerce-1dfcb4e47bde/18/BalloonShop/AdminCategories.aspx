<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminCategories.aspx.cs" Inherits="AdminCategories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titlePlaceHolder" runat="Server">
  <span class="AdminTitle">
    BalloonShop Admin
    <br />
    Categories in 
    <asp:HyperLink ID="deptLink" runat="server" />
  </span>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="adminPlaceHolder" Runat="Server">
  <p>
    <asp:Label ID="statusLabel" runat="server" Text=""></asp:Label>
  </p>
  <asp:GridView ID="grid" runat="server" DataKeyNames="CategoryID" 
    AutoGenerateColumns="False" Width="100%" 
    onrowcancelingedit="grid_RowCancelingEdit" onrowdeleting="grid_RowDeleting" 
    onrowediting="grid_RowEditing" onrowupdating="grid_RowUpdating">
    <Columns>
      <asp:BoundField DataField="Name" HeaderText="Category Name" SortExpression="Name" />
      <asp:TemplateField HeaderText="Category Description" SortExpression="Description">
        <ItemTemplate>
          <asp:Label ID="Label1" runat="server" Text='<%# Bind("Description") %>'>
          </asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
          <asp:TextBox ID="descriptionTextBox" runat="server" TextMode="MultiLine" Text='<%# Bind("Description") %>' Height="70px" Width="400px" />
        </EditItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField>
        <ItemTemplate>
          <asp:HyperLink runat="server" ID="link" NavigateUrl='<%# "AdminProducts.aspx?DepartmentID=" + Request.QueryString["DepartmentID"] + "&amp;CategoryID=" + Eval("CategoryID")%>' Text="View Products">
          </asp:HyperLink>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:CommandField ShowEditButton="True" />
      <asp:ButtonField CommandName="Delete" Text="Delete" />
    </Columns>
  </asp:GridView>
  <p>Create a new category:</p>
  <p>Name:</p>
  <asp:TextBox ID="newName" runat="server" Width="400px" />
  <p>Description:</p>
  <asp:TextBox ID="newDescription" runat="server" Width="400px" Height="70px" TextMode="MultiLine" />
  <p><asp:Button ID="createCategory" Text="Create Category" runat="server" 
      onclick="createCategory_Click" /></p>
</asp:Content>
