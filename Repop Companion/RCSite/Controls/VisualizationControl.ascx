<%@ Control Language="C#" AutoEventWireup="true" CodeFile="VisualizationControl.ascx.cs" Inherits="Controls_VisualizationControl" %>
<asp:Table ID="Table1" runat="server">
    <asp:TableRow>
        <asp:TableCell ID="recipeCell" runat="server" >
            <asp:HyperLink ID="lnk_ItemName" runat="server" CssClass="NoLinkStyle"></asp:HyperLink><br />
            <asp:HyperLink ID="lnk_ItemRecipe" runat="server" CssClass="NoLinkStyle"></asp:HyperLink>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Repeater ID="rpt_Ingredients" runat="server">
                <ItemTemplate>
                    <asp:HyperLink ID="lnk_Name" runat="server" Text='<%# Eval("CraftingComponent.Name") %>' NavigateUrl='<%# Eval("URL") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:Repeater>
        </asp:TableCell>
                <asp:TableCell>
            <asp:Repeater ID="rpt_SubIngredients" runat="server"></asp:Repeater>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
