<%@ Page Title="Item" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="Item.aspx.cs" Inherits="Items_Item" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_MainContent" runat="Server">
    <h1><%=CurrentItem.Name %></h1>
    <p><%=CurrentItem.Description %></p>

    Value: <asp:Label ID="lbl_Value" runat="server" Text="n/a"></asp:Label><br />
    <section id="StackInfoWrapper" visible="false" runat="server">
        Default Stack Size: <asp:Label ID="lbl_DefaultStackSize" runat="server" Text="n/a"></asp:Label><br />
        Max Stack Size: <asp:Label ID="lbl_MaxStackSize" runat="server" Text="n/a"></asp:Label><br />
    </section>
    <section id="PowerInfoWrapper" visible="false" runat="server">
        Power Index: <asp:Label ID="lbl_PowerIndex" runat="server" Text="n/a"></asp:Label><br />
        Power Storage Max: <asp:Label ID="lbl_PowerStorage" runat="server" Text="n/a"></asp:Label><br />
    </section>

    <section id="RecipeBookWrapper" runat="server">
        <br />
        <asp:Repeater ID="rpt_RecipeBook" runat="server">
            <ItemTemplate>
                Recipe: <asp:HyperLink ID="lnk_Recipe" CssClass=<%# Eval("ParentSkill.Name", "NoLinkStyle {0}") %> Text='<%# Eval("Name") %>' NavigateUrl='<%# Eval("URL") %>' runat="server"></asp:HyperLink><br />
            </ItemTemplate>
        </asp:Repeater>
    </section>
    <section id="SpeciesWrapper" runat="server">
                <asp:Repeater ID="rpt_Species" runat="server">
            <ItemTemplate>
                Species/Subsistence: <asp:HyperLink ID="lnk_Recipe" CssClass="NoLinkStyle" Text='<%# Eval("ParentSpecies.Name") + " - " + Eval("Chance") + "%" %>' NavigateUrl='<%# Eval("ParentSpecies.URL") %>' runat="server"></asp:HyperLink><br />
            </ItemTemplate>
        </asp:Repeater>
    </section>

    <section id="ComponentWrapper" runat="server">
        <asp:Repeater ID="rpt_ComponentTypes" runat="server">
            <ItemTemplate>
                Component:
                <asp:HyperLink runat="server" Text='<%# Eval("Name") %>' NavigateUrl='<%# Eval("URL") %>' CssClass="NoLinkStyle"></asp:HyperLink><br />
            </ItemTemplate>
        </asp:Repeater>
        <div id="FilterWrapper" runat="server">
            Filter: <asp:HyperLink ID="lnk_Filter" runat="server" Text="" CssClass="NoLinkStyle"></asp:HyperLink><br />
        </div>
        <section id="RecipeWrapper" runat="server">
            <h2>Produced in Recipe</h2>
            <asp:GridView ID="grd_Recipe" runat="server" AutoGenerateColumns="False" OnRowDataBound="grd_Recipe_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:HyperLink ID="lnk_Name" runat="server" CssClass="NoLinkStyle"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Skill">
                        <ItemTemplate>
                            <asp:HyperLink ID="lnk_Skill" runat="server" CssClass="NoLinkStyle"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </section>
        <section id="IngredientWrapper" runat="server">
            <h2>Used in Recipe as Ingredient</h2>
            <asp:GridView ID="grd_Ingredient" runat="server" AutoGenerateColumns="False" OnRowDataBound="grd_Ingredient_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:HyperLink ID="lnk_Name" runat="server" CssClass="NoLinkStyle"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Skill">
                        <ItemTemplate>
                            <asp:HyperLink ID="lnk_Skill" runat="server" CssClass="NoLinkStyle"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Item Result">
                        <ItemTemplate>
                            <asp:HyperLink ID="lnk_Result" runat="server" CssClass="NoLinkStyle"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </section>
        <section id="AgentWrapper" runat="server">
            <h2>Used in Recipe as Agent</h2>
            <asp:GridView ID="grd_Agent" runat="server" AutoGenerateColumns="False" OnRowDataBound="grd_Agent_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:HyperLink ID="lnk_Name" runat="server" CssClass="NoLinkStyle"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Skill">
                        <ItemTemplate>
                            <asp:HyperLink ID="lnk_Skill" runat="server" CssClass="NoLinkStyle"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Result">
                        <ItemTemplate>
                            <asp:HyperLink ID="lnk_Result" runat="server" CssClass="NoLinkStyle"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </section>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp_ClientScript" runat="Server">
</asp:Content>

