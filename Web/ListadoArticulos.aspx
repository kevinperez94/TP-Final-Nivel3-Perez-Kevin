<%@ Page Title="Listado" Language="C#" MasterPageFile="~/Master2.Master" AutoEventWireup="true" CodeBehind="ListadoArticulos.aspx.cs" Inherits="Web.ListadoArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <h1 style="text-align: center">artículos</h1>
    <hr />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-6">
                    <div class="mb-2">
                        <asp:TextBox runat="server" ID="txtBuscar" CssClass="form-control" TextMode="Search"
                            OnTextChanged="txtBuscar_TextChanged" placeholder="Encuentra el artículo que buscas..." />
                    </div>
                </div>
                <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
                    <div class="mb-3">
                        <asp:CheckBox runat="server" ID="chekFiltrar" AutoPostBack="true" OnCheckedChanged="chekFiltrar_CheckedChanged" />
                        <asp:Label Text="Filtrar" runat="server" />
                    </div>
                </div>
                <asp:Panel runat="server" ID="pnlFiltros" Visible="false">
                    <div class="row">
                        <div class="col-3">
                            <div class="mb-3">
                                <asp:Label Text="Marca" runat="server" />
                                <asp:DropDownList CssClass="form-select" ID="ddlMarca" runat="server" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-3">
                            <div class="mb-3">
                                <asp:Label Text="Categoria" runat="server" />
                                <asp:DropDownList CssClass="form-select" ID="ddlCategoria" runat="server" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="mb-3">
                            <asp:Button Text="Buscar" ID="btnBuscarFiltrado" OnClick="btnBuscarFiltrado_Click" CssClass="btn btn-primary" runat="server" />
                            <asp:Button Text="Reset" ID="btnReset" OnClick="btnReset_Click" CssClass="btn btn-secondary" runat="server" />
                        </div>
                    </div>
                </asp:Panel>
                <div style="text-align: right" class="col-12 mb-1">
                    <asp:HyperLink NavigateUrl="~/AgregarArticulo.aspx" CssClass="btn btn-success btn-sm" Text="Agregar" runat="server" />
                    <asp:Button Text="Seleccionar" ID="btnSelec" OnClick="btnSelec_Click" CssClass="btn btn-secondary btn-sm" runat="server" />
                    <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger btn-sm" runat="server" Visible="false" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="col-2"></div>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:GridView runat="server" CssClass="table table-bordered border-dark" DataKeyNames="Id"
                OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" AutoGenerateColumns="false" ID="dgvArticulos">
                <Columns>
                    <asp:ImageField DataImageUrlField="ImagenUrl" HeaderText="" ItemStyle-Width="10%" ControlStyle-Width="50%"></asp:ImageField>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Marca" DataField="Marca" />
                    <asp:BoundField HeaderText="Categoria" DataField="Categoria" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" />
                    <asp:CommandField ShowSelectButton="true" SelectText="Editar" ControlStyle-CssClass="btn btn-warning btn-sm" />
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:CheckBox ID="checkSeleccionado" OnCheckedChanged="checkSeleccionado_CheckedChanged" AutoPostBack="true" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="modal fade" id="confirmEliminarModal" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h3 class="modal-title fs-5">
                                <asp:Literal ID="litModalTitulo" Text="¿Esta seguro de eliminar este artículo?" runat="server" />
                            </h3>
                            <asp:Button CssClass="btn-close" data-bs-dismiss="modal" aria-label="Cerrar" runat="server" />
                        </div>
                        <div class="modal-body">
                            <asp:Literal ID="litArticulos" runat="server" />
                        </div>
                        <div class="modal-footer">
                            <asp:Button Text="Eliminar" ID="btnConfirmEliminar" OnClick="btnConfirmEliminar_Click" CssClass="btn btn-danger" runat="server" />
                            <asp:Button Text="Cancelar" data-bs-dismiss="modal" CssClass="btn btn-secondary" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="col-2"></div>

</asp:Content>
