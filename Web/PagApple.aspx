<%@ Page Title="Nuestro catálogo Apple!" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PagApple.aspx.cs" Inherits="Web.PagApple" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <br />
    <div class="row">
        <div class="mb-3 centrar-texto">
            <h1>Encuentra los productos Apple</h1>
        </div>
    </div>
    <div class="row">
        <div class="col">
            <div class="mb-3 centrar">
                <asp:Image ImageUrl="~/Images/Apple-banner.jpg" CssClass="imagen-centrar" runat="server" />
            </div>
        </div>
    </div>
    <hr />
    <asp:UpdatePanel runat="server" ID="upFiltro">
        <ContentTemplate>
            <div class="row">
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Marca" runat="server" />
                        <asp:DropDownList CssClass="form-select" ID="ddlMarca" AutoPostBack="true" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Categoria" runat="server" />
                        <asp:DropDownList CssClass="form-select" ID="ddlCategoria" AutoPostBack="true" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <br />
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtBuscar" TextMode="Search" OnTextChanged="txtBuscar_TextChanged" placeholder="Modelo" />
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <br />
                        <asp:Button Text="Buscar" CssClass="btn btn-primary" ID="btnBuscar" OnClick="btnBuscar_Click" runat="server" />
                    </div>
                </div>
            </div>
            <hr />
            <div class="row">
                <asp:Repeater runat="server" ID="repRepetidor">
                    <ItemTemplate>
                        <div class="card mb-3 ms-3 text-bg-dark" style="max-width: 540px;">
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
                                            <small class="text-body-light"><%#Eval("Marca") %></small>
                                        </div>
                                        <div class="card-footer">
                                            <small class="text-body-light"><%#Eval("Categoria") %></small>
                                        </div>
                                    </div>
                                </div>
                            </a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
