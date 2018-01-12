<%@ Page Title="Item" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="Item.aspx.cs" Inherits="Items_Item" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_MainContent" Runat="Server">
    <h1><%=CurrentItem.displayName %></h1>

    Value:  <asp:Label ID="lbl_Value" runat="server" Text="n/a"></asp:Label>

    <section id="RecipeBookWrapper" runat="server">
        <asp:Repeater ID="rpt_RecipeBook" runat="server">
            <ItemTemplate>
                Recipe: <asp:HyperLink ID="lnk_Recipe" CssClass="NoLinkStyle" Text='<%# Eval("displayName") %>' NavigateUrl='<%# LinkGenerator.GenerateRecipeLink(Convert.ToInt32(Eval("recipeID"))) %>' runat="server"></asp:HyperLink><br />
            </ItemTemplate>
        </asp:Repeater>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp_ClientScript" Runat="Server">
</asp:Content>

