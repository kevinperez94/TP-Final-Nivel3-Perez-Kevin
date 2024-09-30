<%@ Page Title="Contacto" Language="C#" MasterPageFile="~/Master2.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="Web.Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="row">
        <div class="col-2"></div>
        <div class="col">
            <h1 style="text-align:center">contacto</h1>
            <hr />
            <div class="mb-3">
                <asp:Label Text="Motivo:" CssClass="h6" runat="server" />
                <asp:DropDownList runat="server" CssClass="form-select">
                    <asp:ListItem Text="SELECCIONAR" Selected="True" />
                    <asp:ListItem Text="Error/Bug" Value="1"/>
                    <asp:ListItem Text="Denuncia" Value="2"/>
                    <asp:ListItem Text="Sugerencia" Value="3"/>
                    <asp:ListItem Text="Trabajo" Value="4"/>
                    <asp:ListItem Text="Marketing (streaming, tv, web, radio, publicidad, etc...)" Value="5"/>
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Label Text="Nombre:" CssClass="h6" runat="server" />
                <asp:TextBox runat="server" type="text" CssClass="form-control" placeholder="ingrese su nombre" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Correo:" CssClass="h6" runat="server" />
                <asp:TextBox runat="server" type="email" CssClass="form-control" placeholder="sucorreo@hotmail.com" />
            </div>
            <div class="mb-3">
                <asp:Label Text="Comentario:" CssClass="h6" runat="server" />
                <asp:TextBox runat="server" TextMode="MultiLine" Rows="6" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <asp:Button Text="Enviar" CssClass="btn btn-primary" runat="server" />
                <asp:HyperLink NavigateUrl="~/Default.aspx" Text="Cancelar" CssClass="btn btn-secondary" runat="server" />
            </div>
        </div>
        <div class="col-2"></div>
    </div>

</asp:Content>
