using Festival.Ms.Application.Interfaces.Services;
using Festival.Ms.DAL.Interfaces.Repositories;
using Festival.Ms.DAL.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival.Ms.Application.Services
{
    public class CompanyBusyService : ICompanyBusyService

    {
        private readonly ICompanyBusyRepository _companyBusyRepository;

        public CompanyBusyService(ICompanyBusyRepository companyBusyRepository)
        {
            _companyBusyRepository = companyBusyRepository;
        }


        public async Task<DTO.Models.CompanyBusy> GetCompanyBusy(long id)
        {
            return CompanyBusyMapper.Map(await _companyBusyRepository.GetCompanyBusy(id));
        }


    }
}
