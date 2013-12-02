<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GetGoCoinCalls.aspx.cs" Inherits="DemoWebGoCoin.GetGoCoinCalls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Go Coin Code GenegratE
    </h2>
     <p>
            <asp:Label ID="lblClient_Id" runat="server" Text="Client Id"></asp:Label>
            <asp:TextBox ID="txtClient_Id" runat="server" ReadOnly="True"></asp:TextBox>
            </p>
            <p>
            <asp:Label ID="lblClient_Secret" runat="server" Text="Client Secret Key"></asp:Label>
            <asp:TextBox ID="txtClient_Secret" runat="server" ReadOnly="True"></asp:TextBox>
            </p>
            <p>
            <asp:Label ID="lblRedirect_Url" runat="server" Text="Redirect Url"></asp:Label>
            <asp:TextBox ID="txtRedirect_Url" runat="server" ReadOnly="True"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lblToken_Code" runat="server" Text="Get Code"></asp:Label>
                <asp:TextBox ID="txtToken_Code" runat="server" ReadOnly="True"></asp:TextBox>
            </p>
            <p>
                 <asp:Button ID="btnGetCurrentGoCoinUser" runat="server" Text="Call for GoCoin API" onclick="GetCurrentGoCoinUser_Click" />
            </p>

</asp:Content>
