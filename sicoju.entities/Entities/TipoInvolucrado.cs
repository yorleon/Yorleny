using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace sicoju.entities.Entities
{
    [Table("TipoInvolucrado")]
    public partial class TipoInvolucrado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoInvolucrado()
        {
            DetalleCaso = new HashSet<DetalleCaso>();
        }

        public int TipoInvolucradoID { get; set; }

        [StringLength(250)]
        public string Descripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleCaso> DetalleCaso { get; set; }
    }
}
