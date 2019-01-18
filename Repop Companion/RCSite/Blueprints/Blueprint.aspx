<%@ Page Title="Blueprint" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="Blueprint.aspx.cs" Inherits="Blueprints_Blueprint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_MainContent" runat="Server">
    <h1><%=CurrentBlueprint.Name %></h1>
    <section id="RecipeWrapper" runat="server">
        <h2>Recipes</h2>
        <asp:GridView ID="grd_Recipes" runat="server" AutoGenerateColumns="False" OnRowDataBound="grd_Recipes_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="Recipe">
                    <ItemTemplate>
                        <asp:HyperLink ID="lnk_Recipe" Text='<%# Eval("Name") %>' NavigateUrl='<%# Eval("URL") %>' CssClass="NoLinkStyle" runat="server"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Skill">
                    <ItemTemplate>
                        <asp:HyperLink ID="lnk_RecipeSkill" Text='<%# Eval("ParentSkill.Name") %>' NavigateUrl='<%# Eval("ParentSkill.URL") %>' CssClass="NoLinkStyle" runat="server"></asp:HyperLink><br />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp_ClientScript" runat="Server">
</asp:Content>

