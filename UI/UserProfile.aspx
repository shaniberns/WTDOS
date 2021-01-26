<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="UI.UserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
    <asp:Label ID="Label1" runat="server" Text="שם: "></asp:Label>
    <asp:Label ID="NameLabel" runat="server" visible="true"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Text="שם משפחה: "></asp:Label>
    <asp:Label ID="LastNameLabel" runat="server" visible="true" ></asp:Label>
    <br />
    <asp:Label ID="Label3" runat="server" Text="מייל: "></asp:Label>
    <asp:Label ID="MailLabel" runat="server" visible="true" ></asp:Label>
    <br />
    <asp:Label ID="Label4" runat="server" Text="תיאור: "></asp:Label>
    <asp:Label ID="DescriptionUserLabel" runat="server" visible="true" ></asp:Label>
    <br />
    <asp:Image ID="Image" runat="server" visible="true" Width="200" Height="200" />

          <br />
          <br />
        <h1>הגדרות פרופיל</h1>
        <br />
<asp:Label ID="Label6" runat="server" Text="שנה פרטים אישיים"></asp:Label>
<asp:Label ID="Label5" runat="server" Text=" "></asp:Label>
<asp:TextBox ID="SetTextBox" runat="server" Height="16px" Width="172px"></asp:TextBox>
<asp:Label ID="Label7" runat="server" Text=" "></asp:Label>
     <asp:DropDownList ID="DropDownList1" runat="server" >
              <asp:ListItem  Value="SetName">שם</asp:ListItem>
              <asp:ListItem Value="SetLastName">שם משפחה</asp:ListItem>
              <asp:ListItem Value="SetMail">מייל</asp:ListItem>
              <asp:ListItem Value="SetPassword">סיסמה</asp:ListItem>
     </asp:DropDownList>
<asp:Label ID="Label9" runat="server" Text=" "></asp:Label>
<asp:Button ID="SetButton1" runat="server" Text="אישור" OnClick="SetButton_Click" ></asp:Button>
        
              
        

          <br />

     
        </center>

                 
            
</asp:Content>

