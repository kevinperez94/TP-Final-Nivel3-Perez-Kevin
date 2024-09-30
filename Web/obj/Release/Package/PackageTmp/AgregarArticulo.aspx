<%@ Page Title="Agregar" Language="C#" MasterPageFile="~/Master2.Master" AutoEventWireup="true" CodeBehind="AgregarArticulo.aspx.cs" Inherits="Web.AgregarArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <h1>agregar producto</h1>
    <div class="row">
        <hr />
        <asp:UpdatePanel runat="server" ID="UpdateImg">
            <ContentTemplate>
                <div class="col">
                    <div class="mb-3">
                        <asp:Image Width="300px" ID="imagenArticulo" ImageUrl="~/Images/image-not-found.png" runat="server" />
                    </div>
                    <div class="mb-3">
                        <asp:Label Text="Subir imagen url del producto" runat="server" CssClass="h6" />
                        <asp:TextBox runat="server" AutoPostBack="true" OnTextChanged="txtImg_TextChanged" ID="txtImg" CssClass="form-control" />
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="row">
        <asp:UpdatePanel runat="server" ID="upForm">
            <ContentTemplate>
                <div class="col">
                    <div class="mb-3">
                        <asp:Label Text="Id" runat="server" CssClass="h6" />
                        <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
                    </div>
                    <div class="mb-3">
                        <asp:Label Text="Marca" runat="server" CssClass="h6" />
                        <asp:DropDownList runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlMarca_SelectedIndexChanged" ID="ddlMarca"></asp:DropDownList>
                        <asp:Label ID="lblMarca" CssClass="lbl-invalid" Visible="false" runat="server" />
                    </div>
                    <div class="mb-3">
                        <asp:Label Text="Categoria" runat="server" CssClass="h6" />
                        <asp:DropDownList runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged" ID="ddlCategoria"></asp:DropDownList>
                        <asp:Label ID="lblCategoria" CssClass="lbl-invalid" Visible="false" runat="server" />
                    </div>
                    <div class="mb-3">
                        <asp:Label Text="Codigo de articulo" runat="server" CssClass="h6" />
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtCodigo"
                            AutoPostBack="true" OnTextChanged="txtCodigo_TextChanged" />
                        <asp:Label ID="lblCodigo" CssClass="lbl-invalid" Visible="false" runat="server" />
                    </div>
                    <div class="mb-3">
                        <asp:Label Text="Nombre de articulo" runat="server" CssClass="h6" />
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre"
                            AutoPostBack="true" OnTextChanged="txtNombre_TextChanged" />
                        <asp:Label ID="lblNombre" CssClass="lbl-invalid" Visible="false" runat="server" />
                    </div>
                    <div class="mb-3">
                        <asp:Label Text="Precio" runat="server" CssClass="h6" />
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtPrecio"
                            AutoPostBack="true" OnTextChanged="txtPrecio_TextChanged" />
                        <asp:Label ID="lblPrecio" CssClass="lbl-invalid" Visible="false" runat="server" />
                    </div>
                    <div class="mb-3">
                        <asp:Label Text="Descripción" runat="server" CssClass="h6" />
                        <asp:TextBox runat="server" TextMode="MultiLine" Rows="7" CssClass="form-control"
                            OnTextChanged="txtDescripcion_TextChanged" AutoPostBack="true" ID="txtDescripcion" />
                        <asp:Label ID="lblDescrip" CssClass="lbl-invalid" Visible="false" runat="server" />
                    </div>
                    <div class="mb-3">
                        <asp:Button Text="Subir" runat="server" CssClass="btn btn-primary" OnClick="btnSubir_Click" ID="btnSubir" />
                        <asp:HyperLink NavigateUrl="~/ListadoArticulos.aspx" CssClass="btn btn-danger" Text="Cancelar" runat="server" />
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>
