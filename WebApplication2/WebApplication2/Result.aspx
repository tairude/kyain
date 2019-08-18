<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="WebApplication2.Result" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="Content/result.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="resultScreen">
            <asp:Panel ID="Panel2" runat="server">
            <h2>あなたのキャイーン度：<asp:Label ID="ScoreLabel" runat="server"></asp:Label></h2>
            </asp:Panel>
            <asp:Panel ID="Panel4" runat="server" Height="54px">
            </asp:Panel>
            <asp:Panel ID="Panel1" runat="server">
                <asp:Image ID="OriginalImage" runat="server" Width="300px" />
                <asp:Image ID="AnalyzedImage" runat="server" Width="300px"/>
            </asp:Panel>
            <asp:Panel ID="Panel3" runat="server" Height="50px">
            </asp:Panel>
            <asp:Button ID="Button1" runat="server" Text="もう一回キャイーンする" CssClass="btn btn-warning" OnClick="Button1_Click" Height="51px" Width="281px" />
        </div>
    </form>
</body>
</html>
