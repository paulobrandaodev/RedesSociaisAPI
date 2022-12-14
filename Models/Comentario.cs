using System;
using System.Collections.Generic;

#nullable disable

namespace RedeSocial.Models
{
    public partial class Comentario
    {
        public Guid Id { get; set; }
        public string Texto { get; set; }
        public Guid IdPost { get; set; }
        public Guid IdUsuario { get; set; }

        public virtual Post IdPostNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
