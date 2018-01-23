using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDemo.Library
{
    [Table("Posts")]
    public class Post
    {
        [Key]
        public Guid PostId { get; set; }

        public string Autor { get; set; }

        public string Texto { get; set; }

        public string Titulo { get; set; }

        public string FechaCreacion { get; set; }

        public string FechaModificacion { get; set; }

        public int Modificaciones { get; set; }

        public PostType PostType { get; set; }

        public bool Activo { get; set; }

        public Post()
        {
            Activo = true;
        }

        public void Copiar(Post post)
        {
            this.Texto = post.Texto;
            this.PostType = post.PostType;
            this.Titulo = post.Titulo;
        }
    }
}
