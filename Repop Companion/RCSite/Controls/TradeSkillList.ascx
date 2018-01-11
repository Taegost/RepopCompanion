<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TradeSkillList.ascx.cs" Inherits="Controls_TradeSkillList" %>

<asp:Repeater ID="rpt_TradeSkills" runat="server">
    <ItemTemplate>
        <asp:HyperLink ID="Label1" runat="server" Text='<%# Eval("displayName") %>' CssClass='<%# Eval("displayName", "NoWrap NoLinkStyle {0}") %>' NavigateUrl='<%# LinkGenerator.GenerateTradeskillLink(Convert.ToInt32(Eval("skillId"))) %>'></asp:HyperLink>
    </ItemTemplate>
</asp:Repeater>