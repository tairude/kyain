<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ポーズ判定ゲーム</title>
    <link rel="stylesheet" href="TOP_Design.css" type="text/css"/> 
</head>
<body>
    <form id="form1" runat="server">
        <div class="title">
            <h1>ポーズ判定ゲーム（仮）</h1>
        </div>
        <div class="gameScreen">
            <asp:FileUpload ID="FileUpload" runat="server" Height="34px" Width="538px" />
            <p>
            <asp:Button class="JudgeButton" ID="JudgeButton" runat="server"  Text="判定ボタン"  OnClick="JudgeButton_Click1" />
            </p>
            <div class="box2">
                <asp:Panel ID="Panel" runat="server">
                <asp:TextBox ID="ScoreBox" runat="server"></asp:TextBox>
                <asp:Image ID="OriginalImage" runat="server" Width="205px" />
                </asp:Panel>
            </div>
        </div>
    </form>
</body>
</html>
