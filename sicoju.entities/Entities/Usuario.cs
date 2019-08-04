using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace sicoju.entities.Entities
{
    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Caso = new HashSet<Caso>();
            UsuarioPerfil = new HashSet<UsuarioPerfil>();
            UsuarioTipoCaso = new HashSet<UsuarioTipoCaso>();
        }

        public int UsuarioID { get; set; }

        public int? TipoUsuarioID { get; set; }

        [StringLength(50)]
        public string Identificacion { get; set; }

        [StringLength(250)]
        public string Nombre { get; set; }

        [StringLength(250)]
        public string PrimerApellido { get; set; }

        [StringLength(250)]
        public string SegundoApellido { get; set; }

        [StringLength(250)]
        public string CorreoElectronico { get; set; }

        [Required]
        [StringLength(250)]
        public string Clave { get; set; }

        public bool Activo { get; set; }

        public bool? Restablecer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Caso> Caso { get; set; }

        public virtual TipoUsuario TipoUsuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsuarioPerfil> UsuarioPerfil { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsuarioTipoCaso> UsuarioTipoCaso { get; set; }
    }
}
