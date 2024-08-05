using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer.Ms.DTO.Models
{
    public class Answer
    {
        public long id { get; set; }
        public string Description { get; set; } = string.Empty;
        public long Value { get; set; }
    }
}
