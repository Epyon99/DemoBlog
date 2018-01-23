using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogDemo.Library
{
    [Table("Links")]
    public class Link
    {
        [Key]
        public Guid LinkId { get; set; }

        public string Text { get; set; }

        public string Hypervinculo { get; set; }

        public Guid MenuId { get; set; }

        [ForeignKey("MenuId")]
        public virtual Menu Menu { get; set; }
    }
}