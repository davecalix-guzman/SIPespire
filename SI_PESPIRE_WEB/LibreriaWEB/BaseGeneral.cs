using DevExpress.Web;
using SI_PESPIRE_LogicaNegocio;
using System.Web.UI;

namespace SI_PESPIRE_WEB.LibreriaWEB
{
    public class BaseGeneral
    {
        public class Generales
        {
            public static void LimpiarControles(ControlCollection controls)
            {
                foreach (Control ctr in controls)
                    switch (ctr)
                    {
                        case ASPxSpinEdit _:
                            ((ASPxSpinEdit) ctr).Number = 0;
                            break;
                        case ASPxTextEdit _:
                            ((ASPxTextEdit)ctr).Text = string.Empty;
                            break;
                        case ASPxRadioButton _:
                            ((ASPxRadioButton)ctr).Checked = false;
                            break;
                        case ASPxRadioButtonList _:
                            ((ASPxRadioButtonList)ctr).SelectedIndex = -1;
                            break;
                        case ASPxCheckBoxList _:
                            ((ASPxCheckBoxList)ctr).SelectedIndex = -1;
                            break;
                        case ASPxCheckBox _:
                            ((ASPxCheckBox)ctr).Checked = false;
                            break;
                        case ASPxBinaryImage _:
                            ((ASPxBinaryImage)ctr).Value = null;
                            break;
                        case ASPxLabel _:
                            break;
                        default:
                            if (ctr is ASPxComboBox) ((ASPxComboBox)ctr).SelectedIndex = -1;
                            else if (ctr.HasControls()) LimpiarControles(ctr.Controls);
                            break;
                    }
            }
        }

        public class ComboBoxes
        {
            public static void CargarCboRoles(ASPxComboBox cboRoles)
            {
                cboRoles.Items.Clear();
                cboRoles.DataSource = RolesLN.ObtenerRolesActivos();
                cboRoles.ValueField = @"RolId";
                cboRoles.TextField = @"Nombre";
                cboRoles.DataBind();
            }

            public static void CargarCboModulos(ASPxComboBox cboModulo)
            {
                cboModulo.Items.Clear();
                cboModulo.DataSource = ModulosLN.ObtenerModulos();
                cboModulo.ValueField = @"ModuloId";
                cboModulo.TextField = @"Nombre";
                cboModulo.DataBind();
            }
        }

        public class Enums
        {
            public enum PageState
            {
                Browsing = 1,
                Adding = 2,
                Editing = 3
            }
        }
    }
}