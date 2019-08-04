namespace sicoju.entities.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Formulario")]
    public partial class Formulario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Formulario()
        {
            FormularioPerfil = new HashSet<FormularioPerfil>();
        }

        public int FormularioID { get; set; }

        [StringLength(250)]
        public string Descripcion { get; set; }

        [StringLength(250)]
        public string Ruta { get; set; }

        public bool Activo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FormularioPerfil> FormularioPerfil { get; set; }
    }
}
