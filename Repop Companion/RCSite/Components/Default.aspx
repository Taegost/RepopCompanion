<%@ Page Title="Components" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Components_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_MainContent" runat="Server">
    <h1>Components</h1>
    <asp:Repeater ID="rpt_AllComponents" runat="server">
        <ItemTemplate>
            <asp:HyperLink ID="lnk_Component" Text='<%# Eval("displayName") %>' NavigateUrl='<%# LinkGenerator.GenerateComponentLink(Convert.ToInt32(Eval("componentID"))) %>' runat="server"></asp:HyperLink><br />
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp_ClientScript" runat="Server">
</asp:Content>

