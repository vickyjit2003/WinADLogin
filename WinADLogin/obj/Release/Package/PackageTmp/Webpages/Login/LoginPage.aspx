<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="WinADLogin.Webpages.Login.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="../../Scripts/jquery-1.10.2.min.js"> </script>
    <link href="../../Content/Mainstyles.css" rel="stylesheet" />
    <title>Idexcel</title>
    <style>
    </style>
</head>
<body class="loginbody">
    <form id="LoginForm" runat="server">
        <div class="divmain">
            <div class="logindiv">
                <p class="lblheader">
                    <asp:Image runat="server" ImageUrl="~/Images/Login/BlueUnlock.png" CssClass="iconimgheader" /><span>User Login </span>
                </p>
                <div class="divlabel">
                    Username 
                </div>
                <div class="divtxtbox" runat="server">
                    <asp:Image runat="server" ImageUrl="~/Images/Login/UserIconB.png" CssClass="iconimg" Height="20" Width="20" />
                    <asp:TextBox autocomplete="off" runat="server" ID="txtUserName" class="txtbox" MaxLength="50"> </asp:TextBox>

                </div>
                <div class="clear">
                </div>
                <div class="divlabel">
                    Password 
                </div>
                <div class="divtxtbox">
                    <asp:Image runat="server" ImageUrl="~/Images/Login/key_2.png" CssClass="iconimgkey" Height="30" Width="21" />
                    <asp:TextBox runat="server" ID="txtPassword" class="txtbox" TextMode="Password" MaxLength="50"> </asp:TextBox>
                </div>
                <div class="clear">
                </div>
                <div class="divbtn">
                    <asp:Button runat="server" ID="Loginbtn" Text="Login" OnClick="Loginbtn_Click" CssClass="btnsubmit" />
                </div>
                <div class="clear">
                </div>
                <p runat="server" id="errormsg" class="errormag"></p>
            </div>
        </div>
    </form>
    <script>
        $("#txtUserName,#txtPassword").keyup(function () {
            $("#errormsg").html("");
        });
    </script>
</body>
</html>
