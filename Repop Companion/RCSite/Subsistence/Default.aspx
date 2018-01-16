<%@ Page Title="Species/Subsistence" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Subsistence_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_MainContent" Runat="Server">
        <h1>Species/Subsistence</h1>
    <asp:Repeater ID="rpt_Species" runat="server">
        <ItemTemplate>
            <asp:HyperLink ID="lnk_Filter" Text='<%# Eval("displayName") %>' NavigateUrl='<%# LinkGenerator.GenerateSpeciesLink(Convert.ToInt32(Eval("speciesID"))) %>' CssClass="NoLinkStyle" runat="server"></asp:HyperLink><br />
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp_ClientScript" Runat="Server">
</asp:Content>

