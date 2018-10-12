<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Unauthoriseduser.aspx.cs" Inherits="WinADLogin.Webpages.Unauthoriseduser" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Idexcel</title>
    <link href="../Content/Mainstyles.css" rel="stylesheet" />
    <style type="text/css">
        body {
            background-color: gray;
        }
    </style>
</head>
<body>
    <form id="UnauthorizedForm" runat="server">
        <div runat="server" id="DivMessage" visible="true" class="divmainwindow">
            <div runat="server" class="divmessage" style="width: 500px;">
                <div class="header">
                </div>
                <div style="margin-top: 8%; text-align: center;">
                    <p style="" class="popupmessage" runat="server" id="Messageheader">Unauthorised user please contact Administrator !</p>
                </div>
                <div class="btndivmargin">
                    <asp:Button runat="server" ID="Ok" Text="Ok" OnClick="Ok_Click" class="btnsubmit" Style="margin-left: 13%; width: 72px;" />
                </div>
            </div>
        </div>
    </form>
</body>

</html>
