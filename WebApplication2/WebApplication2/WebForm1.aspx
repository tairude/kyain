<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" class="form-horizontal">
        <%--<video id="player" controls autoplay></video>--%>
        <div>
        </div>
        <asp:FileUpload ID="FileUpload" runat="server" Height="34px" Width="538px" />
        <p>
            <asp:Button ID="JudgeButton" runat="server" Height="65px" Text="判定ボタン" Width="542px" OnClick="JudgeButton_Click1" CssClass="btn btn-default" />
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
