<%@ Page Title="clientes" MasterPageFile="~/Site1.Master" Language="C#" AutoEventWireup="true" CodeBehind="clientes.aspx.cs" Inherits="WebNif.clientes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="clientes">
        <div class="features section-padding">
            <div class="container">
                <div class="header">
                    <h1><strong>C</strong>lientes</h1>
                    <br />
                    <p>Desde el punto de vista contable, la cuenta de clientes recoge los derechos de cobro derivados de la venta de productos de la empresa, que se ocasiona debido al desajuste entre la venta y el cobro. Tienen la consideración de activos financieros y figuran normalmente en el activo corriente del balance.</p>

                    <div class="underline">
                        <i class="fa fa-ellipsis-h"></i>
                    </div>

                    <div class="meta-text">
                        <h3>ID Cliente: 
                                 <asp:TextBox ID="TextBox1" runat="server" Width="180px"></asp:TextBox>
                            <asp:Button ID="Button1" runat="server" Text="Buscar" OnClick="cliente" BackColor="White" Width="180px" />
                        </h3>
                    </div>
                    <asp:Panel ID="Panel1" runat="server" Height="64px"></asp:Panel>

                    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">

                        <div class="featured-item">

                            <asp:View ID="View0" runat="server">
                                <asp:GridView ID="GridView3" Width="955px" runat="server" AutoGenerateColumns="False" CellPadding="1" ForeColor="#333333" GridLines="Both">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="idcliente" DataFormatString="{0:f0}" HeaderText="Id Cliente" />
                                        <asp:BoundField DataField="nombre" DataFormatString="{0:N0}" HeaderText="Nombre Cliente" />
                                        <asp:BoundField DataField="actividad" DataFormatString="{0:N0}" HeaderText="Descripción" />
                                        <asp:BoundField DataField="email" DataFormatString="{0:N0}" HeaderText="Email" />
                                        <asp:BoundField DataField="telefono" DataFormatString="{0:N0}" HeaderText="Telefono" />
                                        <asp:BoundField DataField="direccion" DataFormatString="{0:N0}" HeaderText="Dirección" />
                                        <asp:BoundField DataField="contacto" DataFormatString="{0:N0}" HeaderText="Nombre de Contacto" />
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
                            </asp:View>

                        </div>

                        <asp:View ID="View1" runat="server">

                            <div class="featured-item">
                                <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Center">
                                    <h4 style="text-align: center;">
                                        <span style="color: #660066; text-align: center; font-weight: bold">ID Cliente 
                    <asp:Label ID="Label1" runat="server" Font-Bold="false"></asp:Label>
                                        </span>
                                        <br />
                                        <span style="color: #660066; text-align: center; font-weight: bold">Nombre 
                    <asp:Label ID="Label2" runat="server" Font-Bold="false"></asp:Label>
                                        </span>
                                        <br />
                                        <span style="color: #660066; text-align: center; font-weight: bold">Descripción 
                    <asp:Label ID="Label3" runat="server" Font-Bold="false"></asp:Label>
                                        </span>
                                        <br />
                                        <span style="color: #660066; text-align: center; font-weight: bold">Email 
                    <asp:Label ID="Label4" runat="server" Font-Bold="false"></asp:Label>
                                        </span>
                                        <br />
                                        <span style="color: #660066; text-align: center; font-weight: bold">Telefono 
                    <asp:Label ID="Label5" runat="server" Font-Bold="false"></asp:Label>
                                        </span>
                                        <br />
                                        <span style="color: #660066; text-align: center; font-weight: bold">Dirección 
                    <asp:Label ID="Label6" runat="server" Font-Bold="false"></asp:Label>
                                        </span>
                                        <br />
                                        <span style="color: #660066; text-align: center; font-weight: bold">Contacto: 
                    <asp:Label ID="Label7" runat="server" Font-Bold="false"></asp:Label>
                                        </span>
                                        <br />
                                    </h4>

                                </asp:Panel>
                            </div>

                            <asp:Panel ID="Panel3" runat="server" Height="64px"></asp:Panel>

                            <asp:GridView ID="GridView2" Width="951px" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView2_RowCommand" CellPadding="1" ForeColor="#333333" GridLines="Both">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="IDFACTURA" DataFormatString="{0:f0}" HeaderText="ID Factura" />
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
                        </asp:View>
                    </asp:MultiView>

                </div>
            </div>
        </div>


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



    </section>




</asp:Content>
