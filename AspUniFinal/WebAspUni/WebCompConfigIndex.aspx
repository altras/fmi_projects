<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebCompConfigIndex.aspx.cs" Inherits="WebAspUni.WebCompConfigIndex" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head>
	<title>ASP Проект - индекс</title>
	<link rel="Stylesheet" href="Design\index.css"/>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/> 
</head>
<body>
	<form id="wrapper" runat="server">
		<header>
		<h1>Номер на компютъра:
        <asp:Literal ID="LiteralPage"  Text="" runat="server" />
        </h1>
		</header>
        <asp:Panel id="BoxSet" runat="server">
		    <asp:GridView id="BoxSetGrid" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField ReadOnly="True" HeaderText="Компонент" 
                   InsertVisible="False" DataField="Item1"></asp:BoundField>
                    <asp:BoundField ReadOnly="True" HeaderText="Информация" 
                   InsertVisible="False" DataField="Item2"></asp:BoundField>
                </Columns>
            </asp:GridView>
		</asp:Panel>
        <asp:Panel runat="server" id="Monitor">
            <asp:GridView id="MonitorGridView" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField ReadOnly="True" HeaderText="Компонент" 
                       InsertVisible="False" DataField="Item1"></asp:BoundField>
                        <asp:BoundField ReadOnly="True" HeaderText="Информация" 
                       InsertVisible="False" DataField="Item2"></asp:BoundField>
                    </Columns>
               </asp:GridView>
        </asp:Panel>
		<asp:Panel runat="server" id="Peripherals">
            <asp:GridView id="PeripheralGridView" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField ReadOnly="True" HeaderText="Номер" 
                           InsertVisible="False" DataField="Item1"></asp:BoundField>
                            <asp:BoundField ReadOnly="True" HeaderText="Име на Периферия" 
                           InsertVisible="False" DataField="Item2"></asp:BoundField>
                           <asp:BoundField ReadOnly="True" HeaderText="Тип на Периферия" 
                           InsertVisible="False" DataField="Item3"></asp:BoundField>
                           <asp:BoundField ReadOnly="True" HeaderText="Производител" 
                           InsertVisible="False" DataField="Item4"></asp:BoundField>
                        </Columns>
             </asp:GridView>
         </asp:Panel>
        <asp:Panel runat="server" id="Software">
        <asp:GridView id="SoftwareGridView" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField ReadOnly="True" HeaderText="Номер" 
                       InsertVisible="False" DataField="Item1"></asp:BoundField>
                        <asp:BoundField ReadOnly="True" HeaderText="Име на Софтуер" 
                       InsertVisible="False" DataField="Item2"></asp:BoundField>
                       <asp:BoundField ReadOnly="True" HeaderText="Тип" 
                       InsertVisible="False" DataField="Item3"></asp:BoundField>
                       <asp:BoundField ReadOnly="True" HeaderText="Производител" 
                       InsertVisible="False" DataField="Item4"></asp:BoundField>
                    </Columns>
        </asp:GridView>
        </asp:Panel>
		<div class="clear"></div>
		<nav id="paging">
			<asp:HyperLink ID="FirstPage" runat="server" class="pagingNumber" NavigateUrl="\WebCompConfigIndex.aspx?page=1">First</asp:HyperLink>
        <script>
            setPageLinkBehavior('First');
        </script>
        <asp:Repeater runat="server" ID="RepeaterPaging">
            <ItemTemplate>
                <a class="pagingNumber" id="pageLink<%# Container.DataItem %>" href="\WebCompConfigIndex.aspx?page=<%# Container.DataItem %>"><%# Container.DataItem %></a>
                <script>
                    setPageLinkBehavior(<%# Container.DataItem %>);
                </script>                
            </ItemTemplate>
        </asp:Repeater>
        <asp:HyperLink ID="LastPageLink" runat="server" class="pagingNumber">Last</asp:HyperLink>
		</nav>
        <asp:HyperLink runat="server" id="mainPage" class="pagingnumber" NavigateUrl="~/Default.aspx">Начална страница</asp:HyperLink>
		<footer>
		<h4>Курсова работа на Виталий Филипов Ф.Н. 71256 по "ASP програмиране"</h4>
	</form>
</body>
</html>
