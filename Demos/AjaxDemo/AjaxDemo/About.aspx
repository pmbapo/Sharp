<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="AjaxDemo.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="Scripts/myJS.js" type="text/javascript"></script>
    
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        About
    </h2>
    <p>
        Put content here.<asp:Button ID="Button1" runat="server" Text="Button" 
            onclick="Button1_Click" />
    </p>
</asp:Content>
