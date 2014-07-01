<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
  CodeFile="AdminDepartments.aspx.cs" Inherits="AdminDepartments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titlePlaceHolder" runat="Server">
    <span class="AdminTitle">
    Хотелски услуги админ
    <br />
    Отдели
  </span>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="adminPlaceHolder" runat="Server">
    <p>
    <asp:Label ID="statusLabel" runat="server" Text=""></asp:Label>
  </p>
  <asp:GridView ID="grid" runat="server" DataKeyNames="DepartmentID" Width="100%" 
    AutoGenerateColumns="False" onrowcancelingedit="grid_RowCancelingEdit" 
    onrowdeleting="grid_RowDeleting" onrowediting="grid_RowEditing" 
    onrowupdating="grid_RowUpdating" OnSelectedIndexChanged="grid_SelectedIndexChanged">
    <Columns>
      <asp:BoundField DataField="Name" HeaderText="Име на отдел" 
        SortExpression="Name" />
      <asp:TemplateField HeaderText="Описание на отдел" 
        SortExpression="Description">
        <EditItemTemplate>
          <asp:TextBox ID="descriptionTextBox" runat="server" 
            Text='<%# Bind("Description") %>' Height="70px" TextMode="MultiLine" 
            Width="400px"></asp:TextBox>
        </EditItemTemplate>
        <ItemTemplate>
          <asp:Label ID="Label1" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:HyperLinkField DataNavigateUrlFields="DepartmentID" 
        DataNavigateUrlFormatString="AdminCategories.aspx?DepartmentID={0}" 
        Text="Виж категории" />
      <asp:CommandField ShowEditButton="True" EditText="Промени" UpdateText="Обнови" CancelText="Прекрати" />
      <asp:ButtonField CommandName="Delete" Text="Изтрий" />
    </Columns>
  </asp:GridView>
  <p>Създаване на нов отдел:</p>
  <p>Име:</p>
  <asp:TextBox ID="newName" runat="server" Width="400px" />
  <p>Описание:</p>
  <asp:TextBox ID="newDescription" runat="server" Width="400px" Height="70px" TextMode="MultiLine" />
  <p><asp:Button ID="createDepartment" Text="Създай департамент" runat="server" 
      onclick="createDepartment_Click" /></p>
</asp:Content>
