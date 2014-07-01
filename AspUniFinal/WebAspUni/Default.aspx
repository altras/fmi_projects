<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAspUni.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head>
	<title>ASP Проект - начална страница</title>
	<link rel="Stylesheet" href="Design\mainPage.css"/>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/> 
</head>
<body>
	<form id="wrapper" runat="server">
		<header>
		<h1>Начална страница</h1>
		</header>
            <asp:Button id="dataBaseInsert" runat="server" text="Въвеждане в Базата Данни" class="pagingnumber" OnClick="PopulateDatabase"  /> <br />
            <asp:HyperLink id="computerIndex" class="pagingnumber" runat="server" NavigateUrl="~/WebCompConfigIndex.aspx">Поръчкови Компютри - Индекс</asp:HyperLink> <br />
            <asp:HyperLink id="insertNewData" class="pagingnumber" runat="server" NavigateUrl="~/NewCustomConfigOrder.aspx">Нова Поръчка</asp:HyperLink> <br />
            <asp:Panel ID="validationXmlsResults" runat="server">
                <asp:Label ID="validatedXmlsResults" runat="server"></asp:Label>
                <asp:Label ID="invalidatedXmlsResults" runat="server"></asp:Label>
            </asp:Panel>
		<footer>
			<h4>Курсова работа на Виталий Филипов Ф.Н. 71256 по "ASP програмиране"</h4>
		</footer>
	</form>
</body>
</html>
