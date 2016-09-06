<%@ Page Title="correo" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="correo.aspx.cs" Inherits="WebNif.correo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- ====== CORREO ====== -->
    <section id="correo">
        <div class="features section-padding">
            <div class="container">
                <div class="header">
                    <h1 style="text-align: left"><strong>C</strong>orreo</h1>
                </div>

                <div class="row">
                    <div class="col-xs-12 col-md-6">

                        <asp:PlaceHolder runat="server" ID="PlaceHolder1" Visible="false">
                            <p class="text-danger">
                                <asp:Literal runat="server" ID="Literal1" />
                            </p>
                        </asp:PlaceHolder>

                        <div class="form-group">
                            <label for="cliente" runat="server" associatedcontrolid="Cliente" cssclass="col-md-2 control-label">Cliente</label>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Cliente" CssClass="text-danger" ErrorMessage="El campo Cliente es obligatorio." />
                            <asp:TextBox ID="Cliente" CssClass="form-control" runat="server" Height="40px" Width="300px"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label for="email" runat="server" associatedcontrolid="Email" cssclass="col-md-2 control-label">Email</label>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" CssClass="text-danger" ErrorMessage="El campo Email es obligatorio." />
                            <asp:TextBox ID="Email" CssClass="form-control" runat="server" Height="40px" Width="300px"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label for="asunto" runat="server" associatedcontrolid="Asunto" cssclass="col-md-2 control-label">Asunto</label>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Asunto" CssClass="text-danger" ErrorMessage="El campo Asunto es obligatorio." />
                            <asp:TextBox ID="Asunto" CssClass="form-control" runat="server" Height="40px" Width="300px"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <asp:Button runat="server" OnClick="enviar_correo" Text="Enviar" CssClass="btn btn-default" />
                            <asp:Label ID="Label8" runat="server"></asp:Label>
                        </div>

                    </div>

                    <div class="col-xs-12 col-md-6">
                        <div class="form-group">
                            <label for="mensaje" runat="server" associatedcontrolid="Mensaje" cssclass="col-md-2 control-label">Mensaje</label>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Mensaje" CssClass="text-danger" ErrorMessage="El campo Asunto es obligatorio." />
                            <textarea name="Mensaje" id="Mensaje" cssclass="form-control" runat="server" rows="10" cols="100"></textarea>
                        </div>
                    </div>


                </div>
            </div>
        </div>
    </section>
    <!-- ======  ====== -->

</asp:Content>
