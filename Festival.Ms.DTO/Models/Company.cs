using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival.Ms.DTO.Models
{
    public class Company
    {

        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public long IdUserAuth { get; set; }

    }
}
