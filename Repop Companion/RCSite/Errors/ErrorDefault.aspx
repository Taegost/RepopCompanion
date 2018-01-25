<%@ Page Title="Error In Page" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="ErrorDefault.aspx.cs" Inherits="Errors_ErrorDefault" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_MainContent" Runat="Server">
        <h1>There was an error</h1>
    <p>We apologize for the inconvenience, we seem to have experienced a problem and the development team has been notified.
        If you have additional informaiton that you feel may be helpful, please take one of the following steps:
        <ul>
            <li>Send an e-mail to RepopCompanion@Gmail.Com</li>
            <li>Create an Issue on <asp:HyperLink runat="server" NavigateUrl="https://github.com/Taegost/RepopCompanion">our GitHub Site</asp:HyperLink></li>
        </ul>

        Thank you for your time.
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp_ClientScript" Runat="Server">
</asp:Content>

