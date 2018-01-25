<%@ Page Title="File Not Found" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="Error404.aspx.cs" Inherits="Errors_Error404" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_MainContent" Runat="Server">
    <h1>File Not Found</h1>
    <p>The page you requested could not be found.  
        If you feel this page was reached in error, please take one of the following steps:
        <ul>
            <li>Send an e-mail to RepopCompanion@Gmail.Com</li>
            <li>Create an Issue on <asp:HyperLink runat="server" NavigateUrl="https://github.com/Taegost/RepopCompanion">our GitHub Site</asp:HyperLink></li>
        </ul>

        Thank you for your time.
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp_ClientScript" Runat="Server">
</asp:Content>

