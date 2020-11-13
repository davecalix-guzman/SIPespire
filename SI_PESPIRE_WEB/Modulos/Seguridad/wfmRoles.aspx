<%@ Page
    Title=""
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="wfmRoles.aspx.cs"
    Inherits="SI_PESPIRE_WEB.Modulos.Seguridad.wfmRoles" %>

<asp:Content
    ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">
    <asp:UpdatePanel ID="uRoles" runat="server">
        <ContentTemplate>
            <div class="panel">
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-4">
                            <label>Seleccione el rol, actualícelo o agregue/elimine acciones</label>
                            <hr />
                            <label>Roles</label>
                            <dx:ASPxComboBox
                                ID="cboRoles"
                                OnSelectedIndexChanged="cboRoles_OnSelectedIndexChanged"
                                CssClass="form-control"
                                Native="true"
                                runat="server"
                                Width="90%"
                                Theme="Metropolis"
                                AutoPostBack="True">
                                <FocusedStyle BackColor="#F1D47F"></FocusedStyle>
                            </dx:ASPxComboBox>
                            <div class="widget">
                                <div class="widget-content padding" style="padding-top: 20px">
                                    <label>Acciones por rol</label>
                                    <div style="height: 220px; overflow: auto; width: 90%; border: 1px solid #DCDCDC; padding-top: 10px">
                                        <dx:ASPxTreeView
                                            ID="tvAcciones"
                                            runat="server"
                                            Width="100%"
                                            AllowCheckNodes="True"
                                            CheckNodesRecursive="true"
                                            Theme="Metropolis">
                                        </dx:ASPxTreeView>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-4">
                            <div class="widget">
                                <div class="widget-content padding">
                                    <label>Ingrese la información para crear nuevo rol</label>
                                    <hr />

                                    <label>Nombre de rol</label>
                                    <dx:ASPxTextBox ID="txtNombres"
                                        CssClass="form-control"
                                        Native="true"
                                        runat="server"
                                        Width="100%"
                                        MaxLength="30">
                                        <ValidationSettings
                                            ErrorDisplayMode="Text"
                                            Display="Dynamic"
                                            ErrorTextPosition="Bottom"
                                            ErrorFrameStyle-ForeColor="Red"
                                            ValidationGroup="rolNuevo">
                                            <RequiredField
                                                IsRequired="True"
                                                ErrorText="Ingrese el nombre del rol" />
                                            <RegularExpression
                                                ErrorText="Contiene caracteres inválidos"
                                                ValidationExpression="^[a-zA-Z0-9-Z\s\_\Ñ\ñ]*$" />
                                            <ErrorFrameStyle
                                                ForeColor="Red">
                                            </ErrorFrameStyle>
                                        </ValidationSettings>
                                        <FocusedStyle BackColor="#F1D47F"></FocusedStyle>
                                    </dx:ASPxTextBox>

                                    <label>Descripción de rol</label>
                                    <dx:ASPxTextBox ID="txtDescripcion"
                                        CssClass="form-control"
                                        Native="true"
                                        runat="server"
                                        Width="100%"
                                        Theme="Metropolis"
                                        MaxLength="50">
                                        <FocusedStyle BackColor="#F1D47F"></FocusedStyle>
                                    </dx:ASPxTextBox>

                                    <label>Activo</label>
                                    <dx:ASPxCheckBox
                                        ID="chkActivo"
                                        runat="server"
                                        Width="100%"
                                        Theme="Metropolis"
                                        Native="True"
                                        CssClass="form-control">
                                    </dx:ASPxCheckBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel">
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-4">
                            <dx:ASPxButton
                                ID="btnActualizar"
                                runat="server"
                                ToolTip="Actualice acciones para un rol y guardelo"
                                Text="Actualizar"
                                OnClick="btnActualizar_OnClick"
                                Width="80px"
                                Native="true"
                                CssClass="btn btn-green"
                                Visible="true">
                            </dx:ASPxButton>
                        </div>
                        <div class="col-md-4">

                            <dx:ASPxButton
                                ID="btnNuevo"
                                runat="server"
                                Width="80px"
                                ToolTip="Nuevo"
                                Text="Nuevo"
                                OnClick="btnNuevo_OnClick"
                                Native="true"
                                CssClass="btn btn-teal"
                                Visible="true">
                            </dx:ASPxButton>

                            <dx:ASPxButton
                                ID="btnGuardar"
                                runat="server"
                                ToolTip="Guardar nuevo rol para usuario"
                                OnClick="btnGuardar_OnClick"
                                Text="Guardar"
                                ValidationGroup="rolNuevo"
                                Width="80px"
                                Native="true"
                                CssClass="btn btn-green"
                                Visible="true">
                            </dx:ASPxButton>

                            <dx:ASPxButton
                                ID="btnCancelar"
                                runat="server"
                                Width="80px"
                                OnClick="btnCancelar_OnClick"
                                ToolTip="Cancelar"
                                Text="Cancelar"
                                Native="true"
                                CssClass="btn btn-default"
                                Visible="true">
                            </dx:ASPxButton>

                            <dx:ASPxButton
                                ID="btnEliminar"
                                runat="server"
                                Width="80px"
                                ToolTip="Eliminar roles no asociados a usuarios"
                                OnClick="btnEliminar_OnClick"
                                Text="Eliminar"
                                Native="true"
                                CssClass="btn btn-danger"
                                Visible="true">
                            </dx:ASPxButton>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
