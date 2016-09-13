<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="iniciarsesion.aspx.cs" Inherits="WebNif.iniciarsesion" %>

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
                    </div>
                </div>
            </div>
        </div>

        <!-- ====== Inic Sesion ====== -->
        <div class="padding100">
            <div class="container">
                <div id="loginbox" style="margin-top: 50px;" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
                    <div class="panel panel-default">
                        <div class="panel-heading panel-heading-custom">
                            <div class="panel-title">
                                <h4><strong>I</strong>niciar <strong>S</strong>esión</h4>
                            </div>
                        </div>
                        <div style="padding-top: 30px" class="panel-body">
                            <div style="display: none" id="login-alert" class="alert alert-danger col-sm-12">
                            </div>
                            <div id="loginform" class="form-horizontal" role="form">
                                <div style="margin-bottom: 25px" class="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                    <asp:TextBox runat="server" ID="usuario" CssClass="form-control" Height="60px" placeholder="Email"></asp:TextBox>
                                </div>
                                <div style="margin-bottom: 25px" class="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                    <asp:TextBox runat="server" ID="contraseña" CssClass="form-control" Height="60px" placeholder="Contraseña"
                                        TextMode="Password"></asp:TextBox>
                                </div>

                                <div style="margin-top: 10px" class="form-group">
                                    <div class="col-sm-12 controls">
                                        <asp:Button ID="Button1" runat="server" Text="Ingresar" CssClass="btn btn-info" Width="100px" OnClick="ingresar" />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-md-12 control">
                                        <div style="padding-top: 15px; font-size: 85%">
                                            Usted no tiene una cuenta! <a href="#" onclick="$('#loginbox').hide(); $('#signupbox').show()">Regristarme </a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div id="signupbox" style="display: none; margin-top: 50px" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
                    <div class="panel panel-default">
                        <div class="panel-heading panel-heading-custom">
                            <div class="panel-title">
                                Regístrate
                            </div>
                            <div style="float: right; font-size: 85%; position: relative; top: -10px">
                            </div>
                        </div>
                        <div class="panel-body">
                            <div id="signupform" class="form-horizontal" role="form">
                                <div class="form-group">
                                    <label for="email" class="col-md-3 control-label">
                                        ID C.C.</label>
                                    <div class="col-md-9">
                                        <asp:TextBox runat="server" ID="txtid" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="name" class="col-md-3 control-label">
                                        Nombre</label>
                                    <div class="col-md-9">
                                        <asp:TextBox runat="server" ID="txtnom" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="tipous" class="col-md-3 control-label">
                                        Tipo de usuario</label>
                                    <div class="col-md-9">
                                        <asp:TextBox runat="server" ID="txttpo" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="tel" class="col-md-3 control-label">
                                        Telefono</label>
                                    <div class="col-md-9">
                                        <asp:TextBox runat="server" ID="txttel" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="email" class="col-md-3 control-label">
                                        Email</label>
                                    <div class="col-md-9">
                                        <asp:TextBox runat="server" ID="txtemail" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="password" class="col-md-3 control-label">
                                        Contraseña</label>
                                    <div class="col-md-9">
                                        <asp:TextBox runat="server" ID="txtcon" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-offset-3 col-md-9">
                                        <div class="button" id="reg" style="text-align: center">
                                            <asp:Button ID="Button2" runat="server" Text="Registrarme" OnClick="registrar" CssClass="btn btn-info" />
                                        </div>
                                        <div class="button" id="volver" style="text-align: center">
                                            <a runat="server" href="~/iniciarsesion.aspx" class="btn btn-info">Volver</a>
                                        </div>
                                    </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

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

        <!-- Modal -->
        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" style="color: blue">Mensaje de Error!</h4>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="lblModalTitle" runat="server"></asp:Label>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="Button5" CssClass="btn btn-default" runat="server" Text="Cerrar" Width="100px" />
                    </div>
                </div>

            </div>
        </div>


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
