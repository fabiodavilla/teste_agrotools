using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteAgrotools.Entities
{
    [Table("Form")]
    public class Form
    {
        [Key]
        public int ID { get; set; }

        public string Title { get; set; }

        public string User { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
