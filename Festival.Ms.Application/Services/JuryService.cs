using Festival.Ms.Application.Interfaces.Services;
using Festival.Ms.DAL.Interfaces.Repositories;
using Festival.Ms.DAL.Mappers;
using Festival.Ms.DAL.Repositories;
using Festival.Ms.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival.Ms.Application.Services
{
    public class JuryService : IJuryService
    {
        private readonly IJuryRepository _juriRepository;

        public JuryService(IJuryRepository juriRepository)
        {
            _juriRepository = juriRepository;
        }

        public async Task<DTO.Models.Jury>GetJury(long id)
        {
            return JuryMapper.Map(await _juriRepository.GetJury(id));
        }

        public async Task<IEnumerable<Jury>> GetAllAsync()
        {
            var juryEntities = await _juriRepository.GetAllAsync();
            return JuryMapper.Map(juryEntities);
        }
    }
}
