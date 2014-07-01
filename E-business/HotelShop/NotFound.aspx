<%@ Page Language="C#" MasterPageFile="~/HotelShop.master" Title="Хотелски услуги : Какво търсите?" %>

<script runat="server">
  protected void Page_Load(object sender, EventArgs e)
  {
    // set the 404 status code
    Response.StatusCode = 404;
  }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <h1>Търсите хотел?</h1>
  <p>За съжаление, страницата, която търсите не съществува на нашия сайт!</p>
  <p>Посетете нашия <asp:HyperLink ID="HyperLink1" runat="server" Target="~/" Text="каталог" />, или се свържете с нас на olya_stamatova@gmail.com!</p>
  <p>Екипът на <b>Хотелски услуги</b></p>
</asp:Content>