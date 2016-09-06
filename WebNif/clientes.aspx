<%@ Page Title="clientes" MasterPageFile="~/Site1.Master" Language="C#" AutoEventWireup="true" CodeBehind="clientes.aspx.cs" Inherits="WebNif.clientes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- ====== CLIENTES ====== -->
    <section id="clientes">
        <div class="features section-padding">
            <div class="container">
                <div class="header">
                    <h1><strong>C</strong>lientes</h1>
                    <p>Want more Bootstrap themes & templates? Subscribe to our mailing list to receive an update when new items arrive! Akshara is a library to buy Bootstrap themes and templates for your business need. Want more Bootstrap themes & templates ? Want more Bootstrap themes & templates?</p>

                    <div class="underline">
                        <i class="fa fa-ellipsis-h"></i>
                    </div>

                    <div class="row">
                        <div class="col-md-4">
                            <div class="featured-item-img">
                                <asp:Panel ID="Panel5" runat="server" Width="200px" Height="600px">
                                    <div class="col-sm-6 col-md-6">
                                        <div class="featured-item">
                                            <div class="icon" onclick="buscar_factura">
                                                <div class="icon-style"><i class="fa fa-search"></i></div>
                                            </div>
                                            <div class="meta-text">
                                                <h3>Cliente: </h3>
                                                <asp:TextBox ID="TextBox3" runat="server" Width="180px"></asp:TextBox>
                                                <asp:Button ID="Button5" runat="server" Text="Buscar" OnClick="cliente" BackColor="White" Width="180px" />
                                            </div>
                                            <asp:Panel ID="Panel6" runat="server" Width="299px" Height="64px"></asp:Panel>

                                            <asp:Panel ID="Panel7" runat="server" Width="299px">
                                                <h4 style="text-align: left;">
                                                    <span style="color: #660066; text-align: left;">Id Cliente: 
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                                                    </span>
                                                    <br />
                                                    <span style="color: #660066; text-align: left;">Nombre 
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                                                    </span>
                                                    <br />
                                                    <span style="color: #660066; text-align: left;">Descripción 
                    <asp:Label ID="Label4" runat="server"></asp:Label>
                                                    </span>
                                                    <br />
                                                    <span style="color: #660066; text-align: left;">e-mail 
                    <asp:Label ID="Label5" runat="server"></asp:Label>
                                                    </span>
                                                    <br />
                                                    <span style="color: #660066; text-align: left;">Telefono 
                    <asp:Label ID="Label6" runat="server"></asp:Label>
                                                    </span>
                                                    <br />
                                                    <span style="color: #660066; text-align: left;">Dirección 
                    <asp:Label ID="Label7" runat="server"></asp:Label>
                                                    </span>
                                                    <br />
                                                    <span style="color: #660066; text-align: left;">Contacto: 
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                                                    </span>
                                                    <br />
                                                </h4>

                                            </asp:Panel>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>

                        <div class="col-md-8 feature-list">
                            <div class="row">

                                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">

                                    <asp:View ID="View0" runat="server">
                                        <asp:GridView ID="GridView3" Width="700px" runat="server" AutoGenerateColumns="False" CellPadding="1" ForeColor="#333333" GridLines="Both">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="comcenum_csc_recaudo" DataFormatString="{0:f0}" HeaderText="Id Cliente" />
                                                <asp:BoundField DataField="SALDOCAPITAL" DataFormatString="{0:N0}" HeaderText="Nombre Cliente" />
                                                <asp:BoundField DataField="NUEVOCAPITAL" DataFormatString="{0:N0}" HeaderText="Descripción" />
                                                <asp:BoundField DataField="PERIODO" DataFormatString="{0:N0}" HeaderText="Cuentas por cobrar" />
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

                                    <asp:View ID="View1" runat="server">
                                        <asp:GridView ID="GridView2" Width="700px" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView2_RowCommand" CellPadding="1" ForeColor="#333333" GridLines="Both">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="comcenum_csc_recaudo" DataFormatString="{0:f0}" HeaderText="Factura" />
                                                <asp:BoundField DataField="FECHA_PAGO" DataFormatString="{0:d}" HeaderText="Fecha de Vencimiento" />
                                                <asp:BoundField DataField="SALDOCAPITAL" DataFormatString="{0:N0}" HeaderText="Saldo" />
                                                <asp:BoundField DataField="NUEVOCAPITAL" DataFormatString="{0:N0}" HeaderText="Tipo de Pago" />
                                                <asp:BoundField DataField="NUEVOCAPITALNIFF" DataFormatString="{0:N0}" HeaderText="Ultima Gestión" />
                                                <asp:BoundField DataField="SOBRETASA" DataFormatString="{0:N0}" HeaderText="Estado" />
                                                <asp:ButtonField ButtonType="Link" runat="server" CommandName="historial_pagos" Text="Historial de Pagos" ControlStyle-Font-Bold="true" />
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

                </div>
            </div>
        </div>
    </section>
    <!-- ====== End CLIENTES ====== -->

</asp:Content>
