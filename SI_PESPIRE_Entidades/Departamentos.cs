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
    
    public partial class Departamentos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Departamentos()
        {
            this.Municipios = new HashSet<Municipios>();
        }
    
        public string DepartamentoId { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public System.DateTime FechaRegistro { get; set; }
        public Nullable<System.DateTime> FechaModificado { get; set; }
        public Nullable<int> FKUsuarioId { get; set; }
        public string FKPaisId { get; set; }
    
        public virtual Paises Paises { get; set; }
        public virtual Usuarios Usuarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Municipios> Municipios { get; set; }
    }
}
