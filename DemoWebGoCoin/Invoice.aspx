<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="DemoWebGoCoin.Invoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <h2>
        Invoices
    </h2>
              
            <p>
            <asp:Label ID="lblAccessToken" runat="server" Text="Invoices"></asp:Label>
             </br>
            <asp:Literal ID="LitInvoices" Text="" runat="server" />
            </p>
   
</asp:Content>
