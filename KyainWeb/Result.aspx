<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="WebApplication2.Result" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            あなたのキャイーン度：<asp:Label ID="ScoreLabel" runat="server"></asp:Label>
            <asp:Panel ID="Panel1" runat="server">
                <asp:Image ID="OriginalImage" runat="server" Width="300px" />
                <asp:Image ID="AnalyzedImage" runat="server" Width="300px"/>
            </asp:Panel>
            <asp:Button ID="Button1" runat="server" Text="もう一回キャイーンする" CssClass="btn btn-warning" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
