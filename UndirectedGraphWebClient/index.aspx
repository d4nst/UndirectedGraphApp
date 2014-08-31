<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="UndirectedGraphWebClient.index" %>

<!DOCTYPE html>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Undirected Graph Application</title>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js"></script>
    <script type="text/javascript" src="http://cytoscape.github.io/cytoscape.js/api/cytoscape.js-latest/cytoscape.min.js"></script>
    <script type="text/javascript" src="Scripts/application.js"></script>
    <style>
        body { 
          font: 14px helvetica neue, helvetica, arial, sans-serif;
        }

        #cy {
          height: 85%;
          width: 95%;
          position: absolute;
          left: 2.5%;
          top: 8%;
          bottom: 30px;
          border-width: 1px;
          border-style: solid;
        }

        #header {
            margin-left: 40px;
            margin-top: 25px;
        }

    </style>
</head>
<body>

    <form id="form1" runat="server">
    <asp:scriptmanager runat="server">
        <services>
            <asp:ServiceReference Path="~/WebServices/GraphNodeWS.svc" />
            <asp:ServiceReference Path="~/WebServices/PathFinderWS.svc" />
        </services>
    </asp:scriptmanager>
    </form>

    <div id="header">
        <button id="btnRedraw">Redraw</button>
        <button id="btnShortestPath">Calculate shortest path</button>
    </div>

    <div id="cy"></div>

</body>
</html>
