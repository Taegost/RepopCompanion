<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RecipeResultsControl.ascx.cs" Inherits="Controls_RecipeResultsControl" %>

        <asp:GridView ID="grd_Results" runat="server" AutoGenerateColumns="False" OnRowDataBound="grd_Results_RowDataBound" AllowSorting="True">
            <Columns>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Hyperlink ID="lnk_ResultName" runat="server" CssClass="NoLinkStyle"></asp:Hyperlink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Count" HeaderText="Qty" />
                <asp:TemplateField HeaderText="Min. Grade">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Grade" runat="server" Text='<%# Bind("MinimumGrade") %>' ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Difficulty">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Difficulty" runat="server" Text='<%# Bind("Difficulty") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ingredient1">
                    <ItemTemplate>
                        <asp:Hyperlink ID="lnk_Ingredient1" runat="server" CssClass="NoLinkStyle"></asp:Hyperlink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ingredient2">
                    <ItemTemplate>
                        <asp:Hyperlink ID="lnk_Ingredient2" runat="server" CssClass="NoLinkStyle"></asp:Hyperlink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ingredient3">
                    <ItemTemplate>
                        <asp:Hyperlink ID="lnk_Ingredient3" runat="server" CssClass="NoLinkStyle"></asp:Hyperlink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ingredient4">
                    <ItemTemplate>
                        <asp:Hyperlink ID="lnk_Ingredient4" runat="server" CssClass="NoLinkStyle"></asp:Hyperlink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>