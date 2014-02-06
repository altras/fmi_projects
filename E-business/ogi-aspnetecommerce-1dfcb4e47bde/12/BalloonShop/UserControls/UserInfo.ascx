<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserInfo.ascx.cs" Inherits="UserControls_UserInfo" %>
<table cellspacing="0" border="0" width="200px" >
  <asp:LoginView ID="LoginView1" runat="server">
    <AnonymousTemplate>
      <tr>
        <td class="UserInfoHead">Welcome!</td>
      </tr>    
      <tr>
        <td class="UserInfoContent">
          You are not logged in.
          <asp:LoginStatus ID="LoginStatus1" runat="server" />
        </td>
      </tr>
    </AnonymousTemplate>
    <RoleGroups>
      <asp:RoleGroup Roles="Administrators">      
        <ContentTemplate>
          <tr>
            <td class="UserInfoHead">
              <asp:LoginName ID="LoginName2" runat="server" FormatString="Hello, <b>{0}</b>!" />
            </td>
          </tr>            
          <tr>
            <td class="UserInfoContent">              
              <asp:LoginStatus ID="LoginStatus2" runat="server" />
              <br />
              <a href="./">BalloonShop</a>   
              <br />
              <a href="AdminDepartments.aspx">Catalog Admin</a>
            </td>
          </tr>          
        </ContentTemplate>
      </asp:RoleGroup>
    </RoleGroups>
  </asp:LoginView>
</table>
