<%@ Page Title="Mis artículos favoritos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="Web.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <h1>favoritos</h1>
    <hr />
    <asp:Repeater runat="server" ID="repRepetidor">
        <ItemTemplate>
            <div class="row">
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
                                            <asp:ImageButton ID="btnFavoritos" OnClick="btnFavoritos_Click" CssClass="btn btn-warning fav-boton" ImageUrl="~/Images/corazon.png" title="Añadir a favoritos"
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
            </div>
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>
