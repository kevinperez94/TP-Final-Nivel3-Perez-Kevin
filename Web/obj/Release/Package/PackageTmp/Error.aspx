<%@ Page Title="Ups! ha ocurridod un error.." Language="C#" MasterPageFile="~/Error.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Web.Error1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <br />
    <br />
    <br />
    <br />
    <div class="row">
        <div class="col-2"></div>
        <div class="col">
            <div class="mb-2">
                <h1 class="centrar-texto">¡ERROR!</h1>
            </div>
        </div>
        <div class="col-2"></div>
    </div>
    <div class="row">
        <div class="col-2"></div>
        <div class="col">
            <div class="mb-2">
                <asp:Label ID="lblError" CssClass="mensaje-login" Visible="false" runat="server" />
            </div>
        </div>
        <div class="col-2"></div>
    </div>

</asp:Content>
