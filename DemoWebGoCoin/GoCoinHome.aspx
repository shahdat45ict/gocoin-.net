<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GoCoinHome.aspx.cs" Inherits="DemoWebGoCoin.GoCoinHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
       function windowOpen() {
           myWindow = window.open('https://llamacoin-dashboard.herokuapp.com/login', '_blank', 'width=650,height=350, scrollbars=no,resizable=no')

           myWindow.focus()
       }
    </script>
   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Go Coin
    </h2>
        <p>
            You can log into the dashboard by clicking the below button, to create your own OAuth client. That will create a key and secret that you can use to obtain a token.
        </p>
       
            <p>
            <asp:Label ID="lblClient_Id" runat="server" Text="Client Id"></asp:Label>
            <asp:TextBox ID="txtClient_Id" runat="server"></asp:TextBox>
            </p>
            <p>
            <asp:Label ID="lblClient_Secret" runat="server" Text="Client Secret Key"></asp:Label>
            <asp:TextBox ID="txtClient_Secret" runat="server"></asp:TextBox>
            </p>
            <p>
            <asp:Label ID="lblRedirect_Url" runat="server" Text="Redirect Url"></asp:Label>
            <asp:TextBox ID="txtRedirect_Url" runat="server"></asp:TextBox>
            </p>
            <p>
                <%--<asp:Button ID="Button1" runat="server" Text="Button" />
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click" />
                 <input type="button" value="Open Window" onclick="windowOpen()">--%>

                 <asp:Button ID="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click"  />
            </p>
       
   
</asp:Content>
