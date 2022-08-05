using System;
using System.Collections.Generic;

#nullable disable

namespace RedeSocial.Models
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public Guid Id { get; set; }
        public string Cargo { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
