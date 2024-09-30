<%@ Page Title="Mi perfil" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Web.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" EnablePartialRendering="true"></asp:ScriptManager>

    <h1>perfil</h1>
    <hr />
    <asp:Panel runat="server" ID="panelPerfil">
        <div class="container text-center">
            <div class="row align-items-start">
                <div class="col">
                    <div class="mb-3">
                        <asp:Image ID="imgPerfil" CssClass="img-perfil" runat="server" />
                    </div>
                </div>
                <div class="col">
                    <div class="mb-3">
                        <asp:Label ID="lblNombreApellido" CssClass="h1" runat="server" />
                        <hr />
                    </div>
                    <div class="mb-1">
                        <asp:Label Text="Correo" runat="server" CssClass="h5 lbl-correo" />
                    </div>
                    <div class="mb-3">
                        <asp:Label ID="lblCorreo" runat="server" CssClass="form-control" />
                    </div>
                    <div class="mb-1">
                        <asp:Label Text="Contraseña" runat="server" CssClass="h5 lbl-contraseña" />
                    </div>
                    <div class="mb-3">
                        <asp:Label ID="lblContraseña" runat="server" CssClass="form-control" />
                    </div>
                </div>
                <div class="col">
                    <div class="mb-3">
                        <asp:Button Text="Editar" ID="btnEditar" OnClick="btnEditar_Click" CssClass="btn btn-warning btn-sm" runat="server" />
                        <asp:Button Text="Cerrar sesión" ID="btnCerrarSesion" OnClick="btnCerrarSesion_Click" CssClass="btn btn-danger btn-sm" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="panelEditar" Visible="false">
        <div class="container text-center">
            <div class="row align-items-start">
                <div class="col">
                    <div class="mb-3">
                        <asp:Image ID="imgPerfilEditar" CssClass="img-perfil" runat="server" />
                    </div>
                    <div class="mb-3">
                        <asp:Label Text="Imagen de perfil" CssClass="h6" runat="server" />
                        <asp:FileUpload CssClass="form-control" ID="fileImgPerfil" title="Cargue una imagen!" runat="server" />
                    </div>
                </div>
                <div class="col">
                    <div class="mb-3">
                        <asp:Label Text="Nombre" CssClass="h6" runat="server" />
                        <asp:TextBox runat="server" ID="txtNombre" OnTextChanged="txtNombre_TextChanged"
                            AutoPostBack="true" CssClass="form-control" />
                        <asp:Label ID="lblNombre" CssClass="lbl-invalid" Visible="false" runat="server" />
                    </div>
                    <div class="mb-3">
                        <asp:Label Text="Apellido" CssClass="h6" runat="server" />
                        <asp:TextBox runat="server" ID="txtApellido" OnTextChanged="txtApellido_TextChanged"
                            AutoPostBack="true" CssClass="form-control" />
                        <asp:Label ID="lblApellido" CssClass="lbl-invalid" Visible="false" runat="server" />
                    </div>
                    <div class="mb-3">
                        <asp:Label Text="Correo" CssClass="h6" runat="server" />
                        <asp:TextBox runat="server" ID="txtEmail" OnTextChanged="txtEmail_TextChanged"
                            AutoPostBack="true" TextMode="Email" CssClass="form-control" />
                        <asp:Label ID="lblEmail" CssClass="lbl-invalid" Visible="false" runat="server" />
                    </div>
                    <div class="mb-3">
                        <asp:Label Text="Contraseña" CssClass="h6" runat="server" />
                        <asp:TextBox runat="server" ID="txtContraseña" OnTextChanged="txtContraseña_TextChanged"
                            AutoPostBack="true" CssClass="form-control" />
                        <asp:Label ID="lblPass" CssClass="lbl-invalid" Visible="false" runat="server" />
                    </div>
                    <div class="mb-3">
                        <asp:Button Text="Guardar" ID="btnGuardar" OnClick="btnGuardar_Click" CssClass="btn btn-success" runat="server" />
                        <asp:Button Text="Cancelar" ID="btnCancelar" OnClick="btnCancelar_Click" CssClass="btn btn-secondary" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
