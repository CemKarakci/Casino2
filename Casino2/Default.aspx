﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Casino2.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="Image1" runat="server" Height="150px" Width="150px" />
            <asp:Image ID="Image2" runat="server" Height="150px" Width="150px" />
            <asp:Image ID="Image3" runat="server" Height="150px" Width="150px" />
            <br />
            <br />
            Your Bet:
            <asp:TextBox ID="betTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="leverButton" runat="server" OnClick="leverButton_Click" Text="Pull Lever" />
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="moneyLabel" runat="server"></asp:Label>
            <br />
            <br />
            1 Cherry - x2 Your Bet<br />
            2 Cherry - x3 Your Bet<br />
            3 Cherry - x4 Your Bet<br />
            <br />
            3 7&#39;s -JackPot- x100 Your Bet<br />
            <br />
            However...If there is even one BAR you win nothing!</div>
    </form>
</body>
</html>
