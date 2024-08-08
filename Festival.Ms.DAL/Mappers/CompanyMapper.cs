using Festival.Ms.DAL.EntityConfig;
using Festival.Ms.DAL.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival.Ms.DAL.Mappers
{
    public class CompanyMapper
    {
        public static DTO.Models.Company Map(CompanyEntity? companyEntity)
        {
            return new DTO.Models.Company()
            {
                Id = companyEntity?.Id ?? 0,
                Description = companyEntity?.Description ?? string.Empty,
                CreatedAt = companyEntity?.CreatedAt ?? DateTime.MinValue,
                IdUserAuth = companyEntity?.IdUserAuth ?? 0
            };
        }

        public static IEnumerable<DTO.Models.Company> Map(IEnumerable<CompanyEntity> companyEntities)
        {
            return companyEntities.Select(Map).ToList();
        }
    }
}

