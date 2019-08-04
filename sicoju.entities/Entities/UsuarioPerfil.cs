using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace sicoju.entities.Entities
{
    [Table("UsuarioPerfil")]
    public partial class UsuarioPerfil
    {
        public int UsuarioPerfilID { get; set; }

        public int? UsuarioID { get; set; }

        public int? PerfilID { get; set; }

        public virtual Perfil Perfil { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
