<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajaxSaveToServer.aspx.cs" Inherits="AjaxDemo.ajaxSaveToServer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <%  if (Request["options"] != ""  )   Response.Write(Request["myText"]); %>
     Dette er vores svar fra serveren.
    </div>
    </form>
</body>
</html>
