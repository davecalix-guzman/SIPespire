<%@ Page Title=""
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="wfmAcciones.aspx.cs"
    Inherits="SI_PESPIRE_WEB.Modulos.Seguridad.wfmAcciones" %>

<asp:Content
    ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">
    <asp:UpdatePanel
        ID="upAcciones"
        runat="server">
        <ContentTemplate>
            <div class="panel">
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-5">
                            <span class="help-block"><i class="fa fa-info-circle" style="color: #1864AB"></i>&nbsp;Ingrese la información de la acción por crear</span>
                            <hr />
                            <div class="col-md-6">
                                <div class="widget">

                                    <label>Módulo al que pertenece la acción</label>
                                    <dx:ASPxComboBox
                                        ID="cboModulo"
                                        CssClass="form-control"
                                        Native="true"
                                        NullText="Seleccione un módulo"
                                        runat="server"
                                        Width="100%"
                                        Theme="Metropolis"
                                        AutoPostBack="True">
                                        <ValidationSettings
                                            ErrorDisplayMode="Text"
                                            Display="Dynamic"
                                            ErrorTextPosition="Bottom"
                                            ErrorFrameStyle-ForeColor="Red"
                                            ValidateOnLeave="False"
                                            ValidationGroup="nuevaAccion">
                                            <RequiredField
                                                IsRequired="True"
                                                ErrorText="Seleccione el módulo" />
                                            <ErrorFrameStyle
                                                ForeColor="Red">
                                            </ErrorFrameStyle>
                                        </ValidationSettings>
                                        <FocusedStyle BackColor="#F1D47F"></FocusedStyle>
                                    </dx:ASPxComboBox>

                                    <label>Nombre de acción</label>
                                    <dx:ASPxTextBox ID="txtNombreAccion"
                                        CssClass="form-control-form"
                                        Native="true"
                                        runat="server"
                                        Width="100%"
                                        MaxLength="30">
                                        <ValidationSettings
                                            ErrorDisplayMode="Text"
                                            Display="Dynamic"
                                            ErrorTextPosition="Bottom"
                                            ErrorFrameStyle-ForeColor="Red"
                                            ValidateOnLeave="False"
                                            ValidationGroup="nuevaAccion">
                                            <RequiredField
                                                IsRequired="True"
                                                ErrorText="Ingrese el nombre de la acción" />
                                            <RegularExpression
                                                ErrorText="Contiene caracteres inválidos"
                                                ValidationExpression="^[a-zA-Z0-9-Z\s\_\Ñ\ñ]*$" />
                                            <ErrorFrameStyle
                                                ForeColor="Red">
                                            </ErrorFrameStyle>
                                        </ValidationSettings>
                                        <FocusedStyle BackColor="#F1D47F"></FocusedStyle>
                                    </dx:ASPxTextBox>

                                    <label>Es una pestaña del menú de aplicación</label>
                                    <dx:ASPxCheckBox
                                        ID="chkPadre"
                                        runat="server"
                                        Width="100%"
                                        Theme="Metropolis"
                                        Native="True"
                                        CssClass="form-control">
                                    </dx:ASPxCheckBox>

                                    <label>Es un formulario</label>
                                    <dx:ASPxCheckBox
                                        ID="chkMenu"
                                        runat="server"
                                        Width="100%"
                                        Theme="Metropolis"
                                        Native="True"
                                        CssClass="form-control">
                                    </dx:ASPxCheckBox>

                                    <label>Ícono</label>
                                    <dx:ASPxTextBox ID="txtIcono"
                                        CssClass="form-control"
                                        Native="true"
                                        runat="server"
                                        Width="100%"
                                        MaxLength="50">
                                        <FocusedStyle BackColor="#F1D47F"></FocusedStyle>
                                    </dx:ASPxTextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="widget">
                                    <label>Clase de CSS</label>
                                    <dx:ASPxTextBox ID="txtClaseCss"
                                        CssClass="form-control"
                                        Native="true"
                                        runat="server"
                                        Width="100%"
                                        MaxLength="30">
                                        <FocusedStyle BackColor="#F1D47F"></FocusedStyle>
                                    </dx:ASPxTextBox>

                                    <label>Nombre del formulario</label>
                                    <dx:ASPxTextBox ID="txtNombreFormulario"
                                        CssClass="form-control-form"
                                        Native="true"
                                        ToolTip="El nombre debe contener el estilo de escritura CamelCase"
                                        OnTextChanged="txtNombreFormulario_OnTextChanged"
                                        AutoPostBack="True"
                                        runat="server"
                                        Width="100%"
                                        MaxLength="50">
                                        <ValidationSettings
                                            ErrorDisplayMode="Text"
                                            Display="Dynamic"
                                            ErrorTextPosition="Bottom"
                                            ErrorFrameStyle-ForeColor="Red"
                                            ValidateOnLeave="False"
                                            ValidationGroup="nuevaAccion">
                                            <RequiredField
                                                IsRequired="True"
                                                ErrorText="Ingrese el nombre del formulario" />
                                            <RegularExpression
                                                ErrorText="Contiene caracteres inválidos"
                                                ValidationExpression="^([A-Z][a-z0-9]+){1,}" />
                                            <ErrorFrameStyle
                                                ForeColor="Red">
                                            </ErrorFrameStyle>
                                        </ValidationSettings>
                                        <FocusedStyle BackColor="#F1D47F"></FocusedStyle>
                                    </dx:ASPxTextBox>

                                    <label>Enlace de formulario</label>
                                    <dx:ASPxTextBox ID="txtEnlace"
                                        CssClass="form-control-form"
                                        Native="true"
                                        Enabled="False"
                                        runat="server"
                                        Width="100%"
                                        MaxLength="50">
                                        <FocusedStyle BackColor="#F1D47F"></FocusedStyle>
                                    </dx:ASPxTextBox>

                                    <label>Activo</label>
                                    <dx:ASPxCheckBox
                                        ID="chkEstado"
                                        runat="server"
                                        Width="100%"
                                        Theme="Metropolis"
                                        Native="True"
                                        CssClass="form-control">
                                    </dx:ASPxCheckBox>

                                    <label>Fuera de linea</label>
                                    <dx:ASPxCheckBox
                                        ID="chkOffline"
                                        runat="server"
                                        Width="100%"
                                        Theme="Metropolis"
                                        Native="True"
                                        CssClass="form-control">
                                    </dx:ASPxCheckBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-7">
                            <span class="help-block"><i class="fa fa-info-circle" style="color: #FF8800"></i>&nbsp;Los cambios realizado en este formulario afectan el funcionamiento de la aplicación, se recomienda hacerlo con precaución.</span>
                            <hr />
                            <div class="widget" style="padding-top: 26px">
                                <dx:ASPxGridView
                                    ID="dgvAcciones"
                                    ClientInstanceName="dgvAcciones"
                                    Width="100%"
                                    Theme="Metropolis"
                                    KeyFieldName="AccionId"
                                    runat="server"
                                    OnCustomButtonCallback="dgvAcciones_OnCustomButtonCallback"
                                    EnableCallBacks="False"
                                    SettingsLoadingPanel-Text="Cargando&amp;hellip;"
                                    AutoGenerateColumns="False">
                                    <SettingsBehavior
                                        AllowFocusedRow="True"
                                        ProcessSelectionChangedOnServer="True" />
                                    <Styles>
                                        <Header BackColor="#3A454E"
                                            ForeColor="White"
                                            Font-Size="1.0em">
                                        </Header>
                                        <SelectedRow
                                            BackColor="#FF8800"
                                            ForeColor="#FFFFFF">
                                        </SelectedRow>
                                    </Styles>
                                    <font size="0.8em"></font>
                                    <SettingsLoadingPanel
                                        Text="Cargando&amp;hellip;" />
                                    <Columns>
                                        <dx:GridViewDataTextColumn
                                            FieldName="AccionId"
                                            VisibleIndex="0"
                                            Visible="false"
                                            Caption="">
                                        </dx:GridViewDataTextColumn>

                                        <dx:GridViewDataTextColumn
                                            FieldName="Modulo"
                                            VisibleIndex="2"
                                            Visible="true"
                                            Caption="MÓDULO"
                                            Width="170">
                                            <HeaderStyle HorizontalAlign="Center"
                                                VerticalAlign="Middle" />
                                            <CellStyle HorizontalAlign="Left"></CellStyle>
                                        </dx:GridViewDataTextColumn>

                                        <dx:GridViewDataTextColumn
                                            FieldName="Nombre"
                                            VisibleIndex="3"
                                            Visible="true"
                                            Caption="ACCIÓN"
                                            Width="150">
                                            <HeaderStyle HorizontalAlign="Center"
                                                VerticalAlign="Middle" />
                                            <CellStyle HorizontalAlign="Left"></CellStyle>
                                        </dx:GridViewDataTextColumn>

                                        <dx:GridViewDataTextColumn
                                            FieldName="Padre"
                                            VisibleIndex="4"
                                            Caption="PADRE">
                                            <HeaderStyle
                                                HorizontalAlign="Center"
                                                VerticalAlign="Middle" />
                                            <CellStyle HorizontalAlign="Center"></CellStyle>
                                        </dx:GridViewDataTextColumn>


                                        <dx:GridViewDataTextColumn
                                            FieldName="Menu"
                                            VisibleIndex="5"
                                            Caption="MENÚ">
                                            <HeaderStyle HorizontalAlign="Center"
                                                VerticalAlign="Middle" />
                                            <CellStyle HorizontalAlign="Center"></CellStyle>
                                        </dx:GridViewDataTextColumn>

                                        <dx:GridViewDataTextColumn
                                            FieldName="Enlace"
                                            VisibleIndex="6"
                                            Caption="ENLACE">
                                            <HeaderStyle HorizontalAlign="Center"
                                                VerticalAlign="Middle" />
                                        </dx:GridViewDataTextColumn>

                                        <dx:GridViewCommandColumn
                                            ButtonType="Image"
                                            Caption="EDITAR"
                                            VisibleIndex="1"
                                            Name="Seleccionar acción para modificar">
                                            <CustomButtons>
                                                <dx:GridViewCommandColumnCustomButton
                                                    ID="cbSeleccionarRegistro">
                                                    <Image ToolTip="Seleccionar registro"
                                                        Url="../../Recursos/search.png">
                                                    </Image>
                                                </dx:GridViewCommandColumnCustomButton>
                                            </CustomButtons>
                                            <HeaderStyle HorizontalAlign="Center"
                                                VerticalAlign="Middle" />
                                            <CellStyle HorizontalAlign="Center"></CellStyle>
                                        </dx:GridViewCommandColumn>
                                    </Columns>
                                    <Settings
                                        GridLines="Horizontal"
                                        ShowFooter="True"
                                        ShowHeaderFilterButton="true" />
                                    <SettingsPopup>
                                        <HeaderFilter Height="300" />
                                        <CustomizationWindow />
                                    </SettingsPopup>
                                    <SettingsPager PageSize="6"></SettingsPager>
                                </dx:ASPxGridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel">
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-6">
                            <dx:ASPxButton
                                ID="btnNuevo"
                                runat="server"
                                Width="80px"
                                ToolTip="Nuevo"
                                OnClick="btnNuevo_OnClick"
                                Text="Nuevo"
                                Native="true"
                                CssClass="btn btn-teal"
                                Theme="Metropolis"
                                Visible="true">
                            </dx:ASPxButton>

                            <dx:ASPxButton
                                ID="btnGuardar"
                                runat="server"
                                ToolTip="Guardar nueva acción"
                                Text="Guardar"
                                OnClick="btnGuardar_OnClick"
                                ValidationGroup="nuevaAccion"
                                Width="80px"
                                Native="true"
                                Theme="Metropolis"
                                CssClass="btn btn-green"
                                Visible="true">
                            </dx:ASPxButton>

                            <dx:ASPxButton
                                ID="btnCancelar"
                                runat="server"
                                Width="80px"
                                ToolTip="Cancelar"
                                OnClick="btnCancelar_OnClick"
                                Text="Cancelar"
                                Native="true"
                                Theme="Metropolis"
                                CssClass="btn btn-default"
                                Visible="true">
                            </dx:ASPxButton>

                            <dx:ASPxButton
                                ID="btnEliminar"
                                runat="server"
                                Width="80px"
                                ToolTip="Eliminar acciones"
                                Text="Eliminar"
                                Native="true"
                                Theme="Metropolis"
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
