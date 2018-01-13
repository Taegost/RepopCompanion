<%@ Page Title="Item" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="Item.aspx.cs" Inherits="Items_Item" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_MainContent" Runat="Server">
    <h1><%=CurrentItem.displayName %></h1>

    Value:  <asp:Label ID="lbl_Value" runat="server" Text="n/a"></asp:Label> <br />
    Default Stack Size: <asp:Label ID="lbl_DefaultStackSize" runat="server" Text="n/a"></asp:Label><br />
    Max Stack Size: <asp:Label ID="lbl_MaxStackSize" runat="server" Text="n/a"></asp:Label>

    <section id="RecipeBookWrapper" runat="server">
        <asp:Repeater ID="rpt_RecipeBook" runat="server">
            <ItemTemplate>
                Recipe: <asp:HyperLink ID="lnk_Recipe" CssClass="NoLinkStyle" Text='<%# Eval("displayName") %>' NavigateUrl='<%# LinkGenerator.GenerateRecipeLink(Convert.ToInt32(Eval("recipeID"))) %>' runat="server"></asp:HyperLink><br />
            </ItemTemplate>
        </asp:Repeater>
    </section>

    <section id="ComponentWrapper" runat="server">
        <asp:Repeater ID="rpt_ComponentTypes" runat="server">
            <ItemTemplate>
                Component: <asp:HyperLink runat="server" Text='<%# Eval("displayName") %>' NavigateUrl='<%# LinkGenerator.GenerateComponentLink(Convert.ToInt32(Eval("componentID"))) %>' CssClass="NoLinkStyle"></asp:HyperLink><br />
            </ItemTemplate>
        </asp:Repeater>
        <asp:Repeater ID="rpt_FilterTypes" runat="server">
            <ItemTemplate>
                Filter: <asp:HyperLink runat="server" Text='<%# Eval("displayName") %>' NavigateUrl='<%# LinkGenerator.GenerateFilterLink(Convert.ToInt32(Eval("filterID"))) %>' CssClass="NoLinkStyle"></asp:HyperLink><br />
            </ItemTemplate>
        </asp:Repeater>
        <h2>Produced in Recipe</h2>
        <asp:GridView ID="grd_Recipe" runat="server"></asp:GridView>
        
        <h2>Used in Recipe as Ingredient</h2>
        <asp:GridView ID="grd_Ingredient" runat="server"></asp:GridView>

        <h2>Used in Recipe as Agent</h2>
        <asp:GridView ID="grd_Agent" runat="server"></asp:GridView>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp_ClientScript" Runat="Server">
</asp:Content>

