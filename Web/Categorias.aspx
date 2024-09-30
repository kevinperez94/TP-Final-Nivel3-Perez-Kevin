<%@ Page Title="Categorías y artículos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="Web.Categorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <hr />
    <h1 class="centrar-texto mb-3">Categorías</h1>
    <div class="container text-center">
        <div class="row row-cols-2">
            <div class="col mb-3">
                <asp:HyperLink NavigateUrl="~/PagCelulares.aspx" runat="server">
                    <asp:image imageurl="~/Images/celulares.png" title="Celulares" CssClass="img-fluid categoria-img" runat="server" />
                </asp:HyperLink>
            </div>
            <div class="col mb-3">
                <asp:HyperLink NavigateUrl="~/PagTelevisores.aspx" runat="server">
                <asp:image imageurl="~/Images/televisores.png" title="Televisores" CssClass="img-fluid categoria-img" runat="server" />
                </asp:HyperLink>
            </div>
            <div class="col mb-3">
                <asp:HyperLink NavigateUrl="~/PagMedia.aspx" runat="server">
                <asp:image imageurl="~/Images/media.png" title="Media" CssClass="img-fluid categoria-img" runat="server" />
                </asp:HyperLink>
            </div>
            <div class="col mb-3">
                <asp:HyperLink NavigateUrl="~/PagAudio.aspx" runat="server">
                <asp:image imageurl="~/Images/audio.png" title="Audio" CssClass="img-fluid categoria-img" runat="server" />
                </asp:HyperLink>
            </div>
        </div>
    </div>
    <hr />
    <h3 class="mb-3">Celulares</h3>
    <div class="row">
        <asp:Repeater runat="server" ID="repCelulares">
            <ItemTemplate>
                <div class="card mb-3 ms-3" style="max-width: 540px;">
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
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <hr />
    <h3 class="mb-3">Televisores</h3>
    <div class="row">
        <asp:Repeater runat="server" ID="repTelevisores">
            <ItemTemplate>
                <div class="card mb-3 ms-3" style="max-width: 540px;">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <a href="Producto.aspx?id=<%#Eval("Id") %>" class="link-sin-estilo">
                                <div class="row g-0">
                                    <div class="col-md-4">
                                        <img src="<%#Eval("ImagenUrl") %>" class="img-fluid rounded-start">
                                    </div>
                                    <div class="col-md-8">
                                        <div class="mb-3 icon-fav">
                                            <asp:ImageButton ID="btnFavoritosTV" OnClick="btnFavoritosTV_Click" CssClass="btn btn-light fav-boton" ImageUrl="~/Images/corazon.png" title="Añadir a favoritos"
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
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <hr />
    <h3 class="mb-3">Productos media</h3>
    <div class="row">
        <asp:Repeater runat="server" ID="repMedia">
            <ItemTemplate>
                <div class="card mb-3 ms-3" style="max-width: 540px;">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <a href="Producto.aspx?id=<%#Eval("Id") %>" class="link-sin-estilo">
                                <div class="row g-0">
                                    <div class="col-md-4">
                                        <img src="<%#Eval("ImagenUrl") %>" class="img-fluid rounded-start">
                                    </div>
                                    <div class="col-md-8">
                                        <div class="mb-3 icon-fav">
                                            <asp:ImageButton ID="btnFavoritosMD" OnClick="btnFavoritosMD_Click" CssClass="btn btn-light fav-boton" ImageUrl="~/Images/corazon.png" title="Añadir a favoritos"
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
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <hr />
    <h3 class="mb-3">Productos de audio</h3>
    <div class="row">
        <asp:Repeater runat="server" ID="repAudio">
            <ItemTemplate>
                <div class="card mb-3 ms-3" style="max-width: 540px;">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <a href="Producto.aspx?id=<%#Eval("Id") %>" class="link-sin-estilo">
                                <div class="row g-0">
                                    <div class="col-md-4">
                                        <img src="<%#Eval("ImagenUrl") %>" class="img-fluid rounded-start">
                                    </div>
                                    <div class="col-md-8">
                                        <div class="mb-3 icon-fav">
                                            <asp:ImageButton ID="btnFavoritosAD" OnClick="btnFavoritosAD_Click" CssClass="btn btn-light fav-boton" ImageUrl="~/Images/corazon.png" title="Añadir a favoritos"
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
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
