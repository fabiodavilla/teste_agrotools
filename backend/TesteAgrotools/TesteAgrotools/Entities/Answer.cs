using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteAgrotools.Entities
{
    [Table("Answer")]
    public class Answer
    {
        [Key]
        public int ID { get; set; }

        public string UserAnswer { get; set; }

        public string latitude { get; set; }

        public string longitude { get; set; }

        public User User { get; set; }
        public FormField FormField { get; set; }

        [ForeignKey("User")]
        public int UserFK { get; set; }

        [ForeignKey("FormField")]
        public int FormFieldFK { get; set; }
    }
}
