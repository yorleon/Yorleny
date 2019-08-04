using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace sicoju.entities.Entities
{
    [Table("DetalleCaso")]
    public partial class DetalleCaso
    {
        public int DetalleCasoID { get; set; }

        public int? CasoID { get; set; }

        public int? InvolucradoID { get; set; }

        public int? TipoInvolucradoID { get; set; }

        public virtual Caso Caso { get; set; }

        public virtual Involucrado Involucrado { get; set; }

        public virtual TipoInvolucrado TipoInvolucrado { get; set; }
    }
}
