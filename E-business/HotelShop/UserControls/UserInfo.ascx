<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserInfo.ascx.cs" Inherits="UserControls_UserInfo" %>
<table cellspacing="0" border="0" width="200px">
    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate>
            <tr>
                <td class="UserInfoHead">
                    Здравейте!
                </td>
            </tr>
            <tr>
                <td class="UserInfoContent">
                    Не сте вписан.
                    <br />
                    <asp:LoginStatus ID="LoginStatus1" LoginText="Влизане" runat="server" />
                    или
                    <asp:HyperLink runat="server" ID="registerLink" NavigateUrl="~/Register.aspx" Text="Регистрирай се"
                        ToolTip="Отиди на страницата за регистрации" />
                </td>
            </tr>
        </AnonymousTemplate>
        <RoleGroups>
            <asp:RoleGroup Roles="Administrators">
                <ContentTemplate>
                    <tr>
                        <td class="UserInfoHead">
                            <asp:LoginName ID="LoginName2" runat="server" FormatString="Здравей, <b>{0}</b>!" />
                        </td>
                    </tr>
                    <tr>
                        <td class="UserInfoContent">
                            <asp:LoginStatus ID="LoginStatus2" LogoutText="Отписване" runat="server" />
                            <br />
                            <asp:HyperLink ID="HyperLink4" NavigateUrl="~/" runat="server" Text="Хотелски услуги" />
                            <br />
                            <asp:HyperLink ID="HyperLink1" NavigateUrl="~/AdminDepartments.aspx" runat="server"
                                Text="Каталог Админ" />
                            <br />
                            <asp:HyperLink ID="HyperLink2" NavigateUrl="~/AdminShoppingCart.aspx" runat="server"
                                Text="Кошница Админ" />
                            <br />
                            <asp:HyperLink ID="HyperLink3" NavigateUrl="~/AdminOrders.aspx" runat="server" Text="Поръчки Админ" />
                        </td>
                    </tr>
                </ContentTemplate>
            </asp:RoleGroup>
            <asp:RoleGroup Roles="Customers">
                <ContentTemplate>
                    <tr>
                        <td class="UserInfoHead">
                            <asp:LoginName ID="LoginName2" runat="server" FormatString="Здравей, <b>{0}</b>!" />
                        </td>
                    </tr>
                    <tr>
                        <td class="UserInfoContent">
                            <asp:LoginStatus ID="LoginStatus2" LogoutText="Излизане" runat="server" />
                            <br />
                            <asp:HyperLink runat="server" ID="detailsLink" NavigateUrl="~/CustomerDetails.aspx"
                                Text="Промени данни" ToolTip="Промени личните си данни" />
                        </td>
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
    </asp:LoginView>
</table>
