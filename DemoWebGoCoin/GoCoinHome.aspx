<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GoCoinHome.aspx.cs" Inherits="DemoWebGoCoin.GoCoinHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Go Coin
    </h2>
              
            <p>
            <asp:Label ID="lblAccessToken" runat="server" Text="AccessToken"></asp:Label>
             </br>
            <asp:Literal ID="LitAccessToken" Text="" runat="server" />
            </p>
   
</asp:Content>
