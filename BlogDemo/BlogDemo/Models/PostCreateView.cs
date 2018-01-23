using BlogDemo.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogDemo.Models
{
    public class PostCreateView
    {
        public Guid Id { get; set; }

        [DisplayName("Articulo")]
        public string Texto { get; set; }

        [DisplayName("Titulo")]
        [StringLength(50)]
        public string Titulo { get; set; }

        [DisplayName("Tipo de publicacion")]
        [Required]
        public PostType Tipo { get; set; }
    }
}