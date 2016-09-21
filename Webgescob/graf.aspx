<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="graf.aspx.cs" Inherits="WebNif.graf" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>graficas</title>
    <link rel="icon" href="images/favicon.ico" type="image/x-icon" />
    <!-- Bootstrap 3.2.0 stylesheet -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Awesome Icon stylesheet -->
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- Pretty Photo stylesheet -->
    <link href="css/prettyPhoto.css" rel="stylesheet" />
    <!-- Custom stylesheet -->
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/white.css" rel="stylesheet" type="text/css" />
    <!-- Custom Responsive stylesheet -->
    <link href="css/responsive.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div id="myCarousel" class="carousel slide" data-ride="carousel">
                <!-- Indicators -->
                <ol class="carousel-indicators">
                    <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                    <li data-target="#myCarousel" data-slide-to="1"></li>
                    <li data-target="#myCarousel" data-slide-to="2"></li>
                    <li data-target="#myCarousel" data-slide-to="3"></li>
                </ol>

                <!-- Wrapper for slides -->
                <div class="carousel-inner" role="listbox">
                    <div class="item active">
                        <asp:Chart ID="Chart1" runat="server" Palette="Fire" Height="650px" Width="800px">
                            <Titles>
                                <asp:Title ShadowOffset="3" Name="Items" />
                            </Titles>
                            <Legends>
                                <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default" LegendStyle="Row" />
                            </Legends>
                            <Series>
                                <asp:Series Name="Interés" />
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1" BorderWidth="2" />
                            </ChartAreas>
                        </asp:Chart>
                    </div>

                    <div class="item">
                        <asp:Chart ID="Chart2" runat="server" Palette="Excel" Height="650px" Width="800px">
                            <Titles>
                                <asp:Title ShadowOffset="3" Name="Items" />
                            </Titles>
                            <Legends>
                                <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default" LegendStyle="Row" />
                            </Legends>
                            <Series>
                                <asp:Series Name="Nuevo capital" />
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea2" BorderWidth="0" />
                            </ChartAreas>
                        </asp:Chart>
                    </div>

                    <div class="item">
                        <asp:Chart ID="Chart3" runat="server" Height="650px" Width="800px">
                            <Titles>
                                <asp:Title ShadowOffset="3" Name="Items" />
                            </Titles>
                            <Legends>
                                <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default" LegendStyle="Row" />
                            </Legends>
                            <Series>
                                <asp:Series Name="Sobretasa" />
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea3" BorderWidth="0" />
                            </ChartAreas>
                        </asp:Chart>
                    </div>

                    <div class="item">
                        <asp:Chart ID="Chart4" runat="server" Height="650px" Width="800px">
                            <Titles>
                                <asp:Title ShadowOffset="3" Name="Items" />
                            </Titles>
                            <Legends>
                                <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default" LegendStyle="Row" />
                            </Legends>
                            <Series>
                                <asp:Series Name="Sobretasa" />
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea4" BorderWidth="0" />
                            </ChartAreas>
                        </asp:Chart>
                    </div>
                </div>

                <!-- Left and right controls -->
                <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
                    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div>

        </div>



        <!-- jQuery -->
        <script src="http://code.jquery.com/jquery.min.js"></script>
        <script src="js/jquery.js"></script>
        <!-- Modernizr js -->
        <script src="js/modernizr-latest.js"></script>
        <!-- Bootstrap 3.2.0 js -->
        <script src="js/bootstrap.min.js"></script>
        <!-- ScrollTo js -->
        <script src="js/jquery.scrollto.min.js"></script>
        <!-- LocalScroll js -->
        <script src="js/jquery.localScroll.min.js"></script>
        <!-- jQuery Parallax plugin -->
        <script src="js/jquery.parallax-1.1.3.js"></script>
        <!-- Skrollr js plugin -->
        <script src="js/skrollr.min.js"></script>
        <!-- jQuery One Page Nav Plugin -->
        <script src="js/jquery.nav.js"></script>
        <!-- jQuery Pretty Photo Plugin -->
        <script src="js/jquery.prettyPhoto.js"></script>
        <!-- Custom JS -->
        <script src="js/main.js"></script>
        <script>
            jQuery(document).ready(function ($) {
                "use strict";

                jQuery("a[data-rel^='prettyPhoto']").prettyPhoto({ social_tools: false });
            });
        </script>



    </form>
</body>
</html>
