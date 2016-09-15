<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="graf.aspx.cs" Inherits="WebNif.graf" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <!-- Carousel-Inner -->
            <div class="carousel-inner">

                <!-- Slide - 1 -->
                <div class="item active bg1">
                    <div class="banner-overlay">
                        <div class="container">
                            <div class="row">
                                <div class="col-md-6 col-sm-8 col-xs-12 animated notranstion">
                                    <br class="hidden-sm hidden-xs" />
                                    <div class="wow" data-wow-duration="1500ms" data-wow-delay="100ms">
                                        <h1 class="carouselText1 text-left wow fadeInUp" data-wow-duration="1000ms" data-wow-delay="150ms">Registro de EPP</h1>
                                        <p class="wow fadeInUp" data-wow-duration="1000ms" data-wow-delay="200ms">
                                            Registra la entrega de los Elementos de Protección Personal EPP a los empleados, necesarios para su ocupación y optimo desempeño
                                        </p>
                                        <br />
                                        <div class="text-left buttonleft hidden-xs">
                                            <a runat="server" href="~/iniciarsesion.aspx" class="btn btn-lg btn-borderwhite wow fadeInUp" data-wow-duration="1500ms" data-wow-delay="1200ms">Registrar</a>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-4 hidden-xs animated">
                                    <img src="img/slider/slide1-1.png" alt="" class="slide1-1 wow  fadeInRight" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Slide - 2 -->
                <div class="item bg2">
                    <div class="banner-overlay">
                        <div class="container">
                            <div class="row">
                                <div class="col-md-6 col-sm-4  hidden-xs animated">
                                    <img src="img/slider/slide1-1.png" alt="" class="slide1-2 wow fadeInLeft img-responsive" />
                                </div>
                                <div class="col-md-6 col-sm-8 col-xs-12 animated">
                                    <div class="wow" data-wow-duration="1500ms" data-wow-delay="100ms">
                                        <br />
                                        <h1 class="carouselText1 col-gapall wow zoomIn" data-wow-duration="1500ms" data-wow-delay="500ms">Control de cambio y renovación de los EPP</h1>
                                        <br />
                                        <ul class="list-unstyled car-mediumtext">
                                            <li class="wow fadeInRight" data-wow-duration="1500ms" data-wow-delay="100ms"><i class="fa fa-check-square wow fadeInDown" data-wow-duration="1500ms" data-wow-delay="100ms"></i>
                                                Generando alertas para el pronto reemplazo de los EPP</li>
                                            <li class="wow fadeInRight" data-wow-duration="1500ms" data-wow-delay="500ms"><i class="fa fa-check-square wow fadeInDown" data-wow-duration="1500ms" data-wow-delay="100ms"></i>
                                                Teniendo en cuenta la vida util del los elementos</li>
                                            <li class="wow fadeInRight" data-wow-duration="1500ms" data-wow-delay="1000ms"><i class="fa fa-check-square wow fadeInDown" data-wow-duration="1500ms" data-wow-delay="100ms"></i>
                                                Considerando posibles reemplazos de los EPP por situaciones extraordinarias</li>
                                        </ul>
                                        <br />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Slide - 3 -->
                <div class="item bg3">
                    <div class="banner-overlay">
                        <div class="container">
                            <div class="row">
                                <div class="col-md-12 text-center animated">
                                    <h1 class="carouselText1 wow fadeInUp" data-wow-duration="1000ms" data-wow-delay="150ms">Los EPP comprenden todos aquellos dispositivos, accesorios y vestimentas de diversos diseños que emplea el trabajador para protegerse contra posibles lesiones.</h1>
                                    <ul class="list-unstyled car-mediumtext2">
                                        <li>
                                            <asp:Panel ID="Panel1" runat="server" Height="30px"></asp:Panel>
                                        </li>
                                        <li>
                                            <h4 class="car-highlight1 wow fadeInDown" data-wow-duration="1200ms" data-wow-delay="200ms" style="color: #FFFFFF; text-align: center;"><font face="small fonts">Controle la oportuna entrega y renovación de los EPP de sus empleados.</font></h4>
                                        </li>
                                        <%--<li>
                                            <h3 class="car-highlight1 wow fadeInDown" data-wow-duration="1200ms" data-wow-delay="300ms">Texto Texto Texto
                                            </h3>
                                        </li>
                                        <li>
                                            <h3 class="car-highlight2 hidden-xs wow fadeInDown" data-wow-duration="1800ms" data-wow-delay="600ms">Texto Texto Texto Texto
                                            </h3>
                                        </li>
                                        <li>
                                            <h3 class="car-highlight3 wow fadeInDown" data-wow-duration="2400ms" data-wow-delay="900ms">Texto Texto Texto Texto
                                            </h3>
                                        </li>--%>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

            <!-- Carousel - Control -->
            <a class="left carousel-control animated fadeInLeft" href="#fullslider" data-slide="prev"><i class="fa fa-chevron-left"></i></a>
            <a class="right carousel-control animated fadeInRight" href="#fullslider" data-slide="next"><i class="fa fa-chevron-right"></i></a>









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

    </form>
</body>
</html>
