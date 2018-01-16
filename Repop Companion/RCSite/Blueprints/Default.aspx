<%@ Page Title="Blueprints" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Blueprints_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_MainContent" Runat="Server">
    <h1>Blueprints</h1>
    <asp:Repeater ID="rpt_Blueprints" runat="server">
        <ItemTemplate>
            <asp:HyperLink ID="lnk_Blueprint" Text='<%# Eval("displayName") %>' NavigateUrl='<%# LinkGenerator.GenerateBlueprintLink(Convert.ToInt32(Eval("structureID"))) %>' CssClass="NoLinkStyle" runat="server"></asp:HyperLink><br />
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp_ClientScript" Runat="Server">
</asp:Content>

