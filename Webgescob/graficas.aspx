<%@ Page Title="Graficas" Language="C#" AutoEventWireup="true" CodeBehind="graficas.aspx.cs" Inherits="WebNif.graficas" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE HTML>
<html>

<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <title>Grafica</title>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
    <style type="text/css">
        #container, #sliders {
            min-width: 310px;
            max-width: 800px;
            margin: 0 auto;
        }

        #container {
            height: 400px;
            min-width: 310px;
            max-width: 1024px;
            margin: 0 auto;
        }
    </style>
</head>

<body>
    <script src="js/highcharts.js"></script>
    <script src="js/highcharts-3d.js"></script>
    <script src="js/modules/exporting.js"></script>

    <form id="form1" runat="server">
        <asp:Panel ID="Panel1" runat="server" Height="60px"></asp:Panel>
        <div id="container" style="height: 400px"></div>
  </form>
</body>
</html>

