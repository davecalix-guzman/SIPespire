using DevExpress.Web;
using SI_PESPIRE_Entidades;
using SI_PESPIRE_LogicaNegocio;
using SI_PESPIRE_WEB.LibreriaWEB;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.UI;

namespace SI_PESPIRE_WEB.Modulos.Seguridad
{
    public partial class wfmAcciones : BasePage
    {
        private static int _accionSeleccionadaId;
        private static List<AccionesGeneradas> _listadoAccionesRecuperadas = new List<AccionesGeneradas>();
        private static Acciones _accionSeleccionada = new Acciones();
        private static BaseGeneral.Enums.PageState PageState { get; set; }

        private static List<AccionesGeneradas> ListadoAccionesRecuperadas
        {
            get => _listadoAccionesRecuperadas;
            set
            {
                if (_listadoAccionesRecuperadas == null || _listadoAccionesRecuperadas == value) return;
                _listadoAccionesRecuperadas = value;
            }
        }

        private static Acciones AccionSeleccionada
        {
            get => _accionSeleccionada;
            set
            {
                if (_accionSeleccionada == null || _accionSeleccionada == value) return;
                _accionSeleccionada = value;
            }
        }

        private static int AccionSeleccionadaId
        {
            get => _accionSeleccionadaId;
            set
            {
                if (_accionSeleccionadaId != 0) return;
                _accionSeleccionadaId = value;
            }
        }


        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!Page.IsPostBack)
            {
                SiteMaster.SetTituloPagina("Acciones asociadas a un rol o perfil");
                RecargarTodo();
                CargarModulos();
            }
            else
            {
                if (!ListadoAccionesRecuperadas.Any()) return;
                dgvAcciones.DataSource = ListadoAccionesRecuperadas;
                dgvAcciones.DataBind();
            }
        }

        private void CargarModulos()
        {
            BaseGeneral.ComboBoxes.CargarCboModulos(cboModulo);
        }

        private void CargarAcciones()
        {
            try
            {
                var listadoAcciones = AccionesLN.ObtenerAcciones();
                if (listadoAcciones.Any())
                {
                    var listadoAccionesGeneradas = new List<AccionesGeneradas>();
                    foreach (var accion in listadoAcciones)
                    {
                        var accionesGeneradas = new AccionesGeneradas
                        {
                            Nombre = accion.Nombre,
                            AccionId = accion.AccionId,
                            Padre = accion.Padre == 1 ? "SI" : "NO",
                            Menu = accion.Menu ? "SI" : "NO",
                            Estado = accion.Estado ? "SI" : "NO",
                            ClaseCss = accion.ClaseCss,
                            Icono = accion.Icono,
                            FueraLinea = accion.Offline ? "SI" : "NO",
                            Enlace = accion.Enlace,
                            Modulo = accion.Modulos.Nombre,
                            NombreFormulario = accion.NombreFormulario
                        };
                        listadoAccionesGeneradas.Add(accionesGeneradas);
                    }

                    ListadoAccionesRecuperadas = listadoAccionesGeneradas;
                    dgvAcciones.DataSource = ListadoAccionesRecuperadas;
                    dgvAcciones.DataBind();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void ChangePageState()
        {
            switch (PageState)
            {
                case BaseGeneral.Enums.PageState.Browsing:
                    btnNuevo.Enabled = true;
                    btnGuardar.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnEliminar.Enabled = false;
                    txtNombreFormulario.Enabled = false;
                    txtNombreAccion.Enabled = false;
                    chkPadre.Enabled = false;
                    chkEstado.Enabled = false;
                    chkOffline.Enabled = false;
                    chkMenu.Enabled = false;
                    cboModulo.Enabled = false;
                    txtIcono.Enabled = false;
                    txtClaseCss.Enabled = false;
                    txtEnlace.Enabled = false;
                    break;

                case BaseGeneral.Enums.PageState.Adding:
                    btnNuevo.Enabled = false;
                    btnGuardar.Enabled = true;
                    btnCancelar.Enabled = true;
                    btnEliminar.Enabled = false;
                    txtNombreFormulario.Enabled = true;
                    txtNombreAccion.Enabled = true;
                    chkPadre.Enabled = true;
                    chkEstado.Enabled = true;
                    chkOffline.Enabled = true;
                    chkMenu.Enabled = true;
                    cboModulo.Enabled = true;
                    txtIcono.Enabled = true;
                    txtClaseCss.Enabled = true;
                    cboModulo.Focus();
                    break;

                case BaseGeneral.Enums.PageState.Editing:
                    btnNuevo.Enabled = true;
                    btnGuardar.Enabled = true;
                    btnCancelar.Enabled = true;
                    btnEliminar.Enabled = true;
                    txtNombreFormulario.Enabled = true;
                    txtNombreAccion.Enabled = true;
                    chkPadre.Enabled = true;
                    chkEstado.Enabled = true;
                    chkOffline.Enabled = true;
                    chkMenu.Enabled = true;
                    cboModulo.Enabled = true;
                    txtIcono.Enabled = true;
                    txtClaseCss.Enabled = true;
                    break;
            }
        }

        protected void dgvAcciones_OnCustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            var asPxGridView = (ASPxGridView)sender;
            if (asPxGridView == null) return;
            var accionId = Convert.ToInt32(asPxGridView.GetRowValues(e.VisibleIndex, "AccionId"));
            AccionSeleccionadaId = accionId;
            MostrarInformacionAccion(accionId);
        }

        private void MostrarInformacionAccion(int accionId)
        {
            var accionSeleccionada = ListadoAccionesRecuperadas.FirstOrDefault(x => x.AccionId == accionId);
            if (accionSeleccionada != null)
            {
                txtNombreAccion.Text = accionSeleccionada.Nombre;
                chkPadre.Value = accionSeleccionada.Padre == "SI" ? chkPadre.Checked = true : chkPadre.Checked = false;
                chkEstado.Value = accionSeleccionada.Estado == "SI"
                    ? chkEstado.Checked = true
                    : chkEstado.Checked = false;
                chkOffline.Value = accionSeleccionada.FueraLinea == "SI"
                    ? chkOffline.Checked = true
                    : chkOffline.Checked = false;
                chkMenu.Value = accionSeleccionada.Menu == "SI" ? chkMenu.Checked = true : chkMenu.Checked = false;
                cboModulo.Text = accionSeleccionada.Modulo;
                txtIcono.Text = accionSeleccionada.Icono ?? @"SIN ÍCONO";
                txtClaseCss.Text = accionSeleccionada.ClaseCss ?? @"SIN CLASE CSS";
                txtEnlace.Text = accionSeleccionada.Enlace;
                txtNombreFormulario.Text = accionSeleccionada.NombreFormulario;
                PageState = BaseGeneral.Enums.PageState.Editing;
                ChangePageState();
            }
        }

        protected void btnCancelar_OnClick(object sender, EventArgs e)
        {
            RecargarTodo();
        }

        private void RecargarTodo()
        {
            BaseGeneral.Generales.LimpiarControles(Controls);
            PageState = BaseGeneral.Enums.PageState.Browsing;
            ChangePageState();
            CargarAcciones();
        }

        protected void btnNuevo_OnClick(object sender, EventArgs e)
        {
            PageState = BaseGeneral.Enums.PageState.Adding;
            ChangePageState();
            BaseGeneral.Generales.LimpiarControles(Controls);
        }

        private void ObtenerEnlaceFormulario()
        {
            var parametroModulo = CapitalizarPrimeraLetra(cboModulo.Text.Trim().ToLower());
            var parametroAccion = txtNombreFormulario.Text;
            string enlace;

            switch (parametroModulo)
            {
                case "GESTIÓN DE INVENTARIOS":
                    enlace = $"GestionInventarios/{parametroAccion}";
                    break;
                case "GESTIÓN DE VENTAS":
                    enlace = $"GestionVentas/{parametroAccion}";
                    break;
                default:
                    enlace = $"{parametroModulo}/{parametroAccion}";
                    break;
            }

            txtEnlace.Text = enlace;
        }

        private static string CapitalizarPrimeraLetra(string nombreModulo)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nombreModulo);
        }

        protected void txtNombreFormulario_OnTextChanged(object sender, EventArgs e)
        {
            var nombreFormulario = txtNombreFormulario.Text.Trim();
            if (!string.IsNullOrWhiteSpace(nombreFormulario)) ObtenerEnlaceFormulario();
        }

        protected void btnGuardar_OnClick(object sender, EventArgs e)
        {
            switch (AccionSeleccionadaId)
            {
                case 0:
                    GuardarAccion();
                    break;
                default:
                    ModificarAccion(AccionSeleccionadaId);
                    break;
            }
        }

        private void ModificarAccion(int accionSeleccionadaId)
        {
            try
            {
                var accionActualizar = AccionesLN.ObtenerAccionPorId(accionSeleccionadaId);
                if (accionActualizar != null)
                {
                    accionActualizar.Nombre = txtNombreAccion.Text.Trim();
                    accionActualizar.Padre = Convert.ToInt32(chkPadre.Value);
                    accionActualizar.Menu = Convert.ToBoolean(chkMenu.Value);
                    accionActualizar.Icono = string.IsNullOrWhiteSpace(txtIcono.Text) || txtIcono.Text == @"SIN ÍCONO".Trim() ? null : txtIcono.Text.Trim();
                    accionActualizar.ClaseCss = string.IsNullOrWhiteSpace(txtClaseCss.Text) || txtClaseCss.Text == @"SIN CLASE CSS".Trim() ? null : txtClaseCss.Text.Trim();
                    accionActualizar.NombreFormulario = txtNombreFormulario.Text.Trim();
                    accionActualizar.Enlace = txtEnlace.Text.Trim();
                    accionActualizar.Estado = Convert.ToBoolean(chkEstado.Value);
                    accionActualizar.Offline = Convert.ToBoolean(chkOffline.Value);
                    accionActualizar.FKModuloId = Convert.ToInt32(cboModulo.Value);
                }

                switch (AccionesLN.ActualizarAccion(accionActualizar))
                {
                    case 1:
                        SiteMaster.MostrarMensaje(SiteMaster.TipoMensaje.Exito,
                            $"Enhorabuena, la acción {accionActualizar?.Nombre} ha sido actualizada exitosamente.",
                            "Gestión de Roles y Perfiles");
                        RecargarTodo();
                        break;
                    case -1:
                        SiteMaster.MostrarMensaje(SiteMaster.TipoMensaje.Excepcion,
                            $"Hubo un error al tratar de actualizar la acción {accionActualizar?.Nombre}.",
                            "Gestión de Roles y Perfiles");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void GuardarAccion()
        {
            try
            {
                var nombreAccion = txtNombreAccion.Text.Trim();
                var padre = Convert.ToInt32(chkPadre.Value);
                var accion = AccionesLN.ObtenerAccionPorNombrePorPadre(nombreAccion, padre);

                if (accion == null)
                {
                    var nuevaAccion = new Acciones
                    {
                        Nombre = txtNombreAccion.Text.Trim(),
                        FKModuloId = Convert.ToInt32(cboModulo.Value),
                        Icono = string.IsNullOrWhiteSpace(txtIcono.Text) ? null : txtIcono.Text.Trim(),
                        ClaseCss = string.IsNullOrWhiteSpace(txtClaseCss.Text) ? null : txtClaseCss.Text.Trim(),
                        Estado = Convert.ToBoolean(chkEstado.Value),
                        Enlace = txtEnlace.Text.Trim(),
                        Menu = Convert.ToBoolean(chkMenu.Value),
                        NombreFormulario = txtNombreFormulario.Text.Trim(),
                        Offline = Convert.ToBoolean(chkOffline.Value),
                        Padre = Convert.ToInt32(chkPadre.Value)
                    };

                    var seInsertoAccion = AccionesLN.RegistrarNuevaAccion(nuevaAccion);
                    switch (seInsertoAccion)
                    {
                        case 0:
                            SiteMaster.MostrarMensaje(SiteMaster.TipoMensaje.Informacion,
                                $"El código de acción {nuevaAccion.AccionId} ya existe.");
                            break;
                        case 1:
                            SiteMaster.MostrarMensaje(SiteMaster.TipoMensaje.Exito,
                                $"Enhorabuena, la acción {nuevaAccion.Nombre} fue creada exitosamente.");
                            RecargarTodo();
                            break;
                        case -1:
                            SiteMaster.MostrarMensaje(SiteMaster.TipoMensaje.Excepcion,
                                $"Se produjo un error al intentar insertar la acción {nuevaAccion.Nombre}.");
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}