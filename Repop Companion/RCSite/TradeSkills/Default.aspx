<%@ Page Title="Trade Skills" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="TradeSkills_Default" %>

<%@ Register Src="~/Controls/TradeSkillList.ascx" TagPrefix="uc1" TagName="TradeSkillList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_MainContent" runat="Server">
    <div class="Banner">
        <uc1:TradeSkillList runat="server" ID="TradeSkillList" />
    </div>
    <section id="TradeskillWrapper" runat="server">
        <h1><%=CurrentSkill.Name %></h1>
        <section id="RecipeWrapper" class="SectionWrapper">
            <div id="RecipeHeader">
                <h2>Recipes</h2>
            </div>
            <asp:Repeater ID="rpt_Recipes" runat="server">
                <ItemTemplate>
                    <div id="RecipeCard" class="CardMain <%=CurrentSkill.Name %>">
                        <asp:HyperLink runat="server" Text='<%# Eval("Name") %>' NavigateUrl='<%# Eval("URL") %>' CssClass="CardTitle"></asp:HyperLink><br />
                        <asp:Label runat="server" Text='<%# Eval("Description") %>' CssClass="CardDescription"></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </section>
        <section id="ItemWrapper" class="SectionWrapper" runat="server">
            <div id="ItemHeader">
                <h2>Items</h2>
            </div>
            <asp:Repeater ID="rpt_Items" runat="server" OnItemDataBound="rpt_Items_ItemDataBound">
                <ItemTemplate>
                    <div id="ItemCard" class="CardMain <%=CurrentSkill.Name %>">
                        <asp:HyperLink runat="server" Text='<%# Eval("Name") %>' NavigateUrl='<%# Eval("URL") %>' CssClass="CardTitle"></asp:HyperLink><br />
                        <asp:HyperLink ID="lnk_RecipeLink" runat="server" CssClass="NoLinkStyle"></asp:HyperLink><br />
                        <asp:Label runat="server" Text='<%# Eval("Description") %>' CssClass="CardDescription"></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </section>
        <section id="FittingWrapper" class="SectionWrapper" runat="server">
            <div id="FittingHeader">
                <h2>Fittings</h2>
            </div>
            <asp:Repeater ID="rpt_Fittings" runat="server" OnItemDataBound="rpt_Fittings_ItemDataBound">
                <ItemTemplate>
                    <div id="FittingCard" class="CardMain <%=CurrentSkill.Name %>">
                        <asp:HyperLink runat="server" Text='<%# Eval("Name") %>' NavigateUrl='<%# Eval("URL") %>' CssClass="CardTitle"></asp:HyperLink><br />
                        <asp:HyperLink ID="lnk_RecipeLink" runat="server" CssClass="NoLinkStyle"></asp:HyperLink><br />
                        <asp:Label runat="server" Text='<%# Eval("Description") %>' CssClass="CardDescription"></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </section>
        <section id="BlueprintWrapper" class="SectionWrapper" runat="server">
            <div id="BlueprintHeader">
                <h2>Blueprints</h2>
            </div>
            <asp:Repeater ID="rpt_Blueprints" runat="server" OnItemDataBound="rpt_Blueprints_ItemDataBound">
                <ItemTemplate>
                    <div id="BlueprintCard" class="CardMain <%=CurrentSkill.Name %>">
                        <asp:HyperLink runat="server" Text='<%# Eval("Name") %>' NavigateUrl='<%# Eval("URL") %>' CssClass="CardTitle"></asp:HyperLink><br />
                        <asp:HyperLink ID="lnk_RecipeLink" runat="server" CssClass="NoLinkStyle"></asp:HyperLink><br />
                        <asp:Label runat="server" Text='<%# Eval("IsHousingStructure", "Housing Structure: {0}") %>' CssClass="CardDescription"></asp:Label><br />
                        <asp:Label runat="server" Text='<%# Eval("IsSiegingUnit", "Sieging Unit: {0}") %>' CssClass="CardDescription"></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </section>
    </section>
    <asp:PlaceHolder ID="NoRecords" runat="server">
        <p>Please select a tradeskill from the menu above to get started.</p>
    </asp:PlaceHolder>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp_ClientScript" runat="Server">
    <script>
        // This isn't working and I don't know why.  Will need to figure it out later.  .animate *almost* works.
        //$(document).ready(function () {
        //    $('#RecipeHeader').click(function () {
        //        $('#RecipeWrapper').toggleClass('CollapsePanelHeader');
        //    });
        //});
    </script>
</asp:Content>

