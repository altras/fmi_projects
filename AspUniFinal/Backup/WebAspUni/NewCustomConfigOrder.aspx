<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewCustomConfigOrder.aspx.cs" Inherits="WebAspUni.NewCustomConfigOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head>
	<title>ASP Project New Entry</title>
	<link rel="Stylesheet" href="Design\newEntry.css"/>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/> 
</head>
<body>
    <form id="wrapper" runat="server">
        <%--INPUT MONITOR INFORMATION--%>
        <asp:Panel ID="monitorSection" runat="server" CssClass="section">
            <asp:Label ID="monitorLable" runat="server" Text="Monitor" CssClass="sectionName" /><br /> <br />

            <%--Tried using [ \u00c0-\u01ffa-zA-Z] for unicode for all European Languages.... Did not work--%>
            <asp:Label ID="monitorNameLabel" runat="server" Text="Monitor Name" />
            <asp:TextBox ID="monitorNameTextBox" runat="server" />
            <asp:RequiredFieldValidator ID="monitorNameRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="monitorNameTextBox" CssClass="errorMessages" SetFocusOnError="true" ></asp:RequiredFieldValidator> <br />
            <asp:RegularExpressionValidator ID="monitorNameRequiredRegularExpressionValidator" runat="server" ErrorMessage="Can only include letters,numbers,dash and underscore" ControlToValidate="monitorNameTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="monitorProducerLabel" runat="server" Text="Monitor Producer" />
            <asp:TextBox ID="monitorProducerTextBox" runat="server" /> 
            <asp:RequiredFieldValidator ID="monitorProducerRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="monitorProducerTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator> <br />
            <asp:RegularExpressionValidator ID="monitorProducerRegularExpressionValidator" runat="server" ErrorMessage="Can only include letters,numbers,dash,underscore and space" ControlToValidate="monitorProducerTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="aspectRatioHeightLabel" runat="server" Text="AspectRatio Height" />
            <asp:TextBox ID="aspectRatioHeightTextBox" runat="server" /> 
            <asp:RequiredFieldValidator ID="aspectRatioHeightRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="aspectRatioHeightTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="aspectRatioHeightRegularExpressionValidator" runat="server" ErrorMessage="Can only include from 3 to 4 digits" ControlToValidate="aspectRatioHeightTextBox" CssClass="errorMessages" ValidationExpression="[0-9]{3,4}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="aspectRatioWidthLabel" runat="server" Text="AspectRatio Width" />
            <asp:TextBox ID="aspectRatioWidthTextBox" runat="server" />
            <asp:RequiredFieldValidator ID="aspectRatioWidthRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="aspectRatioWidthTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="aspectRatioWidthRegularExpressionValidator" runat="server" ErrorMessage="Can only include from 3 to 4 digits" ControlToValidate="aspectRatioWidthTextBox" CssClass="errorMessages" ValidationExpression="[0-9]{3,4}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="materialsStandLabel" runat="server" Text="Materials Stand" />
            <asp:TextBox ID="materialsStandTextBox" runat="server" />
            <asp:RequiredFieldValidator ID="materialsStandRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="materialsStandTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="materialsStandRegularExpressionValidator" runat="server" ErrorMessage="Can only contain letters,' ' and ','" ControlToValidate="materialsStandTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\,]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="materialsDisplayLabel" runat="server" Text="Materials Display" />
            <asp:TextBox ID="materialsDisplayTextBox" runat="server" /> 
            <asp:RequiredFieldValidator ID="materialsDisplayRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="materialsDisplayTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="materialsDisplayRegularExpressionValidator" runat="server" ErrorMessage="Can only contain letters,' ' and ','" ControlToValidate="materialsDisplayTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\,]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="matrixNameLabel" runat="server" Text="Matrix" />
            <asp:TextBox ID="matrixNameTextBox" runat="server" /> 
            <asp:RequiredFieldValidator ID="matrixNameRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="matrixNameTextBox" CssClass="errorMessages" SetFocusOnError="true"> </asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="matrixNameRequiredRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,numbers, dash and whitespace" ControlToValidate="matrixNameTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="matrixProducerLabel" runat="server" Text="Matrix Producer" />
            <asp:TextBox ID="matrixProducerTextBox" runat="server" /> 
            <asp:RequiredFieldValidator ID="matrixProducerRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="matrixProducerTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="matrixProducerRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,numbers, dash and whitespace" ControlToValidate="matrixProducerTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="ledLabel" runat="server" Text="LED" />
            <asp:TextBox ID="ledTextBox" runat="server" />
            <asp:RequiredFieldValidator ID="ledRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="ledTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="ledRegularExpressionValidator" runat="server" ErrorMessage="Can only contain 'yes' or 'no'" ControlToValidate="ledTextBox" CssClass="errorMessages" ValidationExpression="yes|no|Yes|No|YES|NO|ДА|НЕ|не|Не|Да|да" SetFocusOnError="true"></asp:RegularExpressionValidator><br />
        </asp:Panel> <br />

        <%--INPUT BOXSET INFORMATION--%>
        <asp:Panel ID="boxSetSection" runat="server" CssClass="section">
            <asp:Label ID="boxSetLabel" runat="server" Text="BoxSet" CssClass="sectionName" /><br /> <br />

            <asp:Label ID="cupNameLabel" runat="server" Text="CPU" />
            <asp:TextBox ID="cpuNameTextBox" runat="server" /> 
            <asp:RequiredFieldValidator ID="cpuNameRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="cpuNameTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="cpuNameRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,numbers, dash and whitespace" ControlToValidate="cpuNameTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="cpuProducerLabel" runat="server" Text="CPU Producer" />
            <asp:TextBox ID="cpuProducerTextBox" runat="server" /> 
            <asp:RequiredFieldValidator ID="cpuProducerRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="cpuProducerTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="cpuProducerRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,numbers,dash and whitespace" ControlToValidate="cpuProducerTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="motherBoardLabel" runat="server" Text="MotherBoard" />
            <asp:TextBox ID="motherBoardTextBox" runat="server" /> 
            <asp:RequiredFieldValidator ID="motherBoardRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="motherBoardTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="motherBoardRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,numbers,dash and whitespace" ControlToValidate="motherBoardTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="ramLabel" runat="server" Text="RAM" />
            <asp:TextBox ID="ramTextBox" runat="server" /> 
            <asp:RequiredFieldValidator ID="ramRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="ramTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="ramRegularExpressionValidator" runat="server" ErrorMessage="Can contain from 1 to 3 numbers" ControlToValidate="ramTextBox" CssClass="errorMessages" ValidationExpression="[0-9]{1,3}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="videoCardNameLabel" runat="server" Text="VideoCard Name" />
            <asp:TextBox ID="videoCardNameTextBox" runat="server" />
            <asp:RequiredFieldValidator ID="videoCardNameRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="videoCardNameTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="videoCardNameRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,numbers,dash and whitespace" ControlToValidate="videoCardNameTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="videoCardProducerLabel" runat="server" Text="VideoCard Producer" />
            <asp:TextBox ID="videoCardProducerTextBox" runat="server" />
            <asp:RequiredFieldValidator ID="videoCardProducerRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="videoCardProducerTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="videoCardProducerRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,numbers,dash and whitespace" ControlToValidate="videoCardProducerTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="coolingSystemLabel" runat="server" Text="Cooling System" />
            <asp:TextBox ID="coolingSystemTextBox" runat="server" />
            <asp:RequiredFieldValidator ID="coolingSystemRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="coolingSystemTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="coolingSystemRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,numbers,dash and whitespace" ControlToValidate="coolingSystemTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="soundCardLabel" runat="server" Text="Sound Card" />
            <asp:TextBox ID="soundCardTextBox" runat="server" />
            <asp:RequiredFieldValidator ID="soundCardRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="soundCardTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="soundCardRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,numbers,dash and whitespace" ControlToValidate="soundCardTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="powerSupplyLabel" runat="server" Text="Power Supply" />
            <asp:TextBox ID="powerSupplyTextBox" runat="server" /> 
            <asp:RequiredFieldValidator ID="powerSupplyRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="powerSupplyTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="powerSupplyRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,numbers,dash and whitespace" ControlToValidate="powerSupplyTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="expansionCardLabel" runat="server" Text="Expansion Card" />
            <asp:TextBox ID="expansionCardTextBox" runat="server" /> 
            <asp:RequiredFieldValidator ID="expansionCardRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="expansionCardTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="expansionCardRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,numbers,dash and whitespace" ControlToValidate="expansionCardTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="hddNameLabel" runat="server" Text="Hdd Name" />
            <asp:TextBox ID="hddNameTextBox" runat="server" /> 
            <asp:RequiredFieldValidator ID="hddNameRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="hddNameTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="hddNameRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,numbers,dash and whitespace" ControlToValidate="hddNameTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="hddProducerLabel" runat="server" Text="Hdd Producer" />
            <asp:TextBox ID="hddProducerTextBox" runat="server" /> 
            <asp:RequiredFieldValidator ID="hddProducerRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="hddProducerTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="hddProducerRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,numbers,dash and whitespace" ControlToValidate="hddProducerTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="usbFlashDriveLabel" runat="server" Text="USBFlashDrive" />
            <asp:TextBox ID="usbFlashDriveTextBox" runat="server" />
            <asp:RequiredFieldValidator ID="usbFlashDriveRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="usbFlashDriveTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="usbFlashDriveRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,numbers,dash and whitespace" ControlToValidate="usbFlashDriveTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="opticalDiscLabel" runat="server" Text="Optical Disc" />
            <asp:TextBox ID="opticalDiscTextBox" runat="server" /> 
            <asp:RequiredFieldValidator ID="opticalDiscRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="opticalDiscTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="opticalDiscRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,dash and whitespace" ControlToValidate="opticalDiscTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="memoryCardReaderLabel" runat="server" Text="Memory Card Reader" />
            <asp:TextBox ID="memoryCardReaderTextBox" runat="server" /> 
            <asp:RequiredFieldValidator ID="memoryCardReaderRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="memoryCardReaderTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="memoryCardRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,dash and whitespace" ControlToValidate="memoryCardReaderTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="boxLabel" runat="server" Text="Box" />
            <asp:TextBox ID="boxTextBox" runat="server" /> 
            <asp:RequiredFieldValidator ID="boxRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="boxTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="boxRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,dash and whitespace" ControlToValidate="boxTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />
        </asp:Panel><br />

        <%--INPUT PERIPHERALS INFOTMATINO--%>
        <asp:Panel ID="peripheralsSection" runat="server" CssClass="section">
            <asp:Label ID="peripheralsLabel" runat="server" Text="Peripherals" CssClass="sectionName" /><br /> <br />

            <asp:Label ID="mouseNameLabel" runat="server" Text="Mouse" />
            <asp:TextBox ID="mouseNameTextBox" runat="server" /> 
            <asp:RequiredFieldValidator ID="mouseNameRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="mouseNameTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="mouseNameRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,numbers,dash and whitespace" ControlToValidate="mouseNameTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="mouseProducerLabel" runat="server" Text="Mouse Producer" />
            <asp:TextBox ID="mouseProducerTextBox" runat="server" /> 
            <asp:RequiredFieldValidator ID="mouseProducerRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="mouseProducerTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="mouseProducerRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,numbers,dash and whitespace" ControlToValidate="mouseProducerTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="keyboardNameLabel" runat="server" Text="KeyBoard" />
            <asp:TextBox ID="keyboardNameTextBox" runat="server" />
            <asp:RequiredFieldValidator ID="keyboardNameRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="keyboardNameTextBox" CssClass="errorMessage" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="keyboardNameRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,numbers,dash and whitespace" ControlToValidate="keyboardNameTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="keyboardProducerLabel" runat="server" Text="KeyBoard Producer" />
            <asp:TextBox ID="keyboardProducerTextBox" runat="server" /> 
            <asp:RequiredFieldValidator ID="keyboardProducerRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="keyboardProducerTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="keyboardProducerRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,numbers,dash and whitespace" ControlToValidate="keyboardProducerTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="otherDevicesLabel" runat="server" Text="Other Devices" />
            <asp:TextBox ID="otherDevicesTextBox" runat="server" /> 
            <asp:RequiredFieldValidator ID="otherDevicesRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="otherDevicesTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="otherDevicesRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,numbers,dash and whitespace" ControlToValidate="otherDevicesTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="videoCameraLabel" runat="server" Text="Video Camera" />
            <asp:TextBox ID="videoCameraTextBox" runat="server" /> 
            <asp:RequiredFieldValidator ID="videoCameraRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="videoCameraTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="videoCameraRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,numbers,dash and whitespace" ControlToValidate="videoCameraTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="microphoneLabel" runat="server" Text="Microphone" />
            <asp:TextBox ID="microphoneTextBox" runat="server" /> 
            <asp:RequiredFieldValidator ID="microphoneRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="microphoneTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="microphoneRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,numbers,dash and whitespace" ControlToValidate="microphoneTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="headphonesNameLabel" runat="server" Text="Headphones" />
            <asp:TextBox ID="headphonesNameTextBox" runat="server" /> 
            <asp:RequiredFieldValidator ID="headphonesNameRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="headphonesNameTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="headphonesNameRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,numbers,dash and whitespace" ControlToValidate="headphonesNameTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="headphonesProducerLabel" runat="server" Text="Headphones Producer" />
            <asp:TextBox ID="headphonesProducerTextBox" runat="server" /> 
            <asp:RequiredFieldValidator ID="headphonesProducerRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="headphonesProducerTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="headphonesProducerRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,numbers,dash and whitespace" ControlToValidate="headphonesProducerTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />
        </asp:Panel> <br />

        <%--INPUT SOFTWARE INFOTMATINO--%>
        <asp:Panel ID="softwareSection" runat="server" CssClass="section">
            <asp:Label ID="softwareLabel" runat="server" Text="Software"  CssClass="sectionName" /><br /> <br />

            <asp:Label ID="osLabel" runat="server" Text="Os" />
            <asp:TextBox ID="osTextBox" runat="server" />
            <asp:RequiredFieldValidator ID="osRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="osTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="osRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,numbers,dash and whitespace" ControlToValidate="osTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="osProducerLabel" runat="server" Text="Os Producer" />
            <asp:TextBox ID="osProducerTextBox" runat="server" /> 
            <asp:RequiredFieldValidator ID="osProducerRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="osProducerTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="osProducerRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,numbers,dash and whitespace" ControlToValidate="osProducerTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="antivirusNameLabel" runat="server" Text="AntiVirus" />
            <asp:TextBox ID="antivirusNameTextBox" runat="server" />
            <asp:RequiredFieldValidator ID="antivirusNameRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="antivirusNameTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="antivirusNameRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,numbers,dash and whitespace" ControlToValidate="antivirusNameTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="antivirusProducerLabel" runat="server" Text="AntiVirus Producer" />
            <asp:TextBox ID="antivirusProducerTextBox" runat="server" /> 
            <asp:RequiredFieldValidator ID="antivirusProducerRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="antivirusProducerTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="antivirusProducerRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,numbers,dash and whitespace" ControlToValidate="antivirusProducerTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="game1NameLabel" runat="server" Text="Game1" />
            <asp:TextBox ID="game1NameTextBox" runat="server" />
            <asp:RequiredFieldValidator ID="game1NameRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="game1NameTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="game1NameRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,numbers,dash and whitespace" ControlToValidate="game1NameTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="game1ProducerLabel" runat="server" Text="Game1 Producer" />
            <asp:TextBox ID="game1ProducerTextBox" runat="server" /> 
            <asp:RequiredFieldValidator ID="game1ProducerRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="game1ProducerTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="game1ProducerRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,numbers,dash and whitespace" ControlToValidate="game1ProducerTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="game2NameLabel" runat="server" Text="Game2" />
            <asp:TextBox ID="game2NameTextBox" runat="server" /> 
            <asp:RequiredFieldValidator ID="game2NameRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="game2NameTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="game2NameRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,numbers,dash and whitespace" ControlToValidate="game2NameTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="game2ProducerLabel" runat="server" Text="Game2 Producer" />
            <asp:TextBox ID="game2ProducerTextBox" runat="server" />
            <asp:RequiredFieldValidator ID="game2ProducerRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="game2ProducerTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="game2ProducerRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,numbers,dash and whitespace" ControlToValidate="game2ProducerTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="game3NameLabel" runat="server" Text="Game3" />
            <asp:TextBox ID="game3NameTextBox" runat="server" /> 
            <asp:RequiredFieldValidator ID="game3NameRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="game3NameTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="game3NameRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,numbers,dash and whitespace" ControlToValidate="game3NameTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="game3ProducerLabel" runat="server" Text="Game3 Producer" />
            <asp:TextBox ID="game3ProducerTextBox" runat="server" />
            <asp:RequiredFieldValidator ID="game3ProducerRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="game3ProducerTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="game3ProducerRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,numbers,dash and whitespace" ControlToValidate="game3ProducerTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="otherNameLabel" runat="server" Text="Other" />
            <asp:TextBox ID="otherNameTextBox" runat="server" /> 
            <asp:RequiredFieldValidator ID="otherNameRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="otherNameTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="otherNameRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,numbers,dash and whitespace" ControlToValidate="otherNameTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />

            <asp:Label ID="otherProducerLabel" runat="server" Text="Other Producer" />
            <asp:TextBox ID="otherProducerTextBox" runat="server" /> 
            <asp:RequiredFieldValidator ID="otherProducerRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="otherProducerTextBox" CssClass="errorMessages" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="otherProducerRegularExpressionValidator" runat="server" ErrorMessage="Can contain letters,numbers,dash and whitespace" ControlToValidate="otherProducerTextBox" CssClass="errorMessages" ValidationExpression="[ a-zA-Z-0-9-абвгдежзийклмнопрстуфхцчшщъьюяѝАБГВДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯЍ\-]{1,50}" SetFocusOnError="true"></asp:RegularExpressionValidator><br />
        </asp:Panel>

        <asp:Panel ID="navigationSection" runat="server" CssClass="section">
            <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="CreateNewEntry" CausesValidation="true" CssClass="buttons" /><br />
            <asp:HyperLink Id="ToMainPage" runat="server" NavigateUrl="~\Default.aspx" CssClass="buttons" >Back To Main Page</asp:HyperLink>
        </asp:Panel>
    </form>
</body>
</html>
