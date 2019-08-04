using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace sicoju.entities.Entities
{
    [Table("UsuarioTipoCaso")]
    public partial class UsuarioTipoCaso
    {
        public int UsuarioTipoCasoID { get; set; }

        public int? UsuarioID { get; set; }

        public int? TipoCasoID { get; set; }

        public virtual TipoCaso TipoCaso { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
