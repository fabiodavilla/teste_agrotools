using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteAgrotools.Entities
{
    [Table("FormField")]
    public class FormField
    {
        [Key]
        public int ID { get; set; }

        public string Question { get; set; }

        public Form Form { get; set; }

        [ForeignKey("Form")]
        public int FormFK { get; set; }
    }
}
