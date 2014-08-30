<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="UndirectedGraphWebClient.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Undirected Graph Application</title>
    <script type="text/javascript" src="Scripts/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="Scripts/raphael-min.js"></script>
    <script type="text/javascript" src="Scripts/dracula_graffle.js"></script>
    <script type="text/javascript" src="Scripts/dracula_graph.js"></script>
    <script type="text/javascript" src="Scripts/application.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:scriptmanager runat="server">
        <services>
            <asp:ServiceReference Path="~/WebServices/NodeWS.svc" />
        </services>
    </asp:scriptmanager>
    <div>

    </div>
    <div id="content">
    <button id="redraw" onclick="redraw();">Redraw</button>    </div>
    </form>

    <div id="canvas"></div>

</body>
</html>
