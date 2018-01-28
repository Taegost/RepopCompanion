<%@ Page Title="Fittings" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Fittings_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_MainContent" Runat="Server">
    <h1>Fittings</h1>
    <asp:Repeater ID="rpt_Fittings" runat="server">
        <ItemTemplate>
            <asp:HyperLink ID="lnk_Fitting" Text='<%# Eval("Name") %>' NavigateUrl='<%# Eval("URL") %>' CssClass="NoLinkStyle" runat="server"></asp:HyperLink><br />
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp_ClientScript" Runat="Server">
</asp:Content>

