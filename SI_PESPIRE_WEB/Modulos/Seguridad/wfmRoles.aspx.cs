using DevExpress.Web;
using SI_PESPIRE_Entidades;
using SI_PESPIRE_LogicaNegocio;
using SI_PESPIRE_WEB.LibreriaWEB;
using System;
using System.Linq;
using System.Web.UI;

namespace SI_PESPIRE_WEB.Modulos.Seguridad
{
    public partial class wfmRoles : BasePage
    {
        private static int _rolSeleccionadoId;
        private static Roles _rolSeleccionado = new Roles();
        private static BaseGeneral.Enums.PageState PageState { get; set; }

        private static int RolSeleccionadoId
        {
            get => _rolSeleccionadoId;
            set
            {
                if (_rolSeleccionadoId == 0) _rolSeleccionadoId = value;
            }
        }

        private static Roles RolSeleccionado
        {
            get => _rolSeleccionado;
            set
            {
                if (_rolSeleccionado != null && _rolSeleccionado != value) _rolSeleccionado = value;
            }
        }

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!Page.IsPostBack)
            {
                SiteMaster.SetTituloPagina("Roles y perfiles de usuario");
                PageState = BaseGeneral.Enums.PageState.Browsing;
                ChangePageState();
                CargarRoles();
                MostrarNodos();
            }
        }

        private void ChangePageState()
        {
            switch (PageState)
            {
                case BaseGeneral.Enums.PageState.Browsing:
                    btnNuevo.Enabled = true;
                    btnGuardar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnActualizar.Enabled = false;
                    btnCancelar.Enabled = false;
                    txtNombres.Enabled = false;
                    txtDescripcion.Enabled = false;
                    chkActivo.Enabled = false;
                    tvAcciones.Enabled = false;
                    txtNombres.Focus();
                    break;

                case BaseGeneral.Enums.PageState.Adding:
                    btnNuevo.Enabled = false;
                    btnGuardar.Enabled = true;
                    btnEliminar.Enabled = false;
                    btnActualizar.Enabled = false;
                    btnCancelar.Enabled = true;
                    txtNombres.Enabled = true;
                    txtDescripcion.Enabled = true;
                    tvAcciones.Enabled = true;
                    chkActivo.Enabled = true;
                    txtNombres.Focus();
                    break;

                case BaseGeneral.Enums.PageState.Editing:
                    btnNuevo.Enabled = true;
                    btnGuardar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnActualizar.Enabled = true;
                    btnCancelar.Enabled = true;
                    txtNombres.Enabled = false;
                    txtDescripcion.Enabled = true;
                    chkActivo.Enabled = true;
                    tvAcciones.Enabled = true;
                    break;
            }
        }

        private void MostrarNodos()
        {
            try
            {
                var listadoModulos = ModulosLN.ObtenerModulos(true, 0);
                tvAcciones.Nodes.Clear();
                foreach (var modulo in listadoModulos)
                {
                    var nodo = new TreeViewNode(modulo.Nombre.Trim(), modulo.ModuloId.ToString());
                    nodo.TextStyle.Font.Bold = true;
                    var listadoAcciones = AccionesLN.ObtenerAccionesPorModuloId(modulo.ModuloId);
                    if (listadoAcciones.Any())
                        foreach (var accion in listadoAcciones)
                        {
                            var hijos = AccionesLN.ObtenerAccionesPorPadre(modulo.ModuloId, accion.AccionId);
                            var subNodo = new TreeViewNode(accion.Nombre.Trim(), accion.AccionId.ToString());
                            if (hijos != null)
                                foreach (var hijo in hijos)
                                {
                                    var subNodoHijo = new TreeViewNode(hijo.Nombre.Trim(), hijo.AccionId.ToString());
                                    subNodo.Nodes.Add(subNodoHijo);
                                }

                            nodo.Nodes.Add(subNodo);
                        }

                    tvAcciones.Nodes.Add(nodo);
                }

                tvAcciones.DataBind();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void CargarRoles()
        {
            BaseGeneral.ComboBoxes.CargarCboRoles(cboRoles);
        }

        protected void cboRoles_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                PageState = BaseGeneral.Enums.PageState.Editing;
                ChangePageState();
                foreach (TreeViewNode nodo in tvAcciones.Nodes) nodo.Checked = false;

                var rolSeleccionado = Convert.ToInt32(cboRoles.Value);
                var rolModuloAcciones = RolModuloAccionesLN.ObtenerAccionesActivas(rolSeleccionado);
                MostrarInformaciónRol(rolSeleccionado);
                if (rolModuloAcciones.Any())
                {
                    foreach (TreeViewNode nodo in tvAcciones.Nodes)
                    {
                        var objetoRolModuloAcciones =
                            rolModuloAcciones.Where(x => x.FKModuloId == Convert.ToInt32(nodo.Name));
                        if (objetoRolModuloAcciones.Any())
                            foreach (TreeViewNode subNodo in nodo.Nodes)
                            {
                                var objetoAcciones =
                                    objetoRolModuloAcciones.Where(x => x.FKAccionId == Convert.ToInt32(subNodo.Name));
                                if (objetoAcciones.Any())
                                {
                                    var nodoTieneHijos = false;
                                    foreach (TreeViewNode accionNodo in subNodo.Nodes)
                                        foreach (var accion in objetoRolModuloAcciones.ToList())
                                            if (accionNodo.Name == accion.FKAccionId.ToString())
                                            {
                                                accionNodo.Checked = true;
                                                nodoTieneHijos = true;
                                            }

                                    if (!nodoTieneHijos)
                                        foreach (var objeto in objetoRolModuloAcciones.ToList())
                                            if (subNodo.Name == objeto.FKAccionId.ToString())
                                                subNodo.Checked = true;
                                }
                            }
                    }

                    tvAcciones.DataBind();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void MostrarInformaciónRol(int rolSeleccionado)
        {
            try
            {
                var rol = RolesLN.ObtenerRolPorId(rolSeleccionado);
                if (rol == null) return;
                RolSeleccionado = rol;
                txtNombres.Text = rol.Nombre;
                txtDescripcion.Text = rol.Descripcion;
                chkActivo.Value = rol.Estado;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        protected void btnGuardar_OnClick(object sender, EventArgs e)
        {
            RolSeleccionadoId = Convert.ToInt32(cboRoles.Value);
            switch (RolSeleccionadoId)
            {
                case 0:
                    GuardarRol();
                    break;
                default:
                    ActualizarRol();
                    break;
            }
        }

        private void ActualizarRol()
        {
            try
            {
                var rolActualizar = RolSeleccionado;
                if (rolActualizar != null)
                {
                    rolActualizar.Descripcion = txtDescripcion.Text.ToUpper().Trim();
                    rolActualizar.Estado = Convert.ToBoolean(chkActivo.Value);

                    switch (RolesLN.ActualizarRol(rolActualizar))
                    {
                        case 1:
                            SiteMaster.MostrarMensaje(SiteMaster.TipoMensaje.Exito,
                                $"Enhorabuena, el rol {rolActualizar.Nombre} ha sido actualizado exitosamente.",
                                "Gestión de Roles y Perfiles");
                            PageState = BaseGeneral.Enums.PageState.Browsing;
                            ChangePageState();
                            CargarRoles();
                            break;
                        case -1:
                            SiteMaster.MostrarMensaje(SiteMaster.TipoMensaje.Excepcion,
                                $"Hubo un error al tratar de actualizar el rol {rolActualizar.Nombre}.",
                                "Gestión de Roles y Perfiles");
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

        private void GuardarRol()
        {
            try
            {
                var nombreRol = txtNombres.Text.ToUpper().Trim();
                var rol = RolesLN.ObtenerRolPorNombre(nombreRol);
                if (rol == null)
                {
                    var descripcionRol = txtDescripcion.Text.ToUpper().Trim();
                    var estadoRol = Convert.ToBoolean(chkActivo.Value);
                    var fechaRegistro = DateTime.Now;
                    var usuarioRegistro = Convert.ToInt32(Session["vsUsuarioId"]);

                    var nuevoRol = new Roles
                    {
                        Nombre = nombreRol,
                        Descripcion = descripcionRol,
                        Estado = estadoRol,
                        FechaRegistro = fechaRegistro,
                        FKUsuarioId = usuarioRegistro
                    };

                    var seInsertoRol = RolesLN.RegistrarNuevoRol(nuevoRol);
                    switch (seInsertoRol)
                    {
                        case 0:
                            SiteMaster.MostrarMensaje(SiteMaster.TipoMensaje.Informacion,
                                $"El código de rol {nuevoRol.RolId} ya existe.");
                            break;
                        case 1:
                            SiteMaster.MostrarMensaje(SiteMaster.TipoMensaje.Exito,
                                $"Enhorabuena, el rol {nuevoRol.Nombre} fue creado exitosamente.");
                            PageState = BaseGeneral.Enums.PageState.Browsing;
                            ChangePageState();
                            CargarRoles();
                            LimpiarControles(Controls);
                            break;
                        case -1:
                            SiteMaster.MostrarMensaje(SiteMaster.TipoMensaje.Excepcion,
                                $"Se produjo un error al intentar insertar el rol {nuevoRol.Nombre}.");
                            break;
                    }
                }
                else
                {
                    SiteMaster.MostrarMensaje(SiteMaster.TipoMensaje.Atencion,
                        $"Ya existe un rol almacenado con el nombre {rol.Nombre}.", "Gestión de Roles y Perfiles");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        protected void btnNuevo_OnClick(object sender, EventArgs e)
        {
            LimpiarControles(Controls);
            RolSeleccionadoId = 0;
            PageState = BaseGeneral.Enums.PageState.Adding;
            ChangePageState();
        }

        private void LimpiarControles(ControlCollection controls)
        {
            BaseGeneral.Generales.LimpiarControles(controls);
            foreach (TreeViewNode nodo in tvAcciones.Nodes) nodo.Checked = false;
        }

        protected void btnCancelar_OnClick(object sender, EventArgs e)
        {
            CargarRoles();
            LimpiarControles(Controls);
            PageState = BaseGeneral.Enums.PageState.Browsing;
            ChangePageState();
        }


        protected void btnEliminar_OnClick(object sender, EventArgs e)
        {
            if (RolSeleccionado == null) return;
            if (SePuedeEliminarRol())
            {
                SiteMaster.MostrarMensaje(SiteMaster.TipoMensaje.Interrogacion,
                    @"¿Realmente desea eliminar el resgistro?", "Gestión de Roles y Perfiles");
                Session["vsRegistroIdEliminar"] = RolSeleccionado.RolId;
                Session["vsRegistroEliminar"] = RolSeleccionado;
            }
            else
            {
                SiteMaster.MostrarMensaje(SiteMaster.TipoMensaje.Informacion,
                    $"El rol {RolSeleccionado.Nombre} no puede eliminarse porque existen registros asociados a él.",
                    "Gestión de Roles y Perfiles");
            }
        }

        private static bool SePuedeEliminarRol()
        {
            try
            {
                return !RolSeleccionado.Usuarios1.Any() && !RolSeleccionado.RolModuloAcciones.Any();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        protected void btnActualizar_OnClick(object sender, EventArgs e)
        {
            if (verificarSeleccionados())
            {
                if (RolModuloAccionesLN.Eliminar(Convert.ToInt32(cboRoles.Value)))
                    ActualizarAccionesParaRol();
                else
                    ActualizarAccionesParaRol();
            }
            tvAcciones.CollapseAll();
            var rol = RolesLN.ObtenerRolPorId(Convert.ToInt32(cboRoles.Value));
            SiteMaster.MostrarMensaje(SiteMaster.TipoMensaje.Exito, $"Enhorabuena las acciones en el rol {rol.Nombre} fueron actualizadas exitosamente.", "Gestión de Roles y Perfiles");
        }

        private bool verificarSeleccionados()
        {
            bool estado = false; // modulos
            foreach (TreeViewNode nodo in tvAcciones.Nodes)
            {
                if (nodo.CheckState == CheckState.Checked | nodo.CheckState == CheckState.Indeterminate)
                    return true;
            }
            return estado;
        }

        private void ActualizarAccionesParaRol()
        {
            foreach (TreeViewNode nodo in tvAcciones.Nodes) // modulos
            {
                foreach (TreeViewNode subNodo in nodo.Nodes) // funciones
                {
                    if (subNodo.Nodes.Count > 0)
                    {
                        //insertar la funcion
                        if (subNodo.CheckState == CheckState.Indeterminate | subNodo.CheckState == CheckState.Checked)
                        {
                            RolModuloAccionesLN.Insertar(new RolModuloAcciones
                            {
                                FKRolId = Convert.ToInt32(cboRoles.Value),
                                FKModuloId = Convert.ToInt32(nodo.Name),
                                FKAccionId = Convert.ToInt32(subNodo.Name)
                            });
                        }

                        foreach (TreeViewNode accionNodo in subNodo.Nodes) // acciones
                        {
                            //insertar las acciones
                            if (accionNodo.Checked)
                                RolModuloAccionesLN.Insertar(new RolModuloAcciones
                                {
                                    FKRolId = Convert.ToInt32(cboRoles.Value),
                                    FKModuloId = Convert.ToInt32(nodo.Name),
                                    FKAccionId = Convert.ToInt32(accionNodo.Name)
                                });
                        }
                    }
                    else
                    {
                        if (subNodo.Checked)
                            RolModuloAccionesLN.Insertar(new RolModuloAcciones
                            {
                                FKRolId = Convert.ToInt32(cboRoles.Value),
                                FKModuloId = Convert.ToInt32(nodo.Name),
                                FKAccionId = Convert.ToInt32(subNodo.Name)
                            });
                    }
                }
            }
        }
    }
}