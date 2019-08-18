<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>キャイーン度メーカー</title>
<link href="Content/bootstrap.min.css" rel="stylesheet" />
<link rel="stylesheet" type="text/css" href="Content/main.css" />
</head>
<body>
    <form id="form1" runat="server" class="form-horizontal">
        <%--<video id="player" controls autoplay></video>--%>

        <div>
            <h1>キャイーン度メーカー</h1>
        </div>
        <asp:Panel ID="Panel2" runat="server" Height="37px">
        </asp:Panel>
        <div class="uploadfile">
            <asp:FileUpload ID="FileUpload" runat="server" Height="43px" Width="542px" />
        </div>
        <asp:Panel ID="Panel1" runat="server" Height="303px">
            <asp:Image ID="Image1" runat="server" Height="298px" Width="308px" />
        </asp:Panel>
        <p>
            <asp:Button classs="JudgeButton" ID="JudgeButton" runat="server" Height="65px" Text="判定ボタン" Width="542px" OnClick="JudgeButton_Click1" CssClass="btn btn-default" BackColor="#FF9966" ForeColor="White" />
        </p>
    </form>
<%--<script>
  var player = document.getElementById('player');

  var handleSuccess = function(stream) {
    player.srcObject = stream;
  };

  navigator.mediaDevices.getUserMedia({video: true})
      .then(handleSuccess);
</script>--%>
    <script src="Scripts/bootstrap.js"></script>
</body>
</html>
