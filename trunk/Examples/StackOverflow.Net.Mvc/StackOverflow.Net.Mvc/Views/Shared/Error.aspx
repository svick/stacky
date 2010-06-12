<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<System.Web.Mvc.HandleErrorInfo>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>:(</title>
</head>
<body>
    <div class="error-sad"><img src="../../Content/sad01.png" /><img src="../../Content/sad02.png" /></div>
    <div class="error-header">
        The saddest thing ever just happened :(
    </div>
    <div="error-message">
        <%: Model.Exception.Message %>
    </div>
    <div="error-inner-message">
        <% if (Model.Exception.InnerException != null)
           { %>
                <%: Model.Exception.InnerException.Message%><br />
                <%= Model.Exception.InnerException.StackTrace.Replace(Environment.NewLine, "<br />") %>
           <% } %>
    </div>
    <div class="error-sad"><img src="../../Content/sad03.png" /><img src="../../Content/sad04.png" /></div>
</body>
</html>

