﻿using System;
using System.Text.Json;

namespace Festival.Ms.DAL.Interfaces.Entities
{
    public class FestivalEntity
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public JsonElement Question { get; set; }

        public FestivalEntity()
        {
            Description = string.Empty;
        }
    }
}

