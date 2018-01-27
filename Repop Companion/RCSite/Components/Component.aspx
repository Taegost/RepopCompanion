<%@ Page Title="Component" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="Component.aspx.cs" Inherits="Components_Component" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_MainContent" runat="Server">
    <h1><%=CurrentComponent.Name %></h1>
    <p><%=CurrentComponent.Description %></p>
    <section id="ItemWrapper" runat="server">
        <h2>Items</h2>
        <asp:Repeater ID="rpt_Items" runat="server">
            <ItemTemplate>
                <asp:HyperLink ID="lnk_Item" Text='<%# Eval("Name") %>' NavigateUrl='<%# Eval("URL") %>' CssClass="NoLinkStyle" runat="server"></asp:HyperLink><br />
            </ItemTemplate>
        </asp:Repeater>
    </section>
    <section id="IngredientWrapper" runat="server">
        <h2>Recipes used as Ingredient</h2>
        <asp:GridView ID="grd_Ingredients" runat="server" AutoGenerateColumns="False" OnRowDataBound="grd_Ingredients_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="Recipe">
                    <ItemTemplate>
                        <asp:HyperLink ID="lnk_Recipe" Text='<%# Eval("displayName") %>' NavigateUrl='<%# LinkGenerator.GenerateRecipeLink(Convert.ToInt32(Eval("recipeID"))) %>' CssClass="NoLinkStyle" runat="server"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Skill">
                    <ItemTemplate>
                        <asp:HyperLink ID="lnk_RecipeSkill" Text='<%# SkillGateway.SkillGetById(Convert.ToInt32(Eval("skillID"))).displayName %>' NavigateUrl='<%# LinkGenerator.GenerateTradeskillLink(Convert.ToInt32(Eval("skillID"))) %>' CssClass="NoLinkStyle" runat="server"></asp:HyperLink><br />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </section>
    <section id="AgentWrapper" runat="server">
        <h2>Recipes used as Agent</h2>
        <asp:GridView ID="grd_Agents" runat="server" AutoGenerateColumns="False" OnRowDataBound="grd_Agents_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="Recipe">
                    <ItemTemplate>
                        <asp:HyperLink ID="lnk_Recipe" Text='<%# Eval("displayName") %>' NavigateUrl='<%# LinkGenerator.GenerateRecipeLink(Convert.ToInt32(Eval("recipeID"))) %>' CssClass="NoLinkStyle" runat="server"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Skill">
                    <ItemTemplate>
                        <asp:HyperLink ID="lnk_RecipeSkill" Text='<%# SkillGateway.SkillGetById(Convert.ToInt32(Eval("skillID"))).displayName %>' NavigateUrl='<%# LinkGenerator.GenerateTradeskillLink(Convert.ToInt32(Eval("skillID"))) %>' CssClass="NoLinkStyle" runat="server"></asp:HyperLink><br />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>
    </section>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp_ClientScript" runat="Server">
</asp:Content>

