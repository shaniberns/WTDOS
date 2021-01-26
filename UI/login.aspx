<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder1" runat="server">
   <%-- <div class="logInForm">--%><center>
    <asp:Label ID="userNameLabel" runat="server" Text="שם משתמש"></asp:Label>
    <br />
    <asp:TextBox ID="userNameTextBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="passLabel" runat="server" Text="סיסמה"></asp:Label>
    <br />
    <asp:TextBox ID="passTextBox" runat="server"  TextMode="Password" ToolTip="נא הכנס סיסמה"></asp:TextBox>
    <br />
    <asp:Button ID="submit" runat="server" Text="התחבר לאתר" OnClick="submit_Click"/>
    <br />
    <asp:Label ID="check" runat="server" Text="שם משתמש או סיסמה אינם נכונים" Visible ="false"></asp:Label>
       </center> <%--</div>--%>



</asp:Content>

