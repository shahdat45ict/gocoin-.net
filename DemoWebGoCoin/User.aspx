<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="DemoWebGoCoin.User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <asp:Label ID="lblAccessToken" runat="server" Text="AccessToken"></asp:Label>
    <h2>
        User 
    </h2>

<p>
    <asp:Label ID="Label1" runat="server" Text="User"></asp:Label>
    </br>
    <asp:Literal ID="LitUser" Text="" runat="server" />
</p>
</asp:Content>
