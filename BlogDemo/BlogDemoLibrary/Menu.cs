using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDemo.Library
{
    [Table("Menues")]
    public class Menu
    {
        [Key]
        public Guid MenuID { get; set; }

        public string Titulo { get; set; }

        public virtual List<Link> Links { get; set; }
        
    }
}
