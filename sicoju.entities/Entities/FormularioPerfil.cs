using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace sicoju.entities.Entities
{
    [Table("FormularioPerfil")]
    public partial class FormularioPerfil
    {
        public int FormularioPerfilID { get; set; }

        public int? FormularioID { get; set; }

        public int? PerfilID { get; set; }

        public virtual Formulario Formulario { get; set; }

        public virtual Perfil Perfil { get; set; }
    }
}
