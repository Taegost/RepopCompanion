﻿<%@ Page Title="Species" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="Species.aspx.cs" Inherits="Subsistence_Species" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp_MainContent" runat="Server">
    <h1><%=CurrentSpecies.Name %></h1>
    <p><%=CurrentSpecies.Description %></p>
    <p>Extraction Type: <%=CurrentSpecies.ExtractionMethod %></p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp_ClientScript" runat="Server">
</asp:Content>

