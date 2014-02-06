<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchBox.ascx.cs" Inherits="UserControls_SearchBox" %>
<asp:Panel ID="searchPanel" runat="server" DefaultButton="goButton">
  <table class="SearchBox">
    <tr>
      <td class="SearchBoxHead">Search the Catalog</td>
    </tr>
    <tr>
      <td class="SearchBoxContent">
        <asp:TextBox ID="searchTextBox" Runat="server" Width="128px" 
          MaxLength="100" />
        <asp:Button ID="goButton" Runat="server" 
          Text="Go" Width="36px" onclick="goButton_Click" /><br />
        <asp:CheckBox ID="allWordsCheckBox" Runat="server" 
          Text="Search for all words" />
      </td>
    </tr>
  </table>
</asp:Panel> 
