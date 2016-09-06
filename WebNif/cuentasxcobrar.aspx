<%@ Page Title="Cuentas por cobrar" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeFile="~/cuentasxcobrar.aspx.cs" Inherits="WebNif.cuentasxcobrar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- ====== End CUENTAS POR COBRAR ====== -->
    <section id="cuentasporcobrar">
        <div class="features section-padding">
            <div class="container">

                <div class="header">
                    <h1><strong>C</strong>uentas por <strong>C</strong>obrar</h1>
                    <p>
                        <span style="color: rgb(37, 37, 37); font-family: sans-serif; font-size: 14px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 22.4px; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none; background-color: rgb(255, 255, 255);">
                            <span class="Apple-converted-space">&nbsp;</span>
                            Crédito que la empresa concede a sus clientes a través de una cuenta abierta en el curso ordinario de un negocio, como resultado de la entrega de artículos o servicios.
                                Las cuentas por cobrar se consideran como parte del activo circulante de la empresa, por lo que se presta muchísima atención a la administración eficiente de las mismas.
                            <span class="Apple-converted-space">&nbsp;</span>
                        </span>
                    </p>
                    <div class="underline">
                        <i class="fa fa-ellipsis-h"></i>
                    </div>

                    <!--<div class="meta-text">
                        <h3>Periodicidad:
                            <asp:TextBox ID="TextBox3" runat="server" Width="200px"></asp:TextBox></h3>
                        <asp:Panel ID="Panel5" runat="server" Width="299px" Height="64px"></asp:Panel>
                    </div>-->

                </div>

                <div class="row">
                    <div class="col-md-4">
                        <!-- buscadores -->
                        <div class="featured-item-img">
                            <asp:Panel ID="Panel1" runat="server" Width="299px" Height="640px">
                                <div class="col-sm-6 col-md-6">
                                    <div class="featured-item">
                                        <div class="icon" onclick="buscar_factura">
                                            <div class="icon-style"><i class="fa fa-search"></i></div>
                                        </div>

                                        <div class="meta-text">
                                            <h3>Factura: </h3>
                                            <asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox>
                                            <asp:Button ID="Button1" runat="server" Text="Buscar" OnClick="buscar_factura" BackColor="White" Width="200px" />
                                        </div>
                                        <asp:Panel ID="Panel2" runat="server" Width="299px" Height="64px"></asp:Panel>

                                        <div class="icon">
                                            <div class="icon-style"><i class="fa fa-desktop"></i></div>
                                        </div>
                                        <div class="meta-text">
                                            <h3>Cliente: </h3>
                                            <asp:TextBox ID="TextBox2" runat="server" Width="200px"></asp:TextBox>
                                            <asp:Button ID="Button2" runat="server" Text="Buscar" OnClick="buscar_cliente" BackColor="White" Width="200px" />
                                        </div>
                                        <asp:Panel ID="Panel3" runat="server" Width="299px" Height="64px"></asp:Panel>

                                        <div class="icon">
                                            <div class="icon-style"><i class="fa fa-gears"></i></div>
                                        </div>
                                        <div class="meta-text">
                                            <h3>Facturas vencidas </h3>
                                            <asp:Button ID="Button3" runat="server" Text="Buscar" OnClick="buscar_vencidas" BackColor="White" Width="200px" />
                                        </div>
                                        <asp:Panel ID="Panel4" runat="server" Width="299px" Height="64px"></asp:Panel>

                                        <div class="icon">
                                            <div class="icon-style"><i class="fa fa-send"></i></div>
                                        </div>
                                        <div class="meta-text">
                                            <h3>Todas Facturas </h3>
                                            <asp:Button ID="Button4" runat="server" Text="Buscar" OnClick="buscar_todas" BackColor="White" Width="200px" />
                                        </div>

                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>

                    <div class="col-md-8 feature-list">
                        <div class="row">

                            <asp:GridView ID="GridView1" Width="800px" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" CellPadding="1" ForeColor="#333333" GridLines="Both">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="IDFACTURA" DataFormatString="{0:f0}" HeaderText="Factura" />
                                    <asp:BoundField DataField="IDCLIENTE" DataFormatString="{0:f0}" HeaderText="Cliente" />
                                    <asp:BoundField DataField="FECHAFACTURA" DataFormatString="{0:d}" HeaderText="Fecha de Factura" />
                                    <asp:BoundField DataField="MONTO" DataFormatString="{0:N0}" HeaderText="Monto" />
                                    <asp:BoundField DataField="SALDO" DataFormatString="{0:N0}" HeaderText="Saldo" />
                                    <asp:BoundField DataField="VENCIMIENTO" DataFormatString="{0:d}" HeaderText="Fecha Vencimiento" />
                                    <asp:BoundField DataField="ESTADO" DataFormatString="{0:N0}" HeaderText="Estado" />
                                    <asp:ButtonField ButtonType="Link" runat="server" CommandName="historial_pagos" Text="Historial de Pagos" ControlStyle-Font-Bold="true" />
                                    <asp:ButtonField ButtonType="Link" runat="server" CommandName="historial_gestiones" Text="Historial de Gestiones" ControlStyle-Font-Bold="true" />
                                </Columns>
                                <EditRowStyle BackColor="#660066" />
                                <FooterStyle BackColor="#660066" ForeColor="White" Font-Bold="True" />
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
            </div>
        </div>
    </section>
    <!-- ====== End CUENTAS POR COBRAR ====== -->

</asp:Content>

