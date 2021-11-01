using System.Collections.Generic;

namespace TesteAgrotools.DTO
{
    public class FormAnswerDTO
    {
        public string User { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public List<AnswerDTO> Answers { get; set; }
    }
}
