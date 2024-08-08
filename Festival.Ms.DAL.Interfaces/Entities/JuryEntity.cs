using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Festival.Ms.DAL.Interfaces.Entities
{
    public class JuryEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public long IdUserAuth { get; set; }

        public JuryEntity()
        {
            Description = string.Empty;
        }

    }
}
