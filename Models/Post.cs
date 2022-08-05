using System;
using System.Collections.Generic;

#nullable disable

namespace RedeSocial.Models
{
    public partial class Post
    {
        public Post()
        {
            Comentarios = new HashSet<Comentario>();
            Curtida = new HashSet<Curtidum>();
        }

        public Guid Id { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }
        public Guid IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
        public virtual ICollection<Curtidum> Curtida { get; set; }
    }
}
