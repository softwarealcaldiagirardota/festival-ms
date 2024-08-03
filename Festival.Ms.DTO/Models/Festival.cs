using System;
using System.Text.Json;

namespace Festival.Ms.DTO.Models
{
    public class Festival
    {
        public long id { get; set; }
        public string description { get; set; } = string.Empty;
        public JsonElement question { get; set; }
    }
}

