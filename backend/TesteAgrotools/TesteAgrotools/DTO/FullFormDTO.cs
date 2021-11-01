using System.Collections.Generic;
using TesteAgrotools.Entities;

namespace TesteAgrotools.DTO
{
    public class FullFormDTO : Form
    {
        public List<FormField> fields { get; set; }
    }
}
