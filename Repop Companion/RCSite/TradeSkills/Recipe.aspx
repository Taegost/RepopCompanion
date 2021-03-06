﻿<%@ Page Title="Recipe" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="Recipe.aspx.cs" Inherits="TradeSkills_Recipe" %>

<%@ Register Src="~/Controls/TradeSkillList.ascx" TagPrefix="uc1" TagName="TradeSkillList" %>
<%@ Register Src="~/Controls/RecipeResultsControl.ascx" TagPrefix="uc1" TagName="RecipeResultsControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_MainContent" runat="Server">
    <div class="Banner">
        <uc1:TradeSkillList runat="server" ID="TradeSkillList" />
    </div>
    <div id="RecipeWrapper" runat="server">
        <h1><%=CurrentRecipe.Name %></h1>
        <table id="tbl_Main" class="auto-style1" runat="server">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Skill:"></asp:Label>
                </td>
                <td>
                    <asp:HyperLink ID="lnk_Skill" runat="server" CssClass="NoLinkStyle"></asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label2" runat="server" Text="Recipe Book:"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:HyperLink ID="lnk_RecipeBook" runat="server" CssClass="NoLinkStyle"></asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Recipe Steps:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbl_Steps" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Ingredient Weight:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbl_WeightIngredient" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Agent Weight:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbl_WeightAgent" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
        </table>

        <h2>Difficulty</h2>
        <asp:GridView ID="grd_Difficulty" runat="server" AutoGenerateColumns="False" OnRowDataBound="grd_Difficulty_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="Level">
                    <ItemTemplate>
                        <asp:Label ID="lbl_LevelColumn" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="MinF" HeaderText="MinF" />
                <asp:BoundField DataField="MinD" HeaderText="MinD" />
                <asp:BoundField DataField="MinC" HeaderText="MinC" />
                <asp:BoundField DataField="MinB" HeaderText="MinB" />
                <asp:BoundField DataField="MinA" HeaderText="MinA" />
                <asp:BoundField DataField="MinAA" HeaderText="MinAA" />
                <asp:BoundField DataField="Over1" HeaderText="Over1" />
                <asp:BoundField DataField="Over2" HeaderText="Over2" />
            </Columns>
        </asp:GridView>

        <h2>Ingredients</h2>
        <asp:GridView ID="grd_Ingredients" runat="server" AutoGenerateColumns="False" OnRowDataBound="grd_Ingredients_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:HyperLink ID="lnk_IngredientName" runat="server" CssClass="NoLinkStyle"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Count" HeaderText="Qty" />
                <asp:BoundField DataField="Weight" HeaderText="Weight" />
                <asp:BoundField DataField="Slot" HeaderText="Slot" />
            </Columns>
        </asp:GridView>

        <h2>Agents</h2>
        <asp:GridView ID="grd_Agents" runat="server" AutoGenerateColumns="False" OnRowDataBound="grd_Agents_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:HyperLink ID="lnk_AgentName" runat="server" CssClass="NoLinkStyle"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Count" HeaderText="Qty" />
                <asp:BoundField DataField="Weight" HeaderText="Weight" />
            </Columns>
        </asp:GridView>

        <h2>Results</h2>
        <h3>Main</h3>
        <uc1:RecipeResultsControl runat="server" id="ctl_MainResults" />
        <div id="ByProducts" runat="server">
            <h3>Byproduct</h3>
            <uc1:RecipeResultsControl runat="server" ID="ctl_ByProduct1" GroupID="2" />
            <uc1:RecipeResultsControl runat="server" ID="ctl_ByProduct2" GroupID="3" />
            <uc1:RecipeResultsControl runat="server" ID="ctl_ByProduct3" GroupID="4" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp_ClientScript" runat="Server">
</asp:Content>

