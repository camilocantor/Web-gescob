<%@ Page Title="Nueva gestión" MasterPageFile="~/Site1.Master"  Language="C#" AutoEventWireup="true" CodeBehind="nuevagestion.aspx.cs" Inherits="WebNif.nuevagestion" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <section id="historialgestiones">
            <div class="features section-padding">
                <div class="container">
                    <div class="header">
                        <h1 style="color: #660066; text-align: center;"><strong>N</strong>ueva <strong>G</strong>estión</h1>
                        <asp:Panel ID="Panel2" runat="server" Height="64px"></asp:Panel>
                    </div>

                    <div class="alert alert-danger">
                        <table class="table">
                            <thead>
                                <tr>
                                    <th>ID Usuario</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr class="danger">
                                    <td>
                                        <asp:TextBox ID="TextBox6" runat="server" Width="200px"></asp:TextBox></td>
                                </tr>
                            </tbody>
                        </table>

                        <table class="table">
                            <thead>
                                <tr>
                                    <th>ID Factura</th>
                                    <th>Fecha de Gestión</th>
                                    <th>Seguimiento</th>
                                    <th>Estado</th>
                                    <th>Adjunto</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr class="danger">
                                    <td>
                                        <asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox ID="TextBox2" runat="server" Width="200px"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox ID="TextBox3" runat="server" Width="200px"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox ID="TextBox4" runat="server" Width="200px"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox ID="TextBox5" runat="server" Width="200px"></asp:TextBox></td>
                                </tr>
                            </tbody>
                        </table>

                        <asp:Panel ID="Panel1" runat="server" Height="50px"></asp:Panel>

                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;

                      <div class="button" id="nuevo" style="text-align: center">
                          <asp:Button ID="Button1" runat="server" Text="Crear" OnClick="nuevo" BackColor="White" Width="200px" CssClass="btn btn-default btn-lg custom-btn get-btn" />
                      </div>

                    </div>

                    <asp:GridView ID="GridView1" Width="955px" runat="server" AutoGenerateColumns="False" CellPadding="1" ForeColor="#333333" GridLines="Both">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="idfactura" DataFormatString="{0:f0}" HeaderText="Id Factura" />
                            <asp:BoundField DataField="fechagestion" DataFormatString="{0:d}" HeaderText="Fecha de Gestión" />
                            <asp:BoundField DataField="seguimiento" DataFormatString="{0:N0}" HeaderText="Seguimiento" />
                            <asp:BoundField DataField="estado" DataFormatString="{0:N0}" HeaderText="Estado" />
                            <asp:BoundField DataField="adjunto" DataFormatString="{0:N0}" HeaderText="Adjunto" />
                            <asp:BoundField DataField="idusuario" DataFormatString="{0:N0}" HeaderText="Id Usuario" />
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
        </section>

</asp:Content>


