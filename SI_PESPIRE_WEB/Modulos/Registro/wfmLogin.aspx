<%@ Page
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="wfmLogin.aspx.cs"
    Inherits="SI_PESPIRE_WEB.Modulos.Registro.wfmLogin" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Inicio de sesión</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-touch-fullscreen" content="yes" />
    <link href="http://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700" rel="stylesheet" type="text/css" />
    <link type="text/css" href="~/Contenido/assets/plugins/iCheck/skins/minimal/blue.css" rel="stylesheet" />
    <link type="text/css" href="~/Contenido/assets/fonts/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link type="text/css" href="~/Contenido/assets/css/styles.css" rel="stylesheet" />
    <style>
        td.dxic {
            border: none !important;
            height: 30px;
        }

        .dxeTextBox_DevEx, .dxeTextBox_DevEx:focus {
            border: 1px solid #d9dae0;
        }

        .txtLogin {
            padding-left: 25px !important;
            text-transform: none !important;
        }
    </style>

</head>
<body class="focused-form" style="background-image:url(../../Recursos/FondoFood.jpg); background-position-y:top">
    <div class="container"
        id="login-form">
  <%--      <a class="login-logo">
            <img width="180" height="50" src='<%= ResolveUrl("~/Recursos/LogoWarehouse.png") %>' alt="Warehouse" />
        </a>--%>
        <div class="row">
            <form runat="server" class="form-horizontal" id="validate_form">               
                <div id="pnlLogin" runat="server" style="padding-top:200px" class="col-md-4 col-md-offset-4">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h2>Inicio de sesión</h2>
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <div class="col-xs-12">
                                    <div class="input-group" style="margin-bottom: 5px">
                                        <span class="input-group-addon">
                                            <i class="fa fa-user"></i>
                                        </span>
                                        <dx:ASPxTextBox
                                            ID="txtNombreUsuario"
                                            MaxLength="15"
                                            class="txtLogin"
                                            runat="server"
                                            Width="100%"
                                            Theme="MetropolisBlue"
                                            BackColor="#FFFFCC">
                                            <ValidationSettings
                                                Display="Dynamic"
                                                ErrorDisplayMode="ImageWithTooltip">
                                                <RequiredField
                                                    IsRequired="true"
                                                    ErrorText="Ingrese su nombre de usuario" />
                                            </ValidationSettings>
                                            <FocusedStyle
                                                BackColor="#FFFFCC"
                                                Border-BorderColor="#E8C500">
                                            </FocusedStyle>
                                        </dx:ASPxTextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group" style="margin-bottom: 5px">
                                <div class="col-xs-12">
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <i class="fa fa-key"></i>
                                        </span>
                                        <dx:ASPxTextBox
                                            ID="txtContrasenia"
                                            Password="true"
                                            MaxLength="15"
                                            class="txtLogin"
                                            runat="server"
                                            Width="100%"
                                            Theme="MetropolisBlue"
                                            BackColor="#FFFFCC">
                                            <ValidationSettings
                                                Display="Dynamic"
                                                ErrorDisplayMode="ImageWithTooltip">
                                                <RequiredField
                                                    IsRequired="true"
                                                    ErrorText="Ingrese su contraseña" />
                                            </ValidationSettings>
                                            <FocusedStyle
                                                BackColor="#FFFFCC"
                                                Border-BorderColor="#E8C500">
                                            </FocusedStyle>
                                        </dx:ASPxTextBox>
                                    </div>
                                </div>
                            </div>
                            <asp:Label
                                ID="lblMensaje"
                                runat="server"
                                Text=""
                                Visible="false">
                            </asp:Label>
                            <dx:ASPxButton
                                ID="btnEntrar"
                                OnClick="btnEntrar_OnClick"
                                runat="server"
                                CssClass="btn btn-danger pull-right"
                                Native="true"
                                Text="Entrar">
                            </dx:ASPxButton>
                        </div>
                    </div>
                </div>


                <div id="pnlResetearContrasenia" runat="server" visible="false" class="col-md-4 col-md-offset-4">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h2>Se requiere actualizar la contraseña</h2>
                        </div>
                        <div class="panel-body">
                            <label>Ingrese su contraseña actual</label>
                            <dx:ASPxTextBox
                                ID="txtContraseniaActual"
                                CssClass="form-control"
                                Native="True"
                                runat="server"
                                Width="100%"
                                Theme="MetropolisBlue"
                                MaxLength="100"
                                Password="True">
                                <ValidationSettings
                                    ErrorDisplayMode="Text"
                                    Display="Dynamic"
                                    ValidationGroup="cc"
                                    ErrorTextPosition="Bottom"
                                    ErrorFrameStyle-ForeColor="Red">
                                    <ErrorFrameStyle ForeColor="Red">
                                    </ErrorFrameStyle>
                                    <RequiredField
                                        IsRequired="true"
                                        ErrorText="Este campo es requerido" />
                                </ValidationSettings>
                                <FocusedStyle
                                    BackColor="#FFFFCC"
                                    Border-BorderColor="#E8C500">
                                </FocusedStyle>
                            </dx:ASPxTextBox>


                            <label>Nueva contraseña</label>
                            <dx:ASPxTextBox
                                ID="txtContraseniaNueva"
                                CssClass="form-control"
                                Native="True"
                                runat="server"
                                Width="100%"
                                Theme="MetropolisBlue"
                                MaxLength="100"
                                Password="True">
                                <ValidationSettings
                                    ErrorDisplayMode="Text"
                                    Display="Dynamic"
                                    ValidationGroup="cc"
                                    ErrorTextPosition="Bottom"
                                    ErrorFrameStyle-ForeColor="Red">
                                    <ErrorFrameStyle ForeColor="Red">
                                    </ErrorFrameStyle>
                                    <RequiredField
                                        IsRequired="true"
                                        ErrorText="Este campo es requerido" />
                                </ValidationSettings>
                                <FocusedStyle
                                    BackColor="#FFFFCC"
                                    Border-BorderColor="#E8C500">
                                </FocusedStyle>
                            </dx:ASPxTextBox>

                            <label>Confirmar nueva contraseña</label>
                            <dx:ASPxTextBox
                                ID="txtConfirmarContrasenia"
                                CssClass="form-control"
                                Native="true"
                                runat="server"
                                Width="100%"
                                MaxLength="100"
                                Password="True"
                                Theme="MetropolisBlue">
                                <ValidationSettings
                                    ErrorDisplayMode="Text"
                                    Display="Dynamic"
                                    ValidationGroup="cc"
                                    ErrorTextPosition="Bottom"
                                    ErrorFrameStyle-ForeColor="Red">
                                    <ErrorFrameStyle ForeColor="Red">
                                    </ErrorFrameStyle>

                                    <RequiredField
                                        IsRequired="true"
                                        ErrorText="Este campo es requerido" />
                                </ValidationSettings>
                                <FocusedStyle
                                    BackColor="#FFFFCC">
                                </FocusedStyle>
                            </dx:ASPxTextBox>
                            <hr />
                            <asp:Label
                                ID="lblMensaje2"
                                runat="server"
                                ForeColor="Red"
                                Text=""
                                Visible="false">
                            </asp:Label>

                            <asp:CompareValidator
                                ID="CompareValidator1"
                                Display="Dynamic"
                                runat="server"
                                ControlToCompare="txtContraseniaNueva"
                                ValidationGroup="cc"
                                ControlToValidate="txtConfirmarContrasenia"
                                ErrorMessage="Las contraseñas no coinciden"
                                ForeColor="Red">
                            </asp:CompareValidator>

                            <dx:ASPxButton
                                ID="btnGuardarContrasenia"
                                CssClass="btn btn-teal"
                                Native="true"
                                runat="server"
                                ValidationGroup="cc"
                                Text="Guardar">
                            </dx:ASPxButton>

                            <dx:ASPxButton
                                ID="btnCancelarContrasenia"
                                CssClass="btn btn-default pull-right"
                                Native="true"
                                runat="server"
                                CausesValidation="false"
                                Text="Cancelar">
                            </dx:ASPxButton>
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </div>
    <br />
    <br />
    <div class="text-center" style="padding-top:140px">
        <p style="color:white; font-size:large; font-family:'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif">Gestión administrativa de © WHERE House.</p>
        <p style="color:white; font-size:large; font-family:'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif">©Todos los Derechos Reservados a nombre de <a href="https://www.linkedin.com/in/david-guzman-a07677a0" target="_blank">Soluciones Ingeniosas S.a de C.V</a> 2018.©</p>
    </div>

    <script type="text/javascript" src="../../Contenido/assets/js/jquery-1.10.2.min.js"></script>
    <!-- Load jQuery -->
    <script type="text/javascript" src="../../Contenido/assets/js/jqueryui-1.9.2.min.js"></script>
    <!-- Load jQueryUI -->
    <script type="text/javascript" src="../../Contenido/assets/js/bootstrap.min.js"></script>
    <!-- Load Bootstrap -->
    <script type="text/javascript" src="../../Contenido/assets/plugins/easypiechart/jquery.easypiechart.js"></script>
    <!-- EasyPieChart-->
    <script type="text/javascript" src="../../Contenido/assets/plugins/sparklines/jquery.sparklines.min.js"></script>
    <!-- Sparkline -->
    <script type="text/javascript" src="../../Contenido/assets/plugins/jstree/dist/jstree.min.js"></script>
    <!-- jsTree -->
    <script type="text/javascript" src="../../Contenido/assets/plugins/codeprettifier/prettify.js"></script>
    <!-- Code Prettifier  -->
    <script type="text/javascript" src="../../Contenido/assets/plugins/bootstrap-switch/bootstrap-switch.js"></script>
    <!-- Swith/Toggle Button -->
    <script type="text/javascript" src="../../Contenido/assets/plugins/bootstrap-tabdrop/js/bootstrap-tabdrop.js"></script>
    <!-- Bootstrap Tabdrop -->
    <script type="text/javascript" src="../../Contenido/assets/plugins/iCheck/icheck.min.js"></script>
    <!-- iCheck -->
    <script type="text/javascript" src="../../Contenido/assets/js/enquire.min.js"></script>
    <!-- Enquire for Responsiveness -->
    <script type="text/javascript" src="../../Contenido/assets/plugins/bootbox/bootbox.js"></script>
    <!-- Bootbox -->
    <script type="text/javascript" src="../../Contenido/assets/plugins/simpleWeather/jquery.simpleWeather.min.js"></script>
    <!-- Weather plugin-->
    <script type="text/javascript" src="../../Contenido/assets/plugins/nanoScroller/js/jquery.nanoscroller.min.js"></script>
    <!-- nano scroller -->
    <script type="text/javascript" src="../../Contenido/assets/plugins/jquery-mousewheel/jquery.mousewheel.min.js"></script>
    <!-- Mousewheel support needed for jScrollPane -->
    <script type="text/javascript" src="../../Contenido/assets/js/application.js"></script>
    <script type="text/javascript" src="../../Contenido/assets/demo/demo.js"></script>
    <script type="text/javascript" src="../../Contenido/assets/demo/demo-switcher.js"></script>
</body>
</html>
