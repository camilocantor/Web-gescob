<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="historial_pagos.aspx.cs" Inherits="WebNif.historial_pagos" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <head>
        <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <!-- Template Title -->
        <title>historial pagos</title>
        <link rel="icon" href="images/favicon.ico" type="image/x-icon" />
        <!-- Bootstrap 3.2.0 stylesheet -->
        <link href="css/bootstrap.min.css" rel="stylesheet">
        <!-- Font Awesome Icon stylesheet -->
        <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css" />
        <!-- Owl Carousel stylesheet -->
        <link href="css/owl.carousel.css" rel="stylesheet">
        <!-- Pretty Photo stylesheet -->
        <link href="css/prettyPhoto.css" rel="stylesheet">
        <!-- Custom stylesheet -->
        <link href="css/style.css" rel="stylesheet" type="text/css" />
        <link href="css/white.css" rel="stylesheet" type="text/css" />
        <!-- Custom Responsive stylesheet -->
        <link href="css/responsive.css" rel="stylesheet">
        <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
        <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
        <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
    </head>
</head>
<body>
    <form id="form1" runat="server">

        <section id="historialfactura">
            <div class="features section-padding">
                <div class="container">
                    <div class="header">
                        <h1 style="color: #660066; text-align: center;"><strong>F</strong>actura: 
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                        </h1>
                        <br />
                        <h4 style="text-align: center;">
                            <span style="color: #660066; text-align: center;">Cliente: 
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                            </span>
                            <br />
                            <span style="color: #660066; text-align: center;">Fecha de factura: 
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                            </span>
                            <br />
                            <span style="color: #660066; text-align: center;">Fecha de vencimiento: 
                    <asp:Label ID="Label4" runat="server"></asp:Label>
                            </span>
                            <br />
                            <span style="color: #660066; text-align: center;">Concepto: 
                    <asp:Label ID="Label5" runat="server"></asp:Label>
                            </span>
                            <br />
                            <span style="color: #660066; text-align: center;">Monto: 
                    <asp:Label ID="Label6" runat="server"></asp:Label>
                            </span>
                            <br />
                            <span style="color: #660066; text-align: center;">Saldo: 
                    <asp:Label ID="Label7" runat="server"></asp:Label>
                            </span>
                            <br />
                        </h4>

                        <div class="underline">
                            <i class="fa fa-ellipsis-h"></i>
                        </div>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" CellPadding="1" ForeColor="#333333" GridLines="Both" Width="800px">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="PERIODO" DataFormatString="{0:f0}" HeaderText="" />
                                <asp:BoundField DataField="comcenum_csc_recaudo" DataFormatString="{0:f0}" HeaderText="Gestión" />
                                <asp:BoundField DataField="FECHA_PAGO" DataFormatString="{0:d}" HeaderText="Fecha de Pago" />
                                <asp:BoundField DataField="SALDOCAPITAL" DataFormatString="{0:N0}" HeaderText="Saldo Anterior" />
                                <asp:BoundField DataField="CUOTAFIJA" DataFormatString="{0:N0}" HeaderText="Pago" />
                                <asp:BoundField DataField="NUEVOCAPITAL" DataFormatString="{0:N0}" HeaderText="Nuevo Saldo" />
                                <asp:BoundField DataField="SOBRETASA" DataFormatString="{0:N0}" HeaderText="Estado" />
                                <asp:ButtonField ButtonType="Link" runat="server" CommandName="adjunto" HeaderText="Soporte" Text="Adjunto" ControlStyle-Font-Bold="true" />

                            </Columns>
                            <EditRowStyle BackColor="#660066" />
                            <FooterStyle BackColor="#660066" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#660066" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F6D9F6" />
                            <SelectedRowStyle BackColor="#EFF3FB" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#FFC3FC" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>

                    </div>
                </div>
            </div>
        </section>

        <div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        </div>
    </form>
</body>
</html>
