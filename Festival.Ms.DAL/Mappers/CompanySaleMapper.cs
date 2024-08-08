using Festival.Ms.DAL.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival.Ms.DAL.Mappers
{
    public class CompanySaleMapper
    {
        public static DTO.Models.CompanySale Map(CompanySalesEntity? companySalesEntity)
        {
            return new DTO.Models.CompanySale()
            {
                Id = companySalesEntity?.Id ?? 0,
                IdParticipation = companySalesEntity?.IdParticipation ?? 0,
                CreatedAt = companySalesEntity?.CreatedAt ?? DateTime.MinValue,
                Cant = companySalesEntity?.Cant ?? 0,
                IdProduct = companySalesEntity?.IdProduct ?? 0,
            };
        }
    }
}
