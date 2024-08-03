using System;
using System.Text.Json;
using Festival.Ms.DAL.Interfaces.Entities;

namespace Festival.Ms.DAL.Mappers
{
    public static class FestivalMapper
    {
        public static DTO.Models.Festival Map(FestivalEntity? festivalEntity)
        {
            return new DTO.Models.Festival()
            {
                id = festivalEntity?.Id ?? 0,
                description = festivalEntity?.Description ?? string.Empty,
                question = festivalEntity.Question
            };
        }
    }
}

