using Festival.Ms.DAL.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival.Ms.DAL.Mappers
{
    public class CompanyBusyMapper
    {
        public static DTO.Models.CompanyBusy Map(CompanyBuysEntity? companyBuysEntity)
        {
            return new DTO.Models.CompanyBusy()
            {
                Id = companyBuysEntity?.Id ?? 0,
                CreatedAt = companyBuysEntity?.CreatedAt ?? DateTime.MinValue,
                Cant = companyBuysEntity?.Cant ?? 0,
                IdProduct = companyBuysEntity?.IdProduct ?? 0,
                IdParticipation = companyBuysEntity?.IdParticipation ?? 0,
              
             
               
            };
        }

    }
}
