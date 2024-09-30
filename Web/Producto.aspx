<%@ Page Title="Producto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="Web.Producto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager"></asp:ScriptManager>

    <br />
    <asp:Panel runat="server" ID="panelAdmin" Visible="false">
        <div class="row">
            <div class="mb-1" style="text-align: right;">
                <asp:Button Text="Editar" ID="btnEditar" OnClick="btnEditar_Click" CssClass="btn btn-warning" runat="server" />
            </div>
        </div>
    <hr />
    </asp:Panel>
    <asp:Panel runat="server" ID="panelProducto">
        <div class="row">
            <div class="col-1"></div>
            <asp:Repeater runat="server" ID="repArticulo">
                <ItemTemplate>
                    <div class="card mb-3 ms-3" style="max-width: 840px;">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="row g-0">
                                    <div class="col-md-4">
                                        <img src="<%#Eval("ImagenUrl") %>" class="img-fluid rounded-start">
                                    </div>
                                    <div class="col-md-8">
                                        <div class="mb-3 icon-fav">
                                            <asp:ImageButton ID="btnFavoritos" CssClass="btn btn-light fav-boton"
                                                OnClick="btnFavoritos_Click" ImageUrl="~/Images/corazon.png"
                                               CommandArgument='<%# Eval ("Id") %>' title="Añadir a favoritos" runat="server" />
                                        </div>
                                        <hr />
                                        <div class="card-body">
                                            <h3 class="card-title"><%#Eval("Nombre") %></h3>
                                            <p class="card-text precio-tarjeta">$<%#Eval("Precio") %></p>
                                        </div>
                                        <hr />
                                        <div class="card-body">
                                            <p class="card-text"><%#Eval("Descripcion") %></p>
                                        </div>
                                        <div class="card-footer">
                                            <small class="text-body-secondary"><%#Eval("Marca") %></small>
                                        </div>
                                        <div class="card-footer">
                                            <small class="text-body-secondary"><%#Eval("Categoria") %></small>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div class="col-1"></div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="panelEditar" Visible="false">
        <div class="row g-0 text-center" style="background-color: white">
            <div class="col-sm-6 col-md-8">
                <asp:UpdatePanel runat="server" ID="UpdateImg">
                    <ContentTemplate>
                        <div class="col">
                            <div class="mb-3">
                                <div style="padding: 30px">
                                    <asp:Image ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS1f4C-cWV03_czRXhL1THkOdS9RDnAtPxRnA&s" Width="60%" runat="server" ID="imgArticulo" />
                                </div>
                                <h4>Descripción</h4>
                                <div>
                                    <asp:TextBox runat="server" TextMode="MultiLine" BackColor="#ededed" Rows="7" Width="80%"
                                        ID="txtDescripcion" />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-6 col-md-4">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <h4>Id</h4>
                            <div>
                                <asp:TextBox runat="server" ID="txtId" BackColor="#ededed" Width="95%" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="mb-3">
                            <h4>Marca</h4>
                            <div>
                                <asp:DropDownList runat="server" ID="ddlMarca" BackColor="#ededed" CssClass="form-select" Width="95%"></asp:DropDownList>
                                <asp:Label ID="lblMarca" CssClass="lbl-invalid" Visible="false" runat="server" />
                            </div>
                        </div>
                        <div class="mb-3">
                            <h4>Categoria</h4>
                            <div>
                                <asp:DropDownList runat="server" ID="ddlCategoria" BackColor="#ededed" CssClass="form-select" Width="95%"></asp:DropDownList>
                                <asp:Label ID="lblCategoria" CssClass="lbl-invalid" Visible="false" runat="server" />
                            </div>
                        </div>
                        <div class="mb-3">
                            <h4>Codigo de artículo</h4>
                            <div>
                                <asp:TextBox runat="server" ID="txtCodigo" BackColor="#ededed" Width="95%" CssClass="form-control" />
                                <asp:Label ID="lblCodigo" CssClass="lbl-invalid" Visible="false" runat="server" />
                            </div>
                        </div>
                        <div class="mb-3">
                            <h4>Nombre de artículo</h4>
                            <div>
                                <asp:TextBox runat="server" ID="txtNombre" BackColor="#ededed" Width="95%" CssClass="form-control" />
                                <asp:Label ID="lblNombre" CssClass="lbl-invalid" Visible="false" runat="server" />
                            </div>
                        </div>
                        <div class="mb-3">
                            <h4>Precio</h4>
                            <div>
                                <asp:TextBox runat="server" ID="txtPrecio" BackColor="#ededed" Width="95%" CssClass="form-control" />
                                <asp:Label ID="lblPrecio" CssClass="lbl-invalid" Visible="false" runat="server" />
                            </div>
                        </div>
                        <div class="mb-3">
                            <h4>Imagen</h4>
                            <div>
                                <asp:TextBox runat="server" ID="txtImagen" OnTextChanged="txtImagen_TextChanged" BackColor="#ededed" Width="95%" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="mb-3">
                            <asp:Button Text="Guardar" runat="server" ID="btnGuardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary" />
                            <asp:HyperLink NavigateUrl="~/ListadoArticulos.aspx" Text="Cancelar" CssClass="btn btn-secondary" runat="server" />
                            <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger" runat="server" />
                        </div>
                        </div>
    </div>

        <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5" id="staticBackdropLabel">¿Esta seguro de eliminar este artículo?</h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Cancelar"></button>
                    </div>
                    <div class="modal-footer">
                        <asp:Button Text="Eliminar" ID="btnModalEliminar" OnClick="btnModalEliminar_Click" CssClass="btn btn-danger" runat="server" />
                        <asp:Button Text="Cancelar" ID="btnModalCancelar" data-bs-dismiss="modal" CssClass="btn btn-secondary" runat="server" />
                    </div>
                </div>
            </div>
        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
