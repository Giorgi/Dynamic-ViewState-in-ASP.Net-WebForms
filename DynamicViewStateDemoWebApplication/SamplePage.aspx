<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="SamplePage.aspx.cs" Inherits="DynamicViewStateDemoWebApplication.SamplePage" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <p>
        <asp:Label runat="server" ID="loadLabel"></asp:Label>
        <br />
        <asp:Button runat="server" ID="postback" Text="PostBack" />
    </p>
</asp:Content>
