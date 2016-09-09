<%@ Page Title="Historial" MasterPageFile="~/Site1.Master" Language="C#" AutoEventWireup="true" CodeBehind="historial.aspx.cs" Inherits="WebNif.historial" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="historialgestiones">
        <div class="features section-padding">
            <div class="container">
                <div class="header">
                    <h1 style="color: #660066; text-align: center;"><strong>H</strong>istorial</h1>
                    <asp:Panel ID="Panel2" runat="server" Height="64px"></asp:Panel>

                    <div class="meta-text">
                        <h3>Periodicidad: 
                                <asp:DropDownList ID="DropDownList1" runat="server" Width="250px"></asp:DropDownList>
                            <asp:Button ID="Button1" runat="server" Text="Buscar" OnClick="periodicidad" BackColor="White" Width="180px" />
                        </h3>
                    </div>
                    <asp:Panel ID="Panel1" runat="server" Height="64px"></asp:Panel>

                    <div class="underline">
                        <i class="fa fa-ellipsis-h"></i>
                    </div>

                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="1" ForeColor="#333333" GridLines="Both" Width="800px">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="IDFACTURA" DataFormatString="{0:f0}" HeaderText="Factura" />
                            <asp:BoundField DataField="IDCLIENTE" DataFormatString="{0:f0}" HeaderText="Cliente" />
                            <asp:BoundField DataField="FECHAFACTURA" DataFormatString="{0:d}" HeaderText="Fecha de Factura" />
                            <asp:BoundField DataField="MONTO" DataFormatString="{0:N0}" HeaderText="Monto" />
                            <asp:BoundField DataField="SALDO" DataFormatString="{0:N0}" HeaderText="Saldo" />
                            <asp:BoundField DataField="VENCIMIENTO" DataFormatString="{0:d}" HeaderText="Fecha Vencimiento" />
                            <asp:BoundField DataField="ESTADO" DataFormatString="{0:N0}" HeaderText="Estado" />
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

</asp:Content>

