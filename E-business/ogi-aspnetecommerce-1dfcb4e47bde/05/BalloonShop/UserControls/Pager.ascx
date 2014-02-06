<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Pager.ascx.cs" Inherits="UserControls_Pager" %>
<p>
Page 
<asp:Label ID="currentPageLabel" runat="server" />
of
<asp:Label ID="howManyPagesLabel" runat="server" />
|

<asp:HyperLink ID="previousLink" Runat="server">Previous</asp:HyperLink>

<asp:Repeater ID="pagesRepeater" runat="server">
  <ItemTemplate>
    <asp:HyperLink ID="hyperlink" runat="server" Text='<%# Eval("Page")  %>' NavigateUrl='<%# Eval("Url") %>' />
  </ItemTemplate>
</asp:Repeater>

<asp:HyperLink ID="nextLink" Runat="server">Next</asp:HyperLink>
</p>
