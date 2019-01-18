<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TradeSkillList.ascx.cs" Inherits="Controls_TradeSkillList" %>

<asp:Repeater ID="rpt_TradeSkills" runat="server">
    <ItemTemplate>
        <asp:HyperLink ID="Label1" runat="server" Text='<%# Eval("Name") %>' CssClass='<%# Eval("Name", "NoWrap NoLinkStyle {0}") %>' NavigateUrl='<%# Eval("URL") %>'></asp:HyperLink>
    </ItemTemplate>
</asp:Repeater>