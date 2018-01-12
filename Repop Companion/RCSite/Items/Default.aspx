<%@ Page Title="Item List" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Items_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_MainContent" Runat="Server">
    <h1>Items</h1>
    <asp:Repeater ID="rpt_AllItems" runat="server">
        <ItemTemplate>
            <asp:HyperLink ID="lnk_Item" Text='<%# Eval("displayName") %>' NavigateUrl='<%# LinkGenerator.GenerateItemLink(Convert.ToInt32(Eval("itemID"))) %>' runat="server"></asp:HyperLink><br />
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp_ClientScript" Runat="Server">
</asp:Content>

