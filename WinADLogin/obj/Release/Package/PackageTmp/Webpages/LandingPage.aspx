<%@ Page Title="" Language="C#" MasterPageFile="~/WinAdLogin.Master" AutoEventWireup="true" CodeBehind="LandingPage.aspx.cs" Inherits="WinADLogin.Webpages.LandingPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align: center;" runat="server" id="divValiduser">
        <h2>Hi <b>
            <label runat="server" id="username">
            </label>
        </b><span runat="server" id="spnmessage"></span><span> !</span></h2>
    </div>
</asp:Content>
