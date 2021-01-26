<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="UI.SignIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        
        <asp:Label ID="IsBusinessLabel" runat="server" Text="האם אתה עסק או משתמש פרטי?"></asp:Label>
         <br />
<asp:RadioButtonList ID="IsBusinessRadioButtonList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="IsBusinessRadioButtonList_SelectedIndexChanged">
    <asp:ListItem Text="עסק" Value="true" ></asp:ListItem>
    <asp:ListItem Text="משתמש פרטי" Value="false"></asp:ListItem>

</asp:RadioButtonList>
        <br />
         <asp:RequiredFieldValidator ErrorMessage="יש לבחור האם אתה משתמש פרטי או עסק" runat="server" ControlToValidate="IsBusinessRadioButtonList" ></asp:RequiredFieldValidator>


        <asp:Panel ID="PanelUser" runat="server" Visible="false">

        
        <br />
        <asp:Label ID="UserNameLabel" runat="server" Text="שם משתמש"></asp:Label>
        <br />
<asp:TextBox ID="UserNameTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator  ErrorMessage="יש להזין שם משתמש" runat="server" ControlToValidate="UserNameTextBox"></asp:RequiredFieldValidator>
        
        <asp:CustomValidator  runat="server" ControlToValidate="UserNameTextBox" EnableClientScript="false" OnServerValidate="Unnamed_ServerValidate1" ID="UserNameValidator" ></asp:CustomValidator>
        <br />



<asp:Label ID="NameLabel" runat="server" Text="שם"></asp:Label>
        <br />
<asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox>
         <br />
         <asp:RequiredFieldValidator  ErrorMessage="יש להזין שם" runat="server" ControlToValidate="NameTextBox"></asp:RequiredFieldValidator>
        <br />



<asp:Label ID="LastNameLabel" runat="server" Text="שם משפחה"></asp:Label>
        <br />
        <asp:TextBox ID="LastNameTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ErrorMessage="יש להזין שם משפחה" runat="server" ControlToValidate="LastNameTextBox"></asp:RequiredFieldValidator>
        <br />



<asp:Label ID="UserPassLabel" runat="server" Text="סיסמה"></asp:Label>
        <br />
<asp:TextBox ID="UserPassTextBox" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ErrorMessage="יש להזין סיסמה" runat="server" ControlToValidate="UserPassTextBox"></asp:RequiredFieldValidator>
        <asp:CustomValidator ErrorMessage="יש להזין סיסמה" runat="server" ControlToValidate="UserPassTextBox" EnableClientScript="false" OnServerValidate="Unnamed_ServerValidate" ID="PassValidate"></asp:CustomValidator> 


        <br />

<asp:Label ID="MailLabel" runat="server" Text="מייל"></asp:Label>
        <br />
<asp:TextBox ID="MailTextBox" runat="server" TextMode="Email"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ErrorMessage="יש להזין מייל" runat="server" ControlToValidate="MailTextBox"></asp:RequiredFieldValidator>
        <br />







<asp:Label ID="DescriptionUserLabel" runat="server" Text="תיאור עליך" Visible="true"></asp:Label>
<asp:Label ID="DescriptionBusinessLabel" runat="server" Text="תיאור על העסק" Visible="false"></asp:Label>
        <br />
<asp:TextBox ID="DescriptionTextBox" runat="server" TextMode="MultiLine" Height="156px" Width="257px" ></asp:TextBox>
        <br />
         <asp:RequiredFieldValidator ErrorMessage="יש להזין תיאור" runat="server" ControlToValidate="DescriptionTextBox"></asp:RequiredFieldValidator>
        <br />



        <asp:Label ID="PictureLabel" runat="server" Text="הכנס תמונה"></asp:Label>
        <br />
        <asp:FileUpload ID="PictureFileUpload" runat="server"></asp:FileUpload>
        <br />

</asp:Panel>
        
        
<asp:Label ID="BusinessNameLabel" runat="server" Text="שם העסק" Visible="false"></asp:Label>
        <br />
        <asp:TextBox ID="BusinessNameTextBox" runat="server" Visible="false"></asp:TextBox>
        <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="BusinessNameTextBox" EnableClientScript="false"></asp:RequiredFieldValidator>--%>
        <br />



        <asp:Label ID="BusinessAdressLabel" runat="server" Text="כתובת העסק" Visible="false"></asp:Label>
        <br />
        <asp:TextBox ID="BusinessAdressTextBox" runat="server" Visible="false"></asp:TextBox>
        <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="BusinessAdressTextBox" EnableClientScript="false"></asp:RequiredFieldValidator>--%>
        <br />



         <asp:Label ID="PriceLabel" runat="server" Text="מחיר" Visible="false"></asp:Label>
        <br />
        <asp:TextBox ID="PriceTextBox" runat="server" Visible="false"></asp:TextBox>
        <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="PriceTextBox" EnableClientScript="false"></asp:RequiredFieldValidator>--%>
        <br />


         <asp:Button ID="submit" runat="server" Text="הירשם" OnClick="submit_Click" Visible ="false"/>
            
    <br />
        <asp:Label ID="ErrorBusinessLabel" runat="server" Text="יש למלא את כל פרטי העסק!!!" Visible="false" ></asp:Label>
<asp:Label ID="ErrorLabel" runat="server" Text="שגיאה בהרשמה!!!" Visible="false" ></asp:Label>
<asp:Label ID="successLabel" runat="server" Text="ההרשמה בוצעה בהצלחה!" Visible="false"></asp:Label>
    </center>
</asp:Content>
