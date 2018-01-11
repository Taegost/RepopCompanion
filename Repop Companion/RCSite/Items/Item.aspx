<%@ Page Title="Item" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="Item.aspx.cs" Inherits="Items_Item" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_MainContent" Runat="Server">
    <h1><%=CurrentItem.displayName %></h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp_ClientScript" Runat="Server">
</asp:Content>

