using System;
using System.Collections.Generic;

#nullable disable

namespace RedeSocial.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Comentarios = new HashSet<Comentario>();
            Curtida = new HashSet<Curtidum>();
            Posts = new HashSet<Post>();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Foto { get; set; }
        public Guid IdTipoUsuario { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
        public virtual ICollection<Curtidum> Curtida { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
