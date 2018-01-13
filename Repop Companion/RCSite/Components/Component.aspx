<%@ Page Title="Component" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="Component.aspx.cs" Inherits="Components_Component" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_MainContent" runat="Server">
    <h1><%=CurrentComponent.displayName %></h1>
    <h2><%=CurrentComponent.displayDescription %></h2>
    <section id="ItemSection" runat="server">
        <h2>Items</h2>
        <asp:Repeater ID="rpt_Items" runat="server">
            <ItemTemplate>
                <asp:HyperLink ID="lnk_Item" Text='<%# Eval("displayName") %>' NavigateUrl='<%# LinkGenerator.GenerateItemLink(Convert.ToInt32(Eval("itemID"))) %>' CssClass="NoLinkStyle" runat="server"></asp:HyperLink><br />
            </ItemTemplate>
        </asp:Repeater>
    </section>
    <section id="IngredientSection" runat="server">
        <h2>Recipes used as Ingredient</h2>
        <asp:Repeater ID="rpt_Ingredients" runat="server">
            <ItemTemplate>
                <asp:HyperLink ID="lnk_Recipe" Text='<%# Eval("displayName") %>' NavigateUrl='<%# LinkGenerator.GenerateRecipeLink(Convert.ToInt32(Eval("recipeID"))) %>' CssClass="NoLinkStyle" runat="server"></asp:HyperLink>
                <asp:HyperLink ID="lnk_RecipeSkill" Text='<%# SkillGateway.GetSkillById(Convert.ToInt32(Eval("skillID"))).displayName %>' NavigateUrl='<%# LinkGenerator.GenerateTradeskillLink(Convert.ToInt32(Eval("skillID"))) %>' CssClass="NoLinkStyle" runat="server"></asp:HyperLink><br />
            </ItemTemplate>
        </asp:Repeater>
    </section>
        <section id="AgentSection" runat="server">
        <h2>Recipes used as Agent</h2>
        <asp:Repeater ID="rpt_Agents" runat="server">
            <ItemTemplate>
                <asp:HyperLink ID="lnk_Recipe" Text='<%# Eval("displayName") %>' NavigateUrl='<%# LinkGenerator.GenerateRecipeLink(Convert.ToInt32(Eval("recipeID"))) %>' CssClass="NoLinkStyle" runat="server"></asp:HyperLink>
                <asp:HyperLink ID="lnk_RecipeSkill" Text='<%# SkillGateway.GetSkillById(Convert.ToInt32(Eval("skillID"))).displayName %>' NavigateUrl='<%# LinkGenerator.GenerateTradeskillLink(Convert.ToInt32(Eval("skillID"))) %>' CssClass="NoLinkStyle" runat="server"></asp:HyperLink><br />
            </ItemTemplate>
        </asp:Repeater>
    </section>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp_ClientScript" runat="Server">
</asp:Content>

