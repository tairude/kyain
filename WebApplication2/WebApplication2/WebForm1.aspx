<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:FileUpload ID="FileUpload" runat="server" Height="34px" Width="538px" />
        <p>
            <asp:Button ID="JudgeButton" runat="server" Height="65px" Text="判定ボタン" Width="542px" OnClick="JudgeButton_Click1" />
        </p>
        <asp:Panel ID="Panel" runat="server">
            <asp:TextBox ID="ScoreBox" runat="server"></asp:TextBox>
            <asp:Image ID="OriginalImage" runat="server" Width="205px" />
        </asp:Panel>
    </form>
    </form>
</body>
</html>
