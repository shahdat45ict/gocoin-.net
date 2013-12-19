<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="User_update.aspx.cs" Inherits="DemoWebGoCoin.User_update" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <h2>
        User Updated
    </h2>
              
            <p>
            <asp:Label ID="lblAccessToken" runat="server" Text="Updated User"></asp:Label>
             </br>
            <asp:Literal ID="Litupdated_user" Text="" runat="server" />
            </p>
</asp:Content>
