<%@ Page Title="Tu búsqueda" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Busqueda.aspx.cs" Inherits="Web.Busqueda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <br />
    <div class="row">
        <h1 class="mb-3 centrar-texto">Encuentra los artículos que quieres!</h1>
        <div class="col-2"></div>
        <div class="col">
            <div class="input-group mb-3">
                <asp:TextBox ID="txtBuscar" CssClass="form-control" TextMode="Search" placeholder=" Encuentra lo que quieres, artículos, marcas..." runat="server" />
                <asp:Button Text="Buscar" ID="btnBuscar" OnClick="btnBuscar_Click" CssClass="btn btn-outline-primary" runat="server" />
            </div>
        </div>
        <div class="col-2"></div>
    </div>
    <div class="row">
        <div class="col-4"></div>
        <div class="col">
            <div class="mb-3">
                <asp:Label ID="lblBusqueda" CssClass="centrar-texto" runat="server" />
            </div>
        </div>
        <div class="col-4"></div>
    </div>
    <asp:Panel runat="server" Visible="false" ID="panelListado">
        <div class="row">
            <asp:Repeater runat="server" ID="repListado">
                <ItemTemplate>
                    <div class="col-3"></div>
                    <div class="card mb-3" style="max-width: 540px;">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <a href="Producto.aspx?id=<%#Eval("Id") %>" class="link-sin-estilo">
                                    <div class="row g-0">
                                        <div class="col-md-4">
                                            <img src="<%#Eval("ImagenUrl") %>" class="img-fluid rounded-start">
                                        </div>
                                        <div class="col-md-8">
                                            <div class="mb-3 icon-fav">
                                                <asp:ImageButton ID="btnFavoritos" OnClick="btnFavoritos_Click" CssClass="btn btn-light fav-boton" ImageUrl="~/Images/corazon.png" title="Añadir a favoritos"
                                                    CommandArgument='<%# Eval ("Id") %>' runat="server" />
                                            </div>
                                            <div class="card-body">
                                                <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                                <p class="card-text precio-tarjeta">$<%#Eval("Precio") %></p>
                                            </div>
                                            <div class="card-footer">
                                                <small class="text-body-secondary"><%#Eval("Marca") %></small>
                                            </div>
                                            <div class="card-footer">
                                                <small class="text-body-secondary"><%#Eval("Categoria") %></small>
                                            </div>
                                        </div>
                                    </div>
                                </a>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-3"></div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="panelSinResultado">
        <div class="row">
            <div class="col-1"></div>
            <div class="col">
                <asp:Label ID="lblSinResultado" CssClass="h1 centrar-texto" runat="server" />
            </div>
            <div class="col-1"></div>
        </div>
    </asp:Panel>

</asp:Content>
