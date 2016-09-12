<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="in.aspx.cs" Inherits="WebNif._in" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="es">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>gescob</title>
    <link rel="icon" href="images/favicon.ico" type="image/x-icon" />
    <!-- Bootstrap 3.2.0 stylesheet -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Awesome Icon stylesheet -->
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- Owl Carousel stylesheet -->
    <link href="css/owl.carousel.css" rel="stylesheet" />
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

        <!-- ====== M ====== -->
        <div class="navigation">
            <div class="navbar navbar-default" role="navigation">
                <div class="container">
                    <div class="navbar navbar-default">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" runat="server">gescob</a>


                        <div class="navbar-collapse collapse">
                            <ul class="nav navbar-nav" style="border-bottom-color: black">
<%--                                <li><a runat="server" href="~/inicio.aspx">Inicio</a></li>
                                <li><a runat="server" href="~/cuentasxcobrar.aspx">Cuentas por Cobrar</a></li>
                                <li><a runat="server" href="~/clientes.aspx">Clientes</a></li>
                                <li><a runat="server" href="~/gestiones.aspx">Gestiones</a></li>
                                <li><a runat="server" href="~/reportes.aspx">Reportes</a></li>--%>
                            </ul>

                            <ul class="nav navbar-nav navbar-right">
                                <li>
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="login"><span class="glyphicon glyphicon-log-in">
                                      </span> Iniciar Sesión</asp:LinkButton>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <!-- ====== Screenshots Section ====== -->
        <section id="screenshots">
            <div class="screenshots section-padding dark-bg">
                <div class="container">
                    <div class="header">
                        <h1><strong>gescob</strong></h1>
                        <p>Software que permite la <strong>gestión de cobros</strong> de su empresa</p>
                        <div class="underline"><i class="fa fa-image"></i></div>
                    </div>

                    <div class="owl-carousel owl-theme">
                        <div class="item">
                            <a href="images/im1.png" data-rel="prettyPhoto">
                                <img src="images/im1.png" alt="gescob"></a>
                        </div>
                        <div class="item">
                            <a href="images/im2.png" data-rel="prettyPhoto">
                                <img src="images/im2.png" alt="cuentas por cobrar"></a>
                        </div>
                        <div class="item">
                            <a href="images/im3.png" data-rel="prettyPhoto">
                                <img src="images/im3.png" alt="clientes"></a>
                        </div>
                        <div class="item">
                            <a href="images/im4.png" data-rel="prettyPhoto">
                                <img src="images/im4.png" alt="gestiones"></a>
                        </div>
                        <div class="item">
                            <a href="images/im5.png" data-rel="prettyPhoto">
                                <img src="images/im5.png" alt="ingresar gestion"></a>
                        </div>
                    </div>

                </div>
            </div>
        </section>
        <!-- ====== End Screenshots Section ====== -->






        <!-- ====== Copyright Section ====== -->
        <section class="copyright dark-bg">
            <div class="container">
                <div class="row">
                    <div class="col-md-3 col-sm-4 col-md-push-3 animated wow fadeInLeft" data-wow-delay="0.2s">
                        <h3 class="fh5co-lead">About</h3>
                        <ul>
                            <li><a href="#">Texto</a></li>
                            <li><a href="#">Texto</a></li>
                            <li><a href="#">Texto</a></li>
                        </ul>
                    </div>
                    <div class="col-md-3 col-sm-4 col-md-push-3 animated wow fadeInLeft" data-wow-delay="0.4s">
                        <h3 class="fh5co-lead">Support</h3>
                        <ul>
                            <li><a href="#">Texto</a></li>
                            <li><a href="#">Texto</a></li>
                            <li><a href="#">Texto</a></li>
                        </ul>
                    </div>
                    <div class="col-md-3 col-sm-4 col-md-push-3 animated wow fadeInLeft" data-wow-delay="0.6s">
                        <h3 class="fh5co-lead">More Links</h3>
                        <ul>
                            <li><a href="#">Texto</a></li>
                            <li><a href="#">Texto</a></li>
                            <li><a href="#">Texto</a></li>
                        </ul>
                    </div>

                    <div class="col-md-3 col-sm-12 col-md-pull-9 animated wow fadeInLeft" data-wow-delay="0.8s">
                        <div class="fh5co-footer-logo"><a href="index.html">gescob</a></div>
                        <p class="fh5co-copyright"><small>&copy; 2016. All Rights Reserved. </small></p>
                    </div>

                </div>
            </div>
        </section>

        <!-- jQuery -->
        <script src="http://code.jquery.com/jquery.min.js"></script>
        <script src="js/jquery.js"></script>
        <!-- Modernizr js -->
        <script src="js/modernizr-latest.js"></script>
        <!-- Bootstrap 3.2.0 js -->
        <script src="js/bootstrap.min.js"></script>
        <!-- Owl Carousel plugin -->
        <script src="js/owl.carousel.min.js"></script>
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

