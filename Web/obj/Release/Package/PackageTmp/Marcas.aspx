<%@ Page Title="Marcas y artículos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Marcas.aspx.cs" Inherits="Web.Marcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <hr />
    <div class="row">
        <div class="col-1"></div>
        <div class="col-2">
            <div class="mb-3">
                <asp:HyperLink NavigateUrl="~/PagSamsung.aspx" runat="server">
                    <asp:Image ImageUrl="~/Images/logo-samsung.jpg" title="Samsung" CssClass="img-circulo" runat="server" />
                </asp:HyperLink>
            </div>
        </div>
        <div class="col-2">
            <div class="mb-3">
                <asp:HyperLink NavigateUrl="~/PagApple.aspx" runat="server">
                    <asp:Image ImageUrl="~/Images/logo-apple.jpg" title="Apple" CssClass="img-circulo" runat="server" />
                </asp:HyperLink>
            </div>
        </div>
        <div class="col-2">
            <div class="mb-3">
                <asp:HyperLink NavigateUrl="~/PagSony.aspx" runat="server">
                    <asp:image imageurl="~/Images/logo-sony.jpg" title="Sony" CssClass="img-circulo" runat="server" />
                </asp:HyperLink>
            </div>
        </div>
        <div class="col-2">
            <div class="mb-3">
                <asp:HyperLink NavigateUrl="~/PagHuawei.aspx" runat="server">
                    <asp:Image ImageUrl="~/Images/logo-huawei.jpg" title="Huawei" CssClass="img-circulo" runat="server" />
                </asp:HyperLink>
            </div>
        </div>
        <div class="col-2">
            <div class="mb-3">
                <asp:HyperLink NavigateUrl="~/PagMotorola.aspx" runat="server">
                    <asp:Image ImageUrl="~/Images/logo-motorola.gif" title="Motorola" CssClass="img-circulo" runat="server" />
                </asp:HyperLink>
            </div>
        </div>
    </div>
    <hr />
    <div class="row">
        <asp:Repeater runat="server" ID="repRepetidor">
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

</asp:Content>
