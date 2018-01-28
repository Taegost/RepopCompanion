<%@ Page Title="All Filters" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Filters_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_MainContent" runat="Server">
    <h1>Filters</h1>
    <asp:Repeater ID="rpt_Filters" runat="server">
        <ItemTemplate>
            <asp:HyperLink ID="lnk_Filter" Text='<%# Eval("Name") %>' NavigateUrl='<%# Eval("URL") %>' CssClass="NoLinkStyle" runat="server"></asp:HyperLink><br />
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp_ClientScript" runat="Server">
</asp:Content>

