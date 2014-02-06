<%@ Control Language="C#" AutoEventWireup="true" 
CodeFile="ProductReviews.ascx.cs" Inherits="UserControls_ProductReviews"%>

<p class="ReviewHead">Customer Reviews</p>

<asp:DataList ID="list" runat="server" ShowFooter="true" 
CssClass="ReviewTable">
  <ItemStyle CssClass="ReviewTable" />
  <ItemTemplate>
    <p>
      Review by <strong>
        <%# Eval("CustomerName") %></strong> on
      <%# String.Format("{0:D}", Eval("ReviewDate")) %>:
      <br />
      <i>
        <%# Eval("ProductReview") %></i>
    </p>
  </ItemTemplate>
  <FooterTemplate>
  </FooterTemplate>
</asp:DataList>

<asp:Panel ID="addReviewPanel" runat="server">
  <p>
    Write your own review!</p>
  <p>
    <asp:TextBox runat="server" ID="reviewTextBox" Rows="3" 
      Columns="88" TextMode="MultiLine" />
  </p>
  <asp:LinkButton ID="addReviewButton" runat="server" 
    OnClick="addReviewButton_Click">Add Review</asp:LinkButton>
</asp:Panel>

<asp:LoginView ID="LoginView1" runat="server">
  <AnonymousTemplate>
    <p>
      Please log in to write your own review.</p>
  </AnonymousTemplate>
</asp:LoginView>
