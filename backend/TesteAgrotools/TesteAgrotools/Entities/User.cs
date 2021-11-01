using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteAgrotools.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        public int ID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
