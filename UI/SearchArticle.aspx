<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SearchArticle.aspx.cs" Inherits="UI.SearchArticle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Search By Categories"></asp:Label>
   
    <asp:CheckBoxList runat="server" visible ="true">
        <asp:ListItem Value="Family">אטרקציה משפחתית</asp:ListItem>
        <asp:ListItem Value="Romantic">אטרקציה רומנטית</asp:ListItem>
        <asp:ListItem Value="pregnancy">אטרקציה מותאמת לנשים בהריון</asp:ListItem>
        <asp:ListItem Value="Disabled">אטרקציה מונגשת</asp:ListItem>
        <asp:ListItem Value="nature">אטרקציה בטבע</asp:ListItem>
    </asp:CheckBoxList>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Search Article"></asp:Label>
    <br />
    <asp:TextBox ID="TextBoxSearch" runat="server" visible ="true"></asp:TextBox>
   <%-- <asp:RequiredFieldValidator  ErrorMessage="יש להזין טקסט " runat="server" ControlToValidate="TextBoxSearch"></asp:RequiredFieldValidator>--%>
    <asp:Button ID="ButtonSrerch" runat="server" Text="Button" OnClick="ButtonSrerch_Click" />
    <br />
    <asp:DataList runat="server" ID="ArticlesList" OnItemCommand="ArticlesList_ItemCommand">
        <ItemTemplate>
<asp:Image ID="Image" runat="server" ImageUrl='<%# Bind("Picture") %>'></asp:Image>
<asp:Label runat="server" ID="Title" Text='<%# Bind("Title") %>'></asp:Label>
<asp:Label runat="server" ID="Writer" Text='<%# Bind("Writer") %>'></asp:Label>
<asp:Button ID="buttonArticle" runat="server" Text="מעבר לכתבה המלאה" CommandName="GoToArticle"></asp:Button>
        </ItemTemplate>

    </asp:DataList>
</asp:Content>
