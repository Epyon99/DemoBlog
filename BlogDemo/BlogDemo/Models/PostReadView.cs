using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BlogDemo.Models
{
    public class PostReadView : PostCreateView
    {
        public string Autor { get; set; }

        [DisplayName("Fecha de Actualizacion")]
        public string Actualizacion { get; set; }
    }
}