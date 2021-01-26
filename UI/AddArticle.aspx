<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddArticle.aspx.cs" Inherits="UI.AddArticle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>העלאת כתבה חדשה:</h1>
    </br>
    <asp:Label runat="server" Text="כותרת הכתבה"></asp:Label>
    </br>
    <asp:TextBox ID="TextBoxTitle" runat="server" style="margin-right: 10px; margin-top: 0px; direction:rtl" Width="905px"></asp:TextBox>
     <asp:RequiredFieldValidator  ErrorMessage="יש להזין כותרת" runat="server" ControlToValidate="TextBoxTitle"></asp:RequiredFieldValidator>
    </br>
    <asp:Label runat="server" Text="תוכן הכתבה:"></asp:Label>
    </br>

    <asp:TextBox ID="TextBoxArticle" TextMode="MultiLine" style="direction:rtl" runat="server" Height="430px" Width="908px"></asp:TextBox>
         <asp:RequiredFieldValidator  ErrorMessage="יש להזין כתבה" runat="server" ControlToValidate="TextBoxArticle"></asp:RequiredFieldValidator>
    </br>
    <asp:Label runat="server"  Text="תאריך ביקור באטרקציה"></asp:Label>
    
    </br>
    <asp:TextBox ID="TextBoxDate" runat="server" TextMode="date" ></asp:TextBox>
    <asp:RequiredFieldValidator  ErrorMessage="יש להזין תאריך" runat="server" ControlToValidate="TextBoxDate"></asp:RequiredFieldValidator>
    </br>
    <asp:CheckBoxList ID="CheckBoxCategories" runat="server" Height="87px" OnSelectedIndexChanged="Unnamed1_SelectedIndexChanged" Width="277px">
        <asp:ListItem Value="Family">אטרקציה משפחתית</asp:ListItem>
        <asp:ListItem Value="Romantic">אטרקציה רומנטית</asp:ListItem>
        <asp:ListItem Value="pregnancy">אטרקציה מותאמת לנשים בהריון</asp:ListItem>
        <asp:ListItem Value="Disabled">אטרקציה מונגשת</asp:ListItem>
         <asp:ListItem Value="nature">אטרקציה בטבע</asp:ListItem>
    </asp:CheckBoxList>
    </br>
    <asp:Label runat="server" Text="העלאת תמונה"></asp:Label>
    </br>
    <asp:FileUpload runat="server" ID="Picture"></asp:FileUpload>
    </br>
    <asp:Button runat="server" ID="SubButton" Text="העלאת הכתבה" OnClick="SubButton_Click" />
</asp:Content>
