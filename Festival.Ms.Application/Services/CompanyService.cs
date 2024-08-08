using Festival.Ms.Application.Interfaces.Services;
using Festival.Ms.DAL.Interfaces.Entities;
using Festival.Ms.DAL.Interfaces.Repositories;
using Festival.Ms.DAL.Mappers;
using Festival.Ms.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival.Ms.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;


        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<DTO.Models.Company> GetCompany(long id)
        {
            return CompanyMapper.Map(await _companyRepository.GetCompany(id));
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            var companyEntities = await _companyRepository.GetAllAsync();
            return CompanyMapper.Map(companyEntities);
        }


    }

}

