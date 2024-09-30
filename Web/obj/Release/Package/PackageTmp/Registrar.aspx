<%@ Page Title="Crear cuenta" Language="C#" MasterPageFile="~/Master2.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="Web.Registrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-2"></div>
                <div class="col">
                    <h1>crear usuario</h1>
                    <div class="mb-3">
                        <asp:Label Text="Nombre" CssClass="h6" runat="server" />
                        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                        <asp:RegularExpressionValidator ErrorMessage=" Su nombre debe tener 50 caracteres o menos!"
                            CssClass="lbl-invalid" ValidationExpression="^.{1,50}$" ControlToValidate="txtNombre" runat="server" />
                    </div>
                    <div class="mb-3">
                        <asp:Label Text="Apellido" CssClass="h6" runat="server" />
                        <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" />
                        <asp:RegularExpressionValidator ErrorMessage=" Su apellido debe tener 50 caracteres o menos!"
                            CssClass="lbl-invalid" ValidationExpression="^.{1,50}$" ControlToValidate="txtApellido" runat="server" />
                    </div>
                    <div class="mb-3">
                        <asp:Label Text="Correo" CssClass="h6" runat="server" />
                        <asp:TextBox runat="server" TextMode="Email" ID="txtEmail" AutoPostBack="true" ValidationGroup="ValEmail" OnTextChanged="txtEmail_TextChanged" CssClass="form-control" placeholder="sucorreo@hotmail.com" />
                        <asp:Label ID="lblEmail" CssClass="lbl-invalid" Visible="false" runat="server" />
                    </div>
                    <div class="mb-3">
                        <asp:Label Text="Contraseña" CssClass="h6" runat="server" />
                        <asp:TextBox runat="server" ID="txtContraseña" OnTextChanged="txtContraseña_TextChanged" AutoPostBack="true" CssClass="form-control" />
                        <asp:Label ID="lblContraseña" CssClass="lbl-invalid" runat="server" />
                        <asp:RegularExpressionValidator ErrorMessage=" Su contraseña debe ser de 20 caracteres o menos!"
                            CssClass="lbl-invalid" ValidationExpression="^.{3,50}$" ControlToValidate="txtContraseña" runat="server" />
                    </div>
                    <div class="mb-3">
                        <asp:Button Text="Confirmar" CssClass="btn btn-success" runat="server" ID="btnConfirmar" OnClick="btnConfirmar_Click" />
                        <asp:HyperLink NavigateUrl="~/Default.aspx" type="Button" Text="Cancelar" CssClass="btn btn-danger" runat="server" />
                    </div>
                </div>
                <div class="col-2"></div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
