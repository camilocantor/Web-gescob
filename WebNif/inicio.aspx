<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="WebNif.inicio" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- ====== INICIO ====== prueba para aleja-->
    <header id="inicio">
        <div class="bg-color">
            <div class="top section-padding">
                <div class="container">
                    <div class="row">
                        <div class="col-sm-5 col-md-5">
                            <div class="photo-slide">
                                <div id="carousel" class="carousel slide" data-ride="carousel">
                                    <ol class="carousel-indicators">
                                        <li data-target="#carousel" data-slide-to="0" class="active"></li>
                                        <li data-target="#carousel" data-slide-to="1" class=""></li>
                                        <li data-target="#carousel" data-slide-to="2" class=""></li>
                                    </ol>
                                    <h1></h1>

                                    <div class="carousel-inner" style="width: 500px">
                                        <div class="item">
                                            <asp:Chart ID="Chart1" runat="server" Palette="Fire">
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
                                        <div class="item active left">
                                            <asp:Chart ID="Chart2" runat="server" Palette="Excel">
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
                                        <div class="item next left">
                                            <asp:Chart ID="Chart3" runat="server">
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

                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-sm-7 col-md-7">
                            <div class="content">
                                <h1>gescob</h1>
                                <h3>Gestión de cobro. El objetivo que se persigue con respecto a la gestión de las cuentas por cobrar debe ser no solamente el de cobrarlas con prontitud, también debe prestarse atención a las alternativas costo - beneficio que se presentan en los diferentes campos de la administración de éstas. </h3>
                                <p>Estos campos comprenden la determinación de las políticas de crédito, el análisis de crédito, las condiciones de crédito y las políticas de cobro.</p>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </header>
    <!-- ====== End INICIO ====== -->

    <!-- ====== MI CUENTA ====== -->
    <%--<footer id="micuenta">
            <div class="footer section-padding">
                <div class="container">

                    <div class="header">
                        <h1>Mi Cuenta</h1>
                    </div>

                    <div class="underline">
                        <i class="fa fa-ellipsis-h"></i>
                    </div>

                    <div class="row">
                        <div class="col-xs-12 col-md-6">
                            <div class="form-group" style="text-align: left">
                                <asp:Label ID="Label9" runat="server" Text="Nombre"></asp:Label>
                            </div>

                            <div class="form-group" style="text-align: left">
                                <asp:Label ID="Label10" runat="server" Text="Email"></asp:Label>

                            </div>

                            <div class="form-group" style="text-align: left">
                                <asp:Label ID="Label11" runat="server" Text="Tipo de usuario"></asp:Label>
                            </div>

                            <div class="form-group" style="text-align: left">
                                <asp:Label ID="Label12" runat="server" Text="Gestiones pendientes"></asp:Label>
                            </div>

                            <div class="form-group" style="text-align: left">
                                <h1></h1>
                            </div>

                            <div class="form-group" style="text-align: left">
                                <asp:Button ID="Button7" runat="server" Text="Salir" OnClick="logout" BackColor="White" Width="200px" />
                            </div>

                        </div>

                        <div class="col-xs-12 col-md-6">
                            <div class="form-group">
                                <asp:Chart ID="Chart4" runat="server">
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
                    </div>

                </div>
            </div>
        </footer>--%>
    <!-- ====== End Mi cuenta ====== -->

</asp:Content>
