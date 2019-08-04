using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace sicoju.entities.Entities
{
    [Table("Involucrado")]
    public partial class Involucrado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Involucrado()
        {
            DetalleCaso = new HashSet<DetalleCaso>();
        }

        public int InvolucradoID { get; set; }

        [StringLength(50)]
        public string Identificacion { get; set; }

        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(100)]
        public string PrimerApellido { get; set; }

        [StringLength(100)]
        public string SegundoApellido { get; set; }

        [StringLength(250)]
        public string CorreoElectronico { get; set; }

        [StringLength(100)]
        public string Telefono { get; set; }

        public bool Activo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleCaso> DetalleCaso { get; set; }
    }
}
