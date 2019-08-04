using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace sicoju.entities.Entities
{
    [Table("Caso")]
    public partial class Caso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Caso()
        {
            DetalleCaso = new HashSet<DetalleCaso>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CasoID { get; set; }

        public int? JuezID { get; set; }

        public DateTime? FechaIngreso { get; set; }

        public DateTime? FechaCierre { get; set; }

        [StringLength(1000)]
        public string Descripcion { get; set; }

        [StringLength(1000)]
        public string Sentencia { get; set; }

        public bool? Activo { get; set; }

        public virtual Usuario Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleCaso> DetalleCaso { get; set; }
    }
}
