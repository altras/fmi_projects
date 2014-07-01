<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminProducts.aspx.cs" Inherits="AdminProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titlePlaceHolder" runat="Server">
    <span class="AdminTitle">
    Хотелски услуги
    <br />
    Продукти в 
    <asp:HyperLink ID="catLink" runat="server" />
  </span>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="adminPlaceHolder" Runat="Server">
    <p>
    <asp:Label ID="statusLabel" runat="server" Text=""></asp:Label>
  </p>
  <asp:GridView ID="grid" runat="server" DataKeyNames="ProductID" 
    AutoGenerateColumns="False" Width="100%" 
    onrowcancelingedit="grid_RowCancelingEdit" onrowediting="grid_RowEditing" 
    onrowupdating="grid_RowUpdating" OnSelectedIndexChanged="grid_SelectedIndexChanged">
    <Columns>
      <asp:ImageField DataImageUrlField="Thumbnail" 
        DataImageUrlFormatString="ProductImages1/{0}" HeaderText="Снимка на хотел" 
        ReadOnly="True">
      </asp:ImageField>
      <asp:TemplateField HeaderText="Име на хотел" SortExpression="Name">
        <EditItemTemplate>
          <asp:TextBox ID="nameTextBox" runat="server" Width="97%" 
                       CssClass="GridEditingRow" Text='<%# Bind("Name") %>'>
          </asp:TextBox>
        </EditItemTemplate>
        <ItemTemplate>
          <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Описание на хотела" 
        SortExpression="Description">
        <EditItemTemplate>
          <asp:TextBox ID="descriptionTextBox" runat="server" 
             Text='<%# Bind("Description") %>' Height="100px" Width="97%"
             CssClass="GridEditingRow" TextMode="MultiLine" />
        </EditItemTemplate>
        <ItemTemplate>
          <asp:Label ID="Label2" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Цена" SortExpression="Price">
        <ItemTemplate>
          <asp:Label ID="Label2" runat="server" 
               Text='<%# String.Format("{0:0.00}", Eval("Price")) %>'>
          </asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
          <asp:TextBox ID="priceTextBox" runat="server" Width="45px" 
                 Text='<%# String.Format("{0:0.00}", Eval("Price")) %>'>
          </asp:TextBox>
        </EditItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Икона" SortExpression="Thumbnail">
        <EditItemTemplate>
          <asp:TextBox ID="thumbTextBox" Width="80px" runat="server" 
                   Text='<%# Bind("Thumbnail") %>'></asp:TextBox>
        </EditItemTemplate>
        <ItemTemplate>
          <asp:Label ID="Label3" runat="server" Text='<%# Bind("Thumbnail") %>'></asp:Label>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Изображение" SortExpression="Image">
        <EditItemTemplate>
          <asp:TextBox ID="imageTextBox" Width="80px" runat="server" 
                   Text='<%# Bind("Image") %>'></asp:TextBox>
        </EditItemTemplate>
        <ItemTemplate>
          <asp:Label ID="Label4" runat="server" Text='<%# Bind("Image") %>'></asp:Label>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:CheckboxField DataField="PromoDept" HeaderText="Отдел пром." 
        SortExpression="PromoDept" />
      <asp:CheckboxField DataField="PromoFront" HeaderText="Категория пром." 
        SortExpression="PromoFront" />
      <asp:TemplateField>
        <ItemTemplate>
          <asp:HyperLink 
            Runat="server" Text="Избери" 
            NavigateUrl='<%# "AdminProductDetails.aspx?DepartmentID=" + 
            Request.QueryString["DepartmentID"] + "&amp;CategoryID=" + 
            Request.QueryString["CategoryID"] + "&amp;ProductID=" + 
            Eval("ProductID") %>'
            ID="HyperLink1">
          </asp:HyperLink>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:CommandField ShowEditButton="True" EditText="Промени" UpdateText="Обнови" CancelText="Прекрати" />
    </Columns>
  </asp:GridView>


  <p><b>Създай хотел и го задай към категория:</b></p>
  <p>
    <span class="WideLabel">Име:</span>
    <asp:TextBox ID="newName" runat="server" Width="400px" />
  </p>
  <p>
    <span class="WideLabel">Описание:</span>
    <asp:TextBox ID="newDescription" runat="server" Width="400px"
                 Height="70px" TextMode="MultiLine" />
  </p>          
  <p>
    <span class="WideLabel">Цена:</span>
    <asp:TextBox ID="newPrice" runat="server" Width="400px">0.00</asp:TextBox>
  </p>  
  <p>
    <span class="WideLabel">Икона:</span>      
    <asp:TextBox ID="newThumbnail" runat="server" Width="400px">Generic1.png</asp:TextBox>
  </p>  
  <p>
    <span class="WideLabel">Изображение:</span>
    <asp:TextBox ID="newImage" runat="server" Width="400px">Generic2.png</asp:TextBox>
  </p>  
  <p>
    <span class="widelabel">Отдел промо:</span>
    <asp:CheckBox ID="newPromoDept" runat="server" />
  </p>  
  <p>
    <span class="widelabel">Фронт промо:</span>
    <asp:CheckBox ID="newPromoFront" runat="server" />
  </p>  
  <asp:Button ID="createProduct" runat="server" Text="Създай хотел" 
    onclick="createProduct_Click" />
</asp:Content>

