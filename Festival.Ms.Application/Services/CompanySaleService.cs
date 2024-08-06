using Festival.Ms.Application.Interfaces.Services;
using Festival.Ms.DAL.Interfaces.Repositories;
using Festival.Ms.DAL.Mappers;
using Festival.Ms.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival.Ms.Application.Services
{
    public class CompanySaleService : ICompanySaleService
    {
        private readonly ICompanySaleRepository _companySaleRepository;

        public CompanySaleService(ICompanySaleRepository companySaleRepository)
        {
            _companySaleRepository = companySaleRepository;
        }


        public async Task<DTO.Models.CompanySale> GetCompanySale(long id)
        {
            return CompanySaleMapper.Map(await _companySaleRepository.GetCompanySale(id));
        }


    }


}
