<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="AjaxDemo._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

    <script src="Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script>
        $(document).ready(function () {

            $(".import").bind("click", function () {
 

                VarmyText = $("#myText").val();
                $.post("ajaxSaveToServer.aspx", { option: "import", myText: VarmyText }, function (data) {
                    $("#targetDiv").html(data);
                });
            });
        });
	
    </script>
    
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to ASP.NET!
    </h2>
    <input id="myText" type="text" />
 				<span class="import">Import</span>
    <asp:Button ID="Button1" runat="server" Text="Button" />
    <p>
        To learn more about ASP.NET visit <a href="http://www.asp.net" title="ASP.NET Website">www.asp.net</a>.
    </p>
    <p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
            title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
    </p>
    <asp:TextBox name="NOWAY" ID="TextBox1" runat="server"></asp:TextBox>
    <div id="targetDiv"> </div>
</asp:Content>
