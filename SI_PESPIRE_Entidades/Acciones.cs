//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SI_PESPIRE_Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class Acciones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Acciones()
        {
            this.RolModuloAcciones = new HashSet<RolModuloAcciones>();
        }
    
        public int AccionId { get; set; }
        public string Nombre { get; set; }
        public int Padre { get; set; }
        public bool Menu { get; set; }
        public string Icono { get; set; }
        public string ClaseCss { get; set; }
        public string NombreFormulario { get; set; }
        public string Enlace { get; set; }
        public bool Estado { get; set; }
        public bool Offline { get; set; }
        public int FKModuloId { get; set; }
    
        public virtual Modulos Modulos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RolModuloAcciones> RolModuloAcciones { get; set; }
    }
}
