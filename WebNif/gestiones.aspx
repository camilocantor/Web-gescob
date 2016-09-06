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

                                        <asp:TemplateField HeaderText="ID USUARIO">
                                            <ItemTemplate>
                                                <asp:Label ID="IDUSUARIO" runat="server" Text='<%# Bind("IDUSUARIO") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ID FACTURA">
                                            <ItemTemplate>
                                                <asp:Label ID="IDFACTURA" runat="server" Text='<%# Bind("IDFACTURA") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CONTADOR">
                                            <ItemTemplate>
                                                <asp:Label ID="CONTADOR" runat="server" Text='<%# Bind("CONTADOR") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="FECHA DE GESTION">
                                            <EditItemTemplate>
                                                <asp:Label ID="Label_FECHAGESTION" DataFormatString="{0:d}" Visible="false" runat="server" Text='<%# Bind("FECHAGESTION") %>'></asp:Label>
                                                <asp:TextBox ID="FECHAGESTION" runat="server" Text='<%# Bind("FECHAGESTION") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="L_FECHAGESTION" runat="server" Text='<%# Bind("FECHAGESTION") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SEGUIMIENTO">
                                            <EditItemTemplate>
                                                <asp:Label ID="Label_SEGUIMIENTO" Visible="false" runat="server" Text='<%# Bind("SEGUIMIENTO") %>'></asp:Label>
                                                <asp:TextBox ID="t_SEGUIMIENTO" runat="server" Text='<%# Bind("SEGUIMIENTO") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="L_SEGUIMIENTO" runat="server" Text='<%# Bind("SEGUIMIENTO") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ESTADO">
                                            <EditItemTemplate>
                                                <asp:Label ID="Label_ESTADO" Visible="false" runat="server" Text='<%# Bind("ESTADO") %>'></asp:Label>
                                                <asp:TextBox ID="ESTADO" runat="server" Text='<%# Bind("ESTADO") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="L_ESTADO" runat="server" Text='<%# Bind("ESTADO") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ADJUNTO">
                                            <EditItemTemplate>
                                                <asp:Label ID="Label_ADJUNTO" Visible="false" runat="server" Text='<%# Bind("ADJUNTO") %>'></asp:Label>
                                                <asp:TextBox ID="ADJUNTO" runat="server" Text='<%# Bind("ADJUNTO") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="L_ADJUNTO" runat="server" Text='<%# Bind("ADJUNTO") %>'></asp:Label>
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
                                    <a runat="server" href="~/correo.aspx" class="btn btn-default btn-lg custom-btn get-btn" style="width:190px;"><i class="fa fa-cloud-download"></i>Enviar correo</a>
                                </div>

                                <div class="button" id="agregartarea" style="text-align: center">
                                    <a runat="server" href="#nuevatarea" class="btn btn-default btn-lg custom-btn get-btn" style="width:190px;"><i class="fa fa-cloud-download"></i>Agregar tarea</a>
                                </div>

                                <div class="button" id="historialgestiones" style="text-align: center">
                                    <a runat="server" href="~/historial_gestiones.aspx" class="btn btn-default btn-lg custom-btn get-btn" style="width:190px;"><i class="fa fa-cloud-download"></i>Historial</a>
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
