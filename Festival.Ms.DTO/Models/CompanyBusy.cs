using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival.Ms.DTO.Models
{
    public class CompanyBusy
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Cant { get; set; }
        public long IdProduct { get; set; }
        public long IdParticipation { get; set; }

    }
}
