<%@ Page Title="Gestiones" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="gestiones.aspx.cs" Inherits="WebNif.gestiones" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- ====== GESTIONES PENDIENTES ====== -->
    <section id="gestiones">
        <div class="description">
            <div class="description-one section-padding">
                <div class="container" runat="server">
                    <div class="row">
                        <div class="col-sm-5 col-md-6">
                            <div class="app-image">
                                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False"
                                    OnRowCancelingEdit="GridView4_RowCancelingEdit"
                                    OnRowEditing="GridView4_RowEditing"
                                    OnRowUpdating="GridView4_RowUpdating" CellPadding="1" ForeColor="#333333">

                                    <AlternatingRowStyle BackColor="White" />

                                    <Columns>
                                        <asp:CommandField ButtonType="Image"
                                            ShowEditButton="true" EditImageUrl="~/Icons/images.jpg"
                                            UpdateImageUrl="~/Icons/confirmar.jpg"
                                            CancelImageUrl="~/Icons/cancelar.jpg" />

                                        <asp:TemplateField HeaderText="Cliente">
                                            <ItemTemplate>
                                                <asp:Label ID="tipoprestamo" runat="server" Text='<%# Bind("tipoprestamo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Factura">
                                            <ItemTemplate>
                                                <asp:Label ID="tipo" runat="server" Text='<%# Bind("tipoprestamo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha de Vencimiento">
                                            <EditItemTemplate>
                                                <asp:Label ID="Label_cuenta" Visible="false" runat="server" Text='<%# Bind("CUENTA") %>'></asp:Label>
                                                <asp:TextBox ID="cuenta" runat="server" Text='<%# Bind("CUENTA") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="L_cuenta" runat="server" Text='<%# Bind("CUENTA") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Saldo">
                                            <EditItemTemplate>
                                                <asp:Label ID="Label_deudorescolgap" Visible="false" runat="server" Text='<%# Bind("DEUDORESCOLGAP") %>'></asp:Label>
                                                <asp:TextBox ID="deudorescolgap" runat="server" Text='<%# Bind("DEUDORESCOLGAP") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="L_deudorescolgap" runat="server" Text='<%# Bind("DEUDORESCOLGAP") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Gestion">
                                            <EditItemTemplate>
                                                <asp:Label ID="Label_csc_interes" Visible="false" runat="server" Text='<%# Bind("CSC_INTERES") %>'></asp:Label>
                                                <asp:TextBox ID="csc_interes" runat="server" Text='<%# Bind("CSC_INTERES") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="L_csc_interes" runat="server" Text='<%# Bind("CSC_INTERES") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Estado">
                                            <EditItemTemplate>
                                                <asp:Label ID="Label_csc_recaudo" Visible="false" runat="server" Text='<%# Bind("tipoprestamo") %>'></asp:Label>
                                                <asp:TextBox ID="csc_recaudo" runat="server" Text='<%# Bind("tipoprestamo") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="L_csc_recaudo" runat="server" Text='<%# Bind("tipoprestamo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
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

                        <div class="col-sm-7 col-md-6">
                            <div class="content">
                                <div class="header">
                                    <h1><strong>G</strong>estiones <strong>P</strong>endientes</h1>
                                </div>

                                </br>
                                    <div class="button" id="enviarcorreo" style="text-align: center">
                                        <a runat="server" href="~/correo.aspx" class="btn btn-default btn-lg custom-btn get-btn"><i class="fa fa-cloud-download"></i>Enviar correo</a>
                                    </div>

                                <div class="button" id="agregartarea" style="text-align: center">
                                    <a href="#nuevatarea" class="btn btn-default btn-lg custom-btn get-btn"><i class="fa fa-cloud-download"></i>Agregar tarea</a>
                                </div>


                            </div>
                        </div>
                    </div>
                </div>
            </div>


        </div>
    </section>
    <!-- ====== End tareas ====== -->

</asp:Content>
