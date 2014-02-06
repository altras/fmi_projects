<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DepartmentsList.ascx.cs" Inherits="UserControls_DepartmentsList" %>
<asp:DataList ID="list" runat="server" Width="200px" CssClass="DepartmentsList">
  <HeaderStyle CssClass="DepartmentsListHead" />
  <HeaderTemplate>
    Choose a Department
  </HeaderTemplate>  
  <ItemTemplate>
    <asp:HyperLink 
ID="HyperLink1" 
Runat="server" 
NavigateUrl='<%# Link.ToDepartment(Eval("DepartmentID").ToString())%>'
Text='<%# HttpUtility.HtmlEncode(Eval("Name").ToString()) %>'
ToolTip='<%# HttpUtility.HtmlEncode(Eval("Description").ToString()) %>'
CssClass='<%# Eval("DepartmentID").ToString() == Request.QueryString["DepartmentID"] ? "DepartmentSelected" : "DepartmentUnselected" %>'>
    </asp:HyperLink>
  </ItemTemplate>
  <FooterTemplate>
    <a runat="server" href="~/AmazonProducts.aspx" 
       class='<%# Request.AppRelativeCurrentExecutionFilePath == 
       "~/AmazonProducts.aspx" ? "DepartmentSelected" : "DepartmentUnselected" %>' >
    Amazon Balloons
    </a>
  </FooterTemplate>
</asp:DataList>
