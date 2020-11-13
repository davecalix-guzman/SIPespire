<%@ Page
    Title="Home Page"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="SI_PESPIRE_WEB._Default" %>

<asp:Content
    ID="BodyContent"
    ContentPlaceHolderID="MainContent"
    runat="server">
    <asp:UpdatePanel ID="upDefault" runat="server">
        <ContentTemplate>
            <div class="panel panel-flat">
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12">
                            <h4><i class="fa fa-check-square-o"></i>&nbsp;Bienvenido</h4>
                            La administración web del Sistema le permite realizar los mantenimientos necesarios a las tablas catálogo, las configuraciones del sistema, asi como poder revisar información en las diferentes bandejas, consultas y reportes.
                            <br />
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel panel-flat">
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-2">
                            <div style="padding-bottom: 22px"></div>
                            <div class="panel status panel-info">
                                <div class="panel-heading" style="text-align: center">
                                    <asp:Label ID="lblDiaLetras" runat="server" Font-Bold="true" Font-Size="15pt" Text=""></asp:Label>
                                </div>
                                <div class="panel-body text-center">
                                    <strong>
                                        <asp:Label ID="lblDiaNumero" runat="server" Font-Bold="true" Font-Size="34pt" Text=""></asp:Label>
                                    </strong>
                                    <br />
                                    <strong>
                                        <asp:Label ID="lblFecha" runat="server" Font-Bold="true" Font-Size="12pt" Text=""></asp:Label>
                                    </strong>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div style="padding-bottom: 22px"></div>
                            <table class="table table-striped table-bordered table-hover" style="background-color: #F0FFFF; height: 170px;">
                                <tr class="table-info">
                                    <td style="width: 100px"><i class="fa fa-user"></i>&nbsp;Usuario</td>
                                    <td>
                                        <asp:Label ID="lblUsuario" runat="server" Font-Bold="true" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="table-info">
                                    <td style="width: 100px"><i class="fa fa-font"></i>&nbsp;Nombre</td>
                                    <td>
                                        <asp:Label ID="lblNombreUsuario" runat="server" Font-Bold="true" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="table-info">
                                    <td style="width: 100px"><i class="fa fa-unlock-alt"></i>&nbsp;Rol</td>
                                    <td>
                                        <asp:Label ID="lblRol" runat="server" Font-Bold="true" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="table-info">
                                    <td style="width: 100px"><i class="fa fa-dot-circle-o"></i>&nbsp;Oficina</td>
                                    <td>
                                        <asp:Label ID="lblOficina" runat="server" Font-Bold="true" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
