<%@ Page Title="Iniciar sesion" Language="C#" MasterPageFile="~/Master2.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="row">
        <div class="col-2"></div>
        <div class="col">
            <h1 class="centrar-texto">iniciar sesión</h1>
            <hr />
            <div class="mb-3">
                <asp:Label Text="Correo" CssClass="h6" runat="server" />
                <asp:TextBox runat="server" ID="txtEmail" type="text" CssClass="form-control"/>
                <asp:Label ID="lblErrorCorreo" CssClass="lbl-invalid" Visible="false" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Contraseña" CssClass="h6" runat="server" />
                <asp:TextBox runat="server" ID="txtContraseña" type="password" CssClass="form-control"/>
                <asp:Label ID="lblErrorContraseña" CssClass="lbl-invalid" Visible="false" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Button Text="Iniciar sesión" CssClass="btn btn-success" ID="btnAceptar" OnClick="btnAceptar_Click" runat="server" />
                <asp:HyperLink NavigateUrl="~/Registrar.aspx" type="Button" Text="¡No tengo cuenta!" CssClass="btn btn-primary" runat="server" />
            </div>
        </div>
        <div class="col-2"></div>
    </div>
    <div class="row">
        <div class="col-2"></div>
        <div class="col">
            <div class="mb-3">
                <asp:Label ID="lblMensaje" Visible="false" CssClass="mensaje-login" runat="server" />
            </div>
        </div>
        <div class="col-2"></div>
    </div>

</asp:Content>
